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
      var game = FastTestHelper.StartGame();
      var gameStatus = game.GetCurrentGameStatus();
      var players = gameStatus.Players;

      Assert.AreEqual(0, players[0].Location.Index);
      Assert.AreEqual(0, players[1].Location.Index);
      Assert.AreEqual(0, players[2].Location.Index);
      Assert.AreEqual(0, players[3].Location.Index);
    }

    [Test]
    public void When_starting_a_new_game__should_not_be_able_to_buy_property()
    {
      var game = FastTestHelper.StartGame();
      var gameStatus = game.GetCurrentGameStatus();

      Assert.IsFalse(gameStatus.CanBuyProperty);
    }
  }
}