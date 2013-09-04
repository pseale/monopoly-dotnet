using System;
using System.Collections.Generic;

namespace MonopolyWeb.Models
{
  public static class InMemoryGameStorage
  {
     public static Dictionary<Guid, Game> Games = new Dictionary<Guid, Game>();
  }
}