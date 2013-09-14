namespace MonopolyWeb.Models.Core
{
  public class Location
  {
    public int Index { get; set; }
    public bool HasAProperty { get; set; }
    public Property Property { get; set; }
  }
}