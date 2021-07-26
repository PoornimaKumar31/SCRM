using HillromAutomationFramework.Coding.PageObjects;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Landing
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5898")]
    public class LandingPageFooterLinksSteps
    {
        readonly LoginPage loginPage = new LoginPage();

        [Given(@"user is on Landing page")]
        public void GivenUserIsOnLandingPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
        }
    }
}
