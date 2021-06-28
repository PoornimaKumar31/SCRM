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
        [Given(@"user is on Login page")]
        public void GivenTheUserIsInTheLoginPage()
        {
            PropertyClass.Driver.Navigate().GoToUrl(PropertyClass.BaseURL);  // Launch the Application
            // Explicit wait-> Wait till logo is displayed
            WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(LoginPage.Locator.LogoXPath)));
        }
        
        [When(@"user enters valid email ID")]
        public void WhenTheUserEntersAValidEmailId()
        {
            loginPage.EmailField.EnterText(PropertyClass.readConfig.ValidEmailID);
        }
        
        [When(@"enters valid password")]
        public void WhenEntersAValidPassword()
        {
            loginPage.PasswordField.EnterText(PropertyClass.readConfig.ValidPassword);
        }
        
        [When(@"(.*)clicks Login button")]
        public void WhenUserClicksLoginButton()
        {
            loginPage.LoginButton.Clicks();
        }

        [When(@"user enters invalid email ID")]
        public void WhenEnterInvalidEmailId()
        {
            loginPage.EmailField.EnterText(PropertyClass.readConfig.InvalidEmailID);
        }

        [When(@"(.*)enters any password")]
        public void WhenEntersAnyPassword()
        {
            loginPage.PasswordField.EnterText(PropertyClass.readConfig.InvalidPassword);
        }

        [When(@"enters invalid password")]
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
        
        [Then(@"login invalid error message will display")]
        public void ThenUsernameOrPasswordIsInvalidErrorMessageWillDisplay()
        {
            Assert.IsTrue(loginPage.ErrorMessage.Displayed);
            String ActualErrortext = loginPage.ErrorMessage.Text;
            String ExpectedErrorText = LoginPage.ExpectedValues.InvalidEntryErrorMessage;
            Assert.AreEqual(ExpectedErrorText, ActualErrortext); //Compare the error message displayed.
        }
        
        [Then(@"login authentication error message will display")]
        public void AuthenticationErrorMessageWillDisplay()
        {
            String ActualErrortext = loginPage.ErrorMessage.Text;
            String ExpectedErrorText = LoginPage.ExpectedValues.NoEntryErrorMessage;
            Assert.AreEqual(ExpectedErrorText, ActualErrortext); //Compare the error message displayed.
        }

        [When(@"username field is blank")]
        public void WhenUsernameFieldIsBlank()
        {
            Assert.IsTrue(loginPage.EmailField.Text.Length == 0);
        }

        [Then(@"username field contains hint text")]
        public void ThenUsernameFieldContainsHintText()
        {
            String ActualhintText = loginPage.EmailField.GetAttribute("placeholder");
            String ExpectedhintText = LoginPage.ExpectedValues.EmailFieldHintText;
            Assert.AreEqual(ExpectedhintText, ActualhintText);
        }

        [When(@"password field is blank")]
        public void WhenPasswordFieldIsBlank()
        {
            Assert.IsTrue(loginPage.PasswordField.Text.Length == 0);
        }

        [Then(@"password field contains hint text")]
        public void ThenPasswordFieldContainsHintText()
        {
            String ActualhintText = loginPage.PasswordField.GetAttribute("placeholder");
            String ExpectedhintText = LoginPage.ExpectedValues.PasswordFieldHintText;
            Assert.AreEqual(ExpectedhintText, ActualhintText);
        }
    }
}
