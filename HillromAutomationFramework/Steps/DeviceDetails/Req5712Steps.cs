using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding, Scope(Tag = "SoftwareRequirementID_5712")]
    class Req5712Steps
    {
        RV700DeviceDetailsPage rv700DeviceDetailsPage = new RV700DeviceDetailsPage();
        LoginPage loginPage = new LoginPage();
        MainPage mainPage = new MainPage();

        [Given(@"user is on RV(.*) Log Files page")]
        public void GivenUserIsOnRVLogFilesPage(int p0)
        {
            loginPage.SignIn("rv700");
            SelectElement selectAssetType = new SelectElement(mainPage.AssetTypeDropDown);
            selectAssetType.SelectByText(MainPage.ExpectedValues.RV700DeviceName);
            rv700DeviceDetailsPage.RV700Devices[0].Click();
            rv700DeviceDetailsPage.LogsTab.Click();
        }

        [Given(@"at least one log is present")]
        public void GivenAtLeastOneLogIsPresent()
        {
            Assert.IsTrue(rv700DeviceDetailsPage.LogFiles.GetElementCount() != 0);
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
            while (file_exist != true)
            {
                Task.Delay(1000).Wait();
                if (File.Exists(PropertyClass.DownloadPath + "\\" + rv700DeviceDetailsPage.LogFiles[0].Text))
                {
                    file_exist = true;
                }
            }
        }

        [Then(@"downloaded filename matches")]
        public void ThenDownloadedFilenameMatches()
        {
            Assert.IsTrue(File.Exists(PropertyClass.DownloadPath + "\\" + rv700DeviceDetailsPage.LogFiles[0].Text));
        }

    }
}
