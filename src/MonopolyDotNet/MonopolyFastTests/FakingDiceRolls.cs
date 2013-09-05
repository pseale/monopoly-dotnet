using System.Collections.Generic;
using MonopolyWeb.Models.Core;
using NUnit.Framework;

namespace MonopolyFastTests
{
  [TestFixture]
  public class FakingDiceRolls
  {
    [Test]
    public void When_attempting_to_fake_dice_rolls_with_a_single_fake_dice_roll__should_repeat_that_dice_roll_endlessly()
    {
      Dice.ReplaceRandomRollsWith(new List<int>(new[] { 12 }));

      for (int i=0; i<100; i++)
        Assert.AreEqual(12, Dice.Roll());

    }
  }
}