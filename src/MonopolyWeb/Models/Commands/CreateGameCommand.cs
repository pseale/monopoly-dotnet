using System;
using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.Services;

namespace MonopolyWeb.Models.Commands
{
  public static class CreateGameCommand
  {
    public static void Execute(string username, NewGameData newGameData)
    {
      InMemoryGameStorage.Games[username] = new Game(newGameData);
    }
  }
}