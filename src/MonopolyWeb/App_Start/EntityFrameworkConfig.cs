using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.Core.EF;

// ReSharper disable once CheckNamespace
namespace MonopolyWeb
{
  // For more information on ASP.NET Identity, visit http://go.microsoft.com/fwlink/?LinkId=301863
  public static class EntityFrameworkConfig
  {
    private const string RoleClaimType = ClaimsIdentity.DefaultRoleClaimType;
    private const string UserNameClaimType = "http://schemas.microsoft.com/aspnet/userid";
    private const string UserIdClaimType = "http://schemas.microsoft.com/aspnet/username";
    private const string ClaimsIssuer = ClaimsIdentity.DefaultIssuer;

    public static IUserStore Users { get; private set; }

    public static void Configure()
    {
      var dbContextCreator = new DbContextFactory<MonopolyDotNetDbContext>();
      Users = new EFUserStore<User>(dbContextCreator);

      //Identity framework code, required
      AntiForgeryConfig.UniqueClaimTypeIdentifier = UserIdClaimType;
    }

    public static IEnumerable<Claim> GetNewUserIdentityClaims(string userId, string displayName)
    {
      var claims = new List<Claim>();
      claims.Add(new Claim(ClaimTypes.Name, displayName, ClaimsIssuer));
      claims.Add(new Claim(UserIdClaimType, userId, ClaimsIssuer)); //tried to delete this claim; apparently antiforgerytokens use/need this claim. So don't delete it.
      claims.Add(new Claim(UserNameClaimType, displayName, ClaimsIssuer));
      return claims;
    }

    public static void SignIn(HttpContextBase context, IEnumerable<Claim> userClaims, bool isPersistent)
    {
      context.SignIn(userClaims, ClaimTypes.Name, RoleClaimType, isPersistent);
    }
  }
}