using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonopolyWeb.Models.Core
{
  public class Location
  {
    public Location() { } //required for EF

    public Location(int index)
    {
      Index = index;
    }

    public Location(int index, Property property)
    {
      Index = index;
      Property = property;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public int Index { get; private set; }
    public Property Property { get; private set; }
     
    public bool HasAProperty
    {
      get { return Property != null; }
    }

    protected bool Equals(Location other)
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
      return Equals((Location) obj);
    }
  }
}