﻿using Coypu;
using MonopolyTests.Infrastructure;
using NUnit.Framework;

//moved this to base folder to make it easier on Intellisense. Not a joke, I really did it because of intellisense.
namespace MonopolyTests
{
  public class WebTestBase
  {
// ReSharper disable once InconsistentNaming
    protected static BrowserSession browser
    {
      get { return SeleniumHelper.BrowserSession; }
    }

    // ReSharper disable once InconsistentNaming
    protected static string baseUrl
    {
      get { return IisExpressInstance.BaseUrl; }
    }
  }
}