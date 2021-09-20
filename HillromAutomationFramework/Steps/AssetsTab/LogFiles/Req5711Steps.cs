using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AssetsTab;
using HillromAutomationFramework.PageObjects.AssetsTab.DeviceDetails;
using HillromAutomationFramework.PageObjects.AssetsTab.LogFiles;
using HillromAutomationFramework.SupportingCode;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.AssetsTab.LogFiles
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5711")]
    class Req5711Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly LogFilesPage _logFilesPage;

        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverWait _wait;

        public Req5711Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
            _logFilesPage = new LogFilesPage(driver);
        }

        [Given(@"user has selected RV700 device")]
        public void GivenUserHasSelectedRV700Device()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.AssetTypeDropDown.SelectDDL(MainPageExpectedValue.RV700DeviceName);
            Thread.Sleep(1000);
        }

        [Given(@"user is on Main page")]
        public void GivenUserIsOnMainPage()
        {
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.AssetsTabID)));
            _mainPage.AssetsTab.GetElementVisibility().Should().BeTrue( "Assets tab is not displayed");
            _mainPage.SearchSerialNumberAndClick(LogFilesPageExpectedValue.RV70010LogFilesDeviceSerialNumber);
        }

        [When(@"user clicks Logs tab")]
        public void WhenUserClicksLogsTab()
        {
            _logFilesPage.LogsTab.Click();
        }

        [Then(@"logs for RV700 device are displayed")]
        public void ThenLogsForRVDeviceAreDisplayed()
        {
            _logFilesPage.LogFiles.GetElementCount().Should().BeGreaterThan(0,"number of logs are not as expected"); 
        }
  
        [Given(@"user is on RV700 Log Files page with (.*) logs")]
        public void GivenUserIsOnRVLogFilesPageWithLogs(int noOfLogs)
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.ClickWebElement(_driver);
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.AssetTypeDropDown.SelectDDL(MainPageExpectedValue.RV700DeviceName);         
            Thread.Sleep(2000);

            switch (noOfLogs)
            {
                case 0:
                    //Selecting RV700 device with no log files
                    _mainPage.SearchSerialNumberAndClick(LogFilesPageExpectedValue.RV700ZeroLogFileDeviceSerialNumber);
                    break;

                case 10:
                    //selecting RV700 device with 10 log files
                    _mainPage.SearchSerialNumberAndClick(LogFilesPageExpectedValue.RV70010LogFilesDeviceSerialNumber);
                    break;
                case 24:
                    //selecting RV700 device with 24 log files
                    _mainPage.SearchSerialNumberAndClick(LogFilesPageExpectedValue.RV70024LogFilesDeviceSerialNumber);
                    break;
            }
            _wait.Until(ExplicitWait.ElementExists(By.XPath(LogFilesPage.Locator.LogsTabXpath)));
            _logFilesPage.LogsTab.Click();
        }

        [Then(@"no logs for RV700 device are displayed")]
        public void ThenNoLogsForRV700DeviceAreDisplayed()
        {
            _logFilesPage.LogFiles.GetElementCount().Should().Be(0,"Number of Logs are not 0");
        }

        [Then(@"(.*) logs for RV700 device are displayed")]
        public void ThenLogsForRVDeviceAreDisplayed(int ExpectedDeviceCount)
        {
            _logFilesPage.LogFiles.GetElementCount().Should().Be(ExpectedDeviceCount, "Number of Logs is not same as expected");
        }


        [Then(@"user cannot navigate to next logs page")]
        public void ThenUserCannotNavigateToNextLogsPage()
        {
            _logFilesPage.NextPageIcon.FindElement(By.TagName("img")).GetAttribute("src").Should().BeEquivalentTo(PropertyClass.BaseURL + LogFilesPageExpectedValue.NextPageIconDisableImageURL, "Button is not disabled");
        }
        
        [When(@"user clicks Next page button")]
        public void WhenUserClicksNextPageButton()
        {
            _logFilesPage.NextPageIcon.Click();
        }


        [Given(@"logs are sorted by decreasing date")]
        public void GivenLogsAreSortedByDecreasingDate()
        {
            if (_logFilesPage.DateColumn.GetAttribute("class") == "col-md-4 ascending")
            {
                _logFilesPage.DateColumn.ClickWebElement(_driver, "Sorting Arrow");
                SetMethods.WaitUntilTwoStringsAreEqual(_logFilesPage.DateColumn.GetAttribute("class"), "col-md-4 descending");
            }
            
            _logFilesPage.DateColumn.GetCssValue("background-image").Should().BeEquivalentTo("url(\"" + PropertyClass.BaseURL + LogFilesPageExpectedValue.SortDecreasingIconURL + "\")", "Sorting icon is not as expected");
            _logFilesPage.LogDateList.IsDateSorted("d").Should().BeTrue("Logs are not sorted by decreasing date");
        }

        [Given(@"logs are sorted by increasing date")]
        public void GivenLogsAreSortedByIncreasingDate()
        {
            if (_logFilesPage.DateColumn.GetAttribute("class") == "col-md-4 descending")
            {
                _logFilesPage.DateColumn.ClickWebElement(_driver, "Sorting Arrow");
                SetMethods.WaitUntilTwoStringsAreEqual(_logFilesPage.DateColumn.GetAttribute("class"), "col-md-4 ascending");
            }
            
            _logFilesPage.DateColumn.GetCssValue("background-image").Should().BeEquivalentTo("url(\"" + PropertyClass.BaseURL + LogFilesPageExpectedValue.SortIncreasingIconURL + "\")", "Sorting icon is not as expected");
            _logFilesPage.LogDateList.IsDateSorted("a").Should().BeTrue("Logs are not sorted by increasing date");
        }

        [When(@"user clicks Date column heading")]
        public void WhenUserClicksDateColumnHeading()
        {
            _logFilesPage.DateColumn.ClickWebElement(_driver, "date column");
        }

        [Then(@"logs are sorted by decreasing date")]
        public void ThenLogsSortByDecreasingDate()
        {
            _logFilesPage.LogDateList.IsDateSorted("d").Should().BeTrue("Date is not sorted in decreasing order");
        }

        [Then(@"decreasing date sorting indicator is displayed")]
        public void DecreasingDateSortingIndicatorIsDisplayed()
        {
            _logFilesPage.DateColumn.GetAttribute("class").Should().BeEquivalentTo("col-md-4 descending", "decreasing date sorting indicator is not displayed");
            _logFilesPage.DateColumn.GetCssValue("background-image").Should().BeEquivalentTo("url(\"" + PropertyClass.BaseURL+ LogFilesPageExpectedValue.SortDecreasingIconURL+"\")", "Sorting icon is not as expected");
        }

        [Then(@"logs are sorted by increasing date")]
        public void ThenLogsSortByIncreasingDate()
        {
            _logFilesPage.LogDateList.IsDateSorted("a").Should().BeTrue("Date is not sorted in increasing order");
        }

        [Then(@"increasing date sorting indicator is displayed")]
        public void IncreasingDateSortingIndicatorDisplayed()
        {
            _logFilesPage.DateColumn.GetAttribute("class").Should().BeEquivalentTo("col-md-4 ascending", "Icreasing date sorting date indicator is not displayed");
            _logFilesPage.DateColumn.GetCssValue("background-image").Should().BeEquivalentTo("url(\"" + PropertyClass.BaseURL + LogFilesPageExpectedValue.SortIncreasingIconURL + "\")", "Sorting icon is not as expected");
        }

        [Then(@"(.*) newest logs are displayed")]
        public void ThenNewestLogsAreDisplayed(int num)
        {
            _logFilesPage.NNewestLogsPresence(num).Should().BeTrue("Number of logs displayed are not as expected");
        }

        [Then(@"next (.*) older logs are displayed")]
        public void ThenNextOlderLogsAreDisplayed(int num)
        {
            _logFilesPage.NOlderLogsPresence(num).Should().BeTrue("Number of Logs are not as expected");
        }

        [Then(@"""(.*)"" pagination label is displayed")]
        public void ThenPaginationLabelIsDisplayed(string pageNumber)
        {
            _logFilesPage.PageNumber.GetElementVisibility().Should().BeTrue( "Pagination label is not displayed");
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
