using System;
using System.Web.Mvc;
using Microsoft.Web.Mvc;
using MonopolyWeb.Models;
using MonopolyWeb.Models.Queries;
using MonopolyWeb.Models.Services;

namespace MonopolyWeb.Controllers
{
  public class GameController : Controller
  {
    public ActionResult Index()
    {
      var playerId = (Guid) Session["playerId"];
      var game = FindGameByPlayerIdQuery.Execute(playerId);
      var gameStatus = GameFormatter.Flatten(game);
      return View(gameStatus);
    }

    [HttpPost]
    public ActionResult Roll()
    {
      var playerId = (Guid)Session["playerId"];
      var game = FindGameByPlayerIdQuery.Execute(playerId);
      game.Roll();
      return this.RedirectToAction<GameController>(x => x.Index());
    }
  }
}