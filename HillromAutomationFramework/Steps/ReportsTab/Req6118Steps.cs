using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.ReportsTab;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.ReportsTab
{
    [Binding,Scope(Tag = "SoftwareRequirementID_6118")]
    public class Req6118Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly ReportsPage _reportsPage;
        private readonly FirmwareVersionReportPage _firmwareVersionPage;
        private readonly FirmwareStatusReportPage _firmwareStatusPage;


        private readonly WebDriverWait _wait;
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public Req6118Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
            _reportsPage = new ReportsPage(driver);
            _firmwareVersionPage = new FirmwareVersionReportPage(driver);
            _firmwareStatusPage = new FirmwareStatusReportPage(driver);
        }


        [Given(@"user is on Reports page")]
        public void GivenUserIsOnReportsPage()
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.ReportsTab.JavaSciptClick(_driver);
        }
        
        [Given(@"RV700 Asset type is selected")]
        public void GivenRVAssetTypeIsSelected()
        {
            //Selecting RV700 decice type
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPageExpectedValues.RV700DeviceName);

        }
        
        [Given(@"Firmware Version Report type is selected")]
        public void GivenFirmwareVersionReportTypeIsSelected()
        {
            //Selecting firmware version in the report type dropdown
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.FirmwareVersionReportType);
        }
        
        [When(@"user clicks Get report button")]
        public void WhenUserClicksGetReportButton()
        {
            _reportsPage.GetReportButton.Click();
        }
        
        [Then(@"Firmware Version Report \(RV700\) label is displayed")]
        public void ThenFirmwareVersionReportRVLabelIsDisplayed()
        {
            (_firmwareVersionPage.FirmwareReportTitle.GetElementVisibility()).Should().BeTrue("Firmware version report header should be displayed in Firmware Version Report Page.");
            (_firmwareVersionPage.FirmwareReportTitle.Text).Should().BeEquivalentTo(FirmwareVersionReportPageExpectedValues.ReportRV700LabelText, "Firmware version report header text should match the expected value.");
        }
        
        [Then(@"Components column heading is displayed")]
        public void ThenComponentsColumnHeadingIsDisplayed()
        {
            (_firmwareVersionPage.ComponentsHeading.GetElementVisibility()).Should().BeTrue("Components column heading should be displayed in Firmware Version Report page.");
            (_firmwareVersionPage.ComponentsHeading.Text).Should().BeEquivalentTo(FirmwareVersionReportPageExpectedValues.ComponentsHeadingText, "Components coumn heading should match the expected value");
        }
        
        [Then(@"Firmware version column heading is displayed")]
        public void ThenFirmwareVersionColumnHeadingIsDisplayed()
        {
            (_firmwareVersionPage.FirmwareVersionHeading.GetElementVisibility()).Should().BeTrue("Firmware version column heading should be displayed in Firmware Version Report page.");
            (_firmwareVersionPage.FirmwareVersionHeading.Text).Should().BeEquivalentTo(FirmwareVersionReportPageExpectedValues.FirmwareVersionHeadingText, because: "Firmware version column heading text should match the expected value.");
        }
        
        [Then(@"Total devices column heading is displayed")]
        public void ThenTotalDevicesColumnHeadingIsDisplayed()
        {
            (_firmwareVersionPage.TotaldevicesHeading.GetElementVisibility()).Should().BeTrue("Total devices column heading should be displayed in Firmware Version Report page.");
            (_firmwareVersionPage.TotaldevicesHeading.Text).Should().BeEquivalentTo(FirmwareVersionReportPageExpectedValues.TotalDevicesHeadingText, because: "Total devices heading text should match with the expected value.");
        }

        [Given(@"user is on RV700 Firmware Version Report page")]
        public void GivenUserIsOnRVFirmwareVersionReportPage()
        {
            GivenUserIsOnReportsPage();
            //Selecting RV700 decice type
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPageExpectedValues.RV700DeviceName);
            //Selecting firmware version in the report type dropdown
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
            (_firmwareVersionPage.TotalRowDetails.GetElementVisibility()).Should().BeTrue("Rows below total should be displayed when user clicks on total row  in Firmware Version Report page.");
        }

        [When(@"user clicks unit row")]
        public void WhenUserClicksUnitRow()
        {
            _firmwareVersionPage.Unit1Row.Click();
        }

        [Then(@"assets for unit are displayed")]
        public void ThenAssetsForUnitAreDisplayed()
        {
            (_firmwareVersionPage.Unit1RowDetails.GetElementVisibility()).Should().BeTrue("Assets for unit should be displayed when user clicks unit row.");
        }

        [Then(@"the Print button is enabled"),Scope(Tag = "TestCaseID_9422", Scenario = "RV700 Firmware Upgrade Status Report Print")]
        public void ThenThePrintButtonIsEnabledUpgradeStatus()
        {
            (_firmwareStatusPage.PrintButton.Enabled).Should().BeTrue("Print button should be enabled in RV700 Firmware Upgrade Status Report page");
        }

        [Then(@"the Print button is enabled"), Scope(Tag = "TestCaseID_9419", Scenario = "RV700 Firmware Version Report Print")]
        public void ThenThePrintButtonIsEnabledFirmwareVersion()
        {
            (_firmwareVersionPage.PrintButton.Enabled).Should().BeTrue("Print button should be enabled in RV700 Firmware Version Report page");
        }


        [Given(@"Firmware Status Report type is selected")]
        public void GivenFirmwareStatusReportTypeIsSelected()
        {
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.FirmwareStatusReportType);
        }

        [Then(@"Firmware Upgrade Status Report \(RV700\) label is displayed")]
        public void ThenFirmwareUpgradeStatusReportRVLabelIsDisplayed()
        {
            (_firmwareStatusPage.FirmwareReportTitle.GetElementVisibility()).Should().BeTrue("Firmware upgrade status report (RV700) should be displayed RV700 Firmware Upgrade Status Report page.");
            (_firmwareStatusPage.FirmwareReportTitle.Text).Should().BeEquivalentTo(FirmwareStatusReportPageExpectedValues.FirmwareUpgradeStatusRV700Label, "Firmware upgrade status report (RV700) should match with the expected value.");
        }

        [Then(@"Print button is displayed")]
        public void ThenPrintButtonIsDisplayed()
        {
            (_firmwareStatusPage.PrintButton.GetElementVisibility()).Should().BeTrue("Print button shoul be displayed in RV700 Firmware Upgrade Status Report Page");
        }

        [Then(@"Information button is displayed")]
        public void ThenInformationButtonIsDisplayed()
        {
            (_firmwareStatusPage.InformationButton.GetElementVisibility()).Should().BeTrue("Information button should be displayed in RV700 Firmware Upgrade Status Report Page.");
        }

        [Then(@"Download button is displayed")]
        public void ThenDownloadButtonIsDisplayed()
        {
            bool isDownloadButtonVisible = _firmwareStatusPage.DownloadButton.GetElementVisibility();
            (isDownloadButtonVisible).Should().BeTrue("Download button should be displayed in RV700 Firmware Upgrade Status Report Page.");
        }

        [Then(@"Search box is displayed")]
        public void ThenSearchBoxIsDisplayed()
        {
            (_firmwareStatusPage.SearchBox.GetElementVisibility()).Should().BeTrue("Search box should be displayed in RV700 Firmware Upgrade Status Report Page.");
        }

        [Then(@"Previous page icon is displayed")]
        public void ThenPreviousPageIconIsDisplayed()
        {
            (_firmwareStatusPage.PaginationPreviousIcon.GetElementVisibility()).Should().BeTrue("Previous Page pagination icon should be displayed in RV700 Firmware Upgrade Status Report Page.");
        }

        [Then(@"Next page icon is displayed")]
        public void ThenNextPageIconIsDisplayed()
        {
            (_firmwareStatusPage.PaginationNextIcon.GetElementVisibility()).Should().BeTrue("Next Page pagination icon should be displayed in RV700 Firmware Upgrade Status Report Page.");
        }

        [Then(@"Page x of y indicator is displayed")]
        public void ThenPageXOfYIndicatorIsDisplayed()
        {
            (_firmwareStatusPage.PaginationXofY.GetElementVisibility()).Should().BeTrue("\"Page x of y\" indicator should be displayed in RV700 Firmware Upgrade Status Report Page.");
        }

        [Then(@"Displaying x to y of z results indicator is displayed")]
        public void ThenDisplayingXToYOfZResultsIndicatorIsDisplayed()
        {
            (_firmwareStatusPage.PaginationDisplayXY.GetElementVisibility()).Should().BeTrue("\"Dislaying x to y of z results\" indicator should be displayed in RV700 Firmware Upgrade Status Report Page.");
        }

        [Given(@"user is on RV700 Firmware Upgrade Status Report page")]
        public void GivenUserIsOnRVFirmwareUpgradeStatusReportPage()
        {
            GivenUserIsOnReportsPage();
            //Selecting RV700 decice type
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPageExpectedValues.RV700DeviceName);
            //Selecting firmware version in the report type dropdown
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.FirmwareStatusReportType);
            _reportsPage.GetReportButton.Click();
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string columnHeading)
        {
            IWebElement column = null;
            
            //Selecting column heading webelement and expected heading text based on given column name.
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
            (column.GetElementVisibility()).Should().BeTrue(columnHeading + " should be displayed in RV700 Firmware Upgrade Status Report Page Table");
            (column.Text).Should().BeEquivalentTo(columnHeading, because:columnHeading + " should match with the expected value in RV700 Firmware Upgrade Status Report Page Table.");
        }

        [Then(@"""(.*)"" label is in column (.*)")]
        public void ThenLabelIsInColumn(string columnHeading, int columnNumber)
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
    }
}
