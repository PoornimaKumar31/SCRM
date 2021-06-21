using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class SupportedBrowserListSteps
    {
        readonly LoginPage loginPage = new LoginPage();

        [When(@"user click on supported Browsers")]
        public void WhenUserClickOnSupportedBrowsers()
        {
            loginPage.SupportedBrowsersLink.Clicks();
        }
        
        [Then(@"popup is displayed with list of supported browsers")]
        public void ThenPopupIsDisplayedWithListOfSupportedBrowsers()
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
        
        [Then(@"click on close button")]
        public void ThenClickOnCloseButton()
        {
            loginPage.SupportedBrowserclosebutton.Clicks();
        }
    }
}
