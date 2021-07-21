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
    [Binding,Scope(Tag = "SoftwareRequirementID_5899")]
    public class Req5899Steps
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
            Assert.AreEqual(loginPage.SupportedBrowserPopup.Displayed,true,"Supported browser dialog box is not displayed");
            string SupportedBrowserList = loginPage.SupportedBrowserPopup.Text;
            // Microsoft Edge
            Assert.AreEqual(SupportedBrowserList.Contains(LoginPage.ExpectedValues.SupportedBrowserEdge),true,"Microsoft Edge Supported Browser text does not match with the expected value");
            // Google Chrome
            Assert.AreEqual(SupportedBrowserList.Contains(LoginPage.ExpectedValues.SupportedBrowserChrome),true, "Google Chrome Supported Browser text does not match with the expected value");
            //Apple Safari
            Assert.AreEqual(SupportedBrowserList.Contains(LoginPage.ExpectedValues.SupportedBrowserAppleSafari),true, "Apple Safari Supported Browser text does not match with the expected value");
        }



        [Given(@"user is on Supported Browsers dialog")]
        public void GivenUserIsOnSupportedBrowsersDialog()
        {
            PropertyClass.Driver.Navigate().GoToUrl(PropertyClass.BaseURL);
            // Explicit wait-> Wait till logo is displayed
            WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(LoginPage.Locator.LogoID)));
            loginPage.SupportedBrowsersLink.Clicks();
            Assert.AreEqual(loginPage.SupportedBrowserPopup.Displayed,true,"Supported browser dialog ox is not displayed");
        }

        [When(@"user clicks close button")]
        public void WhenUserClicksCloseButton()
        {
            Thread.Sleep(5000);
            loginPage.SupportedBrowserclosebutton.Clicks();
        }

        [Then(@"Supported Browsers dialog is closed")]
        public void ThenSupportedBrowsersDialogIsClosed()
        {
            Assert.AreEqual(PropertyClass.Driver.PageSource.Contains(LoginPage.ExpectedValues.SupportedBrowserAppleSafari), false,"Supported browser dialog box is not closed");
        }

    }
}
