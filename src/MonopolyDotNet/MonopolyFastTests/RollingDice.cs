using System;
using System.Linq;
using MonopolyWeb.Models.Commands;
using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.Services;
using NUnit.Framework;

namespace MonopolyFastTests
{
  [TestFixture]
  public class RollingDice
  {
    [Test]
    public void When_rolling_a_3_from_GO__should_move_the_player_to_Baltic()
    {
      FastTestHelper.WithHumanDiceRoll(3, () =>
      {
        var game = FastTestHelper.StartGame();
        RollDiceCommand.Execute(game);

        var gameStatus = GameStatusService.GetCurrentGameStatus(game);
        var playerOne = gameStatus.Players.First();

        Assert.AreEqual(3, playerOne.Location.Index);
      });
    }
  }
}