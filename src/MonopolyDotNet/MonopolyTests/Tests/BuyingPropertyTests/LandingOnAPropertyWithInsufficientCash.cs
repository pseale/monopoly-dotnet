using MonopolyTests.Builders;
using NUnit.Framework;

namespace MonopolyTests.Tests.BuyingPropertyTests
{
  [TestFixture]
  public class LandingOnAPropertyWithInsufficientCash : WebTestBase
  {
    [Test]
    public void When_landing_on_a_property_for_sale__with_insufficient_cash__should_not_be_able_to_buy_it()
    {
      TestHelper.StartAGame();
      TestHelper.WithHardcodedDiceRolls(new[] {3, 3, 3, 2, 3, 2, 3, 2, 3, 2}, () =>
      {
        browser.ClickButton("Roll");
        browser.ClickButton("Buy ($60)");
        browser.ClickButton("Roll");
        browser.ClickButton("Buy ($80)");
        browser.ClickButton("Roll");
        browser.ClickButton("Buy ($100)");
        browser.ClickButton("Roll");
        browser.ClickButton("Buy ($120)");
        browser.ClickButton("Roll");
        browser.ClickButton("Buy ($140)");
        browser.ClickButton("Roll");
        browser.ClickButton("Buy ($160)");
        browser.ClickButton("Roll");
        browser.ClickButton("Buy ($180)");
        browser.ClickButton("Roll");
        browser.ClickButton("Buy ($200)");
        browser.ClickButton("Roll");
        browser.ClickButton("Buy ($220)");
        browser.ClickButton("Roll");
        browser.ClickButton("Buy ($240)"); //Buy Illinois
        browser.ClickButton("Roll");

        var button = browser.FindButton("Buy ($260)");
        
        Assert.IsFalse(button.Exists());
      });
    }
  }
}