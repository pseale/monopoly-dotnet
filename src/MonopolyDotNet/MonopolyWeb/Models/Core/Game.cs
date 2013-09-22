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

    private Player CreateHumanPlayer(NewGameData data)
    {
      var humanPlayer = new Player(data.PlayerName, data.PlayerTotem, true, 1); 
      return humanPlayer;
    }

    private Player CreateOpponent(string opponentName, int playerIndex, Totem totem)
    {
      var opponent1 = new Player(opponentName, totem, false, playerIndex);
      return opponent1;
    }

    private Player GetHumanPlayer()
    {
      return _players[0];
    }

    public void Roll()
    {
      RollForPlayer(GetHumanPlayer());

      if (!CanBuyProperty(GetHumanPlayer()))
        DoComputerTurns();
    }

    public void BuyProperty()
    {
      GetHumanPlayer().BuyProperty();
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
        player.PassGo();
      }
      else if (newLocation == boardSize)
      {
        player.PassesGoOnNextRoll = true;
      }
      else if (player.PassesGoOnNextRoll)
      {
        player.PassesGoOnNextRoll = false;
        player.PassGo();
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
      var allOtherPlayers = GetOpponents(player);
      var otherPlayersProperty = allOtherPlayers.SelectMany(x => x.Holdings);
      var matchingProperties = otherPlayersProperty.Where(x => x == player.Location.Property).ToList();
      if (!matchingProperties.Any())
        return;

      var matchingProperty = matchingProperties.First();
      var propertyOwner = _players.Where(x => x.Holdings.Contains(matchingProperty)).First();

      player.PayRent(matchingProperty.Rent);
      propertyOwner.ReceiveRent(matchingProperty.Rent);
    }

    private IEnumerable<Player> GetOpponents(Player player)
    {
      return _players.Where(x => x != player);
    }

    private void DoComputerTurns()
    {
      foreach (var robotPlayer in _players.Where(x => !x.IsHuman))
      {
        RollForPlayer(robotPlayer);
        if (CanBuyProperty(robotPlayer))
        {
          robotPlayer.BuyProperty();
        }
      }
    }

    public GameStatus GetCurrentGameStatus()
    {
      var humanPlayer = GetHumanPlayer();
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

    private bool CanBuyProperty(Player player)
    {
      if (!player.Location.HasAProperty)
        return false;

      var someoneOwnsThisProperty = _players.SelectMany(x => x.Holdings).Any(x => x == player.Location.Property);
      if (someoneOwnsThisProperty)
        return false;

      return player.CanAffordProperty();
    }
  }
}