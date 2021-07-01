using HillromAutomationFramework.Coding.PageObjects;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Landing
{
    [Binding]
    public class LandingPageFooterLinksSteps
    {
        readonly LoginPage loginPage = new LoginPage();

        [Given(@"user is on Landing page")]
        public void GivenUserIsOnLandingPage()
        {
            loginPage.SignIn("AdminWithRollup");
        }
    }
}
