using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class LoginPageStaticElementsSteps
    {
        readonly LoginPage loginpage = new LoginPage();

        [Then(@"user will see login Hillrom logo")]
        public void ThenUserWillSeeLoginHillromLogo()
        {
            Thread.Sleep(500);
            Assert.AreEqual(loginpage.LoginPageLogo.Displayed,true,"Hillrom logo is not displayed.\n");
        }

        [Then(@"login SmartCare Remote Management title")]
        public void ThenLoginSmartCareRemoteManagementTitle()
        {
            Assert.AreEqual(loginpage.ApplicationTitle.Displayed,true,"Smartcare remote mangement title is not displayed\n");
            string ExpectedApplicationText = LoginPage.ExpectedValues.ApplicationTitleText;
            string ActualApplicationText = loginpage.ApplicationTitle.Text;
            Assert.AreEqual(ExpectedApplicationText, ActualApplicationText, "Smartcare remote mangement title is not matching with the expected value");
        }

        [Then(@"login instructions")]
        public void ThenLoginInstructions()
        {
            Assert.AreEqual(loginpage.LoginInstructions.Displayed,true,"Login instructions are not displayed");
            string ExpectedInstructionsText = LoginPage.ExpectedValues.LoginInstructionsText;
            string ActualInstructionsText = loginpage.LoginInstructions.Text;
            Assert.AreEqual(ExpectedInstructionsText, ActualInstructionsText,"Login instructions text is not matching with expected value");
        }

        [Then(@"a Ready to Get Started message")]
        public void ThenAReadyToGetStartedMessage()
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

        [Then(@"a copyright message")]
        public void ThenACopyrightMessage()
        {
            Assert.AreEqual(LoginPage.ExpectedValues.CopyRight, loginpage.CopyRight.Text, "Copyright message is not matching with the expected value.");
            Assert.AreEqual(LoginPage.ExpectedValues.RightsReservedMessage, loginpage.Rights.Text, "Right reserved message is not matching with the expected value");
        }
    }
}