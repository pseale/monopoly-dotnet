using MonopolyTests.Builders;
using NUnit.Framework;

namespace MonopolyTests.Tests.PassingGoTests
{
  [TestFixture]
  public class OpponentArrivingAtGo : WebTestBase
  {
    [Test]
    public void When_opponent_arrives_at_GO__do_NOT_collect_200_dollars()
    {
      TestHelper.StartAGame();
      TestHelper.WithOpponent1Roll(10, () =>
      {
        browser.ClickButton("Roll");
        browser.ClickButton("Roll");
        browser.ClickButton("Roll");
        browser.ClickButton("Roll"); //opponent 1 arrives at GO

        Assert.IsTrue(browser.Opponent1HasMoney(1500));
      });
    }
  }
}