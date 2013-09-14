using System.Collections.Generic;
using System.Linq;

namespace MonopolyWeb.Models.Core
{
  public class Game
  {
    private readonly List<Player> _players = new List<Player>();

    public Game(NewGameData newGameData)
    {
      var locationGo = Locations.All[0];

      var humanPlayer = new Player() { Cash = 1500, Location = locationGo };
      humanPlayer.IsHuman = true;
      humanPlayer.Name = newGameData.PlayerName;
      _players.Add(humanPlayer);

      var opponent1 = new Player() { Cash = 1500, Location = locationGo };
      opponent1.Name = newGameData.Opponent1Name;
      _players.Add(opponent1);

      var opponent2 = new Player() { Cash = 1500, Location = locationGo };
      opponent2.Name = newGameData.Opponent2Name;
      _players.Add(opponent2);

      var opponent3 = new Player() { Cash = 1500, Location = locationGo };
      opponent3.Name = newGameData.Opponent3Name;
      _players.Add(opponent3);
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