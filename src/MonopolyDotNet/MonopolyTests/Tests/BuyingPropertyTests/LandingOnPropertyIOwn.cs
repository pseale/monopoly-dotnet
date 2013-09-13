using MonopolyTests.Builders;
using NUnit.Framework;

namespace MonopolyTests.Tests.BuyingPropertyTests
{
  [TestFixture]
  public class LandingOnPropertyIOwn : WebTestBase
  {
    [Test]
    public void When_landing_on_a_property_that_I_own__should_not_be_able_to_buy_that_property()
    {
      TestHelper.StartAGame();
      TestHelper.WithHardcodedDiceRolls(new[] { 6, 10, 10, 10, 10}, () =>
      {
        browser.ClickButton("Roll");
        browser.ClickButton("Buy");

        browser.ClickButton("Roll");
        browser.ClickButton("Roll");
        browser.ClickButton("Roll");
        browser.ClickButton("Roll");

        var button = browser.FindButton("Buy");

        Assert.IsFalse(button.Exists());
      });
    }
  }
}