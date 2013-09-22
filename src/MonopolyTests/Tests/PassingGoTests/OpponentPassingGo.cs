using MonopolyTests.Builders;
using NUnit.Framework;

namespace MonopolyTests.Tests.PassingGoTests
{
  [TestFixture]
  public class OpponentPassingGo : WebTestBase
  {
    [Test]
    public void When_opponent_passes_GO__collect_200_dollars()
    {
      TestHelper.StartAGame();
      TestHelper.WithOpponent1Roll(10, () =>
      {
        browser.ClickButton("Roll");
        browser.ClickButton("Roll");
        browser.ClickButton("Roll");
        browser.ClickButton("Roll"); //arrives at GO
        browser.ClickButton("Roll"); //passes GO

        Assert.IsTrue(browser.Opponent1HasMoney(1700));
      });
    }
  }
}