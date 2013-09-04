using System.Collections.Generic;

namespace MonopolyWeb.Models
{
  public class Game
  {
    private int _playersLocationOnBoard;
    private int[] _computerPlayersLocationsOnBoard = new int[3];
    public TotemLocation[] GetTotemLocations()
    {
      var locationsOnBoard = new List<int>();
      locationsOnBoard.Add(_playersLocationOnBoard);
      locationsOnBoard.AddRange(_computerPlayersLocationsOnBoard);
      return GetLocationFromBoard(locationsOnBoard);
    }

    private TotemLocation[] GetLocationFromBoard(IEnumerable<int> locationsOnBoard)
    {
      var list = new List<TotemLocation>();
      foreach (var locationOnBoard in locationsOnBoard)
      {
        //ok here's the math:
        //board is 720px x 720px (look at image to get a better visual)
        //squares at the corner are 160px x 160px, so the midpoint is 80px x 80px away from the absolute corner.
        //400px is split between 9 spots in the middle, so that's ~45px apiece. We'll say exactly 45px.
        //Our board "location" is stored as an int, 0 is go, 1 is Mediterrannean, 2 is the electric company, and so on.
        //Boardwalk (the last spot) is at index 39.
        //
        //So for spot 0, we want to get the midpoint of that square, so it's 720px -80px for both X and Y.
        //for spot 1, it's 720px -80 px for the Y, 720px -80 -45 for the X.
        //repeat all the way to spot 9. 
        //For spot 10, we start at 0px + 80 for X, 720px -80 for Y.
        //subtract 45px on the Y for each spot up to 19.
        //SPot 20, start at 0px + 80, 0px + 80.
        //count up +45px to X
        //Spot 30, start at 720px - 80 on X, 0px + 80 on Y.
        //count up +45px to Y.
        //
        //Ok we're ready. This is ugly math, but will work for now, I can't think of a simpler setup.

        int extraSpaceToAddForFirstMove = 40;
        int spacePerMove = 47;
        int totalBoardSize = 720;
        int halfwayOffsetForCornerTile = 80;

        if (locationOnBoard < 10)
        {
          int offsetFromLeft = totalBoardSize - halfwayOffsetForCornerTile;
          if (locationOnBoard > 0)
            offsetFromLeft -= extraSpaceToAddForFirstMove + locationOnBoard*spacePerMove;
          int offsetFromTop = totalBoardSize-halfwayOffsetForCornerTile;
          var totemLocation = new TotemLocation(offsetFromLeft, offsetFromTop);
          list.Add(totemLocation);
        }
        else if (locationOnBoard < 20)
        {
          int offsetFromLeft = 0 + halfwayOffsetForCornerTile;
          int offsetFromTop = totalBoardSize - halfwayOffsetForCornerTile;
          if (locationOnBoard%10 > 0)
            offsetFromTop -= extraSpaceToAddForFirstMove + (locationOnBoard%10)*spacePerMove;
          list.Add(new TotemLocation(offsetFromLeft, offsetFromTop));
        }
        else if (locationOnBoard < 30)
        {
          int offsetFromLeft = 0 + halfwayOffsetForCornerTile;
          if (locationOnBoard%10 > 0)
            offsetFromLeft += extraSpaceToAddForFirstMove + (locationOnBoard%10)*spacePerMove;
          int offsetFromTop = 0 + halfwayOffsetForCornerTile;
          list.Add(new TotemLocation(offsetFromLeft, offsetFromTop));
        }
        else
        {
          int offsetFromLeft = totalBoardSize - halfwayOffsetForCornerTile;
          int offsetFromTop = 0 + halfwayOffsetForCornerTile;
          if (locationOnBoard%10 > 0)
            offsetFromTop += extraSpaceToAddForFirstMove + (locationOnBoard%10)*spacePerMove;
          list.Add(new TotemLocation(offsetFromLeft, offsetFromTop));
        }
      }

      return list.ToArray();
    }

    public void Roll()
    {
      _playersLocationOnBoard++;
      _playersLocationOnBoard = _playersLocationOnBoard%40;
    }
  }
}