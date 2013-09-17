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
    public static void WithHumanDiceRoll(int roll, Action action)
    {
      WithHumanDiceRolls(new[] { roll }, action);
    }

    public static void WithHumanDiceRolls(IEnumerable<int> rolls, Action action)
    {
      var originalBehavior = Dice.Roll;
      try
      {

        Dice.ReplaceRandomRollsWith(GenerateSafeComputerRollsFor(rolls));
        action();
      }
      finally
      {
        Dice.Roll = originalBehavior;
      }
    }

    private static List<int> GenerateSafeComputerRollsFor(IEnumerable<int> humanRolls)
    {
      var list = new List<int>();
      foreach (var humanRoll in humanRolls)
      {
        list.Add(humanRoll);
        list.Add(5); //safe roll, assuming we start from Go, and assuming we don't have railroads in the game, or Jail, or Free parking $$$.
        list.Add(5);
        list.Add(5);
      }
      return list;
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