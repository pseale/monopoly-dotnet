using MonopolyWeb.Models.Core;

namespace MonopolyWeb.Models.Services
{
  public static class RollService
  {
    public static void RollForPlayer(Game game, Player player)
    {
      const int boardSize = 40;
      int newLocation = player.Location.Index + Dice.Roll();

      if (newLocation > boardSize)
      {
        PassGo(player);
      }
      else if (newLocation == boardSize)
      {
        player.PassesGoOnNextRoll = true;
      }
      else if (player.PassesGoOnNextRoll)
      {
        player.PassesGoOnNextRoll = false;
        PassGo(player);
      }

      newLocation %= boardSize;
      player.Location = Locations.All[newLocation];

      RentService.DoRentTransaction(game, player);
    }

    public static void PassGo(Player player)
    {
      player.Cash += 200;
    }
  }
}