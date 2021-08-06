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
        LandingPage landingPage = new LandingPage();
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
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.RV700DeviceName);
            Thread.Sleep(1000);
        }

        [Given(@"user is on Main page")]
        public void GivenUserIsOnMainPage()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.AssetsTabID)));
            Assert.AreEqual(true, mainPage.AssetsTab.GetElementVisibility(), "Assets tab is not displayed");
            mainPage.SearchSerialNumberAndClick("700090000004");
        }

        [When(@"user clicks Logs tab")]
        public void WhenUserClicksLogsTab()
        {
            rv700DeviceDetailsPage.LogsTab.Click();
        }

        [Then(@"logs for RV700 device are displayed")]
        public void ThenLogsForRVDeviceAreDisplayed()
        {
            Assert.AreEqual(true,rv700DeviceDetailsPage.LogFiles.GetElementCount() != 0,"number of logs are not as expected"); 
        }
  
        [Given(@"user is on RV700 Log Files page with (.*) logs")]
        public void GivenUserIsOnRVLogFilesPageWithLogs(int noOfLogs)
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.RV700DeviceName);         
            Thread.Sleep(2000);

            switch (noOfLogs)
            {
                case 0:
                    //Selecting RV700 device with no log files
                    mainPage.SearchSerialNumberAndClick("700090000009");
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(RV700DeviceDetailsPage.Locators.LogsTabID)));
                    rv700DeviceDetailsPage.LogsTab.Click();
                    break;

                case 10:
                    //selecting RV700 device with 10 log files
                    mainPage.SearchSerialNumberAndClick("700090000004");
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(RV700DeviceDetailsPage.Locators.LogsTabID)));
                    rv700DeviceDetailsPage.LogsTab.Click();
                    break;
                case 24:
                    //selecting RV700 device with 24 log files
                    mainPage.SearchSerialNumberAndClick("700090000001");
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(RV700DeviceDetailsPage.Locators.LogsTabID)));
                    rv700DeviceDetailsPage.LogsTab.Click();
                    break;
            }
        }

        [Then(@"no logs for RV700 device are displayed")]
        public void ThenNoLogsForRV700DeviceAreDisplayed()
        {
            Assert.AreEqual(0,rv700DeviceDetailsPage.LogFiles.Count,"Number of Logs are not 0");
        }

        [Then(@"(.*) logs for RV700 device are displayed")]
        public void ThenLogsForRVDeviceAreDisplayed(int ExpectedDeviceCount)
        {
            Assert.AreEqual(ExpectedDeviceCount, rv700DeviceDetailsPage.LogFiles.GetElementCount(), "Number of Logs is not same as expected");
        }


        [Then(@"user cannot navigate to next logs page")]
        public void ThenUserCannotNavigateToNextLogsPage()
        {
            Assert.AreEqual(RV700DeviceDetailsPage.ExpectedValues.NextDisableImageURL, rv700DeviceDetailsPage.LogsNextButton.FindElement(By.TagName("img")).GetAttribute("src"), "Button is not disabled");
        }
            
        [When(@"user clicks Request Logs button")]
        public void WhenUserClicksRequestLogsButton()
        {
            rv700DeviceDetailsPage.LogsRequestButton.Click();
        }

        [Then(@"Received, Pending or Executing message is displayed")]
        public void ThenPendingOrExecutingMessageIsDisplayed()
        {
            Assert.AreEqual(true,rv700DeviceDetailsPage.LogsPendingMessage.GetElementVisibility(), "Reciving, Pending or Executing message is not displayed");
            Assert.AreEqual(true, rv700DeviceDetailsPage.LogsPendingMessage.LogFilesRequestStatusMessageVerification(), "Log files status message is not matching with the expected value.");
        }

        [Then(@"user can navigate to next logs page")]
        public void ThenUserCanNavigateToNextLogsPage()
        {
            Assert.AreEqual(RV700DeviceDetailsPage.ExpectedValues.NextEnableImageURL, rv700DeviceDetailsPage.LogsNextButton.FindElement(By.TagName("img")).GetAttribute("src"), "Button is not disabled");
        }

        [Given(@"Received, Pending or Executing message is displayed")]
        public void GivenPendingOrExecutingMessageIsDisplayed()
        {
            Assert.AreEqual(true,rv700DeviceDetailsPage.LogsPendingMessage.Displayed,"Pending or executing message is not displayed");
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
            
            Assert.AreEqual(RV700DeviceDetailsPage.ExpectedValues.SortDecreasingIconURL, rv700DeviceDetailsPage.DateSorting.GetCssValue("background-image"), "Sorting icon is not as expected");
            Assert.AreEqual(true, rv700DeviceDetailsPage.LogDateList.isDateSorted("d"), "Logs are not sorted by decreasing date");
        }

        [Given(@"logs are sorted by increasing date")]
        public void GivenLogsAreSortedByIncreasingDate()
        {
            if (rv700DeviceDetailsPage.DateSorting.GetAttribute("class") == "col-md-4 descending")
            {
                rv700DeviceDetailsPage.DateSorting.Click();
            }
            
            Assert.AreEqual(RV700DeviceDetailsPage.ExpectedValues.SortIncreasingIconURL, rv700DeviceDetailsPage.DateSorting.GetCssValue("background-image"),"Sorting icon is not as expected");
            Assert.AreEqual(true, rv700DeviceDetailsPage.LogDateList.isDateSorted("a"), "Logs are not sorted by increasing date");
        }

        [When(@"user clicks Date column heading")]
        public void WhenUserClicksDateColumnHeading()
        {
            rv700DeviceDetailsPage.DateSorting.Click();
        }

        [Then(@"logs are sorted by decreasing date")]
        public void ThenLogsSortByDecreasingDate()
        {
            Assert.AreEqual(true, rv700DeviceDetailsPage.LogDateList.isDateSorted("d"), "Date is not sorted in decreasing order");
        }

        [Then(@"decreasing date sorting indicator is displayed")]
        public void DecreasingDateSortingIndicatorIsDisplayed()
        {
            Assert.AreEqual(true, rv700DeviceDetailsPage.DateSorting.GetAttribute("class") == "col-md-4 descending", "decreasing date sorting indicator is not displayed");
            Assert.AreEqual(RV700DeviceDetailsPage.ExpectedValues.SortDecreasingIconURL, rv700DeviceDetailsPage.DateSorting.GetCssValue("background-image"),"Sorting icon is not as expected");
        }

        [Then(@"logs are sorted by increasing date")]
        public void ThenLogsSortByIncreasingDate()
        {
            Assert.AreEqual(true,rv700DeviceDetailsPage.LogDateList.isDateSorted("a"),"Date is not sorted in increasing order");
        }

        [Then(@"increasing date sorting indicator is displayed")]
        public void IncreasingDateSortingIndicatorDisplayed()
        {
            Assert.AreEqual(true, rv700DeviceDetailsPage.DateSorting.GetAttribute("class") == "col-md-4 ascending", "Icreasing date sorting date indicator is not displayed");
            Assert.AreEqual(RV700DeviceDetailsPage.ExpectedValues.SortIncreasingIconURL, rv700DeviceDetailsPage.DateSorting.GetCssValue("background-image"),"Sorting icon is not as expected");
        }

        [Then(@"(.*) newest logs are displayed")]
        public void ThenNewestLogsAreDisplayed(int num)
        {
            Assert.AreEqual(true, rv700DeviceDetailsPage.NNewestLogsPresence(num), "Number of logs displayed are not as expected");
        }

        [Then(@"next (.*) older logs are displayed")]
        public void ThenNextOlderLogsAreDisplayed(int num)
        {
            Assert.AreEqual(true, rv700DeviceDetailsPage.NOlderLogsPresence(num), "Number of Logs are not as expected");
        }

        [Then(@"""(.*)"" pagination label is displayed")]
        public void ThenPaginationLabelIsDisplayed(string pageNumber)
        {
            Assert.AreEqual(true, rv700DeviceDetailsPage.LogsPageNumber.GetElementVisibility(), "Pagination label is not displayed");
            Assert.AreEqual(pageNumber, rv700DeviceDetailsPage.LogsPageNumber.Text, "page number is not as expected");
        }

        [Then(@"Next page icon is enabled")]
        public void ThenNextPageIconIsEnabled()
        {
            Assert.AreEqual(CSMDeviceDetailsPage.ExpectedValues.NextEnableImageURL, csmDeviceDetailsPage.LogsNextButton.FindElement(By.TagName("img")).GetAttribute("src"), "Button is not disabled");
        }

        [Then(@"Previous page icon is disabled")]
        public void ThenPreviousPageIconIsDisabled()
        {
            Assert.AreEqual(CSMDeviceDetailsPage.ExpectedValues.PreviousDisableImageURL, csmDeviceDetailsPage.LogsPreviousButton.FindElement(By.TagName("img")).GetAttribute("src"), "Button is not disabled");
        }

        [Then(@"Previous page icon is enabled")]
        public void ThenPreviousPageIconIsEnabled()
        {
            Assert.AreEqual(CSMDeviceDetailsPage.ExpectedValues.PreviousEnableImageURL, csmDeviceDetailsPage.LogsPreviousButton.FindElement(By.TagName("img")).GetAttribute("src"), "Button is not disabled");
        }

        [Then(@"Next page icon is disabled")]
        public void ThenNextPageIconIsDisabled()
        {
            Assert.AreEqual(CSMDeviceDetailsPage.ExpectedValues.NextDisableImageURL, csmDeviceDetailsPage.LogsNextButton.FindElement(By.TagName("img")).GetAttribute("src"), "Button is not disabled");
        }

    }
}
