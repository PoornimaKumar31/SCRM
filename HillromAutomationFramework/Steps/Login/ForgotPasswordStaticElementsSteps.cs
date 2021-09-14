using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.SupportingCode;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding,Scope(Feature = "Forgot Password Static Elements")]
    public class ForgotPasswordStaticElementsSteps
    {
        private readonly ForgotPasswordPage _forgotPassword;

        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverWait _wait;


        public ForgotPasswordStaticElementsSteps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _forgotPassword = new ForgotPasswordPage(driver);
        }


        [Then(@"Hillrom logo is displayed")]
        public void ThenUserWillSeeHillromLogo()
        {
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(ForgotPasswordPage.Locator.HillromLogoID)));
            _forgotPassword.HillromLogo.GetElementVisibility().Should().BeTrue("Hillrom logo is not displayed");
        }

        [Then(@"SmartCare Remote Management title is displayed")]
        public void ThenForgotSmartCareRemoteManagementTitle()
        {
            _forgotPassword.ApplicationTitle.GetElementVisibility().Should().BeTrue(because:"Application title should be displayed in Forgot Password page.");
            _forgotPassword.ApplicationTitle.Text.Should().BeEquivalentTo(ForgotPasswordPage.ExpectedValues.ApplicationTitle, "Application title is not matching with the expected value.");
            //Application subtitle verification
            _forgotPassword.ApplicationSubtitle.GetElementVisibility().Should().BeTrue("Application sub-title is not displayed");
            _forgotPassword.ApplicationSubtitle.Text.Should().BeEquivalentTo(ForgotPasswordPage.ExpectedValues.ApplicationSubTitle, "Application sub-title is not matching with the expected value.");
        }
        
        [Then(@"Reset instructions is displayed")]
        public void ThenResetInstructions()
        {
            _forgotPassword.ResetPasswordInstructions.GetElementVisibility().Should().BeTrue("Reset instructions are not displayed");
            string ExpectedInstructions = ForgotPasswordPage.ExpectedValues.ResetPasswordInstructionsText;
            string ActualInstructions = _forgotPassword.ResetPasswordInstructions.Text;
            ActualInstructions.Should().BeEquivalentTo(ExpectedInstructions,"Reset instructions does not match with the expected text");
        }
    }
}
