using System;

namespace MonopolyWeb.Models.Core
{
  public static class Dice
  {
    private static readonly Random RandomNumberGenerator = new Random();

    public static Func<int> Roll = () => RandomNumberGenerator.Next(1, 6) + RandomNumberGenerator.Next(1, 6);
  }
}