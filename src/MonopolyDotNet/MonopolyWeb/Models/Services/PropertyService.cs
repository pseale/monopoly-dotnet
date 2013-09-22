using System.Linq;
using MonopolyWeb.Models.Core;

namespace MonopolyWeb.Models.Services
{
  public static class PropertyService
  {
    //This would go really well on the Player object but I'm still trying to keep all the model objects underneath Game dumb for now. We'll
    //see when the pressure becomes too much and I have to just move the logic to the currently "dumb" objects like Player. But know
    //that I see that this would be the #1 candidate to move off of Game.
    public static bool CanBuyProperty(Game game, Player player)
    {
      var location = player.Location;
      if (!location.HasAProperty)
        return false;

      if (player.Cash < location.Property.SalePrice)
        return false;

      var doesAnyoneOwnThisProperty = game.Players.SelectMany(x => x.Holdings).Any(x => x == location.Property);

      return !doesAnyoneOwnThisProperty;
    }

    public static void BuyProperty(Player player)
    {
      var property = player.Location.Property;
      player.Holdings.Add(property);
      player.Cash -= property.SalePrice;
    }
  }
}