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
  }
}