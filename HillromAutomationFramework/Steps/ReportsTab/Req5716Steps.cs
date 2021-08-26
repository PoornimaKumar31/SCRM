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

namespace HillromAutomationFramework.Steps.ReportsTab
{
    [Binding, Scope(Tag = "SoftwareRequirementID_5716")]
    class Req5716Steps
    {
        private ScenarioContext _scenarioContext;
        public Req5716Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        LoginPage loginPage = new LoginPage();
        MainPage mainPage = new MainPage();
        LandingPage landingPage = new LandingPage();
        ReportsPage reportsPage = new ReportsPage();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        FirmwareVersionPage firmwareVersionPage = new FirmwareVersionPage();
        UsageReportPage usageReportPage = new UsageReportPage();

        [Given(@"user is on Reports page")]
        public void GivenUserIsOnReportsPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.ReportsTab.JavaSciptClick();
        }

        [Given(@"CVSM Asset type is selected in Asset type dropdown")]
        public void GivenAssetTypeIsCVSM()
        {
            reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CVSMDeviceName);
            Assert.AreEqual(ReportsPage.ExpectedValues.CVSMDeviceName, reportsPage.AssetTypeDDL.GetSelectedOptionFromDDL(), "Selected option is not correct");
        }

        [Given(@"Usage Report type is selected")]
        public void GivenUsageReportTypeIsSelected()
        {
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.UsageReportType);
            Assert.AreEqual(ReportsPage.ExpectedValues.UsageReportType, reportsPage.ReportTypeDDL.GetSelectedOptionFromDDL(), "Selected option is not correct");
        }

        [When(@"user clicks Get report button")]
        public void WhenClicksGetReportButton()
        {
            reportsPage.GetReportButton.Click();
        }

        [When(@"user clicks report type dropdown")]
        public void WhenWhenUserClicksReportTypeDropdown()
        {
            reportsPage.ReportTypeDDL.Click();
        }

        [Then(@"Report type dropdown displays ""(.*)""")]
        public void ThenReportTypeDropdownDisplays(string ExpectedOptions)
        {
            List<string> ExpectedOptionList = new List<string>(ExpectedOptions.ToLower().Split(", "));
            List<string> ActualOptionList = new List<string>(reportsPage.ReportTypeDDL.GetAllOptionsFromDDL().Select(x => x.Text.ToLower()));
            ActualOptionList.Remove("select");
            ActualOptionList.Should().BeEquivalentTo(ExpectedOptionList, "Expected Options are not same as Actual");
        }

        [Then(@"Asset Usage Report \(CVSM\) label is displayed")]
        public void ThenCVSMAssetUsageReportLabelIsDisplayed()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(UsageReportPage.Locator.ReportTitleHeaderID)));
            Assert.AreEqual(true, usageReportPage.ReportsTitleHeader.GetElementVisibility(), "User is not on the usage report page");
            Assert.AreEqual(UsageReportPage.ExpectedValues.ReportTitleHeaderCVSM.ToLower(), usageReportPage.ReportsTitleHeader.Text.ToLower(),"CVSM usage report header is not matching the expected value.");
        }

        [Then(@"Print button is displayed")]
        public void ThenPrintButtonIsDisplayed()
        {
            Assert.AreEqual(true,usageReportPage.PrintButton.GetElementVisibility(), "Print Button is not displayed");
        }

        [Then(@"Number of Devices on Each Floor label is displayed")]
        public void ThenNumberOfDevicesOnEachFloorLabelIsDisplayed()
        {
            Assert.AreEqual(true, usageReportPage.NumberOfdevicesOneachFloorLabel.GetElementVisibility(), "Number of Devices on Each Floor label is not displayed");
        }

        [Then(@"pie chart is displayed")]
        public void ThenPieChartIsDisplayed()
        {
            Assert.AreEqual(true, usageReportPage.PieChart.GetElementVisibility(), "Pie Chart is not displayed");
        }

        [Then(@"Total Usage Details - Components label is displayed")]
        public void ThenTotalUsageDetails_ComponentsLabelIsDisplayed()
        {
            Assert.AreEqual(true, usageReportPage.TotalUsageComponentsLabel.GetElementVisibility(), "Total usage details label is not displayed");
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
            usageReportPage.UnitToggleArrow.Click();
        }

        [Then(@"assets for the unit are hidden")]
        public void ThenAssetsForTheUnitAreHidden()
        {
           Assert.AreEqual(UsageReportPage.ExpectedValues.Station1HiddenDeviceStyleAttribute,usageReportPage.Station1DeviceContainer.GetAttribute("style"),"Asset for Unit is not hidden"); 
        }

        [Then(@"the Print button is enabled"),Scope(Tag = "TestCaseID_9368",Scenario = "CVSM Usage Report Print")]
        public void ThenThePrintButtonIsEnabled()
        {
            Assert.IsTrue(usageReportPage.PrintButton.Enabled,"Print Button is not enabled");
        }

        [Then(@"the Print button is enabled"), Scope(Tag = "TestCaseID_9371",Scenario = "CVSM Firmware Version Report Print")]
        public void ThenThePrintButtonIsEnabledFirmware()
        {
            Assert.IsTrue(firmwareVersionPage.PrintButton.Enabled, "Print Button is not enabled");
        }

        [Then(@"assets are grouped by unit")]
        public void ThenAssetsAreGroupedByUnit()
        {
            SetMethods.ScrollToBottomofWebpage();
            int unitCount = usageReportPage.UnitsRowList.GetElementCount();
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
            usageReportPage.CheckAllDevicesUnderUnitsIsDisplayed(usageReportPage.SerialNumberUnit1Column, UsageReportPage.ExpectedValues.Station1UnitCVSMDeviceSerialNumbers);

            //Unit2
            usageReportPage.CheckAllDevicesUnderUnitsIsDisplayed(usageReportPage.SerialNumberUnit2Column, UsageReportPage.ExpectedValues.NotSetUnitCVSMDevicesSerialNumber);

            //Unit3
            usageReportPage.CheckAllDevicesUnderUnitsIsDisplayed(usageReportPage.SerialNumberUnit3Column, UsageReportPage.ExpectedValues.LuWenUnitCVSMDevicesSerialNumber);

            //Unit4
            usageReportPage.CheckAllDevicesUnderUnitsIsDisplayed(usageReportPage.SerialNumberUnit4Column, UsageReportPage.ExpectedValues.ConnexCS1UnitCVSMDevicesSerialNumber);

            //Unit5
            usageReportPage.CheckAllDevicesUnderUnitsIsDisplayed(usageReportPage.SerialNumberUnit5Column, UsageReportPage.ExpectedValues.AndyDeskUnitCVSMDevicesSerialNumber);
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string tableHeader)
        {
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Trim().Equals("cvsm usage report table elements"))
            {
                IWebElement column = null;
                switch (tableHeader.ToLower().Trim())
                {
                    case "model":
                        column = usageReportPage.ModelHeading;
                        break;
                    case "asset tag":
                        column = usageReportPage.AssetTagHeading;
                        break;
                    case "serial number":
                        column = usageReportPage.SerialNumberHeading;
                        break;
                    case "battery cycle count":
                        column = usageReportPage.BatteryCycleCountHeading;
                        break;
                    case "suretemp thermometer cycle count":
                        column = usageReportPage.SureTempThermometerCycyleCountHeading;
                        break;
                    case "nibp sensor cycle count":
                        column = usageReportPage.NIBPSensorCycleHeading;
                        break;
                    case "sphb cycle count":
                        column = usageReportPage.SPHBCycleCountHeading;
                        break;
                    default:
                        Assert.Fail(tableHeader + "is a invalid Column heading");
                        break;
                }
                Assert.IsTrue(column.GetElementVisibility(), tableHeader + " Column Heading is not displayed");
                Assert.AreEqual(tableHeader.ToLower().Trim(), column.Text.ToLower(), tableHeader + " Column header is not as expected");
            }
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Trim().Equals("cvsm firmware version report elements"))
            {
                IWebElement column = null;
                switch (tableHeader.ToLower().Trim())
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
                        Assert.Fail(tableHeader + "is a invalid Column heading");
                        break;
                }
                Assert.IsTrue(column.GetElementVisibility(), tableHeader + " Column Heading is not displayed");
                Assert.AreEqual(tableHeader.ToLower().Trim(), column.Text.ToLower(), tableHeader + " Column header is not as expected");
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
            IList<IWebElement> columns = usageReportPage.TableHeader.FindElements(By.TagName("div"));
            Assert.AreEqual(columnHeading.ToLower().Trim(), columns[columnNumber - 1].Text.ToLower(), columnHeading + " is not in " + columnNumber);
        }

        [Given(@"Firmware Version Report type is selected")]
        public void GivenFirmwareVersionReportTypeIsSelected()
        {
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareVersionReportType);
            Assert.AreEqual(ReportsPage.ExpectedValues.FirmwareVersionReportType, reportsPage.ReportTypeDDL.GetSelectedOptionFromDDL(), "Selected option is not correct");
        }

        [Then(@"Firmware Version Report \(CVSM\) label is displayed")]
        public void ThenFirmwareVersionReportCVSMLabelIsDisplayed()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(FirmwareVersionPage.Locators.FirmwareReportTitleID)));
            Assert.IsTrue(firmwareVersionPage.FirmwareReportTitle.GetElementVisibility(), "User is not on the firmware version report page");
            Assert.AreEqual(FirmwareVersionPage.ExpectedValues.ReportCVSMLabelText.ToLower(), firmwareVersionPage.FirmwareReportTitle.Text.ToLower(),"Firmware version label text is not matching with the expected value.");
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
            firmwareVersionPage.TotalRow.Click();
        }

        [Then(@"rows below Total are displayed")]
        public void ThenRowsBelowTotalAreDisplayed()
        {
            Assert.IsTrue(firmwareVersionPage.TotalRowDetails.GetElementVisibility(), "Rows are not displayed");
        }

        [When(@"user clicks unit row")]
        public void WhenUserClicksUnitRow()
        {
            //cvsmFirmwareVersionReportPage.AndyDeskUnit.Click();
            firmwareVersionPage.AndyDeskUnit.Click();
            //cvsmFirmwareVersionReportPage.ConnexCS1Unit.Click();
            firmwareVersionPage.ConnexCS1Unit.Click();
            //cvsmFirmwareVersionReportPage.LuWenUnit.Click();
            firmwareVersionPage.LuWenUnit.Click();
            //cvsmFirmwareVersionReportPage.Station1Unit.Click();
            firmwareVersionPage.Station1Unit.Click();
        }

        [Then(@"assets for unit are displayed")]
        public void ThenAssetsForUnitAreDisplayed()
        {
            Assert.IsTrue(firmwareVersionPage.AndyDeskUnitAllDevices.GetElementVisibility(), "asset for unit are not displayed");
            Assert.IsTrue(firmwareVersionPage.ConnexCS1UnitAllDevices.GetElementVisibility(), "asset for unit are not displayed");
            Assert.IsTrue(firmwareVersionPage.LuWenUnitAllDevices.GetElementVisibility(), "asset for unit are not displayed");
            Assert.IsTrue(firmwareVersionPage.Station1UnitAllDevices.GetElementVisibility(), "asset for unit are not displayed");
        }


    }
}
