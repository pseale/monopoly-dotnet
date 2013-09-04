using System;

namespace MonopolyWeb.Models
{
  public static class FindGameByPlayerIdQuery
  {
    public static Game Execute(Guid playerId)
    {
      return InMemoryGameStorage.Games[playerId];
    }
  }
}