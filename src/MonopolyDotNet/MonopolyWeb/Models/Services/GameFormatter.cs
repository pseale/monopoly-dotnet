using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.ViewModels;

namespace MonopolyWeb.Models.Services
{
  public static class GameFormatter
  {
    public static GameStatus Flatten(Game game)
    {
      var gameStatus = new GameStatus();
      int playerIndex = 1;
      gameStatus.PlayerStatuses.AddRange(
        game.GetPlayers().Select(player => Convert(player, playerIndex++)));

      return gameStatus;
    }

    private static PlayerStatus Convert(Player player, int playerIndex)
    {
      var playerStatus = new PlayerStatus();
      playerStatus.PlayerNumber = playerIndex;
      playerStatus.Cash = "$" + player.Cash;
      playerStatus.Holdings = Convert(player.Holdings);
      var coordinates = TokenCoordinatesHelper.GetLocationOnBoard(player.Location, playerIndex);
      playerStatus.OffsetFromLeft = coordinates.OffsetFromLeft.ToString();
      playerStatus.OffsetFromTop = coordinates.OffsetFromTop.ToString();
      return playerStatus;
    }

    private static List<SelectListItem> Convert(List<Property> list)
    {
      var adaptedList = new List<SelectListItem>();
      foreach (var item in list)
      {
        var selectListItem = new SelectListItem();
        selectListItem.Text = item.Name;
        selectListItem.Value = item.Name;
        adaptedList.Add(selectListItem);
      }

      return adaptedList;
    }
  }
}