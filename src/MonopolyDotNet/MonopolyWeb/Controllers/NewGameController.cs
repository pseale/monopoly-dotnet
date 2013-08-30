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
      return View(new NewGameInput());
    }

    [HttpPost]
    public ActionResult Index(NewGameInput newGameInput)
    {
      if (!ModelState.IsValid)
      {
        return View(newGameInput);
      }

      return this.RedirectToAction<GameController>(x => x.Index());
    }
  }
}