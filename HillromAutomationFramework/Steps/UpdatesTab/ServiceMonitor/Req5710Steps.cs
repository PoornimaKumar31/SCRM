using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.UpdatesTab;
using HillromAutomationFramework.SupportingCode;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.UpdatesTab.ServiceMonitor
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5710")]
    public class Req5710Steps
    {

        private readonly LoginPage _loginPage;
        private readonly MainPage _mainPage;
        private readonly ServiceMonitorPage _serviceMoniterPage;

        private readonly WebDriverWait _wait;
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public Req5710Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _mainPage = new MainPage(driver);
            _serviceMoniterPage = new ServiceMonitorPage(driver);
        }

        [Given(@"user is on Service Monitor Settings page")]
        public void GivenUserIsOnServiceMonitorSettingsPage()
        {
            //Login without roll-up
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithOutRollUpPage);
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));

            //Selecting Service Moniter Page
            _mainPage.UpdatesTab.JavaSciptClick(_driver);
            _serviceMoniterPage.AssetTypeDropDown.SelectDDL(ServiceMonitorPageExpectedValues.ServiceMoniterText);
            bool IsServiceMiniterSettingsPageDisplayed = (_serviceMoniterPage.ServiceMoniterLabel.GetElementVisibility()) || (_serviceMoniterPage.DeploymentModeLabel.GetElementVisibility());
            (IsServiceMiniterSettingsPageDisplayed).Should().BeTrue(because: "Service Monitor Settings page should be displayed when user selects Service moniter in updates tab");
        }
        
        [Given(@"user selects a Service Monitor in the list")]
        public void WhenUserSelectsAServiceMonitorInTheList()
        {
            _serviceMoniterPage.FirstDeviceCheckBox.Click();
        }
        
        [When(@"the user clicks Deploy button")]
        public void WhenTheUserClicksDeployButton()
        {
            _serviceMoniterPage.DeployButton.Click();
        }
        
        [Then(@"Deploy button is enabled")]
        public void ThenDeployButtonIsEnabled()
        {
            (_serviceMoniterPage.DeployButton.Enabled).Should().BeTrue(because: "Deploy button should be enabled when user selects one device in service moniter settings page");
        }
        
        [Then(@"Update process has been established message displays")]
        public void ThenUpdateProcessHasBeenEstablishedMessageDisplays()
        {
            Thread.Sleep(1000);
            (_serviceMoniterPage.UpdateMessage.GetElementVisibility()).Should().BeTrue(because:"Update message should be displayed when user clicks on the confirm button");
            string updateMessageText = _serviceMoniterPage.UpdateMessage.Text;
            (updateMessageText).Should().BeEquivalentTo(ServiceMonitorPageExpectedValues.UpdateMessageText, because: "Update message should match with the expected text");
        }
    }
}
