using Coypu.Drivers;
using MonopolyTests.Builders;
using NUnit.Framework;

namespace MonopolyTests.Tests
{
  [TestFixture]
  public class PassingGo : WebTestBase
  {
    [Test]
    public void When_passing_GO__collect_200_dollars()
    {
      TestHelper.StartAGame();
      TestHelper.ReplaceRandomRollsWith(10);

      browser.ClickButton("Roll");
      browser.ClickButton("Roll");
      browser.ClickButton("Roll");
      browser.ClickButton("Roll"); //arrives at GO
      browser.ClickButton("Roll"); //passes GO

      Assert.IsTrue(browser.PlayerHasMoney(1700));

      TestHelper.ResetRolls();
    }

    [Test]
    public void When_arriving_at_GO__do_NOT_collect_200_dollars()
    {
      TestHelper.StartAGame();
      TestHelper.ReplaceRandomRollsWith(10);

      browser.ClickButton("Roll");
      browser.ClickButton("Roll");
      browser.ClickButton("Roll");
      browser.ClickButton("Roll"); //arrives at GO

      Assert.IsTrue(browser.PlayerHasMoney(1500));

      TestHelper.ResetRolls();
    }
  }
}