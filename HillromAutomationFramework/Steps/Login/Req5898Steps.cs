using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class Req5898Steps
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
            Assert.AreEqual(!string.IsNullOrEmpty(popup),true,"New tab for privacy policy link is not opened");
            //Get the URL of new tab.
            string ActualPageTitle = PropertyClass.Driver.SwitchTo().Window(popup).Title;
            Assert.AreEqual(LoginPage.ExpectedValues.PrivacyPolicyTitle, ActualPageTitle,"Privacy policy link is not matching with the expected");
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
            Assert.AreEqual(!string.IsNullOrEmpty(popup),true,"New tab for Terms and conditions page is not opened");
            //Get the URL of new tab.
            string ActualPageTitle = PropertyClass.Driver.SwitchTo().Window(popup).Title;
            Assert.AreEqual(LoginPage.ExpectedValues.TermsOfUseTitle, ActualPageTitle,"Terms and condition page URL does not match with the expected URL");
        }
    }
}
