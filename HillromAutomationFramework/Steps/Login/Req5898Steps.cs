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
            loginPage.PrivacyPolicylink.Click();
        }

        [When(@"user clicks Terms of Use")]
        public void WhenUserClicksTermsOfUse()
        {
            loginPage.TermsOfUseLink.Click();
        }
    }
}
