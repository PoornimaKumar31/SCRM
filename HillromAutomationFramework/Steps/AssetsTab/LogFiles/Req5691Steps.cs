using FluentAssertions;
using HillromAutomationFramework.PageObjects;
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
        readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly CVSMDeviceDetailsPage _cvsmDeviceDetailsPage;
        private ScenarioContext _scenarioContext;

        public Req5691Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = new LoginPage();
            _mainPage = new MainPage();
            _landingPage = new LandingPage();
            _cvsmDeviceDetailsPage = new CVSMDeviceDetailsPage();
        }
        
        [Given(@"user has selected CVSM device")]
        public void GivenUserHasSelectedCVSMDevice()
        {
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            
            wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            
            _mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CVSMDeviceName);
            
            //select the row according to the data
            Thread.Sleep(2000);
            
            _mainPage.SearchSerialNumberAndClick("100020000001");
        }

        [When(@"user clicks Logs tab")]
        public void WhenUserClicksLogsTab()
        {
            wait.Until(ExplicitWait.ElementExists(By.Id(CVSMDeviceDetailsPage.Locators.LogsTabID)));
            _cvsmDeviceDetailsPage.LogsTab.Click();
        }

        [Given(@"user is on Device Details page")]
        public void GivenUserIsOnDeviceDetailsPage()
        {
            _cvsmDeviceDetailsPage.EditButton.GetElementVisibility().Should().BeTrue();
        }

        [Then(@"logs for CVSM device are displayed")]
        public void ThenLogsForCVSMDeviceAreDisplayed()
        {
            Thread.Sleep(2000);
            _cvsmDeviceDetailsPage.LogFiles.GetElementCount().Should().BeGreaterThan(0);
        }
        [Given(@"user is on CVSM Log Files page with (.*) logs")]
        public void GivenUserIsOnCVSMLogFilesPageWithLogs(int noOfLogs)
        {
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CVSMDeviceName);
            Thread.Sleep(2000);

            switch (noOfLogs)
            {
                case 0:
                    //Selecting CVSM device with no log files
                    _mainPage.SearchSerialNumberAndClick("100020000000");
                    wait.Until(ExplicitWait.ElementExists(By.Id(CVSMDeviceDetailsPage.Locators.LogsTabID)));
                    _cvsmDeviceDetailsPage.LogsTab.Click();
                    break;

                case 10:
                    //selecting CVSM device with 10 log files
                    _mainPage.SearchSerialNumberAndClick("100020000007");
                    wait.Until(ExplicitWait.ElementExists(By.Id(CVSMDeviceDetailsPage.Locators.LogsTabID)));
                    _cvsmDeviceDetailsPage.LogsTab.Click();
                    break;
                case 24:
                    //selecting CVSM device with 24 log files
                    _mainPage.SearchSerialNumberAndClick("100020000001");
                    wait.Until(ExplicitWait.ElementExists(By.Id(CVSMDeviceDetailsPage.Locators.LogsTabID)));
                    _cvsmDeviceDetailsPage.LogsTab.Click();
                    break;
                default: Assert.Fail(noOfLogs + " is a invalid log files number.");
                    break;
            }
        }


        [Then(@"no logs for CVSM device are displayed")]
        public void ThenNoLogsForCVSMDeviceAreDisplayed()
        {
            _cvsmDeviceDetailsPage.LogFiles.GetElementCount().Should().Be(0);
        }

        [Then(@"(.*) logs for CVSM device are displayed")]
        public void ThenLogsForCVSMDeviceAreDisplayed(int logfilesCount)
        {
            _cvsmDeviceDetailsPage.LogFiles.GetElementCount().Should().Be(logfilesCount, "Number of Logs are not as expected");
        }


        [Then(@"user cannot navigate to next logs page")]
        public void ThenUserCannotNavigateToNextLogsPage()
        {
            SetMethods.MoveTotheElement(_cvsmDeviceDetailsPage.LogsNextButton.FindElement(By.TagName("img")), "Next log page button");
            string ExpectedValue = CVSMDeviceDetailsPage.ExpectedValues.NextDisableImageURL;
            _cvsmDeviceDetailsPage.LogsNextButton.FindElement(By.TagName("img")).GetAttribute("src").Should().BeEquivalentTo(ExpectedValue,"Button is not disabled");
        }

        [Then(@"(.*) newest logs are displayed")]
        public void GivenNewestLogsAreDisplayed(int num)
        {
            _cvsmDeviceDetailsPage.NNewestLogsPresence(num).Should().BeTrue();
        }

        [When(@"user clicks Next page button")]
        public void WhenUserClicksNextPageButton()
        {
            _cvsmDeviceDetailsPage.LogsNextButton.Click();
            Thread.Sleep(2000);
        }

        [Then(@"next (.*) older logs are displayed")]
        public void ThenUserWillSeeNextLogs(int number)
        {
            _cvsmDeviceDetailsPage.NOlderLogsPresence(number).Should().BeTrue();
        }

        [Given(@"logs are sorted by decreasing date")]
        public void GivenLogsAreSortedByDecreasingDate()
        {
            Thread.Sleep(2000);
            if (_cvsmDeviceDetailsPage.DateSorting.GetAttribute("class") == CVSMDeviceDetailsPage.Locators.LogsAscendingClassName)
            {
                _cvsmDeviceDetailsPage.DateSorting.Click();
                Thread.Sleep(2000);
            }
            Thread.Sleep(2000);
            _cvsmDeviceDetailsPage.DateSorting.GetCssValue("background-image").Should().BeEquivalentTo(CVSMDeviceDetailsPage.ExpectedValues.SortDecreasingIconURL, "Icon displayed for sorting is not as expected");
            _cvsmDeviceDetailsPage.LogDateList.IsDateSorted("d").Should().BeTrue("Logs are not sorted by decreasing date");
        }


        [Given(@"logs are sorted by increasing date")]
        public void GivenLogsAreSortedByIncreasingDate()
        {
            Thread.Sleep(2000);
            if (_cvsmDeviceDetailsPage.DateSorting.GetAttribute("class").ToString() == CVSMDeviceDetailsPage.Locators.LogsDescendingClassName)
            {
                _cvsmDeviceDetailsPage.DateSorting.Click();
                Thread.Sleep(2000);
            }
            Thread.Sleep(2000);
            _cvsmDeviceDetailsPage.DateSorting.GetAttribute("class").Should().BeEquivalentTo("col-md-4 ascending","Sorting indicator is not as expected.");
            _cvsmDeviceDetailsPage.DateSorting.GetCssValue("background-image").Should().BeEquivalentTo(CVSMDeviceDetailsPage.ExpectedValues.SortIncreasingIconURL, "Icon displayed for sorting is not as expected");
            _cvsmDeviceDetailsPage.LogDateList.IsDateSorted("a").Should().BeTrue("Logs are not sorted by increasing date");
        }

        [When(@"user clicks Date column heading")]
        public void WhenUserClicksDateColumnHeading()
        {
            _cvsmDeviceDetailsPage.DateSorting.MoveTotheElement();
            _cvsmDeviceDetailsPage.DateSorting.Click();
        }

        [Then(@"logs are sorted by decreasing date")]
        public void ThenLogsSortByDecreasingDate()
        {
            Thread.Sleep(3000);
            _cvsmDeviceDetailsPage.LogDateList.IsDateSorted("d").Should().BeTrue("log files are sorted by decreasing date.");
        }

        [Then(@"decreasing date sorting indicator is displayed")]
        public void DecreasingDateSortingIndicatorIsDisplayed()
        {
            _cvsmDeviceDetailsPage.DateSorting.GetCssValue("background-image").Should().BeEquivalentTo(CVSMDeviceDetailsPage.ExpectedValues.SortDecreasingIconURL,"Icon displayed for sorting is not as expected");
        }

        [Then(@"logs are sorted by increasing date")]
        public void ThenLogsSortByIncreasingDate()
        {
            Thread.Sleep(3000);
            _cvsmDeviceDetailsPage.LogDateList.IsDateSorted("a").Should().BeTrue("Logs are not sorted by increasing date.");
        }

        [Then(@"increasing date sorting indicator is displayed")]
        public void IncreasingDateSortingIndicatorIsDisplayed()
        {
            _cvsmDeviceDetailsPage.DateSorting.GetCssValue("background-image").Should().BeEquivalentTo(CVSMDeviceDetailsPage.ExpectedValues.SortIncreasingIconURL, "Icon displayed for sorting is not as expected");
        }

        [Then(@"""(.*)"" pagination label is displayed")]
        public void ThenPaginationLabelIsDisplayed(string pageNumber)
        {
            _cvsmDeviceDetailsPage.LogsPageNumber.GetElementVisibility().Should().BeTrue("Pagination label is not displayed");
            _cvsmDeviceDetailsPage.LogsPageNumber.Text.Should().BeEquivalentTo(pageNumber, "page number is not as expected");
        }

        [Then(@"Next page icon is enabled")]
        public void ThenNextPageIconIsEnabled()
        {
            _cvsmDeviceDetailsPage.LogsNextButton.FindElement(By.TagName("img")).GetAttribute("src").Should().BeEquivalentTo(CSMDeviceDetailsPage.ExpectedValues.NextEnableImageURL, "Button is not disabled");
        }

        [Then(@"Previous page icon is disabled")]
        public void ThenPreviousPageIconIsDisabled()
        {
            _cvsmDeviceDetailsPage.LogsPreviousButton.FindElement(By.TagName("img")).GetAttribute("src").Should().BeEquivalentTo(CSMDeviceDetailsPage.ExpectedValues.PreviousDisableImageURL, "Button is not disabled");
        }

        [Then(@"Previous page icon is enabled")]
        public void ThenPreviousPageIconIsEnabled()
        {
            _cvsmDeviceDetailsPage.LogsPreviousButton.FindElement(By.TagName("img")).GetAttribute("src").Should().BeEquivalentTo(CSMDeviceDetailsPage.ExpectedValues.PreviousEnableImageURL, "Button is not disabled");
        }

        [Then(@"Next page icon is disabled")]
        public void ThenNextPageIconIsDisabled()
        {
            _cvsmDeviceDetailsPage.LogsNextButton.FindElement(By.TagName("img")).GetAttribute("src").Should().BeEquivalentTo(CSMDeviceDetailsPage.ExpectedValues.NextDisableImageURL, "Button is not disabled");
        }
    }
}
