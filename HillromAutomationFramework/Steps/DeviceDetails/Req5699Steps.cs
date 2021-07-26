using HillromAutomationFramework.Coding.PageObjects;
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
            landingPage.Organization1Facility1Title.Click();
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
                    landingPage.Organization1Facility0Title.Click();
                    mainPage.SearchSerialNumberAndClick("100010000005");
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CSMDeviceDetailsPage.Locators.LogsTabID)));
                    csmDeviceDetailsPage.LogsTab.Click();
                    break;

                case 10:
                    //selecting CSM device with 10 log files
                    landingPage.Organization1Facility1Title.Click();
                    mainPage.SearchSerialNumberAndClick("110010000019");
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CSMDeviceDetailsPage.Locators.LogsTabID)));
                    csmDeviceDetailsPage.LogsTab.Click();
                    break;
                case 24:
                    //selecting CSM device with 25 log files
                    landingPage.Organization1Facility1Title.Click();
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
            csmDeviceDetailsPage.LogsNextButton.Click();
            Assert.AreEqual(true,csmDeviceDetailsPage.LogsCurrentPageNumber.Text == "1","User can navigate to the next page");
        }

        [When(@"user clicks Request Logs button")]
        public void WhenUserClicksRequestLogsButton()
        {
            csmDeviceDetailsPage.LogsRequestButton.Click();
        }

        [Then(@"Pending or Executing message is displayed")]
        public void ThenPendingOrExecutingMessageIsDisplayed()
        {
            Assert.AreEqual(true,csmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility(),"Pending message is not displayed.");
        }

        [Then(@"user can navigate to next logs page")]
        public void ThenUserCanNavigateToNextLogsPage()
        {
            csmDeviceDetailsPage.LogsNextButton.Click();
            Thread.Sleep(1000);
            Assert.AreEqual(true,csmDeviceDetailsPage.LogsCurrentPageNumber.Text == "2","User cannot navigate to the next page");
        }

        [Given(@"Pending or Executing message is displayed")]
        public void GivenPendingOrExecutingMessageIsDisplayed()
        {
            if(!(csmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility()))
            {
                //create a log file request if not there
                csmDeviceDetailsPage.LogsRequestButton.Click();
                Assert.AreEqual(true,csmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility(), "Pending or Executing message is not displayed");
            }
        }

        [When(@"user navigates to next logs page")]
        public void WhenUserNavigatesToNextLogsPage()
        {
            csmDeviceDetailsPage.LogsNextButton.Click();
            Thread.Sleep(1000);
            Assert.AreEqual(true,csmDeviceDetailsPage.LogsCurrentPageNumber.Text == "2","User navigates to the next page.");
        }

        [When(@"user navigates to previous logs page")]
        public void WhenUserNavigatesToPreviousLogsPage()
        {
            csmDeviceDetailsPage.LogsPreviousButton.Click();
            Thread.Sleep(1000);
            Assert.AreEqual(true,csmDeviceDetailsPage.LogsCurrentPageNumber.Text == "1","User cannot navigate to the previous page.");
        }

        [Given(@"Log files are sorted by decreasing date")]
        public void GivenLogFilesAreSortedByDecreasingDate()
        {
            Thread.Sleep(3000);
            if (!(csmDeviceDetailsPage.DateSorting.GetAttribute("class") == CSMDeviceDetailsPage.Locators.LogsDescendingClassName))
            {
                csmDeviceDetailsPage.DateSorting.Click();
                Thread.Sleep(3000);
                if (!(csmDeviceDetailsPage.DateSorting.GetAttribute("class") == CSMDeviceDetailsPage.Locators.LogsDescendingClassName))
                {
                    Assert.Fail();
                }      
            }
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
            Assert.IsTrue(csmDeviceDetailsPage.LogsCurrentPageNumber.Text == PageNumber.ToString());
        }

        [Given(@"logs are sorted by decreasing date")]
        public void GivenLogsAreSortedByDecreasingDate()
        {
            if (csmDeviceDetailsPage.DateSorting.GetAttribute("class") == "col-md-4 ascending")
            {
                csmDeviceDetailsPage.DateSorting.Click();
            }

            Assert.AreEqual("col-md-4 descending", csmDeviceDetailsPage.DateSorting.GetAttribute("class"),"Sorting Indicator is not as expected.");
        }


        [Given(@"logs are sorted by increasing date")]
        public void GivenLogsAreSortedByIncreasingDate()
        {
            if(csmDeviceDetailsPage.DateSorting.GetAttribute("class")== "col-md-4 descending")
            {
                csmDeviceDetailsPage.DateSorting.Click();
            }
            Assert.AreEqual("col-md-4 ascending", csmDeviceDetailsPage.DateSorting.GetAttribute("class"), "Sorting Indicator is not as expected.");
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
            Assert.AreEqual(true,csmDeviceDetailsPage.DateSorting.GetAttribute("class")==CSMDeviceDetailsPage.Locators.LogsDescendingClassName,"Decreasing date sorting indicator is not displayed");
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
        }

        [Then(@"(.*) logs for CSM device are displayed")]
        public void ThenLogsForCSMDeviceAreDisplayed(int logFilesCount)
        {
            int noOfLogFiles = csmDeviceDetailsPage.LogFiles.GetElementCount();
            Assert.AreEqual(true,  noOfLogFiles== logFilesCount, noOfLogFiles+" are displayed.");
        }

        [Given(@"(.*) newest logs are displayed")]
        public void GivenNewestLogsAreDisplayed(int num)
        {
            Assert.AreEqual(true, csmDeviceDetailsPage.NNewestLogsPresence(num), "Number of logs displayed are not as expected");
        }

        [Then(@"next (.*) older logs are displayed")]
        public void ThenUserWillSeeNextOlderLogs(int num)
        {
            Assert.AreEqual(true, csmDeviceDetailsPage.NOlderLogsPresence(num), "Number of Logs are not as expected");
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
