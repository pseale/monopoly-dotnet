using System;
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
  }
}