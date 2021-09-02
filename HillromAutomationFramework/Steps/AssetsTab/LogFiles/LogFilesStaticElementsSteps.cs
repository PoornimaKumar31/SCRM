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
        private ScenarioContext _scenarioContext;
        private readonly LoginPage _loginPage;
        private readonly LogFilesStaticElements _logFilesStaticElements;
        private readonly MainPage _mainPage;
        private readonly CVSMDeviceDetailsPage _cvsmDeviceDetailsPage;
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

        public LogFilesStaticElementsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = new LoginPage();
            _logFilesStaticElements = new LogFilesStaticElements();
            _mainPage = new MainPage();
            _cvsmDeviceDetailsPage = new CVSMDeviceDetailsPage();
        }
        
        [Given(@"user has selected any device")]
        public void GivenUserHasSelectedAnyDevice()
        {
            
            _loginPage.LogIn(LoginPage.LogInType.AdminWithOutRollUpPage);
            wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
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
            _cvsmDeviceDetailsPage.LogsTab.Click();
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
            _logFilesStaticElements.PreviousIcon.GetElementVisibility().Should().BeTrue("Previous page icon is not displayed");
        }

        [Then(@"Next page icon is displayed")]
        public void ThenNextPageIconIsDisplayed()
        {
            _logFilesStaticElements.NextIcon.GetElementVisibility().Should().BeTrue("Next page icon is not displayed");
        }

        [Then(@"Page number is displayed")]
        public void ThenPageNumberIsDisplayed()
        {
            _logFilesStaticElements.PageNumber.GetElementVisibility().Should().BeTrue("Page Number is not displayed");
        }

    }
}
