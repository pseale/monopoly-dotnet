namespace MonopolyWeb.Models.Services
{
  public static class IntFormatExtensions
  {
    public static string FormatAsCash(this int cash)
    {
      return "$" + cash;
    }
  }
}