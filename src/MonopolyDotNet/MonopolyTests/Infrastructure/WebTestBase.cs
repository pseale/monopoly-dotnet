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

    protected BrowserSession Session()
    {
      return TestRunSetup.BrowserSession;
    }
  }
}