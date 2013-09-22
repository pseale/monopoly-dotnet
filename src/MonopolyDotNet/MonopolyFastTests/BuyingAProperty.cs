﻿using MonopolyWeb.Models.Commands;
using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.Services;
using NUnit.Framework;

namespace MonopolyFastTests
{
  [TestFixture]
  public class BuyingAProperty
  {
    [Test]
    public void When_buying_a_property__should_charge_me_money()
    {
      FastTestHelper.WithHumanDiceRoll(6, () =>
      {
        var game = FastTestHelper.StartGame();
        RollDiceCommand.Execute(game);
        BuyPropertyCommand.Execute(game);

        var gameStatus = GameStatusService.GetCurrentGameStatus(game);

        Assert.AreEqual(1500-80, gameStatus.Players[0].Cash);
      });
    }

    [Test]
    public void When_buying_a_property__should_add_the_property_to_my_holdings()
    {
      FastTestHelper.WithHumanDiceRoll(6, () =>
      {
        var game = FastTestHelper.StartGame();
        RollDiceCommand.Execute(game);
        BuyPropertyCommand.Execute(game);

        var gameStatus = GameStatusService.GetCurrentGameStatus(game);

        Assert.AreEqual(1, gameStatus.Players[0].Holdings.Count);
        Assert.AreEqual("Oriental", gameStatus.Players[0].Holdings[0].Name);
      });
    }
  }
}