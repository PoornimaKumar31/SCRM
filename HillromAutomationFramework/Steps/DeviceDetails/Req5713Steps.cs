using FluentAssertions;
using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding, Scope(Tag = "SoftwareRequirementID_5713")]
    class Req5713Steps
    {
        RV700DeviceDetailsPage _rv700DeviceDetailsPage;
        LoginPage _loginPage;
        LandingPage _landingPage;
        MainPage _mainPage;
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

        public Req5713Steps()
        {
            _rv700DeviceDetailsPage = new RV700DeviceDetailsPage();
            _loginPage = new LoginPage();
            _landingPage = new LandingPage();
            _mainPage = new MainPage();
        }

        [Given(@"user is on RV700 Log Files page")]
        public void GivenUserIsOnRVLogFilesPage()
        {
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.RV700DeviceName);
            Thread.Sleep(1000);
            _mainPage.SearchSerialNumberAndClick("700090000008");
            _rv700DeviceDetailsPage.LogsTab.Click();
        }

        [Given(@"Received, Pending or Executing message is not displayed")]
        public void GivenPendingOrExecutingMessageIsNotDisplayed()
        {
            _rv700DeviceDetailsPage.LogsPendingMessage.GetElementVisibility().Should().BeFalse("Reciving,Pending or Executing message is displayed");
        }

        [When(@"user clicks Request Logs button")]
        public void WhenUserClicksRequestLogsButton()
        {
            _rv700DeviceDetailsPage.LogsRequestButton.Click();
        }

        [Then(@"Received, Pending or Executing message is displayed")]
        public void ThenPendingOrExecutingMessageIsDisplayed()
        {
            _rv700DeviceDetailsPage.LogsPendingMessage.GetElementVisibility().Should().BeTrue( "Reciving, Pending or Executing message is not displayed");
             _rv700DeviceDetailsPage.LogsPendingMessage.LogFilesRequestStatusMessageVerification().Should().BeTrue( "Log files request status message is not matching the expected value.");
        }

        [Given(@"Received, Pending or Executing message is displayed")]
        public void GivenPendingOrExecutingMessageIsDisplayed()
        {
            _rv700DeviceDetailsPage.LogsPendingMessage.GetElementVisibility().Should().BeTrue( "Pending or Executing message is not displayed");
             _rv700DeviceDetailsPage.LogsPendingMessage.LogFilesRequestStatusMessageVerification().Should().BeTrue( "Log files request status message is not matching the expected value.");
        }

        [Then(@"Request Logs button is disabled")]
        public void ThenRequestLogsButtonIsDisabled()
        {
            _rv700DeviceDetailsPage.LogsRequestButton.GetAttribute("class").Should().BeEquivalentTo(RV700DeviceDetailsPage.ExpectedValues.RequestLogButtonDisabledClassName, "Request Logs button is not disabled");
        }

    }
}
