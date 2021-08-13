using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5701")]
    public class Req5701Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        CSMDeviceDetailsPage csmDeviceDetailsPage = new CSMDeviceDetailsPage();

        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        private ScenarioContext _scenarioContext;

        public Req5701Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"user is on the CSM Preventive Maintenance Schedule tab")]
        public void GivenUserIsOnTheCSMPreventiveMaintenanceScheduleTab()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Message = "Asset list table is not displayed in the main page.Timout exception";
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.SearchSerialNumberAndClick("100010000006");
        }

        [Then(@"Name column heading is displayed")]
        public void ThenNameColumnHeadingIsDisplayed()
        {
            Assert.IsTrue(csmDeviceDetailsPage.PMNameHeading.GetElementVisibility(),"Name heading is not displayed");
            Assert.AreEqual(CSMDeviceDetailsPage.ExpectedValues.PMNameHeadingText.ToLower(), csmDeviceDetailsPage.PMNameHeading.Text.ToLower(),"Name heading is not matching with the expected value.");
        }

        [Then(@"Last calibration column heading is displayed")]
        public void ThenLastCalibrationColumnHeadingIsDisplayed()
        {
            Assert.IsTrue(csmDeviceDetailsPage.PMLastCalibrationHeading.GetElementVisibility(), "Last calibration heading is not displayed");
            Assert.AreEqual(CSMDeviceDetailsPage.ExpectedValues.PMLastCalibrationText.ToLower(), csmDeviceDetailsPage.PMLastCalibrationHeading.Text.ToLower(), "Last calibration heading is not matching with the expected value.");
        }

        [Then(@"timeline column is displayed")]
        public void ThenTimelineColumnIsDisplayed()
        {
            _scenarioContext.Pending();
        }

        [Then(@"components are displayed")]
        public void ThenComponentsAreDisplayed()
        {
            _scenarioContext.Pending();
        }

        [Then(@"last calibration date is displayed")]
        public void ThenLastCalibrationDateIsDisplayed()
        {
            Assert.IsTrue(csmDeviceDetailsPage.LastCalibrationDate.GetElementVisibility(),"Last calibration date is not displayed.");
        }

        [Then(@"calibration overdue with date and arrow is displayed")]
        public void ThenCalibrationOverdueWithDateAndArrowIsDisplayed()
        {
            //Calibration overdue arrow
            Assert.IsTrue(csmDeviceDetailsPage.CalibrationOverDueArrowe.GetElementVisibility(),"Calibration overdue arrow is not displayed.");

            //Calibration overdue text
            Assert.IsTrue(csmDeviceDetailsPage.CalibrationOverDueText.GetElementVisibility(),"Calibration overdue text is not displayed.");

        }

    }
}
