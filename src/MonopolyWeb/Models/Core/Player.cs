﻿using System.Collections.Generic;

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
      _holdings = new List<Property>();
    }

    public string Name { get; private set; }
    public int Index { get; private set; } //starts at 1
    public bool IsHuman { get; private set; }
    public Totem Totem { get; private set; }

    public int Cash { get; private set; }

    private readonly List<Property> _holdings;
    public IEnumerable<Property> Holdings
    {
      get { return _holdings; }
    }

    public Location Location { get; set; }
    public bool PassesGoOnNextRoll { get; set; }

    public void PayRentTo(Player propertyOwner)
    {
      var rent = Location.Property.Rent;
      Cash -= rent;
      propertyOwner.ReceiveRent(rent);
    }

    public void ReceiveRent(int rent)
    {
      Cash += rent;
    }

    public void PassGo()
    {
      Cash += 200;
    }

    public void BuyProperty()
    {
      var property = Location.Property;
      _holdings.Add(property);
      Cash -= property.SalePrice;
    }

    public bool CanAffordProperty()
    {
      if (!Location.HasAProperty)
        return false;

      if (Cash < Location.Property.SalePrice)
        return false;

      return true;
    }

    protected bool Equals(Player other)
    {
      return Index == other.Index;
    }

    public override int GetHashCode()
    {
      return Index;
    }
    
    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((Player) obj);
    }
  }
}