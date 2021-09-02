using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.SupportingCode;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;
using FluentAssertions;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class Req5682Steps
    {
        private readonly LoginPage _loginPage;
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

        public Req5682Steps()
        {
            _loginPage = new LoginPage();
        }

 
        [Given(@"user is on Login page")]
        public void GivenTheUserIsInTheLoginPage()
        {
            // Launch the Application
            PropertyClass.Driver.Navigate().GoToUrl(PropertyClass.BaseURL);

            // Wait till logo is displayed
            wait.Until(ExplicitWait.ElementExists(By.Id(LoginPage.Locator.LogoID)));
        }
        
        [When(@"user enters valid email ID")]
        public void WhenTheUserEntersAValidEmailId()
        {
            _loginPage.EmailField.EnterText(Config.EmailIDAdminWithRollUp);
        }
        
        [When(@"enters valid password")]
        public void WhenEntersAValidPassword()
        {
            _loginPage.PasswordField.EnterText(Config.PasswordAdminWithRollUp);
        }
        
        [When(@"clicks Login button")]
        public void WhenClicksLoginButton()
        {
            SetMethods.MoveTotheElement(_loginPage.LoginButton, "Login button");
            _loginPage.LoginButton.Click();
        }

        [When(@"user enters invalid email ID")]
        public void WhenEnterInvalidEmailId()
        {
            _loginPage.EmailField.EnterText(Config.InvalidEmailID);
        }

        [When("enters any password"),When(@"user enters any password")]
        public void WhenEntersAnyPassword()
        {
            _loginPage.PasswordField.EnterText(Config.InvalidPassword);
        }

        [When(@"enters invalid password")]
        public void WhenEnterInvalidPassword()
        {
            _loginPage.PasswordField.EnterText(Config.InvalidPassword);
        }
        
        [Then(@"user will login successfully")]
        public void ThenUserWillLoginSuccessfully()
        {
            wait.Until(ExplicitWait.ElementExists(By.XPath(LandingPage.Locator.LNTAutomatedTestEastOrganizationTitleXPath)));
            string actualTitle = PropertyClass.Driver.Title;
            string expectedTitle = LoginPage.ExpectedValues.LandingPageTitle;

            //Compare the title
            actualTitle.Should().BeEquivalentTo(expectedTitle,"User is not on the landing page"); 
            
        }
        
        [Then(@"login invalid error message will display")]
        public void ThenUsernameOrPasswordIsInvalidErrorMessageWillDisplay()
        {
            _loginPage.ErrorMessage.GetElementVisibility().Should().BeTrue("Login invalid error message is not displayed");
            Thread.Sleep(1000);
            string ActualErrortext = _loginPage.ErrorMessage.Text;
            string ExpectedErrorText = LoginPage.ExpectedValues.InvalidEntryErrorMessage;
            ActualErrortext.Should().BeEquivalentTo(ExpectedErrorText,"Error message not matches with the expected value"); //Compare the error message displayed.
        }
        
        [Then(@"login authentication error message will display")]
        public void AuthenticationErrorMessageWillDisplay()
        {
            _loginPage.ErrorMessage.GetElementVisibility().Should().BeTrue("Authentication error message is not displayed");
            string ActualErrortext = _loginPage.ErrorMessage.Text;
            string ExpectedErrorText = LoginPage.ExpectedValues.NoEntryErrorMessage;
            ActualErrortext.Should().BeEquivalentTo(ExpectedErrorText,"Authentication error message is not matching with the expected value"); //Compare the error message displayed.
        }

        [When(@"username field is blank")]
        public void WhenUsernameFieldIsBlank()
        {
            _loginPage.EmailField.Text.Should().BeNullOrEmpty("Username field is not empty");
        }

        [Then(@"username field contains hint text")]
        public void ThenUsernameFieldContainsHintText()
        {
            string ActualhintText = _loginPage.EmailField.GetAttribute("placeholder");
            string ExpectedhintText = LoginPage.ExpectedValues.EmailFieldHintText;
            ActualhintText.Should().BeEquivalentTo(ExpectedhintText,"Username field hint text does not match with the expeceted value");
        }

        [When(@"password field is blank")]
        public void WhenPasswordFieldIsBlank()
        {
            _loginPage.PasswordField.Text.Should().BeNullOrEmpty("Password field is not blank");
        }

        [Then(@"password field contains hint text")]
        public void ThenPasswordFieldContainsHintText()
        {
            string ActualhintText = _loginPage.PasswordField.GetAttribute("placeholder");
            string ExpectedhintText = LoginPage.ExpectedValues.PasswordFieldHintText;
            ActualhintText.Should().BeEquivalentTo(ExpectedhintText,"Password field hint text does not match with the expected value");
        }

       
        [Then(@"Login button is disabled")]
        public void ThenLoginButtonIsDisabled()
        {
            _loginPage.LoginButton.Enabled.Should().BeFalse("Login Button is enabled");
        }

    }
}
