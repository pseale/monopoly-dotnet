using System.Data.Entity;
using System.Linq;
using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.Core.EF;

namespace MonopolyWeb.Models.Queries
{
  public static class FindGameByUsernameQuery
  {
    public static Game Execute(string username)
    {
      using (var context = new MonopolyDotNetDbContext())
      {
        return context.Games
          .AsQueryable()
          .Include(x=>x.Players)
          .Include(x=>x.Players.Select(y=>y.Holdings))
          .Include(x => x.Players.Select(y => y.Location))
          .Include(x => x.Players.Select(y => y.Location.Property))
          .Single(x => x.Username == username);
      }
    }
  }
}