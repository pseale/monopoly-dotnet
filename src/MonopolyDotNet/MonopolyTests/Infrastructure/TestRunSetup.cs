using Coypu;
using NUnit.Framework;

namespace MonopolyTests.Infrastructure
{
  [SetUpFixture]
  public class TestRunSetup
  {
    private static BrowserSession _browserSession;
    public static BrowserSession BrowserSession
    {
      get { return _browserSession; }
    }

    [SetUp]
    public void TestFixtureSetUp()
    {
      IisExpressInstance.Start("MonopolyWeb", 19456);
      _browserSession = new BrowserSession(new SessionConfiguration() { Port = IisExpressInstance.Port });
    }

    [TearDown]
    public void TestFixtureTearDown()
    {
      IisExpressInstance.Stop();

      if (_browserSession != null)
        _browserSession.Dispose();
    }
  }
}