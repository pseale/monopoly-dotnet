using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MonopolyWeb.Models.Core
{
  public class Game
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; private set; }

    public Game() //EF requires empty constructor
    {
      Players = new List<Player>();
    } 
    public Game(NewGameData newGameData, string username)
    {
      Players = new List<Player>();
      Players.AddRange(newGameData.GetPlayers());
      Username = username;
    }

    public string Username { get; private set; }

    public virtual List<Player> Players { get; set; } // EF requires? would prefer that this is a private field

    private Player GetHumanPlayer()
    {
      return Players.First(x=>x.IsHuman);
    }

    private IEnumerable<Player> GetOpponents(Player player)
    {
      return Players.Where(x => !Equals(x, player));
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
      var matchingProperties = otherPlayersProperty.Where(x => Equals(x, player.Location.Property)).ToList();
      if (!matchingProperties.Any())
        return;

      var matchingProperty = matchingProperties.First();
      var propertyOwner = Players.Where(x => x.Holdings.Any(y=>y.Equals(matchingProperty))).First();

      player.PayRentTo(propertyOwner);
    }

    private void DoComputerTurns()
    {
      foreach (var robotPlayer in Players.Where(x => !x.IsHuman))
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
      status.Players = Players.ToArray().ToList();
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

      var someoneOwnsThisProperty = Players.SelectMany(x => x.Holdings).Any(x => Equals(x, player.Location.Property));
      if (someoneOwnsThisProperty)
        return false;

      return player.CanAffordProperty();
    }
  }
}