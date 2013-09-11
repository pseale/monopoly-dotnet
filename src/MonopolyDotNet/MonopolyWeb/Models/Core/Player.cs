using System.Collections.Generic;

namespace MonopolyWeb.Models.Core
{
  public class Player
  {
    public Player()
    {
      Holdings = new List<Property>();
    }

    public int Cash { get; set; } 
    public int Location { get; set; }
    public List<Property> Holdings { get; set; }
    public bool PassesGoOnNextRoll { get; set; }
  }

  public class Property
  {
    public Property()
    {
      SalePrice = 100;
    }
    public string Name { get; set; }
    public int SalePrice { get; set; }
  }
}