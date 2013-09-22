using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.Services;

namespace MonopolyWeb.Models.Commands
{
  public static class CreateGameCommand
  {
    public static void Execute(string username, NewGameData newGameData)
    {
      var game = new Game();
      game.Players.Add(CreateHumanPlayer(newGameData));

      var allTotems = Enum.GetValues(typeof(Totem)).Cast<Totem>().ToList();
      allTotems.Remove(newGameData.PlayerTotem);
      var availableTotems = new Stack<Totem>(allTotems);

      game.Players.Add(CreateOpponent(newGameData.Opponent1Name, 2, availableTotems.Pop()));
      game.Players.Add(CreateOpponent(newGameData.Opponent2Name, 3, availableTotems.Pop()));
      game.Players.Add(CreateOpponent(newGameData.Opponent3Name, 4, availableTotems.Pop()));

      InMemoryGameStorage.Games[username] = game;
    }

    private static Player CreateHumanPlayer(NewGameData newGameData)
    {
      var humanPlayer = new Player() { Cash = 1500, Location = Locations.Go };
      humanPlayer.IsHuman = true;
      humanPlayer.Name = newGameData.PlayerName;
      humanPlayer.Totem = newGameData.PlayerTotem;
      humanPlayer.Index = 1;
      return humanPlayer;
    }

    private static Player CreateOpponent(string opponentName, int playerIndex, Totem totem)
    {
      var opponent1 = new Player() { Cash = 1500, Location = Locations.Go };
      opponent1.Name = opponentName;
      opponent1.Index = playerIndex;
      opponent1.Totem = totem;
      return opponent1;
    }
  }
}