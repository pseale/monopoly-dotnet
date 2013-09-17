using MonopolyTests.Builders;
using NUnit.Framework;

namespace MonopolyTests.Tests.BuyingPropertyTests
{
  [TestFixture]
  public class LandingOnAPropertyForSale : WebTestBase
  {
    [Test]
    public void When_landing_on_a_property_for_sale__should_be_able_to_buy_that_property()
    {
      TestHelper.StartAGame();
      TestHelper.WithHumanRoll(6, () =>
      {
        browser.ClickButton("Roll");

        var button = browser.FindButton("Buy ($80)");

        Assert.IsTrue(button.Exists());
      });
    }
  }
}