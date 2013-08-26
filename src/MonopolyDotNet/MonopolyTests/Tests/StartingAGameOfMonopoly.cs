using NUnit.Framework;

namespace MonopolyTests.Tests
{
  [TestFixture]
  public class StartingAGameOfMonopoly : WebTestBase
  {
    [Test]
    public void When_anyone_visits_the_home_page__should_be_able_to_start_a_new_game()
    {
      browser.Visit("/");

      var link = browser.FindLink("Start a new game");

      Assert.IsTrue(link.Exists());
    }
  }
}