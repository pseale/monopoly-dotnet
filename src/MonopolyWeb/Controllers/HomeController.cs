using System.Web.Mvc;

namespace MonopolyWeb.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
  }
}