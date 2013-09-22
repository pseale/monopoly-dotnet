using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyWeb.Models.Services;

namespace MonopolyWeb.Models.Core
{
  public class Game
  {
    public List<Player> Players { get; set; }

    public Game()
    {
      Players = new List<Player>();
    }
  }
}