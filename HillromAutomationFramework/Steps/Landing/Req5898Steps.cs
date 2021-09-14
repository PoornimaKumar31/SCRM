using HillromAutomationFramework.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Landing
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5898")]
    public class LandingPageFooterLinksSteps
    {
        private readonly LoginPage _loginPage;

        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverWait _wait;

        public LandingPageFooterLinksSteps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
        }

        [Given(@"user is on Landing page")]
        public void GivenUserIsOnLandingPage()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
        }
    }
}
