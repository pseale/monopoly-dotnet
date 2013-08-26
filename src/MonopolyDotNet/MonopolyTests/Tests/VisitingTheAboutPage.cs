using NUnit.Framework;

namespace MonopolyTests.Tests
{
  [TestFixture]
  public class VisitingTheAboutPage : WebTestBase
  {
    [Test]
    public void When_visiting_the_home_page__should_have_link_to_About_page()
    {
      browser.Visit("/");

      var link = browser.FindLink("About");

      Assert.IsTrue(link.Exists());
    }

    [Test]
    public void When_visiting_the_about_page__should_load_something_or_anything()
    {
      browser.Visit("/About");

      Assert.IsTrue(browser.HasContent("About"));
    }
  }
}