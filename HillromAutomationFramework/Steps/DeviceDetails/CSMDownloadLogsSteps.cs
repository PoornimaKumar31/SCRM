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
    [Binding]
    class CSMDownloadLogsSteps
    {
        LoginPage loginPage = new LoginPage();
        CSMDeviceDetailsPage csmDeviceDetailsPage = new CSMDeviceDetailsPage();
        [When(@"user clicks Logs tab")]
        public void WhenUserClicksLogsTab()
        {
            WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(CSMDeviceDetailsPage.Locator.LogsButtonXpath)));
            csmDeviceDetailsPage.LogsButton.Click();
        }

        [Then(@"logs for CSM device are displayed")]
        public void ThenLogsForCSMDeviceAreDisplayed()
        {
            Thread.Sleep(2000);
            Assert.IsTrue(csmDeviceDetailsPage.LogFiles.Displayed);
        }

        [Given(@"user is on CSM Log Files page")]
        public void GivenUserIsOnCSMLogFilesPage()
        {
            loginPage.SignIn("adminwithrollup");
            csmDeviceDetailsPage.CSMDevices[0].Click();
        }

        [Given(@"at least one log is present")]
        public void GivenAtLeastOneLogIsPresent()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"user clicks log")]
        public void WhenUserClicksLog()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"log is downloaded to computer")]
        public void ThenLogIsDownloadedToComputer()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"downloaded filename matches")]
        public void ThenDownloadedFilenameMatches()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"CSM has ten logs")]
        public void GivenCSMHasTenLogs()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"ten logs for CSM device are displayed")]
        public void ThenTenLogsForCSMDeviceAreDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"user cannot navigate to next logs page")]
        public void ThenUserCannotNavigateToNextLogsPage()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"user clicks Request Logs button")]
        public void WhenUserClicksRequestLogsButton()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Pending or Executing message is displayed")]
        public void ThenPendingOrExecutingMessageIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"user can navigate to next logs page")]
        public void ThenUserCanNavigateToNextLogsPage()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Pending or Executing message is displayed")]
        public void GivenPendingOrExecutingMessageIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"user navigates to next logs page")]
        public void WhenUserNavigatesToNextLogsPage()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"user navigates to previous logs page")]
        public void WhenUserNavigatesToPreviousLogsPage()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Log files are sorted by decreasing date")]
        public void GivenLogFilesAreSortedByDecreasingDate()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"CSM has (.*) logs")]
        public void GivenCSMHasLogs(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"newest ten logs are displayed")]
        public void GivenNewestTenLogsAreDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"user clicks Next page button")]
        public void WhenUserClicksNextPageButton()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"user will see next ten older logs")]
        public void ThenUserWillSeeNextTenOlderLogs()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"user will see logs page (.*) indicator")]
        public void ThenUserWillSeeLogsPageIndicator(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"logs are sorted by decreasing date")]
        public void GivenLogsAreSortedByDecreasingDate()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"second ten logs are displayed")]
        public void GivenSecondTenLogsAreDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"user will see next five older logs")]
        public void ThenUserWillSeeNextFiveOlderLogs()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"logs are sorted by increasing date")]
        public void GivenLogsAreSortedByIncreasingDate()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"user clicks Date column heading")]
        public void WhenUserClicksDateColumnHeading()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"logs sort by decreasing date")]
        public void ThenLogsSortByDecreasingDate()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"user will see decreasing date sorting indicator")]
        public void ThenUserWillSeeDecreasingDateSortingIndicator()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"logs sort by increasing date")]
        public void ThenLogsSortByIncreasingDate()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"user will see increasing date sorting indicator")]
        public void ThenUserWillSeeIncreasingDateSortingIndicator()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Pending or Executing message is not displayed")]
        public void GivenPendingOrExecutingMessageIsNotDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Request Logs button is disabled")]
        public void ThenRequestLogsButtonIsDisabled()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
