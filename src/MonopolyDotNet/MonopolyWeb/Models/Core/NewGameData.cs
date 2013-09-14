namespace MonopolyWeb.Models.Core
{
  public class NewGameData
  {
    public string PlayerName { get; set; }
    public Totem PlayerTotem { get; set; }
    public string Opponent1Name { get; set; }
    public string Opponent2Name { get; set; }
    public string Opponent3Name { get; set; }
  }
}