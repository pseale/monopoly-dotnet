using MonopolyWeb.Models.Commands;
using MonopolyWeb.Models.Core;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace MonopolyFastTests
{
  [TestFixture]
  public class LandingOnAPropertyIDontOwn
  {
    [Test]
    public void When_landing_on_a_property_I_dont_own__should_be_able_to_buy_it()
    {
      FastTestHelper.WithHumanDiceRoll(6, () =>
      {
        var game = FastTestHelper.StartGame();
        RollDiceCommand.Execute(game);

        var gameStatus = game.GetCurrentGameStatus();

        Assert.IsTrue(gameStatus.CanBuyProperty);
      });
    }

    [Test]
    public void When_landing_on_a_property_I_dont_own__should_show_the_correct_sale_price()
    {
      FastTestHelper.WithHumanDiceRoll(6, () =>
      {
        var game = FastTestHelper.StartGame();
        RollDiceCommand.Execute(game);

        var gameStatus = game.GetCurrentGameStatus();

        Assert.AreEqual(80, gameStatus.PropertySalePrice);
      });
    }
  }
}