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
    public class LogoutSteps
    {
        readonly LoginPage loginPage=new LoginPage();

        [Given(@"user is logged in")]
        public void GivenUserIsLoggedIn()
        {
            PropertyClass.Driver.Navigate().GoToUrl(PropertyClass.BaseURL);
            loginPage.EmailField.EnterText(PropertyClass.readConfig.ValidEmailID);
            loginPage.PasswordField.EnterText(PropertyClass.readConfig.ValidPassword);
            loginPage.LoginButton.Click();
            // Wait till User logo is displayed
            WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(LoginPage.Locator.LandingPageUserNameLogoXpath)));
        }

        [When(@"user clicks Logout button")]
        public void WhenUserClicksLogoutButton()
        {
            //Clicks on profile logo
            loginPage.LandingPageUserNameLogo.Clicks();
            //Clicks on logout button
            loginPage.LandingPageLogOutButton.Clicks();
        }
    }
}
