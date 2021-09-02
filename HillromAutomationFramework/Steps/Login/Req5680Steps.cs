using HillromAutomationFramework.PageObjects;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{

    [Binding]
    public class Req5680Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;

        public Req5680Steps()
        {
            _loginPage = new LoginPage();
            _landingPage = new LandingPage();
        }

        [Given(@"user is logged in")]
        public void GivenUserIsLoggedIn()
        {
            //Log in as Admin user with rollup
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
        }

        [When(@"user clicks Logout button")]
        public void WhenUserClicksLogoutButton()
        {
            //Clicks on profile logo
            _landingPage.UserNameLogo.Click();
            //Clicks on logout button
            _landingPage.LogOutButton.Click();
        }
    }
}
