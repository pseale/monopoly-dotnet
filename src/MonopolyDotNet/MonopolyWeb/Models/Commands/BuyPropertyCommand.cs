using MonopolyWeb.Models.Core;

namespace MonopolyWeb.Models.Commands
{
  public static class BuyPropertyCommand
  {
    public static void Execute(Game game)
    {
      game.BuyProperty();
    }
  }
}