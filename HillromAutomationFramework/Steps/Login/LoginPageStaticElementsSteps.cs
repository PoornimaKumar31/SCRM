using FluentAssertions;
using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding,Scope(Feature = "Login page Static Elements")]
    public class LoginPageStaticElementsSteps
    {
        readonly LoginPage _loginpage;
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

        public LoginPageStaticElementsSteps()
        {
            _loginpage = new LoginPage();
        }

        [Given(@"user is on Login page")]
        public void GivenUserIsOnLoginPage()
        {
            // Launch the Application
            PropertyClass.Driver.Navigate().GoToUrl(PropertyClass.BaseURL); 

            // Explicit wait-> Wait till logo is displayed
            wait.Until(ExplicitWait.ElementExists(By.Id(LoginPage.Locator.LogoID)));
        }

        [Then(@"Hillrom logo is displayed")]
        public void HillromLogoIsDisplayed()
        {
            Thread.Sleep(500);
            _loginpage.LoginPageLogo.GetElementVisibility().Should().BeTrue("Hillrom logo is not displayed.\n");
        }

        [Then(@"SmartCare Remote Management title is displayed")]
        public void ThenSmartCareRemoteManagementTitleIsDisplayed()
        {
            _loginpage.ApplicationTitle.GetElementVisibility().Should().BeTrue("Smartcare remote mangement title is not displayed\n");
            string ExpectedApplicationText = LoginPage.ExpectedValues.ApplicationTitleText;
            string ActualApplicationText = _loginpage.ApplicationTitle.Text;
            ActualApplicationText.Should().BeEquivalentTo(ExpectedApplicationText, "Smartcare remote mangement title is not matching with the expected value");
        }

        [Then(@"login instructions is displayed")]
        public void ThenLoginInstructionsIsDisplayed()
        {
            _loginpage.LoginInstructions.GetElementVisibility().Should().BeTrue("Login instructions are not displayed");
            string ExpectedInstructionsText = LoginPage.ExpectedValues.LoginInstructionsText;
            string ActualInstructionsText = _loginpage.LoginInstructions.Text;
            ActualInstructionsText.Should().BeEquivalentTo(ExpectedInstructionsText,"Login instructions text is not matching with expected value");
        }

        [Then(@"Ready to Get Started message is displayed")]
        public void ThenReadyToGetStartedMessageIsDisplayed()
        {
            _loginpage.GetStartedTitle.GetElementVisibility().Should().BeTrue("Ready to get started title is not displayed");
            string ExpectedGetStartedTitle = LoginPage.ExpectedValues.GetStartedTitleText;
            string ActualGetStartedTitle = _loginpage.GetStartedTitle.Text;
            Assert.AreEqual(ExpectedGetStartedTitle, ActualGetStartedTitle,"Ready to get started title text not matches with the expected value");

            _loginpage.GetStartedMessage.GetElementVisibility().Should().BeTrue("Ready to get started message is not displayed");
            string ExpectedGetStartedMessage = LoginPage.ExpectedValues.GetStartedMessageText;
            string ActualGetStartedMessage = _loginpage.GetStartedMessage.Text;
            ActualGetStartedMessage.Should().BeEquivalentTo(ExpectedGetStartedMessage, "Ready to get started message text not matches with the expected value");

        }

        [Then(@"copyright message is displayed")]
        public void ThenCopyrightMessageIsDisplayed()
        {
            _loginpage.CopyRight.Text.Should().BeEquivalentTo(LoginPage.ExpectedValues.CopyRight, "Copyright message is not matching with the expected value.");
            _loginpage.Rights.Text.Should().BeEquivalentTo(LoginPage.ExpectedValues.RightsReservedMessage, "Right reserved message is not matching with the expected value");
        }
    }
}