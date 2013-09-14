using System.Linq;
using MonopolyTests.Builders;
using NUnit.Framework;

namespace MonopolyTests.Tests
{
  [TestFixture]
  public class StartingAGame : WebTestBase
  {
    //this is where I start wishing I was using MSpec
    [SetUp]
    public void TestFixtureSetUp()
    {
      TestHelper.StartAGame();
    }

    [Test]
    public void When_starting_a_game__player_should_start_with_1500_cash_money()
    {
      Assert.IsTrue(browser.PlayerHasMoney(1500));
    }

    [Test]
    public void When_starting_a_game__opponent_1_should_start_with_1500_cash_money()
    {
      Assert.IsTrue(browser.FindCss(".player-card#player-2 .cash").HasContent("$1500"));
    }

    [Test]
    public void When_starting_a_game__opponent_2_should_start_with_1500_cash_money()
    {
      Assert.IsTrue(browser.FindCss(".player-card#player-3 .cash").HasContent("$1500"));
    }

    [Test]
    public void When_starting_a_game__opponent_3_should_start_with_1500_cash_money()
    {
      Assert.IsTrue(browser.FindCss(".player-card#player-4 .cash").HasContent("$1500"));
    }

    [Test]
    public void When_starting_a_game__player_should_start_with_an_icon_indicating_theyre_human()
    {
      var imageTag = browser.FindCss("#player-1 img.player-icon");
      string imageName = imageTag["src"].Split('/').Last();
      Assert.AreEqual("human_player.png", imageName);
    }

    [Test]
    public void When_starting_a_game__opponent_1_should_start_with_an_icon_indicating_theyre_human()
    {
      var imageTag = browser.FindCss("#player-2 img.player-icon");
      string imageName = imageTag["src"].Split('/').Last();
      Assert.AreEqual("robot_scum.png", imageName);
    }

    [Test]
    public void When_starting_a_game__opponent_2_should_start_with_an_icon_indicating_theyre_human()
    {
      var imageTag = browser.FindCss("#player-3 img.player-icon");
      string imageName = imageTag["src"].Split('/').Last();
      Assert.AreEqual("robot_scum.png", imageName);
    }

    [Test]
    public void When_starting_a_game__opponent_3_should_start_with_an_icon_indicating_theyre_human()
    {
      var imageTag = browser.FindCss("#player-4 img.player-icon");
      string imageName = imageTag["src"].Split('/').Last();
      Assert.AreEqual("robot_scum.png", imageName);
    }

    [Test]
    public void When_starting_a_game__players_name_should_be_shown()
    {
      var playerNameH4 = browser.FindCss("#player-1 h4");
      Assert.IsTrue(playerNameH4.HasContent("Tron"));
    }

    [Test]
    public void When_starting_a_game__opponent_1s_name_should_be_shown()
    {
      var playerNameH4 = browser.FindCss("#player-2 h4");
      Assert.IsTrue(playerNameH4.HasContent("Rube"));
    }

    [Test]
    public void When_starting_a_game__opponent_2s_name_should_be_shown()
    {
      var playerNameH4 = browser.FindCss("#player-3 h4");
      Assert.IsTrue(playerNameH4.HasContent("Chester"));
    }

    [Test]
    public void When_starting_a_game__opponent_3s_name_should_be_shown()
    {
      var playerNameH4 = browser.FindCss("#player-4 h4");
      Assert.IsTrue(playerNameH4.HasContent("Adolf"));
    }
  }
}