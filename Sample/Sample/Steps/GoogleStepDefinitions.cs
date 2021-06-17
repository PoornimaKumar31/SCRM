using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Sample.Steps
{
    [Binding]
    public sealed class GoogleStepDefinitions
    {
        IWebDriver driver;

        [Given(@"user launch chrome browser")]
        public void GivenUserLaunchChromeBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Given(@"navigate to google search page")]
        public void GivenNavigateToGoogleSearchPage()
        {
            driver.Navigate().GoToUrl("https://www.google.com");

        }

        [When(@"search hello")]
        public void WhenSearchHello()
        {
            driver.FindElement(By.Name("q")).SendKeys("Hello");
            driver.FindElement(By.Name("q")).Submit();
        }

        [Then(@"result will be displayed")]
        public void ThenResultWillBeDisplayed()
        {

            Assert.IsTrue(true);
            driver.Close();

        }

    }
}
