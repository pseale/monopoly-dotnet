using System.Web.Mvc;
using MonopolyWeb.Models.Queries;

namespace MonopolyWeb.Filters
{
  public class InjectGameAttribute : ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      var username = Microsoft.AspNet.Identity.IdentityExtensions.GetUserName(filterContext.HttpContext.User.Identity);
      var game = FindGameByUsernameQuery.Execute(username);
      filterContext.ActionParameters["game"] = game;

      base.OnActionExecuting(filterContext);
    }
  }
}