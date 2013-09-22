using System;
using System.Net;
using System.Text.RegularExpressions;
using NUnit.Framework;
using RestSharp;

namespace MonopolyTests.Tests.NewGameFormDataTests
{
  [TestFixture]
  public class SubmittingTheStartNewGameForm : WebTestBase
  {
    private RestClient _client;
    private RestRequest _request;

    [SetUp]
    public void SetUp()
    {
      _client = new RestClient(baseUrl);
      
      var requestToGetTheAntiForgeryToken = new RestRequest("NewGame");
      requestToGetTheAntiForgeryToken.Method = Method.GET;
      var result = _client.Execute(requestToGetTheAntiForgeryToken);
      var antiForgeryCookie = result.Cookies[0];
      var match = Regex.Match(result.Content,
        "<input name=\"__RequestVerificationToken\" type=\"hidden\" value=\"(?<token>.*?)\" />"); //this feels brittle, but it works today, 2013-09-21
      var token = match.Groups["token"].Value;

      _request = new RestRequest("NewGame");
      _request.Method = Method.POST;
      _request.AddCookie(antiForgeryCookie.Name, antiForgeryCookie.Value);
      _request.AddParameter("__RequestVerificationToken", token);
    }

    [Test]
    public void When_posting_no_data_to_the_Start_New_Game_service__should_redirect_us_back_to_the_form()
    {
      var response = _client.Execute(_request);

      AssertResponseRedirectsBackToForm(response);
    }

    [Test]
    public void When_posting_everything_minus_our_name_to_the_Start_New_Game_service__should_redirect_us_back_to_the_form()
    {
      _request.AddParameter("Totem", "Dog");
      _request.AddParameter("Opponent1", "Rube");
      _request.AddParameter("Opponent2", "Chester");
      _request.AddParameter("Opponent3", "Rube");
      
      var response = _client.Execute(_request);

      AssertResponseRedirectsBackToForm(response);
    }

    [Test]
    public void When_posting_everything_minus_our_totem_to_the_Start_New_Game_service__should_redirect_us_back_to_the_form()
    {
      _request.AddParameter("Name", "Tron");
      _request.AddParameter("Opponent1", "Rube");
      _request.AddParameter("Opponent2", "Chester");
      _request.AddParameter("Opponent3", "Rube");

      var response = _client.Execute(_request);

      AssertResponseRedirectsBackToForm(response);
    }

    [Test]
    public void When_posting_everything_minus_player_2_to_the_Start_New_Game_service__should_redirect_us_back_to_the_form()
    {
      _request.AddParameter("Name", "Tron");
      _request.AddParameter("Totem", "Dog");
      _request.AddParameter("Opponent2", "Chester");
      _request.AddParameter("Opponent3", "Rube");

      var response = _client.Execute(_request);

      AssertResponseRedirectsBackToForm(response);
    }

    [Test]
    public void When_posting_everything_minus_player_3_to_the_Start_New_Game_service__should_redirect_us_back_to_the_form()
    {
      _request.AddParameter("Name", "Tron");
      _request.AddParameter("Totem", "Dog");
      _request.AddParameter("Opponent1", "Rube");
      _request.AddParameter("Opponent3", "Rube");
      
      var response = _client.Execute(_request);

      AssertResponseRedirectsBackToForm(response);
    }

    [Test]
    public void When_posting_everything_minus_player_4_to_the_Start_New_Game_service__should_redirect_us_back_to_the_form()
    {
      _request.AddParameter("Name", "Tron");
      _request.AddParameter("Totem", "Dog");
      _request.AddParameter("Opponent1", "Rube");
      _request.AddParameter("Opponent2", "Rube");

      var response = _client.Execute(_request);

      AssertResponseRedirectsBackToForm(response);
    }

    [Test]
    public void When_posting_an_empty_Name_to_the_Start_New_Game_service__should_redirect_us_back_to_the_form()
    {
      _request.AddParameter("Name", "");
      _request.AddParameter("Totem", "Dog");
      _request.AddParameter("Opponent1", "Rube");
      _request.AddParameter("Opponent2", "Rube");
      _request.AddParameter("Opponent3", "Rube");

      var response = _client.Execute(_request);

      AssertResponseRedirectsBackToForm(response);
    }

    [Test]
    public void When_posting_a_Name_that_is_too_large_to_the_Start_New_Game_service__should_redirect_us_back_to_the_form()
    {
      string nameThatIs21CharsLong = "12345678901234567890*";
      _request.AddParameter("Name", nameThatIs21CharsLong);
      _request.AddParameter("Totem", "Dog");
      _request.AddParameter("Opponent1", "Rube");
      _request.AddParameter("Opponent2", "Rube");
      _request.AddParameter("Opponent3", "Rube");

      var response = _client.Execute(_request);

      AssertResponseRedirectsBackToForm(response);
    }

    private void AssertResponseRedirectsBackToForm(IRestResponse response)
    {
      Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
      Assert.AreEqual(new Uri(baseUrl + "/NewGame"), response.ResponseUri);
    }
  }
}