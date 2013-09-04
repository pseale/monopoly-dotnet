using System;

namespace MonopolyWeb.Models
{
  public static class CreateGameCommand
  {
    public static void Execute(Guid playerId)
    {
      InMemoryGameStorage.Games[playerId] = new Game();
    }
  }
}