namespace MonopolyWeb.Models.ViewModels
{
  public class TotemLocation
  {
    public TotemLocation(int offsetFromLeft, int offsetFromTop, int playerIndex, int boardIndex)
    {
      OffsetFromLeft = offsetFromLeft;
      OffsetFromTop = offsetFromTop;
      PlayerIndex = playerIndex;
      BoardIndex = boardIndex;
    }

    //assumes board is 720px total (minus a ~10px border/buffer on every side), and tokens are 30px
    public int OffsetFromLeft { get; set; }
    public int OffsetFromTop { get; set; }
    public int PlayerIndex { get; set; }
    public int BoardIndex { get; set; }
  }
}

