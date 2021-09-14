using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.SupportingCode;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class Req5685Steps
    {
        private readonly LoginPage _loginPage;

        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverWait _wait;

        public Req5685Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
        }

        [When(@"user clicks PartnerConnect")]
        public void WhenUserClicksPartnerConnect()
        {
            _loginPage.PartnerConnectLink.Click();
        }

        [Then(@"PartnerConnect zip file is downloaded")]
        public void ThenPartnerConnectZipFileIsDownloaded()
        {
            bool IsParterConnectFileDownloaded = GetMethods.IsFileDownloaded(LoginPage.ExpectedValues.PartnerConnectFileName, waitTimeInSeconds: 300);
            (IsParterConnectFileDownloaded).Should().BeTrue(because: "Partner Connect Zip file should be downloaded when user clicks Partner Connect link in login page");
        }

        [When(@"user clicks Service Monitor")]
        public void WhenUserClicksServiceMonitor()
        {
            _loginPage.ServiceMoniterLink.Click();
        }

        [Then(@"Service Monitor zip file is downloaded")]
        public void ThenServiceMonitorZipFileIsDownloaded()
        {
            bool IsServiceMoniterFileDownloaded = GetMethods.IsFileDownloaded(LoginPage.ExpectedValues.ServiceMonitorFileName, waitTimeInSeconds: 300);
            (IsServiceMoniterFileDownloaded).Should().BeTrue(because: "Service Moniter file should be downloaded when user clicks Service Moniter link.");
        }

        [When(@"user clicks DCP")]
        public void WhenUserClicksDCP()
        {
            _loginPage.DCPLink.Click();
        }

        [Then(@"DCP zip file is downloaded")]
        public void ThenDCPZipFileIsDownloaded()
        {
            bool IsDCPFileDownloaded = GetMethods.IsFileDownloaded(LoginPage.ExpectedValues.DCPFileName, waitTimeInSeconds: 300);
            (IsDCPFileDownloaded).Should().BeTrue(because: "DCP file should be downloaded when user clicks DCP link.");
        }

        [When(@"user clicks Administrator Guide")]
        public void WhenUserClicksAdministratorGuide()
        {
            _loginPage.AdministratorsGuidePDFLink.Click();
        }

        [Then(@"Administrator Guide PDF opens in browser")]
        public void ThenAdministratorGuidePDFOpensInBrowser()
        {
            int windowCount = _driver.WindowHandles.Count;

            // checking if new tab was opened
            (windowCount).Should().BeGreaterThan(1, because: "PDF should be pened in a new window");

            var popup = _driver.WindowHandles[1];
            string.IsNullOrEmpty(popup).Should().BeFalse("PDF is not opened in new tab");

            // Switch to new tab.
            _driver.SwitchTo().Window(popup);
            
            _driver.Url.Should().BeEquivalentTo(LoginPage.ExpectedValues.AdminstartorsGuidePDFURL, "Administator guide PDF is not opened");
        }

        [When(@"user clicks Instructions for Use")]
        public void WhenUserClicksInstructionsForUse()
        {
            _loginPage.InstructionForUsePDFLink.Click();
        }

        [Then(@"Instructions for Use PDF opens in browser")]
        public void ThenInstructionsForUsePDFOpensInBrowser()
        {
            int windowCount = _driver.WindowHandles.Count;

            // checking if new tab was opened
            (windowCount).Should().BeGreaterThan(1, because: "PDF should be pened in a new window");

            // handler for the new tab
            var popup = _driver.WindowHandles[1];

            // check if new tab was opened
            string.IsNullOrEmpty(popup).Should().BeFalse("New tab is not opened");

            // Switch to new tab.
            _driver.SwitchTo().Window(popup); 
            
            _driver.Url.Should().BeEquivalentTo(LoginPage.ExpectedValues.InstructionForUsePDFURL, "Instructions for use PDF is not opened");
        }

        [When(@"user clicks Release Notes")]
        public void WhenUserClicksReleaseNotes()
        {
            _loginPage.ReleaseNotesPDFLink.Click();
        }

        [Then(@"Release Notes PDF opens in browser")]
        public void ThenReleaseNotesPDFOpensInBrowser()
        {
            int windowCount = _driver.WindowHandles.Count;

            // checking if new tab was opened
            (windowCount).Should().BeGreaterThan(1, because: "PDF should be pened in a new window");

            // handler for the new tab
            var popup = _driver.WindowHandles[1];

            // tab was opened
            string.IsNullOrEmpty(popup).Should().BeFalse("New tab is not opened");

            //Switch to new tab
            _driver.SwitchTo().Window(popup);

            _driver.Url.Should().BeEquivalentTo(LoginPage.ExpectedValues.RealeaseNotesPDFURL, "Release notes pdf is not opened");
        }
    }
}
