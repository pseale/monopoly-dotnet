using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.ViewModels;

namespace MonopolyWeb.Models.Services
{
  public static class GameFormatter
  {
    public static GameStatus Flatten(Game game)
    {
      var gameStatus = new GameStatus();
      var locations = game.GetTotemLocations();
      gameStatus.Player1OffsetFromLeft = (locations[0].OffsetFromLeft - 15 - 5).ToString();
      gameStatus.Player1OffsetFromTop = (locations[0].OffsetFromTop - 15 - 40).ToString();
      gameStatus.Player2OffsetFromLeft = (locations[1].OffsetFromLeft - 15 + 5).ToString();
      gameStatus.Player2OffsetFromTop = (locations[1].OffsetFromTop - 15 - 20).ToString();
      gameStatus.Player3OffsetFromLeft = (locations[2].OffsetFromLeft - 15 - 2).ToString();
      gameStatus.Player3OffsetFromTop = (locations[2].OffsetFromTop - 15 - 0).ToString();
      gameStatus.Player4OffsetFromLeft = (locations[3].OffsetFromLeft - 15 + 1).ToString();
      gameStatus.Player4OffsetFromTop = (locations[3].OffsetFromTop - 15 + 20).ToString();

      return gameStatus;
    }
  }
}