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
      CreateUserCommand.Execute(HttpContext, username);
      CreateGameCommand.Execute(username, newGameData);

      return this.RedirectToAction<HomeController>(x => x.Index());
    }
  }
}