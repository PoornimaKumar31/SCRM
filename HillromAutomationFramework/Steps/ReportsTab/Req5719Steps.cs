using FluentAssertions;
using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.PageObjects.ReportsTab;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.ReportsTab
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5719")]
    public class Req5719Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly ReportsPage _reportsPage;

        private readonly WebDriverWait _wait;
        private readonly ScenarioContext _scenarioContext;

        public Req5719Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage();
            _landingPage = new LandingPage();
            _mainPage = new MainPage();
            _reportsPage = new ReportsPage();    
    }

        
        [When(@"user clicks Download button")]
        public void WhenUserClicksOnDownloadButton()
        {
            _reportsPage.DownloadButton.Click();
        }
  
        [Given(@"user is on ""(.*)"" page")]
        public void GivenUserIsOnPage(string reportName)
        {
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            /**
             * Selecting the organization based on the report type. 
             */
            switch(reportName.ToLower().Trim())
            {
                case "csm configuration update status":
                    _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
                    _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
                    _mainPage.ReportsTab.JavaSciptClick();
                    _reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CSMDeviceName);
                    _reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.ConfigurationReportType);
                    break;
                case "csm firmware upgrade status":
                    _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
                    _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
                    _mainPage.ReportsTab.JavaSciptClick();
                    _reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CSMDeviceName);
                    _reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareStatusReportType);
                    break;
                case "csm activity report":
                    _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
                    _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
                    _mainPage.ReportsTab.JavaSciptClick();
                    _reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CSMDeviceName);
                    _reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.ActivityReportType);
                    break;
                case "rv700 firmware upgrade status":
                    _landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.Click();
                    _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
                    _mainPage.ReportsTab.JavaSciptClick();
                    _reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.RV700DeviceName);
                    _reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareStatusReportType);
                    break;
                default:
                    Assert.Fail(reportName + " is a Invalid report type");
                    break;
            }
            
            _reportsPage.GetReportButton.Click();
        }

        [Then(@"""(.*)"" Report is downloaded as csv file")]
        public void ThenReportIsDownloadedAsCsvFile(string reportName)
        {
            string filename = "";
            switch(reportName.ToLower().Trim())
            {
                case "configuration update status":
                    filename= CSMConfigStatusPage.ExpectedValues.CSMConfigurationStatusReportFileName;
                    break;

                case "firmware status":
                    if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("csm firmware status report download"))
                    {
                        filename = FirmwareStatusPage.ExpectedValues.CSMFirmwareStatusReportName;
                    }
                    else if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("rv700 firmware status report download"))
                    {
                        filename = FirmwareStatusPage.ExpectedValues.RV700FirmwareStatusReportName;
                    }
                    else
                    {
                        Assert.Fail(_scenarioContext.ScenarioInfo.Title + " does not have step defination for " + _scenarioContext.StepContext.StepInfo.Text);
                    }
                    break;

                case "activity":
                    filename = ActivityReportPage.ExpectedValues.CSMActivityReportName;
                    break;
                default: Assert.Fail(reportName + " is a invalid report name.");
                    break;
            }
            bool fileDownload = GetMethods.IsFileDownloaded(filename, 10);
            fileDownload.Should().BeTrue(reportName + " should be downloaded when you press the download button");

            bool fileFormat = GetMethods.CheckFileFormat(".csv");
            fileFormat.Should().BeTrue(reportName + " should be in csv format");
        }
    }
}
