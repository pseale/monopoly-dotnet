using System;
using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.Services;

namespace MonopolyWeb.Models.Queries
{
  public static class FindGameByPlayerIdQuery
  {
    public static Game Execute(Guid playerId)
    {
      return InMemoryGameStorage.Games[playerId];
    }
  }
}