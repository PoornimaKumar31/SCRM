using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AssetsTab;
using HillromAutomationFramework.PageObjects.Component_Information;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.AssetsTab.PreventiveMaintenance
{
    [Binding, Scope(Tag = "@SoftwareRequirementID_5694")]
    public class Req5694Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly CSMDeviceDetailsPage _csmDeviceDetailsPage;
        private readonly CVSMAssetListPage _cvsmAssetListPage;
        private readonly MainPage _mainPage;

        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverWait _wait;

        public Req5694Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
            _csmDeviceDetailsPage = new CSMDeviceDetailsPage(driver);
            _cvsmAssetListPage = new CVSMAssetListPage(driver);
        }

        [Given(@"user is on Asset List page")]
        public void GivenUserIsOnAssetListPage()
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
        }
        
        [When(@"user selects any CVSM device")]
        public void WhenUserSelectsAnyCVSMDevice()
        {
            _mainPage.AssetTypeDropDown.SelectDDL(MainPageExpectedValue.CVSMDeviceName);
        }
        
        [Then(@"CVSM Asset details landing page is displayed")]
        public void ThenCVSMAssetDetailsLandingPageIsDisplayed()
        {
            Thread.Sleep(3000);
            _mainPage.DeviceListRow[0].Click();
            Thread.Sleep(2000);
            bool isAssetDetailsLandingPageDisplayed = _cvsmAssetListPage.CVSMDetailsPage.GetElementVisibility();
            isAssetDetailsLandingPageDisplayed.Should().BeTrue("CVSM Asset details landing page is not displayed");
        }

        [Then(@"Asset Details Summary subsection is displayed")]
        public void ThenAssetDetailsSummarySubsectionIsDisplayed()
        {
            Thread.Sleep(2000);
            bool isAssetDetailsSummarySubsectionDisplayed = _csmDeviceDetailsPage.AssetDetailsSummary.GetElementVisibility();
            isAssetDetailsSummarySubsectionDisplayed.Should().BeTrue("Asset Details Summary subsection is not displayed.");
        }

        [Then(@"Preventive Maintenance Schedule subsection is displayed")]
        public void ThenPreventiveMaintenanceScheduleSubsectionIsDisplayed()
        {
            bool IsPMScheduleSubsectionDisplayed = _csmDeviceDetailsPage.PreventiveMaintenance.GetElementVisibility();
            IsPMScheduleSubsectionDisplayed.Should().BeTrue("Preventive maintenance schedule subsection is not displayed.");
        }

        [Given(@"user is on the Preventive maintenance tab")]
        public void GivenUserIsOnThePreventiveMaintenanceScheduleTab()
        {
            GivenUserIsOnAssetListPage();
            WhenUserSelectsAnyCVSMDevice();
            Thread.Sleep(3000);
            _mainPage.DeviceListRow[0].Click();
            Thread.Sleep(2000);
            _csmDeviceDetailsPage.PMTab.Click();
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string columnName)
        {
            bool isColumnNameDisplayed = _csmDeviceDetailsPage.PMNameHeading.GetElementVisibility();
            isColumnNameDisplayed.Should().BeTrue(columnName + " column heading is not displayed");
        }

        [Then(@"""(.*)"" and current calendar year label is displayed")]
        public void ThenAndCurrentCalendarYearLabelIsDisplayed(string leftArrow)
        {
            Thread.Sleep(2000);
            bool IsLeftArrowDisplayed = _csmDeviceDetailsPage.LeftArrow.GetElementVisibility();
            bool currentYearDisplayed = _csmDeviceDetailsPage.CurrentCalenderYear.GetElementVisibility();

            IsLeftArrowDisplayed.Should().BeTrue("Left arrow symbol is not displayed.");
            currentYearDisplayed.Should().BeTrue("Current calendar year label is not displayed.");
        }

        [Then(@"next calendar year and ""(.*)"" is displayed")]
        public void ThenNextCalendarYearAndIsDisplayed(string rightArrow)
        {
            bool IsRightArrowDisplayed = _csmDeviceDetailsPage.RightArrow.GetElementVisibility();
            bool IsNextYearDisplayed = _csmDeviceDetailsPage.NextCalenderYear.GetElementVisibility();

            IsRightArrowDisplayed.Should().BeTrue("Right arrow symbol is not displayed.");
            IsNextYearDisplayed.Should().BeTrue("Next calendar year is not displayed.");
        }

        [Then(@"current month is displayed followed by the other months")]
        public void ThenCurrentMonthIsDisplayedFollowedByTheOtherMonths()
        {
            bool IsCalenderDisplayed = _csmDeviceDetailsPage.CalenderXP.GetElementVisibility();
            string[] monthsArray = _csmDeviceDetailsPage.CalenderXP.Text.Split();
            List<string> listOfMonths = monthsArray.ToList<string>();
            listOfMonths.RemoveAll(p => string.IsNullOrEmpty(p));

            //Actual array
            monthsArray = listOfMonths.ToArray();

            //Expected array       
            var monthsName = GetMethods.GetMonthsName();
            monthsArray.Should().Equal(monthsName, "Current month should be displayed followed by the other months");
        }
    }
}
