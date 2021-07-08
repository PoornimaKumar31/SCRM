using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5692")]
    class Req5692Steps
    {
        CVSMDeviceDetailsPage cvsmDeviceDetailsPage = new CVSMDeviceDetailsPage();
        LoginPage loginPage = new LoginPage();
        MainPage mainPage = new MainPage();
       
        [Given(@"user is on CVSM Log Files page")]
        public void GivenUserIsOnCVSMLogFilesPage()
        {
            loginPage.SignIn("AdminWithoutRollupPage");
            SelectElement selectAssetType = new SelectElement(mainPage.AssetTypeDropDown);
            selectAssetType.SelectByText(MainPage.ExpectedValues.CVSMDeviceName);
            cvsmDeviceDetailsPage.CVSMDevices[1].Click();
            cvsmDeviceDetailsPage.LogsTab.Click();
        }

        [Given(@"at least one log is present")]
        public void GivenAtLeastOneLogIsPresent()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.LogFiles.GetElementCount() != 0);
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
            while (file_exist != true)
            {
                Task.Delay(1000).Wait();
                if (File.Exists(PropertyClass.DownloadPath + "\\" + cvsmDeviceDetailsPage.LogFiles[0].Text))
                {
                    file_exist = true;
                }
            }
        }

        [Then(@"downloaded filename matches")]
        public void ThenDownloadedFilenameMatches()
        {
            Assert.IsTrue(File.Exists(PropertyClass.DownloadPath + "\\" + cvsmDeviceDetailsPage.LogFiles[0].Text));
        }

    }
}
