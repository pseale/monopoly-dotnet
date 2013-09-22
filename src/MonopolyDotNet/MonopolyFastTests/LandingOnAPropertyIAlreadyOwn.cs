using MonopolyWeb.Models.Commands;
using MonopolyWeb.Models.Core;
using NUnit.Framework;

namespace MonopolyFastTests
{
  [TestFixture]
  public class LandingOnAPropertyIAlreadyOwn
  {
    [Test]
    public void When_landing_on_a_property_I_own__should_not_be_able_to_buy_it()
    {
      //Roll to Oriental, then do safe rolls until you make your way back to Oriental
      FastTestHelper.WithHumanDiceRolls(new[] { 6, 4, 10, 10, 10, 6 }, () =>
      {
        var game = FastTestHelper.StartGame();
        RollDiceCommand.Execute(game);
        game.BuyProperty();
        RollDiceCommand.Execute(game);
        RollDiceCommand.Execute(game);
        RollDiceCommand.Execute(game);
        RollDiceCommand.Execute(game);

        var gameStatus = game.GetCurrentGameStatus();

        Assert.IsFalse(gameStatus.CanBuyProperty);
      });
    }
  }
}