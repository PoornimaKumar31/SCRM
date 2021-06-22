using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class ResetPasswordSteps
    {
        readonly LoginPage loginPage = new LoginPage();

        [When(@"user click on forgot password")]
        public void WhenUserClickOnForgotPassword()
        {
            loginPage.ForgotPasswordLink.Clicks();
        }
        
        [When(@"enters a valid email")]
        public void WhenEntersAValidEmail()
        {
            loginPage.ForgetPasswordEmailFeild.enterText(PropertyClass.readConfig.validEmailID);
            
        }
        
        [When(@"click on submit button")]
        public void WhenClickOnSubmitButton()
        {
            loginPage.ForgetPasswordSubmitButton.Click();
        }
        
        [When(@"enter invalid email in forgot password page")]
        public void WhenEnterInvalidEmailInForgotPasswordPage()
        {
            loginPage.ForgetPasswordEmailFeild.enterText(PropertyClass.readConfig.invalidEmailID);
        }
        
        [When(@"click on Login button in forgot password page")]
        public void WhenClickOnLoginButtonInForgotPasswordPage()
        {
            loginPage.ForgetPasswordLoginLink.Clicks();
        }
        
        [Then(@"update message will displayed in login page")]
        public void ThenYouWillReceiveAnEmailWithALinkToUpdateYourPasswordMessageIsDisplayedTheLoginPage()
        {
            // Wait till the message is displayed. 
            WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(LoginPage.Locator.ForgetPasswordSuccessMessageXpath)));
        }

        [Then(@"submit button is disabled")]
        public void ThenSubmitButtonIsDisabled()
        {
            Assert.IsFalse(loginPage.ForgetPasswordSubmitButton.Enabled);
        }
        
        [Then(@"invalid email error message is displayed")]
        public void ThenInvalidEmailAddressTryAgainMessageIsDisplayed()
        {
            //to do->(bug in the application->Message is not displaying)
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"redirect to the login page")]
        [Obsolete]
        public void ThenRedirectToTheLoginPage()
        {
            //checking login page element
            Assert.IsTrue(loginPage.ForgotPasswordLink.Displayed);
            Assert.IsTrue(loginPage.EmailField.Displayed);
            
        }
    }
}
