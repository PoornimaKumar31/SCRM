using FluentAssertions;
using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.PageObjects.ReportsTab;
using HillromAutomationFramework.Coding.SupportingCode;
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
    [Binding, Scope(Tag = "SoftwareRequirementID_9423")]
    public class Req9423Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly ReportsPage _reportsPage;
        private readonly ActivityReportPage _activityReportPage;

        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverWait _wait;

        public Req9423Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage();
            _landingPage = new LandingPage();
            _mainPage = new MainPage();
            _reportsPage = new ReportsPage();
            _activityReportPage = new ActivityReportPage();
        }


        [Given(@"user is on Reports page")]
        public void GivenUserIsOnReportsPage()
        {
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(_landingPage.PSSServiceOrganizationFacilityBatesville, "Centrella Orgaization");
            _landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.ReportsTab.JavaSciptClick();
        }
        
        [Given(@"Centrella Asset type is selected")]
        public void GivenCentrellaAssetTypeIsSelected()
        {
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CentrellaDeviceName);
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
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.ActivityReportType);
        }

        [When(@"user clicks Get report button")]
        public void WhenUserClicksGetReportButton()
        {
            _reportsPage.GetReportButton.Click();
        }

        [Then(@"Activity Report \(Centrella\) label is displayed")]
        public void ThenActivityReportCentrellaLabelIsDisplayed()
        {
            (_activityReportPage.ActivityReportHeader.GetElementVisibility()).Should().BeTrue("Activity Report (Centrella) label should be displayed in Centrella Activity Report Page.");
            (_activityReportPage.ActivityReportHeader.Text).Should().BeEquivalentTo(ActivityReportPage.ExpectedValues.ActivityReportCentreallaHeader, because: "Activity report header should match the expected value in Centrella Activity Report Page.");
        }

        [Then(@"Print button is displayed")]
        public void ThenPrintButtonIsDisplayed()
        {
            (_activityReportPage.PrintButton.GetElementVisibility()).Should().BeTrue("Print button should be displayed in Centrella Activity Report Page.");
        }

        [Then(@"Download button is displayed")]
        public void ThenDownloadButtonIsDisplayed()
        {
            (_activityReportPage.DownloadButton.GetElementVisibility()).Should().BeTrue("Download button should be displayed in Centrella Activity Report Page.");
        }

        [Then(@"Search box is displayed")]
        public void ThenSearchBoxIsDisplayed()
        {
            (_activityReportPage.SearchBox.GetElementVisibility()).Should().BeTrue(because: "Search box should be displayed in Centrella Activity Report Page.");
        }

        [Then(@"Previous page icon is displayed")]
        public void ThenPreviousPageIconIsDisplayed()
        {
            (_activityReportPage.PaginationPreviousPageIcon.GetElementVisibility()).Should().BeTrue(because: "Previous page icon should be displayed in Centrella Activity Report Page.");
        }

        [Then(@"Next page icon is displayed")]
        public void ThenNextPageIconIsDisplayed()
        {
            (_activityReportPage.PaginationNextPageIcon.GetElementVisibility()).Should().BeTrue(because: "Next page icon should be displayed in Centrella Activity Report Page.");
        }

        [Then(@"Page x of y indicator is displayed")]
        public void ThenPageXOfYIndicatorIsDisplayed()
        {
            (_activityReportPage.PaginationPageXofY.GetElementVisibility()).Should().BeTrue(because: "Page x of y indicator should be displayed in Centrella Activity Report Page.");
        }

        [Then(@"Displaying x to y of z results indicator is displayed")]
        public void ThenDisplayingXToYOfZResultsIndicatorIsDisplayed()
        {
            (_activityReportPage.PaginationDisplayXY.GetElementVisibility()).Should().BeTrue(because: "Display x to y of z results label should be displayed in Centrella Activity Report Page.");
        }

        [Given(@"user is on Centrella Activity Report page")]
        public void GivenUserIsOnCentrellaActivityReportPage()
        {
            GivenUserIsOnReportsPage();
            //Selecting Centrella device
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CentrellaDeviceName);
            //Selecting the Activity Report
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.ActivityReportType);
            _reportsPage.GetReportButton.Click();
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string columnHeading)
        {
            IWebElement column = null;
            string ExpectedColumnHeading = "";

            switch (columnHeading.ToLower().Trim())
            {
                case "serial number":
                    column = _activityReportPage.SerialNumberHeading;
                    ExpectedColumnHeading = ActivityReportPage.ExpectedValues.SerialNumberHeadingText;
                    break;

                case "location":
                    column = _activityReportPage.LocationHeading;
                    ExpectedColumnHeading = ActivityReportPage.ExpectedValues.LocationHeadingText;
                    break;

                case "last vital sent":
                    column = _activityReportPage.LastVitalSentHeading;
                    ExpectedColumnHeading = ActivityReportPage.ExpectedValues.LastVitalSentHeadingText;
                    break;

                default:
                    Assert.Fail(columnHeading + " is a invalid heading name.");
                    break;
            }
            (column.GetElementVisibility()).Should().BeTrue(because: columnHeading + " should be displayed in Centrella Activity Report Page Table.");
            string ActualcolumnName = column.Text;
            (ActualcolumnName).Should().BeEquivalentTo(ExpectedColumnHeading, because: columnHeading + " column heading should match with the expected value in Centrella Activity Report Page Table.");
        }

        [Then(@"""(.*)"" label is in column (.*)")]
        public void ThenLabelIsInColumn(string columnHeading, int columnNumber)
        {
            IList<IWebElement> columns = _activityReportPage.TableHeading.FindElements(By.TagName("div"));
            string ActualColumnNameAtIndexColumnNumber = columns[columnNumber - 1].Text;
            (ActualColumnNameAtIndexColumnNumber).Should().BeEquivalentTo(columnHeading, because: columnHeading + " should be in " + columnNumber+ " in Centrella Activity Report Page Table.");
        }
    }
}
