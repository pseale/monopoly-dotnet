using System.Web;
using System.Web.Mvc;
using Microsoft.Web.Mvc;

namespace MonopolyWeb.Controllers
{
  public class QuitGameController : Controller
  {
    public ActionResult Index()
    {
      if (User.Identity.IsAuthenticated)
        HttpContext.SignOut();
      return this.RedirectToAction<HomeController>(x => x.Index());
    }
  }
}