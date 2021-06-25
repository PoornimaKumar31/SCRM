using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class SupportedBrowserListSteps
    {
        readonly LoginPage loginPage = new LoginPage();

        [When(@"user clicks Supported Browsers")]
        public void WhenUserClicksSupportedBrowsers()
        {
            loginPage.SupportedBrowsersLink.Clicks();
        }

        [Then(@"Supported Browsers dialog is displayed")]
        public void ThenSupportedBrowsersDialogIsDisplayed()
        {
            Assert.IsTrue(loginPage.SupportedBrowserPopup.Displayed);
            String SupportedBrowserList = loginPage.SupportedBrowserPopup.Text;
            // Microsoft Edge
            Assert.IsTrue(SupportedBrowserList.Contains(LoginPage.ExpectedValues.SupportedBrowserEdge));
            // Google Chrome
            Assert.IsTrue(SupportedBrowserList.Contains(LoginPage.ExpectedValues.SupportedBrowserChrome));
            //Apple Safari
            Assert.IsTrue(SupportedBrowserList.Contains(LoginPage.ExpectedValues.SupportedBrowserAppleSafari));
        }


        [Given(@"user is on Supported Browsers dialog")]
        public void GivenUserIsOnSupportedBrowsersDialog()
        {
            PropertyClass.Driver.Navigate().GoToUrl(PropertyClass.BaseURL);
            // Explicit wait-> Wait till logo is displayed
            WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(LoginPage.Locator.LogoXPath)));
            loginPage.SupportedBrowsersLink.Clicks();
            Assert.IsTrue(loginPage.SupportedBrowserPopup.Displayed);
        }

        [When(@"user clicks Close button")]
        public void WhenUserClicksCloseButton()
        {
            loginPage.SupportedBrowserclosebutton.Clicks();
        }

        [Then(@"Supported Browsers dialog is closed")]
        public void ThenSupportedBrowsersDialogIsClosed()
        {
            Assert.IsFalse(loginPage.SupportedBrowserclosebutton.Displayed);
        }

    }
}
