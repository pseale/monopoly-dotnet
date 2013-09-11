using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyWeb.Models.Core
{
  public class Game
  {
    private readonly List<Player> _players = new List<Player>(); 

    public Game()
    {
      for (int i=0; i<4; i++)
        _players.Add(new Player() { Cash = 1500 });
    }

    public int[] GetTotemLocations()
    {
      return _players.Select(x => x.Location).ToArray();
    }

    public int[] GetCash()
    {
      return _players.Select(x => x.Cash).ToArray();
    }

    public List<List<Property>> GetHoldings()
    {
      return _players.Select(x => x.Holdings).ToList();
    }

    public void Roll()
    {
      var player = _players[0];
      player.Location += Dice.Roll();
      
      if (player.Location > 40)
      {
        PassGo();
      }
      else if (player.Location == 40)
      {
        player.PassesGoOnNextRoll = true;
      }
      else if (player.PassesGoOnNextRoll)
      {
        player.PassesGoOnNextRoll = false;
        PassGo();
      }

      player.Location %= 40;
    }

    private void PassGo()
    {
      _players[0].Cash += 200;
    }

    public IEnumerable<Player> GetPlayers()
    {
      return _players;
    }
  }
}