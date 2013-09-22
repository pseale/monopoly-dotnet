namespace MonopolyWeb.Models.Core
{
  public class Location
  {
    public Location(int index)
    {
      Index = index;
    }

    public Location(int index, Property property)
    {
      Index = index;
      Property = property;
    }

    public int Index { get; private set; }
    public Property Property { get; private set; }

    public bool HasAProperty
    {
      get { return Property != null; }
    }
  }
}