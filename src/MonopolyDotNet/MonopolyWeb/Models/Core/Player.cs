using System.Collections.Generic;

namespace MonopolyWeb.Models.Core
{
  public class Player
  {
    public Player()
    {
      Holdings = new List<Property>();
    }
    
    public bool IsHuman { get; set; }
    public int Cash { get; set; } 
    public Location Location { get; set; }
    public List<Property> Holdings { get; set; }
    public bool PassesGoOnNextRoll { get; set; }
  }
}