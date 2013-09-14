﻿using System.Collections.Generic;
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
      var gameStatusViewModel = new GameStatusViewModel();
      
      int playerIndex = 1;
      var gameStatus = game.GetCurrentGameStatus();
      gameStatusViewModel.PlayerStatuses.AddRange(gameStatus.Players.Select(player => Convert(player, playerIndex++)));
      
      gameStatusViewModel.CanBuyProperty = gameStatus.CanBuyProperty;
      gameStatusViewModel.PropertySalePrice = CashHelper.FormatAsCash(gameStatus.PropertySalePrice);

      return gameStatusViewModel;
    }

    private static PlayerStatusViewModel Convert(Player player, int playerIndex)
    {
      var playerStatus = new PlayerStatusViewModel();
      playerStatus.PlayerNumber = playerIndex;
      playerStatus.Name = player.Name;
      playerStatus.IsHuman = player.IsHuman;
      playerStatus.Cash = CashHelper.FormatAsCash(player.Cash);
      playerStatus.Holdings = Convert(player.Holdings);
      var coordinates = TokenCoordinatesHelper.GetLocationOnBoard(player.Location.Index, playerIndex);
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