using System;
using MonopolyWeb.Models.Core;
using MonopolyWeb.Models.ViewModels;

namespace MonopolyWeb.Models.Converters
{
  public class NewGameConverter
  {
    public static NewGameData Convert(NewGameInput newGameInput)
    {
      var newGameData = new NewGameData(newGameInput.Name, newGameInput.Totem.Value, newGameInput.Opponent1, newGameInput.Opponent2,
        newGameInput.Opponent3);

      return newGameData;
    }
  }
}