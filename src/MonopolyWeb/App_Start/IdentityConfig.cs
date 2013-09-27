using System.Web.Helpers;

// ReSharper disable once CheckNamespace
namespace MonopolyWeb
{
  public static class IdentityConfig
  {
    public const string UserIdClaimType = "http://schemas.microsoft.com/aspnet/username";

    public static void Configure()
    {
      AntiForgeryConfig.UniqueClaimTypeIdentifier = UserIdClaimType;
    }
  }
}