using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.SupportingCode;
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
        readonly LoginPage loginPage = new LoginPage();
        readonly MainPage mainPage = new MainPage();

        [Given(@"user is on Main page")]
        public void GivenUserIsOnMainPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithOutRollUpPage);
            WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.AssetsTabID)));
        }

        [When(@"user clicks Global Service Center")]
        public void WhenUserClicksGlobalServiceCenter()
        {
            mainPage.GlobalServiceCenter.Click();
        }

        [Then(@"Global Service Center page is displayed")]
        public void ThenGlobalServiceCenterPageIsDisplayed()
        {
            var popup = PropertyClass.Driver.WindowHandles[1]; // handler for the new tab
            // Check if new tab is opened
            Assert.IsTrue(!string.IsNullOrEmpty(popup));
            //Get the URL of new tab.
            string ActualPageURL = PropertyClass.Driver.SwitchTo().Window(popup).Url;
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
            var popup = PropertyClass.Driver.WindowHandles[1]; // handler for the new tab
            // Check if new tab is opened
            Assert.IsTrue(!string.IsNullOrEmpty(popup));
            //Get the URL of new tab.
            string ActualPageURL = PropertyClass.Driver.SwitchTo().Window(popup).Url;
            Assert.AreEqual(MainPage.ExpectedValues.ContactUsURL, ActualPageURL, "URL is not matching");
        }

        [Scope(Tag = "TestCaseID_8947")]
        [Then(@"Terms of use page is displayed")]
        public void ThenTermsAndConditionsPageIsDisplayed()
        {
            var popup = PropertyClass.Driver.WindowHandles[1]; // handler for the new tab
            // Check if new tab is opened
            Assert.IsTrue(!string.IsNullOrEmpty(popup));
            //Get the URL of new tab.
            string ActualPageURL = PropertyClass.Driver.SwitchTo().Window(popup).Url;
            Assert.AreEqual(MainPage.ExpectedValues.TermsAndConditonsURL, ActualPageURL, "URL is not matching");
        }

        
        [Then(@"Privacy Policy page is displayed"), Scope(Tag = "TestCaseID_8949")]
        public void ThenPrivacyPolicyPageIsDisplayed()
        {
            var popup = PropertyClass.Driver.WindowHandles[1]; // handler for the new tab
            // Check if new tab is opened
            Assert.IsTrue(!string.IsNullOrEmpty(popup));
            //Get the URL of new tab.
            string ActualPageURL = PropertyClass.Driver.SwitchTo().Window(popup).Url;
            Assert.AreEqual(MainPage.ExpectedValues.PrivacyPolicyURL, ActualPageURL,"URL is not matching");
        }



    }
}
