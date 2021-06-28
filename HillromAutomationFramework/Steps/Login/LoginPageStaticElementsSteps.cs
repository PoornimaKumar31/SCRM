using HillromAutomationFramework.Coding.PageObjects;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class LoginPageStaticElementsSteps
    {
        LoginPage loginpage = new LoginPage();

        [Then(@"user will see login Hillrom logo")]
        public void ThenUserWillSeeLoginHillromLogo()
        {
            //Assert.IsTrue(loginpage.LoginPageLogo.Displayed);
        }
        
        [Then(@"login SmartCare Remote Management title")]
        public void ThenLoginSmartCareRemoteManagementTitle()
        {
            Assert.IsTrue(loginpage.ApplicationTitle.Displayed);
            string ExpectedApplicationText = LoginPage.ExpectedValues.ApplicationTitleText;
            string ActualApplicationText = loginpage.ApplicationTitle.Text;
            Assert.AreEqual(ExpectedApplicationText, ActualApplicationText);
        }
        
        [Then(@"login instructions")]
        public void ThenLoginInstructions()
        {
            Assert.IsTrue(loginpage.LoginInstructions.Displayed);
            string ExpectedInstructionsText = LoginPage.ExpectedValues.LoginInstructionsText;
            string ActualInstructionsText = loginpage.LoginInstructions.Text;
            Assert.AreEqual(ExpectedInstructionsText, ActualInstructionsText);
        }
        
        [Then(@"a Ready to Get Started message")]
        public void ThenAReadyToGetStartedMessage()
        {
            Assert.IsTrue(loginpage.GetStartedTitle.Displayed);
            string ExpectedGetStartedTitle =LoginPage.ExpectedValues.GetStartedTitleText;
            string ActualGetStartedTitle = loginpage.GetStartedTitle.Text;
            Assert.AreEqual(ExpectedGetStartedTitle, ActualGetStartedTitle);

            Assert.IsTrue(loginpage.GetStartedMessage.Displayed);
            string ExpectedGetStartedMessage = LoginPage.ExpectedValues.GetStartedMessageText;
            string ActualGetStartedMessage = loginpage.GetStartedMessage.Text;
            Assert.AreEqual(ExpectedGetStartedMessage, ActualGetStartedMessage);

        }
        
        [Then(@"a copyright message")]
        public void ThenACopyrightMessage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
