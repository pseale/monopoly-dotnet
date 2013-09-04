namespace MonopolyWeb.Models.Core
{
  public class Location
  {
    public Location(int offsetFromLeft, int offsetFromTop)
    {
      OffsetFromLeft = offsetFromLeft;
      OffsetFromTop = offsetFromTop;
    }

    //assumes board is 720px total (minus a ~10px border/buffer on every side), and tokens are 30px
    public int OffsetFromLeft { get; set; }
    public int OffsetFromTop { get; set; }
  }
}