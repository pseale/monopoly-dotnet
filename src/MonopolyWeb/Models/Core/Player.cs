using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonopolyWeb.Models.Core
{
  public class Player
  {
    public Player() { } //EF requires?
    public Player(string playerName, Totem totem, bool isHuman, int index)
    {
      PlayerName = playerName;
      Totem = totem;
      IsHuman = isHuman;
      Index = index;

      Cash = 1500;
      Location = Locations.Go;
      Holdings = new List<Property>();
    }

    public Guid GameId { get; set; } //required for EF
    public Game Game { get; set; } //required for EF
    public string PlayerName { get; private set; }
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public int Index { get; private set; } //starts at 1
    public bool IsHuman { get; private set; }
    public Totem Totem { get; private set; }

    public int Cash { get; private set; }

    public virtual List<Property> Holdings { get; set; } //required public and virtual for EF

    public Location Location { get; set; }
    public bool PassesGoOnNextRoll { get; set; }

    public void PayRentTo(Player propertyOwner)
    {
      var rent = Location.Property.Rent;
      Cash -= rent;
      propertyOwner.ReceiveRent(rent);
    }

    private void ReceiveRent(int rent)
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
      Holdings.Add(property);
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