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
        CVSMUsageReportPage cvsmUsageReportPage = new CVSMUsageReportPage();

        [Given(@"user is on Reports page")]
        public void GivenUserIsOnReportsPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("deviceTable")));
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

        [When(@"When user clicks report type dropdown")]
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
            Assert.AreEqual(true,Enumerable.SequenceEqual(ActualOptionList,ExpectedOptionList),"Expected Options are not same as Actual");
        }

        [Then(@"CVSM Asset Usage Report label is displayed")]
        public void ThenCVSMAssetUsageReportLabelIsDisplayed()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(CVSMUsageReportPage.Locator.ReportTitleHeaderID)));
            Assert.AreEqual(true, cvsmUsageReportPage.ReportTitleHeading.GetElementVisibility(), "User is not on the usage report page");
        }

        [Then(@"Print button is displayed")]
        public void ThenPrintButtonIsDisplayed()
        {
            Assert.AreEqual(true, cvsmUsageReportPage.PrintButton.GetElementVisibility(), "Print Button is not displayed");
        }

        [Then(@"Number of Devices on Each Floor label is displayed")]
        public void ThenNumberOfDevicesOnEachFloorLabelIsDisplayed()
        {
            Assert.AreEqual(true, cvsmUsageReportPage.NumberOfDevicesOnEachFloorLabel.GetElementVisibility(), "Number of Devices on Each Floor label is not displayed");
        }

        [Then(@"pie chart with Location ID is displayed")]
        public void ThenPieChartWithLocationIDIsDisplayed()
        {
            //Can't verify Location ID is displayed or not
            Assert.AreEqual(true, cvsmUsageReportPage.PieChart.GetElementVisibility(), "Pie Chart is not displayed");
        }

        [Then(@"Total Usage Details - Components label is displayed")]
        public void ThenTotalUsageDetails_ComponentsLabelIsDisplayed()
        {
            Assert.AreEqual(true, cvsmUsageReportPage.TotalUsageDetailsLabel.GetElementVisibility(), "Total usage details label is not displayed");
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
            cvsmUsageReportPage.UnitToggleArrow.Click();
        }

        [Then(@"assets for the unit are hidden")]
        public void ThenAssetsForTheUnitAreHidden()
        {
           Assert.AreEqual(CVSMUsageReportPage.ExpectedValue.Station1HiddenDeviceStyleAttribute,cvsmUsageReportPage.Station1DeviceContainer.GetAttribute("style"),"Asset for Unit is not hidden"); 
        }

        [When(@"user clicks Print button")]
        public void WhenUserClicksPrintButton()
        {
            cvsmUsageReportPage.PrintButton.Click();
        }

        [Then(@"browser’s built-in print dialog is displayed")]
        public void ThenBrowserSBuilt_InPrintDialogIsDisplayed()
        {
            _scenarioContext.Pending();
        }

    }
}
