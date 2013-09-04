using System;
using Coypu;
using Coypu.Drivers;
using MonopolyTests.Infrastructure;
using RestSharp;

namespace MonopolyTests.Builders
{
  //just make static helper methods "for now"
  public static class TestHelper
  {
    // ReSharper disable once InconsistentNaming
    private static BrowserSession browser { get { return SeleniumHelper.BrowserSession; } }
    // ReSharper disable once InconsistentNaming
    private static string baseUrl { get { return IisExpressInstance.BaseUrl; } }

    public static void StartAGame()
    {
      browser.Visit("/NewGame");

      browser.FillIn("Name").With("Tron");
      browser.Choose("Dog");
      browser.FindFieldset("Opponent 1").Choose("Rube");
      browser.FindFieldset("Opponent 2").Choose("Chester");
      browser.FindFieldset("Opponent 3").Choose("Adolf");

      browser.ClickButton("Submit");

      if (browser.Location != new Uri(baseUrl + "/Game"))
        throw new MonopolyTestRunException("While setting up a test, attempted to start a game, but did not succeed.");
    }
  }
}