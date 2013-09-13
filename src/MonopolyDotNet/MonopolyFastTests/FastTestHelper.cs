using System;
using System.Linq;
using MonopolyWeb.Models.Core;

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

    public static void WithDiceRolls(int[] rolls, Action action)
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
  }
}