using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using HillromAutomationFramework.Hooks;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class DownloadSoftwareAndPDFSteps
    {
        LoginPage loginPage = new LoginPage();
        [When(@"user click on PartnerConnect™")]
        public void WhenUserClickOnPartnerConnect()
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
        
        [When(@"user click on Service Monitor")]
        public void WhenUserClickOnServiceMonitor()
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
        
        [When(@"user click on DCP")]
        public void WhenUserClickOnDCP()
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
        
        [When(@"user click on Administrator's Guide")]
        public void WhenUserClickOnAdministratorSGuide()
        {
            loginPage.AdministratorsGuidePDFLink.Clicks();
        }
        
        [When(@"user click on Instructions for Use")]
        public void WhenUserClickOnInstructionsForUse()
        {
            loginPage.InstructionForUsePDFLink.Clicks();
        }
        
        [When(@"user click on Release Notes")]
        public void WhenUserClickOnReleaseNotes()
        {
            loginPage.ReleaseNotesPDFLink.Click();
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
        
        [Then(@"redirect to Administrator's Guide PDF page")]
        public void ThenRedirectToAdministratorSGuidePDFPage()
        {
            var popup = PropertyClass.Driver.WindowHandles[1]; // handler for the new tab
            Assert.IsTrue(!string.IsNullOrEmpty(popup)); // checking if new tab was opened
            PropertyClass.Driver.SwitchTo().Window(popup); // Switch to new tab.
            Assert.AreEqual(LoginPage.ExpectedValues.AdminstartorsGuidePDFURL, PropertyClass.Driver.Url);
            // Delay to load pdf completely
            Thread.Sleep(500);
            Hooks1.CaptureNow();
        }
        
        [Then(@"redirect to Instructions for Use PDF page")]
        public void ThenRedirectToInstructionsForUsePDFPage()
        {
            var popup = PropertyClass.Driver.WindowHandles[1]; // handler for the new tab
            Assert.IsTrue(!string.IsNullOrEmpty(popup)); // check if new tab was opened
            PropertyClass.Driver.SwitchTo().Window(popup); // Switch to new tab.
            Assert.AreEqual(LoginPage.ExpectedValues.InstructionForUsePDFURL, PropertyClass.Driver.Url);
            //To load pdf completely and taking the screenshot
            Thread.Sleep(500);
            Hooks1.CaptureNow();
        }
        
        [Then(@"redirect to Release Notes PDF page")]
        public void ThenRedirectToReleaseNotesPDFPage()
        {
            var popup = PropertyClass.Driver.WindowHandles[1]; // handler for the new tab
            Assert.IsTrue(!string.IsNullOrEmpty(popup)); // tab was opened
            PropertyClass.Driver.SwitchTo().Window(popup); //Switch to new tab
            Assert.AreEqual(LoginPage.ExpectedValues.RealeaseNotesPDFURL, PropertyClass.Driver.Url);
            //To load pdf completely and taking the screenshot
            Thread.Sleep(500);
            Hooks1.CaptureNow();
        }
    }
}
