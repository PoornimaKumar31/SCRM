using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class Req5685Steps
    {
        readonly LoginPage loginPage = new LoginPage();

        [When(@"user clicks PartnerConnect")]
        public void WhenUserClicksPartnerConnect()
        {
            loginPage.PartnerConnectLink.Click();
            // Checking if download starts.
            int count = 0;
            bool file_exist = false;
            while (file_exist != true || count <= 30)
            {
                Task.Delay(10000).Wait();
                count++;
                if (File.Exists(PropertyClass.PartnerConnectFilePath))
                {
                    file_exist = true;
                }
            }
        }

        [Then(@"PartnerConnect zip file is downloaded")]
        public void ThenPartnerConnectZipFileIsDownloaded()
        {
            // Checking if Partner Connect ZIP file is downloaded successfuly.
            if (Directory.Exists(PropertyClass.DownloadPath))
            {
                Assert.AreEqual(File.Exists(PropertyClass.PartnerConnectFilePath), true, "PartnerConnect zip file is not downloaded");
                //Delete file after verifying
                File.Delete(PropertyClass.PartnerConnectFilePath);
            }
            else
            {
                Assert.Fail("Directory/Folder Does not exist");
            }
        }

        [When(@"user clicks Service Monitor")]
        public void WhenUserClicksServiceMonitor()
        {
            loginPage.ServiceMoniterLink.Click();
            // Checking if download starts.
            bool file_exist = false;
            int count = 0;
            while (file_exist != true || count <= 30)
            {
                Task.Delay(10000).Wait();
                count++;
                if (File.Exists(PropertyClass.ServiceMonitorFilePath))
                {
                    file_exist = true;
                }
            }
        }

        [Then(@"Service Monitor zip file is downloaded")]
        public void ThenServiceMonitorZipFileIsDownloaded()
        {
            // Checking if Partner Connect ZIP file is downloaded successfuly.
            if (Directory.Exists(PropertyClass.DownloadPath))
            {
                Assert.AreEqual(File.Exists(PropertyClass.ServiceMonitorFilePath), true, "Service Moniter Zip file is not downloaded");
                // Delete after Verifying.
                File.Delete(PropertyClass.ServiceMonitorFilePath);
            }
            else
            {
                Assert.Fail("Directory/Folder Does not exist");
            }
        }

        [When(@"user clicks DCP")]
        public void WhenUserClicksDCP()
        {
            loginPage.DCPLink.Click();
            // Checking if download starts.
            bool file_exist = false;
            int count = 0;
            while (file_exist != true || count<=30)
            {
                Task.Delay(1000).Wait();
                count++;
                if (File.Exists(PropertyClass.DCPFilePath))
                {
                    file_exist = true;
                }
            }
        }

        [Then(@"DCP zip file is downloaded")]
        public void ThenDCPZipFileIsDownloaded()
        {
            // Checking if Partner Connect ZIP file is downloaded successfuly.
            if (Directory.Exists(PropertyClass.DownloadPath))
            {
                Assert.AreEqual(File.Exists(PropertyClass.DCPFilePath), true, "Dcp zip file is not downloaded\n");
                // Delete after verifying.
                File.Delete(PropertyClass.DCPFilePath);
            }
            else
            {
                Assert.Fail("Directory/Folder Does not exist");
            }
        }

        [When(@"user clicks Administrator Guide")]
        public void WhenUserClicksAdministratorGuide()
        {
            loginPage.AdministratorsGuidePDFLink.Click();
        }

        [Then(@"Administrator Guide PDF opens in browser")]
        public void ThenAdministratorGuidePDFOpensInBrowser()
        {
            var popup = PropertyClass.Driver.WindowHandles[1]; // handler for the new tab
            Assert.AreEqual(!string.IsNullOrEmpty(popup),true,"PDF is not opened in new tab"); // checking if new tab was opened
            PropertyClass.Driver.SwitchTo().Window(popup); // Switch to new tab.
            Assert.AreEqual(LoginPage.ExpectedValues.AdminstartorsGuidePDFURL, PropertyClass.Driver.Url,"Administator guide PDF is not opened");
        }

        [When(@"user clicks Instructions for Use")]
        public void WhenUserClicksInstructionsForUse()
        {
            loginPage.InstructionForUsePDFLink.Click();
        }

        [Then(@"Instructions for Use PDF opens in browser")]
        public void ThenInstructionsForUsePDFOpensInBrowser()
        {
            var popup = PropertyClass.Driver.WindowHandles[1]; // handler for the new tab
            Assert.AreEqual(!string.IsNullOrEmpty(popup),true,"New tab is not opened"); // check if new tab was opened
            PropertyClass.Driver.SwitchTo().Window(popup); // Switch to new tab.
            Assert.AreEqual(LoginPage.ExpectedValues.InstructionForUsePDFURL, PropertyClass.Driver.Url,"Instructions for use PDF is not opened");
        }

        [When(@"user clicks Release Notes")]
        public void WhenUserClicksReleaseNotes()
        {
            loginPage.ReleaseNotesPDFLink.Click();
        }

        [Then(@"Release Notes PDF opens in browser")]
        public void ThenReleaseNotesPDFOpensInBrowser()
        {
            var popup = PropertyClass.Driver.WindowHandles[1]; // handler for the new tab
            Assert.AreEqual(!string.IsNullOrEmpty(popup),true,"New tab is not opened"); // tab was opened
            PropertyClass.Driver.SwitchTo().Window(popup); //Switch to new tab
            Assert.AreEqual(LoginPage.ExpectedValues.RealeaseNotesPDFURL, PropertyClass.Driver.Url,"Release notes pdf is not opened");
        }
    }
}
