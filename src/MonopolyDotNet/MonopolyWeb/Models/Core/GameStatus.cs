using System.Collections.Generic;

namespace MonopolyWeb.Models.Core
{
  public class GameStatus
  {
    public List<Player> Players { get; set; }
    public bool CanRoll { get; set; }
    public bool CanBuyProperty { get; set; }
    public bool CanEndTurn { get; set; }
    public int PropertySalePrice { get; set; }
  }
}