using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.ViewModels;
using NUnit.Framework;

namespace MonopolyFastTests
{
  [TestFixture]
  public class EnumeratingMonopolyProperties
  {
    [Test]
    public void Should_be_40_locations_in_the_Location_lookup()
    {
      Assert.AreEqual(40, Locations.All.Length);
    }

    [Test]
    public void Should_have_correct_information_in_every_single_location()
    {
      Assert.IsFalse(Locations.All[0].HasAProperty);

      Assert.IsTrue(Locations.All[1].HasAProperty);
      Assert.AreEqual("Mediterranean", Locations.All[1].Property.PropertyName);
      Assert.AreEqual(60, Locations.All[1].Property.SalePrice);

      Assert.IsFalse(Locations.All[2].HasAProperty);

      Assert.IsTrue(Locations.All[3].HasAProperty);
      Assert.AreEqual("Baltic", Locations.All[3].Property.PropertyName);
      Assert.AreEqual(60, Locations.All[3].Property.SalePrice);

      Assert.IsFalse(Locations.All[4].HasAProperty);
      //no railroads for now, if ever
      Assert.IsFalse(Locations.All[5].HasAProperty);

      Assert.IsTrue(Locations.All[6].HasAProperty);
      Assert.AreEqual("Oriental", Locations.All[6].Property.PropertyName);
      Assert.AreEqual(80, Locations.All[6].Property.SalePrice);

      Assert.IsFalse(Locations.All[7].HasAProperty);

      Assert.IsTrue(Locations.All[8].HasAProperty);
      Assert.AreEqual("Vermont", Locations.All[8].Property.PropertyName);
      Assert.AreEqual(80, Locations.All[8].Property.SalePrice);

      Assert.IsTrue(Locations.All[9].HasAProperty);
      Assert.AreEqual("Connecticut", Locations.All[9].Property.PropertyName);
      Assert.AreEqual(100, Locations.All[9].Property.SalePrice);

      Assert.IsFalse(Locations.All[10].HasAProperty);

      Assert.IsTrue(Locations.All[11].HasAProperty);
      Assert.AreEqual("St. Charles Place", Locations.All[11].Property.PropertyName);
      Assert.AreEqual(140, Locations.All[11].Property.SalePrice);

      //no utilities for now
      Assert.IsFalse(Locations.All[12].HasAProperty);

      Assert.IsTrue(Locations.All[13].HasAProperty);
      Assert.AreEqual("States", Locations.All[13].Property.PropertyName);
      Assert.AreEqual(140, Locations.All[13].Property.SalePrice);

      Assert.IsTrue(Locations.All[14].HasAProperty);
      Assert.AreEqual("Virginia", Locations.All[14].Property.PropertyName);
      Assert.AreEqual(160, Locations.All[14].Property.SalePrice);

      Assert.IsFalse(Locations.All[15].HasAProperty);

      Assert.IsTrue(Locations.All[16].HasAProperty);
      Assert.AreEqual("St. James Place", Locations.All[16].Property.PropertyName);
      Assert.AreEqual(180, Locations.All[16].Property.SalePrice);

      Assert.IsFalse(Locations.All[17].HasAProperty);

      Assert.IsTrue(Locations.All[18].HasAProperty);
      Assert.AreEqual("Tennessee", Locations.All[18].Property.PropertyName);
      Assert.AreEqual(180, Locations.All[18].Property.SalePrice);

      Assert.IsTrue(Locations.All[19].HasAProperty);
      Assert.AreEqual("New York", Locations.All[19].Property.PropertyName);
      Assert.AreEqual(200, Locations.All[19].Property.SalePrice);

      Assert.IsFalse(Locations.All[20].HasAProperty);

      Assert.IsTrue(Locations.All[21].HasAProperty);
      Assert.AreEqual("Kentucky", Locations.All[21].Property.PropertyName);
      Assert.AreEqual(220, Locations.All[21].Property.SalePrice);

      Assert.IsFalse(Locations.All[22].HasAProperty);

      Assert.IsTrue(Locations.All[23].HasAProperty);
      Assert.AreEqual("Indiana", Locations.All[23].Property.PropertyName);
      Assert.AreEqual(220, Locations.All[23].Property.SalePrice);

      Assert.IsTrue(Locations.All[24].HasAProperty);
      Assert.AreEqual("Illinois", Locations.All[24].Property.PropertyName);
      Assert.AreEqual(240, Locations.All[24].Property.SalePrice);

      Assert.IsFalse(Locations.All[25].HasAProperty);

      Assert.IsTrue(Locations.All[26].HasAProperty);
      Assert.AreEqual("Atlantic", Locations.All[26].Property.PropertyName);
      Assert.AreEqual(260, Locations.All[26].Property.SalePrice);

      Assert.IsTrue(Locations.All[27].HasAProperty);
      Assert.AreEqual("Ventnor", Locations.All[27].Property.PropertyName);
      Assert.AreEqual(260, Locations.All[27].Property.SalePrice);

      Assert.IsFalse(Locations.All[28].HasAProperty);

      Assert.IsTrue(Locations.All[29].HasAProperty);
      Assert.AreEqual("Marvin Gardens", Locations.All[29].Property.PropertyName);
      Assert.AreEqual(280, Locations.All[29].Property.SalePrice);

      Assert.IsFalse(Locations.All[30].HasAProperty);

      Assert.IsTrue(Locations.All[31].HasAProperty);
      Assert.AreEqual("Pacific", Locations.All[31].Property.PropertyName);
      Assert.AreEqual(300, Locations.All[31].Property.SalePrice);

      Assert.IsTrue(Locations.All[32].HasAProperty);
      Assert.AreEqual("North Carolina", Locations.All[32].Property.PropertyName);
      Assert.AreEqual(300, Locations.All[32].Property.SalePrice);

      Assert.IsFalse(Locations.All[33].HasAProperty);

      Assert.IsTrue(Locations.All[34].HasAProperty);
      Assert.AreEqual("Pennsylvania", Locations.All[34].Property.PropertyName);
      Assert.AreEqual(320, Locations.All[34].Property.SalePrice);

      Assert.IsFalse(Locations.All[35].HasAProperty);

      Assert.IsFalse(Locations.All[36].HasAProperty);

      Assert.IsTrue(Locations.All[37].HasAProperty);
      Assert.AreEqual("Park Place", Locations.All[37].Property.PropertyName);
      Assert.AreEqual(350, Locations.All[37].Property.SalePrice);

      Assert.IsFalse(Locations.All[38].HasAProperty);

      Assert.IsTrue(Locations.All[39].HasAProperty);
      Assert.AreEqual("Boardwalk", Locations.All[39].Property.PropertyName);
      Assert.AreEqual(400, Locations.All[39].Property.SalePrice);
    }

    [Test]
    public void Should_have_location_1_as_not_attached_to_a_property()
    {
      var location = Locations.All[0];

      Assert.IsFalse(location.HasAProperty);
    }
  }
}