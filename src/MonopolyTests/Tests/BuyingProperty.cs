using MonopolyTests.Builders;
using NUnit.Framework;
using System.Linq;

namespace MonopolyTests.Tests
{
  [TestFixture]
  public class BuyingProperty : WebTestBase
  {
    [Test]
    public void When_buying_a_property__should_add_it_to_my_property_holdings()
    {
      TestHelper.StartAGame();
      TestHelper.WithHumanRolls(new[] {6, 10, 10, 10, 10}, () =>
      {
        browser.ClickButton("Roll");
        browser.ClickButton("Buy ($80)");

        var allOptionTags = browser.FindAllCss(".player-card#player-1 select.holdings option").ToList();
        Assert.AreEqual(1, allOptionTags.Count());
        Assert.AreEqual("Oriental", allOptionTags.First().Value); 
      });
    }
  }
}