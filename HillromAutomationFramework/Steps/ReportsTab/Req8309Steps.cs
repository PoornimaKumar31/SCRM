using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.PageObjects.ReportsTab;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.ReportsTab
{
    [Binding, Scope(Tag = "SoftwareRequirementID_8309")]
    public sealed class Req8309Steps
    {

        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        ReportsPage reportsPage = new ReportsPage();
        FirmwareVersionPage firmwareVersionPage = new FirmwareVersionPage();

        private readonly ScenarioContext _scenarioContext;
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

        public Req8309Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"user is on Reports page")]
        public void GivenUserIsOnReportsPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(landingPage.EdenHospitalMedicalCenterOrganizationTitle, "Centrella Orgaization");
            landingPage.EdenHospitalMedicalCenterOrganizationFacilityMedicalCenter.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.ReportsTab.JavaSciptClick();
        }

        [Given(@"Centrella Asset type is selected in Asset type dropdown")]
        public void GivenCentrellaAssetTypeIsSelectedInAssetTypeDropdown()
        {
            reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CentrellaDeviceName);
        }

        [Given(@"Firmware Version Report type is selected")]
        public void GivenFirmwareVersionReportTypeIsSelected()
        {
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareVersionReportType);
        }

        [When(@"user clicks Get report button")]
        public void WhenUserClicksGetReportButton()
        {
            reportsPage.GetReportButton.Click();
        }

        [Then(@"Firmware Version Report \(Centrella\) label is displayed")]
        public void ThenFirmwareVersionReportCentrellaLabelIsDisplayed()
        {
            Assert.IsTrue(firmwareVersionPage.FirmwareReportTitle.GetElementVisibility(),"Firmware version report label is not displayed.");
            Assert.AreEqual(FirmwareVersionPage.ExpectedValues.ReportCentrellaLabelText.ToLower(), firmwareVersionPage.FirmwareReportTitle.Text.ToLower(), "Firmware version report label is not matching the expected value.");
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string columnHeading)
        {
            IWebElement column=null;

            switch (columnHeading.ToLower().Trim())
            {
                case "components":
                    column = firmwareVersionPage.ComponentsHeading;
                    break;

                case "firmware version":
                    column = firmwareVersionPage.FirmwareVersionHeading;
                    break;

                case "total devices":
                    column = firmwareVersionPage.TotaldevicesHeading;
                    break;
                default:
                    Assert.Fail(columnHeading + " is a invalid headid name.");
                    break;
            }
            Assert.IsTrue(column.GetElementVisibility(), columnHeading+" column heading is not displayed");
            Assert.AreEqual(columnHeading.ToLower(), column.Text.ToLower(), columnHeading+" column heading is not matching with the expected value");

        }

        [Given(@"user is on Centrella Firmware Version Report page")]
        public void GivenUserIsOnCentrellaFirmwareVersionReportPage()
        {
            GivenUserIsOnReportsPage();
            reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CentrellaDeviceName);
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareVersionReportType);
            reportsPage.GetReportButton.Click();
        }

        [When(@"user clicks Total row")]
        public void WhenUserClicksTotalRow()
        {
            firmwareVersionPage.TotalRow.Click();
        }

        [Then(@"rows below Total are displayed")]
        public void ThenRowsBelowTotalAreDisplayed()
        {
            Assert.IsTrue(firmwareVersionPage.TotalRowDetails.GetElementVisibility(),"Total row details are not displayed.");
        }

        [When(@"user clicks unit row")]
        public void WhenUserClicksUnitRow()
        {
            firmwareVersionPage.Unit1Row.Click();
        }

        [Then(@"assets for unit are displayed")]
        public void ThenAssetsForUnitAreDisplayed()
        {
            Assert.IsTrue(firmwareVersionPage.Unit1RowDetails.GetElementVisibility(),"Unit row details are not displayed.");
        }

        [Then(@"the Print button is enabled")]
        public void ThenThePrintButtonIsEnabled()
        {
            Assert.IsTrue(firmwareVersionPage.PrintButton.Enabled, "Print button is not enabled.");
        }
    }
}
