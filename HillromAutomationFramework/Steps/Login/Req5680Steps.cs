using HillromAutomationFramework.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{

    [Binding]
    public class Req5680Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;

        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverWait _wait;

        public Req5680Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
        }

        [Given(@"user is logged in")]
        public void GivenUserIsLoggedIn()
        {
            //Log in as Admin user with rollup
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
        }

        [When(@"user clicks Logout button")]
        public void WhenUserClicksLogoutButton()
        {
            //Clicks on profile logo
            _landingPage.UserNameLogo.Click();
            //Clicks on logout button
            _landingPage.LogOutButton.Click();
        }
    }
}
