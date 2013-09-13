using MonopolyTests.Builders;
using NUnit.Framework;

namespace MonopolyTests.Tests.PassingGoTests
{
  public class ArrivingAtGo : WebTestBase
  {
    [Test]
    public void When_arriving_at_GO__do_NOT_collect_200_dollars()
    {
      TestHelper.StartAGame();
      TestHelper.WithHardcodedDiceRoll(10, () =>
      {
        browser.ClickButton("Roll");
        browser.ClickButton("Roll");
        browser.ClickButton("Roll");
        browser.ClickButton("Roll"); //arrives at GO

        Assert.IsTrue(browser.PlayerHasMoney(1500));
      });
    }
  }
}