using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5700")]
    public class Req5700Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        CSMDeviceDetailsPage csmDeviceDetailsPage = new CSMDeviceDetailsPage();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        readonly MainPage mainPage = new MainPage();


        [Given(@"user is on CSM Log Files page")]
        public void GivenUserIsOnCSMLogFilesPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest2Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CSMDeviceName);
            Thread.Sleep(1000);
            //select the row according to the data
            mainPage.SearchSerialNumberAndClick("110010000025");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CSMDeviceDetailsPage.Locators.LogsTabID)));
            csmDeviceDetailsPage.LogsTab.Click();
        }
        
        [Given(@"Received, Pending or Executing message is not displayed")]
        public void GivenPendingOrExecutingMessageIsNotDisplayed()
        {
            Assert.AreEqual(false,csmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility(), "Receiving,Pending or Executing message is displayed");
        }
        
        [When(@"user clicks Request Logs button")]
        public void WhenUserClicksRequestLogsButton()
        {
            csmDeviceDetailsPage.LogsRequestButton.Click();
        }
        
        [Then(@"Received, Pending or Executing message is displayed")]
        public void ThenPendingOrExecutingMessageIsDisplayed()
        {
            Assert.AreEqual(true,csmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility(), "Pending or Executing message is not displayed");
            Assert.AreEqual(true, csmDeviceDetailsPage.LogsPendingMessage.LogFilesRequestStatusMessageVerification(), "Log files request message is not matching the expected.");
        }
        
        [Then(@"Request Logs button is disabled")]
        public void ThenRequestLogsButtonIsDisabled()
        {
            Assert.AreEqual(CSMDeviceDetailsPage.ExpectedValues.RequestLogButtonDisabledClassName,csmDeviceDetailsPage.LogsRequestButton.GetAttribute("class"), "Request Logs button is not disabled");
        }

        [Given(@"Received, Pending or Executing message is displayed")]
        public void GivenPendingOrExecutingMessageIsDisplayed()
        {
            Assert.AreEqual(true,csmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility(), "Pending or Executing message is not displayed");
            Assert.AreEqual(true, csmDeviceDetailsPage.LogsPendingMessage.LogFilesRequestStatusMessageVerification(), "Log files request message is not matching the expected.");
        }

    }
}
