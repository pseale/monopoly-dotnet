using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.Core.EF;

namespace MonopolyWeb.Models.Commands
{
  public static class CreateUserCommand
  {
    private const string RoleClaimType = ClaimsIdentity.DefaultRoleClaimType;
    private const string UserNameClaimType = "http://schemas.microsoft.com/aspnet/userid";
    private const string ClaimsIssuer = ClaimsIdentity.DefaultIssuer;

    public static void Execute(HttpContextBase httpContext, string username)
    {
      var user = new User(username);
      var userStore = new EFUserStore<User>(new DbContextFactory<MonopolyDotNetDbContext>());
      //I tried adding a task.Wait() after this call to make sure this create call finishes, but it seems like
      //either I'm doing something horribly wrong (?) or the framework code isn't setting the task to Completed status after done.
      //I really really don't know, but I DO know that if I uncomment that task.Wait() call, it will wait forever, and I DO know
      //that the correct way to "wait for an async task to finish" is to use task.Wait(), so I'm just leaving this here with this 
      //longwinded comment that absolves me of all responsibility. You Have Been Warned.
      //
      //I also tried task.GetAwaiter().GetResult(); -- no dice.
      //
      //It's probably because I'm using preview code (not even RC).
      var task = userStore.Create(user);
      //task.GetAwaiter().GetResult();
      //task.Wait();
      var userClaims = GetNewUserIdentityClaims(user.Id, user.UserName);
      SignIn(httpContext, userClaims, false);
    }

    private static IEnumerable<Claim> GetNewUserIdentityClaims(string userId, string displayName)
    {
      var claims = new List<Claim>();
      claims.Add(new Claim(ClaimTypes.Name, displayName, ClaimsIssuer));
      claims.Add(new Claim(IdentityConfig.UserIdClaimType, userId, ClaimsIssuer)); //tried to delete this claim; apparently antiforgerytokens use/need this claim. So don't delete it.
      claims.Add(new Claim(UserNameClaimType, displayName, ClaimsIssuer));
      return claims;
    }

    private static void SignIn(HttpContextBase context, IEnumerable<Claim> userClaims, bool isPersistent)
    {
      context.SignIn(userClaims, ClaimTypes.Name, RoleClaimType, isPersistent);
    }
  }
}