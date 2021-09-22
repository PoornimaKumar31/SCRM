using HillromAutomationFramework.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class Req5898Steps
    {
        private readonly LoginPage _loginPage;

        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverWait _wait;

        public Req5898Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
        }

        [When(@"user clicks Privacy Policy")]
        public void WhenUserClicksPrivacyPolicy()
        {
            _loginPage.PrivacyPolicylink.Click();
        }

        [When(@"user clicks Terms of Use")]
        public void WhenUserClicksTermsOfUse()
        {
            _loginPage.TermsOfUseLink.Click();
        }
    }
}
