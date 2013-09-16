using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyWeb.Models.Commands;
using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.Queries;

namespace MonopolyFastTests
{
  public static class FastTestHelper
  {
    public static void WithDiceBehavior(Func<int> diceBehavior, Action action)
    {
      var originalBehavior = Dice.Roll;
      try
      {
        Dice.Roll = diceBehavior;
        action();
      }
      finally
      {
        Dice.Roll = originalBehavior;
      }
    }

    public static void WithDiceRolls(IEnumerable<int> rolls, Action action)
    {
      var originalBehavior = Dice.Roll;
      try
      {
        Dice.ReplaceRandomRollsWith(rolls.ToList());
        action();
      }
      finally
      {
        Dice.Roll = originalBehavior;
      }
    }

    public static Game StartGame()
    {
      var playerId = Guid.NewGuid();
      var newGameData = new NewGameData("Tron", Totem.Dog, "Rube", "Chester", "Adolf");

      CreateGameCommand.Execute(playerId, newGameData);
      var game = FindGameByPlayerIdQuery.Execute(playerId);
      return game;
    }
  }
}