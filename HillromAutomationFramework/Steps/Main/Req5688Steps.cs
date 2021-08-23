using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Main
{
    [Binding, Scope(Tag = "SoftwareRequirementID_5688")]
    public class Req5688Steps
    {
        MainPage mainPage = new MainPage();
        LoginPage loginPage = new LoginPage();
        CVSMDeviceDetailsPage cvsmDeviceDetailsPage = new CVSMDeviceDetailsPage(); 
        [Given(@"user without roll-up for multiple organizations is on Assets page")]
        public void GivenUserWithoutRoll_UpForMultipleOrganizationsIsOnAssetsPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithOutRollUpPage);
            Assert.AreEqual(true, mainPage.AssetsTab.GetElementVisibility(), "Main page is not displayed");
        }

        [Then(@"all organizations is the default Organization filter")]
        public void ThenAllOrganizationsIsTheDefaultOrganizationFilter()
        {
            Assert.AreEqual(true, mainPage.AllOrganizationDefault.GetElementVisibility(), "All Organizaion is not selected as default value");
        }

        [When(@"user selects organization from Organization dropdown")]
        public void WhenUserSelectsOrganizationFromOrganizationDropdown()
        {
            mainPage.OrganizationDropdown.Click();
            mainPage.AutomatedEyeTestDDLSelection.Click();
        }

        [Then(@"only devices in selected organization are displayed")]
        public void ThenOnlyDevicesInSelectedOrganizationAreDisplayed()
        {
            Thread.Sleep(3000);
            //Assert.AreEqual(true,mainPage.VerifyRecordPresence(MainPage.ExpectedValues.AllOrgnaizationRV700DevicesCount), "All devices for selected organization is not displayed");
        }

        [Given(@"user without roll-up for multiple facilities is on Assets page")]
        public void GivenUserWithoutRoll_UpForMultipleFacilitiesIsOnAssetsPage()
        {
            GivenUserWithoutRoll_UpForMultipleOrganizationsIsOnAssetsPage();
            mainPage.OrganizationDropdown.Click();
            mainPage.LNTAutomatedTestDDLSelection.Click();
        }

        [When(@"user selects facility from Organization dropdown")]
        public void WhenUserSelectsFacilityFromOrganizationDropdown()
        {
            mainPage.OrganizationDropdown.Click();
            mainPage.LNTAutomatedTestDDLExpensionArrow.Click();
            mainPage.LNTAutomatedTestDDLFacility1.Click();
        }

        [Then(@"only devices in selected facility are displayed")]
        public void ThenOnlyDevicesInSelectedFacilityAreDisplayed()
        {
            Thread.Sleep(3000);
            int TotalRecords = mainPage.VerifyRecordPresence();
            Assert.AreEqual(true, MainPage.ExpectedValues.LNTAutomatedTestOrganizationFacilityOneDeviceCount == TotalRecords, "Only devices in selected facility are not displayed");
        }

        [Given(@"user without roll-up for multiple units is on Assets page")]
        public void GivenUserWithoutRoll_UpForMultipleUnitsIsOnAssetsPage()
        {
            GivenUserWithoutRoll_UpForMultipleFacilitiesIsOnAssetsPage();
            mainPage.OrganizationDropdown.Click();
            mainPage.LNTAutomatedTestDDLExpensionArrow.Click();
            mainPage.LNTAutomatedTestDDLFacility1.Click();
        }

        [When(@"user selects unit from Organization dropdown")]
        public void WhenUserSelectsUnitFromOrganizationDropdown()
        {
            mainPage.OrganizationDropdown.Click();
            mainPage.LNTAutmatedTestDDLFacility1ExpensionArrow.Click();
            mainPage.LNTAutmatedTestDDLFacility1Unit1.Click();
        }

        [Then(@"only devices in selected unit are displayed")]
        public void ThenOnlyDevicesInSelectedUnitAreDisplayed()
        {
            Thread.Sleep(5000);
            int TotalRecords = mainPage.VerifyRecordPresence();
            Assert.AreEqual(true, TotalRecords == MainPage.ExpectedValues.LNTAutomatedTestOrganizationFacilityOneUnitOneDeviceCount, "Number of devices in unit of facility is not as expected");
        }

        [When(@"user selects All locations from Organization dropdown")]
        public void WhenUserSelectsAllLocationsFromOrganizationDropdown()
        {
            mainPage.OrganizationDropdown.Click();
            mainPage.AllOrganizationsOption.Click();
        }

        [Then(@"all devices belonging to all user organizations are displayed")]
        public void ThenAllDevicesBelongingToAllUserOrganizationsAreDisplayed()
        {
            Thread.Sleep(3000);
            int totalRecords = mainPage.VerifyRecordPresence();
            Assert.AreEqual(true, totalRecords == MainPage.ExpectedValues.AllOrgnaizationDevicesCount, "All devices are not displayed for all organization");
        }
    }
}
