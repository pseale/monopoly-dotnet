using MonopolyWeb.Models.Core;
using NUnit.Framework;

namespace MonopolyFastTests
{
  [TestFixture]
  public class LandingOnAPropertyIAlreadyOwn
  {
    [Test]
    public void When_landing_on_a_property_I_own__should_not_be_able_to_buy_it()
    {
      FastTestHelper.WithHumanDiceRolls(new[] { 6, 10, 10, 10, 10 }, () =>
      {
        var game = FastTestHelper.StartGame(); 
        game.Roll();
        game.BuyProperty();
        game.Roll();
        game.Roll();
        game.Roll();
        game.Roll();

        var gameStatus = game.GetCurrentGameStatus();

        Assert.IsFalse(gameStatus.CanBuyProperty);
      });
    }
  }
}