using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class Req5684Steps
    {
        private readonly ScenarioContext _scenarioContext;
        readonly LoginPage loginPage = new LoginPage();
        readonly ForgotPasswordPage forgotPasswordPage = new ForgotPasswordPage();

        public Req5684Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"user clicks forgot password")]
        public void WhenUserClickOnForgotPassword()
        {
            loginPage.ForgotPasswordLink.Click();
        }

        [Then(@"Forgot Password page is displayed")]
        public void ThenForgotPasswordPageIsDisplayed()
        {
            Assert.AreEqual(forgotPasswordPage.EmailFeild.Displayed,true,"Forgot password page is not displayed");
            Assert.AreEqual(forgotPasswordPage.SubmitButton.Displayed,true, "Forgot password page is not displayed");
            Assert.AreEqual(forgotPasswordPage.LoginLink.Displayed,true, "Forgot password page is not displayed");
        }

        [Given(@"user is on Forgot Password page")]
        public void GivenUserIsOnForgotPasswordPage()
        {
            PropertyClass.Driver.Navigate().GoToUrl(PropertyClass.BaseURL);
            WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(LoginPage.Locator.LogoID)));
            loginPage.ForgotPasswordLink.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(ForgotPasswordPage.Locator.HillromLogoID)));
        }

        [When(@"email field is blank")]
        public void WhenEmailFieldIsBlank()
        {
            Thread.Sleep(500);
            Assert.AreEqual(forgotPasswordPage.EmailFeild.Text.Length == 0,true,"Email field is not blank.\n");
        }

        [Then(@"email field contains hint text")]
        public void ThenEmailFieldContainsHintText()
        {
            string ExpectedHintText = ForgotPasswordPage.ExpectedValues.EmailFieldHintText;
            string ActualHintText = forgotPasswordPage.EmailFeild.GetAttribute("placeholder");
            Assert.AreEqual(ExpectedHintText, ActualHintText,"Email field hint text is not matching with expected value.\n");
        }

        [When(@"user enters invalid email address")]
        public void WhenEnterInvalidEmailInForgotPasswordPage()
        {
            forgotPasswordPage.EmailFeild.EnterText(Config.InvalidEmailID);
        }

        [When(@"user clicks Submit button")]
        public void Whenclickonsubmitbutton()
        {
            forgotPasswordPage.SubmitButton.Click();
        }

        [Then(@"forgot invalid error message is displayed")]
        public void ThenForgotInvalidErrorMessageIsDisplayed()
        {
            //id is missing
            _scenarioContext.Pending();
        }


        [When(@"user enters valid email address")]
        public void WhenUserEntersValidEmailAddress()
        {
            forgotPasswordPage.EmailFeild.EnterText(Config.EmailIDAdminWithRollUp);
        }

        [Then(@"Login page is displayed")]
        public void ThenLoginPageIsDisplayed()
        {
            Assert.AreEqual(loginPage.EmailField.Displayed,true,"Login page is not displayed.\n");
            Assert.AreEqual(loginPage.PasswordField.Displayed,true, "Login page is not displayed.\n");
            Assert.AreEqual(loginPage.ForgotPasswordLink.Displayed,true, "Login page is not displayed..\n");
        }

        [Then(@"notification message is displayed")]
        public void ThenNotificationMessageIsDisplayed()
        {
            Assert.AreEqual(loginPage.ForgetPasswordSuccessMessage.Displayed,true,"Notification message is not displayed.\n");
        }

        [Then(@"notification message disappears after a few seconds")]
        public void ThenNotificationMessageDisappearsAfterAFewSeconds()
        {
            Thread.Sleep(10000);
            Assert.AreEqual(loginPage.ForgetPasswordSuccessMessage.Displayed,false, "Notification message is not disappear.\n");
        }

        [When(@"user clicks Login")]
        public void WhenUserClicksLogin()
        {
            forgotPasswordPage.LoginLink.Click();
        }
    }
}
