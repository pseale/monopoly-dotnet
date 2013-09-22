using System.Collections.Generic;

namespace MonopolyWeb.Models.Core
{
  public class Player
  {
    public Player(string name, Totem totem, bool isHuman, int index)
    {
      Name = name;
      Totem = totem;
      IsHuman = isHuman;
      Index = index;

      Cash = 1500;
      Location = Locations.Go;
      Holdings = new List<Property>();
    }

    public string Name { get; private set; }
    public int Index { get; private set; } //starts at 1
    public bool IsHuman { get; private set; }
    public Totem Totem { get; private set; }

    public int Cash { get; set; }
    public List<Property> Holdings { get; private set; }
    public Location Location { get; set; }
    public bool PassesGoOnNextRoll { get; set; }
  }
}