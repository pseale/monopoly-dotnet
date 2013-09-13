using System;
using System.Linq;
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
      var players = game.GetPlayers().ToArray();

      Assert.AreEqual(0, players[0].Location);
      Assert.AreEqual(0, players[1].Location);
      Assert.AreEqual(0, players[2].Location);
      Assert.AreEqual(0, players[3].Location);
    }
  
    [Test]
    public void When_rolling_a_1_from_GO__should_change_the_players_location_to_Mediterranean()
    {
      WithDiceBehavior(() => 1, () =>
      {
        var game = new Game();
        game.Roll();

        var players = game.GetPlayers().ToArray();
        var playerOne = players.First();

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