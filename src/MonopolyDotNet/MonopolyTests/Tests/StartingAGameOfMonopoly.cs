using System;
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

    [Test]
    public void When_submitting_the_form_for_a_new_game_with_missing_info__should_redirect_back_to_the_form_with_your_data_preserved()
    {
      browser.Visit("/NewGame");

      browser.FillIn("Name").With("Tron");
      browser.Choose("Dog");
      browser.FindFieldset("Opponent 1").Choose("Rube");
      browser.FindFieldset("Opponent 2").Choose("Chester");
      //everything filled in except 3rd opponent Adolf //browser.FindFieldset("Opponent 3").Choose("Adolf");

      browser.ClickButton("Submit");

      Assert.AreEqual(new Uri(baseUrl+"/NewGame"), browser.Location);
      Assert.AreEqual("Tron", browser.FindField("Name").Value);
      Assert.AreEqual("Dog", browser.FindField("Totem").Value);
      Assert.AreEqual("Rube", browser.FindField("Player2").Value);
      Assert.AreEqual("Chester", browser.FindField("Player3").Value);
    }

    [Test]
    public void When_submitting_the_form_for_a_new_game_with_different_missing_info__should_redirect_back_to_the_form_with_your_data_preserved()
    {
      browser.Visit("/NewGame");

      //nothing filled in, EXCEPT 3rd opponent Adolf
      browser.FindFieldset("Opponent 3").Choose("Adolf");

      browser.ClickButton("Submit");

      Assert.AreEqual(new Uri(baseUrl + "/NewGame"), browser.Location);
      Assert.AreEqual("Adolf", browser.FindField("Player4").Value);
    }
  }
}