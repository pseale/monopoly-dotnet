using System.Collections.Generic;
using System.Web.Mvc;

namespace MonopolyWeb.Models.ViewModels
{
  public class PlayerStatusViewModel
  {
    public PlayerStatusViewModel()
    {
      Holdings = new List<SelectListItem>();
    }

    public string Name { get; set; }
    public bool IsHuman { get; set; }
    public int PlayerNumber { get; set; }
    public string OffsetFromLeft { get; set; }
    public string OffsetFromTop { get; set; }
    public string Cash { get; set; }
    public List<SelectListItem> Holdings { get; set; }
  }
}