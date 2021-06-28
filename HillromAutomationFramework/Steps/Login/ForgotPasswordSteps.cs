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
    public class ForgotPasswordSteps
    {
        private readonly ScenarioContext _scenarioContext;
        readonly LoginPage loginPage = new LoginPage();
        readonly ForgotPasswordPage forgotPasswordPage = new ForgotPasswordPage();

        public ForgotPasswordSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }



        [When(@"user clicks forgot password")]
        public void WhenUserClickOnForgotPassword()
        {
            loginPage.ForgotPasswordLink.Clicks();
        }

        [Then(@"Forgot Password page is displayed")]
        public void ThenForgotPasswordPageIsDisplayed()
        {
            Assert.IsTrue(forgotPasswordPage.EmailFeild.Displayed);
            Assert.IsTrue(forgotPasswordPage.SubmitButton.Displayed);
            Assert.IsTrue(forgotPasswordPage.LoginButton.Displayed);
        }

        [Given(@"user is on Forgot Password page")]
        public void GivenUserIsOnForgotPasswordPage()
        {
            PropertyClass.Driver.Navigate().GoToUrl(PropertyClass.BaseURL);
            loginPage.ForgotPasswordLink.Click();
            //Wait till forgot password apge is displayed
            WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(ForgotPasswordPage.Locator.HillromLogoXpath)));
        }

        [When(@"email field is blank")]
        public void WhenEmailFieldIsBlank()
        {
            Assert.IsTrue(forgotPasswordPage.EmailFeild.Text.Length == 0);
        }

        [Then(@"email field contains hint text")]
        public void ThenEmailFieldContainsHintText()
        {
            string ExpectedHintText = ForgotPasswordPage.ExpectedValues.EmailFieldHintText;
            String ActualHintText = forgotPasswordPage.EmailFeild.GetAttribute("placeholder").ToString();
            Assert.AreEqual(ExpectedHintText, ActualHintText);
        }

        [When(@"user enters invalid email address")]
        public void WhenEnterInvalidEmailInForgotPasswordPage()
        {
            forgotPasswordPage.EmailFeild.EnterText(PropertyClass.readConfig.InvalidEmailID);
        }

        [When(@"user clicks Submit button")]
        public void whenclickonsubmitbutton()
        {
            forgotPasswordPage.SubmitButton.Click();
        }

        [Then(@"forgot invalid error message is displayed")]
        public void ThenForgotInvalidErrorMessageIsDisplayed()
        {
            _scenarioContext.Pending();
        }


        [When(@"user enters valid email address")]
        public void WhenUserEntersValidEmailAddress()
        {
            forgotPasswordPage.EmailFeild.EnterText(PropertyClass.readConfig.ValidEmailID);
        }

        [Then(@"Login page is displayed")]
        public void ThenLoginPageIsDisplayed()
        {
            Assert.IsTrue(loginPage.EmailField.Displayed);
            Assert.IsTrue(loginPage.PasswordField.Displayed);
            Assert.IsTrue(loginPage.ForgotPasswordLink.Displayed);
        }

        [Then(@"notification message is displayed")]
        public void ThenNotificationMessageIsDisplayed()
        {
            Assert.IsTrue(loginPage.ForgetPasswordSuccessMessage.Displayed);
        }

        [Then(@"notification message disappears after a few seconds")]
        public void ThenNotificationMessageDisappearsAfterAFewSeconds()
        {
            Thread.Sleep(10000);
            Assert.IsFalse(loginPage.ForgetPasswordSuccessMessage.Displayed);
        }

        [When(@"user clicks Login")]
        public void WhenUserClicksLogin()
        {
            forgotPasswordPage.LoginButton.Click();
        }
    }
}
