using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.ReportsTab
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5719")]
    public class Req5719Steps
    {
        private readonly LoginPage loginPage = new LoginPage();
        private readonly LandingPage landingPage = new LandingPage();
        private readonly MainPage mainPage = new MainPage();
        private readonly CSMConfigStatusPage csmConfigStatusPage = new CSMConfigStatusPage();
        private readonly FirmwareStatusPage firmwareStatusPage = new FirmwareStatusPage();
        private readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        private ScenarioContext _scenarioContext;

        public Req5719Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        
        [When(@"user clicks on Download button")]
        public void WhenUserClicksOnDownloadButton()
        {
            csmConfigStatusPage.DownloadButton.Click();
        }
  
        [Given(@"user is on ""(.*)"" page")]
        public void GivenUserIsOnPage(string reportName)
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            switch(reportName.ToLower().Trim())
            {
                case "csm configuration update status":
                    landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("deviceTable")));
                    mainPage.ReportsTab.JavaSciptClick();
                    csmConfigStatusPage.AssetTypeDropdown.SelectDDL(CSMConfigStatusPage.ExpectedValues.CSMDeviceName);
                    csmConfigStatusPage.ReportTypeDropdown.SelectDDL(CSMConfigStatusPage.ExpectedValues.CSMConfigurationReport);
                    break;
                case "csm firmware upgrade status":
                    landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("deviceTable")));
                    mainPage.ReportsTab.JavaSciptClick();
                    csmConfigStatusPage.AssetTypeDropdown.SelectDDL(FirmwareStatusPage.ExpectedValues.CSMDeviceName);
                    csmConfigStatusPage.ReportTypeDropdown.SelectDDL(FirmwareStatusPage.ExpectedValues.Firmware);
                    break;
                case "csm activity report":
                    landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("deviceTable")));
                    mainPage.ReportsTab.JavaSciptClick();
                    csmConfigStatusPage.AssetTypeDropdown.SelectDDL(CSMConfigStatusPage.ExpectedValues.CSMDeviceName);
                    csmConfigStatusPage.ReportTypeDropdown.SelectDDL(CSMConfigStatusPage.ExpectedValues.CSMActivityReport);
                    break;
                case "rv700 firmware upgrade status":
                    landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("deviceTable")));
                    mainPage.ReportsTab.JavaSciptClick();
                    csmConfigStatusPage.AssetTypeDropdown.SelectDDL(FirmwareStatusPage.ExpectedValues.RV700DeviceName);
                    csmConfigStatusPage.ReportTypeDropdown.SelectDDL(FirmwareStatusPage.ExpectedValues.Firmware);
                    break;
                default:
                    Assert.Fail(reportName + " is a Invalid report type");
                    break;
            }
            
            csmConfigStatusPage.GetReportButton.Click();
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
                    if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("csm firmware status report"))
                    {
                        filename = FirmwareStatusPage.ExpectedValues.CSMFirmwareStatusReportName;
                    }
                    else if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("rv700 firmware status report"))
                    {
                        filename = FirmwareStatusPage.ExpectedValues.RV700FirmwareStatusReportName;
                    }
                    break;
                case "activity":
                    filename = CSMConfigStatusPage.ExpectedValues.CSMActivityReportName;
                    break;
                default: Assert.Fail(reportName + " is a invalid report name.");
                    break;
            }
            Assert.AreEqual(true, GetMethods.IsFileDownloaded(filename,10),reportName + " file is not downloaded.");
            Assert.AreEqual(true, GetMethods.CheckFileFormat(".csv"), reportName+" file is not in .csv format.");
        }






    }
}
