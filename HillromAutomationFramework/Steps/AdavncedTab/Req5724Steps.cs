using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AdvancedTab;
using HillromAutomationFramework.SupportingCode;
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
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly AdvancedPage _advancePage;       

        public Req5724Steps()
        {
            _loginPage = new LoginPage();
            _landingPage = new LandingPage();
            _mainPage = new MainPage();
            _advancePage = new AdvancedPage();
        }

        [Given(@"user login as Manager role")]
        public void GivenUserLoginAsManagerRole()
        {
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
        }

        [Given(@"user login as Regular role")]
        public void GivenUserLoginAsRegularRole()
        {
            _loginPage.LogIn(LoginPage.LogInType.StandardUserWithoutRollUpPage);
        }

        [Then(@"Main page is displayed")]
        public void ThenMainPageIsDisplayed()
        {
            bool IsOrganisationDropdownDisplayed = _mainPage.OrganizationDropdown.GetElementVisibility();
            Assert.IsTrue(IsOrganisationDropdownDisplayed, "Main page is not displayed");
        }

        [Then(@"Advanced tab is displayed")]
        public void ThenAdvancedTabIsDisplayed()
        {
            bool IsAdvancedTabDisplayed = _advancePage.AdvancedTab.GetElementVisibility();
            Assert.IsTrue(IsAdvancedTabDisplayed, "Advanced tab is not displayed");
        }

        [Then(@"Advanced tab is not displayed")]
        public void ThenAdvancedTabIsNotDisplayed()
        {
            bool IsAdvancedTabDisplayed = _advancePage.AdvancedTab.GetElementVisibility();
            Assert.IsFalse(IsAdvancedTabDisplayed, "Advanced tab is displayed");
        }
    }
}
