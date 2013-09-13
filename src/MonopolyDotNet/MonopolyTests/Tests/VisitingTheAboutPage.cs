using NUnit.Framework;

namespace MonopolyTests.Tests
{
  [TestFixture]
  public class VisitingTheAboutPage : WebTestBase
  {
    [Test]
    public void When_visiting_the_about_page__should_load_something_or_anything()
    {
      browser.Visit("/About");

      Assert.IsTrue(browser.HasContent("About"));
    }
  }
}