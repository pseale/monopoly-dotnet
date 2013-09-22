using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.Services;

namespace MonopolyWeb.Models.Commands
{
  public class RollDiceCommand
  {
    public static void Execute(Game game)
    {
      RollService.RollForPlayer(game, game.Players[0]);

      if (!PropertyService.CanBuyProperty(game, game.Players[0]))
        ComputerAi.DoComputerTurns(game);
    }
  }
}