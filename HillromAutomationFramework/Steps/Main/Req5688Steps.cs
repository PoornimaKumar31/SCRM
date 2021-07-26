using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Main
{
    [Binding]
    public class Req5688Steps
    {

        private ScenarioContext _scenarioContext;

        public Req5688Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Given(@"user without roll-up page for multiple organizations is on Assets page")]
        public void GivenUserWithoutRoll_UpPageForMultipleOrganizationsIsOnAssetsPage()
        {
            _scenarioContext.Pending();
        }


        [Given(@"user without roll-up page for multiple facilities is on Assets page")]
        public void GivenUserWithoutRoll_UpPageForMultipleFacilitiesIsOnAssetsPage()
        {
            _scenarioContext.Pending();
        }

        [Given(@"user without roll-up page for multiple units is on Assets page")]
        public void GivenUserWithoutRoll_UpPageForMultipleUnitsIsOnAssetsPage()
        {
            _scenarioContext.Pending();
        }


        [When(@"user selects organization from Organization dropdown")]
        public void WhenUserSelectsOrganizationFromOrganizationDropdown()
        {
            _scenarioContext.Pending();
        }
        
        [When(@"user selects facility from Organization dropdown")]
        public void WhenUserSelectsFacilityFromOrganizationDropdown()
        {
            _scenarioContext.Pending();
        }
        
        [When(@"user selects unit from Organization dropdown")]
        public void WhenUserSelectsUnitFromOrganizationDropdown()
        {
            _scenarioContext.Pending();
        }
        
        [When(@"user selects All locations from Organization dropdown")]
        public void WhenUserSelectsAllLocationsFromOrganizationDropdown()
        {
            _scenarioContext.Pending();
        }
        
        [Then(@"all organizations is the default Organization filter")]
        public void ThenAllOrganizationsIsTheDefaultOrganizationFilter()
        {
            _scenarioContext.Pending();
        }
        
        [Then(@"only devices in selected organization are displayed")]
        public void ThenOnlyDevicesInSelectedOrganizationAreDisplayed()
        {
            _scenarioContext.Pending();
        }
        
        [Then(@"only devices in selected facility are displayed")]
        public void ThenOnlyDevicesInSelectedFacilityAreDisplayed()
        {
            _scenarioContext.Pending();
        }
        
        [Then(@"only devices in selected unit are displayed")]
        public void ThenOnlyDevicesInSelectedUnitAreDisplayed()
        {
            _scenarioContext.Pending();
        }
        
        [Then(@"all devices belonging to all user organizations are displayed")]
        public void ThenAllDevicesBelongingToAllUserOrganizationsAreDisplayed()
        {
            _scenarioContext.Pending();
        }
    }
}
