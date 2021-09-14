using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.ReportsTab
{
    [Binding,Scope(Tag = "SoftwareRequirementID_9426")]
    public class Req9426Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly ReportsPage _reportsPage;

        private readonly WebDriverWait _wait;
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public Req9426Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
            _reportsPage = new ReportsPage(driver);
        }


        [Given(@"user is on ""(.*)"" page")]
        public void GivenUserIsOnPage(string reportType)
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);

            if (reportType.ToLower().Trim().Equals("centrella firmware upgrade status"))
            {
                SetMethods.MoveTotheElement(_landingPage.PSSServiceOrganizationFacilityBatesville, _driver,"Centrella Orgaization");
                _landingPage.PSSServiceOrganizationFacilityBatesville.Click();
                _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));

                _mainPage.ReportsTab.JavaSciptClick(_driver);
                _reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CentrellaDeviceName);
                _reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareStatusReportType);
                _reportsPage.GetReportButton.Click();
            }
            else
            { 
                 Assert.Fail(reportType + " is a invalid report type.");       
            }
           
        }
        
        [When(@"user clicks Download button")]
        public void WhenUserClicksDownloadButton()
        {
            _reportsPage.DownloadButton.Click();
        }
        
        [Then(@"""(.*)"" Report is downloaded as csv file")]
        public void ThenReportIsDownloadedAsCsvFile(string reportName)
        {
            string fileName = "";
            if(reportName.ToLower().Trim().Equals("firmware status"))
            {
                fileName = FirmwareStatusPage.ExpectedValues.CentrellaFirmwareStatusReportName;
            }
            else
            {
                Assert.Fail(reportName + " is a invalid report.");
            }
            bool isFileDownloaded = GetMethods.IsFileDownloaded(fileName, 10);
            (isFileDownloaded).Should().BeTrue(because: reportName + " file should be downloaded when user clicks on download button in centrella firmware upgrade status report page.");

            bool IsFileFormatCSV = GetMethods.CheckFileFormat(fileName,".csv");
            (IsFileFormatCSV).Should().BeTrue(reportName + " file should be in .csv format.");

        }
    }
}
