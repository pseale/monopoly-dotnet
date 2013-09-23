using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.Core.EF;

namespace MonopolyWeb.Models.Commands
{
  public class EndTurnCommand
  {
    public static void Execute(Game game)
    {
      using (var context = new MonopolyDotNetDbContext())
      {
        context.Games.Attach(game);
        game.EndTurn();
        context.SaveChanges();
      }
    }
  }
}