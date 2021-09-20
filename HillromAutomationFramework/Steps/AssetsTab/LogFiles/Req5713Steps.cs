using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AssetsTab;
using HillromAutomationFramework.PageObjects.AssetsTab.DeviceDetails;
using HillromAutomationFramework.PageObjects.AssetsTab.LogFiles;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.AssetsTab.LogFiles
{
    [Binding, Scope(Tag = "SoftwareRequirementID_5713")]
    class Req5713Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly LogFilesPage _logFilesPage;

        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverWait _wait;

        public Req5713Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
            _logFilesPage = new LogFilesPage(driver);
        }

        [Given(@"user is on RV700 Log Files page")]
        public void GivenUserIsOnRVLogFilesPage()
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.AssetTypeDropDown.SelectDDL(MainPageExpectedValue.RV700DeviceName);
            Thread.Sleep(1000);
            _mainPage.SearchSerialNumberAndClick(LogFilesPageExpectedValue.RV700RequestLogFileDeviceSerialNumber);
            _logFilesPage.LogsTab.ClickWebElement(_driver,"Logs tab");
        }

        [Given(@"Received, Pending or Executing message is not displayed")]
        public void GivenPendingOrExecutingMessageIsNotDisplayed()
        {
            _logFilesPage.LogsPendingMessage.GetElementVisibility().Should().BeFalse("Reciving,Pending or Executing message is displayed");
        }

        [When(@"user clicks Request Logs button")]
        public void WhenUserClicksRequestLogsButton()
        {
            _logFilesPage.RequestLogsButton.Click();
        }

        [Then(@"Received, Pending or Executing message is displayed")]
        public void ThenPendingOrExecutingMessageIsDisplayed()
        {
            _logFilesPage.LogsPendingMessage.GetElementVisibility().Should().BeTrue( "Reciving, Pending or Executing message is not displayed");
             _logFilesPage.LogsPendingMessage.LogFilesRequestStatusMessageVerification().Should().BeTrue( "Log files request status message is not matching the expected value.");
        }

        [Given(@"Received, Pending or Executing message is displayed")]
        public void GivenPendingOrExecutingMessageIsDisplayed()
        {
            _logFilesPage.LogsPendingMessage.GetElementVisibility().Should().BeTrue( "Pending or Executing message is not displayed");
             _logFilesPage.LogsPendingMessage.LogFilesRequestStatusMessageVerification().Should().BeTrue( "Log files request status message is not matching the expected value.");
        }

        [Then(@"Request Logs button is disabled")]
        public void ThenRequestLogsButtonIsDisabled()
        {
            _logFilesPage.RequestLogsButton.GetAttribute("class").Should().BeEquivalentTo(LogFilesPageExpectedValue.RequestLogButtonDisabledClassName, "Request Logs button is not disabled");
        }

    }
}
