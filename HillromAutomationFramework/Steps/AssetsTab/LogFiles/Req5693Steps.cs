using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.AssetsTab.LogFiles
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5693")]
    class Req5693Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly CVSMDeviceDetailsPage _cvsmDeviceDetailsPage;
        private readonly MainPage _mainPage;

        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public Req5693Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            _driver = driver;

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
            _cvsmDeviceDetailsPage = new CVSMDeviceDetailsPage(driver);
        }

        [Given(@"user is on CVSM Log Files page")]
        public void GivenUserIsOnCVSMLogFilesPage()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CVSMDeviceName);
            
            //select the row according to the data 
            _mainPage.SearchSerialNumberAndClick("100020000004");
            _wait.Until(ExplicitWait.ElementExists(By.Id(CVSMDeviceDetailsPage.Locators.LogsTabID)));
            _cvsmDeviceDetailsPage.LogsTab.Click();
        }

        [Given(@"Received, Pending or Executing message is not displayed")]
        public void GivenPendingOrExecutingMessageIsNotDisplayed()
        {
            _cvsmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility().Should().BeFalse("Received, Pending or Executing message is displayed.");
        }

        [When(@"user clicks Request Logs button")]
        public void WhenUserClicksRequestLogsButton()
        {
            _cvsmDeviceDetailsPage.LogsRequestButton.Click();
        }

        [Then(@"Received, Pending or Executing message is displayed")]
        public void ThenPendingOrExecutingMessageIsDisplayed()
        {
            _cvsmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility().Should().BeTrue("Received, Pending or Executing message is not displayed");
            _cvsmDeviceDetailsPage.LogsPendingMessage.LogFilesRequestStatusMessageVerification().Should().BeTrue("Displayed message is not as expected.");
        }

        [Given(@"Received, Pending or Executing message is displayed")]
        public void GivenPendingOrExecutingMessageIsDisplayed()
        {
            _cvsmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility().Should().BeTrue("Received, Pending or Executing message is not displayed ");
            _cvsmDeviceDetailsPage.LogsPendingMessage.LogFilesRequestStatusMessageVerification().Should().BeTrue("Displayed message is not as expected.");
        }

        [Then(@"Request Logs button is disabled")]
        public void ThenRequestLogsButtonIsDisabled()
        {
            _cvsmDeviceDetailsPage.LogsRequestButton.GetAttribute("class").Should().BeEquivalentTo(CVSMDeviceDetailsPage.ExpectedValues.RequestLogButtonDisabledClassName, "Request Logs button is not disabled");
        }

    }
}
