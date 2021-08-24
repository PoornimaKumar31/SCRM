using HillromAutomationFramework.Coding.PageObjects;
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
    [Binding, Scope(Tag = "SoftwareRequirementID_7732")]
    public sealed class Req7732Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        ReportsPage reportsPage = new ReportsPage();
        FirmwareStatusPage firmwareStatusPage = new FirmwareStatusPage();

        private readonly ScenarioContext _scenarioContext;
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

        public Req7732Steps(ScenarioContext scenarioContext)
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

        [Given(@"Centrella Asset type is selected")]
        public void GivenCentrellaAssetTypeIsSelected()
        {
            reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CentrellaDeviceName);
        }

        [Given(@"Firmware Status Report type is selected")]
        public void GivenFirmwareStatusReportTypeIsSelected()
        {
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareStatusReportType);
        }

        [When(@"user clicks Get report button")]
        public void WhenUserClicksGetReportButton()
        {
            reportsPage.GetReportButton.Click();
        }

        [Then(@"Firmware Upgrade Status Report \(Centrella\) label is displayed")]
        public void ThenFirmwareUpgradeStatusReportCentrellaLabelIsDisplayed()
        {
            Assert.IsTrue(firmwareStatusPage.FirmwareReportTitle.GetElementVisibility(), "Firmware upgrade status report label is not displayed.");
            Assert.AreEqual(FirmwareStatusPage.ExpectedValues.FirmwareUpgradeStatusCentrellaLabel.ToLower(),firmwareStatusPage.FirmwareReportTitle.Text.ToLower(), "Firmware upgrade status report label is not matching the expected value.");
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
            Assert.IsTrue(firmwareStatusPage.DownloadButton.GetElementVisibility(),"Download button is not displayed.");
        }

        [Then(@"Search box is displayed")]
        public void ThenSearchBoxIsDisplayed()
        {
            Assert.IsTrue(firmwareStatusPage.SearchBox.GetElementVisibility(),"Search box is not displayed.");
        }

        [Then(@"Previous page icon is displayed")]
        public void ThenPreviousPageIconIsDisplayed()
        {
            Assert.IsTrue(firmwareStatusPage.PaginationPreviousIcon.GetElementVisibility(),"Previous page icon is displayed.");
        }

        [Then(@"Next page icon is displayed")]
        public void ThenNextPageIconIsDisplayed()
        {
            Assert.IsTrue(firmwareStatusPage.PaginationNextIcon.GetElementVisibility(), "Next page icon is not displayed.");
        }

        [Then(@"Page x of y indicator is displayed")]
        public void ThenPageXOfYIndicatorIsDisplayed()
        {
            Assert.IsTrue(firmwareStatusPage.PaginationXofY.GetElementVisibility(), "Page x of y label is not displayed.");
        }

        [Then(@"Displaying x to y of z results indicator is displayed")]
        public void ThenDisplayingXToYOfZResultsIndicatorIsDisplayed()
        {
            Assert.IsTrue(firmwareStatusPage.PaginationDisplayXY.GetElementVisibility(),"Displaying x to y of z label is not displayed.");
        }

        [Given(@"user is on Centrella Firmware Upgrade Status Report page")]
        public void GivenUserIsOnCentrellaFirmwareUpgradeStatusReportPage()
        {
            GivenUserIsOnReportsPage();
            reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CentrellaDeviceName);
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareStatusReportType);
            reportsPage.GetReportButton.Click();
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string columnHeading)
        {
            IWebElement column = null;
            switch (columnHeading.ToLower().Trim())
            {
                case "serial number":
                    column = firmwareStatusPage.SerialNumberHeading;
                    break;

                case "firmware version":
                    column = firmwareStatusPage.FirmwareVerionHeading;
                    break;

                case "location":
                    column = firmwareStatusPage.LocationHeading;
                    break;

                case "status":
                    column = firmwareStatusPage.StatusHeading;
                    break;

                case "last deployed":
                    column = firmwareStatusPage.LastDeployedHeading;
                    break;
                case "last connected":
                    column = firmwareStatusPage.LastConnectedHeading;
                    break;

                default:
                    Assert.Fail(columnHeading + " is a invalid heading name.");
                    break;
            }
            Assert.AreEqual(true, column.GetElementVisibility(), columnHeading + " is not displayed");
            Assert.AreEqual(columnHeading.ToLower(), column.Text.ToLower(), columnHeading + " is not matching with the expected value.");
        }

        [Then(@"""(.*)"" label is in column (.*)")]
        public void ThenLabelIsInColumn(string columnHeading, int columnNumber)
        {
            IList<IWebElement> columns = firmwareStatusPage.TableHeader.FindElements(By.TagName("div"));
            Assert.AreEqual(columnHeading.ToLower().Trim(), columns[columnNumber - 1].Text.ToLower(), columnHeading + " is not in " + columnNumber);
        }

        [Then(@"the Print button is enabled")]
        public void ThenThePrintButtonIsEnabled()
        {
            Assert.IsTrue(firmwareStatusPage.PrintButton.Enabled, "Print button is not enabled");
        }


    }
}
