using HillromAutomationFramework.Coding.PageObjects;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Landing
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5898")]
    public class LandingPageFooterLinksSteps
    {
        readonly LoginPage _loginPage;

        public LandingPageFooterLinksSteps()
        {
            _loginPage = new LoginPage();
        }

        [Given(@"user is on Landing page")]
        public void GivenUserIsOnLandingPage()
        {
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
        }
    }
}
