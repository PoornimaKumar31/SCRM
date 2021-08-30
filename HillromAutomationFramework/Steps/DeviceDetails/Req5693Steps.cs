using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5693")]
    class Req5693Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        CVSMDeviceDetailsPage cvsmDeviceDetailsPage = new CVSMDeviceDetailsPage();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        readonly MainPage mainPage = new MainPage();

        [Given(@"user is on CVSM Log Files page")]
        public void GivenUserIsOnCVSMLogFilesPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CVSMDeviceName);
            //select the row according to the data 
            mainPage.SearchSerialNumberAndClick("100020000004");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CVSMDeviceDetailsPage.Locators.LogsTabID)));
            cvsmDeviceDetailsPage.LogsTab.Click();
        }

        [Given(@"Received, Pending or Executing message is not displayed")]
        public void GivenPendingOrExecutingMessageIsNotDisplayed()
        {
            Assert.AreEqual(false,cvsmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility(), "Received, Pending or Executing message is displayed.");
        }

        [When(@"user clicks Request Logs button")]
        public void WhenUserClicksRequestLogsButton()
        {
            cvsmDeviceDetailsPage.LogsRequestButton.Click();
        }

        [Then(@"Received, Pending or Executing message is displayed")]
        public void ThenPendingOrExecutingMessageIsDisplayed()
        {
            Assert.AreEqual(true,cvsmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility(), "Received, Pending or Executing message is not displayed");
            Assert.AreEqual(true, cvsmDeviceDetailsPage.LogsPendingMessage.LogFilesRequestStatusMessageVerification(), "Displayed message is not as expected.");
        }

        [Given(@"Received, Pending or Executing message is displayed")]
        public void GivenPendingOrExecutingMessageIsDisplayed()
        {
            Assert.AreEqual(true,cvsmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility(), "Received, Pending or Executing message is not displayed ");
            Assert.AreEqual(true, cvsmDeviceDetailsPage.LogsPendingMessage.LogFilesRequestStatusMessageVerification(), "Displayed message is not as expected.");
        }

        [Then(@"Request Logs button is disabled")]
        public void ThenRequestLogsButtonIsDisabled()
        {
            Assert.AreEqual(CVSMDeviceDetailsPage.ExpectedValues.RequestLogButtonDisabledClassName,cvsmDeviceDetailsPage.LogsRequestButton.GetAttribute("class"), "Request Logs button is not disabled");
        }

    }
}
