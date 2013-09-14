using System;
using System.Web.Mvc;
using Microsoft.Web.Mvc;
using MonopolyWeb.Models.Commands;
using MonopolyWeb.Models.Converters;
using MonopolyWeb.Models.Queries;

namespace MonopolyWeb.Controllers
{
  public class GameController : Controller
  {
    public ActionResult Index()
    {
      if (!(Session["playerId"] is Guid))
        return this.RedirectToAction<LogoutController>(x => x.Index());

      var playerId = (Guid) Session["playerId"];
      var game = FindGameByPlayerIdQuery.Execute(playerId);
      var gameStatus = GameFormatter.Flatten(game);
      return View(gameStatus);
    }

    [HttpPost]
    public ActionResult Roll()
    {
      if (!(Session["playerId"] is Guid))
        return this.RedirectToAction<LogoutController>(x => x.Index());

      var playerId = (Guid)Session["playerId"];
      var game = FindGameByPlayerIdQuery.Execute(playerId);
      RollDiceCommand.Execute(game);
      return this.RedirectToAction<GameController>(x => x.Index());
    }

    [HttpPost]
    public ActionResult BuyProperty()
    {
      if (!(Session["playerId"] is Guid))
        return this.RedirectToAction<LogoutController>(x => x.Index());

      var playerId = (Guid)Session["playerId"];
      var game = FindGameByPlayerIdQuery.Execute(playerId);
      BuyPropertyCommand.Execute(game);

      return this.RedirectToAction<GameController>(x => x.Index());
    }
  }
}