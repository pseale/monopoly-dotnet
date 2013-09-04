using System;
using System.Collections.Generic;
using MonopolyWeb.Models.Core;

namespace MonopolyWeb.Models.Services
{
  public static class TokenCoordinatesHelper
  {
    private static Location[] _midpoints = new[]
    {
      new Location(638,633),
      new Location(550,633), 
      new Location(507,633), 
      new Location(464,633), 
      new Location(415,633), 
      new Location(367,633), 
      new Location(320,633), 
      new Location(271,633), 
      new Location(225,633), 
      new Location(183,633), 

      
      new Location(89,633), 
      new Location(89,550), 
      new Location(89,499), 
      new Location(89,454), 
      new Location(89,408), 
      new Location(89,358), 
      new Location(89,308), 
      new Location(89,262), 
      new Location(89,217), 
      new Location(89,174), 

      new Location(89,82), 
      new Location(166,82), 
      new Location(217,82), 
      new Location(263,82), 
      new Location(312,82), 
      new Location(360,82), 
      new Location(407,82), 
      new Location(458,82), 
      new Location(499,82), 
      new Location(540,82), 
    
      new Location(640,82), 
      new Location(640,166), 
      new Location(640,218), 
      new Location(640,267), 
      new Location(640,314), 
      new Location(640,358), 
      new Location(640,405), 
      new Location(640,456), 
      new Location(640,500), 
      new Location(640,544), 
    };

    public static Location GetMidpointOf(int location)
    {
      return _midpoints[location];
    }

    public static TotemLocation AdjustPointToTopLeftOfTotem(TotemLocation totemLocation)
    {
      return new TotemLocation(totemLocation.OffsetFromLeft-15, totemLocation.OffsetFromTop-15, totemLocation.PlayerIndex, totemLocation.BoardIndex);
    }

    public static TotemLocation ShiftForPlayerIndex(TotemLocation totemLocation)
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

    public static TotemLocation[] GetLocationFromBoard(int[] locationsOnBoard)
    {
      var list = new List<TotemLocation>();
      for (int i=0; i<4; i++)
      {
        var locationOnBoard = locationsOnBoard[i];
        var location = GetMidpointOf(locationOnBoard);
        var totemLocation = new TotemLocation(location.OffsetFromLeft, location.OffsetFromTop, i, locationOnBoard);
        list.Add(ShiftForPlayerIndex(AdjustPointToTopLeftOfTotem(totemLocation)));
      }

      return list.ToArray();
    }
  }
}