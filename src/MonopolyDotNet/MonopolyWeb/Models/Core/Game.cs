using System.Collections.Generic;
using System.Linq;

namespace MonopolyWeb.Models.Core
{
  public class Game
  {
    private int _playersLocationOnBoard;
    private int[] _computerPlayersLocationsOnBoard = new int[3];
    public int[] GetTotemLocations()
    {
      var locationsOnBoard = new List<int>();
      locationsOnBoard.Add(_playersLocationOnBoard);
      locationsOnBoard.AddRange(_computerPlayersLocationsOnBoard);
      return locationsOnBoard.ToArray();
    }


    public void Roll()
    {
      _playersLocationOnBoard++;
      _playersLocationOnBoard = _playersLocationOnBoard%40;
    }
  }
}