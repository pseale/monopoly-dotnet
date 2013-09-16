using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.ViewModels;

namespace MonopolyWeb.Models.Services
{
  public static class TokenCoordinatesHelper
  {
    private static readonly LocationViewModel[] Midpoints = new[]
    {
      new LocationViewModel(638,633),
      new LocationViewModel(550,633), 
      new LocationViewModel(507,633), 
      new LocationViewModel(464,633), 
      new LocationViewModel(415,633), 
      new LocationViewModel(367,633), 
      new LocationViewModel(320,633), 
      new LocationViewModel(271,633), 
      new LocationViewModel(225,633), 
      new LocationViewModel(183,633), 

      
      new LocationViewModel(89,633), 
      new LocationViewModel(89,550), 
      new LocationViewModel(89,499), 
      new LocationViewModel(89,454), 
      new LocationViewModel(89,408), 
      new LocationViewModel(89,358), 
      new LocationViewModel(89,308), 
      new LocationViewModel(89,262), 
      new LocationViewModel(89,217), 
      new LocationViewModel(89,174), 

      new LocationViewModel(89,82), 
      new LocationViewModel(166,82), 
      new LocationViewModel(217,82), 
      new LocationViewModel(263,82), 
      new LocationViewModel(312,82), 
      new LocationViewModel(360,82), 
      new LocationViewModel(407,82), 
      new LocationViewModel(458,82), 
      new LocationViewModel(499,82), 
      new LocationViewModel(540,82), 
    
      new LocationViewModel(640,82), 
      new LocationViewModel(640,166), 
      new LocationViewModel(640,218), 
      new LocationViewModel(640,267), 
      new LocationViewModel(640,314), 
      new LocationViewModel(640,358), 
      new LocationViewModel(640,405), 
      new LocationViewModel(640,456), 
      new LocationViewModel(640,500), 
      new LocationViewModel(640,544), 
    };

    public static LocationViewModel GetMidpointOf(int location)
    {
      return Midpoints[location];
    }

    private static TotemLocation AdjustPointToTopLeftOfTotem(TotemLocation totemLocation)
    {
      return new TotemLocation(totemLocation.OffsetFromLeft-15, totemLocation.OffsetFromTop-15, totemLocation.PlayerIndex, totemLocation.BoardIndex);
    }

    private static TotemLocation ShiftForPlayerIndex(TotemLocation totemLocation)
    {
      int pixelsToShift = -30 + totemLocation.PlayerIndex * 20;
      var directionToShift = new int[2];

      if (totemLocation.BoardIndex < 10)
      {
        directionToShift[0] = 0;
        directionToShift[1] = 1;
      }
      else if (totemLocation.BoardIndex < 20)
      {
        directionToShift[0] = -1;
        directionToShift[1] = 0;
      }
      else if (totemLocation.BoardIndex < 30)
      {
        directionToShift[0] = 0;
        directionToShift[1] = -1;
      }
      else
      {
        directionToShift[0] = 1;
        directionToShift[1] = 0;
      }

      return new TotemLocation(totemLocation.OffsetFromLeft + directionToShift[0] * pixelsToShift, totemLocation.OffsetFromTop + directionToShift[1]*pixelsToShift, totemLocation.PlayerIndex, totemLocation.BoardIndex);
    }

    public static TotemLocation GetLocationOnBoard(Player player)
    {
      var location = GetMidpointOf(player.Location.Index);
      var totemLocation = new TotemLocation(location.OffsetFromLeft, location.OffsetFromTop, player.Index, player.Location.Index);
      var adjustedPoint = AdjustPointToTopLeftOfTotem(totemLocation);
      var finalPoint = ShiftForPlayerIndex(adjustedPoint);
      return finalPoint;
    }
  }
}