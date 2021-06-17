using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using TechTalk.SpecFlow;

namespace Sample.Steps
{
    [Binding]
    //bhag 
    public sealed class GoogleStepDefinitions
    {
        IWebDriver driver;
        [Given(@"user launched chrome browser")]
        public void GivenUserLaunchedChromeBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            
        }

        [Given(@"navigate to google website")]
        public void GivenNavigateToGoogleWebsite()
        {
            driver.Navigate().GoToUrl("https://www.google.com/");
        }

        [When(@"user search for hello")]
        public void WhenUserSearchForHello()
        {
            
            driver.FindElement(By.Name("q")).SendKeys("Hello");
            driver.FindElement(By.Name("q")).Submit();


        }

        [Then(@"user will see result")]
        public void ThenUserWillSeeResult()
        {
            string expected = "Hello - Google Search";
            string actual = driver.Title;
            Assert.AreEqual(actual, expected);
        }

        [Then(@"user closes the browser")]
        public void ThenUserClosesTheBrowser()
        {
            driver.Close();
        }


    }
}
