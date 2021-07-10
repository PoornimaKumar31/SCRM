using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class ForgotPasswordStaticElementsSteps
    {
        readonly ForgotPasswordPage forgotPassword = new ForgotPasswordPage();

        [Then(@"user will see forgot Hillrom logo")]
        public void ThenUserWillSeeForgotHillromLogo()
        {
            Thread.Sleep(500);
            Assert.AreEqual(forgotPassword.HillromLogo.GetElementVisibility(),true,"Hillrom logo is not displayed");
        }
        
        [Then(@"forgot SmartCare Remote Management title")]
        public void ThenForgotSmartCareRemoteManagementTitle()
        {
            Assert.AreEqual(forgotPassword.ApplicationTitle.GetElementVisibility(),true,"Smartcare remote management title is not displayed");
        }
        
        [Then(@"reset instructions")]
        public void ThenResetInstructions()
        {
            Assert.AreEqual(forgotPassword.ResetPasswordInstructions.GetElementVisibility(),true,"Reset instructions are not displayed");
            string ExpectedInstructions = ForgotPasswordPage.ExpectedValues.ResetPasswordInstructionsText;
            string ActualInstructions = forgotPassword.ResetPasswordInstructions.Text;
            Assert.AreEqual(ExpectedInstructions, ActualInstructions,"Reset instructions does not match with the expected text");
        }
    }
}
