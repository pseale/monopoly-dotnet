using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.Services;

namespace MonopolyWeb.Models.Commands
{
  public class EndTurnCommand
  {
    public static void Execute(Game game)
    {
      ComputerAi.DoComputerTurns(game);
    }
  }
}