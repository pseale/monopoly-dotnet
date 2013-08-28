using NUnit.Framework;

namespace MonopolyTests
{
  //fun fact: NUnit doesn't see this file if I put it in a subfolder.
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