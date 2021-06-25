using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class FooterLinksSteps
    {
        readonly LoginPage loginPage = new LoginPage();

        [When(@"user clicks Privacy Policy")]
        public void WhenUserClicksPrivacyPolicy()
        {
            loginPage.PrivacyPolicylink.Clicks();
        }

        [Then(@"Privacy Policy page is displayed")]
        public void ThenPrivacyPolicyPageIsDisplayed()
        {
            var popup = PropertyClass.Driver.WindowHandles[1]; // handler for the new tab
            // Check if new tab is opened
            Assert.IsTrue(!string.IsNullOrEmpty(popup));
            //Get the URL of new tab.
            string ActualPageURL = PropertyClass.Driver.SwitchTo().Window(popup).Url;
            Assert.AreEqual(LoginPage.ExpectedValues.PrivacyPolicyURL, ActualPageURL);
        }

        [When(@"user clicks Terms of Use")]
        public void WhenUserClicksTermsOfUse()
        {
            loginPage.TermsOfUseLink.Clicks();
        }

        [Then(@"Terms and Conditions page is displayed")]
        public void ThenTermsAndConditionsPageIsDisplayed()
        {
            var popup = PropertyClass.Driver.WindowHandles[1]; // handler for the new tab
            // Check if new tab is opened
            Assert.IsTrue(!string.IsNullOrEmpty(popup));
            //Get the URL of new tab.
            string ActualPageURL = PropertyClass.Driver.SwitchTo().Window(popup).Url;
            Assert.AreEqual(LoginPage.ExpectedValues.TermsOfUseURL, ActualPageURL);
        }
    }
}
