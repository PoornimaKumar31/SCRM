using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Main
{
    [Binding]
    public class Req5686Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        private ScenarioContext _scenarioContext;

        public Req5686Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"the user is on Landing page")]
        public void GivenTheUserIsOnLandingPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            Assert.AreEqual(true, landingPage.Organization0Facility0Title.GetElementVisibility(), "User is not on Landing page.");
        }
        
        [When(@"user clicks Facility panel for an organization")]
        public void WhenUserClicksFacilityPanelForAnOrganization()
        {
            landingPage.Organization0Facility0Title.Click();
        }
        
        [Then(@"Organization label is displayed")]
        public void ThenOrganizationLabelIsDisplayed()
        {
            //replace organization label xpath with id. 
            Assert.AreEqual(true, mainPage.OrganizationLabel.GetElementVisibility(), "Organization label is not displayed.");
        }
        
        [Then(@"Organization dropdown is displayed")]
        public void ThenOrganizationDropdownIsDisplayed()
        {
            Assert.AreEqual(true, mainPage.OrganizationDropdown.GetElementVisibility(), "Organzation dropdown is not displayed.");
        }
        
        [Then(@"Asset type label is displayed")]
        public void ThenAssetTypeLabelIsDisplayed()
        {
            //id should check in centrella link
            _scenarioContext.Pending();
        }
        
        [Then(@"Asset type dropdown is displayed")]
        public void ThenAssetTypeDropdownIsDisplayed()
        {
            Assert.AreEqual(true, mainPage.AssetTypeDropDown.GetElementVisibility(), "Asset type dropdown is not displayed.");
        }
        
        [Then(@"Search field is displayed")]
        public void ThenSearchFieldIsDisplayed()
        {
            Assert.AreEqual(true, mainPage.SearchField.GetElementVisibility(), "Search field is displayed.");
        }
        
        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string columnHeading)
        {
            IWebElement heading=null;
            switch(columnHeading.ToLower().Trim())
            {
                case "type": 
                    heading = mainPage.TypeHeading;
                    break;
                case "firware":
                    heading = mainPage.FirmwareHeading;
                    break;
                case "config file":
                    heading = mainPage.ConfigFileHeading;
                    break;
                case "asset tag":
                    heading = mainPage.AssetTagHeading;
                    break;
                case "serial number":
                    heading = mainPage.SerialNumberHeading;
                    break;
                case "location":
                    heading = mainPage.LocationHeading;
                    break;
                case "last conected":
                    heading = mainPage.LastConnectedHeading;
                    break;
                case "pm due":
                    heading = mainPage.PMDueHeading;
                    break;
                default: Assert.Fail(columnHeading+" is an invalid heading name.");
                    break;
            }
            Assert.AreEqual(true, heading.GetElementVisibility(),columnHeading+ " heading is not displayed.");
        }
        
        [Then(@"Page x of y label is displayed")]
        public void ThenPageXOfYLabelIsDisplayed()
        {
            Assert.AreEqual(true, mainPage.PaginationXOfYLabel.GetElementVisibility(), "Page x of y label is not displayed");
        }
        
        [Then(@"Displaying x to y of z results label is displayed")]
        public void ThenDisplayingXToYOfZResultsLabelIsDisplayed()
        {
            Assert.AreEqual(true, mainPage.PaginationDisplay.GetElementVisibility(), "Displaying x to y of z results label is not displayed");
        }
    }
}
