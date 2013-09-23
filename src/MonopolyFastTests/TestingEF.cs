using System.Linq;
using MonopolyWeb.Models.Commands;
using MonopolyWeb.Models.Queries;
using NUnit.Framework;

namespace MonopolyFastTests
{
  [TestFixture]
  public class TestingEF
  {
    [Test]
    public void test1()
    {
      var game = FastTestHelper.StartGame();

      var gameFromQuery = FindGameByUsernameQuery.Execute(game.Username);

      Assert.AreEqual(4, gameFromQuery.Players.Count);
      Assert.AreEqual(0, gameFromQuery.Players.First(x=>x.IsHuman).Location.Index);
      Assert.AreEqual(false, gameFromQuery.Players.First(x => x.IsHuman).Location.HasAProperty);
    }

    [Test]
    public void test2()
    {
      FastTestHelper.WithHumanDiceRoll(6, () =>
      {
        var game = FastTestHelper.StartGame();
        RollDiceCommand.Execute(game);

        var gameFromQuery = FindGameByUsernameQuery.Execute(game.Username);
        var player = game.Players.First(x => x.IsHuman);

        Assert.AreEqual(4, gameFromQuery.Players.Count);
        Assert.AreEqual(0, player.Holdings.Count);
        Assert.AreEqual(6, player.Location.Index);
        Assert.AreEqual(true, player.Location.HasAProperty);
        Assert.AreEqual("Oriental", player.Location.Property.PropertyName);
      });
    }

    [Test]
    public void test3()
    {
      FastTestHelper.WithHumanDiceRoll(6, () =>
      {
        var game = FastTestHelper.StartGame();
        RollDiceCommand.Execute(game);
        BuyPropertyCommand.Execute(game);

        var gameFromQuery = FindGameByUsernameQuery.Execute(game.Username);
        var player = game.Players.First(x => x.IsHuman);

        Assert.AreEqual(4, gameFromQuery.Players.Count);
        Assert.AreEqual(1, player.Holdings.Count);
        Assert.AreEqual("Oriental", player.Holdings.First().PropertyName);
        Assert.AreEqual(6, player.Location.Index);
        Assert.AreEqual(true, player.Location.HasAProperty);
        Assert.AreEqual("Oriental", player.Location.Property.PropertyName);
      });
    }
  }
}