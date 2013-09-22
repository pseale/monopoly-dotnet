namespace MonopolyWeb.Models.ViewModels
{
  public class OpponentsViewModel
  {
    public static string[] All;

    static OpponentsViewModel()
    {
      All = new string[] { "Rube", "Chester", "Mike Shishesky", "Mike Krzyzewski", "Adolf" };
    }
  }
}