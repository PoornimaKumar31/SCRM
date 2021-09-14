using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding,Scope(Feature = "Forgot Password Static Elements")]
    public class ForgotPasswordStaticElementsSteps
    {
        readonly ForgotPasswordPage _forgotPassword;

        public ForgotPasswordStaticElementsSteps()
        {
            _forgotPassword = new ForgotPasswordPage();
        }

        [Then(@"Hillrom logo is displayed")]
        public void ThenUserWillSeeHillromLogo()
        {
            Thread.Sleep(500);
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
