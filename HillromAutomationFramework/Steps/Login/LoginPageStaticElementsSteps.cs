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
    [Binding,Scope(Feature = "Login page Static Elements")]
    public class LoginPageStaticElementsSteps
    {
        readonly LoginPage loginpage = new LoginPage();

        [Given(@"user is on Login page")]
        public void GivenUserIsOnLoginPage()
        {
            PropertyClass.Driver.Navigate().GoToUrl(PropertyClass.BaseURL);  // Launch the Application
            // Explicit wait-> Wait till logo is displayed
            WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(LoginPage.Locator.LogoID)));
        }

        [Then(@"Hillrom logo is displayed")]
        public void HillromLogoIsDisplayed()
        {
            Thread.Sleep(500);
            Assert.AreEqual(loginpage.LoginPageLogo.Displayed,true,"Hillrom logo is not displayed.\n");
        }

        [Then(@"SmartCare Remote Management title is displayed")]
        public void ThenSmartCareRemoteManagementTitleIsDisplayed()
        {
            Assert.AreEqual(loginpage.ApplicationTitle.Displayed,true,"Smartcare remote mangement title is not displayed\n");
            string ExpectedApplicationText = LoginPage.ExpectedValues.ApplicationTitleText;
            string ActualApplicationText = loginpage.ApplicationTitle.Text;
            Assert.AreEqual(ExpectedApplicationText, ActualApplicationText, "Smartcare remote mangement title is not matching with the expected value");
        }

        [Then(@"login instructions is displayed")]
        public void ThenLoginInstructionsIsDisplayed()
        {
            Assert.AreEqual(loginpage.LoginInstructions.Displayed,true,"Login instructions are not displayed");
            string ExpectedInstructionsText = LoginPage.ExpectedValues.LoginInstructionsText;
            string ActualInstructionsText = loginpage.LoginInstructions.Text;
            Assert.AreEqual(ExpectedInstructionsText, ActualInstructionsText,"Login instructions text is not matching with expected value");
        }

        [Then(@"Ready to Get Started message is displayed")]
        public void ThenReadyToGetStartedMessageIsDisplayed()
        {
            Assert.AreEqual(loginpage.GetStartedTitle.Displayed,true,"Ready to get started title is not displayed");
            string ExpectedGetStartedTitle = LoginPage.ExpectedValues.GetStartedTitleText;
            string ActualGetStartedTitle = loginpage.GetStartedTitle.Text;
            Assert.AreEqual(ExpectedGetStartedTitle, ActualGetStartedTitle,"Ready to get started title text not matches with the expected value");

            Assert.AreEqual(loginpage.GetStartedMessage.Displayed,true, "Ready to get started message is not displayed");
            string ExpectedGetStartedMessage = LoginPage.ExpectedValues.GetStartedMessageText;
            string ActualGetStartedMessage = loginpage.GetStartedMessage.Text;
            Assert.AreEqual(ExpectedGetStartedMessage, ActualGetStartedMessage, "Ready to get started message text not matches with the expected value");

        }

        [Then(@"copyright message is displayed")]
        public void ThenCopyrightMessageIsDisplayed()
        {
            Assert.AreEqual(LoginPage.ExpectedValues.CopyRight, loginpage.CopyRight.Text, "Copyright message is not matching with the expected value.");
            Assert.AreEqual(LoginPage.ExpectedValues.RightsReservedMessage, loginpage.Rights.Text, "Right reserved message is not matching with the expected value");
        }
    }
}