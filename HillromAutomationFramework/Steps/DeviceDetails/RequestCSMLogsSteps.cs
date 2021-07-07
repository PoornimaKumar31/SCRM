using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5700")]
    public class RequestCSMLogsSteps
    {
        LoginPage loginPage = new LoginPage();
        CSMDeviceDetailsPage csmDeviceDetailsPage = new CSMDeviceDetailsPage();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        readonly MainPage mainPage = new MainPage();


        [Given(@"user is on CSM Log Files page")]
        public void GivenUserIsOnCSMLogFilesPage()
        {
            loginPage.SignIn("AdminWithoutRollupPage");
            SelectElement selectAssetType = new SelectElement(mainPage.AssetTypeDropDown);
            selectAssetType.SelectByText(MainPage.ExpectedValues.CSMDeviceName);
            //select the row according to the data
            csmDeviceDetailsPage.CSMDevices[0].Clicks();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CSMDeviceDetailsPage.Locators.LogsTabID)));
            csmDeviceDetailsPage.LogsTab.Click();
        }
        
        [Given(@"Pending or Executing message is not displayed")]
        public void GivenPendingOrExecutingMessageIsNotDisplayed()
        {
            Assert.IsFalse(csmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility());
        }
        
        [When(@"user clicks Request Logs button")]
        public void WhenUserClicksRequestLogsButton()
        {
            csmDeviceDetailsPage.LogsRequestButton.Click();
        }
        
        [Then(@"Pending or Executing message is displayed")]
        public void ThenPendingOrExecutingMessageIsDisplayed()
        {
            Assert.IsTrue(csmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility());
        }
        
        [Then(@"Request Logs button is disabled")]
        public void ThenRequestLogsButtonIsDisabled()
        {
            Assert.IsFalse(csmDeviceDetailsPage.LogsRequestButton.Enabled);
        }

        [Given(@"Pending or Executing message is displayed")]
        public void GivenPendingOrExecutingMessageIsDisplayed()
        {
            Assert.IsTrue(csmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility());
        }

    }
}
