using System.Linq;
using MonopolyWeb.Models.Core;

namespace MonopolyWeb.Models.Services
{
  public static class ComputerAi
  {
    public static void DoComputerTurns(Game game)
    {
      foreach (var robotPlayer in game.Players.Where(x => !x.IsHuman))
      {
        RollService.RollForPlayer(game, robotPlayer);
        if (PropertyService.CanBuyProperty(game, robotPlayer))
          game.BuyPropertyForPlayer(robotPlayer);
      }
    }
  }
}