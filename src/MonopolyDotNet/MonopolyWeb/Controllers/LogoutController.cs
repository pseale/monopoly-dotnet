using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web.Mvc;

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
      {
        var newCookie = new HttpCookie(cookie);
        newCookie.Expires = DateTime.Today.AddDays(-2);
        Response.Cookies.Add(newCookie);
      }

      return View();
      //return this.RedirectToAction<HomeController>(x => x.Index());
    }
  }
}