using System;
using MonopolyTests.Builders;
using NUnit.Framework;

namespace MonopolyTests.Tests
{
  [TestFixture]
  public class QuittingAGame : WebTestBase
  {
    [Test]
    public void When_quitting_a_game__should_eventually_redirect_me_to_the_home_page()
    {
      TestHelper.StartAGame();

      browser.ClickLink("Quit Game");

      Assert.AreEqual(new Uri(baseUrl), browser.Location);
    }

    [Test]
    public void When_quitting_a_game__should_be_able_to_start_a_new_game()
    {
      TestHelper.StartAGame();

      browser.ClickLink("Quit Game");

      //find the start new game form
      var nameField = browser.FindField("Name");
      var totemField = browser.FindField("Totem");
      Assert.IsTrue(nameField.Exists());
      Assert.IsTrue(totemField.Exists());
    }
  }
}