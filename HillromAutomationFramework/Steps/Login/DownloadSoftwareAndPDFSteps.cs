using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class DownloadSoftwareAndPDFSteps
    {
        readonly LoginPage loginPage = new LoginPage();

        [When(@"user clicks PartnerConnect")]
        public void WhenUserClicksPartnerConnect()
        {
            loginPage.PartnerConnectLink.Clicks();
            // Checking if download starts.
            bool file_exist = false;
            while (file_exist != true)
            {
                Task.Delay(10000).Wait();
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
                Assert.IsTrue(File.Exists(PropertyClass.PartnerConnectFilePath));
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
            loginPage.ServiceMoniterLink.Clicks();
            // Checking if download starts.
            bool file_exist = false;
            while (file_exist != true)
            {
                Task.Delay(10000).Wait();
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
                Assert.IsTrue(File.Exists(PropertyClass.ServiceMonitorFilePath));
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
            loginPage.DCPLink.Clicks();
            // Checking if download starts.
            bool file_exist = false;
            while (file_exist != true)
            {
                Task.Delay(1000).Wait();
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
                Assert.IsTrue(File.Exists(PropertyClass.DCPFilePath));
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
            loginPage.AdministratorsGuidePDFLink.Clicks();
        }

        [Then(@"Administrator Guide PDF opens in browser")]
        public void ThenAdministratorGuidePDFOpensInBrowser()
        {
            var popup = PropertyClass.Driver.WindowHandles[1]; // handler for the new tab
            Assert.IsTrue(!string.IsNullOrEmpty(popup)); // checking if new tab was opened
            PropertyClass.Driver.SwitchTo().Window(popup); // Switch to new tab.
            Assert.AreEqual(LoginPage.ExpectedValues.AdminstartorsGuidePDFURL, PropertyClass.Driver.Url);
        }

        [When(@"user clicks Instructions for Use")]
        public void WhenUserClicksInstructionsForUse()
        {
            loginPage.InstructionForUsePDFLink.Clicks();
        }

        [Then(@"Instructions for Use PDF opens in browser")]
        public void ThenInstructionsForUsePDFOpensInBrowser()
        {
            var popup = PropertyClass.Driver.WindowHandles[1]; // handler for the new tab
            Assert.IsTrue(!string.IsNullOrEmpty(popup)); // check if new tab was opened
            PropertyClass.Driver.SwitchTo().Window(popup); // Switch to new tab.
            Assert.AreEqual(LoginPage.ExpectedValues.InstructionForUsePDFURL, PropertyClass.Driver.Url);
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
            Assert.IsTrue(!string.IsNullOrEmpty(popup)); // tab was opened
            PropertyClass.Driver.SwitchTo().Window(popup); //Switch to new tab
            Assert.AreEqual(LoginPage.ExpectedValues.RealeaseNotesPDFURL, PropertyClass.Driver.Url);
        }
    }
}
