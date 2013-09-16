using System;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;
using Coypu;
using Coypu.Drivers;
using MonopolyTests.Infrastructure;
using MonopolyWeb.Models.Core;
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
      StartAGame("Dog");
    }

    public static void StartAGame(string totem)
    {
      browser.Visit("/NewGame");

      browser.FillIn("Name").With("Tron");
      browser.Choose(totem);
      browser.FindFieldset("Opponent 1").Choose("Rube");
      browser.FindFieldset("Opponent 2").Choose("Chester");
      browser.FindFieldset("Opponent 3").Choose("Adolf");

      browser.ClickButton("Submit");

      if (browser.Location.PathAndQuery != "/Game")
        throw new MonopolyTestRunException("While setting up a test, attempted to start a game, but did not succeed. At URL: " + browser.Location);
    }

    public static void ReplaceRandomRollsWith(params int[] rolls)
    {
      ExecutePost("SecretAdmin/ReplaceRolls", x =>
      {
        x.AddParameter("Rolls", string.Join(",", rolls));
      });
    }

    public static void ResetRolls()
    {
      ExecutePost("SecretAdmin/ResetRollsToDefault", x => { });
    }

    private static void ExecutePost(string relativePath, Action<RestRequest> requestSetupAction)
    {
      var client = new RestClient(baseUrl);
      var request = new RestRequest(relativePath);
      var cookie = browser.Driver.GetBrowserCookies().First();
      request.AddCookie(cookie.Name, cookie.Value);
      request.Method = Method.POST;

      requestSetupAction(request);

      var response = client.Execute(request);
      if (response.StatusCode != HttpStatusCode.OK)
        throw new MonopolyTestRunException("Error while attempting to POST to " + relativePath +" during test setup/teardown. Response from server: " + response.Content);
    }

    public static bool PlayerHasMoney(this BrowserSession browserSession, int cash)
    {
      return browserSession.FindCss(".player-card#player-1 .cash").HasContent("$" + cash);
    }

    public static void WithHardcodedDiceRoll(int roll, Action action)
    {
      WithHardcodedDiceRolls(new int[] { roll }, action);
    }

    public static void WithHardcodedDiceRolls(int[] rolls, Action action)
    {
      try
      {
        ReplaceRandomRollsWith(rolls);
        action();
      }
      finally
      {
        ResetRolls();
      }
    }

    public static string GetSrcFilenameFrom(ElementScope playerTotemImgTag)
    {
      return playerTotemImgTag["src"].Split('/').Last();
    }
  }
}