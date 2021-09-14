using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.AssetsTab
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5898")]
    public class Req5898Steps
    {
        private readonly LoginPage loginPage;
        private readonly MainPage mainPage;

        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverWait _wait;

        public Req5898Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            loginPage = new LoginPage(driver);
            mainPage = new MainPage(driver);
        }

        [Given(@"user is on Main page")]
        public void GivenUserIsOnMainPage()
        {
            loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithOutRollUpPage);
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.AssetsTabID)));
        }

        [When(@"user clicks Global Service Center")]
        public void WhenUserClicksGlobalServiceCenter()
        {
            mainPage.GlobalServiceCenter.Click();
        }

        [Then(@"Global Service Center page is displayed")]
        public void ThenGlobalServiceCenterPageIsDisplayed()
        {
            int windowCount = _driver.WindowHandles.Count;

            // checking if new tab was opened
            (windowCount).Should().BeGreaterThan(1, because: "Link should be pened in a new window");

            var popup = _driver.WindowHandles[1]; // handler for the new tab
            // Check if new tab is opened
            Assert.IsTrue(!string.IsNullOrEmpty(popup));
            //Get the URL of new tab.
            string ActualPageURL = _driver.SwitchTo().Window(popup).Url;
            Assert.AreEqual(MainPage.ExpectedValues.GlobalServiceCenterURL, ActualPageURL, "URL is not matching");
        }

        [When(@"user clicks Contact Us")]
        public void WhenUserClicksContactUs()
        {
            mainPage.ContactUs.Click();
        }

        [Then(@"Contact Us page is displayed")]
        public void ThenContactUsPageIsDisplayed()
        {
            int windowCount = _driver.WindowHandles.Count;

            // checking if new tab was opened
            (windowCount).Should().BeGreaterThan(1, because: "Link should be pened in a new window");

            var popup = _driver.WindowHandles[1]; // handler for the new tab
            // Check if new tab is opened
            Assert.IsTrue(!string.IsNullOrEmpty(popup));
            //Get the URL of new tab.
            string ActualPageURL = _driver.SwitchTo().Window(popup).Url;
            Assert.AreEqual(MainPage.ExpectedValues.ContactUsURL, ActualPageURL, "URL is not matching");
        }

        [Scope(Tag = "TestCaseID_8947")]
        [Then(@"Terms of use page is displayed")]
        public void ThenTermsAndConditionsPageIsDisplayed()
        {
            int windowCount = _driver.WindowHandles.Count;

            // checking if new tab was opened
            (windowCount).Should().BeGreaterThan(1, because: "Link should be pened in a new window");

            var popup = _driver.WindowHandles[1]; // handler for the new tab
            // Check if new tab is opened
            Assert.IsTrue(!string.IsNullOrEmpty(popup));
            //Get the URL of new tab.
            string ActualPageURL = _driver.SwitchTo().Window(popup).Url;
            Assert.AreEqual(MainPage.ExpectedValues.TermsAndConditonsURL, ActualPageURL, "URL is not matching");
        }

        
        [Then(@"Privacy Policy page is displayed"), Scope(Tag = "TestCaseID_8949")]
        public void ThenPrivacyPolicyPageIsDisplayed()
        {
            int windowCount = _driver.WindowHandles.Count;

            // checking if new tab was opened
            (windowCount).Should().BeGreaterThan(1, because: "Link should be pened in a new window");

            var popup = _driver.WindowHandles[1]; // handler for the new tab
            // Check if new tab is opened
            Assert.IsTrue(!string.IsNullOrEmpty(popup));
            //Get the URL of new tab.
            string ActualPageURL = _driver.SwitchTo().Window(popup).Url;
            Assert.AreEqual(MainPage.ExpectedValues.PrivacyPolicyURL, ActualPageURL,"URL is not matching");
        }



    }
}
