using FluentAssertions;
using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class Req5678Steps
    {
        private readonly LoginPage _loginPage;
        public Req5678Steps()
        {
            _loginPage = new LoginPage();
        }

        [Then(@"""(.*)"" is displayed")]
        public void ThenIsDisplayed(string ExpectedText)
        {
            string ActualVersionNoDisplayed = _loginPage.VersionNumber.Text;
            //Verifying the version no is displayed
            _loginPage.VersionNumber.GetElementVisibility().Should().BeTrue("Version no is not displayed\n");
            //Verifying the version no displayed is correct
            ActualVersionNoDisplayed.Should().BeEquivalentTo(ExpectedText, "The app" + ExpectedText + " is not Matching\n");
        }
    }
}