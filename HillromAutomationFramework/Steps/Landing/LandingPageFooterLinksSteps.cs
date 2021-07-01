using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
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
            loginPage.SignIn("adminwithrollup");
        }
    }
}
