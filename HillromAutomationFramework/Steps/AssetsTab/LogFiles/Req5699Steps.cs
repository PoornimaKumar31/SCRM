using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.AssetsTab.LogFiles
{
    [Binding, Scope(Tag ="SoftwareRequirementID_5699")]
    class Req5699Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly CSMDeviceDetailsPage _csmDeviceDetailsPage;
        private readonly MainPage _mainPage;
        private readonly DeviceDetailsPage _deviceDetailsPage;

        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public Req5699Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _csmDeviceDetailsPage = new CSMDeviceDetailsPage(driver);
            _mainPage = new MainPage(driver);
            _deviceDetailsPage = new DeviceDetailsPage(driver);
        }

        [Given(@"user has selected CSM device")]
        public void GivenUserHasSelectedCSMDevice()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest2Title.Click();
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CSMDeviceName);
            Thread.Sleep(1000);
            _mainPage.SearchSerialNumberAndClick("110010000019");
            
        }

        [Given(@"user is on Device Details page")]
        public void GivenUserIsOnDeviceDetailsPage()
        {
            bool result = (_deviceDetailsPage.AssetLabel.GetElementVisibility()) || (_deviceDetailsPage.AssetData.GetElementVisibility());
            result.Should().BeTrue("User is not on device details page.");
        }



        [When(@"user clicks Logs tab")]
        public void WhenUserClicksLogsTab()
        {
            _wait.Until(ExplicitWait.ElementExists(By.Id(CSMDeviceDetailsPage.Locators.LogsTabID)));
            _csmDeviceDetailsPage.LogsTab.Click();
        }

        [Then(@"logs for CSM device are displayed")]
        public void ThenLogsForCSMDeviceAreDisplayed()
        {
            Thread.Sleep(2000);
            _csmDeviceDetailsPage.LogFiles.Count.Should().BeGreaterThan(0,"log files are not displayed.");
        }

        [Given(@"user is on CSM Log Files page with (.*) logs")]
        public void GivenUserIsOnCSMLogFilesPageWithLogs(int noOfLogs)
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            switch (noOfLogs)
            {
                case 0:
                    //Selecting CSM device with no log files
                    _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
                    _wait.Until(ExplicitWait.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
                    _mainPage.SearchSerialNumberAndClick("100010000005");
                    _wait.Until(ExplicitWait.ElementExists(By.Id(CSMDeviceDetailsPage.Locators.LogsTabID)));
                    _csmDeviceDetailsPage.LogsTab.Click();
                    break;

                case 10:
                    //selecting CSM device with 10 log files
                    _landingPage.LNTAutomatedTestOrganizationFacilityTest2Title.Click();
                    _wait.Until(ExplicitWait.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
                    _mainPage.SearchSerialNumberAndClick("110010000019");
                    _wait.Until(ExplicitWait.ElementExists(By.Id(CSMDeviceDetailsPage.Locators.LogsTabID)));
                    _csmDeviceDetailsPage.LogsTab.Click();
                    break;
                case 24:
                    //selecting CSM device with 25 log files
                    _landingPage.LNTAutomatedTestOrganizationFacilityTest2Title.Click();
                    _wait.Until(ExplicitWait.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
                    _mainPage.SearchSerialNumberAndClick("110010000000");
                    _wait.Until(ExplicitWait.ElementExists(By.Id(CSMDeviceDetailsPage.Locators.LogsTabID)));
                    _csmDeviceDetailsPage.LogsTab.Click();
                    break;
                default: Assert.Fail("Invalid number of logs \""+ noOfLogs+"\"");
                    break;
            }
        }

        [When(@"user clicks log")]
        public void WhenUserClicksLog()
        {
            _csmDeviceDetailsPage.LogFiles[0].Click();   
        }

        [Then(@"log is downloaded to computer")]
        public void ThenLogIsDownloadedToComputer()
        {
            bool IsCSMLofFileDownloaded = GetMethods.IsFileDownloaded(_csmDeviceDetailsPage.LogFiles[0].Text, waitTimeInSeconds: 20);
            (IsCSMLofFileDownloaded).Should().BeTrue(because: "CSM Log file should be downloaded when user clicks First Log File in Logs page");
        }

        [Then(@"downloaded filename matches")]
        public void ThenDownloadedFilenameMatches()
        {
            File.Exists(PropertyClass.DownloadPath +"\\"+ _csmDeviceDetailsPage.LogFiles[0].Text).Should().BeTrue("download file name does not match the log file name.");
        }

        [Then(@"user cannot navigate to next logs page")]
        public void ThenUserCannotNavigateToNextLogsPage()
        {
            SetMethods.MoveTotheElement(_csmDeviceDetailsPage.LogsNextButton.FindElement(By.TagName("img")), _driver, "Next logs page");
            _csmDeviceDetailsPage.LogsNextButton.FindElement(By.TagName("img")).GetAttribute("src").Should().BeEquivalentTo(CSMDeviceDetailsPage.ExpectedValues.NextDisableImageURL, "Next page icon is not disabled.");
        }

        [Then(@"no logs for CSM device are displayed")]
        public void ThenNoLogsForCSMDeviceAreDisplayed()
        {
            _csmDeviceDetailsPage.LogFiles.GetElementCount().Should().Be(0,"Number of logs are not as expected");
        }


        [When(@"user clicks Next page button")]
        public void WhenUserClicksNextPageButton()
        {
            _csmDeviceDetailsPage.LogsNextButton.Click();
        }

        [Then(@"user will see logs page (.*) indicator")]
        public void ThenUserWillSeeLogsPageIndicator(int PageNumber)
        {
            _csmDeviceDetailsPage.LogsPageNumber.Text.Should().BeEquivalentTo(PageNumber.ToString());
        }

        [Given(@"logs are sorted by decreasing date")]
        public void GivenLogsAreSortedByDecreasingDate()
        {
            if (_csmDeviceDetailsPage.DateSorting.GetAttribute("class") == "col-md-4 ascending")
            {
                _csmDeviceDetailsPage.DateSorting.MoveTotheElement(_driver, "Sorting Arrow");
                _csmDeviceDetailsPage.DateSorting.Click();
                SetMethods.WaitUntilTwoStringsAreEqual(_csmDeviceDetailsPage.DateSorting.GetAttribute("class"), "col-md-4 descending");
            }

            _csmDeviceDetailsPage.DateSorting.GetAttribute("class").Should().BeEquivalentTo("col-md-4 descending","Sorting Indicator is not as expected.");
            _csmDeviceDetailsPage.DateSorting.GetCssValue("background-image").Should().BeEquivalentTo(CSMDeviceDetailsPage.ExpectedValues.SortDecreasingIconURL);
            _csmDeviceDetailsPage.LogDateList.IsDateSorted("d").Should().BeTrue("Log file are not sorted in decreasing date");
        }


        [Given(@"logs are sorted by increasing date")]
        public void GivenLogsAreSortedByIncreasingDate()
        {
            if(_csmDeviceDetailsPage.DateSorting.GetAttribute("class")== "col-md-4 descending")
            {
                _csmDeviceDetailsPage.DateSorting.MoveTotheElement(_driver, "Sorting Arrow");
                _csmDeviceDetailsPage.DateSorting.Click();
                SetMethods.WaitUntilTwoStringsAreEqual(_csmDeviceDetailsPage.DateSorting.GetAttribute("class"), "col-md-4 ascending");
            }
            _csmDeviceDetailsPage.DateSorting.GetAttribute("class").Should().BeEquivalentTo("col-md-4 ascending", "Sorting Indicator is not as expected.");
            _csmDeviceDetailsPage.DateSorting.GetCssValue("background-image").Should().BeEquivalentTo(CSMDeviceDetailsPage.ExpectedValues.SortIncreasingIconURL);
            _csmDeviceDetailsPage.LogDateList.IsDateSorted("a").Should().BeTrue("Log files are not sorted in increasing date");
        }

        [When(@"user clicks Date column heading")]
        public void WhenUserClicksDateColumnHeading()
        {
            _csmDeviceDetailsPage.DateSorting.MoveTotheElement(_driver, "Date column Heading");
            _csmDeviceDetailsPage.DateSorting.Click();
        }

        [Then(@"logs are sorted by decreasing date")]
        public void ThenLogsSortByDecreasingDate()
        {
            _csmDeviceDetailsPage.LogDateList.IsDateSorted("d").Should().BeTrue("Date is not sorted in the decreasing order");
        }

        [Then(@"decreasing date sorting indicator is displayed")]
        public void DecreasingDateSortingIndicatorIsDisplayed()
        {
            Thread.Sleep(3000);
            _csmDeviceDetailsPage.DateSorting.GetAttribute("class").Should().BeEquivalentTo(CSMDeviceDetailsPage.Locators.LogsDescendingClassName, "Decreasing date sorting indicator is not displayed");
            _csmDeviceDetailsPage.DateSorting.GetCssValue("background-image").Should().BeEquivalentTo(CSMDeviceDetailsPage.ExpectedValues.SortDecreasingIconURL);
        }

        [Then(@"logs are sorted by increasing date")]
        public void ThenLogsSortByIncreasingDate()
        {
            _csmDeviceDetailsPage.LogDateList.IsDateSorted("a").Should().BeTrue("Logs are not sorted in increasing order");
        }

        [Then(@"increasing date sorting indicator is displayed")]
        public void IncreasingDateSortingIndicatorIsDisplayed()
        {
            _csmDeviceDetailsPage.DateSorting.GetAttribute("class").Should().BeEquivalentTo(CSMDeviceDetailsPage.Locators.LogsAscendingClassName,"Increasing date sorting indicator is not displayed");
            _csmDeviceDetailsPage.DateSorting.GetCssValue("background-image").Should().BeEquivalentTo(CSMDeviceDetailsPage.ExpectedValues.SortIncreasingIconURL);
        }

        [Then(@"(.*) logs for CSM device are displayed")]
        public void ThenLogsForCSMDeviceAreDisplayed(int logFilesCount)
        {
            int noOfLogFiles = _csmDeviceDetailsPage.LogFiles.GetElementCount();
            noOfLogFiles.Should().Be(logFilesCount, noOfLogFiles+" are displayed.");
        }

        [Then(@"(.*) newest logs are displayed")]
        public void GivenNewestLogsAreDisplayed(int num)
        {
            _csmDeviceDetailsPage.NNewestLogsPresence(num).Should().BeTrue("Number of logs displayed are not as expected");
        }

        [Then(@"next (.*) older logs are displayed")]
        public void ThenUserWillSeeNextOlderLogs(int num)
        {
            _csmDeviceDetailsPage.NOlderLogsPresence(num).Should().BeTrue("Number of Logs are not as expected");
        }

        [Then(@"""(.*)"" pagination label is displayed")]
        public void ThenPaginationLabelIsDisplayed(string pageNumber)
        {
            _csmDeviceDetailsPage.LogsPageNumber.GetElementVisibility().Should().BeTrue("Pagination label is not displayed");
            _csmDeviceDetailsPage.LogsPageNumber.Text.Should().BeEquivalentTo(pageNumber, "page number is not as expected");
        }

        [Then(@"Next page icon is enabled")]
        public void ThenNextPageIconIsEnabled()
        {
            _csmDeviceDetailsPage.LogsNextButton.FindElement(By.TagName("img")).GetAttribute("src").Should().BeEquivalentTo(CSMDeviceDetailsPage.ExpectedValues.NextEnableImageURL, "Button is not disabled");
        }

        [Then(@"Previous page icon is disabled")]
        public void ThenPreviousPageIconIsDisabled()
        {
            _csmDeviceDetailsPage.LogsPreviousButton.FindElement(By.TagName("img")).GetAttribute("src").Should().BeEquivalentTo(CSMDeviceDetailsPage.ExpectedValues.PreviousDisableImageURL, "Button is not disabled");
        }

        [Then(@"Previous page icon is enabled")]
        public void ThenPreviousPageIconIsEnabled()
        {
            _csmDeviceDetailsPage.LogsPreviousButton.FindElement(By.TagName("img")).GetAttribute("src").Should().BeEquivalentTo(CSMDeviceDetailsPage.ExpectedValues.PreviousEnableImageURL, "Button is not disabled");
        }

        [Then(@"Next page icon is disabled")]
        public void ThenNextPageIconIsDisabled()
        {
            _csmDeviceDetailsPage.LogsNextButton.FindElement(By.TagName("img")).GetAttribute("src").Should().BeEquivalentTo(CSMDeviceDetailsPage.ExpectedValues.NextDisableImageURL, "Button is not disabled");
        }


    }

}
