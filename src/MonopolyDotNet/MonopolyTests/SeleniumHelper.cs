using Coypu;

namespace MonopolyTests
{
  public static class SeleniumHelper
  {
    private static BrowserSession _browserSession;
    public static BrowserSession BrowserSession
    {
      get { return _browserSession; }
    }

    public static void Start()
    {
      _browserSession = new BrowserSession(new SessionConfiguration() { Port = IisExpressInstance.Port });
    }

    public static void Stop()
    {
      if (_browserSession == null) return;
      
      _browserSession.Dispose();
    }
  }
}