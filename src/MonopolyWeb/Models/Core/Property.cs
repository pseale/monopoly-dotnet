namespace MonopolyWeb.Models.Core
{
  public class Property
  {
    public Property(string name, int salePrice)
    {
      Name = name;
      SalePrice = salePrice;
    }

    public string Name { get; set; }
    public int SalePrice { get; set; }
    public int Rent { get { return SalePrice/10; } }

    protected bool Equals(Property other)
    {
      return string.Equals(Name, other.Name) && SalePrice == other.SalePrice;
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ SalePrice;
      }
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((Property) obj);
    }
  }
}