using FluentAssertions;
using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.PageObjects.Component_Information;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding, Scope(Tag = "@SoftwareRequirementID_5694")]
    public class Req5694Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        CSMDeviceDetailsPage csmDeviceDetailsPage = new CSMDeviceDetailsPage();
        CVSMAssetListPage cvsmAssetListPage = new CVSMAssetListPage();
        MainPage mainPage = new MainPage();

        [Given(@"user is on Asset List page")]
        public void GivenUserIsOnAssetListPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
        }
        
        [When(@"user selects any CVSM device")]
        public void WhenUserSelectsAnyCVSMDevice()
        {
            mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CVSMDeviceName);
        }
        
        [Then(@"CVSM Asset details landing page is displayed")]
        public void ThenCVSMAssetDetailsLandingPageIsDisplayed()
        {
            mainPage.DeviceListRow[0].Click();
            Thread.Sleep(2000);
            bool isAssetDetailsLandingPageDisplayed = cvsmAssetListPage.CVSMDetailsPage.GetElementVisibility();
            Assert.IsTrue(isAssetDetailsLandingPageDisplayed, "CVSM Asset details landing page is not displayed");
        }

        [Then(@"Asset Details Summary subsection is displayed")]
        public void ThenAssetDetailsSummarySubsectionIsDisplayed()
        {
            Thread.Sleep(2000);
            bool isAssetDetailsSummarySubsectionDisplayed = csmDeviceDetailsPage.AssetDetailsSummary.GetElementVisibility();
            Assert.IsTrue(isAssetDetailsSummarySubsectionDisplayed, "Asset Details Summary subsection is not displayed.");
        }

        [Then(@"Preventive Maintenance Schedule subsection is displayed")]
        public void ThenPreventiveMaintenanceScheduleSubsectionIsDisplayed()
        {
            bool IsPMScheduleSubsectionDisplayed = csmDeviceDetailsPage.PreventiveMaintenance.GetElementVisibility();
            Assert.IsTrue(IsPMScheduleSubsectionDisplayed, "Preventive maintenance schedule subsection is not displayed.");
        }

        [Given(@"user is on the Preventive maintenance tab")]
        public void GivenUserIsOnThePreventiveMaintenanceScheduleTab()
        {
            GivenUserIsOnAssetListPage();
            WhenUserSelectsAnyCVSMDevice();
            mainPage.DeviceListRow[0].Click();
            Thread.Sleep(2000);
            csmDeviceDetailsPage.PMTab.Click();
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string columnName)
        {
            bool isColumnNameDisplayed = csmDeviceDetailsPage.PMNameHeading.GetElementVisibility();
            Assert.IsTrue(isColumnNameDisplayed, columnName + " column heading is not displayed");
        }

        [Then(@"""(.*)"" and current calendar year label is displayed")]
        public void ThenAndCurrentCalendarYearLabelIsDisplayed(string leftArrow)
        {
            Thread.Sleep(2000);
            bool IsLeftArrowDisplayed = csmDeviceDetailsPage.LeftArrow.GetElementVisibility();
            bool currentYearDisplayed = csmDeviceDetailsPage.CurrentCalenderYear.GetElementVisibility();

            Assert.IsTrue(IsLeftArrowDisplayed, "Left arrow symbol is not displayed.");
            Assert.IsTrue(currentYearDisplayed, "Current calendar year label is not displayed.");
        }

        [Then(@"next calendar year and ""(.*)"" is displayed")]
        public void ThenNextCalendarYearAndIsDisplayed(string rightArrow)
        {
            bool IsRightArrowDisplayed = csmDeviceDetailsPage.RightArrow.GetElementVisibility();
            bool IsNextYearDisplayed = csmDeviceDetailsPage.NextCalenderYear.GetElementVisibility();

            Assert.IsTrue(IsRightArrowDisplayed, "Right arrow symbol is not displayed.");
            Assert.IsTrue(IsNextYearDisplayed, "Next calendar year is not displayed.");
        }

        [Then(@"current month is displayed followed by the other months")]
        public void ThenCurrentMonthIsDisplayedFollowedByTheOtherMonths()
        {
            bool IsCalenderDisplayed = csmDeviceDetailsPage.CalenderXP.GetElementVisibility();
            string[] monthsArray = csmDeviceDetailsPage.CalenderXP.Text.Split();
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
