using System.Linq;
using MonopolyWeb.Models;
using MonopolyWeb.Models.Core;
using NUnit.Framework;

namespace MonopolyFastTests
{
  [TestFixture]
  public class StartingANewGame
  {
    [Test]
    public void When_starting_a_new_game__should_set_the_starting_location_to_GO()
    {
      var game = new Game();
      var tokens = game.GetTotemLocations();
      var playerToken = tokens[0];

      Assert.AreEqual(720-80, playerToken.OffsetFromLeft);
      Assert.AreEqual(720-80, playerToken.OffsetFromTop);
    }
  
    [Test]
    public void When_rolling_a_1_from_GO__should_change_the_players_location_to_Mediterranean()
    {
      var game = new Game();
      game.Roll();

      var tokens = game.GetTotemLocations();
      var playerToken = tokens[0];

      Assert.AreEqual(720-80-40-47, playerToken.OffsetFromLeft);
      Assert.AreEqual(720-80, playerToken.OffsetFromTop);
    }
  }
}