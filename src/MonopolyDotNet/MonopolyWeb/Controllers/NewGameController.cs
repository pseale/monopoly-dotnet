using System;
using Microsoft.Web.Mvc;
using System.Web.Mvc;
using MonopolyWeb.Models.Commands;
using MonopolyWeb.Models.Converters;
using MonopolyWeb.Models.ViewModels;

namespace MonopolyWeb.Controllers
{
  [Authorize]
  public class NewGameController : Controller
  {
    [HttpGet]
    public ActionResult Index()
    {
      return View(new NewGameInput());
    }

    [HttpPost]
    public ActionResult Index(NewGameInput newGameInput)
    {
      if (!ModelState.IsValid)
      {
        return View(newGameInput);
      }

      var newGameData = NewGameConverter.Convert(newGameInput);
      Guid playerId = Guid.NewGuid();
      var username = Microsoft.AspNet.Identity.IdentityExtensions.GetUserName(User.Identity);
      CreateGameCommand.Execute(username, newGameData);
      

      // If we got this far, something failed, redisplay form
      return this.RedirectToAction<GameController>(x => x.Index());
    }
  }
}