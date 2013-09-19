using System;
using System.Web.Mvc;
using Microsoft.Web.Mvc;
using MonopolyWeb.Models.Commands;
using MonopolyWeb.Models.Converters;
using MonopolyWeb.Models.Queries;

namespace MonopolyWeb.Controllers
{
  [Authorize]
  public class GameController : Controller
  {
    public ActionResult Index()
    {
      var username = Microsoft.AspNet.Identity.IdentityExtensions.GetUserName(User.Identity);
      var game = FindGameByUsernameQuery.Execute(username);
      var gameStatus = GameFormatter.Flatten(game);
      return View(gameStatus);
    }

    [HttpPost]
    public ActionResult Roll()
    {
      var username = Microsoft.AspNet.Identity.IdentityExtensions.GetUserName(User.Identity);
      var game = FindGameByUsernameQuery.Execute(username);
      RollDiceCommand.Execute(game);
      return this.RedirectToAction<GameController>(x => x.Index());
    }

    [HttpPost]
    public ActionResult BuyProperty()
    {
      var username = Microsoft.AspNet.Identity.IdentityExtensions.GetUserName(User.Identity);
      var game = FindGameByUsernameQuery.Execute(username);
      BuyPropertyCommand.Execute(game);

      return this.RedirectToAction<GameController>(x => x.Index());
    }

    [HttpPost]
    public ActionResult EndTurn()
    {
      var username = Microsoft.AspNet.Identity.IdentityExtensions.GetUserName(User.Identity);
      var game = FindGameByUsernameQuery.Execute(username);
      EndTurnCommand.Execute(game);

      return this.RedirectToAction<GameController>(x => x.Index());
    }
  }
}