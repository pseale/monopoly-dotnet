using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ASPNETIdentity;

namespace MonopolyWeb
{
  // For more information on ASP.NET Identity, visit http://go.microsoft.com/fwlink/?LinkId=301863
  public static class IdentityConfig
  {
    public static IUserStore Users { get; set; }
    public static IRoleStore Roles { get; set; }
    public static string RoleClaimType { get; set; }
    public static string UserNameClaimType { get; set; }
    public static string UserIdClaimType { get; set; }
    public static string ClaimsIssuer { get; set; }

    public static void ConfigureIdentity()
    {
      var dbContextCreator = new DbContextFactory<IdentityDbContext>();
      Users = new EFUserStore<User>(dbContextCreator);
      Roles = new EFRoleStore<Role, UserRole>(dbContextCreator);
      RoleClaimType = ClaimsIdentity.DefaultRoleClaimType;
      UserIdClaimType = "http://schemas.microsoft.com/aspnet/userid";
      UserNameClaimType = "http://schemas.microsoft.com/aspnet/username";
      ClaimsIssuer = ClaimsIdentity.DefaultIssuer;
      AntiForgeryConfig.UniqueClaimTypeIdentifier = IdentityConfig.UserIdClaimType;
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