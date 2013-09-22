using MonopolyWeb.Models.Core;

namespace MonopolyWeb.Models.Commands
{
  public class EndTurnCommand
  {
    public static void Execute(Game game)
    {
      game.EndTurn();
    }
  }
}