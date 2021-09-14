using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.AssetsTab.LogFiles
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5692")]
    class Req5692Steps
    { 
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly CVSMDeviceDetailsPage _cvsmDeviceDetailsPage;

        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public Req5692Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _cvsmDeviceDetailsPage = new CVSMDeviceDetailsPage(driver);
            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
        }

        [Given(@"user is on CVSM Log Files page")]
        public void GivenUserIsOnCVSMLogFilesPage()
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
            
            _mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CVSMDeviceName);
            Thread.Sleep(2000);
            
            _mainPage.SearchSerialNumberAndClick("100020000007");
            _cvsmDeviceDetailsPage.LogsTab.Click();
        }

        [Given(@"at least one log is present")]
        public void GivenAtLeastOneLogIsPresent()
        {
            _cvsmDeviceDetailsPage.LogFiles.GetElementCount().Should().BeGreaterThan(0);
        }

        [When(@"user clicks log")]
        public void WhenUserClicksLog()
        {
            _cvsmDeviceDetailsPage.LogFiles[0].Click();
        }

        [Then(@"log is downloaded to computer")]
        public void ThenLogIsDownloadedToComputer()
        {
            bool IsCVSMLofFileDownloaded = GetMethods.IsFileDownloaded(_cvsmDeviceDetailsPage.LogFiles[0].Text, waitTimeInSeconds: 20);
            (IsCVSMLofFileDownloaded).Should().BeTrue(because: "CVSM Log file should be downloaded when user clicks First Log File in Logs page");
        }

        [Then(@"downloaded filename matches")]
        public void ThenDownloadedFilenameMatches()
        {
            File.Exists(PropertyClass.DownloadPath + "\\" + _cvsmDeviceDetailsPage.LogFiles[0].Text).Should().BeTrue("Log file name does not match with downloaded file.");
        }

    }
}
