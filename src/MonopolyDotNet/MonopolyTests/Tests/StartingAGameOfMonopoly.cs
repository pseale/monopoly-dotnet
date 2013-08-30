using System;
using Coypu;
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
      browser.FindFieldset("Opponent 1").Choose("P2Rube");
      browser.FindFieldset("Opponent 2").Choose("P3Chester");
      browser.FindFieldset("Opponent 3").Choose("P4Adolf");

      //Assert there is no error up to this point
    }

    [Test]
    public void When_submitting_the_form_for_a_new_game_with_missing_info__should_redirect_back_to_the_form_with_your_data_preserved()
    {
      browser.Visit("/NewGame");

      browser.FillIn("Name").With("Tron");
      browser.Choose("Dog");
      browser.FindFieldset("Opponent 1").Choose("P2Rube");
      browser.FindFieldset("Opponent 2").Choose("P3Chester");
      //everything filled in except 3rd opponent Adolf //browser.FindFieldset("Opponent 3").Choose("P4Adolf");

      browser.ClickButton("Submit");

      Assert.AreEqual(new Uri(baseUrl+"/NewGame"), browser.Location);
      Assert.AreEqual("Tron", browser.FindField("Name").Value);
      Assert.AreEqual("Dog", browser.FindField("Totem").Value);
      Assert.AreEqual("true", browser.FindField("P2Rube")["Checked"]); //"But Peter, why are you doing such horrible things with Checked attributes and mangling radio button names, when the API seems so much friendlier?" YOU CANT HANDLE THE TRUTH
      Assert.AreEqual("true", browser.FindField("P3Chester")["Checked"]);
    }

    [Test]
    public void When_submitting_the_form_for_a_new_game_with_different_missing_info__should_redirect_back_to_the_form_with_your_data_preserved()
    {
      browser.Visit("/NewGame");

      //nothing filled in, EXCEPT 3rd opponent Adolf
      browser.FindFieldset("Opponent 3").Choose("P4Adolf");

      browser.ClickButton("Submit");

      Assert.AreEqual(new Uri(baseUrl + "/NewGame"), browser.Location);
      Assert.AreEqual("true", browser.FindField("P4Adolf")["Checked"]);
    }

    [Test]
    public void When_submitting_the_form_for_a_new_game_with_all_necessary_info__should_start_a_game()
    {
      browser.Visit("/NewGame");

      browser.FillIn("Name").With("Tron");
      browser.Choose("Dog");
      browser.FindFieldset("Opponent 1").Choose("P2Rube");
      browser.FindFieldset("Opponent 2").Choose("P3Chester");
      browser.FindFieldset("Opponent 3").Choose("P4Adolf");

      browser.ClickButton("Submit");

      Assert.AreEqual(new Uri(baseUrl + "/Game"), browser.Location);
    }

  }
}