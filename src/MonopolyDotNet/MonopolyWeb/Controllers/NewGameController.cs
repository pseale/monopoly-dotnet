using System.ComponentModel.DataAnnotations;
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

  public class NewGame
  {
    [Required]
    public string Name { get; set; }
    [Required]
    public string Totem { get; set; }
    [Required]
    public string Player2 { get; set; }
    [Required]
    public string Player3 { get; set; }
    [Required]
    public string Player4 { get; set; }
  }
}