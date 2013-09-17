using MonopolyTests.Builders;
using NUnit.Framework;

namespace MonopolyTests.Tests
{
  [TestFixture]
  public class OpponentBuyingProperty : WebTestBase
  {
    [Test]
    public void When_opponent_lands_on_a_property_for_sale__should_buy_it()
    {
      TestHelper.StartAGame();
      TestHelper.WithOpponent1Roll(6, () =>
      {
        browser.ClickButton("Roll");

        Assert.IsTrue(browser.Opponent1HasMoney(1500 - 80));
      });
    }
  }
}