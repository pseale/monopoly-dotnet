using System.Linq;
using MonopolyWeb.Models.Core;

namespace MonopolyWeb.Models.Services
{
  public static class GameStatusService
  {

    public static GameStatus GetCurrentGameStatus(Game game)
    {
      var humanPlayer = game.Players[0];
      var status = new GameStatus();
      status.Players = game.Players.ToArray().ToList();
      if (PropertyService.CanBuyProperty(game, humanPlayer))
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
  }
}