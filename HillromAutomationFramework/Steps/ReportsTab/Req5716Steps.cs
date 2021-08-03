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
    [Binding,Scope(Tag = "SoftwareRequirementID_5716")]
    class Req5716Steps
    {
        LoginPage loginPage = new LoginPage();
        MainPage mainPage = new MainPage();
        LandingPage landingPage = new LandingPage();
        ReportsPage reportsPage = new ReportsPage();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        UsageReportPage usageReportPage = new UsageReportPage();

        [Given(@"user is on Reports page")]
        public void GivenUserIsOnReportsPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("deviceTable")));
            mainPage.ReportsTab.JavaSciptClick();
        }

        [Given(@"Asset type is CVSM")]
        public void GivenAssetTypeIsCVSM()
        {
            reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CVSMDeviceName);
            Assert.AreEqual(ReportsPage.ExpectedValues.CVSMDeviceName, reportsPage.AssetTypeDDL.GetSelectedOptionFromDDL(), "Selected option is not correct");
        }

        [When(@"user selects Usage from Report type dropdown menu")]
        public void WhenUserSelectsUsageFromReportTypeDropdownMenu()
        {
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.UsageReportType);
            Assert.AreEqual(ReportsPage.ExpectedValues.UsageReportType, reportsPage.ReportTypeDDL.GetSelectedOptionFromDDL(), "Selected option is not correct");
        }

        [When(@"clicks Get report button")]
        public void WhenClicksGetReportButton()
        {
            reportsPage.GetReportButton.Click();
        }

        [Then(@"CVSM Asset Usage Report page is displayed")]
        public void ThenCVSMAssetUsageReportPageIsDisplayed()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("reportTitleHeader")));
            Assert.AreEqual(true, usageReportPage.ReportsTitleHeader.GetElementVisibility(), "User is not on the usage report page");
        }

    }
}
