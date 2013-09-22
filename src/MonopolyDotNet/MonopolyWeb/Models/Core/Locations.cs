namespace MonopolyWeb.Models.Core
{
  public static class Locations
  {
    static Locations()
    {
      All = new Location[40];

      var i = 0;
      AddEmptyLocation(i++);
      AddProperty(i++, "Mediterranean", 60);
      AddEmptyLocation(i++);
      AddProperty(i++, "Baltic", 60);
      AddEmptyLocation(i++);
      AddEmptyLocation(i++);
      AddProperty(i++, "Oriental", 80);
      AddEmptyLocation(i++);
      AddProperty(i++, "Vermont", 80);
      AddProperty(i++, "Connecticut", 100);
      AddEmptyLocation(i++);
      AddProperty(i++, "St. Charles Place", 140);
      AddEmptyLocation(i++);
      AddProperty(i++, "States", 140);
      AddProperty(i++, "Virginia", 160);
      AddEmptyLocation(i++);
      AddProperty(i++, "St. James Place", 180);
      AddEmptyLocation(i++);
      AddProperty(i++, "Tennessee", 180);
      AddProperty(i++, "New York", 200);
      AddEmptyLocation(i++);
      AddProperty(i++, "Kentucky", 220);
      AddEmptyLocation(i++);
      AddProperty(i++, "Indiana", 220);
      AddProperty(i++, "Illinois", 240);
      AddEmptyLocation(i++);
      AddProperty(i++, "Atlantic", 260);
      AddProperty(i++, "Ventnor", 260);
      AddEmptyLocation(i++);
      AddProperty(i++, "Marvin Gardens", 280);
      AddEmptyLocation(i++);
      AddProperty(i++, "Pacific", 300);
      AddProperty(i++, "North Carolina", 300);
      AddEmptyLocation(i++);
      AddProperty(i++, "Pennsylvania", 320);
      AddEmptyLocation(i++);
      AddEmptyLocation(i++);
      AddProperty(i++, "Park Place", 350);
      AddEmptyLocation(i++);
      AddProperty(i++, "Boardwalk", 400);

      Go = All[0];
    }

    private static void AddProperty(int locationIndex, string propertyName, int salePrice)
    {
      var location = new Location(locationIndex, new Property(propertyName, salePrice));
     All[locationIndex] = location;
    }

    private static void AddEmptyLocation(int locationIndex)
    {
      All[locationIndex] = new Location(locationIndex);
    }

    public static readonly Location[] All;
    public static readonly Location Go;
  }
}