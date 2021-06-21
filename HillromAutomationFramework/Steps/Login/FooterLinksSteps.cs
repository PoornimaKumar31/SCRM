using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class FooterLinksSteps
    {
        readonly LoginPage loginPage = new LoginPage();

        [When(@"User click on Privacy Policy link")]
        public void WhenUserClickOnPrivacyPolicyLink()
        {
            loginPage.PrivacyPolicylink.Clicks();
        }
        
        [When(@"User click on Terms of use link")]
        public void WhenUserClickOnTermsOfUseLink()
        {
            loginPage.TermsOfUseLink.Clicks();
        }
        
        [Then(@"It will display ""(.*)"" page\.")]
        public void ThenItWillDisplayPage_(string ExpectedPage)
        {
            var popup = PropertyClass.Driver.WindowHandles[1]; // handler for the new tab
            // Check if new tab is opened
            Assert.IsTrue(!string.IsNullOrEmpty(popup));
            //Get the URL of new tab.
            string ActualPageURL = PropertyClass.Driver.SwitchTo().Window(popup).Url;
            if (ExpectedPage.Equals("Global Privacy Notice"))
            {
                Assert.AreEqual(LoginPage.ExpectedValues.PrivacyPolicyURL, ActualPageURL);
            }
            else if (ExpectedPage.Equals("Hillrom Terms and Conditions"))
            {
                Assert.AreEqual(LoginPage.ExpectedValues.TermsOfUseURL, ActualPageURL);
            }
        }
    }
}
