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
            PropertyClass.Driver.Navigate().GoToUrl(PropertyClass.BaseURL);  // Launch the Application
            // Explicit wait-> Wait till logo is displayed
            WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(LoginPage.Locator.LogoID)));
            loginPage.EmailField.EnterText(PropertyClass.readConfig.ValidEmailID);
            loginPage.PasswordField.EnterText(PropertyClass.readConfig.ValidPassword);
            loginPage.LoginButton.Clicks();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(LoginPage.Locator.LandingPageTileID)));
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
