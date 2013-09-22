using System.Linq;
using MonopolyWeb.Models.Core;

namespace MonopolyWeb.Models.Services
{
  public static class RentService
  {
    public static void DoRentTransaction(Game game, Player player)
    {
      if (!player.Location.HasAProperty)
        return;

      //I hate using reference equality but I'll do it here for player == player and property == property
      var allOtherPlayers = game.Players.Where(x => x != player);
      var otherPlayersProperty = allOtherPlayers.SelectMany(x => x.Holdings);
      var matchingProperties = otherPlayersProperty.Where(x => x == player.Location.Property).ToList();
      if (!matchingProperties.Any())
        return;

      var matchingProperty = matchingProperties.First();
      var propertyOwner = game.Players.Where(x => x.Holdings.Contains(matchingProperty)).First();

      player.Cash -= matchingProperty.Rent;
      propertyOwner.Cash += matchingProperty.Rent;
    }

  }
}