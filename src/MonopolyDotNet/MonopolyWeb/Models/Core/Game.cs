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
      RollForPlayer(_players[0]);

      if (!CanBuyProperty(_players[0]))
        DoComputerTurns();
    }

    public void BuyProperty()
    {
      BuyPropertyForPlayer(_players[0]);
      EndTurn();
    }

    public void EndTurn()
    {
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

      DoRentTransaction(player);
    }

    private void DoRentTransaction(Player player)
    {
      if (!player.Location.HasAProperty)
        return;

      //I hate using reference equality but I'll do it here for player == player and property == property
      var allOtherPlayers = _players.Where(x => x != player);
      var otherPlayersProperty = allOtherPlayers.SelectMany(x => x.Holdings);
      var matchingProperties = otherPlayersProperty.Where(x => x == player.Location.Property).ToList();
      if (!matchingProperties.Any())
        return;

      var matchingProperty = matchingProperties.First();
      var propertyOwner = _players.Where(x => x.Holdings.Contains(matchingProperty)).First();
      
      player.Cash -= matchingProperty.Rent;
      propertyOwner.Cash += matchingProperty.Rent;
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
      var status = new GameStatus();
      status.Players = _players.ToArray().ToList();
      if (CanBuyProperty(humanPlayer))
      {
        status.CanRoll = false;
        status.CanBuyProperty = true;
        status.CanEndTurn = true;
        status.PropertySalePrice = humanPlayer.Location.Property.SalePrice;
      }
      else
      {
        status.CanRoll = true;
        status.CanBuyProperty = false;
        status.CanEndTurn = false;
      }

      return status;
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

    private static void BuyPropertyForPlayer(Player player)
    {
      var property = player.Location.Property;
      player.Holdings.Add(property);
      player.Cash -= property.SalePrice;
    }
  }
}