using MonopolyTests.Builders;
using NUnit.Framework;

namespace MonopolyTests.Tests
{
  [TestFixture]
  public class BuyingProperty : WebTestBase
  {
    [Test]
    public void When_buying_a_property__should_add_it_to_my_property_holdings()
    {
      TestHelper.StartAGame();
      TestHelper.WithHardcodedDiceRolls(new[] {6, 10, 10, 10, 10}, () =>
      {
        browser.ClickButton("Roll");
        browser.ClickButton("Buy");

        var properties = browser.FindAllCss(".player-card#player-1 holdings");
        Assert.Fail();
      });
    }
  }
}