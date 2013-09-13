﻿using System;
using System.Linq;
using MonopolyWeb.Models.Core;
using NUnit.Framework;

namespace MonopolyFastTests
{
  [TestFixture]
  public class RollingDice
  {
    [Test]
    public void When_rolling_a_1_from_GO__should_change_the_players_location_to_Mediterranean()
    {
      WithDiceBehavior(() => 1, () =>
      {
        var game = new Game();
        game.Roll();

        var gameStatus = game.GetCurrentGameStatus();
        var playerOne = gameStatus.Players.First();

        Assert.AreEqual(1, playerOne.Location);
      });
    }

    private void WithDiceBehavior(Func<int> diceBehavior, Action action)
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