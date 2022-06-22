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
    [Binding, Scope(Tag = "SoftwareRequirementID_7732")]
    public sealed class Req7732Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly ReportsPage _reportsPage;
        private readonly FirmwareStatusReportPage _firmwareStatusPage;


        private readonly WebDriverWait _wait;
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public Req7732Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
            _reportsPage = new ReportsPage(driver);
            _firmwareStatusPage = new FirmwareStatusReportPage(driver);
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

        [Given(@"Centrella Asset type is selected")]
        public void GivenCentrellaAssetTypeIsSelected()
        {
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPageExpectedValues.CentrellaDeviceName);
        }

        [Given(@"Firmware Status Report type is selected")]
        public void GivenFirmwareStatusReportTypeIsSelected()
        {
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.FirmwareStatusReportType);
        }

        [When(@"user clicks Get report button")]
        public void WhenUserClicksGetReportButton()
        {
            _reportsPage.GetReportButton.Click();
        }

        [Then(@"Firmware Upgrade Status \(Centrella\) label is displayed")]
        public void ThenFirmwareUpgradeStatusReportCentrellaLabelIsDisplayed()
        {
            (_firmwareStatusPage.FirmwareReportTitle.GetElementVisibility()).Should().BeTrue("Firmware upgrade status report label should be displayed in Firmware Status Report page");
            (_firmwareStatusPage.FirmwareReportTitle.Text).Should().BeEquivalentTo(FirmwareStatusReportPageExpectedValues.FirmwareUpgradeStatusCentrellaLabel, because: "Firmware upgrade status report label should match the expected value in Firmware Status Report page.");
        }

        [Then(@"Print button is displayed")]
        public void ThenPrintButtonIsDisplayed()
        {
            (_firmwareStatusPage.PrintButton.GetElementVisibility()).Should().BeTrue("Print button should be displayed in Firmware Upgrade status report.");
        }

        [Then(@"Information button is displayed")]
        public void ThenInformationButtonIsDisplayed()
        {
            (_firmwareStatusPage.InformationButton.GetElementVisibility()).Should().BeTrue("Information button should be displayed in Firmware Upgrade status report.");
        }

        [Then(@"Download button is displayed")]
        public void ThenDownloadButtonIsDisplayed()
        {
            (_firmwareStatusPage.DownloadButton.GetElementVisibility()).Should().BeTrue("Download button should be displayed in Firmware Upgrade status report.");
        }

        [Then(@"Search box is displayed")]
        public void ThenSearchBoxIsDisplayed()
        {
            (_firmwareStatusPage.SearchBox.GetElementVisibility()).Should().BeTrue("Search box should be displayed in Firmware Upgrade status report.");
        }

        [Then(@"Previous page icon is displayed")]
        public void ThenPreviousPageIconIsDisplayed()
        {
            (_firmwareStatusPage.PaginationPreviousIcon.GetElementVisibility()).Should().BeTrue("Previous page icon should be displayed in Firmware Upgrade status report.");
        }

        [Then(@"Next page icon is displayed")]
        public void ThenNextPageIconIsDisplayed()
        {
            (_firmwareStatusPage.PaginationNextIcon.GetElementVisibility()).Should().BeTrue("Next page icon should be displayed in Firmware Upgrade status report.");
        }

        [Then(@"Page x of y indicator is displayed")]
        public void ThenPageXOfYIndicatorIsDisplayed()
        {
            (_firmwareStatusPage.PaginationXofY.GetElementVisibility()).Should().BeTrue("Page x of y label should be displayed in Firmware Upgrade status report.");
        }

        [Then(@"Displaying x to y of z results indicator is displayed")]
        public void ThenDisplayingXToYOfZResultsIndicatorIsDisplayed()
        {
            (_firmwareStatusPage.PaginationDisplayXY.GetElementVisibility()).Should().BeTrue("Displaying x to y of z label should be displayed in Firmware Upgrade status report.");
        }

        [Given(@"user is on Centrella Firmware Upgrade Status Report page")]
        public void GivenUserIsOnCentrellaFirmwareUpgradeStatusReportPage()
        {
            GivenUserIsOnReportsPage();
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPageExpectedValues.CentrellaDeviceName);
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.FirmwareStatusReportType);
            _reportsPage.GetReportButton.Click();
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string columnHeading)
        {
            IWebElement column = null;
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
            (column.GetElementVisibility()).Should().BeTrue(columnHeading + " should be displayed in Firmware Upgrade status report page.");
            string ActualColumnName = column.Text;
            (ActualColumnName).Should().BeEquivalentTo(columnHeading,because:columnHeading + " should match with the expected value in Firmware Upgrade status report page.");
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

        [Then(@"the Print button is enabled")]
        public void ThenThePrintButtonIsEnabled()
        {
            (_firmwareStatusPage.PrintButton.Enabled).Should().BeTrue("Print button should be enabled in Firmware Upgrade status report page.");
        }
    }
}
