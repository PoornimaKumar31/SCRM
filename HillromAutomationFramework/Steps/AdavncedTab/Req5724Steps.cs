using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.PageObjects.AdvancedTab;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.AdavncedTab
{
    [Binding, Scope(Tag = "SoftwareRequirementID_5724")]
    public sealed class Req5724Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        AdvancedPage advancePage = new AdvancedPage();
        

        private readonly ScenarioContext _scenarioContext;

        public Req5724Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"user login as Manager role")]
        public void GivenUserLoginAsManagerRole()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
        }

        [Given(@"user login as Regular role")]
        public void GivenUserLoginAsRegularRole()
        {
            loginPage.LogIn(LoginPage.LogInType.StandardUserWithoutRollUpPage);
        }

        [Then(@"Main page is displayed")]
        public void ThenMainPageIsDisplayed()
        {
            bool IsOrganisationDropdownDisplayed = mainPage.OrganizationDropdown.GetElementVisibility();
            Assert.IsTrue(IsOrganisationDropdownDisplayed, "Main page is not displayed");
        }

        [Then(@"Advanced tab is displayed")]
        public void ThenAdvancedTabIsDisplayed()
        {
            bool IsAdvancedTabDisplayed = advancePage.AdvancedTab.GetElementVisibility();
            Assert.IsTrue(IsAdvancedTabDisplayed, "Advanced tab is not displayed");
        }

        [Then(@"Advanced tab is not displayed")]
        public void ThenAdvancedTabIsNotDisplayed()
        {
            bool IsAdvancedTabDisplayed = advancePage.AdvancedTab.GetElementVisibility();
            Assert.IsFalse(IsAdvancedTabDisplayed, "Advanced tab is displayed");
        }
    }
}
