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
      var locations = TokenCoordinatesHelper.GetLocationFromBoard(game.GetTotemLocations());
      gameStatus.Player1OffsetFromLeft = (locations[0].OffsetFromLeft).ToString();
      gameStatus.Player1OffsetFromTop = (locations[0].OffsetFromTop).ToString();
      gameStatus.Player2OffsetFromLeft = (locations[1].OffsetFromLeft).ToString();
      gameStatus.Player2OffsetFromTop = (locations[1].OffsetFromTop).ToString();
      gameStatus.Player3OffsetFromLeft = (locations[2].OffsetFromLeft).ToString();
      gameStatus.Player3OffsetFromTop = (locations[2].OffsetFromTop).ToString();
      gameStatus.Player4OffsetFromLeft = (locations[3].OffsetFromLeft).ToString();
      gameStatus.Player4OffsetFromTop = (locations[3].OffsetFromTop).ToString();

      var cash = game.GetCash();
      gameStatus.Player1Cash = "$" + cash[0];
      gameStatus.Player2Cash = "$" + cash[1];
      gameStatus.Player3Cash = "$" + cash[2];
      gameStatus.Player4Cash = "$" + cash[3];

      var holdings = game.GetHoldings();
      gameStatus.Player1Holdings = Adapt(holdings[0]);
      gameStatus.Player2Holdings = Adapt(holdings[1]);
      gameStatus.Player3Holdings = Adapt(holdings[2]);
      gameStatus.Player4Holdings = Adapt(holdings[3]);
      return gameStatus;
    }

    private static List<SelectListItem> Adapt(List<string> list)
    {
      var adaptedList = new List<SelectListItem>();
      foreach (var item in list)
      {
        var selectListItem = new SelectListItem();
        selectListItem.Text = item;
        selectListItem.Value = item;
        adaptedList.Add(selectListItem);
      }

      return adaptedList;
    }
  }
}