using System;
using System.Collections.Generic;
using MonopolyWeb.Models.Core;

namespace MonopolyWeb.Models.Services
{
  public static class InMemoryGameStorage
  {
     public static Dictionary<string, Game> Games = new Dictionary<string, Game>();
  }
}