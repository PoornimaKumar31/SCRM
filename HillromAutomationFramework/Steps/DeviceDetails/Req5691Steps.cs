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
    [Binding,Scope(Tag = "SoftwareRequirementID_5691")]
    class Req5691Steps
    {
        readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        CVSMDeviceDetailsPage cvsmDeviceDetailsPage = new CVSMDeviceDetailsPage();
        private ScenarioContext _scenarioContext;

        public Req5691Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"user has selected CVSM device")]
        public void GivenUserHasSelectedCVSMDevice()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.Organization1Facility0Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CVSMDeviceName);
            //select the row according to the data
            Thread.Sleep(2000);
            mainPage.SearchSerialNumberAndClick("100020000001");
        }

        [When(@"user clicks Logs tab")]
        public void WhenUserClicksLogsTab()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CVSMDeviceDetailsPage.Locators.LogsTabID)));
            cvsmDeviceDetailsPage.LogsTab.Click();
        }

        [Given(@"user is on Device details page")]
        public void GivenUserIsOnDeviceDetailsPage()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.EditButton.GetElementVisibility());
        }


        [Then(@"logs for CVSM device are displayed")]
        public void ThenLogsForCVSMDeviceAreDisplayed()
        {
            Thread.Sleep(2000);
            Assert.IsTrue(cvsmDeviceDetailsPage.LogFiles.GetElementCount() > 0);
        }
        [Given(@"user is on CVSM Log Files page with (.*) logs")]
        public void GivenUserIsOnCVSMLogFilesPageWithLogs(int noOfLogs)
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.Organization1Facility0Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CVSMDeviceName);
            Thread.Sleep(2000);

            switch (noOfLogs)
            {
                case 0:
                    //Selecting CVSM device with no log files
                    mainPage.SearchSerialNumberAndClick("100020000000");
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CVSMDeviceDetailsPage.Locators.LogsTabID)));
                    cvsmDeviceDetailsPage.LogsTab.Click();
                    break;

                case 10:
                    //selecting CVSM device with 10 log files
                    mainPage.SearchSerialNumberAndClick("100020000007");
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CVSMDeviceDetailsPage.Locators.LogsTabID)));
                    cvsmDeviceDetailsPage.LogsTab.Click();
                    break;
                case 24:
                    //selecting CVSM device with 24 log files
                    mainPage.SearchSerialNumberAndClick("100020000001");
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CVSMDeviceDetailsPage.Locators.LogsTabID)));
                    cvsmDeviceDetailsPage.LogsTab.Click();
                    break;
                default: Assert.Fail(noOfLogs + " is a invalid log files number.");
                    break;
            }
        }


        [Then(@"no logs for CVSM device are displayed")]
        public void ThenNoLogsForCVSMDeviceAreDisplayed()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.LogFiles.GetElementCount() == 0);
        }

        [Then(@"(.*) logs for CVSM device are displayed")]
        public void ThenLogsForCVSMDeviceAreDisplayed(int logfilesCount)
        {
            Assert.AreEqual(logfilesCount, cvsmDeviceDetailsPage.LogFiles.GetElementCount(), "Number of Logs are not as expected");
        }


        [Then(@"user cannot navigate to next logs page")]
        public void ThenUserCannotNavigateToNextLogsPage()
        {
            SetMethods.ScrollToBottomofWebpage();
            string PageNumberBeforeClick = cvsmDeviceDetailsPage.LogsCurrentPageNumber.Text;
            cvsmDeviceDetailsPage.LogsNextButton.Click();
            string PageNumberAfterClick= cvsmDeviceDetailsPage.LogsCurrentPageNumber.Text;
            Assert.AreEqual(PageNumberBeforeClick, PageNumberAfterClick, "User can navigate to the next page.");
        }

        [When(@"user clicks Request Logs button")]
        public void WhenUserClicksRequestLogsButton()
        {
            cvsmDeviceDetailsPage.LogsRequestButton.Click();
        }

        [Then(@"Pending or Executing message is displayed")]
        public void ThenPendingOrExecutingMessageIsDisplayed()
        {
            Assert.AreEqual(true,cvsmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility(), "Pending or Executing message is not displayed");
        }

        [Then(@"user can navigate to next logs page")]
        public void ThenUserCanNavigateToNextLogsPage()
        {
            SetMethods.ScrollToBottomofWebpage();
            string PageNumberBeforeClick = cvsmDeviceDetailsPage.LogsCurrentPageNumber.Text;
            cvsmDeviceDetailsPage.LogsNextButton.Click();
            Thread.Sleep(1000);
            string PageNumberAfterClick = cvsmDeviceDetailsPage.LogsCurrentPageNumber.Text;
            Assert.AreNotEqual(PageNumberBeforeClick, PageNumberAfterClick, "User cannot navigate to the next page.");
        }

        [Given(@"Pending or Executing message is displayed")]
        public void GivenPendingOrExecutingMessageIsDisplayed()
        {
            Assert.AreEqual(true,cvsmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility(), "Pending or Executing message is not displayed");
        }

        [When(@"user navigates to next logs page")]
        public void WhenUserNavigatesToNextLogsPage()
        {
            cvsmDeviceDetailsPage.LogsNextButton.Click();
        }

        [When(@"user navigates to previous logs page")]
        public void WhenUserNavigatesToPreviousLogsPage()
        {
            cvsmDeviceDetailsPage.LogsPreviousButton.Click();
        }

        [Given(@"Log files are sorted by decreasing date")]
        public void GivenLogFilesAreSortedByDecreasingDate()
        {
            if (cvsmDeviceDetailsPage.DateSorting.GetAttribute("class") == "col-md-4 ascending")
            {
                cvsmDeviceDetailsPage.DateSorting.Click();
            }

            Assert.AreEqual("col-md-4 descending", cvsmDeviceDetailsPage.DateSorting.GetAttribute("class"), "Logs are not sorted in Decreasing date");
        }

        [Given(@"(.*) newest logs are displayed")]
        public void GivenNewestLogsAreDisplayed(int num)
        {
            Assert.AreEqual(true, cvsmDeviceDetailsPage.NNewestLogsPresence(num));
        }

        [When(@"user clicks Next page button")]
        public void WhenUserClicksNextPageButton()
        {
            cvsmDeviceDetailsPage.LogsNextButton.Click();
        }

        [Then(@"next (.*) older logs are displayed")]
        public void ThenUserWillSeeNextLogs(int number)
        {
            Assert.AreEqual(true, cvsmDeviceDetailsPage.NOlderLogsPresence(number));
        }

        [Given(@"logs are sorted by decreasing date")]
        public void GivenLogsAreSortedByDecreasingDate()
        {
            if (cvsmDeviceDetailsPage.DateSorting.GetAttribute("class") == "col-md-4 ascending")
            {
                cvsmDeviceDetailsPage.DateSorting.Click();
            }

            Assert.AreEqual("col-md-4 descending", cvsmDeviceDetailsPage.DateSorting.GetAttribute("class"), "Logs are not sorted as expected");
          
        }


        [Given(@"logs are sorted by increasing date")]
        public void GivenLogsAreSortedByIncreasingDate()
        {
            Thread.Sleep(2000);
            if (cvsmDeviceDetailsPage.DateSorting.GetAttribute("class").ToString() == "col-md-4 descending")
            {
                cvsmDeviceDetailsPage.DateSorting.Click();
                Thread.Sleep(2000);
            }
            Thread.Sleep(2000);
            Assert.AreEqual("col-md-4 ascending", cvsmDeviceDetailsPage.DateSorting.GetAttribute("class"),"Sorting indicator is not as expected.");
        }

        [When(@"user clicks Date column heading")]
        public void WhenUserClicksDateColumnHeading()
        {
            Thread.Sleep(3000);
            cvsmDeviceDetailsPage.DateSorting.Click();
        }

        [Then(@"logs are sorted by decreasing date")]
        public void ThenLogsSortByDecreasingDate()
        {
            Thread.Sleep(5000);
            Assert.AreEqual(true,cvsmDeviceDetailsPage.LogDateList.isDateSorted("d"),"log files are sorted by decreasing date.");
        }

        [Then(@"decreasing date sorting indicator is displayed")]
        public void DecreasingDateSortingIndicatorIsDisplayed()
        {
            
            Assert.AreEqual(true,cvsmDeviceDetailsPage.DateSorting.GetAttribute("class") == "col-md-4 descending","Indicator is not as expected.");
        }

        [Then(@"logs are sorted by increasing date")]
        public void ThenLogsSortByIncreasingDate()
        {
            Thread.Sleep(5000);
            Assert.AreEqual(true,cvsmDeviceDetailsPage.LogDateList.isDateSorted("a"),"Logs are not sorted by increasing date.");
        }

        [Then(@"increasing date sorting indicator is displayed")]
        public void IncreasingDateSortingIndicatorIsDisplayed()
        {
            Assert.AreEqual(true, cvsmDeviceDetailsPage.DateSorting.GetAttribute("class") == "col-md-4 ascending", "Indicator is not as expected.");
            
        }

        [Then(@"Displaying (.*) to (.*) of (.*) results label is displayed")]
        public void ThenDisplayingToOfResultsLabelIsDisplayed(int p0, int p1, int p2)
        {
            //In Application Result label is not there.(Bugs needs to be fixed)
            _scenarioContext.Pending();
        }

        [Then(@"page (.*) of (.*) label is displayed")]
        public void ThenPageOfLabelIsDisplayed(int p0, int p1)
        {
            //In Application Pagination label is not in proper format.(Bugs needs to be fixed)
            _scenarioContext.Pending();
        }

    }
}
