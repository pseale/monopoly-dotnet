using System;
using NUnit.Framework;

namespace MonopolyTests.Tests
{
  [TestFixture]
  public class QuittingAGameEvenWhenImNotInAGame : WebTestBase
  {
    [Test]
    public void When_somehow_visiting_the_Game_Quit_page_even_though_Im_not_in_a_game__should_gracefully_redirect_to_homepage()
    {
      //we have just logged out/quit, no game is ongoing
      browser.Visit("/QuitGame");

      Assert.AreEqual(new Uri(baseUrl), browser.Location);
    }
  }
}