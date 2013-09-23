using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.Core.EF;

namespace MonopolyWeb.Models.Commands
{
  public static class RollDiceCommand
  {
    public static void Execute(Game game)
    {
      using (var context = new MonopolyDotNetDbContext())
      {
        context.Games.Attach(game);
        game.Roll();
        context.SaveChanges();
      }
    }
  }
}