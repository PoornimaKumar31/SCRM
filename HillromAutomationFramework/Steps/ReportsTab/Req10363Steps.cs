using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.ReportsTab;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.ReportsTab
{
    [Binding, Scope(Tag = "SoftwareRequirementID_10363")]
    public class Req10363Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly ReportsPage _reportsPage;
        private readonly ActivityReportPage _activityReportPage;

        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverWait _wait;
        private readonly IWebDriver _driver;

        public Req10363Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
            _reportsPage = new ReportsPage(driver);
            _activityReportPage = new ActivityReportPage(driver);
        }


        [Given(@"user is on Reports page")]
        public void GivenUserIsOnReportsPage()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(_landingPage.PSSServiceOrganizationFacilityBatesville, _driver, "Progressa Orgaization");
            _landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.ReportsTab.JavaSciptClick(_driver);
        }
        
        [Given(@"Progressa Asset type is selected")]
        public void GivenProgressaAssetTypeIsSelected()
        {
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPageExpectedValues.ProgressaDeviceName);
        }
        
        [When(@"user clicks report type dropdown")]
        public void WhenUserClicksReportTypeDropdown()
        {
            _reportsPage.ReportTypeDDL.Click();
        }
        
        [Then(@"Report type dropdown displays ""(.*)""")]
        public void ThenReportTypeDropdownDisplays(string ExpectedOptions)
        {
            List<string> ExpectedOptionList = new List<string>(ExpectedOptions.ToLower().Split(", "));
            List<string> ActualOptionList = new List<string>(_reportsPage.ReportTypeDDL.GetAllOptionsFromDDL().Select(x => x.Text.ToLower()));
            //Removing hidden option
            ActualOptionList.Remove("select");
            //Asserting
            ActualOptionList.Should().BeEquivalentTo(ExpectedOptionList,"Expected Options are not same as Actual");
        }

        [Given(@"Activity Report type is selected")]
        public void GivenActivityReportTypeIsSelected()
        {
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.ActivityReportType);
        }

        [When(@"user clicks Get report button")]
        public void WhenUserClicksGetReportButton()
        {
            _reportsPage.GetReportButton.Click();
        }

        [Then(@"Activity Report \(Progressa\) label is displayed")]
        public void ThenActivityReportProgressaLabelIsDisplayed()
        {
            (_activityReportPage.ActivityReportHeader.GetElementVisibility()).Should().BeTrue("Activity Report (Progressa) label should be displayed in Progressa Activity Report Page.");
            (_activityReportPage.ActivityReportHeader.Text).Should().BeEquivalentTo(ActivityReportPageExpectedValues.ActivityReportProgressaHeader, because: "Activity report header should match the expected value in Progressa Activity Report Page.");
        }

        [Then(@"Print button is displayed")]
        public void ThenPrintButtonIsDisplayed()
        {
            (_activityReportPage.PrintButton.GetElementVisibility()).Should().BeTrue("Print button should be displayed in Progressa Activity Report Page.");
        }

        [Then(@"Download button is displayed")]
        public void ThenDownloadButtonIsDisplayed()
        {
            (_activityReportPage.DownloadButton.GetElementVisibility()).Should().BeTrue("Download button should be displayed in Progressa Activity Report Page.");
        }

        [Then(@"Search box is displayed")]
        public void ThenSearchBoxIsDisplayed()
        {
            (_activityReportPage.SearchBox.GetElementVisibility()).Should().BeTrue(because: "Search box should be displayed in Progressa Activity Report Page.");
        }

        [Then(@"Previous page icon is displayed")]
        public void ThenPreviousPageIconIsDisplayed()
        {
            (_activityReportPage.PaginationPreviousPageIcon.GetElementVisibility()).Should().BeTrue(because: "Previous page icon should be displayed in Progressa Activity Report Page.");
        }

        [Then(@"Next page icon is displayed")]
        public void ThenNextPageIconIsDisplayed()
        {
            (_activityReportPage.PaginationNextPageIcon.GetElementVisibility()).Should().BeTrue(because: "Next page icon should be displayed in Progressa Activity Report Page.");
        }

        [Then(@"Page x of y indicator is displayed")]
        public void ThenPageXOfYIndicatorIsDisplayed()
        {
            (_activityReportPage.PaginationPageXofY.GetElementVisibility()).Should().BeTrue(because: "Page x of y indicator should be displayed in Progressa Activity Report Page.");
        }

        [Then(@"Displaying x to y of z results indicator is displayed")]
        public void ThenDisplayingXToYOfZResultsIndicatorIsDisplayed()
        {
            (_activityReportPage.PaginationDisplayXY.GetElementVisibility()).Should().BeTrue(because: "Display x to y of z results label should be displayed in Progressa Activity Report Page.");
        }

        [Given(@"user is on Progressa Activity Report page")]
        public void GivenUserIsOnProgressaActivityReportPage()
        {
            GivenUserIsOnReportsPage();
            //Selecting Progressa device
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPageExpectedValues.ProgressaDeviceName);
            //Selecting the Activity Report
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.ActivityReportType);
            _reportsPage.GetReportButton.Click();
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string columnHeading)
        {
            IWebElement column = null;

            switch (columnHeading.ToLower().Trim())
            {
                case "serial number":
                    column = _activityReportPage.SerialNumberHeading;
                    break;

                case "ap location":
                    column = _activityReportPage.LocationHeading;
                    break;

                case "patient present":
                    column = _activityReportPage.PatientPresentHeading;
                    break;

                case "pm due":
                    column = _activityReportPage.PMDueHeading;
                    break;

                default:
                    Assert.Fail(columnHeading + " is a invalid heading name.");
                    break;
            }
            (column.GetElementVisibility()).Should().BeTrue(because: columnHeading + " should be displayed in Progressa Activity Report Page Table.");
            string ActualcolumnName = column.Text;
            (ActualcolumnName).Should().BeEquivalentTo(columnHeading, because: columnHeading + " column heading should match with the expected value in Progressa Activity Report Page Table.");
        }

        [Then(@"""(.*)"" label is in column (.*)")]
        public void ThenLabelIsInColumn(string columnHeading, int columnNumber)
        {
            IList<IWebElement> columnsList = _activityReportPage.TableHeading.FindElements(By.TagName("div"));
            List<string> columnListText = new List<string>();
            foreach (IWebElement column in columnsList)
            {
                columnListText.Add(column.Text.ToLower());
            }
            //Making as zero based Indexing
            columnNumber--;
            columnListText.Should().HaveElementAt(columnNumber, columnHeading.ToLower(), because: columnHeading + " column heading should be in column number " + columnNumber);
        }
    }
}
