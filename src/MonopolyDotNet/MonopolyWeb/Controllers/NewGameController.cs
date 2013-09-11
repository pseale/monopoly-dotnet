using System;
using System.Web;
using Microsoft.Web.Mvc;
using MonopolyWeb.Models;
using System.Web.Mvc;
using MonopolyWeb.Models.Commands;
using MonopolyWeb.Models.Services;
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

    [HttpPost]
    public ActionResult Index(NewGameInput newGameInput)
    {
      if (!ModelState.IsValid)
      {
        return View(newGameInput);
      }

      Guid playerId = Guid.NewGuid();
      CreateGameCommand.Execute(playerId);

      Session["playerId"] = playerId;

      return this.RedirectToAction<GameController>(x => x.Index());
    }
  }
}