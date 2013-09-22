using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyWeb.Models.Services;

namespace MonopolyWeb.Models.Core
{
  public class Game
  {
    public List<Player> Players { get; set; }

    public Game()
    {
      Players = new List<Player>();
    }

    public void BuyProperty()
    {
      BuyPropertyForPlayer(Players[0]);
      EndTurn();
    }

    public void EndTurn()
    {
      ComputerAi.DoComputerTurns(this);
    }

    public void DoRentTransaction(Player player)
    {
      if (!player.Location.HasAProperty)
        return;

      //I hate using reference equality but I'll do it here for player == player and property == property
      var allOtherPlayers = Players.Where(x => x != player);
      var otherPlayersProperty = allOtherPlayers.SelectMany(x => x.Holdings);
      var matchingProperties = otherPlayersProperty.Where(x => x == player.Location.Property).ToList();
      if (!matchingProperties.Any())
        return;

      var matchingProperty = matchingProperties.First();
      var propertyOwner = Players.Where(x => x.Holdings.Contains(matchingProperty)).First();
      
      player.Cash -= matchingProperty.Rent;
      propertyOwner.Cash += matchingProperty.Rent;
    }

    public void PassGo(Player player)
    {
      player.Cash += 200;
    }

    public GameStatus GetCurrentGameStatus()
    {
      var humanPlayer = Players[0];
      var status = new GameStatus();
      status.Players = Players.ToArray().ToList();
      if (PropertyService.CanBuyProperty(this, humanPlayer))
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

    public void BuyPropertyForPlayer(Player player)
    {
      var property = player.Location.Property;
      player.Holdings.Add(property);
      player.Cash -= property.SalePrice;
    }
  }
}