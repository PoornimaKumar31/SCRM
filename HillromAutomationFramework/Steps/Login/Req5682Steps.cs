using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class Req5682Steps
    {
        readonly LoginPage loginPage = new LoginPage();

        // Explicit wait-> Wait till the organization list is displayed
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

        [Given(@"user is on Login page")]
        public void GivenTheUserIsInTheLoginPage()
        {
            PropertyClass.Driver.Navigate().GoToUrl(PropertyClass.BaseURL);  // Launch the Application
            // Explicit wait-> Wait till logo is displayed
            
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(LoginPage.Locator.LogoID)));
        }
        
        [When(@"user enters valid email ID")]
        public void WhenTheUserEntersAValidEmailId()
        {
            loginPage.EmailField.EnterText(Config.EmailIDAdminWithRollUp);
        }
        
        [When(@"enters valid password")]
        public void WhenEntersAValidPassword()
        {
            loginPage.PasswordField.EnterText(Config.PasswordAdminWithRollUp);
        }
        
        [When(@"clicks Login button")]
        public void WhenClicksLoginButton()
        {
            loginPage.LoginButton.Click();
        }

        [When(@"user enters invalid email ID")]
        public void WhenEnterInvalidEmailId()
        {
            loginPage.EmailField.EnterText(Config.InvalidEmailID);
        }

        [When("enters any password")]
        public void WhenEntersAnyPassword()
        {
            loginPage.PasswordField.EnterText(Config.InvalidPassword);
        }

        [When(@"enters invalid password")]
        public void WhenEnterInvalidPassword()
        {
            loginPage.PasswordField.EnterText(Config.InvalidPassword);
        }
        
        [Then(@"user will login successfully")]
        public void ThenUserWillLoginSuccessfully()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(LandingPage.Locator.LNTAutomatedEyeTestOrganizationTitleXPath)));
            string actualTitle = PropertyClass.Driver.Title;
            string expectedTitle = LoginPage.ExpectedValues.LandingPageTitle;
            Assert.AreEqual(expectedTitle, actualTitle,"User is not on the landing page"); //Compare the title
        }
        
        [Then(@"login invalid error message will display")]
        public void ThenUsernameOrPasswordIsInvalidErrorMessageWillDisplay()
        {
            Assert.AreEqual(true, loginPage.ErrorMessage.GetElementVisibility(), "Login invalid error message is not displayed");
            Thread.Sleep(1000);
            String ActualErrortext = loginPage.ErrorMessage.Text;
            String ExpectedErrorText = LoginPage.ExpectedValues.InvalidEntryErrorMessage;
            Assert.AreEqual(ExpectedErrorText, ActualErrortext,"Error message not matches with the expected value"); //Compare the error message displayed.
        }
        
        [Then(@"login authentication error message will display")]
        public void AuthenticationErrorMessageWillDisplay()
        {
            Assert.AreEqual(true, loginPage.ErrorMessage.GetElementVisibility(), "Authentication error message is not displayed");
            String ActualErrortext = loginPage.ErrorMessage.Text;
            String ExpectedErrorText = LoginPage.ExpectedValues.NoEntryErrorMessage;
            Assert.AreEqual(ExpectedErrorText, ActualErrortext,"Authentication error message is not matching with the expected value"); //Compare the error message displayed.
        }

        [When(@"username field is blank")]
        public void WhenUsernameFieldIsBlank()
        {
            Assert.AreEqual(loginPage.EmailField.Text.Length == 0,true,"Username field is not empty");
        }

        [Then(@"username field contains hint text")]
        public void ThenUsernameFieldContainsHintText()
        {
            String ActualhintText = loginPage.EmailField.GetAttribute("placeholder");
            String ExpectedhintText = LoginPage.ExpectedValues.EmailFieldHintText;
            Assert.AreEqual(ExpectedhintText, ActualhintText,"Username field hint text does not match with the expeceted value");
        }

        [When(@"password field is blank")]
        public void WhenPasswordFieldIsBlank()
        {
            Assert.AreEqual(loginPage.PasswordField.Text.Length == 0,true,"Password field is not blank");
        }

        [Then(@"password field contains hint text")]
        public void ThenPasswordFieldContainsHintText()
        {
            String ActualhintText = loginPage.PasswordField.GetAttribute("placeholder");
            String ExpectedhintText = LoginPage.ExpectedValues.PasswordFieldHintText;
            Assert.AreEqual(ExpectedhintText, ActualhintText,"Password field hint text does not match with the expected value");
        }
    }
}
