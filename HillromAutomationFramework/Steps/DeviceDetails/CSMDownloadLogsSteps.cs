using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding]
    class CSMDownloadLogsSteps
    {
        CSMDeviceDetailsPage csmDeviceDetailsPage = new CSMDeviceDetailsPage();
        private ScenarioContext _scenarioContext;
        public CSMDownloadLogsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"user clicks Logs tab")]
        public void WhenUserClicksLogsTab()
        {
            WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(CSMDeviceDetailsPage.Locators.LogsButtonXpath)));
            csmDeviceDetailsPage.LogsButton.Click();
        }

        [Then(@"logs for CSM device are displayed")]
        public void ThenLogsForCSMDeviceAreDisplayed()
        {
            Thread.Sleep(3000);
            Assert.IsTrue(csmDeviceDetailsPage.LogFiles.Displayed);
        }

        [Given(@"user is on CSM Log Files page")]
        public void GivenUserIsOnCSMLogFilesPage()
        {
            _scenarioContext.Pending();
        }

        [Given(@"at least one log is present")]
        public void GivenAtLeastOneLogIsPresent()
        {
            _scenarioContext.Pending();
        }

        [When(@"user clicks log")]
        public void WhenUserClicksLog()
        {
            _scenarioContext.Pending();
        }

        [Then(@"log is downloaded to computer")]
        public void ThenLogIsDownloadedToComputer()
        {
            _scenarioContext.Pending();
        }

        [Then(@"downloaded filename matches")]
        public void ThenDownloadedFilenameMatches()
        {
            _scenarioContext.Pending();
        }

        [Given(@"CSM has ten logs")]
        public void GivenCSMHasTenLogs()
        {
            _scenarioContext.Pending();
        }

        [Then(@"ten logs for CSM device are displayed")]
        public void ThenTenLogsForCSMDeviceAreDisplayed()
        {
            _scenarioContext.Pending();
        }

        [Then(@"user cannot navigate to next logs page")]
        public void ThenUserCannotNavigateToNextLogsPage()
        {
            _scenarioContext.Pending();
        }

        [When(@"user clicks Request Logs button")]
        public void WhenUserClicksRequestLogsButton()
        {
            _scenarioContext.Pending();
        }

        [Then(@"Pending or Executing message is displayed")]
        public void ThenPendingOrExecutingMessageIsDisplayed()
        {
            _scenarioContext.Pending();
        }

        [Then(@"user can navigate to next logs page")]
        public void ThenUserCanNavigateToNextLogsPage()
        {
            _scenarioContext.Pending();
        }

        [Given(@"Pending or Executing message is displayed")]
        public void GivenPendingOrExecutingMessageIsDisplayed()
        {
            _scenarioContext.Pending();
        }

        [When(@"user navigates to next logs page")]
        public void WhenUserNavigatesToNextLogsPage()
        {
            _scenarioContext.Pending();
        }

        [When(@"user navigates to previous logs page")]
        public void WhenUserNavigatesToPreviousLogsPage()
        {
            _scenarioContext.Pending();
        }

        [Given(@"Log files are sorted by decreasing date")]
        public void GivenLogFilesAreSortedByDecreasingDate()
        {
            _scenarioContext.Pending();
        }

        [Given(@"CSM has (.*) logs")]
        public void GivenCSMHasLogs(int p0)
        {
            _scenarioContext.Pending();
        }

        [Given(@"newest ten logs are displayed")]
        public void GivenNewestTenLogsAreDisplayed()
        {
            _scenarioContext.Pending();
        }

        [When(@"user clicks Next page button")]
        public void WhenUserClicksNextPageButton()
        {
            _scenarioContext.Pending();
        }

        [Then(@"user will see next ten older logs")]
        public void ThenUserWillSeeNextTenOlderLogs()
        {
            _scenarioContext.Pending();
        }

        [Then(@"user will see logs page (.*) indicator")]
        public void ThenUserWillSeeLogsPageIndicator(int p0)
        {
            _scenarioContext.Pending();
        }

        [Given(@"logs are sorted by decreasing date")]
        public void GivenLogsAreSortedByDecreasingDate()
        {
            _scenarioContext.Pending();
        }

        [Given(@"second ten logs are displayed")]
        public void GivenSecondTenLogsAreDisplayed()
        {
            _scenarioContext.Pending();
        }

        [Then(@"user will see next five older logs")]
        public void ThenUserWillSeeNextFiveOlderLogs()
        {
            _scenarioContext.Pending();
        }

        [Given(@"logs are sorted by increasing date")]
        public void GivenLogsAreSortedByIncreasingDate()
        {
            _scenarioContext.Pending();
        }

        [When(@"user clicks Date column heading")]
        public void WhenUserClicksDateColumnHeading()
        {
            _scenarioContext.Pending();
        }

        [Then(@"logs sort by decreasing date")]
        public void ThenLogsSortByDecreasingDate()
        {
            _scenarioContext.Pending();
        }

        [Then(@"user will see decreasing date sorting indicator")]
        public void ThenUserWillSeeDecreasingDateSortingIndicator()
        {
            _scenarioContext.Pending();
        }

        [Then(@"logs sort by increasing date")]
        public void ThenLogsSortByIncreasingDate()
        {
            _scenarioContext.Pending();
        }

        [Then(@"user will see increasing date sorting indicator")]
        public void ThenUserWillSeeIncreasingDateSortingIndicator()
        {
            _scenarioContext.Pending();
        }

        [Given(@"Pending or Executing message is not displayed")]
        public void GivenPendingOrExecutingMessageIsNotDisplayed()
        {
            _scenarioContext.Pending();
        }

        [Then(@"Request Logs button is disabled")]
        public void ThenRequestLogsButtonIsDisabled()
        {
            _scenarioContext.Pending();
        }

    }
}
