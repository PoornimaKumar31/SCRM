using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5691")]
    class DisplayingCVSMLogsSteps
    {
       private ScenarioContext _scenarioContext;
        public DisplayingCVSMLogsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"user is on CVSM Log Files page")]
        public void GivenUserIsOnCVSMLogFilesPage()
        {
           _scenarioContext.Pending();
        }

        [Given(@"CVSM has no logs")]
        public void GivenCVSMHasNoLogs()
        {
            _scenarioContext.Pending();
        }

        [Then(@"no logs for CVSM device are displayed")]
        public void ThenNoLogsForCVSMDeviceAreDisplayed()
        {
           _scenarioContext.Pending();
        }

        [Given(@"CVSM has ten logs")]
        public void GivenCVSMHasTenLogs()
        {
           _scenarioContext.Pending();
        }

        [Then(@"ten logs for CVSM device are displayed")]
        public void ThenTenLogsForCVSMDeviceAreDisplayed()
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

        [Given(@"CVSM has (.*) logs")]
        public void GivenCVSMHasLogs(int p0)
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
    }
}
