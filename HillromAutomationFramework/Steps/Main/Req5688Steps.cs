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
        [Given(@"user without roll-up page for multiple organizations is on Assets page")]
        public void GivenUserWithoutRoll_UpPageForMultipleOrganizationsIsOnAssetsPage()
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
            Assert.AreEqual(MainPage.ExpectedValues.AllOrgnaizationRV700DevicesCount, mainPage.DeviceListRow.GetElementCount(), "All devices for selected organization is not displayed");
        }

        [Given(@"user without roll-up page for multiple facilities is on Assets page")]
        public void GivenUserWithoutRoll_UpPageForMultipleFacilitiesIsOnAssetsPage()
        {
            GivenUserWithoutRoll_UpPageForMultipleOrganizationsIsOnAssetsPage();
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
            Assert.AreEqual(MainPage.ExpectedValues.LNTAutomatedTestOrganizationFacilityOneDeviceCount, mainPage.DeviceListRow.Count, "Number of devices in organizaion facility is not as expected");
        }

        [Given(@"user without roll-up page for multiple units is on Assets page")]
        public void GivenUserWithoutRoll_UpPageForMultipleUnitsIsOnAssetsPage()
        {
            GivenUserWithoutRoll_UpPageForMultipleFacilitiesIsOnAssetsPage();
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
            Assert.AreEqual(MainPage.ExpectedValues.LNTAutomatedTestOrganizationFacilityOneUnitOneDeviceCount, mainPage.DeviceListRow.Count, "Number of devices in unit of facility is not as expected");
        }

        [When(@"user selects All locations from Organization dropdown")]
        public void WhenUserSelectsAllLocationsFromOrganizationDropdown()
        {
            GivenUserWithoutRoll_UpPageForMultipleOrganizationsIsOnAssetsPage();
        }

        [Then(@"all devices belonging to all user organizations are displayed")]
        public void ThenAllDevicesBelongingToAllUserOrganizationsAreDisplayed()
        {
            
        }

    }
}
