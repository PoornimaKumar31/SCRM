using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AssetsTab;
using HillromAutomationFramework.PageObjects.AssetsTab.LogFiles;
using HillromAutomationFramework.SupportingCode;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.AssetsTab.LogFiles
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5700")]
    public class Req5700Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly LogFilesPage _logFilesPage;

        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;


        public Req5700Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
            _logFilesPage = new LogFilesPage(driver);
        }

        [Given(@"user is on CSM Log Files page")]
        public void GivenUserIsOnCSMLogFilesPage()
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest2Title.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.AssetTypeDropDown.SelectDDL(MainPageExpectedValue.CSMDeviceName);
            Thread.Sleep(1000);

            //select the device according to the data
            _mainPage.SearchSerialNumberAndClick(LogFilesPageExpectedValue.CSMRequestLogFileDeviceSerialNumber);
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(LogFilesPage.Locator.LogsTabXpath)));
            _logFilesPage.LogsTab.Click();
        }
        
        [Given(@"Received, Pending or Executing message is not displayed")]
        public void GivenPendingOrExecutingMessageIsNotDisplayed()
        {
            _logFilesPage.LogsPendingMessage.GetElementVisibility().Should().BeFalse("Receiving,Pending or Executing message is displayed");
        }
        
        [When(@"user clicks Request Logs button")]
        public void WhenUserClicksRequestLogsButton()
        {
            _logFilesPage.RequestLogsButton.Click();
        }
        
        [Then(@"Received, Pending or Executing message is displayed")]
        public void ThenPendingOrExecutingMessageIsDisplayed()
        {
            _logFilesPage.LogsPendingMessage.GetElementVisibility().Should().BeTrue("Pending or Executing message is not displayed");
            _logFilesPage.LogsPendingMessage.LogFilesRequestStatusMessageVerification().Should().BeTrue("Log files request message is not matching the expected.");
        }
        
        [Then(@"Request Logs button is disabled")]
        public void ThenRequestLogsButtonIsDisabled()
        {
           _logFilesPage.RequestLogsButton.GetAttribute("class").Should().BeEquivalentTo(LogFilesPageExpectedValue.RequestLogButtonDisabledClassName ,"Request Logs button is not disabled");
        }

        [Given(@"Received, Pending or Executing message is displayed")]
        public void GivenPendingOrExecutingMessageIsDisplayed()
        {
            _logFilesPage.LogsPendingMessage.GetElementVisibility().Should().BeTrue("Pending or Executing message is not displayed");
            _logFilesPage.LogsPendingMessage.LogFilesRequestStatusMessageVerification().Should().BeTrue("Log files request message is not matching the expected.");
        }

    }
}
