using MonopolyTests.Builders;
using NUnit.Framework;

namespace MonopolyTests.Tests
{
  [TestFixture]
  public class BuyingProperty : WebTestBase
  {
    [Test]
    public void When_landing_on_a_property_for_sale__should_be_able_to_buy_that_property()
    {
      TestHelper.StartAGame();
      TestHelper.ReplaceRandomRollsWith(6);

      browser.ClickButton("Roll");

      var button = browser.FindButton("Buy ($100)");

      Assert.IsTrue(button.Exists());

      TestHelper.ResetRolls();
    }

    [Test]
    public void When_landing_on_a_property_that_I_own__should_not_be_able_to_buy_that_property()
    {
      TestHelper.StartAGame();
      TestHelper.ReplaceRandomRollsWith(6, 10, 10, 10, 10);

      browser.ClickButton("Roll");
      browser.ClickButton("Buy");

      browser.ClickButton("Roll");
      browser.ClickButton("Roll");
      browser.ClickButton("Roll");
      browser.ClickButton("Roll");

      var button = browser.FindButton("Buy");

      Assert.IsFalse(button.Exists());

      TestHelper.ResetRolls();
    }

    [Test]
    public void When_purchasing_a_property__should_add_it_to_my_property_holdings()
    {
      TestHelper.StartAGame();
      TestHelper.ReplaceRandomRollsWith(6, 10, 10, 10, 10);

      browser.ClickButton("Roll");
      browser.ClickButton("Buy");

      var properties = browser.FindAllCss(".player-card#player-1 property");

      TestHelper.ResetRolls();
    }
  }
}