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
    [Binding,Scope(Tag = "TestCaseID_8953")]
    public class LogFilesStaticElementsSteps
    {
        private readonly LoginPage _loginPage;
        private readonly LogFilesPage _logFilesStaticElements;
        private readonly MainPage _mainPage;
        private readonly CVSMDeviceDetailsPage _cvsmDeviceDetailsPage;

        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public LogFilesStaticElementsSteps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _logFilesStaticElements = new LogFilesPage(driver);
            _mainPage = new MainPage(driver);
            _cvsmDeviceDetailsPage = new CVSMDeviceDetailsPage(driver);
        }

        [Given(@"user has selected any device")]
        public void GivenUserHasSelectedAnyDevice()
        {
            
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithOutRollUpPage);
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.SearchSerialNumberAndClick("100020000001");

        }

        [Given(@"user is on Device Details page")]
        public void GivenUserIsOnMainPage()
        {
            _cvsmDeviceDetailsPage.EditButton.GetElementVisibility().Should().BeTrue();
        }

        [When(@"user clicks Logs tab")]
        public void WhenUserClicksLogsTab()
        {
            _logFilesStaticElements.LogsTab.Click();
        }

        [Then(@"Log Files label is displayed")]
        public void ThenLogFilesLabelIsDisplayed()
        {
            _logFilesStaticElements.LogFilesLabel.GetElementVisibility().Should().BeTrue("Logs label is not diplayed");
        }

        [Then(@"Request Logs button is displayed")]
        public void ThenRequestLogsButtonIsDisplayed()
        {
            _logFilesStaticElements.RequestLogsButton.GetElementVisibility().Should().BeTrue("Request Logs button is not displayed");
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenNameColumnHeadingIsDisplayed(string ExpectedColumnName)
        {
            switch(ExpectedColumnName.ToLower().Trim())
            {
                case "name":
                    _logFilesStaticElements.NameColumn.GetElementVisibility().Should().BeTrue("Name column is not displayed");
                    break;

                case "date":
                    _logFilesStaticElements.DateColumn.GetElementVisibility().Should().BeTrue("Date Column is not displayed");
                    break;
                default:
                    Assert.Fail(ExpectedColumnName+" is invalid heading name");
                    break;
            }
        }

    

        [Then(@"date sorting indicator is displayed")]
        public void ThenDateSortingIndicatorIsDisplayed()
        {
            _logFilesStaticElements.DateSortingIndicator.GetElementVisibility().Should().BeTrue("Date sorting indicator is not displayed");
        }

        [Then(@"Previous page icon is displayed")]
        public void ThenPreviousPageIconIsDisplayed()
        {
            _logFilesStaticElements.PreviousPageIcon.GetElementVisibility().Should().BeTrue("Previous page icon is not displayed");
        }

        [Then(@"Next page icon is displayed")]
        public void ThenNextPageIconIsDisplayed()
        {
            _logFilesStaticElements.NextPageIcon.GetElementVisibility().Should().BeTrue("Next page icon is not displayed");
        }

        [Then(@"Page number is displayed")]
        public void ThenPageNumberIsDisplayed()
        {
            _logFilesStaticElements.PageNumber.GetElementVisibility().Should().BeTrue("Page Number is not displayed");
        }

    }
}
