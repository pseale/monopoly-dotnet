using System;
using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.Services;

namespace MonopolyWeb.Models.Commands
{
  public static class CreateGameCommand
  {
    public static void Execute(Guid playerId, NewGameData newGameData)
    {
      InMemoryGameStorage.Games[playerId] = new Game(newGameData);
    }
  }
}