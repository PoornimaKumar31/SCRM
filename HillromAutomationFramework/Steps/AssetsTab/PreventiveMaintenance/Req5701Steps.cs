using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AssetsTab;
using HillromAutomationFramework.PageObjects.AssetsTab.DeviceDetails;
using HillromAutomationFramework.PageObjects.AssetsTab.PreventiveMaintainenece;
using HillromAutomationFramework.PageObjects.AssetsTab.PreventiveMaintenance;
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
    [Binding, Scope(Tag = "@SoftwareRequirementID_5701")]
    public class SoftwareRequirement5701Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly PreventiveMaintenancePage _preventiveMaintenancePage;
        private readonly MainPage _mainPage;

        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverWait _wait;

        public SoftwareRequirement5701Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _preventiveMaintenancePage = new PreventiveMaintenancePage(driver);
            _mainPage = new MainPage(driver);
        }

        private static class _Global
        {
           public static string testDeviceSerialNumber = "100055940720";
        }

        [Given(@"user is on Asset List page")]
        public void GivenUserIsOnAssetListPage()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
        }

        [When(@"user selects CSM device with serial number ""(.*)""")]
        public void WhenUserSelectsCSMDeviceWithSerialNumber(string serialnumber)
        {
            _mainPage.AssetTypeDropDown.SelectDDL(MainPageExpectedValue.CSMDeviceName);
            Thread.Sleep(2000);
            _mainPage.SearchSerialNumberAndClick(serialnumber);
        }

        [When(@"clicks Preventive maintenance tab")]
        public void WhenClicksPreventiveMaintenanceTab()
        {
            _preventiveMaintenancePage.PMTab.Click();
        }

        [Then(@"Preventive maintenance schedule subsection is displayed")]
        public void ThenPreventiveMaintenanceScheduleSubsectionIsDisplayed()
        {
            bool IsPMScheduleSubsectionDisplayed = _preventiveMaintenancePage.PreventiveMaintenance.GetElementVisibility();
            IsPMScheduleSubsectionDisplayed.Should().BeTrue("Preventive maintenance schedule subsection is displayed.");
        }

        [Then(@"Host controller graphic is displayed in ""(.*)"" column")]
        public void ThenHostControllerGraphicIsDisplayedInColumn(string ColumnName)
        {
            int IndexOfName = _preventiveMaintenancePage.PMSHeader.IndexOf(_preventiveMaintenancePage.PMNameHeading);
            int IndexOfHostController = _preventiveMaintenancePage.PMSRow.IndexOf(_preventiveMaintenancePage.HostContollerColumn);
            Thread.Sleep(2000);
            bool IsHostControllerGraphicDisplayed = _preventiveMaintenancePage.HostControllerGraphic.GetElementVisibility();

            IsHostControllerGraphicDisplayed.Should().BeTrue("Host controller graphic is displayed.");
            IndexOfHostController.Should().Be(IndexOfName, "Host controller graphic is not displayed in Name column.");
        }
        

       [Then(@"""(.*)"" is displayed in ""(.*)"" column")]
        public void ThenIsDisplayedInColumn(string HostController, string ColumnName)
        {
            int IndexOfName = _preventiveMaintenancePage.PMSHeader.IndexOf(_preventiveMaintenancePage.PMNameHeading);
            int IndexOfHostController = _preventiveMaintenancePage.PMSRow.IndexOf(_preventiveMaintenancePage.HostContollerColumn);
            Thread.Sleep(2000);
            bool IsHostControllerDisplayed = _preventiveMaintenancePage.HostController.GetElementVisibility();

            IsHostControllerDisplayed.Should().BeTrue("Host controller is not displayed.");
            IndexOfHostController.Should().Be(IndexOfName, "Host controller is not displayed in Name column.");
        }

        [Then(@"""(.*)"" is ""(.*)"" on ""(.*)"" row in ""(.*)"" column")]
        public void ThenIsOnRowInColumn(string LastCalibration, string LastExpectedCalibrationDate, string HostControllerRow, string LastCalibrationColumn)
        {
            int LastCalibrationHeading = _preventiveMaintenancePage.PMSHeader.IndexOf(_preventiveMaintenancePage.PMLastCalibrationHeading);
            int LastCalibrationDate = _preventiveMaintenancePage.PMSRow.IndexOf(_preventiveMaintenancePage.LastCalibrationDate);
            LastCalibrationDate.Should().Be(LastCalibrationHeading, "Last calibration is not in Host controller row in Last calibration column.");

            string LastActualCalibrationDate = _preventiveMaintenancePage.LastCalibrationDate.Text;
            LastExpectedCalibrationDate.Should().Be(LastActualCalibrationDate, "Last calibration is not 30 Sep 2015 on Host controller row in Last calibration column.");           
        }

        [Then(@"""(.*)"" message is displayed on ""(.*)"" row")]
        public void ThenMessageIsDisplayedOnRow(string CalibrationMessage, string HostControllerRow)
        {
            string text = _preventiveMaintenancePage.CalibrationOverDueText.Text;
            string calibrationOverdueDate = _preventiveMaintenancePage.CalibrationOverDueDate.Text;

            string[] calibrationOverdue = text.Split();
            string calibrationOverdueText = calibrationOverdue[0] + " " + calibrationOverdue[1];

            Thread.Sleep(2000);
            int IndexOfHostController = _preventiveMaintenancePage.PMSRow.IndexOf(_preventiveMaintenancePage.HostContollerColumn);
            if (calibrationOverdueText == CalibrationMessage)
            {
                bool IsDisplayed = _preventiveMaintenancePage.CalibrationOverDueText.GetElementVisibility();
                Assert.AreEqual(IsDisplayed, 0 == IndexOfHostController, "Calibration overdue message is not displayed on Host controller row.");
            }
            else if (calibrationOverdueDate == CalibrationMessage)
            {
                bool IsDisplayed = _preventiveMaintenancePage.LastCalibrationDate.GetElementVisibility();
                Assert.AreEqual(IsDisplayed, 0 == IndexOfHostController, "Calibration overdue message is not displayed on Host controller row.");
            }
        }

        [Then(@"left pointing red arrow is displayed on ""(.*)"" row")]
        public void ThenLeftPointingRedArrowIsDisplayedOnRow(string HostControllerRow)
        {
            //Verifying whether element is displayed
            bool isLeftPointingRedArrowDisplayed = _preventiveMaintenancePage.CalibrationOverDueArrow.GetElementVisibility();
            isLeftPointingRedArrowDisplayed.Should().BeTrue("Left pointing arrow is displayed on " + HostControllerRow + " row.");

            //Checking whether the element is in the host controller row
            int IndexOfHostControllerColumn = _preventiveMaintenancePage.PMSRow.IndexOf(_preventiveMaintenancePage.HostContollerColumn);
            IndexOfHostControllerColumn.Should().Be(0, "Left pointing arrow is displayed on " + HostControllerRow + " row.");

            //Verifying whether displayed image is correct
            string leftPointingRedArrowURL = _preventiveMaintenancePage.CalibrationOverDueArrow.GetAttribute("src");
            leftPointingRedArrowURL.Should().BeEquivalentTo(PropertyClass.BaseURL + PreventiveMaintenancePageExpectedValues.LeftPointingRedArrowImageURL, "Left pointing red arrow is displayed on " + HostControllerRow + " row.");
        }

        [Then(@"upward pointing black arrow is displayed on ""(.*)"" row")]
        public void ThenUpwardPointingBlackArrowIsDisplayedOnRow(string HostControllerRow)
        {
            //Verifying whether element is displayed
            bool IsUpwardPointingArrowDisplayed = _preventiveMaintenancePage.CalibrationOverDueArrow.GetElementVisibility();
            IsUpwardPointingArrowDisplayed.Should().BeTrue("Upward pointing arrow is displayed on " + HostControllerRow + " row.");

            //Checking whether the element is in the host controller row
            int IndexOfHostControllerColumn = _preventiveMaintenancePage.PMSRow.IndexOf(_preventiveMaintenancePage.HostContollerColumn);
            IndexOfHostControllerColumn.Should().Be(0, "Upward pointing arrow is displayed on " + HostControllerRow + " row.");

            //Verifying whether displayed image is correct
            string upwardPointingBlackArrowURL = _preventiveMaintenancePage.CalibrationOverDueArrow.GetAttribute("src");
            upwardPointingBlackArrowURL.Should().BeEquivalentTo(PropertyClass.BaseURL + PreventiveMaintenancePageExpectedValues.UpwardPointingBlackArrowImageURL, "Upward pointing black arrow is not displayed on " + HostControllerRow + " row.");                    
        }

        [Given(@"user is on the Preventive maintenance tab")]
        public void GivenUserIsOnThePreventiveMaintenanceTab()
        {
            GivenUserIsOnAssetListPage();
            WhenUserSelectsCSMDeviceWithSerialNumber(_Global.testDeviceSerialNumber);
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string ColumnHeading)
        {
            bool IsColumnHeadingDisplayed = _preventiveMaintenancePage.PMNameHeading.GetElementVisibility();
            Assert.IsTrue(IsColumnHeadingDisplayed, ColumnHeading + " column heading is not displayed.");
        }

        [Then(@"""(.*)"" and current calendar year label is displayed")]
        public void ThenAndCurrentCalendarYearLabelIsDisplayed(string LeftArrowSymbol)
        {
            Thread.Sleep(2000);
            bool IsLeftArrowDisplayed = _preventiveMaintenancePage.LeftArrow.GetElementVisibility();
            bool currentYearDisplayed = _preventiveMaintenancePage.CurrentCalenderYear.GetElementVisibility();

            Assert.IsTrue(IsLeftArrowDisplayed, "Left arrow symbol is not displayed.");
            Assert.IsTrue(currentYearDisplayed, "Current calendar year label is not displayed.");
        }

        [Then(@"next calendar year and ""(.*)"" is displayed")]
        public void ThenNextCalendarYearAndIsDisplayed(string RigthArrowSymbol)
        {
            bool IsRightArrowDisplayed = _preventiveMaintenancePage.RightArrow.GetElementVisibility();
            bool IsNextYearDisplayed = _preventiveMaintenancePage.NextCalenderYear.GetElementVisibility();

            Assert.IsTrue(IsRightArrowDisplayed, "Right arrow symbol is not displayed.");
            Assert.IsTrue(IsNextYearDisplayed, "Next calendar year is not displayed.");
        }

        [Then(@"current month is displayed followed by the other months")]
        public void ThenCurrentMonthIsDisplayedFollowedByTheOtherMonths()
        {           
            bool IsCalenderDisplayed = _preventiveMaintenancePage.CalenderXP.GetElementVisibility();
            string[] monthsArray = _preventiveMaintenancePage.CalenderXP.Text.Split();           
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
