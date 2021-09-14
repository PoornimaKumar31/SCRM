using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.SupportingCode;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class Req5678Steps
    {
        private readonly LoginPage _loginPage;

        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverWait _wait;

        public Req5678Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
        }

        [Then(@"Version Number is displayed")]
        public void ThenVersionNumberIsDisplayed()
        {
            string ActualVersionNoDisplayed = _loginPage.VersionNumber.Text.Trim();
            string ExpectedText = PropertyClass.VersionNumber.Trim();
            //Verifying the version no is displayed
            _loginPage.VersionNumber.GetElementVisibility().Should().BeTrue("Version no is not displayed\n");
            //Verifying the version no displayed is correct
            ActualVersionNoDisplayed.Should().BeEquivalentTo(ExpectedText, "The app" + ExpectedText + " is not Matching\n");
        }
    }
}