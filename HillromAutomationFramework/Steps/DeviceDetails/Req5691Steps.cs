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
            loginPage.SignIn("AdminWithoutRollupPage");
            SelectElement selectAssetType = new SelectElement(mainPage.AssetTypeDropDown);
            selectAssetType.SelectByText(MainPage.ExpectedValues.CVSMDeviceName);
            //select the row according to the data
            Thread.Sleep(2000);
            cvsmDeviceDetailsPage.CVSMDevices[1].Clicks();
        }

        [When(@"user clicks Logs tab")]
        public void WhenUserClicksLogsTab()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CVSMDeviceDetailsPage.Locators.LogsTabID)));
            cvsmDeviceDetailsPage.LogsTab.Click();
        }

        [Given(@"user is on device details page")]
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
            loginPage.SignIn("AdminWithoutRollupPage");
            SelectElement selectAssetType = new SelectElement(mainPage.AssetTypeDropDown);
            selectAssetType.SelectByText(MainPage.ExpectedValues.CVSMDeviceName);
            Thread.Sleep(2000);

            switch (noOfLogs)
            {
                case 0:
                    //Selecting CSM device with no log files
                    cvsmDeviceDetailsPage.CVSMDevices[0].Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CVSMDeviceDetailsPage.Locators.LogsTabID)));
                    cvsmDeviceDetailsPage.LogsTab.Click();
                    break;

                case 10:
                    //selecting CSM device with 10 log files
                    cvsmDeviceDetailsPage.CVSMDevices[2].Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CVSMDeviceDetailsPage.Locators.LogsTabID)));
                    cvsmDeviceDetailsPage.LogsTab.Click();
                    break;
                case 24:
                    //selecting CSM device with 25 log files
                    cvsmDeviceDetailsPage.CVSMDevices[1].Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CVSMDeviceDetailsPage.Locators.LogsTabID)));
                    cvsmDeviceDetailsPage.LogsTab.Click();
                    break;
            }
        }


        [Then(@"no logs for CVSM device are displayed")]
        public void ThenNoLogsForCVSMDeviceAreDisplayed()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.LogFiles.GetElementCount() == 0);
        }

        [Then(@"(.*) logs for CVSM device are displayed")]
        public void ThenLogsForCVSMDeviceAreDisplayed(int p0)
        {
            Assert.AreEqual(p0, cvsmDeviceDetailsPage.LogFiles.GetElementCount(), "Number of Logs are not as expected");
        }


        [Then(@"user cannot navigate to next logs page")]
        public void ThenUserCannotNavigateToNextLogsPage()
        {
            Assert.IsFalse(cvsmDeviceDetailsPage.LogsNextButton.Enabled);
        }

        [When(@"user clicks Request Logs button")]
        public void WhenUserClicksRequestLogsButton()
        {
            cvsmDeviceDetailsPage.LogsRequestButton.Click();
        }

        [Then(@"Pending or Executing message is displayed")]
        public void ThenPendingOrExecutingMessageIsDisplayed()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.LogsPendingMessage.Displayed);
        }

        [Then(@"user can navigate to next logs page")]
        public void ThenUserCanNavigateToNextLogsPage()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.LogsNextButton.Enabled);
        }

        [Given(@"Pending or Executing message is displayed")]
        public void GivenPendingOrExecutingMessageIsDisplayed()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.LogsPendingMessage.Displayed);
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
        }

        [Given(@"newest (.*) logs are displayed")]
        public void GivenNewestLogsAreDisplayed(int num)
        {
            _scenarioContext.Pending();
        }

        [When(@"user clicks Next page button")]
        public void WhenUserClicksNextPageButton()
        {
            cvsmDeviceDetailsPage.LogsNextButton.Click();
        }

        [Then(@"user will see next (.*) older logs")]
        public void ThenUserWillSeeNextOlderLogs(int num)
        {
            Assert.AreEqual(num,cvsmDeviceDetailsPage.LogFiles.GetElementCount(),"Number of Logs are not as expected");
        }

        [Then(@"user will see logs page (.*) indicator")]
        public void ThenUserWillSeeLogsPageIndicator(int p0)
        {
           _scenarioContext.Pending();
        }

        [Given(@"logs are sorted by decreasing date")]
        public void GivenLogsAreSortedByDecreasingDate()
        {
            if (cvsmDeviceDetailsPage.DateSorting.GetAttribute("class") == "col-md-4 ascending")
            {
                cvsmDeviceDetailsPage.DateSorting.Click();
            }
        }

        [Given(@"second ten logs are displayed")]
        public void GivenSecondTenLogsAreDisplayed()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.LogFiles.GetElementCount() == 10);
        }

        [Then(@"user will see next five older logs")]
        public void ThenUserWillSeeNextFiveOlderLogs()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.LogFiles.GetElementCount() == 5);
        }

        [Given(@"logs are sorted by increasing date")]
        public void GivenLogsAreSortedByIncreasingDate()
        {
            if (cvsmDeviceDetailsPage.DateSorting.GetAttribute("class") == "col-md-4 descending")
            {
                cvsmDeviceDetailsPage.DateSorting.Click();
            }
        }

        [When(@"user clicks Date column heading")]
        public void WhenUserClicksDateColumnHeading()
        {
            cvsmDeviceDetailsPage.DateSorting.Click();
        }

        [Then(@"logs sort by decreasing date")]
        public void ThenLogsSortByDecreasingDate()
        {
            Thread.Sleep(5000);
            Assert.IsTrue(cvsmDeviceDetailsPage.LogDateList.isDateSorted("d"));
        }

        [Then(@"user will see decreasing date sorting indicator")]
        public void ThenUserWillSeeDecreasingDateSortingIndicator()
        {
            
            Assert.IsTrue(cvsmDeviceDetailsPage.DateSorting.GetAttribute("class") == "col-md-4 descending");
        }

        [Then(@"logs sort by increasing date")]
        public void ThenLogsSortByIncreasingDate()
        {
            Thread.Sleep(5000);
            Assert.IsTrue(cvsmDeviceDetailsPage.LogDateList.isDateSorted("a"));
        }

        [Then(@"user will see increasing date sorting indicator")]
        public void ThenUserWillSeeIncreasingDateSortingIndicator()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.DateSorting.GetAttribute("class") == "col-md-4 ascending");
        }

        [Then(@"Displaying (.*) to (.*) of (.*) results label is displayed")]
        public void ThenDisplayingToOfResultsLabelIsDisplayed(int p0, int p1, int p2)
        {
            _scenarioContext.Pending();
        }

        [Then(@"page (.*) of (.*) label is displayed")]
        public void ThenPageOfLabelIsDisplayed(int p0, int p1)
        {
            _scenarioContext.Pending();
        }

    }
}
