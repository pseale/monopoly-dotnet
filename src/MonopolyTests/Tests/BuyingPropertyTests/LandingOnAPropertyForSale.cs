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

    [Test]
    public void When_landing_on_a_property_for_sale__should_be_able_to_end_my_turn_without_buying_it()
    {
      TestHelper.StartAGame();
      TestHelper.WithHumanRoll(6, () =>
      {
        browser.ClickButton("Roll");

        var button = browser.FindButton("End Turn");

        Assert.IsTrue(button.Exists());
      });
    }

    //this test assumes we can't extend our turn with doubles
    [Test]
    public void When_landing_on_a_property_for_sale__should_not_be_able_to_roll_for_my_next_turn()
    {
      TestHelper.StartAGame();
      TestHelper.WithHumanRoll(6, () =>
      {
        browser.ClickButton("Roll");

        var button = browser.FindButton("Roll");

        Assert.IsFalse(button.Exists());
      });
    }
  }
}