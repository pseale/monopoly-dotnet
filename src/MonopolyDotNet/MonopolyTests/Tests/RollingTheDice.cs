using System.Drawing;
using Coypu;
using MonopolyTests.Builders;
using MonopolyTests.Infrastructure;
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
      var boardLocation = GetBoardCoordinates();
      var originalLocation = GetTotemCoordinates(browser.FindCss("img#player-1"));

      browser.ClickButton("Roll");

      var newLocation = GetTotemCoordinates(browser.FindCss("img#player-1"));
      //I want to see test failures in terms of offset from the board coordinates, not offset from the entire page
      Assert.AreNotEqual(originalLocation.X - boardLocation.X, newLocation.X - boardLocation.X);
    }

    [Test]
    public void When_rolling_the_dice_and_ending_the_turn__should_do_opponent1s_turn_also()
    {
      TestHelper.StartAGame();
      TestHelper.WithHumanRoll(5, () =>
      {
        var boardLocation = GetBoardCoordinates();
        var originalLocation = GetTotemCoordinates(browser.FindCss("img#player-2"));
        browser.ClickButton("Roll");

        var newLocation = GetTotemCoordinates(browser.FindCss("img#player-2"));

        Assert.AreNotEqual(originalLocation.X - boardLocation.X, newLocation.X - boardLocation.X);
      });
    }

    [Test]
    public void When_rolling_the_dice_and_ending_the_turn__should_do_opponent2s_turn_also()
    {
      TestHelper.StartAGame();
      TestHelper.WithHumanRoll(5, () =>
      {
        var boardLocation = GetBoardCoordinates();
        var originalLocation = GetTotemCoordinates(browser.FindCss("img#player-3"));
        browser.ClickButton("Roll");

        var newLocation = GetTotemCoordinates(browser.FindCss("img#player-3"));

        Assert.AreNotEqual(originalLocation.X - boardLocation.X, newLocation.X - boardLocation.X);
      });
    }

    [Test]
    public void When_rolling_the_dice_and_ending_the_turn__should_do_opponent3s_turn_also()
    {
      TestHelper.StartAGame();
      TestHelper.WithHumanRoll(5, () =>
      {
        var boardLocation = GetBoardCoordinates();
        var originalLocation = GetTotemCoordinates(browser.FindCss("img#player-4"));
        browser.ClickButton("Roll");

        var newLocation = GetTotemCoordinates(browser.FindCss("img#player-4"));

        Assert.AreNotEqual(originalLocation.X - boardLocation.X, newLocation.X - boardLocation.X);
      });
    }

    private static Point GetBoardCoordinates()
    {
      var native = browser.FindCss(".monopoly-board").Native;
      if (native is OpenQA.Selenium.Remote.RemoteWebElement)
        return ((OpenQA.Selenium.Remote.RemoteWebElement)native).Coordinates.LocationInDom;
      throw new MonopolyTestRunException("Test infrastructure problem: can't figure out what browser we're using to get the native coordinates. Find this method and add browser-specific code to fix this problem.");
    }

    private static Point GetTotemCoordinates(ElementScope imgTag)
    {
      var native = imgTag.Native;
      if (native is OpenQA.Selenium.Remote.RemoteWebElement)
        return ((OpenQA.Selenium.Remote.RemoteWebElement)native).Coordinates.LocationInDom;
      throw new MonopolyTestRunException("Test infrastructure problem: can't figure out what browser we're using to get the native coordinates. Find this method and add browser-specific code to fix this problem.");
    }
  }
}