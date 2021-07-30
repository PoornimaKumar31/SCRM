using HillromAutomationFramework.Coding.PageObjects;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{

    [Binding]
    public class Req5680Steps
    {
        readonly LoginPage loginPage=new LoginPage();
        readonly LandingPage landingPage = new LandingPage();

        [Given(@"user is logged in")]
        public void GivenUserIsLoggedIn()
        {
            //Log in as Admin user with rollup
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
        }

        [When(@"user clicks Logout button")]
        public void WhenUserClicksLogoutButton()
        {
            //Clicks on profile logo
            landingPage.UserNameLogo.Click();
            //Clicks on logout button
            landingPage.LogOutButton.Click();
        }
    }
}
