using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using MonopolyWeb.Models.Core;

#if DEBUG

namespace MonopolyWeb.Controllers
{
  //one man's gaping security hole is another man's useful admin tool
  public class SecretAdminController : Controller
  {
    [HttpPost]
    public ActionResult ReplaceRolls(string rolls)
    {
      var rollsParsed = rolls.Split(',').Select(x => int.Parse(x)).ToList();
      Dice.ReplaceRandomRollsWith(rollsParsed);

      return Json(new{ success = true });
    }

    [HttpPost]
    public ActionResult ResetRollsToDefault()
    {
      Dice.Roll = Dice.StandardBehavior;
      return Json(new { success = true });
    }
  }
}

#endif