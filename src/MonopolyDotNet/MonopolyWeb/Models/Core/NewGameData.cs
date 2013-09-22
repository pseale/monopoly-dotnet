using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyWeb.Models.Core
{
  public class NewGameData
  {
    private readonly List<Player> _players = new List<Player>();

    public NewGameData(string playerName, Totem playerTotem, string opponent1Name, string opponent2Name, string opponent3Name)
    {
      _players.Add(CreateHumanPlayer(playerName, playerTotem));

      var allTotems = Enum.GetValues(typeof(Totem)).Cast<Totem>().ToList();
      allTotems.Remove(playerTotem);
      var availableTotems = new Stack<Totem>(allTotems);

      _players.Add(CreateOpponent(opponent1Name, 2, availableTotems.Pop()));
      _players.Add(CreateOpponent(opponent2Name, 3, availableTotems.Pop()));
      _players.Add(CreateOpponent(opponent3Name, 4, availableTotems.Pop()));
    }

    public IEnumerable<Player> GetPlayers()
    {
      return _players;
    }

    private Player CreateHumanPlayer(string playerName, Totem playerTotem)
    {
      var humanPlayer = new Player(playerName, playerTotem, true, 1);
      return humanPlayer;
    }

    private Player CreateOpponent(string opponentName, int playerIndex, Totem totem)
    {
      var opponent = new Player(opponentName, totem, false, playerIndex);
      return opponent;
    }
  }
}