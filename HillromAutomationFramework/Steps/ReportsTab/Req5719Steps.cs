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
        private readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

       
        
        [When(@"user clicks on Download button")]
        public void WhenUserClicksOnDownloadButton()
        {
            csmConfigStatusPage.DownloadButton.Click();
        }
        
        [Then(@"Configuration Update Status Report is downloaded as csv file")]
        public void ThenConfigurationUpdateStatusReportIsDownloadedAsCsvFile()
        {
            Assert.AreEqual(true, GetMethods.IsFileDownloaded(CSMConfigStatusPage.ExpectedValues.CSMConfigurationStatusReportFileName,10),"Report file is not downloaded.");
            Assert.AreEqual(true, GetMethods.CheckFileFormat(".csv"),"Report file is not in .csv format.");
        }


        [Given(@"user is on ""(.*)"" page")]
        public void GivenUserIsOnPage(string reportName)
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            switch(reportName.ToLower().Trim())
            {
                case "csm configuration update status":
                    landingPage.Organization1Facility0Title.Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("deviceTable")));
                    mainPage.ReportsTab.JavaSciptClick();
                    csmConfigStatusPage.AssetTypeDropdown.SelectDDL(CSMConfigStatusPage.ExpectedValues.CSMDeviceName);
                    csmConfigStatusPage.ReportTypeDropdown.SelectDDL(CSMConfigStatusPage.ExpectedValues.CSMConfiguration);
                    break;
                case "csm firmware upgrade status":
                    break;
                case "csm activity report":
                    break;
                case "rv700 firmware upgrade status":
                    break;
            }
            
            csmConfigStatusPage.GetReportButton.Click();
        }

        [Then(@"""(.*)"" Report is downloaded as csv file")]
        public void ThenReportIsDownloadedAsCsvFile(string p0)
        {
            ScenarioContext.Current.Pending();
        }






    }
}
