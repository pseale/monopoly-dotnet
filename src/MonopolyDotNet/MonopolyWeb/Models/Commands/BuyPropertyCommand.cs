using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.Services;

namespace MonopolyWeb.Models.Commands
{
  public static class BuyPropertyCommand
  {
    public static void Execute(Game game)
    {
      PropertyService.BuyProperty(game.Players[0]);
      ComputerAi.DoComputerTurns(game);
    }
  }
}