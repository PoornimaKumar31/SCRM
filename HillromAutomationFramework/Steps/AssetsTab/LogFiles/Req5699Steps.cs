using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AssetsTab;
using HillromAutomationFramework.PageObjects.AssetsTab.DeviceDetails;
using HillromAutomationFramework.PageObjects.AssetsTab.LogFiles;
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
        private readonly MainPage _mainPage;
        private readonly LogFilesPage _logFilesPage;

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
            _mainPage = new MainPage(driver);
            _logFilesPage = new LogFilesPage(driver);
        }

        [Given(@"user has selected CSM device")]
        public void GivenUserHasSelectedCSMDevice()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest2Title.Click();
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.AssetTypeDropDown.SelectDDL(MainPageExpectedValue.CSMDeviceName);
            Thread.Sleep(1000);
            _mainPage.SearchSerialNumberAndClick(LogFilesPageExpectedValue.CSM10LogFileDeviceSerialNumber);
            
        }

        [Given(@"user is on Device Details page")]
        public void GivenUserIsOnDeviceDetailsPage()
        {
            bool result = (_logFilesPage.ComponentInformationTab.GetElementVisibility()) || (_logFilesPage.LogsTab.GetElementVisibility());
            result.Should().BeTrue("User is not on device details page.");
        }



        [When(@"user clicks Logs tab")]
        public void WhenUserClicksLogsTab()
        {
            _wait.Until(ExplicitWait.ElementExists(By.XPath(LogFilesPage.Locator.LogsTabXpath)));
            _logFilesPage.LogsTab.Click();
        }

        [Then(@"logs for CSM device are displayed")]
        public void ThenLogsForCSMDeviceAreDisplayed()
        {
            Thread.Sleep(2000);
            _logFilesPage.LogFiles.Count.Should().BeGreaterThan(0,"log files are not displayed.");
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
                    _mainPage.SearchSerialNumberAndClick(LogFilesPageExpectedValue.CSMZeroLogFileDeviceSerialNumber);
                    break;

                case 10:
                    //selecting CSM device with 10 log files
                    _landingPage.LNTAutomatedTestOrganizationFacilityTest2Title.Click();
                    _wait.Until(ExplicitWait.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
                    _mainPage.SearchSerialNumberAndClick(LogFilesPageExpectedValue.CSM10LogFileDeviceSerialNumber);
                    break;
                case 24:
                    //selecting CSM device with 25 log files
                    _landingPage.LNTAutomatedTestOrganizationFacilityTest2Title.Click();
                    _wait.Until(ExplicitWait.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
                    _mainPage.SearchSerialNumberAndClick(LogFilesPageExpectedValue.CSM24LogFileDeviceSerialNumber);
                    break;
                default: Assert.Fail("Invalid number of logs \""+ noOfLogs+"\"");
                    break;
            }
            _wait.Until(ExplicitWait.ElementExists(By.XPath(LogFilesPage.Locator.LogsTabXpath)));
            _logFilesPage.LogsTab.Click();
        }

        [When(@"user clicks log")]
        public void WhenUserClicksLog()
        {
            (_logFilesPage.LogFiles.GetElementCount()).Should().BeGreaterThan(0,"Atleat one log should be present");
            _logFilesPage.LogFiles[0].Click();
        }

        [Then(@"log is downloaded to computer")]
        public void ThenLogIsDownloadedToComputer()
        {
            bool IsCSMLofFileDownloaded = GetMethods.IsFileDownloaded(_logFilesPage.LogFiles[0].Text, waitTimeInSeconds: 20);
            (IsCSMLofFileDownloaded).Should().BeTrue(because: "CSM Log file should be downloaded when user clicks First Log File in Logs page");
        }

        [Then(@"downloaded filename matches")]
        public void ThenDownloadedFilenameMatches()
        {
            File.Exists(PropertyClass.DownloadPath +"\\"+ _logFilesPage.LogFiles[0].Text).Should().BeTrue("download file name does not match the log file name.");
        }

        [Then(@"user cannot navigate to next logs page")]
        public void ThenUserCannotNavigateToNextLogsPage()
        {
            SetMethods.MoveTotheElement(_logFilesPage.NextPageIcon.FindElement(By.TagName("img")), _driver, "Next logs page icon");
            _logFilesPage.NextPageIcon.FindElement(By.TagName("img")).GetAttribute("src").Should().BeEquivalentTo(PropertyClass.BaseURL+ LogFilesPageExpectedValue.NextPageIconDisableImageURL, "Next page icon is not disabled.");
        }

        [Then(@"no logs for CSM device are displayed")]
        public void ThenNoLogsForCSMDeviceAreDisplayed()
        {
            _logFilesPage.LogFiles.GetElementCount().Should().Be(0,"Number of logs are not as expected");
        }


        [When(@"user clicks Next page button")]
        public void WhenUserClicksNextPageButton()
        {
            _logFilesPage.NextPageIcon.Click();
        }

        [Then(@"user will see logs page (.*) indicator")]
        public void ThenUserWillSeeLogsPageIndicator(int PageNumber)
        {
            _logFilesPage.PageNumber.Text.Should().BeEquivalentTo(PageNumber.ToString());
        }

        [Given(@"logs are sorted by decreasing date")]
        public void GivenLogsAreSortedByDecreasingDate()
        {
            if (_logFilesPage.DateColumn.GetAttribute("class") == "col-md-4 ascending")
            {
                _logFilesPage.DateColumn.ClickWebElement(_driver, "Sorting Arrow");
                SetMethods.WaitUntilTwoStringsAreEqual(_logFilesPage.DateColumn.GetAttribute("class"), "col-md-4 descending");
            }

            _logFilesPage.DateColumn.GetAttribute("class").Should().BeEquivalentTo("col-md-4 descending","Sorting Indicator is not as expected.");
            _logFilesPage.DateColumn.GetCssValue("background-image").Should().BeEquivalentTo("url(\""+PropertyClass.BaseURL + LogFilesPageExpectedValue.SortDecreasingIconURL+"\")");
            _logFilesPage.LogDateList.IsDateSorted("d").Should().BeTrue("Log file are not sorted in decreasing date");
        }


        [Given(@"logs are sorted by increasing date")]
        public void GivenLogsAreSortedByIncreasingDate()
        {
            if(_logFilesPage.DateColumn.GetAttribute("class")== "col-md-4 descending")
            {
                _logFilesPage.DateColumn.ClickWebElement(_driver, "Sorting Arrow");
                SetMethods.WaitUntilTwoStringsAreEqual(_logFilesPage.DateColumn.GetAttribute("class"), "col-md-4 ascending");
            }
            _logFilesPage.DateColumn.GetAttribute("class").Should().BeEquivalentTo("col-md-4 ascending", "Sorting Indicator is not as expected.");
            _logFilesPage.DateColumn.GetCssValue("background-image").Should().BeEquivalentTo("url(\"" + PropertyClass.BaseURL + LogFilesPageExpectedValue.SortIncreasingIconURL + "\")");
            _logFilesPage.LogDateList.IsDateSorted("a").Should().BeTrue("Log files are not sorted in increasing date");
        }

        [When(@"user clicks Date column heading")]
        public void WhenUserClicksDateColumnHeading()
        {
            _logFilesPage.DateColumn.ClickWebElement(_driver, "Date column Heading");
        }

        [Then(@"logs are sorted by decreasing date")]
        public void ThenLogsSortByDecreasingDate()
        {
            _logFilesPage.LogDateList.IsDateSorted("d").Should().BeTrue("Date is not sorted in the decreasing order");
        }

        [Then(@"decreasing date sorting indicator is displayed")]
        public void DecreasingDateSortingIndicatorIsDisplayed()
        {
            Thread.Sleep(3000);
            _logFilesPage.DateColumn.GetAttribute("class").Should().BeEquivalentTo(LogFilesPage.Locator.LogsDescendingClassName, "Decreasing date sorting indicator is not displayed");
            _logFilesPage.DateColumn.GetCssValue("background-image").Should().BeEquivalentTo("url(\"" + PropertyClass.BaseURL + LogFilesPageExpectedValue.SortDecreasingIconURL + "\")");
        }

        [Then(@"logs are sorted by increasing date")]
        public void ThenLogsSortByIncreasingDate()
        {
           _logFilesPage.LogDateList.IsDateSorted("a").Should().BeTrue("Logs are not sorted in increasing order");
        }

        [Then(@"increasing date sorting indicator is displayed")]
        public void IncreasingDateSortingIndicatorIsDisplayed()
        {
            _logFilesPage.DateColumn.GetAttribute("class").Should().BeEquivalentTo(LogFilesPage.Locator.LogsAscendingClassName,"Increasing date sorting indicator is not displayed");
            _logFilesPage.DateColumn.GetCssValue("background-image").Should().BeEquivalentTo("url(\"" + PropertyClass.BaseURL + LogFilesPageExpectedValue.SortIncreasingIconURL + "\")");
        }

        [Then(@"(.*) logs for CSM device are displayed")]
        public void ThenLogsForCSMDeviceAreDisplayed(int logFilesCount)
        {
            int noOfLogFiles = _logFilesPage.LogFiles.GetElementCount();
            noOfLogFiles.Should().Be(logFilesCount, noOfLogFiles+" are displayed.");
        }

        [Then(@"(.*) newest logs are displayed")]
        public void GivenNewestLogsAreDisplayed(int num)
        {
            _logFilesPage.NNewestLogsPresence(num).Should().BeTrue("Number of logs displayed are not as expected");
        }

        [Then(@"next (.*) older logs are displayed")]
        public void ThenUserWillSeeNextOlderLogs(int num)
        {
            _logFilesPage.NOlderLogsPresence(num).Should().BeTrue("Number of Logs are not as expected");
        }

        [Then(@"""(.*)"" pagination label is displayed")]
        public void ThenPaginationLabelIsDisplayed(string pageNumber)
        {
            _logFilesPage.PageNumber.GetElementVisibility().Should().BeTrue("Pagination label is not displayed");
            _logFilesPage.PageNumber.Text.Should().BeEquivalentTo(pageNumber, "page number is not as expected");
        }

        [Then(@"Next page icon is enabled")]
        public void ThenNextPageIconIsEnabled()
        {
            _logFilesPage.NextPageIcon.FindElement(By.TagName("img")).GetAttribute("src").Should().BeEquivalentTo(PropertyClass.BaseURL + LogFilesPageExpectedValue.NextPageIconEnableImageURL, "Button is not disabled");
        }

        [Then(@"Previous page icon is disabled")]
        public void ThenPreviousPageIconIsDisabled()
        {
            _logFilesPage.PreviousPageIcon.FindElement(By.TagName("img")).GetAttribute("src").Should().BeEquivalentTo(PropertyClass.BaseURL + LogFilesPageExpectedValue.PreviousPageIconDisableImageURL, "Button is not disabled");
        }

        [Then(@"Previous page icon is enabled")]
        public void ThenPreviousPageIconIsEnabled()
        {
            _logFilesPage.PreviousPageIcon.FindElement(By.TagName("img")).GetAttribute("src").Should().BeEquivalentTo(PropertyClass.BaseURL + LogFilesPageExpectedValue.PreviousPageIconEnableImageURL, "Button is not disabled");
        }

        [Then(@"Next page icon is disabled")]
        public void ThenNextPageIconIsDisabled()
        {
            _logFilesPage.NextPageIcon.FindElement(By.TagName("img")).GetAttribute("src").Should().BeEquivalentTo(PropertyClass.BaseURL+ LogFilesPageExpectedValue.NextPageIconDisableImageURL, "Button is not disabled");
        }


    }

}
