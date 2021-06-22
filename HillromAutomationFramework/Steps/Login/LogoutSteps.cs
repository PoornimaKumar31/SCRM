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
        [When(@"user enters a valid email id and password")]
        public void WhenUserEntersAValidEmailIdAndPassword()
        {
            loginPage.EmailField.EnterText(PropertyClass.readConfig.ValidEmailID);
            loginPage.PasswordField.EnterText(PropertyClass.readConfig.ValidPassword);
        }


        [When(@"click on profile icon")]
        public void WhenClickOnProfileIcon()
        {
            // Wait till User logo is displayed
            WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(LoginPage.Locator.LandingPageUserNameLogoXpath)));
            loginPage.LandingPageUserNameLogo.Clicks();
        }


        [When(@"click on logout button")]
        public void WhenClickOnLogoutButton()
        {
            loginPage.LandingPageLogOutButton.Clicks();
        }
        
        [Then(@"user will logout successfully")]
        public void ThenUserWillLogoutSuccessfully()
        {
            // Verifying in the login page
            Assert.IsTrue(loginPage.EmailField.Displayed);
            Assert.IsTrue(loginPage.PasswordField.Displayed);
            Assert.IsTrue(loginPage.LoginButton.Displayed);
        }
    }
}
