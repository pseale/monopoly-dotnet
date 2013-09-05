namespace MonopolyWeb.Models.ViewModels
{
  public class GameStatus
  {
    public string Player1OffsetFromLeft { get; set; }
    public string Player1OffsetFromTop { get; set; }
    public string Player2OffsetFromLeft { get; set; }
    public string Player2OffsetFromTop { get; set; }
    public string Player3OffsetFromLeft { get; set; }
    public string Player3OffsetFromTop { get; set; }
    public string Player4OffsetFromLeft { get; set; }
    public string Player4OffsetFromTop { get; set; }

    public string Player1Cash { get; set; }
    public string Player2Cash { get; set; }
    public string Player3Cash { get; set; }
    public string Player4Cash { get; set; }
  }
}