using System.Drawing;
using Coypu;
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
      var originalLocation = GetCoordinatesOfTotemOnBoard(browser.FindCss("img#player-1"));

      browser.ClickButton("Roll");

      var newLocation = GetCoordinatesOfTotemOnBoard(browser.FindCss("img#player-1"));
      //I want to see test failures in terms of offset from the board coordinates, not offset from the entire page
      Assert.AreNotEqual(originalLocation.X - boardLocation.X, newLocation.X - boardLocation.X);
    }

    private static Point GetCoordinatesOfTotemOnBoard(ElementScope imgTag)
    {
      return ((OpenQA.Selenium.Firefox.FirefoxWebElement) imgTag.Native).Coordinates.LocationInDom;
    }

    [Test]
    public void When_rolling_the_dice_and_ending_the_turn__should_do_opponent1s_turn_also()
    {
      TestHelper.StartAGame();
      TestHelper.WithHumanRoll(5, () =>
      {
        var boardLocation =
          ((OpenQA.Selenium.Firefox.FirefoxWebElement)browser
          .FindCss(".monopoly-board").Native).Coordinates.LocationInDom;
        var originalLocation = GetCoordinatesOfTotemOnBoard(browser.FindCss("img#player-2"));
        browser.ClickButton("Roll");

        var newLocation = GetCoordinatesOfTotemOnBoard(browser.FindCss("img#player-2"));

        Assert.AreNotEqual(originalLocation.X - boardLocation.X, newLocation.X - boardLocation.X);
      });
    }

    [Test]
    public void When_rolling_the_dice_and_ending_the_turn__should_do_opponent2s_turn_also()
    {
      TestHelper.StartAGame();
      TestHelper.WithHumanRoll(5, () =>
      {
        var boardLocation =
          ((OpenQA.Selenium.Firefox.FirefoxWebElement)browser
          .FindCss(".monopoly-board").Native).Coordinates.LocationInDom;
        var originalLocation = GetCoordinatesOfTotemOnBoard(browser.FindCss("img#player-3"));
        browser.ClickButton("Roll");

        var newLocation = GetCoordinatesOfTotemOnBoard(browser.FindCss("img#player-3"));

        Assert.AreNotEqual(originalLocation.X - boardLocation.X, newLocation.X - boardLocation.X);
      });
    }

    [Test]
    public void When_rolling_the_dice_and_ending_the_turn__should_do_opponent3s_turn_also()
    {
      TestHelper.StartAGame();
      TestHelper.WithHumanRoll(5, () =>
      {
        var boardLocation =
          ((OpenQA.Selenium.Firefox.FirefoxWebElement)browser
          .FindCss(".monopoly-board").Native).Coordinates.LocationInDom;
        var originalLocation = GetCoordinatesOfTotemOnBoard(browser.FindCss("img#player-4"));
        browser.ClickButton("Roll");

        var newLocation = GetCoordinatesOfTotemOnBoard(browser.FindCss("img#player-4"));

        Assert.AreNotEqual(originalLocation.X - boardLocation.X, newLocation.X - boardLocation.X);
      });
    }
  }
}