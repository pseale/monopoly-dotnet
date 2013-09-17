using Coypu.Drivers;
using MonopolyTests.Builders;
using NUnit.Framework;

namespace MonopolyTests.Tests.BuyingPropertyTests
{
  [TestFixture]
  public class BuyingAProperty : WebTestBase
  {
    [Test]
    public void When_buying_a_property__should_charge_me_money()
    {
      TestHelper.StartAGame();
      TestHelper.WithHumanRoll(6, () =>
      {
        browser.ClickButton("Roll");
        browser.ClickButton("Buy ($80)");

        Assert.IsTrue(browser.HumanPlayerHasMoney(1500 - 80));
      });
    }
  }
}