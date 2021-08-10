using FluentAssertions;
using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.PageObjects.ReportsTab;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.ReportsTab
{
    [Binding,Scope(Tag = "SoftwareRequirementID_6118")]
    public class Req6118Steps
    {
        private readonly LoginPage loginPage = new LoginPage();
        private readonly LandingPage landingPage = new LandingPage();
        private readonly MainPage mainPage = new MainPage();
        private readonly ReportsPage reportsPage = new ReportsPage();
        private readonly FirmwareVersionPage firmwareVersionPage = new FirmwareVersionPage();
        private readonly FirmwareStatusPage firmwareStatusPage = new FirmwareStatusPage();

        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        private ScenarioContext _scenarioContext;

        public Req6118Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Given(@"user is on Reports page")]
        public void GivenUserIsOnReportsPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.ReportsTab.JavaSciptClick();
        }
        
        [Given(@"RV700 Asset type is selected")]
        public void GivenRVAssetTypeIsSelected()
        {
            //Selecting RV700 decice type
            reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.RV700DeviceName);

        }
        
        [Given(@"Firmware Version Report type is selected")]
        public void GivenFirmwareVersionReportTypeIsSelected()
        {
            //Selecting firmware version in the report type dropdown
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareVersionReportType);
        }
        
        [When(@"user clicks Get report button")]
        public void WhenUserClicksGetReportButton()
        {
            reportsPage.GetReportButton.Click();
        }
        
        [Then(@"Firmware Version Report \(RV700\) label is displayed")]
        public void ThenFirmwareVersionReportRVLabelIsDisplayed()
        {
            Assert.IsTrue(firmwareVersionPage.FirmwareReportTitle.GetElementVisibility(),"Firmware version report header is not displayed.");
            Assert.AreEqual(FirmwareVersionPage.ExpectedValues.ReportRV700LabelText.ToLower(),firmwareVersionPage.FirmwareReportTitle.Text.ToLower(),"Firmware version report header is not matching the expected value.");
        }
        
        [Then(@"Components column heading is displayed")]
        public void ThenComponentsColumnHeadingIsDisplayed()
        {
            Assert.IsTrue(firmwareVersionPage.ComponentsHeading.GetElementVisibility(),"Components column heading is not displayed.");
            Assert.AreEqual(FirmwareVersionPage.ExpectedValues.ComponentsHeadingText.ToLower(), firmwareVersionPage.ComponentsHeading.Text.ToLower(),"Components coumn heading is not matching the expected value");
        }
        
        [Then(@"Firmware version column heading is displayed")]
        public void ThenFirmwareVersionColumnHeadingIsDisplayed()
        {
            Assert.IsTrue(firmwareVersionPage.FirmwareVersionHeading.GetElementVisibility(),"Firmware version column heading is not displayed.");
            Assert.AreEqual(FirmwareVersionPage.ExpectedValues.FirmwareVersionHeadingText.ToLower(),firmwareVersionPage.FirmwareVersionHeading.Text.ToLower(),"Firmware version column heading is not matching the expected value.");
        }
        
        [Then(@"Total devices column heading is displayed")]
        public void ThenTotalDevicesColumnHeadingIsDisplayed()
        {
            Assert.IsTrue(firmwareVersionPage.TotaldevicesHeading.GetElementVisibility(), "Total devices column heading is not displayed");
            Assert.AreEqual(FirmwareVersionPage.ExpectedValues.TotalDevicesHeadingText.ToLower(),firmwareVersionPage.TotaldevicesHeading.Text.ToLower(),"Total devices heading is not matching with expected value.");
        }

        [Given(@"user is on RV700 Firmware Version Report page")]
        public void GivenUserIsOnRVFirmwareVersionReportPage()
        {
            GivenUserIsOnReportsPage();
            //Selecting RV700 decice type
            reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.RV700DeviceName);
            //Selecting firmware version in the report type dropdown
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
            Assert.IsFalse(firmwareVersionPage.TotalRowDetails.GetElementVisibility(),"Rows below total are hidden.");
        }

        [When(@"user clicks unit row")]
        public void WhenUserClicksUnitRow()
        {
            firmwareVersionPage.Unit1Row.Click();
        }

        [Then(@"assets for unit are hidden")]
        public void ThenAssetsForUnitAreHidden()
        {
            Assert.IsFalse(firmwareVersionPage.Unit1RowDetails.GetElementVisibility(),"Assets for unit are displayed.");
        }

        [When(@"user clicks Print button")]
        public void WhenUserClicksPrintButton()
        {
            if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("rv700 firmware version report print"))
            {
                firmwareVersionPage.PrintButton.Click();
            }
            else if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("rv700 firmware upgrade status report print"))
            {
                firmwareStatusPage.PrintButton.Click();
            }
            else
            {
                //If this test step does not belong to any scenario
                Assert.Fail(_scenarioContext.ScenarioInfo.Title + " does not have step defination for " + _scenarioContext.StepContext.StepInfo.Text);
            }
            
        }

        [Then(@"browser’s built-in print dialog is displayed")]
        public void ThenBrowserSBuilt_InPrintDialogIsDisplayed()
        {
            //Need to find some way to habdle print page
            throw new PendingStepException("Need to find some way to habdle print page");
        }

        [Given(@"Firmware Status Report type is selected")]
        public void GivenFirmwareStatusReportTypeIsSelected()
        {
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareStatusReportType);
        }

        [Then(@"Firmware Upgrade Status Report \(RV700\) label is displayed")]
        public void ThenFirmwareUpgradeStatusReportRVLabelIsDisplayed()
        {
            Assert.IsTrue(firmwareStatusPage.FirmwareReportTitle.GetElementVisibility(),"Firmware upgrade status report (RV700) is not displayed.");
            Assert.AreEqual(FirmwareStatusPage.ExpectedValues.FirmwareUpgradeStatusRV700Label.ToLower(), firmwareStatusPage.FirmwareReportTitle.Text.ToLower(),"Firmware upgrade status report (RV700) is not mathing the expected value.");
        }

        [Then(@"Print button is displayed")]
        public void ThenPrintButtonIsDisplayed()
        {
            Assert.IsTrue(firmwareStatusPage.PrintButton.GetElementVisibility(),"Print button is not displayed.");
        }

        [Then(@"Information button is displayed")]
        public void ThenInformationButtonIsDisplayed()
        {
            Assert.IsTrue(firmwareStatusPage.InformationButton.GetElementVisibility(),"Information button is not displayed.");
        }

        [Then(@"Download button is displayed")]
        public void ThenDownloadButtonIsDisplayed()
        {
            bool isDownloadButtonVisible = firmwareStatusPage.DownloadButton.GetElementVisibility();
            Assert.IsTrue(isDownloadButtonVisible,"Download button is not displayed.");
            //DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(PropertyClass.Driver)
            //{
            //    Timeout = TimeSpan.FromSeconds(10),
            //    PollingInterval = TimeSpan.FromMilliseconds(100),
            //    Message = "Web Element not found"
            //};
        }

        [Then(@"Search box is displayed")]
        public void ThenSearchBoxIsDisplayed()
        {
            Assert.IsTrue(firmwareStatusPage.SearchBox.GetElementVisibility(),"Search box is not displayed.");
        }

        [Then(@"Previous page icon is displayed")]
        public void ThenPreviousPageIconIsDisplayed()
        {
            Assert.IsTrue(firmwareStatusPage.PaginationPreviousIcon.GetElementVisibility(),"Previous pagination icon is not displayed.");
        }

        [Then(@"Next page icon is displayed")]
        public void ThenNextPageIconIsDisplayed()
        {
            Assert.IsTrue(firmwareStatusPage.PaginationNextIcon.GetElementVisibility(),"Next page icon is not displayed.");
        }

        [Then(@"Page x of y indicator is displayed")]
        public void ThenPageXOfYIndicatorIsDisplayed()
        {
            Assert.IsTrue(firmwareStatusPage.PaginationXofY.GetElementVisibility(),"\"Page x of y\" indicator is not displayed.");
        }

        [Then(@"Displaying x to y of z results indicator is displayed")]
        public void ThenDisplayingXToYOfZResultsIndicatorIsDisplayed()
        {
            Assert.IsTrue(firmwareStatusPage.PaginationDisplayXY.GetElementVisibility(),"\"Dislaying x to y of z results\" indicator is not displayed.");
        }

        [Given(@"user is on RV700 Firmware Upgrade Status Report page")]
        public void GivenUserIsOnRVFirmwareUpgradeStatusReportPage()
        {
            GivenUserIsOnReportsPage();
            //Selecting RV700 decice type
            reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.RV700DeviceName);
            //Selecting firmware version in the report type dropdown
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareStatusReportType);
            reportsPage.GetReportButton.Click();
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string columnHeading)
        {
            IWebElement column = null;
            string ExpectedColumnHeading = "";
            
            //Selecting column heading webelement and expected heading text based on given column name.
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

            Assert.AreEqual(true, column.GetElementVisibility(), columnHeading + " is not displayed");
            Assert.AreEqual(ExpectedColumnHeading.ToLower(), column.Text.ToLower(), columnHeading + " is not matching with the expected value.");
        }

        [Then(@"""(.*)"" label is in column (.*)")]
        public void ThenLabelIsInColumn(string columnHeading, int columnNumber)
        {
            //finding all the column under the heading tab
            IList<IWebElement> columns = firmwareStatusPage.TableHeader.FindElements(By.TagName("div"));
            //Asserting if column heading is present in specified location.
            Assert.AreEqual(columnHeading.ToLower().Trim(), columns[columnNumber - 1].Text.ToLower(), columnHeading + " is not in " + columnNumber);
        }
    }
}
