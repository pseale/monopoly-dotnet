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

    [Test]
    public void When_starting_a_new_game__should_be_able_to_fill_in_every_field_on_the_form()
    {
      browser.Visit("/NewGame");
      
      browser.FillIn("Name").With("Tron");
      browser.Choose("Dog");
      browser.FindFieldset("Opponent 1").Choose("Rube");
      browser.FindFieldset("Opponent 2").Choose("Chester");
      browser.FindFieldset("Opponent 3").Choose("Adolf");

      //Assert there is no error up to this point
    }
  }
}