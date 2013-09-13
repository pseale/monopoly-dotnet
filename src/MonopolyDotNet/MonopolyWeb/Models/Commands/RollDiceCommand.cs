using MonopolyWeb.Models.Core;

namespace MonopolyWeb.Models.Commands
{
  public class RollDiceCommand
  {
    public static void Execute(Game game)
    {
      game.Roll();
    }
  }
}