namespace MonopolyWeb.Models.Core
{
  public static class Locations
  {
    static Locations()
    {
      All = new Location[40];

      var empty = new Location() { HasAProperty = false };

      var i = 0;
      All[i++] = empty;
      All[i++] = Property("Mediterranean", 60);
      All[i++] = empty;
      All[i++] = Property("Baltic", 60);
      All[i++] = empty;
      All[i++] = empty;
      All[i++] = Property("Oriental", 80);
      All[i++] = empty;
      All[i++] = Property("Vermont", 80);
      All[i++] = Property("Connecticut", 100);
      All[i++] = empty;
      All[i++] = Property("St. Charles Place", 140);
      All[i++] = empty;
      All[i++] = Property("States", 140);
      All[i++] = Property("Virginia", 160);
      All[i++] = empty;
      All[i++] = Property("St. James Place", 180);
      All[i++] = empty;
      All[i++] = Property("Tennessee", 180);
      All[i++] = Property("New York", 200);
      All[i++] = empty;
      All[i++] = Property("Kentucky", 220);
      All[i++] = empty;
      All[i++] = Property("Indiana", 220);
      All[i++] = Property("Illinois", 240);
      All[i++] = empty;
      All[i++] = Property("Atlantic", 260);
      All[i++] = Property("Ventnor", 260);
      All[i++] = empty;
      All[i++] = Property("Marvin Gardens", 280);
      All[i++] = empty;
      All[i++] = Property("Pacific", 300);
      All[i++] = Property("North Carolina", 300);
      All[i++] = empty;
      All[i++] = Property("Pennsylvania", 320);
      All[i++] = empty;
      All[i++] = empty;
      All[i++] = Property("Park Place", 350);
      All[i++] = empty;
      All[i++] = Property("Boardwalk", 400);
    }

    private static Location Property(string propertyName, int salePrice)
    {
      var location = new Location();
      location.HasAProperty = true;
      location.Property = new Property() {Name = propertyName, SalePrice = salePrice};
      return location;
    }

    public static readonly Location[] All;
  }
}