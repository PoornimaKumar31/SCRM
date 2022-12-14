using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.ReportsTab;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.ReportsTab
{
    [Binding, Scope(Tag = "SoftwareRequirementID_8309")]
    public sealed class Req8309Steps
    {

        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly ReportsPage _reportsPage;
        private readonly FirmwareVersionReportPage _firmwareVersionPage;

        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public Req8309Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
            _reportsPage = new ReportsPage(driver);
            _firmwareVersionPage = new FirmwareVersionReportPage(driver);
        }

        [Given(@"user is on Reports page")]
        public void GivenUserIsOnReportsPage()
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(_landingPage.PSSServiceOrganizationFacilityBatesville, _driver, "Centrella Orgaization");
            _landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.ReportsTab.JavaSciptClick(_driver);
        }

        [Given(@"Centrella Asset type is selected in Asset type dropdown")]
        public void GivenCentrellaAssetTypeIsSelectedInAssetTypeDropdown()
        {
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPageExpectedValues.CentrellaDeviceName);
        }

        [Given(@"Firmware Version Report type is selected")]
        public void GivenFirmwareVersionReportTypeIsSelected()
        {
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.FirmwareVersionReportType);
        }

        [When(@"user clicks Get report button")]
        public void WhenUserClicksGetReportButton()
        {
            _reportsPage.GetReportButton.Click();
        }

        [Then(@"Firmware Version Report \(Centrella\) label is displayed")]
        public void ThenFirmwareVersionReportCentrellaLabelIsDisplayed()
        {
            (_firmwareVersionPage.FirmwareReportTitle.GetElementVisibility()).Should().BeTrue("Firmware version report label should be displayed in Firmware Version Report page");
            (_firmwareVersionPage.FirmwareReportTitle.Text).Should().BeEquivalentTo(FirmwareVersionReportPageExpectedValues.ReportCentrellaLabelText, because: "Firmware version report label should match the expected value in Firmware Version Report page.");
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string columnHeading)
        {
            IWebElement column=null;

            switch (columnHeading.ToLower().Trim())
            {
                case "components":
                    column = _firmwareVersionPage.ComponentsHeading;
                    break;

                case "firmware version":
                    column = _firmwareVersionPage.FirmwareVersionHeading;
                    break;

                case "total devices":
                    column = _firmwareVersionPage.TotaldevicesHeading;
                    break;
                default:
                    Assert.Fail(columnHeading + " is a invalid headid name.");
                    break;
            }
            (column.GetElementVisibility()).Should().BeTrue(columnHeading + " column heading should be displayed in Firmware Version Report page table.");
            string ActualColumnName = column.Text;
            (ActualColumnName).Should().BeEquivalentTo(columnHeading, because: columnHeading + " column heading should match with the expected value in Firmware Version Report page table.");
        }

        [Given(@"user is on Centrella Firmware Version Report page")]
        public void GivenUserIsOnCentrellaFirmwareVersionReportPage()
        {
            GivenUserIsOnReportsPage();
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPageExpectedValues.CentrellaDeviceName);
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.FirmwareVersionReportType);
            _reportsPage.GetReportButton.Click();
        }

        [When(@"user clicks Total row")]
        public void WhenUserClicksTotalRow()
        {
            _firmwareVersionPage.TotalRow.Click();
        }

        [Then(@"rows below Total are displayed")]
        public void ThenRowsBelowTotalAreDisplayed()
        {
            (_firmwareVersionPage.TotalRowDetails.GetElementVisibility()).Should().BeTrue("Total row details should be displayed when user cliks on total row in Centrella Firmware Version Report page.");
        }

        [When(@"user clicks unit row")]
        public void WhenUserClicksUnitRow()
        {
            _firmwareVersionPage.Unit1Row.Click();
        }

        [Then(@"assets for unit are displayed")]
        public void ThenAssetsForUnitAreDisplayed()
        {
            (_firmwareVersionPage.Unit1RowDetails.GetElementVisibility()).Should().BeTrue(because: "Assets for unit should be displayed when user clicks unit row in Centrella Firmware Version Report page.");
        }

        [Then(@"the Print button is enabled")]
        public void ThenThePrintButtonIsEnabled()
        {
            (_firmwareVersionPage.PrintButton.Enabled).Should().BeTrue("Print button should be enabled in Centrella Firmware Version Report page.");
        }
    }
}
