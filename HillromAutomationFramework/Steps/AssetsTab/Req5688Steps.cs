using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AssetsTab;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.AssetsTab
{
    [Binding, Scope(Tag = "SoftwareRequirementID_5688")]
    public class Req5688Steps
    {
        private readonly LoginPage _loginPage;
        private readonly MainPage _mainPage;

        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverWait _wait;

        public Req5688Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _mainPage = new MainPage(driver);
        }

        [Given(@"user without roll-up for multiple organizations is on Assets page")]
        public void GivenUserWithoutRoll_UpForMultipleOrganizationsIsOnAssetsPage()
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithOutRollUpPage);
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
            Assert.AreEqual(true, _mainPage.AssetsTab.GetElementVisibility(), "Main page is not displayed");
        }

        [Then(@"all organizations is the default Organization filter")]
        public void ThenAllOrganizationsIsTheDefaultOrganizationFilter()
        {
            Assert.AreEqual(true, _mainPage.AllOrganizationDefault.GetElementVisibility(), "All Organizaion is not selected as default value");
        }

        [When(@"user selects organization from Organization dropdown")]
        public void WhenUserSelectsOrganizationFromOrganizationDropdown()
        {
            _mainPage.OrganizationDropdown.ClickWebElement(_driver, "Organization dropdown");
            Thread.Sleep(1000);
            _mainPage.AutomatedEyeTestDDLSelection.ClickWebElement(_driver, "L&t Automated Eye Test organization");
        }

        [Then(@"only devices in selected organization are displayed")]
        public void ThenOnlyDevicesInSelectedOrganizationAreDisplayed()
        {
            Thread.Sleep(3000);
            List<string> LocationColumnDataList = _mainPage.GetColumnData("Location");

            foreach(string data in LocationColumnDataList)
            {
                data.Should().StartWithEquivalentOf(MainPageExpectedValue.LTAutomatedEyeTestOrgnaizationText);
            }
        }

        [Given(@"user without roll-up for multiple facilities is on Assets page")]
        public void GivenUserWithoutRoll_UpForMultipleFacilitiesIsOnAssetsPage()
        {
            GivenUserWithoutRoll_UpForMultipleOrganizationsIsOnAssetsPage();
            Thread.Sleep(2000);
            _mainPage.OrganizationDropdown.Click();
            Thread.Sleep(2000);
            _mainPage.LNTAutomatedTestDDLSelection.Click();
        }

        [When(@"user selects facility from Organization dropdown")]
        public void WhenUserSelectsFacilityFromOrganizationDropdown()
        {
            Thread.Sleep(5000);
            int OrganizationDropDownwidthInPixel = _mainPage.OrganizationDropdown.Size.Width;

            int MoveElementByoffSetX = (OrganizationDropDownwidthInPixel / 2)-1 ;

            //Clicking on the organization drop down by pixels offset 
            Actions actions = new Actions(_driver);
            actions.MoveToElement(_mainPage.OrganizationDropdown, MoveElementByoffSetX, 0,MoveToElementOffsetOrigin.Center).Perform();
            actions.Click().Perform();
           

            Thread.Sleep(1000);
            _mainPage.LNTAutomatedTestDDLExpensionArrow.ClickWebElement(_driver,"LNT Automated Test organization ExpensionArrow in organization dropdown");
            Thread.Sleep(1000);
            _mainPage.LNTAutomatedTestDDLFacility1.ClickWebElement(_driver,"LNT Automated Test organization Test1 facility");
        }

        [Then(@"only devices in selected facility are displayed")]
        public void ThenOnlyDevicesInSelectedFacilityAreDisplayed()
        {
            Thread.Sleep(3000);
            List<string> LocationColumnData = _mainPage.GetColumnData("Location");

            foreach(string data in LocationColumnData)
            {
                data.Should().StartWithEquivalentOf(MainPageExpectedValue.LNTAutomatedTestOrganizationFacilityTest1Text,
                    because: "only LNT Automated Test Organization Facility Test1 should be displayed in asset list page");
            }
        }

        [Given(@"user without roll-up for multiple units is on Assets page")]
        public void GivenUserWithoutRoll_UpForMultipleUnitsIsOnAssetsPage()
        {
            GivenUserWithoutRoll_UpForMultipleFacilitiesIsOnAssetsPage();

            int OrganizationDropDownwidthInPixel = _mainPage.OrganizationDropdown.Size.Width;

            int MoveElementByoffSetX = (OrganizationDropDownwidthInPixel / 2) - 1;

            //Clicking on the organization drop down by pixels offset 
            Actions actions = new Actions(_driver);
            actions.MoveToElement(_mainPage.OrganizationDropdown, MoveElementByoffSetX, 0, MoveToElementOffsetOrigin.Center).Perform();
            actions.Click().Perform();

            Thread.Sleep(2000);
            _mainPage.LNTAutomatedTestDDLExpensionArrow.ClickWebElement(_driver,"LNT Automated Test organization ExpensionArrow in organization dropdown");
            Thread.Sleep(1000);
            _mainPage.LNTAutomatedTestDDLFacility1.ClickWebElement(_driver,"LNT Automated Test organization Test1 facility");
        }

        [When(@"user selects unit from Organization dropdown")]
        public void WhenUserSelectsUnitFromOrganizationDropdown()
        {
            
            Thread.Sleep(2000);

            int OrganizationDropDownwidthInPixel = _mainPage.OrganizationDropdown.Size.Width;

            int MoveElementByoffSetX = (OrganizationDropDownwidthInPixel / 2) - 1;

            //Clicking on the organization drop down by pixels offset 
            Actions actions = new Actions(_driver);
            actions.MoveToElement(_mainPage.OrganizationDropdown, MoveElementByoffSetX, 0, MoveToElementOffsetOrigin.Center).Perform();
            actions.Click().Perform();

            _mainPage.LNTAutmatedTestDDLFacility1ExpensionArrow.ClickWebElement(_driver,"FacilityExpansionArrow");
            Thread.Sleep(2000);
            //station1
            _mainPage.LNTAutmatedTestDDLFacility1Unit1.ClickWebElement(_driver,"station1");
        }

        [Then(@"only devices in selected unit are displayed")]
        public void ThenOnlyDevicesInSelectedUnitAreDisplayed()
        {
            Thread.Sleep(5000);
            List<string> LocationColumnData = _mainPage.GetColumnData("Location");

            //Asserting
            LocationColumnData.Should().AllBeEquivalentTo(MainPageExpectedValue.LNTAutomatedTestOrganizationFacilityTest1UnitStation1Text, because: "Only devices related to LNT Automated Test Organization Facility Test1 Unit Station1 should be displayed");
        }

        [When(@"user selects All locations from Organization dropdown")]
        public void WhenUserSelectsAllLocationsFromOrganizationDropdown()
        {
            Thread.Sleep(1000);
            _mainPage.OrganizationDropdown.Click();
            Thread.Sleep(1000);
            _mainPage.AllOrganizationsOption.Click();
        }

        [Then(@"all devices belonging to all user organizations are displayed")]
        public void ThenAllDevicesBelongingToAllUserOrganizationsAreDisplayed()
        {
            Thread.Sleep(5000);
            SetMethods.ScrollToBottomofWebpage(_driver);
            int totalRecords = _mainPage.VerifyRecordPresence();
            (totalRecords).Should().Be(int.Parse(MainPageExpectedValue.AllOrgnaizationDevicesCount), because: "All devices should be displayed for all organization");
        }
    }
}
