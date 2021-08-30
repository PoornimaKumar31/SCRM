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
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding, Scope(Tag ="SoftwareRequirementID_5699")]
    class Req5699Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        CSMDeviceDetailsPage csmDeviceDetailsPage = new CSMDeviceDetailsPage();
        
        readonly MainPage mainPage = new MainPage();
        readonly DeviceDetailsPage deviceDetailsPage = new DeviceDetailsPage();


        readonly private ScenarioContext _scenarioContext;
        readonly private WebDriverWait _wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

        public Req5699Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"user has selected CSM device")]
        public void GivenUserHasSelectedCSMDevice()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest2Title.Click();
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
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
            _wait.Until(ExplicitWait.ElementExists(By.Id(CSMDeviceDetailsPage.Locators.LogsTabID)));
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
                    _wait.Until(ExplicitWait.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
                    mainPage.SearchSerialNumberAndClick("100010000005");
                    _wait.Until(ExplicitWait.ElementExists(By.Id(CSMDeviceDetailsPage.Locators.LogsTabID)));
                    csmDeviceDetailsPage.LogsTab.Click();
                    break;

                case 10:
                    //selecting CSM device with 10 log files
                    landingPage.LNTAutomatedTestOrganizationFacilityTest2Title.Click();
                    _wait.Until(ExplicitWait.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
                    mainPage.SearchSerialNumberAndClick("110010000019");
                    _wait.Until(ExplicitWait.ElementExists(By.Id(CSMDeviceDetailsPage.Locators.LogsTabID)));
                    csmDeviceDetailsPage.LogsTab.Click();
                    break;
                case 24:
                    //selecting CSM device with 25 log files
                    landingPage.LNTAutomatedTestOrganizationFacilityTest2Title.Click();
                    _wait.Until(ExplicitWait.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
                    mainPage.SearchSerialNumberAndClick("110010000000");
                    _wait.Until(ExplicitWait.ElementExists(By.Id(CSMDeviceDetailsPage.Locators.LogsTabID)));
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
            SetMethods.MoveTotheElement(csmDeviceDetailsPage.LogsNextButton.FindElement(By.TagName("img")), "Next logs page");
            Assert.AreEqual(CSMDeviceDetailsPage.ExpectedValues.NextDisableImageURL, csmDeviceDetailsPage.LogsNextButton.FindElement(By.TagName("img")).GetAttribute("src"), "Next page icon is not disabled.");
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
