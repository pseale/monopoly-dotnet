﻿using System.Web.Mvc;

namespace MonopolyWeb.Controllers
{
  public class NewGameController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult Create()
    {
      throw new System.NotImplementedException();
    }
  }
}