using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AdvancedTab;
using HillromAutomationFramework.SupportingCode;
using OpenQA.Selenium;
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

        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public Req5724Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
            _advancePage = new AdvancedPage(driver);
        }

        [Given(@"user login as Manager role")]
        public void GivenUserLoginAsManagerRole()
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
        }

        [Given(@"user login as Regular role")]
        public void GivenUserLoginAsRegularRole()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.StandardUserWithoutRollUpPage);
        }

        [Then(@"Main page is displayed")]
        public void ThenMainPageIsDisplayed()
        {
            bool isOrganisationDropdownDisplayed = _mainPage.OrganizationDropdown.GetElementVisibility();
            isOrganisationDropdownDisplayed.Should().BeTrue("Main page should be displayed.");
        }

        [Then(@"Advanced tab is displayed")]
        public void ThenAdvancedTabIsDisplayed()
        {
            bool isAdvancedTabDisplayed = _advancePage.AdvancedTab.GetElementVisibility();
            isAdvancedTabDisplayed.Should().BeTrue("Advanced tab should be displayed on Main page.");
        }

        [Then(@"Advanced tab is not displayed")]
        public void ThenAdvancedTabIsNotDisplayed()
        {
            bool isAdvancedTabDisplayed = _advancePage.AdvancedTab.GetElementVisibility();
            isAdvancedTabDisplayed.Should().BeFalse("Advanced tab should not be displayed on Main page.");
        }
    }
}
