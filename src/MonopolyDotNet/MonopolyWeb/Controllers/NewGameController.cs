using System;
using System.Web;
using Microsoft.Web.Mvc;
using MonopolyWeb.Models;
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

      var cookie = new HttpCookie("monopolydotnet", Guid.NewGuid().ToString("D"));
      cookie.Expires = new DateTime(2099, 12, 31);
      Response.Cookies.Add(cookie);
      return this.RedirectToAction<GameController>(x => x.Index());
    }
  }
}