using System.Collections.Generic;
using System.Web.Mvc;
using MonopolyWeb.Models;
using MonopolyWeb.Models.Services;

namespace MonopolyWeb.Controllers
{
  public class LogoutController : Controller
  {
    public ActionResult Index()
    {
      Session.Abandon();

      return View();
    }
  }
}