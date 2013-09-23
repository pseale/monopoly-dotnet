using System;
using System.Threading.Tasks;
using Microsoft.Web.Mvc;
using System.Web.Mvc;
using MonopolyWeb.Models.Commands;
using MonopolyWeb.Models.Converters;
using MonopolyWeb.Models.Core;
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

      return this.RedirectToAction<HomeController>(x => x.Index());
    }

    private async Task CreateUserAndThenLogIn(string username)
    {
      var user = new User(username);
      await EntityFrameworkConfig.Users.Create(user);
      var userClaims = EntityFrameworkConfig.GetNewUserIdentityClaims(user.Id, user.UserName);
      EntityFrameworkConfig.SignIn(HttpContext, userClaims, false);
    }
  }
}