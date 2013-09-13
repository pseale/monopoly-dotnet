using MonopolyWeb.Models.Core;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace MonopolyFastTests
{
  [TestFixture]
  public class LandingOnAPropertyIDontOwn
  {
    [Test]
    public void When_landing_on_a_property_I_dont_own__should_be_able_to_buy_it()
    {
      FastTestHelper.WithDiceBehavior(() => 6, () =>
      {
        var game = new Game();
        game.Roll();

        var gameStatus = game.GetCurrentGameStatus();

        Assert.IsTrue(gameStatus.CanBuyProperty);
      });
    }

    [Test]
    public void When_landing_on_a_property_I_dont_own__should_show_the_correct_sale_price()
    {
      FastTestHelper.WithDiceBehavior(() => 6, () =>
      {
        var game = new Game();
        game.Roll();

        var gameStatus = game.GetCurrentGameStatus();

        Assert.AreEqual(80, gameStatus.PropertySalePrice);
      });
    }
  }
}