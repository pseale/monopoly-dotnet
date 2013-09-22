using MonopolyWeb.Models.Commands;
using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.Services;
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
        BuyPropertyCommand.Execute(game);
        RollDiceCommand.Execute(game);
        RollDiceCommand.Execute(game);
        RollDiceCommand.Execute(game);
        RollDiceCommand.Execute(game);

        var gameStatus = GameStatusService.GetCurrentGameStatus(game);

        Assert.IsFalse(gameStatus.CanBuyProperty);
      });
    }
  }
}