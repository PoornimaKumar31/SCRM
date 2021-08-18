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
    [Binding,Scope(Tag = "SoftwareRequirementID_5717")]
    public class Req5717Steps
    {
        private readonly LoginPage loginPage = new LoginPage();
        private readonly LandingPage landingPage = new LandingPage();
        private readonly MainPage mainPage = new MainPage();
        private readonly ReportsPage reportsPage = new ReportsPage();
        private readonly UsageReportPage usageReportPage = new UsageReportPage();
        private readonly FirmwareVersionPage firmwareVersionPage = new FirmwareVersionPage();
        private readonly FirmwareStatusPage firmwareStatusPage = new FirmwareStatusPage();
        private readonly CSMConfigStatusPage csmConfigStatusPage = new CSMConfigStatusPage();
        private readonly ActivityReportPage activityReportPage = new ActivityReportPage();

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
            List<string> ExpecteddropdownOptionsList = new List<string>(dropdownOptions.Split(",").Select(option => option.Trim().ToLower()).ToArray());
            //List<string> ExpectedOptionList = new List<string>(dropdownOptions.ToLower().Split(", "));
            List<string> ActualOptionList = new List<string>(reportsPage.ReportTypeDDL.GetAllOptionsFromDDL().Select(x => x.Text.ToLower()));
            //Getting the actual option from the dropdown list.
            ActualOptionList.Remove("select"); //Removing the select item
            //Asserting
            ActualOptionList.Should().BeEquivalentTo(ExpecteddropdownOptionsList,"it should contain only that report which supported by CSM device");
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
            Assert.AreEqual(true, reportsPage.PrintButton.GetElementVisibility(),"Print button is not displayed.");
        }

        [Then(@"Number of Devices on Each Floor label is displayed")]
        public void ThenNumberOfDevicesOnEachFloorLabelIsDisplayed()
        {
            Assert.AreEqual(true, usageReportPage.NumberOfdevicesOneachFloorLabel.GetElementVisibility(), "Number of Devices on Each Floor label is not displayed");
            Assert.AreEqual(UsageReportPage.ExpectedValues.NumberofDevicesOnEachFlorrLabelText.ToLower(), usageReportPage.NumberOfdevicesOneachFloorLabel.Text.ToLower(), "Number of Devices on Each Floor label is not matching the expected text.");
        }

        [Then(@"pie chart is displayed")]
        public void ThenPieChartIsDisplayed()
        {
            Assert.AreEqual(true, usageReportPage.PieChart.GetElementVisibility(),"Pie chart is not displayed.");
        }

        [Then(@"Total Usage Details - Components label is displayed")]
        public void ThenTotalUsageDetails_ComponentsLabelIsDisplayed()
        {
            Assert.AreEqual(true, usageReportPage.TotalUsageComponentsLabel.GetElementVisibility(), "Total usage label is not displayed.");
            Assert.AreEqual(UsageReportPage.ExpectedValues.TotalUsageDetailsComponentLabelText.ToLower(), usageReportPage.TotalUsageComponentsLabel.Text.ToLower(),"Total usage label is not matching the expected value.");
        }


        [Given(@"user is on CSM Usage Report page")]
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
            SetMethods.ScrollToBottomofWebpage();
            int unitCount = usageReportPage.UnitsRowList.GetElementCount();
            for(int row=0;row<unitCount;row++)
            {
                IWebElement deviceParent = PropertyClass.Driver.FindElement(By.Id("devices" + row)).FindElement(By.XPath(".."));
                IWebElement unitParent = PropertyClass.Driver.FindElement(By.Id("location" + row)).FindElement(By.XPath(".."));
                if(!(deviceParent.Equals(unitParent)))
                {
                    Assert.Fail("Assets are not grouped by unit.");
                }
            }
        }

        [Then(@"all the devices within each unit is displayed")]
        public void ThenAllTheDevicesWithinThatUnitIsDisplayed()
        {
            //Unit1
            usageReportPage.CheckAllDevicesUnderUnitsIsDisplayed(usageReportPage.SerialNumberUnit1Column, UsageReportPage.ExpectedValues.Unit1CSMDeviceSerialNumbers);

            //Unit2
            usageReportPage.CheckAllDevicesUnderUnitsIsDisplayed(usageReportPage.SerialNumberUnit2Column,UsageReportPage.ExpectedValues.Unit2CSMDevicesSerialNumber);

            //Unit3
            usageReportPage.CheckAllDevicesUnderUnitsIsDisplayed(usageReportPage.SerialNumberUnit3Column, UsageReportPage.ExpectedValues.Unit3CSMDevicesSerialNumber);

            //Unit4
            usageReportPage.CheckAllDevicesUnderUnitsIsDisplayed(usageReportPage.SerialNumberUnit4Column, UsageReportPage.ExpectedValues.Unit4CSMDevicesSerialNumber);
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string columnHeading)
        {
            IWebElement column=null;
            string ExpectedColumnHeading = "";

            //For usage report
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("csm usage report table elements"))
            {
                switch (columnHeading.ToLower().Trim())
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

                    default:
                        Assert.Fail(columnHeading + " is a invalid heading.");
                        break;
                }
            }
            //for Configuration update report
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("csm configuration update status report table elements"))
            {
                switch (columnHeading.ToLower().Trim())
                {
                    case "serial number":
                        column = csmConfigStatusPage.SerialNumberHeading;
                        ExpectedColumnHeading = CSMConfigStatusPage.ExpectedValues.SerialNumberHeadingText;
                        break;

                    case "configuration":
                        column = csmConfigStatusPage.ConfigurationHeading;
                        ExpectedColumnHeading = CSMConfigStatusPage.ExpectedValues.ConfigurationHeadingText;
                        break;

                    case "location":
                        column = csmConfigStatusPage.LocationHeading;
                        ExpectedColumnHeading = CSMConfigStatusPage.ExpectedValues.LocationHeadingText;
                        break;

                    case "status":
                        column = csmConfigStatusPage.StatusHeading;
                        ExpectedColumnHeading = CSMConfigStatusPage.ExpectedValues.StatusHeadingText;
                        break;

                    case "last deployed":
                        column = csmConfigStatusPage.LastDeployedHeading;
                        ExpectedColumnHeading = CSMConfigStatusPage.ExpectedValues.LastDeployedHeadingText;
                        break;
                    case "last connected":
                        column = csmConfigStatusPage.LastConnectedHeading;
                        ExpectedColumnHeading = CSMConfigStatusPage.ExpectedValues.LastConnectedHeadingText;
                        break;

                    default:
                        Assert.Fail(columnHeading + " is a invalid heading name.");
                        break;
                }
            }
            //For CSM Firmware upgrade report
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("csm firmware upgrade status report page table elements"))
            {
                switch (columnHeading.ToLower().Trim())
                {
                    case "serial number":
                        column = firmwareStatusPage.SerialNumberHeading;
                        ExpectedColumnHeading = FirmwareStatusPage.ExpectedValues.SerialNumberHeadingText;
                        break;

                    case "firmware version":
                        column = firmwareStatusPage.FirmwareVerionHeading;
                        ExpectedColumnHeading = FirmwareStatusPage.ExpectedValues.FirmwareVesrionHeadingText;
                        break;

                    case "location":
                        column = firmwareStatusPage.LocationHeading;
                        ExpectedColumnHeading = FirmwareStatusPage.ExpectedValues.LocationHeadingText;
                        break;

                    case "status":
                        column = firmwareStatusPage.StatusHeading;
                        ExpectedColumnHeading = FirmwareStatusPage.ExpectedValues.StatusHeadingText;
                        break;

                    case "last deployed":
                        column = firmwareStatusPage.LastDeployedHeading;
                        ExpectedColumnHeading = FirmwareStatusPage.ExpectedValues.LastDeployedHeadingText;
                        break;
                    case "last connected":
                        column = firmwareStatusPage.LastConnectedHeading;
                        ExpectedColumnHeading = FirmwareStatusPage.ExpectedValues.LastConnectedHeadingText;
                        break;

                    default:
                        Assert.Fail(columnHeading + " is a invalid heading name.");
                        break;
                }
            }
            //For CSM Acitivity report
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("csm activity report page table elements"))
            {
                switch (columnHeading.ToLower().Trim())
                {
                    case "serial number":
                        column = activityReportPage.SerialNumberHeading;
                        ExpectedColumnHeading = ActivityReportPage.ExpectedValues.SerialNumberHeadingText;
                        break;

                    case "location":
                        column = activityReportPage.LocationHeading;
                        ExpectedColumnHeading = ActivityReportPage.ExpectedValues.LocationHeadingText;
                        break;

                    case "last vital sent":
                        column = activityReportPage.LastVitalSentHeading;
                        ExpectedColumnHeading = ActivityReportPage.ExpectedValues.LastVitalSentHeadingText;
                        break;

                    default:
                        Assert.Fail(columnHeading + " is a invalid heading name.");
                        break;
                }
            }
            else
            {
                Assert.Fail(_scenarioContext.ScenarioInfo.Title + " does not have step defination for " + _scenarioContext.StepContext.StepInfo.Text);
            }

            Assert.AreEqual(true, column.GetElementVisibility(),columnHeading+" is not displayed");
            Assert.AreEqual(ExpectedColumnHeading.ToLower(), column.Text.ToLower(),columnHeading+" is not matching with the expected value.");

        }


        [Then(@"""(.*)"" label is in column (.*)")]
        public void ThenLabelIsInColumn(string columnHeading, int columnNumber)
        {
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("csm usage report table elements columns"))
            {
                IList<IWebElement> columns = usageReportPage.TableHeader.FindElements(By.TagName("div"));
                Assert.AreEqual(columnHeading.ToLower().Trim(), columns[columnNumber - 1].Text.ToLower(), columnHeading + " is not in " + columnNumber);
            }
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("csm configuration update status report table elements columns"))
            {
                IList<IWebElement> columns = csmConfigStatusPage.TableHeading.FindElements(By.TagName("div"));
                Assert.AreEqual(columnHeading.ToLower().Trim(), columns[columnNumber - 1].Text.ToLower(), columnHeading + " is not in " + columnNumber);
            }
            else if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("csm firmware upgrade status report page table elements columns"))
            {
                IList<IWebElement> columns = firmwareStatusPage.TableHeader.FindElements(By.TagName("div"));
                Assert.AreEqual(columnHeading.ToLower().Trim(), columns[columnNumber - 1].Text.ToLower(), columnHeading + " is not in " + columnNumber);
            }
            else if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("csm activity report page table elements columns"))
            {
                IList<IWebElement> columns = activityReportPage.TableHeading.FindElements(By.TagName("div"));
                Assert.AreEqual(columnHeading.ToLower().Trim(), columns[columnNumber - 1].Text.ToLower(), columnHeading + " is not in " + columnNumber);
            }
            else
            {
                Assert.Fail(_scenarioContext.ScenarioInfo.Title + " does not have step defination for " + _scenarioContext.StepContext.StepInfo.Text);
            }
               
        }

        [When(@"user clicks unit row")]
        public void WhenUserClicksUnitRow()
        {
            if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("csm usage report table toggle"))
            {
                usageReportPage.Station1.Click();
            }
            else if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("csm firmware version report table toggle"))
            {
                firmwareVersionPage.Unit1Row.Click();
            }
            else
            {
                //If this test step does not belong to any scenario
                Assert.Fail(_scenarioContext.ScenarioInfo.Title + " does not have step defination for " + _scenarioContext.StepContext.StepInfo.Text);
            }
            
        }

        [Then(@"assets for unit are hidden")]
        public void ThenAssetsForUnitAreHidden()
        {
            //Checking the visibility of entire device table
                Assert.AreEqual(false, usageReportPage.Station1Devices.GetElementVisibility(), "Assets for units are not hidden");
        }

        [Then(@"assets for unit are displayed")]
        public void ThenAssetsForUnitAreDisplayed()
        {
            Assert.AreEqual(true, firmwareVersionPage.Unit1RowDetails.GetElementVisibility(), "Unit 1 rows are displayed");
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

        [Then(@"rows below Total are displayed")]
        public void ThenRowsBelowTotalAreDisplayed()
        {
            Assert.AreEqual(true, firmwareVersionPage.TotalRowDetails.GetElementVisibility(), message: "Rows below table are displayed.");
        }

        [When(@"user clicks Print button")]
        public void WhenUserClicksPrintButton()
        {
            reportsPage.PrintButton.Click();
        }

        [Then(@"browser’s built-in print dialog is displayed")]
        public void ThenBrowserSBuilt_InPrintDialogIsDisplayed()
        {
            //find solution to handle print dialog
            _scenarioContext.Pending();
        }


        [Given(@"Configuration Update Status Report type is selected")]
        public void GivenConfigurationUpdateStatusReportTypeIsSelected()
        {
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.ConfigurationReportType);
        }

        [Then(@"Configuration Update Status Report \(CSM\) label is displayed")]
        public void ThenConfigurationUpdateStatusReportCSMLabelIsDisplayed()
        {
            Assert.AreEqual(true, csmConfigStatusPage.ReportTitle.GetElementVisibility(),"Configuration update status report label is not displayed.");
            Assert.AreEqual(CSMConfigStatusPage.ExpectedValues.ConfigurationUpdateStatusCSMLabelText.ToLower(),csmConfigStatusPage.ReportTitle.Text.ToLower(),"Configuration update status report is not matching with the expected value.");
        }

        [Then(@"Information button is displayed")]
        public void ThenInformationButtonIsDisplayed()
        {
            Assert.AreEqual(true, reportsPage.InformationButton.GetElementVisibility(),"Information button is not displayed.");
        }

        [Then(@"Download button is displayed")]
        public void ThenDownloadButtonIsDisplayed()
        {
            Assert.AreEqual(true, reportsPage.DownloadButton.GetElementVisibility(),"Download button is not displayed.");
        }

        [Then(@"Search box is displayed")]
        public void ThenSearchBoxIsDisplayed()
        {
            Assert.AreEqual(true, csmConfigStatusPage.SearchBox.GetElementVisibility(),"Search box is not displayed.");
        }

        [Then(@"Previous page icon is displayed")]
        public void ThenPreviousPageIconIsDisplayed()
        {
            Assert.AreEqual(true, csmConfigStatusPage.PreviousPaginationIcon.GetElementVisibility(),"Previous pagination icon is not displayed.");
        }

        [Then(@"Next page icon is displayed")]
        public void ThenNextPageIconIsDisplayed()
        {
            Assert.AreEqual(true, csmConfigStatusPage.NextPaginationIcon.GetElementVisibility(),"Next page pagination icon is not displayed.");
        }

        [Then(@"Page x of y indicator is displayed")]
        public void ThenPageXOfYIndicatorIsDisplayed()
        {
            Assert.AreEqual(true, csmConfigStatusPage.PageXOfY.GetElementVisibility(), "Page x of y label is not displayed.");
        }

        [Then(@"Displaying x to y of z results indicator is displayed")]
        public void ThenDisplayingXToYOfZResultsIndicatorIsDisplayed()
        {
            Assert.AreEqual(true,csmConfigStatusPage.PageDisplay.GetElementVisibility(),"Displaying x of z results indicator is displayed.");
        }


        [Given(@"user is on CSM Configuration Update Status Report page")]
        public void GivenUserIsOnCSMConfigurationUpdateStatusReportPage()
        {
            GivenUserIsOnReportPage();
            reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CSMDeviceName);
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.ConfigurationReportType);
            reportsPage.GetReportButton.Click();
        }

        [Given(@"Firmware Status Report type is selected")]
        public void GivenFirmwareStatusReportTypeIsSelected()
        {
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareStatusReportType);
        }

        [Then(@"Firmware Upgrade Status Report \(CSM\) label is displayed")]
        public void ThenFirmwareUpgradeStatusReportCSMLabelIsDisplayed()
        {
            Assert.AreEqual(true, firmwareStatusPage.FirmwareReportTitle.GetElementVisibility(),"Firmware upgrade status report csm is not displayed");
            Assert.AreEqual(FirmwareStatusPage.ExpectedValues.FirmwareUpgradeStatusCSMLabel.ToLower(), firmwareStatusPage.FirmwareReportTitle.Text.ToLower(), "Firmware upgrade status report CSM is not matching with the expected value.");
        }

        [Given(@"user is on CSM Firmware Upgrade Status Report page")]
        public void GivenUserIsOnCSMFirmwareUpgradeStatusReportPage()
        {
            GivenUserIsOnReportPage();
            reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CSMDeviceName);
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareStatusReportType);
            reportsPage.GetReportButton.Click();
        }

        [Given(@"Activity Report type is selected")]
        public void GivenActivityReportTypeIsSelected()
        {
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.ActivityReportType);
        }

        [Then(@"Activity Report \(CSM\) label is displayed")]
        public void ThenActivityReportCSMLabelIsDisplayed()
        {
            Assert.AreEqual(true, activityReportPage.ActivityReportHeader.GetElementVisibility(),"Activity report header label is not displayed.");
            Assert.AreEqual(ActivityReportPage.ExpectedValues.ActivityReportCSMHeader.ToLower(),activityReportPage.ActivityReportHeader.Text.ToLower(),"Activity report header is not matching with the expected value.");
        }

        [Given(@"user is on CSM Activity Report page")]
        public void GivenUserIsOnCSMActivityReportPage()
        {
            GivenUserIsOnReportPage();
            reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CSMDeviceName);
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.ActivityReportType);
            reportsPage.GetReportButton.Click();
        }


    }
}
