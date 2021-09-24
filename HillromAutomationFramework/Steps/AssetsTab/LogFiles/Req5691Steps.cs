using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AssetsTab;
using HillromAutomationFramework.PageObjects.AssetsTab.LogFiles;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.AssetsTab.LogFiles
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5691")]
    class Req5691Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly LogFilesPage _logFilesPage;

        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public Req5691Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _mainPage = new MainPage(driver);
            _landingPage = new LandingPage(driver);
            _logFilesPage = new LogFilesPage(driver);
        }

        [Given(@"user has selected CVSM device")]
        public void GivenUserHasSelectedCVSMDevice()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            
            _mainPage.AssetTypeDropDown.SelectDDL(MainPageExpectedValue.CVSMDeviceName);
            
            //select the row according to the data
            Thread.Sleep(2000);
            
            _mainPage.SearchSerialNumberAndClick(LogFilesPageExpectedValue.CVSM24LogFileDeviceSerialNumber);
        }

        [When(@"user clicks Logs tab")]
        public void WhenUserClicksLogsTab()
        {
            _wait.Until(ExplicitWait.ElementExists(By.XPath(LogFilesPage.Locator.LogsTabXpath)));
            _logFilesPage.LogsTab.Click();
        }

        [Given(@"user is on Device Details page")]
        public void GivenUserIsOnDeviceDetailsPage()
        {
            _logFilesPage.ComponentInformationTab.GetElementVisibility().Should().BeTrue("Request log button should be displayed in device detals page under logs tab.");
        }

        [Then(@"logs for CVSM device are displayed")]
        public void ThenLogsForCVSMDeviceAreDisplayed()
        {
            Thread.Sleep(2000);
            _logFilesPage.LogFiles.GetElementCount().Should().BeGreaterThan(0);
        }
        [Given(@"user is on CVSM Log Files page with (.*) logs")]
        public void GivenUserIsOnCVSMLogFilesPageWithLogs(int noOfLogs)
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.AssetTypeDropDown.SelectDDL(MainPageExpectedValue.CVSMDeviceName);
            Thread.Sleep(2000);

            switch (noOfLogs)
            {
                case 0:
                    //Selecting CVSM device with no log files
                    _mainPage.SearchSerialNumberAndClick(LogFilesPageExpectedValue.CVSMZeroLogFileDeviceSerialNumber);
                    break;

                case 10:
                    //selecting CVSM device with 10 log files
                    _mainPage.SearchSerialNumberAndClick(LogFilesPageExpectedValue.CVSM10LogFileDeviceSerialNumber);
                    break;
                case 24:
                    //selecting CVSM device with 24 log files
                    _mainPage.SearchSerialNumberAndClick(LogFilesPageExpectedValue.CVSM24LogFileDeviceSerialNumber);
                    break;
                default: Assert.Fail(noOfLogs + " is a invalid log files number.");
                    break;
            }
            _wait.Until(ExplicitWait.ElementExists(By.XPath(LogFilesPage.Locator.LogsTabXpath)));
            _logFilesPage.LogsTab.Click();
        }


        [Then(@"no logs for CVSM device are displayed")]
        public void ThenNoLogsForCVSMDeviceAreDisplayed()
        {
            _logFilesPage.LogFiles.GetElementCount().Should().Be(0, because:"No log files should be displayed.");
        }

        [Then(@"(.*) logs for CVSM device are displayed")]
        public void ThenLogsForCVSMDeviceAreDisplayed(int logfilesCount)
        {
            _logFilesPage.LogFiles.GetElementCount().Should().Be(logfilesCount, because: "Number of Logs should match expected logfiles count "+logfilesCount);
        }


        [Then(@"user cannot navigate to next logs page")]
        public void ThenUserCannotNavigateToNextLogsPage()
        {
            SetMethods.MoveTotheElement(_logFilesPage.NextPageIcon.FindElement(By.TagName("img")), _driver, "Next log page button");
            string ExpectedValue =PropertyClass.BaseURL+ LogFilesPageExpectedValue.NextPageIconDisableImageURL;
            _logFilesPage.NextPageIcon.FindElement(By.TagName("img")).GetAttribute("src").Should().BeEquivalentTo(ExpectedValue,"Button is not disabled");
        }

        [Then(@"(.*) newest logs are displayed")]
        public void GivenNewestLogsAreDisplayed(int num)
        {
            _logFilesPage.NNewestLogsPresence(num).Should().BeTrue(because: num+" number of newest logs are present.");
        }

        [When(@"user clicks Next page button")]
        public void WhenUserClicksNextPageButton()
        {
            _logFilesPage.NextPageIcon.Click();
            Thread.Sleep(2000);
        }

        [Then(@"next (.*) older logs are displayed")]
        public void ThenUserWillSeeNextLogs(int number)
        {
            _logFilesPage.NOlderLogsPresence(number).Should().BeTrue(because:number+" number of older logs should be present");
        }

        [Given(@"logs are sorted by decreasing date")]
        public void GivenLogsAreSortedByDecreasingDate()
        {
            Thread.Sleep(2000);
            if (_logFilesPage.DateColumn.GetAttribute("class")  == LogFilesPage.Locator.LogsAscendingClassName)
            {
                _logFilesPage.DateColumn.Click();
                Thread.Sleep(2000);
            }
            Thread.Sleep(2000);
            _logFilesPage.DateColumn.GetCssValue("background-image").Should().BeEquivalentTo("url(\"" + PropertyClass.BaseURL + LogFilesPageExpectedValue.SortDecreasingIconURL + "\")", "Icon displayed for sorting is not as expected");
            _logFilesPage.LogDateList.IsDateSorted("d").Should().BeTrue("Logs are not sorted by decreasing date");
        }


        [Given(@"logs are sorted by increasing date")]
        public void GivenLogsAreSortedByIncreasingDate()
        {
            Thread.Sleep(2000);
            if (_logFilesPage.DateColumn.GetAttribute("class").ToString() == LogFilesPage.Locator.LogsDescendingClassName)
            {
                _logFilesPage.DateColumn.Click();
                Thread.Sleep(2000);
            }
            Thread.Sleep(2000);
            _logFilesPage.DateColumn.GetAttribute("class").Should().BeEquivalentTo("col-md-4 ascending","Sorting indicator is not as expected.");
            _logFilesPage.DateColumn.GetCssValue("background-image").Should().BeEquivalentTo("url(\"" + PropertyClass.BaseURL + LogFilesPageExpectedValue.SortIncreasingIconURL + "\")", "Icon displayed for sorting is not as expected");
            _logFilesPage.LogDateList.IsDateSorted("a").Should().BeTrue("Logs are not sorted by increasing date");
        }

        [When(@"user clicks Date column heading")]
        public void WhenUserClicksDateColumnHeading()
        {
            _logFilesPage.DateColumn.ClickWebElement(_driver, "Date column Heading");
        }

        [Then(@"logs are sorted by decreasing date")]
        public void ThenLogsSortByDecreasingDate()
        {
            Thread.Sleep(3000);
            _logFilesPage.LogDateList.IsDateSorted("d").Should().BeTrue("log files are sorted by decreasing date.");
        }

        [Then(@"decreasing date sorting indicator is displayed")]
        public void DecreasingDateSortingIndicatorIsDisplayed()
        {
            _logFilesPage.DateColumn.GetCssValue("background-image").Should().BeEquivalentTo("url(\"" + PropertyClass.BaseURL + LogFilesPageExpectedValue.SortDecreasingIconURL + "\")","Icon displayed for sorting is not as expected");
        }

        [Then(@"logs are sorted by increasing date")]
        public void ThenLogsSortByIncreasingDate()
        {
            Thread.Sleep(3000);
            _logFilesPage.LogDateList.IsDateSorted("a").Should().BeTrue("Logs are not sorted by increasing date.");
        }

        [Then(@"increasing date sorting indicator is displayed")]
        public void IncreasingDateSortingIndicatorIsDisplayed()
        {
            _logFilesPage.DateColumn.GetCssValue("background-image").Should().BeEquivalentTo("url(\"" + PropertyClass.BaseURL + LogFilesPageExpectedValue.SortIncreasingIconURL + "\")", "Icon displayed for sorting is not as expected");
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
            _logFilesPage.NextPageIcon.FindElement(By.TagName("img")).GetAttribute("src").Should().BeEquivalentTo(PropertyClass.BaseURL+LogFilesPageExpectedValue.NextPageIconDisableImageURL, "Button is not disabled");
        }
    }
}
