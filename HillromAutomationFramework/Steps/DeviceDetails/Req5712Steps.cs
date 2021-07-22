using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding, Scope(Tag = "SoftwareRequirementID_5712")]
    class Req5712Steps
    {
        RV700DeviceDetailsPage rv700DeviceDetailsPage = new RV700DeviceDetailsPage();
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

        [Given(@"user is on RV700 Log Files page")]
        public void GivenUserIsOnRVLogFilesPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.Organization2Facility0Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.RV700DeviceName);
            Thread.Sleep(1000);
            mainPage.SearchSerialNumberAndClick("700090000004");
            rv700DeviceDetailsPage.LogsTab.Click();
        }

        [Given(@"at least one log is present")]
        public void GivenAtLeastOneLogIsPresent()
        {
            Assert.AreEqual(true,rv700DeviceDetailsPage.LogFiles.GetElementCount()>0,"No logs are present.");
        }

        [When(@"user clicks log")]
        public void WhenUserClicksLog()
        {
            rv700DeviceDetailsPage.LogFiles[0].Click();
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
                if (File.Exists(PropertyClass.DownloadPath + "\\" + rv700DeviceDetailsPage.LogFiles[0].Text))
                {
                    file_exist = true;
                }
            }
        }

        [Then(@"downloaded filename matches")]
        public void ThenDownloadedFilenameMatches()
        {
            Assert.AreEqual(true,File.Exists(PropertyClass.DownloadPath + "\\" + rv700DeviceDetailsPage.LogFiles[0].Text),"Download filename does not match with the log file name");
        }

    }
}
