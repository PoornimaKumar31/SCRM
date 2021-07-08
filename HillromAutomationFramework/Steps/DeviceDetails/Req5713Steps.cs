using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding, Scope(Tag = "SoftwareRequirementID_5713")]
    class Req5713Steps
    {
        RV700DeviceDetailsPage rv700DeviceDetailsPage = new RV700DeviceDetailsPage();
        LoginPage loginPage = new LoginPage();
        MainPage mainPage = new MainPage();
        [Given(@"user is on RV700 Log Files page")]
        public void GivenUserIsOnRVLogFilesPage()
        {
            loginPage.SignIn("rv700");
            SelectElement selectAssetType = new SelectElement(mainPage.AssetTypeDropDown);
            selectAssetType.SelectByText(MainPage.ExpectedValues.RV700DeviceName);
            rv700DeviceDetailsPage.RV700Devices[0].Click();
            rv700DeviceDetailsPage.LogsTab.Click();
        }

        [Given(@"Pending or Executing message is not displayed")]
        public void GivenPendingOrExecutingMessageIsNotDisplayed()
        {
            Assert.IsFalse(rv700DeviceDetailsPage.LogsPendingMessage.GetElementVisibility());
        }

        [When(@"user clicks Request Logs button")]
        public void WhenUserClicksRequestLogsButton()
        {
            rv700DeviceDetailsPage.LogsRequestButton.Click();
        }

        [Then(@"Pending or Executing message is displayed")]
        public void ThenPendingOrExecutingMessageIsDisplayed()
        {
            Assert.IsTrue(rv700DeviceDetailsPage.LogsPendingMessage.GetElementVisibility());
        }

        [Given(@"Pending or Executing message is displayed")]
        public void GivenPendingOrExecutingMessageIsDisplayed()
        {
            Assert.IsTrue(rv700DeviceDetailsPage.LogsPendingMessage.GetElementVisibility());
        }

        [Then(@"Request Logs button is disabled")]
        public void ThenRequestLogsButtonIsDisabled()
        {
            Assert.IsFalse(rv700DeviceDetailsPage.LogsRequestButton.Enabled);
        }

    }
}
