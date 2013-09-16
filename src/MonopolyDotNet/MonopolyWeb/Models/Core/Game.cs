﻿using System;
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
      const int boardSize = 40;

      var player = _players[0];
      int newLocation = player.Location.Index + Dice.Roll();

      if (newLocation > boardSize)
      {
        PassGo();
      }
      else if (newLocation == boardSize)
      {
        player.PassesGoOnNextRoll = true;
      }
      else if (player.PassesGoOnNextRoll)
      {
        player.PassesGoOnNextRoll = false;
        PassGo();
      }

      newLocation %= boardSize;
      player.Location = Locations.All[newLocation];
    }

    private void PassGo()
    {
      _players[0].Cash += 200;
    }

    public GameStatus GetCurrentGameStatus()
    {
      var currentGameStatus = new GameStatus();
      currentGameStatus.Players = _players.ToArray().ToList();
      currentGameStatus.CanBuyProperty = CanBuyProperty();
      if (CanBuyProperty())
        currentGameStatus.PropertySalePrice = _players[0].Location.Property.SalePrice;
      return currentGameStatus;
    }

    private bool CanBuyProperty()
    {
      var location = _players[0].Location;
      if (!location.HasAProperty)
        return false;

      if (_players[0].Cash < location.Property.SalePrice)
        return false;

      var doesAnyoneOwnThisProperty = _players.SelectMany(x => x.Holdings).Any(x => x == location.Property);

      return !doesAnyoneOwnThisProperty;
    }

    public void BuyProperty()
    {
      var humanPlayer = _players[0];
      var property = humanPlayer.Location.Property;
      humanPlayer.Holdings.Add(property);
      humanPlayer.Cash -= property.SalePrice;
    }
  }
}