using System;
using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.Services;

namespace MonopolyWeb.Models.Queries
{
  public static class FindGameByUsernameQuery
  {
    public static Game Execute(string username)
    {
      return InMemoryGameStorage.Games[username];
    }
  }
}