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
    [Binding,Scope(Tag = "SoftwareRequirementID_5692")]
    class Req5692Steps
    {
        CVSMDeviceDetailsPage cvsmDeviceDetailsPage = new CVSMDeviceDetailsPage();
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();

        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
       
        [Given(@"user is on CVSM Log Files page")]
        public void GivenUserIsOnCVSMLogFilesPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.Organization1Facility0Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CVSMDeviceName);
            Thread.Sleep(2000);
            mainPage.SearchSerialNumberAndClick("100020000007");
            cvsmDeviceDetailsPage.LogsTab.Click();
        }

        [Given(@"at least one log is present")]
        public void GivenAtLeastOneLogIsPresent()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.LogFiles.GetElementCount() > 0);
        }

        [When(@"user clicks log")]
        public void WhenUserClicksLog()
        {
            cvsmDeviceDetailsPage.LogFiles[0].Click();
        }

        [Then(@"log is downloaded to computer")]
        public void ThenLogIsDownloadedToComputer()
        {
            bool file_exist = false;
            int count = 0;
            while (file_exist != true && count <= 10)
            {
                Task.Delay(1000).Wait();
                count++;
                if (File.Exists(PropertyClass.DownloadPath + "\\" + cvsmDeviceDetailsPage.LogFiles[0].Text))
                {
                    file_exist = true;
                }
            }
        }

        [Then(@"downloaded filename matches")]
        public void ThenDownloadedFilenameMatches()
        {
            Assert.AreEqual(true,File.Exists(PropertyClass.DownloadPath + "\\" + cvsmDeviceDetailsPage.LogFiles[0].Text),"Log file name does not match with downloaded file.");
        }

    }
}
