using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.ReportsTab;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.ReportsTab
{
    [Binding,Scope(Tag = "SoftwareRequirementID_9425")]
    public class Req9425Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly ReportsPage _reportsPage;

        private readonly WebDriverWait _wait;
        private readonly ScenarioContext _scenarioContext;

        public Req9425Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage();
            _landingPage = new LandingPage();
            _mainPage = new MainPage();
            _reportsPage = new ReportsPage();        
        }

        [Given(@"user is on ""(.*)"" page")]
        public void GivenUserIsOnPage(string reportType)
        {
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);

            if (reportType.ToLower().Trim().Equals("centrella activity report"))
            {
                SetMethods.MoveTotheElement(_landingPage.PSSServiceOrganizationFacilityBatesville, "Centrella Orgaization");
                _landingPage.PSSServiceOrganizationFacilityBatesville.Click();
                _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));

                _mainPage.ReportsTab.JavaSciptClick();
                _reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CentrellaDeviceName);
                _reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.ActivityReportType);
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
            if (reportName.ToLower().Trim().Equals("activity"))
            {
                fileName = ActivityReportPage.ExpectedValues.CentrellaActivityReportName;
            }
            else
            {
                Assert.Fail(reportName + " is a invalid report.");
            }
            bool isFileDownloaded = GetMethods.IsFileDownloaded(fileName, 10);
            (isFileDownloaded).Should().BeTrue(because: reportName + " file should be downloaded when user clicks on download button in centrella activity report page.");

            bool IsFileFormatCSV = GetMethods.CheckFileFormat(fileName,".csv");
            (IsFileFormatCSV).Should().BeTrue(reportName + " file should be in .csv format.");
        }
    }
}
