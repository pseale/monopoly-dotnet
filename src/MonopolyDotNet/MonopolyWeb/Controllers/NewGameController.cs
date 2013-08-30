using MonopolyWeb.Models;
using MvcContrib;
using System.Web.Mvc;

namespace MonopolyWeb.Controllers
{
  public class NewGameController : Controller
  {
    [HttpGet]
    public ActionResult Index()
    {
      return View(new NewGame());
    }

    [HttpPost]
    public ActionResult Index(NewGame newGame)
    {
      if (!ModelState.IsValid)
      {
        return View(newGame);
      }

      return this.RedirectToAction<GameController>(x => x.Index());
    }
  }
}