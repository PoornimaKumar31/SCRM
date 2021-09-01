using FluentAssertions;
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
        private readonly LoginPage _loginPage;
        
        public Req5685Steps()
        {
            _loginPage = new LoginPage();
        }

        [When(@"user clicks PartnerConnect")]
        public void WhenUserClicksPartnerConnect()
        {
            _loginPage.PartnerConnectLink.Click();
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
                File.Exists(PropertyClass.PartnerConnectFilePath).Should().BeTrue("PartnerConnect zip file is not downloaded");
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
            _loginPage.ServiceMoniterLink.Click();
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
                File.Exists(PropertyClass.ServiceMonitorFilePath).Should().BeTrue("Service Moniter Zip file is not downloaded");
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
            _loginPage.DCPLink.Click();
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
                File.Exists(PropertyClass.DCPFilePath).Should().BeTrue("Dcp zip file is not downloaded\n");
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
            _loginPage.AdministratorsGuidePDFLink.Click();
        }

        [Then(@"Administrator Guide PDF opens in browser")]
        public void ThenAdministratorGuidePDFOpensInBrowser()
        {
            // handler for the new tab
            var popup = PropertyClass.Driver.WindowHandles[1];

            // checking if new tab was opened
            string.IsNullOrEmpty(popup).Should().BeFalse("PDF is not opened in new tab");

            // Switch to new tab.
            PropertyClass.Driver.SwitchTo().Window(popup);
            
            PropertyClass.Driver.Url.Should().BeEquivalentTo(LoginPage.ExpectedValues.AdminstartorsGuidePDFURL, "Administator guide PDF is not opened");
        }

        [When(@"user clicks Instructions for Use")]
        public void WhenUserClicksInstructionsForUse()
        {
            _loginPage.InstructionForUsePDFLink.Click();
        }

        [Then(@"Instructions for Use PDF opens in browser")]
        public void ThenInstructionsForUsePDFOpensInBrowser()
        {
            // handler for the new tab
            var popup = PropertyClass.Driver.WindowHandles[1];

            // check if new tab was opened
            string.IsNullOrEmpty(popup).Should().BeFalse("New tab is not opened");

            // Switch to new tab.
            PropertyClass.Driver.SwitchTo().Window(popup); 
            
            PropertyClass.Driver.Url.Should().BeEquivalentTo(LoginPage.ExpectedValues.InstructionForUsePDFURL, "Instructions for use PDF is not opened");
        }

        [When(@"user clicks Release Notes")]
        public void WhenUserClicksReleaseNotes()
        {
            _loginPage.ReleaseNotesPDFLink.Click();
        }

        [Then(@"Release Notes PDF opens in browser")]
        public void ThenReleaseNotesPDFOpensInBrowser()
        {
            // handler for the new tab
            var popup = PropertyClass.Driver.WindowHandles[1];

            // tab was opened
            string.IsNullOrEmpty(popup).Should().BeFalse("New tab is not opened");

            //Switch to new tab
            PropertyClass.Driver.SwitchTo().Window(popup);

            PropertyClass.Driver.Url.Should().BeEquivalentTo(LoginPage.ExpectedValues.RealeaseNotesPDFURL, "Release notes pdf is not opened");
        }
    }
}
