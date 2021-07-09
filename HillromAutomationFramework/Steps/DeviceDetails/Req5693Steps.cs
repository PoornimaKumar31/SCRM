using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5693")]
    class Req5693Steps
    {
        LoginPage loginPage = new LoginPage();
        CVSMDeviceDetailsPage cvsmDeviceDetailsPage = new CVSMDeviceDetailsPage();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        readonly MainPage mainPage = new MainPage();

        [Given(@"user is on CVSM Log Files page")]
        public void GivenUserIsOnCVSMLogFilesPage()
        {
            loginPage.SignIn("AdminWithoutRollupPage");
            SelectElement selectAssetType = new SelectElement(mainPage.AssetTypeDropDown);
            selectAssetType.SelectByText(MainPage.ExpectedValues.CVSMDeviceName);
            //select the row according to the data
            cvsmDeviceDetailsPage.CVSMDevices[0].Clicks();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CVSMDeviceDetailsPage.Locators.LogsTabID)));
            cvsmDeviceDetailsPage.LogsTab.Click();
        }

        [Given(@"Pending or Executing message is not displayed")]
        public void GivenPendingOrExecutingMessageIsNotDisplayed()
        {
            Assert.IsFalse(cvsmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility());
        }

        [When(@"user clicks Request Logs button")]
        public void WhenUserClicksRequestLogsButton()
        {
            cvsmDeviceDetailsPage.LogsRequestButton.Click();
        }

        [Then(@"Pending or Executing message is displayed")]
        public void ThenPendingOrExecutingMessageIsDisplayed()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility());
        }

        [Given(@"Pending or Executing message is displayed")]
        public void GivenPendingOrExecutingMessageIsDisplayed()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility());
        }

        [Then(@"Request Logs button is disabled")]
        public void ThenRequestLogsButtonIsDisabled()
        {
            Assert.IsFalse(cvsmDeviceDetailsPage.LogsRequestButton.Enabled);
        }

    }
}
