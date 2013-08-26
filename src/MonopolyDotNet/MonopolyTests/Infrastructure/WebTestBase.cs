using Coypu;
using NUnit.Framework;

namespace MonopolyTests.Infrastructure
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
      get { return TestRunSetup.BrowserSession; }
    }
  }
}