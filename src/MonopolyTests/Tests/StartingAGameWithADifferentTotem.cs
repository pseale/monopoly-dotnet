using System.Linq;
using MonopolyTests.Builders;
using NUnit.Framework;

namespace MonopolyTests.Tests
{
  [TestFixture]
  public class StartingAGameWithADifferentTotem : WebTestBase
  {
    [Test]
    public void When_starting_a_game_with_a_different_totem__should_have_that_totem()
    {
      TestHelper.StartAGame("Horseman");

      var player1Filename = TestHelper.GetSrcFilenameFrom(browser.FindCss("img#player-1"));
      Assert.AreEqual("horseman.png", player1Filename);
    }

    //this is where I wish I had MSpec's "behaves like" functionality - same asserts on different contexts.
    [Test]
    public void When_starting_a_game_with_a_different_totem__everyones_totems_should_be_unique()
    {
      TestHelper.StartAGame("Horseman");

      var player1Filename = TestHelper.GetSrcFilenameFrom(browser.FindCss("img#player-1"));
      var player2Filename = TestHelper.GetSrcFilenameFrom(browser.FindCss("img#player-2"));
      var player3Filename = TestHelper.GetSrcFilenameFrom(browser.FindCss("img#player-3"));
      var player4Filename = TestHelper.GetSrcFilenameFrom(browser.FindCss("img#player-4"));
      var filenames = new[] { player1Filename, player2Filename, player3Filename, player4Filename };
      var numberOfUniqueFilenames = filenames.GroupBy(x => x).Count();

      Assert.AreEqual(4, numberOfUniqueFilenames, "Expected unique filenames, got: " + string.Join(", ", filenames));
    }
  }
}