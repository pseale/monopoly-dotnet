using Coypu.Drivers;
using MonopolyTests.Infrastructure;
using NUnit.Framework;

namespace MonopolyTests
{
  [TestFixture]
  public class StartingAGameOfMonopoly : WebTestBase
  {
    [Test]
    public void When_anyone_visits_the_home_page__should_be_able_to_start_a_new_game()
    {
      Session().Visit("/");

      var link = Session().FindLink("Start New Game");

      Assert.IsTrue(link.Exists());
    }
  }
}