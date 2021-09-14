using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.SupportingCode;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class Req5684Steps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly LoginPage _loginPage;
        private readonly ForgotPasswordPage _forgotPasswordPage;
        private readonly WebDriverWait _wait;

        public Req5684Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(25));
            _loginPage = new LoginPage();
            _forgotPasswordPage = new ForgotPasswordPage();
        }

        [When(@"user clicks forgot password")]
        public void WhenUserClickOnForgotPassword()
        {
            _loginPage.ForgotPasswordLink.Click();
        }

        [Then(@"Forgot Password page is displayed")]
        public void ThenForgotPasswordPageIsDisplayed()
        {
            _forgotPasswordPage.EmailFeild.GetElementVisibility().Should().BeTrue("Forgot password page is not displayed");
            _forgotPasswordPage.SubmitButton.GetElementVisibility().Should().BeTrue("Forgot password page is not displayed");
            _forgotPasswordPage.LoginLink.GetElementVisibility().Should().BeTrue("Forgot password page is not displayed");
        }

        [Given(@"user is on Forgot Password page")]
        public void GivenUserIsOnForgotPasswordPage()
        {
            PropertyClass.Driver.Navigate().GoToUrl(PropertyClass.BaseURL);
            _wait.Until(ExplicitWait.ElementExists(By.Id(LoginPage.Locator.LogoID)));
            _loginPage.ForgotPasswordLink.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(ForgotPasswordPage.Locator.HillromLogoID)));
        }

        [Then(@"Submit button is disabled")]
        public void ThenSubmitButtonIsDisabled()
        {
            _forgotPasswordPage.SubmitButton.Enabled.Should().BeFalse("Submit button is enable");
        }


        [When(@"email field is blank")]
        public void WhenEmailFieldIsBlank()
        {
            Thread.Sleep(500);
            _forgotPasswordPage.EmailFeild.Text.Should().BeNullOrEmpty("Email field is not blank.\n");
        }

        [Then(@"email field contains hint text")]
        public void ThenEmailFieldContainsHintText()
        {
            string ExpectedHintText = ForgotPasswordPage.ExpectedValues.EmailFieldHintText;
            string ActualHintText = _forgotPasswordPage.EmailFeild.GetAttribute("placeholder");
            ActualHintText.Should().BeEquivalentTo(ExpectedHintText,"Email field hint text is not matching with expected value.\n");
        }

        [When(@"user enters invalid email address")]
        public void WhenEnterInvalidEmailInForgotPasswordPage()
        {
            _forgotPasswordPage.EmailFeild.EnterText(Config.InvalidFormatEmailID);
        }

        [When(@"user clicks Submit button")]
        public void Whenclickonsubmitbutton()
        {
            _forgotPasswordPage.SubmitButton.Click();
        }

        [Then(@"forgot invalid error message is displayed")]
        public void ThenForgotInvalidErrorMessageIsDisplayed()
        {
            _forgotPasswordPage.InvalidEmailErrorMessage.GetElementVisibility().Should().BeTrue("Error message should be displayed when user enters invalid format email.");
            (_forgotPasswordPage.InvalidEmailErrorMessage.Text).Should().BeEquivalentTo(ForgotPasswordPage.ExpectedValues.InvalidEmailErrorMessageText, because:"Error message text should match the expected value.");
        }


        [When(@"user enters valid email address")]
        public void WhenUserEntersValidEmailAddress()
        {
            _forgotPasswordPage.EmailFeild.EnterText(Config.EmailIDAdminWithRollUp);
        }

        [Then(@"Login page is displayed")]
        public void ThenLoginPageIsDisplayed()
        {
            bool IsLoginPageDisplayed = (_loginPage.EmailField.GetElementVisibility()) || (_loginPage.PasswordField.GetElementVisibility()) || (_loginPage.ForgotPasswordLink.GetElementVisibility());
            IsLoginPageDisplayed.Should().BeTrue(because:"Login page should be displayed when user cliks logout button in Roll up page.");
        }

        [Then(@"notification message is displayed")]
        public void ThenNotificationMessageIsDisplayed()
        {
            _loginPage.ForgetPasswordSuccessMessage.GetElementVisibility().Should().BeTrue("Notification message is not displayed.\n");
        }

        [Then(@"notification message disappears after a few seconds")]
        public void ThenNotificationMessageDisappearsAfterAFewSeconds()
        {
            Thread.Sleep(10000);
            _loginPage.ForgetPasswordSuccessMessage.GetElementVisibility().Should().BeFalse("Notification message is not disappear.\n");
        }

        [When(@"user clicks Login")]
        public void WhenUserClicksLogin()
        {
            _forgotPasswordPage.LoginLink.Click();
        }
    }
}
