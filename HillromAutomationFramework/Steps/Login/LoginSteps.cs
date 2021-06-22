using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class LoginSteps
    {
        readonly LoginPage loginPage = new LoginPage();
        [Given(@"user is in login page")]
        public void GivenTheUserIsInTheLoginPage()
        {
            PropertyClass.Driver.Navigate().GoToUrl(PropertyClass.BaseURL);  // Launch the Application
            PropertyClass.Driver.Manage().Window.Maximize(); // Maximize the window
            PropertyClass.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60); // Implicit wait for 60 seconds
            // Explicit wait-> Wait till logo is displayed
            WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(LoginPage.Locator.LogoXPath)));
        }
        
        [When(@"user enters a valid email id")]
        public void WhenTheUserEntersAValidEmailId()
        {
            loginPage.EmailField.EnterText(PropertyClass.readConfig.ValidEmailID);
        }
        
        [When(@"enters a valid password")]
        public void WhenEntersAValidPassword()
        {
            loginPage.PasswordField.EnterText(PropertyClass.readConfig.ValidPassword);
        }
        
        [When(@"click on login button")]
        public void WhenClickOnLoginButton()
        {
            loginPage.LoginButton.Clicks();
        }
        
        [When(@"enter invalid email id")]
        public void WhenEnterInvalidEmailId()
        {
            loginPage.EmailField.EnterText(PropertyClass.readConfig.InvalidEmailID);
            
        }
        
        [When(@"enter invalid password")]
        public void WhenEnterInvalidPassword()
        {
            loginPage.PasswordField.EnterText(PropertyClass.readConfig.InvalidPassword);
        }
        
        [Then(@"user will login successfully")]
        public void ThenUserWillLoginSuccessfully()
        {
            // Explicit wait-> Wait till the organization list is displayed
            WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(LoginPage.Locator.LandingPageTileXPath)));
            string actualTitle = PropertyClass.Driver.Title;
            string expectedTitle = LoginPage.ExpectedValues.LandingPageTitle;
            Assert.AreEqual(expectedTitle, actualTitle); //Compare the title
        }
        
        [Then(@"username or password is invalid error message will display")]
        public void ThenUsernameOrPasswordIsInvalidErrorMessageWillDisplay()
        {
            String ActualErrortext = loginPage.ErrorMessage.Text;
            String ExpectedErrorText = LoginPage.ExpectedValues.InvalidEntryErrorMessage;
            Assert.AreEqual(ExpectedErrorText, ActualErrortext); //Compare the error message displayed.
        }
        
        [Then(@"authentication error message will display")]
        public void AuthenticationErrorMessageWillDisplay()
        {
            String ActualErrortext = loginPage.ErrorMessage.Text;
            String ExpectedErrorText = LoginPage.ExpectedValues.NoEntryErrorMessage;
            Assert.AreEqual(ExpectedErrorText, ActualErrortext); //Compare the error message displayed.
        }
    }
}
