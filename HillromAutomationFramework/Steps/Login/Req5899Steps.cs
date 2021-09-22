using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.LoginPageObject;
using HillromAutomationFramework.SupportingCode;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5899")]
    public class Req5899Steps
    {
        private readonly LoginPage _loginPage;

        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverWait _wait;

        public Req5899Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            _loginPage = new LoginPage(driver);
        }


        [When(@"user clicks Supported Browsers")]
        public void WhenUserClicksSupportedBrowsers()
        {
            _loginPage.SupportedBrowsersLink.Click();
        }

        [Then(@"Supported Browsers dialog is displayed")]
        public void ThenSupportedBrowsersDialogIsDisplayed()
        {
            _loginPage.SupportedBrowserPopup.GetElementVisibility().Should().BeTrue("Supported browser dialog box is not displayed");
            string SupportedBrowserList = _loginPage.SupportedBrowserPopup.Text;
            
            // Microsoft Edge
            SupportedBrowserList.Contains(LoginPageExpectedValue.SupportedBrowserEdge).Should().BeTrue("Microsoft Edge Supported Browser text does not match with the expected value");
            
            // Google Chrome
            SupportedBrowserList.Contains(LoginPageExpectedValue.SupportedBrowserChrome).Should().BeTrue("Google Chrome Supported Browser text does not match with the expected value");
            
            //Apple Safari
            SupportedBrowserList.Contains(LoginPageExpectedValue.SupportedBrowserAppleSafari).Should().BeTrue("Apple Safari Supported Browser text does not match with the expected value");
        }



        [Given(@"user is on Supported Browsers dialog")]
        public void GivenUserIsOnSupportedBrowsersDialog()
        {
            _driver.Navigate().GoToUrl(PropertyClass.BaseURL);
            
            //Wait till logo is displayed
            _wait.Until(ExplicitWait.ElementExists(By.Id(LoginPage.Locator.LogoID)));
            
            _loginPage.SupportedBrowsersLink.Click();
            
            _loginPage.SupportedBrowserPopup.GetElementVisibility().Should().BeTrue("Supported browser dialog ox is not displayed");
        }

        [When(@"user clicks Close button")]
        public void WhenUserClicksCloseButton()
        {
            _loginPage.SupportedBrowserclosebutton.Click();
        }

        [Then(@"Supported Browsers dialog is closed")]
        public void ThenSupportedBrowsersDialogIsClosed()
        {
            _loginPage.SupportedBrowserPopup.GetElementVisibility().Should().BeFalse("Supported browser dialog box is not closed");
        }

    }
}
