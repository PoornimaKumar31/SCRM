﻿using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding, Scope(Tag ="SoftwareRequirementID_5699")]
    class Req5699Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        CSMDeviceDetailsPage csmDeviceDetailsPage = new CSMDeviceDetailsPage();
        readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        readonly MainPage mainPage = new MainPage();
        readonly DeviceDetailsPage deviceDetailsPage = new DeviceDetailsPage();
        private ScenarioContext _scenarioContext;


        public Req5699Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"user has selected CSM device")]
        public void GivenUserHasSelectedCSMDevice()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest2Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CSMDeviceName);
            Thread.Sleep(1000);
            mainPage.SearchSerialNumberAndClick("110010000019");
            
        }

        [Given(@"user is on Device Details page")]
        public void GivenUserIsOnDeviceDetailsPage()
        {
            bool result = (deviceDetailsPage.AssetLabel.GetElementVisibility()) || (deviceDetailsPage.AssetData.GetElementVisibility());
            Assert.AreEqual(true, result, "User is not on device details page.");
        }



        [When(@"user clicks Logs tab")]
        public void WhenUserClicksLogsTab()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CSMDeviceDetailsPage.Locators.LogsTabID)));
            csmDeviceDetailsPage.LogsTab.Click();
        }

        [Then(@"logs for CSM device are displayed")]
        public void ThenLogsForCSMDeviceAreDisplayed()
        {
            Thread.Sleep(2000);
            Assert.AreEqual(true,csmDeviceDetailsPage.LogFiles.Count>0,"log files are not displayed.");
        }

        [Given(@"user is on CSM Log Files page with (.*) logs")]
        public void GivenUserIsOnCSMLogFilesPageWithLogs(int noOfLogs)
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            switch (noOfLogs)
            {
                case 0:
                    //Selecting CSM device with no log files
                    landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
                    mainPage.SearchSerialNumberAndClick("100010000005");
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CSMDeviceDetailsPage.Locators.LogsTabID)));
                    csmDeviceDetailsPage.LogsTab.Click();
                    break;

                case 10:
                    //selecting CSM device with 10 log files
                    landingPage.LNTAutomatedTestOrganizationFacilityTest2Title.Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
                    mainPage.SearchSerialNumberAndClick("110010000019");
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CSMDeviceDetailsPage.Locators.LogsTabID)));
                    csmDeviceDetailsPage.LogsTab.Click();
                    break;
                case 24:
                    //selecting CSM device with 25 log files
                    landingPage.LNTAutomatedTestOrganizationFacilityTest2Title.Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
                    mainPage.SearchSerialNumberAndClick("110010000000");
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CSMDeviceDetailsPage.Locators.LogsTabID)));
                    csmDeviceDetailsPage.LogsTab.Click();
                    break;
                default: Assert.Fail("Invalid number of logs \""+ noOfLogs+"\"");
                    break;
            }
        }

        [When(@"user clicks log")]
        public void WhenUserClicksLog()
        {
            csmDeviceDetailsPage.LogFiles[0].Click();   
        }

        [Then(@"log is downloaded to computer")]
        public void ThenLogIsDownloadedToComputer()
        {
            bool file_exist = false;
            int count = 0;
            while (file_exist != true && count<=10)
            {
                Task.Delay(1000).Wait();
                count++;
                if (File.Exists(PropertyClass.DownloadPath +"\\"+ csmDeviceDetailsPage.LogFiles[0].Text) || count ==15)
                {
                    file_exist = true;
                }
            }
        }

        [Then(@"downloaded filename matches")]
        public void ThenDownloadedFilenameMatches()
        {
            Assert.AreEqual(true,File.Exists(PropertyClass.DownloadPath +"\\"+ csmDeviceDetailsPage.LogFiles[0].Text),"download file name does not match the log file name.");
        }

        [Then(@"user cannot navigate to next logs page")]
        public void ThenUserCannotNavigateToNextLogsPage()
        {
            SetMethods.MoveTotheElement(csmDeviceDetailsPage.LogsNextButton, "Next logs page");
            csmDeviceDetailsPage.LogsNextButton.Click();
            Assert.AreEqual(true,csmDeviceDetailsPage.LogsPageNumber.Text == "1","User can navigate to the next page");
        }

        [When(@"user clicks Request Logs button")]
        public void WhenUserClicksRequestLogsButton()
        {
            csmDeviceDetailsPage.LogsRequestButton.Click();
        }

        [Then(@"Received, Pending or Executing message is displayed")]
        public void ThenPendingOrExecutingMessageIsDisplayed()
        {
            Assert.AreEqual(true,csmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility(), "Received, Pending or Executing message is not displayed.");
            Assert.AreEqual(true, csmDeviceDetailsPage.LogsPendingMessage.LogFilesRequestStatusMessageVerification(), "Log files request message does not match the expected value.");
        }

        [Then(@"user can navigate to next logs page")]
        public void ThenUserCanNavigateToNextLogsPage()
        {
            csmDeviceDetailsPage.LogsNextButton.Click();
            Thread.Sleep(1000);
            Assert.AreEqual(true,csmDeviceDetailsPage.LogsPageNumber.Text == "2","User cannot navigate to the next page");
        }

        [Given(@"Received, Pending or Executing message is displayed")]
        public void GivenPendingOrExecutingMessageIsDisplayed()
        {
            if(!(csmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility()))
            {
                //create a log file request if not there
                csmDeviceDetailsPage.LogsRequestButton.Click();
                Assert.AreEqual(true,csmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility(), "Pending or Executing message is not displayed");
                Assert.AreEqual(true, csmDeviceDetailsPage.LogsPendingMessage.LogFilesRequestStatusMessageVerification(), "Log files request message does not match the expected value.");
            }
        }

        [When(@"user navigates to next logs page")]
        public void WhenUserNavigatesToNextLogsPage()
        {
            csmDeviceDetailsPage.LogsNextButton.Click();
            Thread.Sleep(1000);
            Assert.AreEqual(true,csmDeviceDetailsPage.LogsPageNumber.Text == "2","User navigates to the next page.");
        }

        [When(@"user navigates to previous logs page")]
        public void WhenUserNavigatesToPreviousLogsPage()
        {
            csmDeviceDetailsPage.LogsPreviousButton.Click();
            Thread.Sleep(1000);
            Assert.AreEqual(true, csmDeviceDetailsPage.LogsPageNumber.Text == "1", "User cannot navigate to the previous page.");
        }

        [Then(@"no logs for CSM device are displayed")]
        public void ThenNoLogsForCSMDeviceAreDisplayed()
        {
            Assert.AreEqual(true,csmDeviceDetailsPage.LogFiles.GetElementCount()==0,"Number of logs are not as expected");
        }


        [When(@"user clicks Next page button")]
        public void WhenUserClicksNextPageButton()
        {
            csmDeviceDetailsPage.LogsNextButton.Click();
        }

        [Then(@"user will see logs page (.*) indicator")]
        public void ThenUserWillSeeLogsPageIndicator(int PageNumber)
        {
            Assert.IsTrue(csmDeviceDetailsPage.LogsPageNumber.Text == PageNumber.ToString());
        }

        [Given(@"logs are sorted by decreasing date")]
        public void GivenLogsAreSortedByDecreasingDate()
        {
            if (csmDeviceDetailsPage.DateSorting.GetAttribute("class") == "col-md-4 ascending")
            {
                csmDeviceDetailsPage.DateSorting.Click();
            }

            Assert.AreEqual("col-md-4 descending", csmDeviceDetailsPage.DateSorting.GetAttribute("class"),"Sorting Indicator is not as expected.");
            Assert.AreEqual(CSMDeviceDetailsPage.ExpectedValues.SortDecreasingIconURL, csmDeviceDetailsPage.DateSorting.GetCssValue("background-image"));
            Assert.AreEqual(true, csmDeviceDetailsPage.LogDateList.isDateSorted("d"), "Log file are not sorted in decreasing date");
        }


        [Given(@"logs are sorted by increasing date")]
        public void GivenLogsAreSortedByIncreasingDate()
        {
            if(csmDeviceDetailsPage.DateSorting.GetAttribute("class")== "col-md-4 descending")
            {
                csmDeviceDetailsPage.DateSorting.Click();
            }
            Assert.AreEqual("col-md-4 ascending", csmDeviceDetailsPage.DateSorting.GetAttribute("class"), "Sorting Indicator is not as expected.");
            Assert.AreEqual(CSMDeviceDetailsPage.ExpectedValues.SortIncreasingIconURL, csmDeviceDetailsPage.DateSorting.GetCssValue("background-image"));
            Assert.AreEqual(true, csmDeviceDetailsPage.LogDateList.isDateSorted("a"), "Log files are not sorted in increasing date");
        }

        [When(@"user clicks Date column heading")]
        public void WhenUserClicksDateColumnHeading()
        {
            csmDeviceDetailsPage.DateSorting.Click();
        }

        [Then(@"logs are sorted by decreasing date")]
        public void ThenLogsSortByDecreasingDate()
        {
            Assert.AreEqual(true,csmDeviceDetailsPage.LogDateList.isDateSorted("d"),"Date is not sorted in the decreasing order");
        }

        [Then(@"decreasing date sorting indicator is displayed")]
        public void DecreasingDateSortingIndicatorIsDisplayed()
        {
            Thread.Sleep(3000);
            Assert.AreEqual(true, csmDeviceDetailsPage.DateSorting.GetAttribute("class") == CSMDeviceDetailsPage.Locators.LogsDescendingClassName, "Decreasing date sorting indicator is not displayed");
            Assert.AreEqual(CSMDeviceDetailsPage.ExpectedValues.SortDecreasingIconURL, csmDeviceDetailsPage.DateSorting.GetCssValue("background-image"));
        }

        [Then(@"logs are sorted by increasing date")]
        public void ThenLogsSortByIncreasingDate()
        {
            Assert.AreEqual(true, csmDeviceDetailsPage.LogDateList.isDateSorted("a"),"Logs are not sorted in increasing order");
        }

        [Then(@"increasing date sorting indicator is displayed")]
        public void IncreasingDateSortingIndicatorIsDisplayed()
        {
            Assert.AreEqual(true,csmDeviceDetailsPage.DateSorting.GetAttribute("class") == CSMDeviceDetailsPage.Locators.LogsAscendingClassName,"Increasing date sorting indicator is not displayed");
            Assert.AreEqual(CSMDeviceDetailsPage.ExpectedValues.SortIncreasingIconURL, csmDeviceDetailsPage.DateSorting.GetCssValue("background-image"));
        }

        [Then(@"(.*) logs for CSM device are displayed")]
        public void ThenLogsForCSMDeviceAreDisplayed(int logFilesCount)
        {
            int noOfLogFiles = csmDeviceDetailsPage.LogFiles.GetElementCount();
            Assert.AreEqual(true,  noOfLogFiles== logFilesCount, noOfLogFiles+" are displayed.");
        }

        [Then(@"(.*) newest logs are displayed")]
        public void GivenNewestLogsAreDisplayed(int num)
        {
            Assert.AreEqual(true, csmDeviceDetailsPage.NNewestLogsPresence(num), "Number of logs displayed are not as expected");
        }

        [Then(@"next (.*) older logs are displayed")]
        public void ThenUserWillSeeNextOlderLogs(int num)
        {
            Assert.AreEqual(true, csmDeviceDetailsPage.NOlderLogsPresence(num), "Number of Logs are not as expected");
        }

        [Then(@"""(.*)"" pagination label is displayed")]
        public void ThenPaginationLabelIsDisplayed(string pageNumber)
        {
            Assert.AreEqual(true, csmDeviceDetailsPage.LogsPageNumber.GetElementVisibility(), "Pagination label is not displayed");
            Assert.AreEqual(pageNumber, csmDeviceDetailsPage.LogsPageNumber.Text, "page number is not as expected");
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
