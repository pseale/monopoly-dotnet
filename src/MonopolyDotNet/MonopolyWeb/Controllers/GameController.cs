using System.Web.Mvc;

namespace MonopolyWeb.Controllers
{
  public class GameController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
  }
}