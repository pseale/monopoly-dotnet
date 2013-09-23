using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.Services;
using MonopolyWeb.Models.ViewModels;

namespace MonopolyWeb.Models.Converters
{
  public static class GameFormatter
  {
    public static GameStatusViewModel Flatten(Game game)
    {
      var vm = new GameStatusViewModel();
      
      var gameStatus = game.GetCurrentGameStatus();
      vm.PlayerStatuses.AddRange(gameStatus.Players.Select(player => Convert(player)).OrderBy(x=>x.PlayerNumber));
      vm.CanRoll = gameStatus.CanRoll;
      vm.CanBuyProperty = gameStatus.CanBuyProperty;
      vm.CanEndTurn = gameStatus.CanEndTurn;
      vm.PropertySalePrice = CashHelper.FormatAsCash(gameStatus.PropertySalePrice);

      return vm;
    }

    private static PlayerStatusViewModel Convert(Player player)
    {
      var vm = new PlayerStatusViewModel();
      vm.Name = player.PlayerName;
      vm.PlayerNumber = player.Index;
      vm.Icon = player.IsHuman ? "human_player.png" : "robot_scum.png";
      vm.TotemIcon = GetIconFor(player.Totem);
      vm.Cash = CashHelper.FormatAsCash(player.Cash);
      vm.Holdings = Convert(player.Holdings);
      var coordinates = TokenCoordinatesHelper.GetLocationOnBoard(player);
      vm.OffsetFromLeft = coordinates.OffsetFromLeft.ToString();
      vm.OffsetFromTop = coordinates.OffsetFromTop.ToString();
      return vm;
    }

    private static string GetIconFor(Totem totem)
    {
      return totem.ToString().ToLower() + ".png";
    }

    private static List<SelectListItem> Convert(IEnumerable<Property> list)
    {
      var convertedList = new List<SelectListItem>();
      foreach (var item in list.OrderBy(x=>x.SalePrice))
      {
        var selectListItem = new SelectListItem();
        selectListItem.Text = item.PropertyName;
        selectListItem.Value = item.PropertyName;
        convertedList.Add(selectListItem);
      }

      return convertedList;
    }
  }
}