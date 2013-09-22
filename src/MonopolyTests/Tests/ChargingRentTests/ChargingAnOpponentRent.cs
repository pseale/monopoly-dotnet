using MonopolyTests.Builders;
using NUnit.Framework;

namespace MonopolyTests.Tests.ChargingRentTests
{
  [TestFixture]
  public class ChargingAnOpponentRent : WebTestBase
  {
    [Test]
    public void When_an_opponent_lands_on_my_property__should_charge_them_rent()
    {
      TestHelper.StartAGame();
      //I want to land on Oriental (roll 6 to get there), buy it, then have exactly 1 opponent land on Oriental after I already own it.
      TestHelper.WithRolls(new[] {6, 6, 7, 7}, () =>
      {
        browser.ClickButton("Roll");
        
        browser.ClickButton("Buy ($80)");

        Assert.IsTrue(browser.Opponent1HasMoney(1500 - 8));
      });
    }

    [Test]
    public void When_an_opponent_lands_on_my_property__should_give_me_their_rent_money()
    {
      TestHelper.StartAGame();
      //I want to land on Oriental (roll 6 to get there), buy it, then have exactly 1 opponent land on Oriental after I already own it.
      TestHelper.WithRolls(new[] { 6, 6, 7, 7 }, () =>
      {
        browser.ClickButton("Roll");

        browser.ClickButton("Buy ($80)");

        Assert.IsTrue(browser.HumanPlayerHasMoney(1500 - 80 + 8));
      });
    }
  }
}