using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class Req5898Steps
    {
        private readonly LoginPage _loginPage;

        public Req5898Steps()
        {
            _loginPage = new LoginPage();
        }

        [When(@"user clicks Privacy Policy")]
        public void WhenUserClicksPrivacyPolicy()
        {
            _loginPage.PrivacyPolicylink.Click();
        }

        [When(@"user clicks Terms of Use")]
        public void WhenUserClicksTermsOfUse()
        {
            _loginPage.TermsOfUseLink.Click();
        }
    }
}
