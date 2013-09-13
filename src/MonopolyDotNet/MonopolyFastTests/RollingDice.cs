using System;
using System.Linq;
using MonopolyWeb.Models.Core;
using NUnit.Framework;

namespace MonopolyFastTests
{
  [TestFixture]
  public class RollingDice
  {
    [Test]
    public void When_rolling_a_3_from_GO__should_move_the_player_to_Baltic()
    {
      FastTestHelper.WithDiceBehavior(() => 3, () =>
      {
        var game = new Game();
        game.Roll();

        var gameStatus = game.GetCurrentGameStatus();
        var playerOne = gameStatus.Players.First();

        Assert.AreEqual(3, playerOne.Location);
      });
    }
  }
}