using System;
using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.ViewModels;

namespace MonopolyWeb.Models.Converters
{
  public class NewGameConverter
  {
    public static NewGameData Convert(NewGameInput newGameInput)
    {
      var newGameData = new NewGameData();
      newGameData.PlayerName = newGameInput.Name;
//      newGameData.PlayerTotem = newGameInput.Totem;
      newGameData.Opponent1Name = newGameInput.Second;
      newGameData.Opponent2Name = newGameInput.Third;
      newGameData.Opponent3Name = newGameInput.Fourth;

      return newGameData;
    }
  }
}