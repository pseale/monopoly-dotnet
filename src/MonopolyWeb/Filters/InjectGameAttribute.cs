using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MonopolyWeb.Models.Queries;

namespace MonopolyWeb.Filters
{
  public class InjectGameAttribute : ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      var username = filterContext.HttpContext.User.Identity.Name;
      var game = FindGameByUsernameQuery.Execute(username);
      filterContext.ActionParameters["game"] = game;

      base.OnActionExecuting(filterContext);
    }
  }
}