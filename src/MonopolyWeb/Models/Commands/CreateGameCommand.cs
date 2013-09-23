using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.Core.EF;

namespace MonopolyWeb.Models.Commands
{
  public static class CreateGameCommand
  {
    public static void Execute(string username, NewGameData newGameData)
    {
      using (var context = new MonopolyDotNetDbContext())
      {
        var game = new Game(newGameData, username);
        context.Games.Add(game);
        context.SaveChanges();
      }
    }
  }
}