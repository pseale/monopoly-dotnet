using System.Collections.Generic;
using System.Linq;

namespace MonopolyWeb.Models.Core
{
  public class Game
  {
    private readonly List<Player> _players = new List<Player>(); 

    public Game()
    {
      for (int i=0; i<4; i++)
        _players.Add(new Player() { Cash = 1500 });
    }

    public void Roll()
    {
      var player = _players[0];
      player.Location += Dice.Roll();
      
      if (player.Location > 40)
      {
        PassGo();
      }
      else if (player.Location == 40)
      {
        player.PassesGoOnNextRoll = true;
      }
      else if (player.PassesGoOnNextRoll)
      {
        player.PassesGoOnNextRoll = false;
        PassGo();
      }

      player.Location %= 40;
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
        currentGameStatus.PropertySalePrice = Locations.All[_players[0].Location].Property.SalePrice;
      return currentGameStatus;
    }

    private bool CanBuyProperty()
    {
      var location = Locations.All[_players[0].Location];
      if (!location.HasAProperty)
        return false;

      var doesAnyoneOwnThisProperty = _players.SelectMany(x => x.Holdings).Any(x => x == location.Property);

      return !doesAnyoneOwnThisProperty;
    }

    public void BuyProperty()
    {
      var humanPlayer = _players[0];
      var property = Locations.All[humanPlayer.Location].Property;
      humanPlayer.Holdings.Add(property);
      humanPlayer.Cash -= property.SalePrice;
    }
  }
}