using System;
using System.Collections.Generic;

namespace MonopolyWeb.Models.Core
{
  public static class Dice
  {
    private static readonly Random RandomNumberGenerator = new Random();

    public static readonly Func<int> StandardBehavior =
      () => RandomNumberGenerator.Next(1, 6) + RandomNumberGenerator.Next(1, 6);

    private static int[] _hardcodedRolls = new int[0];
    private static int _index = 0;
    public static void ReplaceRandomRollsWith(List<int> rolls)
    {
      _hardcodedRolls = rolls.ToArray();
      _index = 0;
      Roll = () =>
      {
        if (_index >= _hardcodedRolls.Length)
          _index = 0;
        return _hardcodedRolls[_index++];
      };
    }

    public static Func<int> Roll = StandardBehavior;
  }
}