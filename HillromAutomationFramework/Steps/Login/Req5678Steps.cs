using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class Req5678Steps
    {
        LoginPage loginPage = new LoginPage();

        [Then(@"""(.*)"" is displayed")]
        public void ThenIsDisplayed(string ExpectedText)
        {
            string ActualVersionNoDisplayed = loginPage.VersionNumber.Text;
            //Verifying the version no is displayed
            Assert.AreEqual(true, loginPage.VersionNumber.GetElementVisibility(), "Version no is not displayed\n");
            //Verifying the version no displayed is correct
            Assert.AreEqual(ExpectedText, ActualVersionNoDisplayed, "The app" + ExpectedText + " is not Matching\n");
        }
    }
}