using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AssetsTab;
using HillromAutomationFramework.PageObjects.AssetsTab.DeviceDetails;
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
    [Binding,Scope(Tag = "SoftwareRequirementID_5711")]
    class Req5711Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly RV700DeviceDetailsPage _rv700DeviceDetailsPage;

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
            _rv700DeviceDetailsPage = new RV700DeviceDetailsPage(driver);
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
            _mainPage.SearchSerialNumberAndClick("700090000004");
        }

        [When(@"user clicks Logs tab")]
        public void WhenUserClicksLogsTab()
        {
            _rv700DeviceDetailsPage.LogsTab.Click();
        }

        [Then(@"logs for RV700 device are displayed")]
        public void ThenLogsForRVDeviceAreDisplayed()
        {
            _rv700DeviceDetailsPage.LogFiles.GetElementCount().Should().BeGreaterThan(0,"number of logs are not as expected"); 
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
                    _mainPage.SearchSerialNumberAndClick("700090000009");
                    _wait.Until(ExplicitWait.ElementExists(By.Id(RV700DeviceDetailsPage.Locators.LogsTabID)));
                    _rv700DeviceDetailsPage.LogsTab.Click();
                    break;

                case 10:
                    //selecting RV700 device with 10 log files
                    _mainPage.SearchSerialNumberAndClick("700090000004");
                    _wait.Until(ExplicitWait.ElementExists(By.Id(RV700DeviceDetailsPage.Locators.LogsTabID)));
                    _rv700DeviceDetailsPage.LogsTab.Click();
                    break;
                case 24:
                    //selecting RV700 device with 24 log files
                    _mainPage.SearchSerialNumberAndClick("700090000001");
                    _wait.Until(ExplicitWait.ElementExists(By.Id(RV700DeviceDetailsPage.Locators.LogsTabID)));
                    _rv700DeviceDetailsPage.LogsTab.Click();
                    break;
            }
        }

        [Then(@"no logs for RV700 device are displayed")]
        public void ThenNoLogsForRV700DeviceAreDisplayed()
        {
            _rv700DeviceDetailsPage.LogFiles.GetElementCount().Should().Be(0,"Number of Logs are not 0");
        }

        [Then(@"(.*) logs for RV700 device are displayed")]
        public void ThenLogsForRVDeviceAreDisplayed(int ExpectedDeviceCount)
        {
            _rv700DeviceDetailsPage.LogFiles.GetElementCount().Should().Be(ExpectedDeviceCount, "Number of Logs is not same as expected");
        }


        [Then(@"user cannot navigate to next logs page")]
        public void ThenUserCannotNavigateToNextLogsPage()
        {
            _rv700DeviceDetailsPage.LogsNextButton.FindElement(By.TagName("img")).GetAttribute("src").Should().BeEquivalentTo(PropertyClass.BaseURL + DeviceDetailsPageExpectedValue.NextDisableImageURL, "Button is not disabled");
        }
        
        [When(@"user clicks Next page button")]
        public void WhenUserClicksNextPageButton()
        {
            _rv700DeviceDetailsPage.LogsNextButton.Click();
        }


        [Given(@"logs are sorted by decreasing date")]
        public void GivenLogsAreSortedByDecreasingDate()
        {
            if (_rv700DeviceDetailsPage.DateSorting.GetAttribute("class") == "col-md-4 ascending")
            {
                SetMethods.MoveTotheElement(_rv700DeviceDetailsPage.DateSorting, _driver, "Sorting Arrow");
                _rv700DeviceDetailsPage.DateSorting.Click();
                SetMethods.WaitUntilTwoStringsAreEqual(_rv700DeviceDetailsPage.DateSorting.GetAttribute("class"), "col-md-4 descending");
            }
            
            _rv700DeviceDetailsPage.DateSorting.GetCssValue("background-image").Should().BeEquivalentTo(DeviceDetailsPageExpectedValue.SortDecreasingIconURL, "Sorting icon is not as expected");
            _rv700DeviceDetailsPage.LogDateList.IsDateSorted("d").Should().BeTrue("Logs are not sorted by decreasing date");
        }

        [Given(@"logs are sorted by increasing date")]
        public void GivenLogsAreSortedByIncreasingDate()
        {
            if (_rv700DeviceDetailsPage.DateSorting.GetAttribute("class") == "col-md-4 descending")
            {
                SetMethods.MoveTotheElement(_rv700DeviceDetailsPage.DateSorting, _driver, "Sorting Arrow");
                _rv700DeviceDetailsPage.DateSorting.Click();
                SetMethods.WaitUntilTwoStringsAreEqual(_rv700DeviceDetailsPage.DateSorting.GetAttribute("class"), "col-md-4 ascending");
            }
            
            _rv700DeviceDetailsPage.DateSorting.GetCssValue("background-image").Should().BeEquivalentTo(DeviceDetailsPageExpectedValue.SortIncreasingIconURL, "Sorting icon is not as expected");
            _rv700DeviceDetailsPage.LogDateList.IsDateSorted("a").Should().BeTrue("Logs are not sorted by increasing date");
        }

        [When(@"user clicks Date column heading")]
        public void WhenUserClicksDateColumnHeading()
        {
            _rv700DeviceDetailsPage.DateSorting.MoveTotheElement(_driver);
            _rv700DeviceDetailsPage.DateSorting.Click();

        }

        [Then(@"logs are sorted by decreasing date")]
        public void ThenLogsSortByDecreasingDate()
        {
            _rv700DeviceDetailsPage.LogDateList.IsDateSorted("d").Should().BeTrue("Date is not sorted in decreasing order");
        }

        [Then(@"decreasing date sorting indicator is displayed")]
        public void DecreasingDateSortingIndicatorIsDisplayed()
        {
            _rv700DeviceDetailsPage.DateSorting.GetAttribute("class").Should().BeEquivalentTo("col-md-4 descending", "decreasing date sorting indicator is not displayed");
            _rv700DeviceDetailsPage.DateSorting.GetCssValue("background-image").Should().BeEquivalentTo(DeviceDetailsPageExpectedValue.SortDecreasingIconURL, "Sorting icon is not as expected");
        }

        [Then(@"logs are sorted by increasing date")]
        public void ThenLogsSortByIncreasingDate()
        {
            _rv700DeviceDetailsPage.LogDateList.IsDateSorted("a").Should().BeTrue("Date is not sorted in increasing order");
        }

        [Then(@"increasing date sorting indicator is displayed")]
        public void IncreasingDateSortingIndicatorDisplayed()
        {
            _rv700DeviceDetailsPage.DateSorting.GetAttribute("class").Should().BeEquivalentTo("col-md-4 ascending", "Icreasing date sorting date indicator is not displayed");
            _rv700DeviceDetailsPage.DateSorting.GetCssValue("background-image").Should().BeEquivalentTo(DeviceDetailsPageExpectedValue.SortIncreasingIconURL, "Sorting icon is not as expected");
        }

        [Then(@"(.*) newest logs are displayed")]
        public void ThenNewestLogsAreDisplayed(int num)
        {
            _rv700DeviceDetailsPage.NNewestLogsPresence(num).Should().BeTrue("Number of logs displayed are not as expected");
        }

        [Then(@"next (.*) older logs are displayed")]
        public void ThenNextOlderLogsAreDisplayed(int num)
        {
            _rv700DeviceDetailsPage.NOlderLogsPresence(num).Should().BeTrue("Number of Logs are not as expected");
        }

        [Then(@"""(.*)"" pagination label is displayed")]
        public void ThenPaginationLabelIsDisplayed(string pageNumber)
        {
            _rv700DeviceDetailsPage.LogsPageNumber.GetElementVisibility().Should().BeTrue( "Pagination label is not displayed");
            _rv700DeviceDetailsPage.LogsPageNumber.Text.Should().BeEquivalentTo(pageNumber, "page number is not as expected");
        }

        [Then(@"Next page icon is enabled")]
        public void ThenNextPageIconIsEnabled()
        {
            _rv700DeviceDetailsPage.LogsNextButton.FindElement(By.TagName("img")).GetAttribute("src").Should().BeEquivalentTo(PropertyClass.BaseURL + DeviceDetailsPageExpectedValue.NextEnableImageURL, "Button is not disabled");
        }

        [Then(@"Previous page icon is disabled")]
        public void ThenPreviousPageIconIsDisabled()
        {
            _rv700DeviceDetailsPage.LogsPreviousButton.FindElement(By.TagName("img")).GetAttribute("src").Should().BeEquivalentTo(PropertyClass.BaseURL + DeviceDetailsPageExpectedValue.PreviousDisableImageURL, "Button is not disabled");
        }

        [Then(@"Previous page icon is enabled")]
        public void ThenPreviousPageIconIsEnabled()
        {
            _rv700DeviceDetailsPage.LogsPreviousButton.FindElement(By.TagName("img")).GetAttribute("src").Should().BeEquivalentTo(PropertyClass.BaseURL + DeviceDetailsPageExpectedValue.PreviousEnableImageURL, "Button is not disabled");
        }

        [Then(@"Next page icon is disabled")]
        public void ThenNextPageIconIsDisabled()
        {
            _rv700DeviceDetailsPage.LogsNextButton.FindElement(By.TagName("img")).GetAttribute("src").Should().BeEquivalentTo(PropertyClass.BaseURL+DeviceDetailsPageExpectedValue.NextDisableImageURL, "Button is not disabled");
        }

    }
}
