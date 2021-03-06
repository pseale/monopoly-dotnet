﻿namespace MonopolyWeb.Models.ViewModels
{
  public class LocationViewModel
  {
    public LocationViewModel(int offsetFromLeft, int offsetFromTop)
    {
      OffsetFromLeft = offsetFromLeft;
      OffsetFromTop = offsetFromTop;
    }

    //assumes board is 720px total (minus a ~10px border/buffer on every side), and tokens are 30px
    public int OffsetFromLeft { get; set; }
    public int OffsetFromTop { get; set; }
  }
}