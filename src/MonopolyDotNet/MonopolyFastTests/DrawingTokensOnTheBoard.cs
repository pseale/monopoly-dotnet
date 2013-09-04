using MonopolyWeb.Models.Services;
using NUnit.Framework;

namespace MonopolyFastTests
{
  [TestFixture]
  public class DrawingTokensOnTheBoard
  {
    [Test]
    public void When_finding_the_midpoint_of_GO__should_generate_coordinates_that_fit_perfectly_in_the_middle_of_GO()
    {
      var coordinates = TokenCoordinatesHelper.GetMidpointOf(0);

      Assert.AreEqual(638, coordinates.OffsetFromLeft); //just harvested the expected value from the array
      Assert.AreEqual(633, coordinates.OffsetFromTop);
    }

    [Test]
    public void When_finding_the_midpoint_of_Mediterrannean__should_generate_coordinates_that_fit_perfectly_in_the_middle_of_it()
    {
      var coordinates = TokenCoordinatesHelper.GetMidpointOf(1);

      Assert.AreEqual(550, coordinates.OffsetFromLeft);
      Assert.AreEqual(633, coordinates.OffsetFromTop);
    }

    [Test]
    public void When_finding_the_midpoint_of_Boardwalk__should_generate_coordinates_that_fit_perfectly_in_the_middle_of_it()
    {
      var coordinates = TokenCoordinatesHelper.GetMidpointOf(39);

      Assert.AreEqual(640, coordinates.OffsetFromLeft);
      Assert.AreEqual(544, coordinates.OffsetFromTop);
    }
  }
}