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

namespace HillromAutomationFramework.Steps.AdavncedTab
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
            bool IsScheduleSubsectionDisplayed = csmDeviceDetailsPage.PreventiveMaintenanceLabel.GetElementVisibility();
            Assert.IsTrue(IsScheduleSubsectionDisplayed, "Preventive maintenance schedule subsection is not displayed");
        }

        [Then(@"Host controller graphic is displayed in ""(.*)"" column")]
        public void ThenHostControllerGraphicIsDisplayedInColumn(string ColumnName)
        {
            int IndexOfName = csmDeviceDetailsPage.PMSHeader.IndexOf(csmDeviceDetailsPage.PMNameHeading);
            int IndexOfHostController = csmDeviceDetailsPage.PMSRow.IndexOf(csmDeviceDetailsPage.HostContollerColumn);
            Thread.Sleep(2000);
            bool IsHostControllerGraphicDisplayed = csmDeviceDetailsPage.HostControllerGraphic.GetElementVisibility();

            Assert.IsTrue(IsHostControllerGraphicDisplayed, "Host controller graphic is not displayed.");
            Assert.AreEqual(IndexOfName, IndexOfHostController, "Host controller graphic is not displayed in Name column.");
        }
        

       [Then(@"""(.*)"" is displayed in ""(.*)"" column")]
        public void ThenIsDisplayedInColumn(string HostController, string NameColumn)
        {
            int IndexOfName = csmDeviceDetailsPage.PMSHeader.IndexOf(csmDeviceDetailsPage.PMNameHeading);
            int IndexOfHostController = csmDeviceDetailsPage.PMSRow.IndexOf(csmDeviceDetailsPage.HostContollerColumn);
            //string str = csmDeviceDetailsPage.HostContollerColumn.Text;
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
            string[] calibrationOverDue = text.Split();
            string calibrationOverdueText = calibrationOverDue[0] + " " + calibrationOverDue[1];
            string calibrationOverdueDate = calibrationOverDue[3] + " " + calibrationOverDue[4] + " " + calibrationOverDue[5];

            Thread.Sleep(2000);
            string LastCalibrationDateText = csmDeviceDetailsPage.LastCalibrationDate.Text;
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
            bool IsDisplayed = csmDeviceDetailsPage.CalibrationOverDueArrowe.GetElementVisibility();
            int IndexOfHostController = csmDeviceDetailsPage.PMSRow.IndexOf(csmDeviceDetailsPage.HostContollerColumn);
            Assert.AreEqual(IsDisplayed, 0 == IndexOfHostController, "Calibration overdue message is not displayed on Host controller row.");
        }

        [Then(@"upward pointing black arrow is displayed on ""(.*)"" row")]
        public void ThenUpwardPointingBlackArrowIsDisplayedOnRow(string HostControllerRow)
        {
            bool IsUpwardPointingArrowDisplayed = csmDeviceDetailsPage.CalibrationOverDueArrowe.GetElementVisibility();
            Assert.IsTrue(IsUpwardPointingArrowDisplayed, "Upward pointing black arrow is displayed on Host controller row.");
            string color = csmDeviceDetailsPage.CalibrationOverDueArrowe.GetCssValue("color");

            String[] hexValue = color.Replace("rgba(", "").Replace(")", "").Split(",");

            int hexValue1 = int.Parse(hexValue[0].Trim());
            int hexValue2 = int.Parse(hexValue[1].Trim());
            int hexValue3 = int.Parse(hexValue[2].Trim());

            string actualColour = GetMethods.ConvertRGBtoHex(hexValue1, hexValue2, hexValue3);

            Assert.AreEqual("#444444", actualColour, "Upward pointing black arrow is displayed on Host controller row");
        }

        [Given(@"user is on the Preventive maintenance tab")]
        public void GivenUserIsOnThePreventiveMaintenanceTab()
        {
            GivenUserIsOnAssetListPage();
            WhenUserSelectsCSMDeviceWithSerialNumber("100055940720");
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string ColumnHeading)
        {
            string str = csmDeviceDetailsPage.PMNameHeading.Text;
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
            //Actual
            bool IsCalenderDisplayed = csmDeviceDetailsPage.CalenderXP.GetElementVisibility();
            string[] monthsArray = csmDeviceDetailsPage.CalenderXP.Text.Split();           
            List<string> listOfMonths = monthsArray.ToList<string>();
            listOfMonths.RemoveAll(p => string.IsNullOrEmpty(p));
            monthsArray = listOfMonths.ToArray();

            //Expected 
            var monthsName = GetMethods.GetMonthsName();
            string[] Expectedmonths = monthsName.ToArray();
            bool isSequenceSame = false;
            isSequenceSame = monthsArray.SequenceEqual(monthsName);
            Assert.IsTrue(isSequenceSame, "Current month is not displayed followed by the other months");
        }
    }
}
