namespace MonopolyWeb.Models.Core
{
  public class NewGameData
  {
    public NewGameData(string playerName, Totem playerTotem, string opponent1Name, string opponent2Name, string opponent3Name)
    {
      PlayerName = playerName;
      PlayerTotem = playerTotem;
      Opponent1Name = opponent1Name;
      Opponent2Name = opponent2Name;
      Opponent3Name = opponent3Name;
    }

    public string PlayerName { get; private set; }
    public Totem PlayerTotem { get; private set; }
    public string Opponent1Name { get; private set; }
    public string Opponent2Name { get; private set; }
    public string Opponent3Name { get; private set; }
  }
}