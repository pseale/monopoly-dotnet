using System;
using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.Services;

namespace MonopolyWeb.Models.Commands
{
  public static class CreateGameCommand
  {
    public static void Execute(Guid playerId)
    {
      InMemoryGameStorage.Games[playerId] = new Game();
    }
  }
}