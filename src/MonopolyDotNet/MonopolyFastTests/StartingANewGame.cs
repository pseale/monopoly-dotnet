using System;
using MonopolyWeb.Models.Core;
using NUnit.Framework;

namespace MonopolyFastTests
{
  [TestFixture]
  public class StartingANewGame
  {
    [Test]
    public void When_starting_a_new_game__should_set_the_starting_location_to_GO()
    {
      var game = new Game();
      var tokens = game.GetTotemLocations();

      Assert.AreEqual(0, tokens[0]);
      Assert.AreEqual(0, tokens[1]);
      Assert.AreEqual(0, tokens[2]);
      Assert.AreEqual(0, tokens[3]);
    }
  
    [Test]
    public void When_rolling_a_1_from_GO__should_change_the_players_location_to_Mediterranean()
    {
      WithDiceBehavior(() => 1, () =>
      {
        var game = new Game();
        game.Roll();

        var tokens = game.GetTotemLocations();
        var playerToken = tokens[0];

        Assert.AreEqual(1, playerToken);
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