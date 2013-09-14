namespace MonopolyWeb.Models.Services
{
  public static class CashHelper
  {
    public static string FormatAsCash(int cash)
    {
      return "$" + cash;
    }
  }
}