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
            loginPage.SignIn("rv700");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.AssetsTabID)));
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
                    rv700DeviceDetailsPage.RV700Devices[1].Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(RV700DeviceDetailsPage.Locators.LogsTabID)));
                    rv700DeviceDetailsPage.LogsTab.Click();
                    break;

                case 10:
                    //selecting RV700 device with 10 log files
                    rv700DeviceDetailsPage.RV700Devices[0].Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(RV700DeviceDetailsPage.Locators.LogsTabID)));
                    rv700DeviceDetailsPage.LogsTab.Click();
                    break;
                case 25:
                    //selecting RV700 device with 25 log files
                    rv700DeviceDetailsPage.RV700Devices[2].Click();
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
            Assert.IsFalse(rv700DeviceDetailsPage.LogFiles[0].Displayed);
        }

        [Then(@"ten logs for RV700 device are displayed")]
        public void ThenTenLogsForRV700DeviceAreDisplayed()
        {
            Assert.IsTrue(rv700DeviceDetailsPage.LogFiles.GetElementCount() == 10);
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

        [Given(@"newest ten logs are displayed")]
        public void GivenNewestTenLogsAreDisplayed()
        {
            Assert.IsTrue(rv700DeviceDetailsPage.LogFiles.GetElementCount() == 10);
        }

        [When(@"user clicks Next page button")]
        public void WhenUserClicksNextPageButton()
        {
            rv700DeviceDetailsPage.LogsNextButton.Click();
        }

        [Then(@"user will see next ten older logs")]
        public void ThenUserWillSeeNextTenOlderLogs()
        {
            Assert.IsTrue(rv700DeviceDetailsPage.LogFiles.GetElementCount() == 10);
        }

        [Then(@"user will see logs page (.*) indicator")]
        public void ThenUserWillSeeLogsPageIndicator()
        {
            _scenarioContext.Pending();
        }

        [Given(@"logs are sorted by decreasing date")]
        public void GivenLogsAreSortedByDecreasingDate()
        {
            if (rv700DeviceDetailsPage.DateSorting.GetAttribute("class") == "col-md-4 ascending")
            {
                rv700DeviceDetailsPage.DateSorting.Click();
            }
        }

        [Given(@"second ten logs are displayed")]
        public void GivenSecondTenLogsAreDisplayed()
        {
            _scenarioContext.Pending();
        }

        [Then(@"user will see next five older logs")]
        public void ThenUserWillSeeNextFiveOlderLogs()
        {
            Assert.IsTrue(rv700DeviceDetailsPage.LogFiles.GetElementCount() == 5);
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

        [Then(@"user will see decreasing date sorting indicator")]
        public void ThenUserWillSeeDecreasingDateSortingIndicator()
        {
            Assert.IsTrue(rv700DeviceDetailsPage.DateSorting.GetAttribute("class") == "col-md-4 descending");
        }

        [Then(@"logs sort by increasing date")]
        public void ThenLogsSortByIncreasingDate()
        {
            Assert.IsTrue(rv700DeviceDetailsPage.LogDateList.isDateSorted("a"));
        }

        [Then(@"user will see increasing date sorting indicator")]
        public void ThenUserWillSeeIncreasingDateSortingIndicator()
        {
            Assert.IsTrue(rv700DeviceDetailsPage.DateSorting.GetAttribute("class") == "col-md-4 ascending");
        }

    }
}
