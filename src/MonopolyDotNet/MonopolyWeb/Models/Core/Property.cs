namespace MonopolyWeb.Models.Core
{
  public class Property
  {
    public Property()
    {
      SalePrice = 100;
    }
    public string Name { get; set; }
    public int SalePrice { get; set; }
    public int Rent { get { return SalePrice/10; } }
  }
}