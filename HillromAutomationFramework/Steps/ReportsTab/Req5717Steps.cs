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
using System.Threading;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.ReportsTab
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5717")]
    public class Req5717Steps
    {
        //POM
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly ReportsPage _reportsPage;
        private readonly UsageReportPage _usageReportPage;
        private readonly FirmwareVersionReportPage _firmwareVersionPage;
        private readonly FirmwareStatusReportPage _firmwareStatusPage;
        private readonly ConfigStatusReportPage _csmConfigStatusPage;
        private readonly ActivityReportPage _activityReportPage;

        private readonly WebDriverWait _wait;
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        private static List<string> listOfDeviceSerialNumber;

        public Req5717Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
            _reportsPage = new ReportsPage(driver);
            _usageReportPage = new UsageReportPage(driver);
            _firmwareVersionPage = new FirmwareVersionReportPage(driver);
            _firmwareStatusPage = new FirmwareStatusReportPage(driver);
            _csmConfigStatusPage = new ConfigStatusReportPage(driver);
            _activityReportPage = new ActivityReportPage(driver);
        }


        [Given(@"user is on Reports page")]
        public void GivenUserIsOnReportPage()
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest2Title.Click();
            _wait.Message = "Asset list is not displayed in main page.Timed out after 10 seconds.";
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.ReportsTab.JavaSciptClick(_driver);
        }
        
        [Given(@"CSM Asset type is selected")]
        public void GivenCSMAssetTypeIsSelected()
        {
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPageExpectedValues.CSMDeviceName);
        }
        
        [When(@"user clicks report type dropdown")]
        public void WhenUserClicksReportTypeDropdown()
        {
            _reportsPage.ReportTypeDDL.Click();
        }
        
        [Then(@"Report type dropdown displays ""(.*)""")]
        public void ThenReportTypeDropdownDisplays(string dropdownOptions)
        {
            //Spliting Based on comma for getting parameter
            List<string> ExpecteddropdownOptionsList = new List<string>(dropdownOptions.Split(",").Select(option => option.Trim().ToLower()).ToArray());
            //Actual List
            List<string> ActualOptionList = new List<string>(_reportsPage.ReportTypeDDL.GetAllOptionsFromDDL().Select(x => x.Text.ToLower()));
            //Getting the actual option from the dropdown list.
            ActualOptionList.Remove("select"); //Removing the select item
            //Asserting
            ActualOptionList.Should().BeEquivalentTo(ExpecteddropdownOptionsList,"it should contain only that report which supported by CSM device");
        }


        [Given(@"Usage Report type is selected")]
        public void GivenUsageReportTypeIsSelected()
        {
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.UsageReportType);
        }

        [When(@"user clicks Get report button")]
        public void WhenUserClicksGetReportButton()
        {
            _reportsPage.GetReportButton.Click();
        }

        [Then(@"Asset Usage Report \(CSM\) label is displayed")]
        public void ThenAssetUsageReportCSMLabelIsDisplayed()
        {
            (_usageReportPage.ReportsTitleHeader.GetElementVisibility()).Should().BeTrue("Report title should be displayed in Usage report");
            (_usageReportPage.ReportsTitleHeader.Text).Should().BeEquivalentTo(UsageReportPageExpectedValues.ReportTiltleHeaderCSM,"Usage report titlr header should match the expected string.");
        }

        [Then(@"Print button is displayed")]
        public void ThenPrintButtonIsDisplayed()
        {
            (_reportsPage.PrintButton.GetElementVisibility()).Should().BeTrue("Print button should be displayed in Report page");
        }

        [Then(@"Number of Assets By Unit label is displayed")]
        public void ThenNumberOfAssetsByUnitLabelIsDisplayed()
        {
            (_usageReportPage.NumberOfdevicesOneachFloorLabel.GetElementVisibility()).Should().BeTrue("Number of Assets By Unit label should be displayed in usage report page.");
            (_usageReportPage.NumberOfdevicesOneachFloorLabel.Text).Should().BeEquivalentTo(UsageReportPageExpectedValues.NumberOfAssetsByUnitLabelText, "Number of Assets By Unit label should match the expected text.");
        }

        [Then(@"pie chart is displayed")]
        public void ThenPieChartIsDisplayed()
        {
            (_usageReportPage.PieChart.GetElementVisibility()).Should().BeTrue("Pie chart should be displayed in Usage report page");
        }

        [Then(@"Total Usage Details - Components label is displayed")]
        public void ThenTotalUsageDetails_ComponentsLabelIsDisplayed()
        {
            (_usageReportPage.TotalUsageComponentsLabel.GetElementVisibility()).Should().BeTrue("Total Usage Label should be displayed in Usage report page");
            (_usageReportPage.TotalUsageComponentsLabel.Text).Should().BeEquivalentTo(UsageReportPageExpectedValues.TotalUsageDetailsComponentLabelText,"Total usage label should match the expected value.");
        }


        [Given(@"user is on CSM Usage Report page")]
        public void GivenUserIsOnCSMUsageReportsPage()
        {
            GivenUserIsOnReportPage();
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPageExpectedValues.CSMDeviceName);
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.UsageReportType);
            _reportsPage.GetReportButton.Click();
        }

        [Then(@"Assets are grouped by unit")]
        public void ThenAssetsAreGroupedByUnit()
        {
            SetMethods.ScrollToBottomofWebpage(_driver);
            int unitCount = _usageReportPage.UnitsRowList.GetElementCount();
            for(int row=0;row<unitCount;row++)
            {
                IWebElement deviceParent = _driver.FindElement(By.Id("devices" + row)).FindElement(By.XPath(".."));
                IWebElement unitParent = _driver.FindElement(By.Id("location" + row)).FindElement(By.XPath(".."));
                if(!(deviceParent.Equals(unitParent)))
                {
                    Assert.Fail("Assets are not grouped by unit.");
                }
            }
        }

        [Then(@"all devices within each unit are displayed")]
        public void ThenAllTheDevicesWithinThatUnitIsDisplayed()
        {
            //Unit1
            listOfDeviceSerialNumber = new List<string>(UsageReportPageExpectedValues.Unit1CSMDeviceSerialNumbers.Split(",").ToList());
            _usageReportPage.CheckAllDevicesUnderUnitsIsDisplayed(_usageReportPage.SerialNumberUnit1Column, listOfDeviceSerialNumber);

            //Unit2
            listOfDeviceSerialNumber = new List<string>(UsageReportPageExpectedValues.Unit2CSMDevicesSerialNumber.Split(",").ToList());
            _usageReportPage.CheckAllDevicesUnderUnitsIsDisplayed(_usageReportPage.SerialNumberUnit2Column, listOfDeviceSerialNumber);

            //Unit3
            listOfDeviceSerialNumber = new List<string>(UsageReportPageExpectedValues.Unit3CSMDevicesSerialNumber.Split(",").ToList());
            _usageReportPage.CheckAllDevicesUnderUnitsIsDisplayed(_usageReportPage.SerialNumberUnit3Column, listOfDeviceSerialNumber);

            //Unit4
            listOfDeviceSerialNumber = new List<string>(UsageReportPageExpectedValues.Unit4CSMDevicesSerialNumber.Split(",").ToList());
            _usageReportPage.CheckAllDevicesUnderUnitsIsDisplayed(_usageReportPage.SerialNumberUnit4Column, listOfDeviceSerialNumber);
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string columnHeading)
        {
            IWebElement column=null;

            //For usage report
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("csm usage report table elements"))
            {
                switch (columnHeading.ToLower().Trim())
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
                        Assert.Fail(columnHeading + " is a invalid heading.");
                        break;
                }
                (column.GetElementVisibility()).Should().BeTrue(columnHeading+" column heading should be displayed in Usage report page");
                (column.Text).Should().BeEquivalentTo(columnHeading, because: columnHeading + " should match the expected value in usage report column heading.");
            }
            //for Configuration update report
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("csm configuration update status report table elements"))
            {
                switch (columnHeading.ToLower().Trim())
                {
                    case "serial number":
                        column = _csmConfigStatusPage.SerialNumberHeading;
                        break;

                    case "configuration":
                        column = _csmConfigStatusPage.ConfigurationHeading;
                        break;

                    case "ownership":
                        column = _csmConfigStatusPage.LocationHeading;
                        break;

                    case "status":
                        column = _csmConfigStatusPage.StatusHeading;
                        break;

                    case "last deployed":
                        column = _csmConfigStatusPage.LastDeployedHeading;
                        break;
                    case "last connected":
                        column = _csmConfigStatusPage.LastConnectedHeading;
                        break;

                    default:
                        Assert.Fail(columnHeading + " is a invalid heading name.");
                        break;
                }
                (column.GetElementVisibility()).Should().BeTrue(columnHeading + " column heading should be displayed in Configuration update status report page");
                (column.Text).Should().BeEquivalentTo(columnHeading, because:columnHeading + " should match the expected value.");
            }
            //For CSM Firmware upgrade report
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("csm firmware upgrade status report page table elements"))
            {
                switch (columnHeading.ToLower().Trim())
                {
                    case "serial number":
                        column = _firmwareStatusPage.SerialNumberHeading;
                        break;

                    case "firmware version":
                        column = _firmwareStatusPage.FirmwareVerionHeading;
                        break;

                    case "ownership":
                        column = _firmwareStatusPage.LocationHeading;
                        break;

                    case "status":
                        column = _firmwareStatusPage.StatusHeading;
                        break;

                    case "last deployed":
                        column = _firmwareStatusPage.LastDeployedHeading;
                        break;
                    case "last connected":
                        column = _firmwareStatusPage.LastConnectedHeading;
                        break;

                    default:
                        Assert.Fail(columnHeading + " is a invalid heading name.");
                        break;
                }
                (column.GetElementVisibility()).Should().BeTrue(columnHeading + " column heading should be displayed in Firmware upgrade status report page");
                (column.Text).Should().BeEquivalentTo(columnHeading, because: columnHeading + " should match the expected value.");
            }
            //For CSM Acitivity report
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("csm activity report page table elements"))
            {
                switch (columnHeading.ToLower().Trim())
                {
                    case "serial number":
                        column = _activityReportPage.SerialNumberHeading;
                        break;

                    case "ownership unit":
                        column = _activityReportPage.OwnershipUnitHeading;
                        break;

                    case "ap location":
                        column = _activityReportPage.LocationHeading;
                        break;

                    case "battery charge level":
                        column = _activityReportPage.BatteryChargeLevelHeading;
                        break;
                        
                    case "battery cycle count":
                        column = _activityReportPage.BatteryCycleCountHeading;
                        break;

                    case "maximum capacity":
                        column = _activityReportPage.MaximumCapacityHeading;
                        break;

                    case "replace?":
                        column = _activityReportPage.ReplaceHeading;
                        break;

                    case "last vitals sent":
                        column = _activityReportPage.LastVitalSentHeading;
                        break;

                    case "pm due":
                        column = _activityReportPage.PMDueHeading;
                        break;

                    default:
                        Assert.Fail(columnHeading + " is a invalid heading name.");
                        break;
                }
                (column.GetElementVisibility()).Should().BeTrue(columnHeading + " column heading should be displayed in Activity report page");
                (column.Text).Should().BeEquivalentTo(columnHeading, because:columnHeading + " should match the expected value.");
            }
            //If Test step does not belong to any secnario
            else
            {
                Assert.Fail(_scenarioContext.ScenarioInfo.Title + " does not have step defination for " + _scenarioContext.StepContext.StepInfo.Text);
            }

        }


        [Then(@"""(.*)"" label is in column (.*)")]
        public void ThenLabelIsInColumn(string columnHeading, int columnNumber)
        {
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("csm usage report table elements columns"))
            {
                IList<IWebElement> columnsList = _usageReportPage.TableHeader.FindElements(By.TagName("div"));
                List<string> columnListText = new List<string>();
                foreach (IWebElement column in columnsList)
                {
                    columnListText.Add(column.Text.ToLower());
                }
                //Making as zero based Indexing
                columnNumber--;
                columnListText.Should().HaveElementAt(columnNumber, columnHeading.ToLower(), because: columnHeading + " column heading should be in column number " + columnNumber);
            }
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("csm configuration update status report table elements columns"))
            {
                IList<IWebElement> columnsList = _csmConfigStatusPage.TableHeading.FindElements(By.TagName("div"));
                List<string> columnListText = new List<string>();
                foreach (IWebElement column in columnsList)
                {
                    columnListText.Add(column.Text.ToLower());
                }
                //Making as zero based Indexing
                columnNumber--;
                columnListText.Should().HaveElementAt(columnNumber, columnHeading.ToLower(), because: columnHeading + " column heading should be in column number " + columnNumber);
            }
            else if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("csm firmware upgrade status report page table elements columns"))
            {
                IList<IWebElement> columnsList = _firmwareStatusPage.TableHeader.FindElements(By.TagName("div"));
                List<string> columnListText = new List<string>();
                foreach (IWebElement column in columnsList)
                {
                    columnListText.Add(column.Text.ToLower());
                }
                //Making as zero based Indexing
                columnNumber--;
                columnListText.Should().HaveElementAt(columnNumber, columnHeading.ToLower(), because: columnHeading + " column heading should be in column number " + columnNumber);
            }
            else if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("csm activity report page table elements columns"))
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
                _usageReportPage.Station1.Click();
            }
            else if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("csm firmware version report table toggle"))
            {
                _firmwareVersionPage.Unit1Row.Click();
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
            (_usageReportPage.Station1Devices.GetElementVisibility()).Should().BeFalse("Assets under unit should be hidden in usage report page When user clicks on unit row");
        }

        [Then(@"assets for unit are displayed")]
        public void ThenAssetsForUnitAreDisplayed()
        {
            (_firmwareVersionPage.Unit1RowDetails.GetElementVisibility()).Should().BeTrue("Assets under unit should be displayed in firmware version report page When user clicks on unit row");
        }



        [Given(@"Firmware Version Report type is selected")]
        public void GivenFirmwareVersionReportTypeIsSelected()
        {
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.FirmwareVersionReportType);
        }

        [Then(@"Firmware Version Report \(CSM\) label is displayed")]
        public void ThenFirmwareVersionReportCSMLabelIsDisplayed()
        {
            (_firmwareVersionPage.FirmwareReportTitle.GetElementVisibility()).Should().BeTrue("Report header should be displayed in the firmware version report page");
            (_firmwareVersionPage.FirmwareReportTitle.Text).Should().BeEquivalentTo(FirmwareVersionReportPageExpectedValues.ReportCSMLabelText, "Firmware version report header should match the expected value.");
        }

        [Then(@"Components column heading is displayed")]
        public void ThenComponentsColumnHeadingIsDisplayed()
        {
            (_firmwareVersionPage.ComponentsHeading.GetElementVisibility()).Should().BeTrue("Components heading should be displayed in firware version report page.");
            (_firmwareVersionPage.ComponentsHeading.Text).Should().BeEquivalentTo(FirmwareVersionReportPageExpectedValues.ComponentsHeadingText, "Components heading should match the expected value.");
        }

        [Then(@"Firmware version column heading is displayed")]
        public void ThenFirmwareVersionColumnHeadingIsDisplayed()
        {
            (_firmwareVersionPage.FirmwareVersionHeading.GetElementVisibility()).Should().BeTrue("Firmware version heading should be displayed in firmware version report page.");
            (_firmwareVersionPage.FirmwareVersionHeading.Text).Should().BeEquivalentTo(FirmwareVersionReportPageExpectedValues.FirmwareVersionHeadingText, "Firmware version heading text should match the expected value.");
        }

        [Then(@"Total devices column heading is displayed")]
        public void ThenTotalDevicesColumnHeadingIsDisplayed()
        {
            (_firmwareVersionPage.TotaldevicesHeading.GetElementVisibility()).Should().BeTrue("Total devices heading should be displayed in firmware version report page.");
            (_firmwareVersionPage.TotaldevicesHeading.Text).Should().BeEquivalentTo(FirmwareVersionReportPageExpectedValues.TotalDevicesHeadingText, "Total devices heading text should match the expected value.");
        }

        [Given(@"user is on CSM Firmware Version Report page")]
        public void GivenUserIsOnCSMFirmwareVersionReportPage()
        {
            GivenUserIsOnReportPage();
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPageExpectedValues.CSMDeviceName);
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
            (_firmwareVersionPage.TotalRowDetails.GetElementVisibility()).Should().BeTrue("Rows below total should be displayed when user clicks total row in firmware version report.");
        }

        [Then(@"the Print button is enabled"),Scope(Tag = "TestCaseID_9378", Scenario = "CSM Firmware Version Report Print")]
        public void ThenThePrintButtonIsEnabledFirmwareVersionReport()
        {
            (_firmwareVersionPage.PrintButton.Enabled).Should().BeTrue("Print button should be enabled in Firmware version report page");
        }

        [Then(@"the Print button is enabled"),Scope(Tag = "TestCaseID_9383", Scenario = "CSM Configuration Update Status Report Print")]
        public void ThenThePrintButtonIsEnabledConfigurationUpdateStatus()
        {
            (_csmConfigStatusPage.PrintButton.Enabled).Should().BeTrue(because: "Print button should be enabled in Firmware version report page");
        }

        [Then(@"the Print button is enabled"),Scope(Tag = "TestCaseID_9388",Scenario = "CSM Firmware Upgrade Status Report Print")]
        public void ThenThePrintButtonIsEnabledFirmwareUpgrade()
        {
            (_firmwareStatusPage.PrintButton.Enabled).Should().BeTrue(because: "Print button should be enabled in Firmware Upgrade status report page");
        }


        [Given(@"Configuration Update Status Report type is selected")]
        public void GivenConfigurationUpdateStatusReportTypeIsSelected()
        {
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.ConfigurationReportType);
        }

        [Then(@"Configuration Update Status Report \(CSM\) label is displayed")]
        public void ThenConfigurationUpdateStatusReportCSMLabelIsDisplayed()
        {
            (_csmConfigStatusPage.ReportTitle.GetElementVisibility()).Should().BeTrue(because: "Report Title label should be displayed in Configurayion update status report page");
            (_csmConfigStatusPage.ReportTitle.Text).Should().BeEquivalentTo(ConfigStatusReportPageExpectedValues.ConfigurationUpdateStatusCSMLabelText, because: "Configuration update status report title should match with the expected value.");
        }

        [Then(@"Information button is displayed")]
        public void ThenInformationButtonIsDisplayed()
        {
            (_reportsPage.InformationButton.GetElementVisibility()).Should().BeTrue("Information button should be displayed in Reports page");
        }

        [Then(@"Download button is displayed")]
        public void ThenDownloadButtonIsDisplayed()
        {
            (_reportsPage.DownloadButton.GetElementVisibility()).Should().BeTrue("Download button should be displayed in Reports page");
        }

        [Then(@"Search box is displayed")]
        public void ThenSearchBoxIsDisplayed()
        {
            (_csmConfigStatusPage.SearchBox.GetElementVisibility()).Should().BeTrue("Search Box should be displayed in Reports page");
        }

        [Then(@"Previous page icon is displayed")]
        public void ThenPreviousPageIconIsDisplayed()
        {
            (_csmConfigStatusPage.PreviousPaginationIcon.GetElementVisibility()).Should().BeTrue("Previous page pagination icon should be displayed in reports page.");
        }

        [Then(@"Next page icon is displayed")]
        public void ThenNextPageIconIsDisplayed()
        {
            (_csmConfigStatusPage.NextPaginationIcon.GetElementVisibility()).Should().BeTrue("Next page pagination icon should be displayed in reports page.");
        }

        [Then(@"Page x of y indicator is displayed")]
        public void ThenPageXOfYIndicatorIsDisplayed()
        {
            (_csmConfigStatusPage.PageXOfY.GetElementVisibility()).Should().BeTrue("Page x of y label should be displayed in reports page.");
        }

        [Then(@"Displaying x to y of z results indicator is displayed")]
        public void ThenDisplayingXToYOfZResultsIndicatorIsDisplayed()
        {
            (_csmConfigStatusPage.PageDisplay.GetElementVisibility()).Should().BeTrue("Displaying x of z results indicator should be displayed in reports page.");
        }


        [Given(@"user is on CSM Configuration Update Status Report page")]
        public void GivenUserIsOnCSMConfigurationUpdateStatusReportPage()
        {
            GivenUserIsOnReportPage();
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPageExpectedValues.CSMDeviceName);
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.ConfigurationReportType);
            _reportsPage.GetReportButton.Click();
        }

        [Given(@"Firmware Status Report type is selected")]
        public void GivenFirmwareStatusReportTypeIsSelected()
        {
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.FirmwareStatusReportType);
        }

        [Then(@"Firmware Upgrade Status Report \(CSM\) label is displayed")]
        public void ThenFirmwareUpgradeStatusReportCSMLabelIsDisplayed()
        {
            (_firmwareStatusPage.FirmwareReportTitle.GetElementVisibility()).Should().BeTrue("Report title should be displayed in Firmware upgrade status report page.");
            (_firmwareStatusPage.FirmwareReportTitle.Text).Should().BeEquivalentTo(FirmwareStatusReportPageExpectedValues.FirmwareUpgradeStatusCSMLabel,because: "Firmware upgrade status report label should match the expected value.");
        }

        [Given(@"user is on CSM Firmware Upgrade Status Report page")]
        public void GivenUserIsOnCSMFirmwareUpgradeStatusReportPage()
        {
            GivenUserIsOnReportPage();
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPageExpectedValues.CSMDeviceName);
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.FirmwareStatusReportType);
            _reportsPage.GetReportButton.Click();
        }

        [Given(@"Activity Report type is selected")]
        public void GivenActivityReportTypeIsSelected()
        {
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.ActivityReportType);
        }

        [Then(@"Activity Report \(CSM\) label is displayed")]
        public void ThenActivityReportCSMLabelIsDisplayed()
        {
            (_activityReportPage.ActivityReportHeader.GetElementVisibility()).Should().BeTrue(because: "Activity report header label should be displayed in Activity report page");
            (_activityReportPage.ActivityReportHeader.Text).Should().BeEquivalentTo(ActivityReportPageExpectedValues.ActivityReportCSMHeader, because: "Activity report header text should match the expected value.");
        }

        [Given(@"user is on CSM Activity Report page")]
        public void GivenUserIsOnCSMActivityReportPage()
        {
            GivenUserIsOnReportPage();
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPageExpectedValues.CSMDeviceName);
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.ActivityReportType);
            _reportsPage.GetReportButton.Click();
        }

        [When(@"user clicks Serial number column heading")]
        public void WhenUserClicksSerialNumberColumnHeading()
        {
            _csmConfigStatusPage.SerialNumberHeading.Click();
        }

        [When(@"user clicks ""(.*)"" column heading")]
        public void WhenUserClicksColumnHeading(string columnName)
        {
            switch(columnName.ToLower().Trim())
            {
                case "serial number":
                    _csmConfigStatusPage.SerialNumberHeading.Click();
                    break;

                default: Assert.Fail(columnName + " is an invalid column Name");
                    break;
            }
            //Wait till data is loaded
            Thread.Sleep(2000);
        }

        [Then(@"logs are sorted by increasing ""(.*)""")]
        public void ThenLogsAreSortedByIncreasing(string columnName)
        {  
            List<string> columnDataList = _csmConfigStatusPage.GetColumnData(_driver, columnName);
            columnDataList.Should().BeInAscendingOrder("logs should be sorted by"+columnName+ " in ascending order.");
        }

        [Then(@"increasing ""(.*)"" sorting indicator is displayed")]
        public void ThenIncreasingSortingIndicatorIsDisplayed(string columnName)
        {
            IWebElement columnWebElement=null;
            switch(columnName.ToLower().Trim())
            {
                case "serial number":
                    columnWebElement = _csmConfigStatusPage.SerialNumberHeading;
                    break;
                default: Assert.Fail(columnName + " is an invalid column Name");
                    break;
            }
            string columnnIndiatorURL = columnWebElement.GetCssValue("background-image");
            (columnnIndiatorURL).Should().BeEquivalentTo("url(\"" + PropertyClass.BaseURL + ConfigStatusReportPageExpectedValues.IncreasingSortIndicatorURL+ "\")", because:"Increasing sort indicator should be displayed beside " + columnName + " when logs are sorted in ascending order.");
        }

        [Then(@"logs are sorted by decreasing ""(.*)""")]
        public void ThenLogsAreSortedByDecreasing(string columnName)
        {
            List<string> columnDataList = _csmConfigStatusPage.GetColumnData(_driver, columnName);
            columnDataList.Should().BeInDescendingOrder("logs should be sorted by" + columnName+" in descending order.");
        }

        [Then(@"decreasing ""(.*)"" sorting indicator is displayed")]
        public void ThenDecreasingSortingIndicatorIsDisplayed(string columnName)
        {
            IWebElement columnWebElement = null;
            switch (columnName.ToLower().Trim())
            {
                case "serial number":
                    columnWebElement = _csmConfigStatusPage.SerialNumberHeading;
                    break;
                default:
                    Assert.Fail(columnName + " is an invalid column Name");
                    break;
            }
            string columnnIndiatorURL = columnWebElement.GetCssValue("background-image");
            (columnnIndiatorURL).Should().BeEquivalentTo("url(\"" + PropertyClass.BaseURL + ConfigStatusReportPageExpectedValues.DecreasingSortIndicatorURL + "\")", because: "Decreasing sort indicator should be displayed beside" + columnName + "when logs are sorted in desending order order.");
        }



    }
}
