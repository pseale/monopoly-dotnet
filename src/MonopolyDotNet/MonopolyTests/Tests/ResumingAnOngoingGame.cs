using NUnit.Framework;

namespace MonopolyTests.Tests
{
  [TestFixture]
  public class ResumingAnOngoingGame : WebTestBase
  {
    [Test]
    public void When_a_game_has_started__should_be_able_to_find_the_ongoing_game_from_the_home_page()
    {
      browser.Visit("/NewGame");

      browser.FillIn("Name").With("Tron");
      browser.Choose("Dog");
      browser.FindFieldset("Opponent 1").Choose("Rube");
      browser.FindFieldset("Opponent 2").Choose("Chester");
      browser.FindFieldset("Opponent 3").Choose("Adolf");

      browser.ClickButton("Submit");

      browser.Visit("/");

      Assert.IsTrue(browser.FindLink("Resume Game").Exists());
    }

    [Test]
    public void When_a_game_has_started__other_visitors_should_not_be_able_to_find_the_game()
    {
      browser.Visit("/NewGame");

      browser.FillIn("Name").With("Tron");
      browser.Choose("Dog");
      browser.FindFieldset("Opponent 1").Choose("Rube");
      browser.FindFieldset("Opponent 2").Choose("Chester");
      browser.FindFieldset("Opponent 3").Choose("Adolf");

      browser.ClickButton("Submit");

      browser.Visit("/Logout");


      browser.Visit("/");

      Assert.IsFalse(browser.FindLink("Resume Game").Exists());
    }
  }
}