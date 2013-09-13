using System.CodeDom;
using System.Collections.Generic;

namespace MonopolyWeb.Models.ViewModels
{
  public class GameStatus
  {
    public GameStatus()
    {
      PlayerStatuses = new List<PlayerStatus>();
    }

    public List<PlayerStatus> PlayerStatuses { get; set; }
    public bool CanBuyProperty { get; set; }
    public int SalePrice { get; set; }
  }
}