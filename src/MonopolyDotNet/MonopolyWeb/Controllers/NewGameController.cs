using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Security;
using Microsoft.Web.Mvc;
using System.Web.Mvc;
using MonopolyWeb.Models;
using MonopolyWeb.Models.Commands;
using MonopolyWeb.Models.Converters;
using MonopolyWeb.Models.ViewModels;

namespace MonopolyWeb.Controllers
{
  public class NewGameController : Controller
  {
    [HttpGet]
    public ActionResult Index()
    {
      return View(new NewGameInput());
    }

    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<ActionResult> Index(NewGameInput newGameInput)
    {
      if (!ModelState.IsValid)
      {
        return View(newGameInput);
      }

      var newGameData = NewGameConverter.Convert(newGameInput);
      var username = Guid.NewGuid().ToString("D");
      await CreateUserAndThenLogIn(username);

      CreateGameCommand.Execute(username, newGameData);

      return this.RedirectToAction<GameController>(x => x.Index());
    }

    private async Task CreateUserAndThenLogIn(string username)
    {
      var user = new User(username);
      await IdentityConfig.Users.Create(user);
      await IdentityConfig.Secrets.Create(new UserSecret(username, "123456"));
      await IdentityConfig.Logins.Add(new UserLogin(user.Id, IdentityConfig.LocalLoginProvider, username));
      IList<Claim> userClaims = IdentityConfig.RemoveUserIdentityClaims(new Claim[0]);
      IdentityConfig.AddUserIdentityClaims(user.Id, user.UserName, userClaims);
      IdentityConfig.SignIn(HttpContext, userClaims, false);
    }
  }
}