using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.PageObjects.ReportsTab;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.ReportsTab
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5719")]
    public class Req5719Steps
    {
        private readonly LoginPage loginPage = new LoginPage();
        private readonly LandingPage landingPage = new LandingPage();
        private readonly MainPage mainPage = new MainPage();
        private readonly ReportsPage reportsPage = new ReportsPage();
        private readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        private ScenarioContext _scenarioContext;

        public Req5719Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        
        [When(@"user clicks Download button")]
        public void WhenUserClicksOnDownloadButton()
        {
            reportsPage.DownloadButton.Click();
        }
  
        [Given(@"user is on ""(.*)"" page")]
        public void GivenUserIsOnPage(string reportName)
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            /**
             * Selecting the organization based on the report type. 
             */
            switch(reportName.ToLower().Trim())
            {
                case "csm configuration update status":
                    landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
                    mainPage.ReportsTab.JavaSciptClick();
                    reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CSMDeviceName);
                    reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.ConfigurationReportType);
                    break;
                case "csm firmware upgrade status":
                    landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
                    mainPage.ReportsTab.JavaSciptClick();
                    reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CSMDeviceName);
                    reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareStatusReportType);
                    break;
                case "csm activity report":
                    landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
                    mainPage.ReportsTab.JavaSciptClick();
                    reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CSMDeviceName);
                    reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.ActivityReportType);
                    break;
                case "rv700 firmware upgrade status":
                    landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
                    mainPage.ReportsTab.JavaSciptClick();
                    reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.RV700DeviceName);
                    reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareStatusReportType);
                    break;
                default:
                    Assert.Fail(reportName + " is a Invalid report type");
                    break;
            }
            
            reportsPage.GetReportButton.Click();
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
            Assert.AreEqual(true, GetMethods.IsFileDownloaded(filename,10),reportName + " file is not downloaded.");
            Assert.AreEqual(true, GetMethods.CheckFileFormat(".csv"), reportName+" file is not in .csv format.");
        }
    }
}
