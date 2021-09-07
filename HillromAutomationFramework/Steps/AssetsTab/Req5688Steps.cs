using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.AssetsTab
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
            SetMethods.ScrollToBottomofWebpage();
            Thread.Sleep(3000);
            Assert.AreEqual(MainPage.ExpectedValues.AllOrgnaizationRV700DevicesCount,mainPage.VerifyRecordPresence(), "All devices for selected organization is not displayed");
        }

        [Given(@"user without roll-up for multiple facilities is on Assets page")]
        public void GivenUserWithoutRoll_UpForMultipleFacilitiesIsOnAssetsPage()
        {
            GivenUserWithoutRoll_UpForMultipleOrganizationsIsOnAssetsPage();
            Thread.Sleep(1000);
            mainPage.OrganizationDropdown.Click();
            Thread.Sleep(1000);
            mainPage.LNTAutomatedTestDDLSelection.Click();
        }

        [When(@"user selects facility from Organization dropdown")]
        public void WhenUserSelectsFacilityFromOrganizationDropdown()
        {
            Thread.Sleep(2000);
            mainPage.OrganizationDropdown.ClickWebElement("Organization DropDown");
            mainPage.LNTAutomatedTestDDLExpensionArrow.ClickWebElement("LNT Automated Test organization ExpensionArrow in organization dropdown");
            Thread.Sleep(2000);
            mainPage.LNTAutomatedTestDDLFacility1.ClickWebElement("LNT Automated Test organization Test1 facility");
        }

        [Then(@"only devices in selected facility are displayed")]
        public void ThenOnlyDevicesInSelectedFacilityAreDisplayed()
        {
            SetMethods.ScrollToBottomofWebpage();
            Thread.Sleep(3000);
            int TotalRecords = mainPage.VerifyRecordPresence();
            Assert.AreEqual(true, MainPage.ExpectedValues.LNTAutomatedTestOrganizationFacilityOneDeviceCount == TotalRecords, "Only devices in selected facility are not displayed");
        }

        [Given(@"user without roll-up for multiple units is on Assets page")]
        public void GivenUserWithoutRoll_UpForMultipleUnitsIsOnAssetsPage()
        {
            GivenUserWithoutRoll_UpForMultipleFacilitiesIsOnAssetsPage();
            mainPage.OrganizationDropdown.ClickWebElement("Organization dropdown");
            mainPage.LNTAutomatedTestDDLExpensionArrow.ClickWebElement("LNT Automated Test organization ExpensionArrow in organization dropdown");
            mainPage.LNTAutomatedTestDDLFacility1.ClickWebElement("LNT Automated Test organization Test1 facility");
        }

        [When(@"user selects unit from Organization dropdown")]
        public void WhenUserSelectsUnitFromOrganizationDropdown()
        {
            mainPage.OrganizationDropdown.Click();
            Thread.Sleep(1000);
            mainPage.LNTAutmatedTestDDLFacility1ExpensionArrow.Click();
            Thread.Sleep(1000);
            mainPage.LNTAutmatedTestDDLFacility1Unit1.Click();
        }

        [Then(@"only devices in selected unit are displayed")]
        public void ThenOnlyDevicesInSelectedUnitAreDisplayed()
        {
            SetMethods.ScrollToBottomofWebpage();
            Thread.Sleep(5000);
            int TotalRecords = mainPage.VerifyRecordPresence();
            Assert.AreEqual(true, TotalRecords == MainPage.ExpectedValues.LNTAutomatedTestOrganizationFacilityOneUnitOneDeviceCount, "Number of devices in unit of facility is not as expected");
        }

        [When(@"user selects All locations from Organization dropdown")]
        public void WhenUserSelectsAllLocationsFromOrganizationDropdown()
        {
            Thread.Sleep(1000);
            mainPage.OrganizationDropdown.Click();
            Thread.Sleep(1000);
            mainPage.AllOrganizationsOption.Click();
        }

        [Then(@"all devices belonging to all user organizations are displayed")]
        public void ThenAllDevicesBelongingToAllUserOrganizationsAreDisplayed()
        {
            Thread.Sleep(5000);
            SetMethods.ScrollToBottomofWebpage();
            int totalRecords = mainPage.VerifyRecordPresence();
            (totalRecords).Should().Be(MainPage.ExpectedValues.AllOrgnaizationDevicesCount, because: "All devices should be displayed for all organization");
        }
    }
}
