using System.Collections.Generic;
using System.Web.Mvc;
using MonopolyWeb.Models;

namespace MonopolyWeb.Controllers
{
  public class LogoutController : Controller
  {
    public ActionResult Index()
    {
      var cookieList = new List<string>();
      foreach (var cookieName in Request.Cookies.Keys)
        cookieList.Add(cookieName.ToString());

      foreach (var cookie in cookieList)
        Response.Cookies.Add(CookieHelper.CreateExpiredCookie(cookie));

      return View();
    }
  }
}