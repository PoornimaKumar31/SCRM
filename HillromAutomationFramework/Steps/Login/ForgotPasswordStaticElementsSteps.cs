using HillromAutomationFramework.Coding.PageObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class ForgotPasswordStaticElementsSteps
    {
        ForgotPasswordPage forgotPassword = new ForgotPasswordPage();

        [Then(@"user will see forgot Hillrom logo")]
        public void ThenUserWillSeeForgotHillromLogo()
        {
            Assert.IsTrue(forgotPassword.HillromLogo.Displayed);
        }
        
        [Then(@"forgot SmartCare Remote Management title")]
        public void ThenForgotSmartCareRemoteManagementTitle()
        {
            Assert.IsTrue(forgotPassword.ApplicationTitle.Displayed);
        }
        
        [Then(@"reset instructions")]
        public void ThenResetInstructions()
        {
            Assert.IsTrue(forgotPassword.ResetPasswordInstructions.Displayed);
            string ExpectedInstructions = ForgotPasswordPage.ExpectedValues.ResetPasswordInstructionsText;
            string ActualInstructions = forgotPassword.ResetPasswordInstructions.Text;
            Assert.AreEqual(ExpectedInstructions, ActualInstructions);
        }
    }
}
