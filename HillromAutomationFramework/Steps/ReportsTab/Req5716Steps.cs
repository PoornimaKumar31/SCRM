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
    [Binding, Scope(Tag = "SoftwareRequirementID_5716")]
    class Req5716Steps
    {
        ///POM
        private readonly LoginPage _loginPage;
        private readonly MainPage _mainPage;
        private readonly LandingPage _landingPage;
        private readonly ReportsPage _reportsPage;
        private readonly FirmwareVersionPage _firmwareVersionPage;
        private readonly UsageReportPage _usageReportPage;

        private readonly WebDriverWait _wait;
        private readonly ScenarioContext _scenarioContext;


        public Req5716Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage();
            _mainPage = new MainPage();
            _landingPage = new LandingPage();
            _reportsPage = new ReportsPage();
            _firmwareVersionPage = new FirmwareVersionPage();
            _usageReportPage = new UsageReportPage();
        }
       

        [Given(@"user is on Reports page")]
        public void GivenUserIsOnReportsPage()
        {
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.ReportsTab.JavaSciptClick();
        }

        [Given(@"CVSM Asset type is selected in Asset type dropdown")]
        public void GivenAssetTypeIsCVSM()
        {
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CVSMDeviceName);
            (_reportsPage.AssetTypeDDL.GetSelectedOptionFromDDL()).Should().BeEquivalentTo(ReportsPage.ExpectedValues.CVSMDeviceName,"CVSM device should be selected in the asset type dropdown.");
        }

        [Given(@"Usage Report type is selected")]
        public void GivenUsageReportTypeIsSelected()
        {
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.UsageReportType);
            (_reportsPage.ReportTypeDDL.GetSelectedOptionFromDDL()).Should().BeEquivalentTo(ReportsPage.ExpectedValues.UsageReportType, "Usage report should be selected in Report type dropdown.");
        }

        [When(@"user clicks Get report button")]
        public void WhenClicksGetReportButton()
        {
            _reportsPage.GetReportButton.Click();
        }

        [When(@"user clicks report type dropdown")]
        public void WhenWhenUserClicksReportTypeDropdown()
        {
            _reportsPage.ReportTypeDDL.Click();
        }

        [Then(@"Report type dropdown displays ""(.*)""")]
        public void ThenReportTypeDropdownDisplays(string ExpectedOptions)
        {
            List<string> ExpectedOptionList = new List<string>(ExpectedOptions.ToLower().Split(", "));
            List<string> ActualOptionList = new List<string>(_reportsPage.ReportTypeDDL.GetAllOptionsFromDDL().Select(x => x.Text.ToLower()));
            ActualOptionList.Remove("select");
            ActualOptionList.Should().BeEquivalentTo(ExpectedOptionList, "Expected Options are not same as Actual");
        }

        [Then(@"Asset Usage Report \(CVSM\) label is displayed")]
        public void ThenCVSMAssetUsageReportLabelIsDisplayed()
        {
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(UsageReportPage.Locator.ReportTitleHeaderID)));
            (_usageReportPage.ReportsTitleHeader.GetElementVisibility()).Should().BeTrue("Report Title header should be displayed in the Uasge report page.");
            (_usageReportPage.ReportsTitleHeader.Text).Should().BeEquivalentTo(UsageReportPage.ExpectedValues.ReportTitleHeaderCVSM, "CVSM usage report header should have matching string as expected");
        }

        [Then(@"Print button is displayed")]
        public void ThenPrintButtonIsDisplayed()
        {
            (_usageReportPage.PrintButton.GetElementVisibility()).Should().BeTrue("Print button should be displayed in the Usge report page");
        }

        [Then(@"Number of Devices on Each Floor label is displayed")]
        public void ThenNumberOfDevicesOnEachFloorLabelIsDisplayed()
        {
            (_usageReportPage.NumberOfdevicesOneachFloorLabel.GetElementVisibility()).Should().BeTrue("Number of Devices on Each Floor label should be displayed on usage report page");
        }

        [Then(@"pie chart is displayed")]
        public void ThenPieChartIsDisplayed()
        {
            (_usageReportPage.PieChart.GetElementVisibility()).Should().BeTrue("Pie chart should be displayed in the Usage report page.");
        }

        [Then(@"Total Usage Details - Components label is displayed")]
        public void ThenTotalUsageDetails_ComponentsLabelIsDisplayed()
        {
            (_usageReportPage.TotalUsageComponentsLabel.GetElementVisibility()).Should().BeTrue("Total usage details label should be displayed in the Usage report page");
        }

        [Given(@"user is on CVSM Usage Report page")]
        public void GivenUserIsOnCVSMUsageReportPage()
        {
            //User Logged in and clicked on Report Tab
            GivenUserIsOnReportsPage();
            
            //CVSM Asset Type is selected in Asset Type DDL
            GivenAssetTypeIsCVSM();

            //Usage Report type is selcted in Report Type DDL
            GivenUsageReportTypeIsSelected();

            //User clicks on Reports button
            WhenClicksGetReportButton();

            //Report will be displayed
            ThenCVSMAssetUsageReportLabelIsDisplayed();
        }

        [When(@"user clicks unit toggle arrow")]
        public void WhenUserClicksUnitRowToggleArrow()
        {
            //clicking on the toggle button
            _usageReportPage.UnitToggleArrow.Click();
        }

        [Then(@"assets for the unit are hidden")]
        public void ThenAssetsForTheUnitAreHidden()
        {
            (_usageReportPage.Station1DeviceContainer.GetAttribute("style")).Should().BeEquivalentTo(UsageReportPage.ExpectedValues.Station1HiddenDeviceStyleAttribute, "Asset for Unit should be hidden when user clicks unit toggle arrow");
        }

        [Then(@"the Print button is enabled"),Scope(Tag = "TestCaseID_9368",Scenario = "CVSM Usage Report Print")]
        public void ThenThePrintButtonIsEnabled()
        {
            (_usageReportPage.PrintButton.Enabled).Should().BeTrue("Print button should be enabled in usage report page.");
        }

        [Then(@"the Print button is enabled"), Scope(Tag = "TestCaseID_9371",Scenario = "CVSM Firmware Version Report Print")]
        public void ThenThePrintButtonIsEnabledFirmware()
        {
            (_firmwareVersionPage.PrintButton.Enabled).Should().BeTrue("Print button should be enabled in firmware version report page.");
        }

        [Then(@"assets are grouped by unit")]
        public void ThenAssetsAreGroupedByUnit()
        {
            SetMethods.ScrollToBottomofWebpage();
            //Getting no of units
            int unitCount = _usageReportPage.UnitsRowList.GetElementCount();
            unitCount.Should().BeGreaterThan(0, "Atleast one unit should be present");
            //Check if the unit and device parent element are same.
            for (int row = 0; row < unitCount; row++)
            {
                IWebElement deviceParent = PropertyClass.Driver.FindElement(By.Id("devices" + row)).FindElement(By.XPath(".."));
                IWebElement unitParent = PropertyClass.Driver.FindElement(By.Id("location" + row)).FindElement(By.XPath(".."));
                if (!(deviceParent.Equals(unitParent)))
                {
                    Assert.Fail("Assets are not grouped by unit.");
                }
            }
        }

        [Then(@"all the devices within unit are displayed")]
        public void ThenAllTheDevicesWithinUnitAreDisplayed()
        {
            //Unit1
            _usageReportPage.CheckAllDevicesUnderUnitsIsDisplayed(_usageReportPage.SerialNumberUnit1Column, UsageReportPage.ExpectedValues.Station1UnitCVSMDeviceSerialNumbers);

            //Unit2
            _usageReportPage.CheckAllDevicesUnderUnitsIsDisplayed(_usageReportPage.SerialNumberUnit2Column, UsageReportPage.ExpectedValues.NotSetUnitCVSMDevicesSerialNumber);

            //Unit3
            _usageReportPage.CheckAllDevicesUnderUnitsIsDisplayed(_usageReportPage.SerialNumberUnit3Column, UsageReportPage.ExpectedValues.LuWenUnitCVSMDevicesSerialNumber);

            //Unit4
            _usageReportPage.CheckAllDevicesUnderUnitsIsDisplayed(_usageReportPage.SerialNumberUnit4Column, UsageReportPage.ExpectedValues.ConnexCS1UnitCVSMDevicesSerialNumber);

            //Unit5
            _usageReportPage.CheckAllDevicesUnderUnitsIsDisplayed(_usageReportPage.SerialNumberUnit5Column, UsageReportPage.ExpectedValues.AndyDeskUnitCVSMDevicesSerialNumber);
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string tableHeader)
        {
            //For usage report
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Trim().Equals("cvsm usage report table elements"))
            {
                IWebElement column = null;
                switch (tableHeader.ToLower().Trim())
                {
                    case "model":
                        column = _usageReportPage.ModelHeading;
                        break;
                    case "asset tag":
                        column = _usageReportPage.AssetTagHeading;
                        break;
                    case "serial number":
                        column = _usageReportPage.SerialNumberHeading;
                        break;
                    case "battery cycle count":
                        column = _usageReportPage.BatteryCycleCountHeading;
                        break;
                    case "suretemp thermometer cycle count":
                        column = _usageReportPage.SureTempThermometerCycyleCountHeading;
                        break;
                    case "nibp sensor cycle count":
                        column = _usageReportPage.NIBPSensorCycleHeading;
                        break;
                    case "sphb cycle count":
                        column = _usageReportPage.SPHBCycleCountHeading;
                        break;
                    default:
                        Assert.Fail(tableHeader + "is a invalid Column heading");
                        break;
                }
                (column.GetElementVisibility()).Should().BeTrue(tableHeader + " Column Heading should be displayed in usage report page.");
                string columnName = column.Text;
                (columnName).Should().BeEquivalentTo(tableHeader.Trim(), tableHeader + " Column header should match the expected string");
            }
            //For Firmware version report
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Trim().Equals("cvsm firmware version report elements"))
            {
                IWebElement column = null;
                switch (tableHeader.ToLower().Trim())
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
                        Assert.Fail(tableHeader + "is a invalid Column heading");
                        break;
                }
                (column.GetElementVisibility()).Should().BeTrue(tableHeader + " Column Heading should be displayed in usage report page.");
                string columnName = column.Text;
                (columnName).Should().BeEquivalentTo(tableHeader.Trim(), tableHeader + " Column header should match the expected string");
            }
            //if test defination does not belong to any scenario
            else
            {
                Assert.Fail(_scenarioContext.ScenarioInfo.Title + " does not have step defination for " + _scenarioContext.StepContext.StepInfo.Text);
            }
        }

        [Then(@"""(.*)"" label is in column (.*)")]
        public void ThenLabelIsInColumn(string columnHeading, int columnNumber)
        {
            IList<IWebElement> columns = _usageReportPage.TableHeader.FindElements(By.TagName("div"));
            string actualColumnName = columns[columnNumber - 1].Text;
            (actualColumnName).Should().BeEquivalentTo(columnHeading.Trim(),columnHeading+" column heading should be displayed in "+columnNumber);
        }

        [Given(@"Firmware Version Report type is selected")]
        public void GivenFirmwareVersionReportTypeIsSelected()
        {
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareVersionReportType);
            (_reportsPage.ReportTypeDDL.GetSelectedOptionFromDDL()).Should().BeEquivalentTo(ReportsPage.ExpectedValues.FirmwareVersionReportType,"Report type should be fiirmware version");
        }

        [Then(@"Firmware Version Report \(CVSM\) label is displayed")]
        public void ThenFirmwareVersionReportCVSMLabelIsDisplayed()
        {
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(FirmwareVersionPage.Locators.FirmwareReportTitleID)));
            (_firmwareVersionPage.FirmwareReportTitle.GetElementVisibility()).Should().BeTrue("Report title header should be displayed in Firmware version Report page.");
            (_firmwareVersionPage.FirmwareReportTitle.Text).Should().BeEquivalentTo(FirmwareVersionPage.ExpectedValues.ReportCVSMLabelText, "Firmware version report title should match the expected string.");
        }


        [Given(@"user is on CVSM Firmware Version Report page")]
        public void GivenUserIsOnCVSMFirmwareVersionReportPage()
        {
            //User Logged in and clicked on Report Tab
            GivenUserIsOnReportsPage();

            //CVSM Asset Type is selected in Asset Type DDL
            GivenAssetTypeIsCVSM();

            //Firmware Version Report type is selcted in Report Type DDL
            GivenFirmwareVersionReportTypeIsSelected();

            //User clicks on Reports button
            WhenClicksGetReportButton();

            //Report will be displayed
            ThenFirmwareVersionReportCVSMLabelIsDisplayed();
        }

        [When(@"user clicks Total row")]
        public void WhenUserClicksTotalRow()
        {
            //cvsmFirmwareVersionReportPage.TotalRow.Click();
            _firmwareVersionPage.TotalRow.Click();
        }

        [Then(@"rows below Total are displayed")]
        public void ThenRowsBelowTotalAreDisplayed()
        {
            (_firmwareVersionPage.TotalRowDetails.GetElementVisibility()).Should().BeTrue("Rows below total should be displayed when user clicks Total row");
        }

        [When(@"user clicks unit row")]
        public void WhenUserClicksUnitRow()
        {
            //cvsmFirmwareVersionReportPage.AndyDeskUnit.Click();
            _firmwareVersionPage.AndyDeskUnit.Click();
            //cvsmFirmwareVersionReportPage.ConnexCS1Unit.Click();
            _firmwareVersionPage.ConnexCS1Unit.Click();
            //cvsmFirmwareVersionReportPage.LuWenUnit.Click();
            _firmwareVersionPage.LuWenUnit.Click();
            //cvsmFirmwareVersionReportPage.Station1Unit.Click();
            _firmwareVersionPage.Station1Unit.Click();
        }

        [Then(@"assets for unit are displayed")]
        public void ThenAssetsForUnitAreDisplayed()
        {
            (_firmwareVersionPage.AndyDeskUnitAllDevices.GetElementVisibility()).Should().BeTrue("Assets for unit AndyDesk should be displayed when clicks AndyDesk Unit Row");

            (_firmwareVersionPage.ConnexCS1UnitAllDevices.GetElementVisibility()).Should().BeTrue("Assets for unit ConnexCs1 should be displayed when clicks ConnexCs1 Unit Row");

            (_firmwareVersionPage.LuWenUnitAllDevices.GetElementVisibility()).Should().BeTrue("Assets for unit Luwen should be displayed when clicks Luwen Unit Row");

            (_firmwareVersionPage.Station1UnitAllDevices.GetElementVisibility()).Should().BeTrue("Assets for unit Station1 should be displayed when clicks Station1 Unit Row");
        }


    }
}
