using Coypu;
using NUnit.Framework;

namespace MonopolyTests
{
  [SetUpFixture]
  public class TestRunSetup
  {
    [SetUp]
    public void TestFixtureSetUp()
    {
      IisExpressInstance.Start("MonopolyWeb", 19456);
      SeleniumHelper.Start();
    }

    [TearDown]
    public void TestFixtureTearDown()
    {
      SeleniumHelper.Stop();
      IisExpressInstance.Stop();
    }
  }
}