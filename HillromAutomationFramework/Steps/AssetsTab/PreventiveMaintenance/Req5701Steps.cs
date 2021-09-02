using FluentAssertions;
using HillromAutomationFramework.PageObjects;
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

namespace HillromAutomationFramework.Steps.AssetsTab.PreventiveMaintenance
{
    [Binding, Scope(Tag = "@SoftwareRequirementID_5701")]
    public class SoftwareRequirement5701Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        CSMAssetListPage csmAssetListPage = new CSMAssetListPage();
        CSMDeviceDetailsPage csmDeviceDetailsPage = new CSMDeviceDetailsPage();
        MainPage mainPage = new MainPage();
        string testDeviceSerialNumber = "100055940720";

        [Given(@"user is on Asset List page")]
        public void GivenUserIsOnAssetListPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
        }

        [When(@"user selects CSM device with serial number ""(.*)""")]
        public void WhenUserSelectsCSMDeviceWithSerialNumber(string serialnumber)
        {
            mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CSMDeviceName);
            Thread.Sleep(2000);
            mainPage.SearchSerialNumberAndClick(serialnumber);
        }

        [When(@"clicks Preventive maintenance tab")]
        public void WhenClicksPreventiveMaintenanceTab()
        {
            csmDeviceDetailsPage.PMTab.Click();
        }

        [Then(@"Preventive maintenance schedule subsection is displayed")]
        public void ThenPreventiveMaintenanceScheduleSubsectionIsDisplayed()
        {
            bool IsPMScheduleSubsectionDisplayed = csmDeviceDetailsPage.PreventiveMaintenance.GetElementVisibility();
            IsPMScheduleSubsectionDisplayed.Should().BeTrue("Preventive maintenance schedule subsection is displayed.");
        }

        [Then(@"Host controller graphic is displayed in ""(.*)"" column")]
        public void ThenHostControllerGraphicIsDisplayedInColumn(string ColumnName)
        {
            int IndexOfName = csmDeviceDetailsPage.PMSHeader.IndexOf(csmDeviceDetailsPage.PMNameHeading);
            int IndexOfHostController = csmDeviceDetailsPage.PMSRow.IndexOf(csmDeviceDetailsPage.HostContollerColumn);
            Thread.Sleep(2000);
            bool IsHostControllerGraphicDisplayed = csmDeviceDetailsPage.HostControllerGraphic.GetElementVisibility();

            IsHostControllerGraphicDisplayed.Should().BeTrue("Host controller graphic is displayed.");
            Assert.AreEqual(IndexOfName, IndexOfHostController, "Host controller graphic is not displayed in Name column.");
        }
        

       [Then(@"""(.*)"" is displayed in ""(.*)"" column")]
        public void ThenIsDisplayedInColumn(string HostController, string ColumnName)
        {
            int IndexOfName = csmDeviceDetailsPage.PMSHeader.IndexOf(csmDeviceDetailsPage.PMNameHeading);
            int IndexOfHostController = csmDeviceDetailsPage.PMSRow.IndexOf(csmDeviceDetailsPage.HostContollerColumn);
            Thread.Sleep(2000);
            bool IsHostControllerDisplayed = csmDeviceDetailsPage.HostController.GetElementVisibility();

            Assert.IsTrue(IsHostControllerDisplayed, "Host controller is not displayed.");
            Assert.AreEqual(IndexOfName, IndexOfHostController, "Host controller is not displayed in Name column.");
        }

        [Then(@"""(.*)"" is ""(.*)"" on ""(.*)"" row in ""(.*)"" column")]
        public void ThenIsOnRowInColumn(string LastCalibration, string LastExpectedCalibrationDate, string HostControllerRow, string LastCalibrationColumn)
        {
            int LastCalibrationHeading = csmDeviceDetailsPage.PMSHeader.IndexOf(csmDeviceDetailsPage.PMLastCalibrationHeading);
            int LastCalibrationDate = csmDeviceDetailsPage.PMSRow.IndexOf(csmDeviceDetailsPage.LastCalibrationDate);
            Assert.AreEqual(LastCalibrationHeading, LastCalibrationDate, "Last calibration is not in Host controller row in Last calibration column.");

            string LastActualCalibrationDate = csmDeviceDetailsPage.LastCalibrationDate.Text;
            Assert.AreEqual(LastActualCalibrationDate, LastExpectedCalibrationDate, "Last calibration is not 30 Sep 2015 on Host controller row in Last calibration column.");           
        }

        [Then(@"""(.*)"" message is displayed on ""(.*)"" row")]
        public void ThenMessageIsDisplayedOnRow(string CalibrationMessage, string HostControllerRow)
        {
            string text = csmDeviceDetailsPage.CalibrationOverDueText.Text;
            string calibrationOverdueDate = csmDeviceDetailsPage.CalibrationOverDueDate.Text;

            string[] calibrationOverdue = text.Split();
            string calibrationOverdueText = calibrationOverdue[0] + " " + calibrationOverdue[1];

            Thread.Sleep(2000);
            int IndexOfHostController = csmDeviceDetailsPage.PMSRow.IndexOf(csmDeviceDetailsPage.HostContollerColumn);
            if (calibrationOverdueText == CalibrationMessage)
            {
                bool IsDisplayed = csmDeviceDetailsPage.CalibrationOverDueText.GetElementVisibility();
                Assert.AreEqual(IsDisplayed, 0 == IndexOfHostController, "Calibration overdue message is not displayed on Host controller row.");
            }
            else if (calibrationOverdueDate == CalibrationMessage)
            {
                bool IsDisplayed = csmDeviceDetailsPage.LastCalibrationDate.GetElementVisibility();
                Assert.AreEqual(IsDisplayed, 0 == IndexOfHostController, "Calibration overdue message is not displayed on Host controller row.");
            }
        }

        [Then(@"left pointing red arrow is displayed on ""(.*)"" row")]
        public void ThenLeftPointingRedArrowIsDisplayedOnRow(string HostControllerRow)
        {
            bool isLeftPointingRedArrowDisplayed = csmDeviceDetailsPage.CalibrationOverDueArrow.GetElementVisibility();
            isLeftPointingRedArrowDisplayed.Should().BeTrue("Left pointing arrow is displayed on " + HostControllerRow + " row.");

            int IndexOfHostControllerColumn = csmDeviceDetailsPage.PMSRow.IndexOf(csmDeviceDetailsPage.HostContollerColumn);
            IndexOfHostControllerColumn.Should().Be(0, "Left pointing arrow is displayed on " + HostControllerRow + " row.");

            string leftPointingRedArrowURL = csmDeviceDetailsPage.CalibrationOverDueArrow.GetAttribute("src");
            leftPointingRedArrowURL.Should().BeEquivalentTo(CSMDeviceDetailsPage.ExpectedValues.LeftPointingRedArrowImageURL, "Left pointing red arrow is displayed on " + HostControllerRow + " row.");
        }

        [Then(@"upward pointing black arrow is displayed on ""(.*)"" row")]
        public void ThenUpwardPointingBlackArrowIsDisplayedOnRow(string HostControllerRow)
        {
            bool IsUpwardPointingArrowDisplayed = csmDeviceDetailsPage.CalibrationOverDueArrow.GetElementVisibility();
            IsUpwardPointingArrowDisplayed.Should().BeTrue("Upward pointing arrow is displayed on " + HostControllerRow + " row.");

            int IndexOfHostControllerColumn = csmDeviceDetailsPage.PMSRow.IndexOf(csmDeviceDetailsPage.HostContollerColumn);
            IndexOfHostControllerColumn.Should().Be(0, "Upward pointing arrow is displayed on " + HostControllerRow + " row.");

            string upwardPointingBlackArrowURL = csmDeviceDetailsPage.CalibrationOverDueArrow.GetAttribute("src");
            upwardPointingBlackArrowURL.Should().BeEquivalentTo(CSMDeviceDetailsPage.ExpectedValues.UpwardPointingBlackArrowImageURL, "Upward pointing black arrow is not displayed on " + HostControllerRow + " row.");                    
        }

        [Given(@"user is on the Preventive maintenance tab")]
        public void GivenUserIsOnThePreventiveMaintenanceTab()
        {
            GivenUserIsOnAssetListPage();
            WhenUserSelectsCSMDeviceWithSerialNumber(testDeviceSerialNumber);
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string ColumnHeading)
        {
            bool IsColumnHeadingDisplayed = csmDeviceDetailsPage.PMNameHeading.GetElementVisibility();
            Assert.IsTrue(IsColumnHeadingDisplayed, ColumnHeading + " column heading is not displayed.");
        }

        [Then(@"""(.*)"" and current calendar year label is displayed")]
        public void ThenAndCurrentCalendarYearLabelIsDisplayed(string LeftArrowSymbol)
        {
            Thread.Sleep(2000);
            bool IsLeftArrowDisplayed = csmDeviceDetailsPage.LeftArrow.GetElementVisibility();
            bool currentYearDisplayed = csmDeviceDetailsPage.CurrentCalenderYear.GetElementVisibility();

            Assert.IsTrue(IsLeftArrowDisplayed, "Left arrow symbol is not displayed.");
            Assert.IsTrue(currentYearDisplayed, "Current calendar year label is not displayed.");
        }

        [Then(@"next calendar year and ""(.*)"" is displayed")]
        public void ThenNextCalendarYearAndIsDisplayed(string RigthArrowSymbol)
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
