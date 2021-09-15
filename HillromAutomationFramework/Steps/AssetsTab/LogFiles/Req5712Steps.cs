using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AssetsTab;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.AssetsTab.LogFiles
{
    [Binding, Scope(Tag = "SoftwareRequirementID_5712")]
    class Req5712Steps
    {
        private readonly RV700DeviceDetailsPage _rv700DeviceDetailsPage;
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;

        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverWait _wait;

        public Req5712Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
            _rv700DeviceDetailsPage = new RV700DeviceDetailsPage(driver);
        }

        [Given(@"user is on RV700 Log Files page")]
        public void GivenUserIsOnRVLogFilesPage()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.AssetTypeDropDown.SelectDDL(MainPageExpectedValue.RV700DeviceName);
            Thread.Sleep(1000);
            _mainPage.SearchSerialNumberAndClick("700090000004");
            _rv700DeviceDetailsPage.LogsTab.Click();
        }

        [Given(@"at least one log is present")]
        public void GivenAtLeastOneLogIsPresent()
        {
            _rv700DeviceDetailsPage.LogFiles.GetElementCount().Should().BeGreaterThan(0,"No logs are present.");
        }

        [When(@"user clicks log")]
        public void WhenUserClicksLog()
        {
            _rv700DeviceDetailsPage.LogFiles[0].Click();
        }

        [Then(@"log is downloaded to computer")]
        public void ThenLogIsDownloadedToComputer()
        {
            bool IsRV700LofFileDownloaded = GetMethods.IsFileDownloaded(_rv700DeviceDetailsPage.LogFiles[0].Text, waitTimeInSeconds: 20);
            (IsRV700LofFileDownloaded).Should().BeTrue(because: "CSM Log file should be downloaded when user clicks First Log File in Logs page");
        }

        [Then(@"downloaded filename matches")]
        public void ThenDownloadedFilenameMatches()
        {
            File.Exists(PropertyClass.DownloadPath + "\\" + _rv700DeviceDetailsPage.LogFiles[0].Text).Should().BeTrue("Download filename does not match with the log file name");
        }

    }
}
