using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using HillromAutomationFramework.Hooks;
using NUnit.Framework;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class LoginFunctionalitySteps
    {
        LoginPage loginPage = new LoginPage();
        [Given(@"user is in login page")]
        public void GivenTheUserIsInTheLoginPage()
        {
            PropertyClass.Driver.Navigate().GoToUrl(PropertyClass.readConfig.BaseURL);  // Launch the Application
            PropertyClass.Driver.Manage().Window.Maximize(); // Maximize the window
            PropertyClass.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60); // Implicit wait for 60 seconds
            // Explicit wait-> Wait till logo is displayed
            WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(LoginPage.Locator.LogoXPath)));
        }
        
        [When(@"user enters a valid email id")]
        public void WhenTheUserEntersAValidEmailId()
        {
            loginPage.EmailField.enterText(PropertyClass.readConfig.validEmailID);
            Hooks.Hooks1.CaptureNow(); //Take a screenshot
        }
        
        [When(@"enters a valid password")]
        public void WhenEntersAValidPassword()
        {
            loginPage.PasswordField.enterText(PropertyClass.readConfig.validPassword);
        }
        
        [When(@"click on login button")]
        public void WhenClickOnLoginButton()
        {
            loginPage.LoginButton.Clicks();
        }
        
        [When(@"enter invalid email id")]
        public void WhenEnterInvalidEmailId()
        {
            loginPage.EmailField.enterText(PropertyClass.readConfig.invalidEmailID);
            Hooks.Hooks1.CaptureNow(); //Take screenshot
        }
        
        [When(@"enter invalid password")]
        public void WhenEnterInvalidPassword()
        {
            loginPage.PasswordField.enterText(PropertyClass.readConfig.invalidPassword);
        }
        
        [Then(@"user will login successfully")]
        public void ThenUserWillLoginSuccessfully()
        {
            // Explicit wait-> Wait till the organization list is displayed
            WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(LoginPage.Locator.LandingPageTileXPath)));
            string actualTitle = PropertyClass.Driver.Title;
            string expectedTitle = LoginPage.ExpectedValues.LandingPageTitle;
            Hooks.Hooks1.CaptureNow(); //Take screenshot
            Assert.AreEqual(expectedTitle, actualTitle); //Compare the title
        }
        
        [Then(@"username or password is invalid error message will display")]
        public void ThenUsernameOrPasswordIsInvalidErrorMessageWillDisplay()
        {
            String ActualErrortext = loginPage.ErrorMessage.Text;
            String ExpectedErrorText = LoginPage.ExpectedValues.InvalidEntryErrorMessage;
            Hooks.Hooks1.CaptureNow(); //Take screenshot
            Assert.AreEqual(ExpectedErrorText, ActualErrortext); //Compare the error message displayed.
        }
        
        [Then(@"authentication error message will display")]
        public void AuthenticationErrorMessageWillDisplay()
        {
            String ActualErrortext = loginPage.ErrorMessage.Text;
            String ExpectedErrorText = LoginPage.ExpectedValues.NoEntryErrorMessage;
            Hooks.Hooks1.CaptureNow(); //Take screenshot
            Assert.AreEqual(ExpectedErrorText, ActualErrortext); //Compare the error message displayed.
        }
    }
}
