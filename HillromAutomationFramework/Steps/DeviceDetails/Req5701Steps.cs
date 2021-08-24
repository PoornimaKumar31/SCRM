using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.PageObjects.Component_Information;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
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

            Assert.IsTrue(IsHostControllerGraphicDisplayed);
            Assert.AreEqual(IndexOfName, IndexOfHostController, "Host controller graphic is not displayed in Name column.");
        }
        

       [Then(@"""(.*)"" is displayed in ""(.*)"" column")]
        public void ThenIsDisplayedInColumn(string p0, string p1)
        {
            int IndexOfName = csmDeviceDetailsPage.PMSHeader.IndexOf(csmDeviceDetailsPage.PMNameHeading);
            int IndexOfHostController = csmDeviceDetailsPage.PMSRow.IndexOf(csmDeviceDetailsPage.HostContollerColumn);
            string str = csmDeviceDetailsPage.HostContollerColumn.Text;
            Thread.Sleep(2000);
            bool IsHostControllerDisplayed = csmDeviceDetailsPage.HostController.GetElementVisibility();

            Assert.IsTrue(IsHostControllerDisplayed);
            Assert.AreEqual(IndexOfName, IndexOfHostController, "Host controller is not displayed in Name column.");
        }

        [Then(@"""(.*)"" is ""(.*)"" on ""(.*)"" row in ""(.*)"" column")]
        public void ThenIsOnRowInColumn(string p0, string p1, string p2, string p3)
        {
            int LastCalibrationHeading = csmDeviceDetailsPage.PMSHeader.IndexOf(csmDeviceDetailsPage.PMLastCalibrationHeading);
            int LastCalibrationDate = csmDeviceDetailsPage.PMSRow.IndexOf(csmDeviceDetailsPage.LastCalibrationDate);
            Assert.AreEqual(LastCalibrationHeading, LastCalibrationDate, "Last calibration is not in Host controller row in Last calibration column");

            string str = csmDeviceDetailsPage.LastCalibrationDate.Text;
            Assert.AreEqual(str, p1, "Last calibration is not 30 Sep 2015 on Host controller row in Last calibration column");           
        }

        [Then(@"""(.*)"" message is displayed on ""(.*)"" row")]
        public void ThenMessageIsDisplayedOnRow(string Message, string HostControllerRow)
        {
            string text = csmDeviceDetailsPage.CalibrationOverDueText.Text;
            string[] calibrationOverDue = text.Split();
            string calibrationOverdueText = calibrationOverDue[0] + " " + calibrationOverDue[1];
            string calibrationOverdueDate = calibrationOverDue[3] + " " + calibrationOverDue[4] + " " + calibrationOverDue[5];

            Thread.Sleep(2000);
            string LastCalibrationDateText = csmDeviceDetailsPage.LastCalibrationDate.Text;
            int IndexOfHostController = csmDeviceDetailsPage.PMSRow.IndexOf(csmDeviceDetailsPage.HostContollerColumn);
            if (calibrationOverdueText == Message)
            {
                bool IsDisplayed = csmDeviceDetailsPage.CalibrationOverDueText.GetElementVisibility();
                Assert.AreEqual(IsDisplayed, 0 == IndexOfHostController, "Calibration overdue message is not displayed on Host controller row");
            }
            else if (calibrationOverdueDate == Message)
            {
                bool IsDisplayed = csmDeviceDetailsPage.LastCalibrationDate.GetElementVisibility();
                Assert.AreEqual(IsDisplayed, 0 == IndexOfHostController, "Calibration overdue message is not displayed on Host controller row");
            }
        }

        [Then(@"left pointing red arrow is displayed on ""(.*)"" row")]
        public void ThenLeftPointingRedArrowIsDisplayedOnRow(string HostControllerRow)
        {
            bool IsDisplayed = csmDeviceDetailsPage.CalibrationOverDueArrowe.GetElementVisibility();
            int IndexOfHostController = csmDeviceDetailsPage.PMSRow.IndexOf(csmDeviceDetailsPage.HostContollerColumn);
            Assert.AreEqual(IsDisplayed, 0 == IndexOfHostController, "Calibration overdue message is not displayed on Host controller row");
        }
    }
}
