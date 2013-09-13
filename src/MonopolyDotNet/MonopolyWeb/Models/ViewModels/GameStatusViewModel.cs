using System.CodeDom;
using System.Collections.Generic;

namespace MonopolyWeb.Models.ViewModels
{
  public class GameStatusViewModel
  {
    public GameStatusViewModel()
    {
      PlayerStatuses = new List<PlayerStatusViewModel>();
    }

    public List<PlayerStatusViewModel> PlayerStatuses { get; set; }
    public bool CanBuyProperty { get; set; }
    public int SalePrice { get; set; }
  }
}