using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.PageObjects.ReportsTab;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.ReportsTab
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5717")]
    public class Req5717Steps
    {
        private readonly LoginPage loginPage = new LoginPage();
        private readonly LandingPage landingPage = new LandingPage();
        private readonly MainPage mainPage = new MainPage();
        private readonly ReportsPage reportsPage = new ReportsPage();
        private readonly UsageReportPage usageReportPage = new UsageReportPage();
        private readonly FirmwareVersionPage firmwareVersionPage = new FirmwareVersionPage();

        private readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        private ScenarioContext _scenarioContext;

        public Req5717Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Given(@"user is on Reports page")]
        public void GivenUserIsOnReportPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Message = "Asset list is not displayed in main page.Timed out after 10 seconds.";
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.ReportsTab.JavaSciptClick();
        }
        
        [Given(@"CSM Asset type is selected")]
        public void GivenCSMAssetTypeIsSelected()
        {
            reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CSMDeviceName);
        }
        
        [When(@"user clicks report type dropdown")]
        public void WhenUserClicksReportTypeDropdown()
        {
            reportsPage.ReportTypeDDL.Click();
        }
        
        [Then(@"Report type dropdown displays ""(.*)""")]
        public void ThenReportTypeDropdownDisplays(string dropdownOptions)
        {
            //Spliting Based on comma for getting parameter
            string[] ExpecteddropdownOptionsArray = dropdownOptions.Split(",").Select(option=> option.Trim().ToLower()).ToArray();
            //Getting the actual option from the dropdown list.
            IList<IWebElement> Actualoptions = reportsPage.ReportTypeDDL.GetAllOptionsFromDDL();
            List<string> ActualOptionTextArray=new List<string>();
            foreach(IWebElement Option in Actualoptions)
            {
                ActualOptionTextArray.Add(Option.Text.ToLower());
            }
            foreach(string ExpectedOption in ExpecteddropdownOptionsArray)
            {
                Assert.AreEqual(true, ActualOptionTextArray.Contains(ExpectedOption.ToLower()),ExpectedOption+ " is not present in the dropdown option");
            }
        }


        [Given(@"Usage Report type is selected")]
        public void GivenUsageReportTypeIsSelected()
        {
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.UsageReportType);
        }

        [When(@"user clicks Get report button")]
        public void WhenUserClicksGetReportButton()
        {
            reportsPage.GetReportButton.Click();
        }

        [Then(@"Asset Usage Report \(CSM\) label is displayed")]
        public void ThenAssetUsageReportCSMLabelIsDisplayed()
        {
            Assert.AreEqual(true,usageReportPage.ReportsTitleHeader.GetElementVisibility(), "Usage Report header is not displayed");
            Assert.AreEqual(UsageReportPage.ExpectedValues.ReportTiltleHeaderCSM.ToLower(), usageReportPage.ReportsTitleHeader.Text.ToLower(), "Usage report is not matching with the expected value.");
        }

        [Then(@"Print button is displayed")]
        public void ThenPrintButtonIsDisplayed()
        {
            Assert.AreEqual(true, usageReportPage.PrintButton.GetElementVisibility(),"Print button is not displayed.");
        }

        [Then(@"Number of Devices on Each Floor label is displayed")]
        public void ThenNumberOfDevicesOnEachFloorLabelIsDisplayed()
        {
            Assert.AreEqual(true, usageReportPage.NumberOfdevicesOneachFloorLabel.GetElementVisibility(), "Number of Devices on Each Floor label is not displayed");
            Assert.AreEqual(UsageReportPage.ExpectedValues.NumberofDevicesOnEachFlorrLabelText.ToLower(), usageReportPage.NumberOfdevicesOneachFloorLabel.Text.ToLower(), "Number of Devices on Each Floor label is not matching the expected text.");
        }

        [Then(@"pie chart with Location ID is displayed")]
        public void ThenPieChartWithLocationIDIsDisplayed()
        {
            Assert.AreEqual(true, usageReportPage.PieChart.GetElementVisibility(),"Pie chart is not displayed.");
        }

        [Then(@"Total Usage Details - Components label is displayed")]
        public void ThenTotalUsageDetails_ComponentsLabelIsDisplayed()
        {
            Assert.AreEqual(true, usageReportPage.TotalUsageComponentsLabel.GetElementVisibility(), "Total usage label is not displayed.");
            Assert.AreEqual(UsageReportPage.ExpectedValues.TotalUsageDetailsComponentLabelText.ToLower(), usageReportPage.TotalUsageComponentsLabel.Text.ToLower(),"Total usage label is not matching the expected value.");
        }


        [Given(@"user is on CSM Usage Reports page")]
        public void GivenUserIsOnCSMUsageReportsPage()
        {
            GivenUserIsOnReportPage();
            reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CSMDeviceName);
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.UsageReportType);
            reportsPage.GetReportButton.Click();
        }

        [Then(@"Assets are grouped by unit")]
        public void ThenAssetsAreGroupedByUnit()
        {
            //need to clarify
            _scenarioContext.Pending();
        }

        [Then(@"all the devices within that location ID is displayed")]
        public void ThenAllTheDevicesWithinThatLocationIDIsDisplayed()
        {
            //need to clarify
            _scenarioContext.Pending();
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string columnHeading)
        {
            IWebElement column=null;
            string ExpectedColumnHeading = "";
            switch(columnHeading.ToLower().Trim())
            {
                case "model":
                    column = usageReportPage.ModelHeading;
                    ExpectedColumnHeading = UsageReportPage.ExpectedValues.ModelHeadingText;
                    break;

                case "asset tag":
                    column = usageReportPage.AssetTagHeading;
                    ExpectedColumnHeading = UsageReportPage.ExpectedValues.AssetTagHeadingText;
                    break;

                case "serial number":
                    column = usageReportPage.SerialNumberHeading;
                    ExpectedColumnHeading = UsageReportPage.ExpectedValues.SerialNumberHeadingText;
                    break;

                case "battery cycle count":
                    column = usageReportPage.BatteryCycleCountHeading;
                    ExpectedColumnHeading = UsageReportPage.ExpectedValues.BatteryCycleCountHeadingText;
                    break;

                case "suretemp thermometer cycle count":
                    column = usageReportPage.SureTempThermometerCycyleCountHeading;
                    ExpectedColumnHeading = UsageReportPage.ExpectedValues.SureTempThermometerCycleCountHeadingText;
                    break;

                case "nibp sensor cycle count":
                    column = usageReportPage.NIBPSensorCycleHeading;
                    ExpectedColumnHeading = UsageReportPage.ExpectedValues.NIBPSensorCycleCountHeadingText;
                    break;

                case "sphb cycle count":
                    column = usageReportPage.SPHBCycleCountHeading;
                    ExpectedColumnHeading = UsageReportPage.ExpectedValues.SPHBCycleCountHeadingText;
                    break;

                default: Assert.Fail(columnHeading+" is a invalid heading.");
                    break;
            }
            Assert.AreEqual(true, column.GetElementVisibility(),columnHeading+" is not displayed");
            Assert.AreEqual(ExpectedColumnHeading.ToLower(), column.Text.ToLower(),columnHeading+" is not matching with the expected value.");

        }

        [When(@"user clicks unit row")]
        public void WhenUserClicksUnitRow()
        {
            usageReportPage.Station1.Click();
        }

        [Then(@"assets for unit are hidden")]
        public void ThenAssetsForUnitAreHidden()
        {
            //Checking the visibility of entire device table
            Assert.AreEqual(false, usageReportPage.Station1Devices.GetElementVisibility(),"Assets for units are not hidden");
        }

        [Given(@"Firmware Version Report type is selected")]
        public void GivenFirmwareVersionReportTypeIsSelected()
        {
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareVersionReportType);
        }

        [Then(@"Firmware Version Report \(CSM\) label is displayed")]
        public void ThenFirmwareVersionReportCSMLabelIsDisplayed()
        {
            Assert.AreEqual(true, firmwareVersionPage.FirmwareReportTitle.GetElementVisibility(),"Firmware verion report label is not displayed.");
            Assert.AreEqual(FirmwareVersionPage.ExpectedValues.ReportCSMLabelText.ToLower(),firmwareVersionPage.FirmwareReportTitle.Text.ToLower(),"Firware version report(CSM) is not mathing with the expected value.");
        }

        [Then(@"Components column heading is displayed")]
        public void ThenComponentsColumnHeadingIsDisplayed()
        {
            Assert.AreEqual(true, firmwareVersionPage.ComponentsHeading.GetElementVisibility(),"Components heading is not displayed.");
            Assert.AreEqual(FirmwareVersionPage.ExpectedValues.ComponentsHeadingText.ToLower(), firmwareVersionPage.ComponentsHeading.Text.ToLower(), "Components heading is not matching with the expected value.");
        }

        [Then(@"Firmware version column heading is displayed")]
        public void ThenFirmwareVersionColumnHeadingIsDisplayed()
        {
            Assert.AreEqual(true, firmwareVersionPage.FirmwareVersionHeading.GetElementVisibility(),"Firmware version heading is not displayed.");
            Assert.AreEqual(FirmwareVersionPage.ExpectedValues.FirmwareVersionHeadingText.ToLower(), firmwareVersionPage.FirmwareVersionHeading.Text.ToLower(),"Firmware version heading is not matching with the expected value.");
        }

        [Then(@"Total devices column heading is displayed")]
        public void ThenTotalDevicesColumnHeadingIsDisplayed()
        {
            Assert.AreEqual(true, firmwareVersionPage.TotaldevicesHeading.GetElementVisibility(), "Total devices heading is not displayed.");
            Assert.AreEqual(FirmwareVersionPage.ExpectedValues.TotalDevicesHeadingText.ToLower(), firmwareVersionPage.TotaldevicesHeading.Text.ToLower(), "Total devices heading is not matching with the expected value.");
        }

        [Given(@"user is on CSM Firmware Version Report page")]
        public void GivenUserIsOnCSMFirmwareVersionReportPage()
        {
            GivenUserIsOnReportPage();
            reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CSMDeviceName);
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareVersionReportType);
            reportsPage.GetReportButton.Click();
        }

        [When(@"user clicks Total row")]
        public void WhenUserClicksTotalRow()
        {
            firmwareVersionPage.TotalRow.Click();
        }

        [Then(@"rows below Total are hidden")]
        public void ThenRowsBelowTotalAreHidden()
        {
            Assert.AreEqual(false, firmwareVersionPage.TotalRowDetails.GetElementVisibility(), message: "Rows below table are displayed.");
        }


    }
}
