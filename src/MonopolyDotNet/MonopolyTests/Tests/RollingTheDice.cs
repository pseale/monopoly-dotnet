using MonopolyTests.Builders;
using NUnit.Framework;

namespace MonopolyTests.Tests
{
  [TestFixture]
  public class RollingTheDice : WebTestBase
  {
    [Test]
    public void When_rolling_the_dice__should_move_my_token()
    {
      TestHelper.StartAGame();

      var boardLocation =
        ((OpenQA.Selenium.Firefox.FirefoxWebElement) browser
        .FindCss(".monopoly-board").Native).Coordinates.LocationInDom;

      var dogTotem = browser.FindCss("img#player-1");
      var originalLocation = ((OpenQA.Selenium.Firefox.FirefoxWebElement) dogTotem.Native).Coordinates.LocationInDom;
      
      browser.ClickButton("Roll");
      var newLocation = ((OpenQA.Selenium.Firefox.FirefoxWebElement) dogTotem.Native).Coordinates.LocationInDom;

      //I want to see test failures in terms of offset from the board coordinates, not offset from the entire page
      Assert.AreNotEqual(originalLocation.X - boardLocation.X, newLocation.X - boardLocation.X);
    }
  }
}