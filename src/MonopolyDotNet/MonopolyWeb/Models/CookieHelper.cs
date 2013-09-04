using System;
using System.Web;

namespace MonopolyWeb.Models
{
  public static class CookieHelper
  {
    private const string CookieName = "monopolydotnet";

    public static HttpCookie Create(Guid playerId)
    {
      var cookie = new HttpCookie(CookieName, playerId.ToString("D"));
      cookie.Expires = new DateTime(2099, 12, 31);
      return cookie;
    }

    public static HttpCookie CreateExpiredCookie(string cookieName)
    {
      var cookie = new HttpCookie(cookieName);
      cookie.Expires = DateTime.Today.AddDays(-2);
      return cookie;
    }

    public static Guid GetPlayerIdFrom(HttpCookieCollection collection)
    {
      return Guid.Parse(collection[CookieName].Value);
    }
  }
}