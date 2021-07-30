using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding,Scope(Feature = "Forgot Password Static Elements")]
    public class ForgotPasswordStaticElementsSteps
    {
        readonly ForgotPasswordPage forgotPassword = new ForgotPasswordPage();

        [Then(@"Hillrom logo is displayed")]
        public void ThenUserWillSeeHillromLogo()
        {
            Thread.Sleep(500);
            Assert.AreEqual(forgotPassword.HillromLogo.GetElementVisibility(),true,"Hillrom logo is not displayed");
        }
        
        [Then(@"SmartCare Remote Management title is displayed")]
        public void ThenForgotSmartCareRemoteManagementTitle()
        {
            Assert.AreEqual(forgotPassword.ApplicationTitle.GetElementVisibility(),true,"Application title is not displayed");
            Assert.AreEqual(ForgotPasswordPage.ExpectedValues.ApplicationTitle, forgotPassword.ApplicationTitle.Text, "Application title is not matching with the expected value.");
            //Application subtitle verification
            Assert.AreEqual(forgotPassword.ApplicationSubtitle.GetElementVisibility(), true, "Application sub-title is not displayed");
            Assert.AreEqual(ForgotPasswordPage.ExpectedValues.ApplicationSubTitle, forgotPassword.ApplicationSubtitle.Text, "Application sub-title is not matching with the expected value.");
        }
        
        [Then(@"Reset instructions is displayed")]
        public void ThenResetInstructions()
        {
            Assert.AreEqual(forgotPassword.ResetPasswordInstructions.GetElementVisibility(),true,"Reset instructions are not displayed");
            string ExpectedInstructions = ForgotPasswordPage.ExpectedValues.ResetPasswordInstructionsText;
            string ActualInstructions = forgotPassword.ResetPasswordInstructions.Text;
            Assert.AreEqual(ExpectedInstructions, ActualInstructions,"Reset instructions does not match with the expected text");
        }
    }
}
