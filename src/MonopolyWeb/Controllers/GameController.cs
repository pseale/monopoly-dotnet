using System.Web.Mvc;
using Microsoft.Web.Mvc;
using MonopolyWeb.Filters;
using MonopolyWeb.Models.Commands;
using MonopolyWeb.Models.Converters;
using MonopolyWeb.Models.Core;

namespace MonopolyWeb.Controllers
{
  [InjectGame]
  [Authorize]
  public class GameController : Controller
  {
    public ActionResult Index(Game game)
    {
      var gameStatus = GameFormatter.Flatten(game);
      return View(gameStatus);
    }

    [ValidateAntiForgeryToken]
    [HttpPost]
    public ActionResult Roll(Game game)
    {
      RollDiceCommand.Execute(game);
      return this.RedirectToAction<HomeController>(x => x.Index());
    }

    [ValidateAntiForgeryToken]
    [HttpPost]
    public ActionResult BuyProperty(Game game)
    {
      BuyPropertyCommand.Execute(game);
      return this.RedirectToAction<HomeController>(x => x.Index());
    }

    [ValidateAntiForgeryToken]
    [HttpPost]
    public ActionResult EndTurn(Game game)
    {
      EndTurnCommand.Execute(game);
      return this.RedirectToAction<HomeController>(x => x.Index());
    }
  }
}