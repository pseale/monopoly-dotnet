using System.Collections.Generic;
using System.Linq;

namespace MonopolyWeb.Models.Core
{
  public class Game
  {
    private int _playersLocationOnBoard;
    private readonly int[] _computerPlayersLocationsOnBoard = new int[3];

    private int _playerCash;
    private readonly int[] _computerPlayerCash = new int[3];
    private bool _playerPassesGoNextRoll;

    public Game()
    {
      _playerCash = 1500;
      for (int i = 0; i < 3; i++)
        _computerPlayerCash[i] = 1500;
    }

    public int[] GetTotemLocations()
    {
      var locationsOnBoard = new List<int>();
      locationsOnBoard.Add(_playersLocationOnBoard);
      locationsOnBoard.AddRange(_computerPlayersLocationsOnBoard);
      return locationsOnBoard.ToArray();
    }

    public int[] GetCash()
    {
      var cash = new List<int>();
      cash.Add(_playerCash);
      cash.AddRange(_computerPlayerCash);
      return cash.ToArray();
    }

    public void Roll()
    {
      _playersLocationOnBoard += Dice.Roll();
      if (_playersLocationOnBoard > 40)
        PassGo();
      else if (_playersLocationOnBoard == 40)
        _playerPassesGoNextRoll = true;
      else if (_playerPassesGoNextRoll)
      {
        _playerPassesGoNextRoll = false;
        PassGo();
      }

      _playersLocationOnBoard = _playersLocationOnBoard%40;
    }

    private void PassGo()
    {
      _playerCash += 200;
    }

    public List<List<string>> GetHoldings()
    {
      var list = new List<List<string>>();
      list.Add(new List<string>());
      list[0].Add("Boardwalk");
      list.Add(new List<string>());
      list.Add(new List<string>());
      list.Add(new List<string>());
      return list;
    }
  }
}