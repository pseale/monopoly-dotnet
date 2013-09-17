using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyWeb.Models.Core
{
  public class Game
  {
    private readonly List<Player> _players = new List<Player>();

    public Game(NewGameData newGameData)
    {
      _players.Add(CreateHumanPlayer(newGameData));

      var allTotems = Enum.GetValues(typeof(Totem)).Cast<Totem>().ToList();
      allTotems.Remove(newGameData.PlayerTotem);
      var availableTotems = new Stack<Totem>(allTotems);

      _players.Add(CreateOpponent(newGameData.Opponent1Name, 2, availableTotems.Pop()));
      _players.Add(CreateOpponent(newGameData.Opponent2Name, 3, availableTotems.Pop()));
      _players.Add(CreateOpponent(newGameData.Opponent3Name, 4, availableTotems.Pop()));
    }

    private Player CreateHumanPlayer(NewGameData newGameData)
    {
      var humanPlayer = new Player() {Cash = 1500, Location = Locations.Go};
      humanPlayer.IsHuman = true;
      humanPlayer.Name = newGameData.PlayerName;
      humanPlayer.Totem = newGameData.PlayerTotem;
      humanPlayer.Index = 1;
      return humanPlayer;
    }

    private Player CreateOpponent(string opponentName, int playerIndex, Totem totem)
    {
      var opponent1 = new Player() {Cash = 1500, Location = Locations.Go};
      opponent1.Name = opponentName;
      opponent1.Index = playerIndex;
      opponent1.Totem = totem;
      return opponent1;
    }

    public void Roll()
    {

      var player = _players[0];
      RollForPlayer(player);

      //assumes turn is always over after a roll, which is true until we implement extending turns via rolls with doubles
      DoComputerTurns();
    }

    private void RollForPlayer(Player player)
    {
      const int boardSize = 40;
      int newLocation = player.Location.Index + Dice.Roll();

      if (newLocation > boardSize)
      {
        PassGo(player);
      }
      else if (newLocation == boardSize)
      {
        player.PassesGoOnNextRoll = true;
      }
      else if (player.PassesGoOnNextRoll)
      {
        player.PassesGoOnNextRoll = false;
        PassGo(player);
      }

      newLocation %= boardSize;
      player.Location = Locations.All[newLocation];
    }

    private void DoComputerTurns()
    {
      foreach (var robotPlayer in _players.Where(x => !x.IsHuman))
      {
        RollForPlayer(robotPlayer);
        if (CanBuyProperty(robotPlayer))
          BuyPropertyForPlayer(robotPlayer);
      }
    }

    private void PassGo(Player player)
    {
      player.Cash += 200;
    }

    public GameStatus GetCurrentGameStatus()
    {
      var humanPlayer = _players[0];
      var currentGameStatus = new GameStatus();
      currentGameStatus.Players = _players.ToArray().ToList();
      currentGameStatus.CanBuyProperty = CanBuyProperty(humanPlayer);
      if (CanBuyProperty(humanPlayer))
        currentGameStatus.PropertySalePrice = humanPlayer.Location.Property.SalePrice;
      return currentGameStatus;
    }

    //This would go really well on the Player object but I'm still trying to keep all the model objects underneath Game dumb for now. We'll
    //see when the pressure becomes too much and I have to just move the logic to the currently "dumb" objects like Player. But know
    //that I see that this would be the #1 candidate to move off of Game.
    private bool CanBuyProperty(Player player)
    {
      var location = player.Location;
      if (!location.HasAProperty)
        return false;

      if (player.Cash < location.Property.SalePrice)
        return false;

      var doesAnyoneOwnThisProperty = _players.SelectMany(x => x.Holdings).Any(x => x == location.Property);

      return !doesAnyoneOwnThisProperty;
    }

    public void BuyProperty()
    {
      BuyPropertyForPlayer(_players[0]);
    }

    private static void BuyPropertyForPlayer(Player player)
    {
      var property = player.Location.Property;
      player.Holdings.Add(property);
      player.Cash -= property.SalePrice;
    }
  }
}