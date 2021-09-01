using FluentAssertions;
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
        LoginPage _loginPage = new LoginPage();
        LandingPage _landingPage = new LandingPage();
        CSMDeviceDetailsPage _csmDeviceDetailsPage = new CSMDeviceDetailsPage();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        readonly MainPage _mainPage = new MainPage();


        [Given(@"user is on CSM Log Files page")]
        public void GivenUserIsOnCSMLogFilesPage()
        {
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest2Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CSMDeviceName);
            Thread.Sleep(1000);
            //select the row according to the data
            _mainPage.SearchSerialNumberAndClick("110010000025");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CSMDeviceDetailsPage.Locators.LogsTabID)));
            _csmDeviceDetailsPage.LogsTab.Click();
        }
        
        [Given(@"Received, Pending or Executing message is not displayed")]
        public void GivenPendingOrExecutingMessageIsNotDisplayed()
        {
            _csmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility().Should().BeFalse("Receiving,Pending or Executing message is displayed");
        }
        
        [When(@"user clicks Request Logs button")]
        public void WhenUserClicksRequestLogsButton()
        {
            _csmDeviceDetailsPage.LogsRequestButton.Click();
        }
        
        [Then(@"Received, Pending or Executing message is displayed")]
        public void ThenPendingOrExecutingMessageIsDisplayed()
        {
            _csmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility().Should().BeTrue("Pending or Executing message is not displayed");
            _csmDeviceDetailsPage.LogsPendingMessage.LogFilesRequestStatusMessageVerification().Should().BeTrue("Log files request message is not matching the expected.");
        }
        
        [Then(@"Request Logs button is disabled")]
        public void ThenRequestLogsButtonIsDisabled()
        {
           _csmDeviceDetailsPage.LogsRequestButton.GetAttribute("class").Should().BeEquivalentTo(CSMDeviceDetailsPage.ExpectedValues.RequestLogButtonDisabledClassName, "Request Logs button is not disabled");
        }

        [Given(@"Received, Pending or Executing message is displayed")]
        public void GivenPendingOrExecutingMessageIsDisplayed()
        {
            _csmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility().Should().BeTrue("Pending or Executing message is not displayed");
            _csmDeviceDetailsPage.LogsPendingMessage.LogFilesRequestStatusMessageVerification().Should().BeTrue("Log files request message is not matching the expected.");
        }

    }
}
