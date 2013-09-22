using NUnit.Framework;

namespace MonopolyTests.Tests
{
  public class VisitingTheHomePage : WebTestBase
  {
    [Test]
    public void When_visiting_the_home_page__should_be_able_to_visit_the_About_page()
    {
      browser.Visit("/");

      var link = browser.FindLink("About");

      Assert.IsTrue(link.Exists());
    }

    [Test]
    public void When_anyone_visits_the_home_page__should_be_able_to_start_a_new_game()
    {
      browser.Visit("/");

      //find the start new game form
      var nameField = browser.FindField("Name");
      var totemField = browser.FindField("Totem");
      Assert.IsTrue(nameField.Exists());
      Assert.IsTrue(totemField.Exists());
    }

    [Test]
    public void When_visiting_the_home_page__should_not_see_a_Quit_Game_link()
    {
      var link = browser.FindLink("Quit Game");

      Assert.IsFalse(link.Exists());
    }
  }
}