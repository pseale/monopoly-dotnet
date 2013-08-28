﻿using Coypu;
using NUnit.Framework;

//moved this to base folder to make it easier on Intellisense. Not a joke, I really did it because of intellisense.
namespace MonopolyTests
{
  [TestFixture]
  public class WebTestBase
  {
    [SetUp]
    public void WebTestBaseSetUp()
    {
    }

    [TearDown]
    public void WebTestBaseTearDown()
    {
      
    }

// ReSharper disable once InconsistentNaming
    protected static BrowserSession browser
    {
      get { return SeleniumHelper.BrowserSession; }
    }
  }
}