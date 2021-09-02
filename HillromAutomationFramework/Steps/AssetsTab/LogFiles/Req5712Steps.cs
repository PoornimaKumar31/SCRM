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

namespace HillromAutomationFramework.Steps.AssetsTab.LogFiles
{
    [Binding, Scope(Tag = "SoftwareRequirementID_5712")]
    class Req5712Steps
    {
        private readonly RV700DeviceDetailsPage _rv700DeviceDetailsPage;
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

        public Req5712Steps()
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
            bool file_exist = false;
            int count = 0;
            while (file_exist != true && count<=10)
            {
                Task.Delay(1000).Wait();
                count++;
                if (File.Exists(PropertyClass.DownloadPath + "\\" + _rv700DeviceDetailsPage.LogFiles[0].Text))
                {
                    file_exist = true;
                }
            }
        }

        [Then(@"downloaded filename matches")]
        public void ThenDownloadedFilenameMatches()
        {
            File.Exists(PropertyClass.DownloadPath + "\\" + _rv700DeviceDetailsPage.LogFiles[0].Text).Should().BeTrue("Download filename does not match with the log file name");
        }

    }
}
