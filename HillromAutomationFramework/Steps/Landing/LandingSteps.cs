using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Landing
{
    [Binding]
    class LandingSteps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        [Given(@"user is on landing page")]
        public void GivenUserIsOnLandingPage()
        {
            loginPage.SignIn();
        }

        [Given(@"user clicks on organization")]
        public void GivenUserClicksOnOrganization()
        {
            Thread.Sleep(3000);
            landingPage.TileList[2].Clicks();
            Thread.Sleep(3000);
        }

        [Then(@"user will see the device list")]
        public void ThenUserWillSeeTheDeviceList()
        {
            Console.WriteLine("This is device page");
        }

    }
}
