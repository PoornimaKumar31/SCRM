using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5711")]
    class Req5711Steps
    {
        LoginPage loginPage = new LoginPage();
        MainPage mainPage = new MainPage();
        RV700DeviceDetailsPage rv700DeviceDetailsPage = new RV700DeviceDetailsPage();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        private ScenarioContext _scenarioContext;
        public Req5711Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"user has selected RV700 device")]
        public void GivenUserHasSelectedRV700Device()
        {
            loginPage.SignIn("rv700");
            SelectElement selectAssetType = new SelectElement(mainPage.AssetTypeDropDown);
            selectAssetType.SelectByText(MainPage.ExpectedValues.RV700DeviceName);
            rv700DeviceDetailsPage.RV700Devices[1].Click();
        }

        [Given(@"user is on Main page")]
        public void GivenUserIsOnMainPage()
        {
            
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.AssetsTabID)));
            Assert.AreEqual(true, mainPage.AssetsTab.GetElementVisibility(), "Assets tab is not displayed");
        }

        [When(@"user clicks Logs tab")]
        public void WhenUserClicksLogsTab()
        {
            rv700DeviceDetailsPage.LogsTab.Click();
        }

        [Then(@"logs for RV700 device are displayed")]
        public void ThenLogsForRVDeviceAreDisplayed()
        {
            Assert.IsTrue(rv700DeviceDetailsPage.LogFiles.GetElementCount() != 0); 
        }
  
        [Given(@"user is on RV700 Log Files page with (.*) logs")]
        public void GivenUserIsOnRVLogFilesPageWithLogs(int noOfLogs)
        {
            loginPage.SignIn("rv700");
            SelectElement selectAssetType = new SelectElement(mainPage.AssetTypeDropDown);
            selectAssetType.SelectByText(MainPage.ExpectedValues.RV700DeviceName);         
            Thread.Sleep(2000);

            switch (noOfLogs)
            {
                case 0:
                    //Selecting RV700 device with no log files
                    rv700DeviceDetailsPage.RV700Devices[2].Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(RV700DeviceDetailsPage.Locators.LogsTabID)));
                    rv700DeviceDetailsPage.LogsTab.Click();
                    break;

                case 10:
                    //selecting RV700 device with 10 log files
                    rv700DeviceDetailsPage.RV700Devices[4].Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(RV700DeviceDetailsPage.Locators.LogsTabID)));
                    rv700DeviceDetailsPage.LogsTab.Click();
                    break;
                case 24:
                    //selecting RV700 device with 24 log files
                    rv700DeviceDetailsPage.RV700Devices[1].Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(RV700DeviceDetailsPage.Locators.LogsTabID)));
                    rv700DeviceDetailsPage.LogsTab.Click();
                    break;
            }
        }

        [Given(@"newest (.*) logs are displayed")]
        public void GivenNewestLogsAreDisplayed(int p0)
        {
            _scenarioContext.Pending();
        }

        [Then(@"user will see next (.*) older logs")]
        public void ThenUserWillSeeNextOlderLogs(int p0)
        {
            _scenarioContext.Pending();
        }

        [Then(@"no logs for RV700 device are displayed")]
        public void ThenNoLogsForRV700DeviceAreDisplayed()
        {
            Assert.AreEqual(true,rv700DeviceDetailsPage.LogFiles.Count==0,"Number of Logs are not 0");
        }

        [Then(@"(.*) logs for RV700 device are displayed")]
        public void ThenLogsForRVDeviceAreDisplayed(int p0)
        {
            Assert.AreEqual(p0, rv700DeviceDetailsPage.LogFiles.GetElementCount(), "Number of Logs is not same as expected");
        }


        [Then(@"user cannot navigate to next logs page")]
        public void ThenUserCannotNavigateToNextLogsPage()
        {
            Assert.IsFalse(rv700DeviceDetailsPage.LogsNextButton.Enabled);
        }

        [When(@"user clicks Request Logs button")]
        public void WhenUserClicksRequestLogsButton()
        {
            rv700DeviceDetailsPage.LogsRequestButton.Click();
        }

        [Then(@"Pending or Executing message is displayed")]
        public void ThenPendingOrExecutingMessageIsDisplayed()
        {
            Assert.IsTrue(rv700DeviceDetailsPage.LogsPendingMessage.Displayed);
        }

        [Then(@"user can navigate to next logs page")]
        public void ThenUserCanNavigateToNextLogsPage()
        {
            Assert.IsTrue(rv700DeviceDetailsPage.LogsNextButton.Enabled);
        }

        [Given(@"Pending or Executing message is displayed")]
        public void GivenPendingOrExecutingMessageIsDisplayed()
        {
            Assert.IsTrue(rv700DeviceDetailsPage.LogsPendingMessage.Displayed);
        }

        [When(@"user navigates to next logs page")]
        public void WhenUserNavigatesToNextLogsPage()
        {
            rv700DeviceDetailsPage.LogsNextButton.Click();
        }

        [When(@"user navigates to previous logs page")]
        public void WhenUserNavigatesToPreviousLogsPage()
        {
            rv700DeviceDetailsPage.LogsPreviousButton.Click();
        }

        [Given(@"Log files are sorted by decreasing date")]
        public void GivenLogFilesAreSortedByDecreasingDate()
        {
            if (rv700DeviceDetailsPage.DateSorting.GetAttribute("class") == "col-md-4 ascending")
            {
                rv700DeviceDetailsPage.DateSorting.Click();
            }
        }


        [When(@"user clicks Next page button")]
        public void WhenUserClicksNextPageButton()
        {
            rv700DeviceDetailsPage.LogsNextButton.Click();
        }


        [Given(@"logs are sorted by decreasing date")]
        public void GivenLogsAreSortedByDecreasingDate()
        {
            if (rv700DeviceDetailsPage.DateSorting.GetAttribute("class") == "col-md-4 ascending")
            {
                rv700DeviceDetailsPage.DateSorting.Click();
            }
        }

        [Given(@"logs are sorted by increasing date")]
        public void GivenLogsAreSortedByIncreasingDate()
        {
            if (rv700DeviceDetailsPage.DateSorting.GetAttribute("class") == "col-md-4 descending")
            {
                rv700DeviceDetailsPage.DateSorting.Click();
            }
        }

        [When(@"user clicks Date column heading")]
        public void WhenUserClicksDateColumnHeading()
        {
            rv700DeviceDetailsPage.DateSorting.Click();
        }

        [Then(@"logs sort by decreasing date")]
        public void ThenLogsSortByDecreasingDate()
        {
            if (rv700DeviceDetailsPage.DateSorting.GetAttribute("class") == "col-md-4 ascending")
            {
                rv700DeviceDetailsPage.DateSorting.Click();
            }
        }

        [Then(@"decreasing date sorting indicator is displayed")]
        public void DecreasingDateSortingIndicatorIsDisplayed()
        {
            Assert.IsTrue(rv700DeviceDetailsPage.DateSorting.GetAttribute("class") == "col-md-4 descending");
        }

        [Then(@"logs sort by increasing date")]
        public void ThenLogsSortByIncreasingDate()
        {
            Assert.IsTrue(rv700DeviceDetailsPage.LogDateList.isDateSorted("a"));
        }

        [Then(@"increasing date sorting indicator is displayed")]
        public void IncreasingDateSortingIndicatorDisplayed()
        {
            Assert.IsTrue(rv700DeviceDetailsPage.DateSorting.GetAttribute("class") == "col-md-4 ascending");
        }

        [Then(@"newest (.*) logs are displayed")]
        public void ThenNewestLogsAreDisplayed(int p0)
        {
            _scenarioContext.Pending();
        }

        [Then(@"displaying (.*) to (.*) of (.*) results label is displayed")]
        public void ThenDisplayingToOfResultsLabelIsDisplayed(int p0, int p1, int p2)
        {
            _scenarioContext.Pending();
        }

        [Then(@"page (.*) of (.*) label is displayed")]
        public void ThenPageOfLabelIsDisplayed(int p0, int p1)
        {
            _scenarioContext.Pending();
        }

        [Then(@"page (.*) of (.*) label displayed")]
        public void ThenPageOfLabelDisplayed(int p0, int p1)
        {
            _scenarioContext.Pending();
        }

        [Then(@"next (.*) older logs are displayed")]
        public void ThenNextOlderLogsAreDisplayed(int p0)
        {
            _scenarioContext.Pending();
        }

    }
}
