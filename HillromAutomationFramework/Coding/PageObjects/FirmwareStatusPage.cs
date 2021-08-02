using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HillromAutomationFramework.Coding.PageObjects
{
    class FirmwareStatusPage
    {
        public static class Locators
        {
            public const string AssetTypeDropdownId = "modelFilter";
            public const string ReportTypeDropdownId = "typeFilter";
            public const string GetReportButtonId = "getReport";
            public const string InformationButtonId = "fs-info";
            public const string InformationPopUpId = "myHelp";
            public const string InformationPopUpHeaderClassName = "heading";
            public const string InformationPopUpCloseButtonclassName = "ok";
            public const string InformationPopUpDataClassName = "para";
            public const string StatusLabelClassName = "key";
        }
        public static class ExpectedValues
        {
            public const string CSMDeviceName = "Connex Spot Monitor (CSM)";
            public const string RV700DeviceName = "RetinaVue 700 (RV700)";
            public const string Firmware = "Firmware Status";
            public const string CSMFirmwareStatusReportName = "Firmware_Status_Report.csv";
            public const string RV700FirmwareStatusReportName = "Firmware_Status_Report.csv";



            //CSM firmware status information
            public const string CSMInformationPopUPHeaderText = "CSM Firmware Report Statuses:";
            public const string CSMStratedDefinition = "Firmware update has been initiated.";
            public const string CSMAvailableDefination = "Firmware update has been received by Service Monitor and is waiting for device to call home.";
            public const string CSMDownloadingDefination = "Firmware update is actively downloading to the device.";
            public const string CSMDownloadedDefination = "New firmware is available on the device.";
            public const string CSMScheduledDefination = "Firmware update is downloaded to the device, and awaiting scheduled time to apply the update.";
            public const string CSMUpdatingDefination = "Device is currently installing the new firmware.";
            public const string CSMAppliedDefination = "Firmware update successful. Device is currently running the new firmware.";
            public const string CSMCancelRequestedDefination = "Cancelation of the Firmware update has been requested.";
            public const string CSMCancelingDefination = "Cancelation of the Firmware update has been received and is awaiting device confirmation.";
            public const string CSMDownloadFailedDefination = "Download of Firmware update to the device has failed. Download will attempt again at next call home.";
            public const string CSMFailedDefination = "Firmware update aborted. Check device log for details.";

            //RV700 status information
            public const string RV700InformationPopUPHeaderText = "RV700 Firmware Report Statuses:";
            public const string RV700StratedDefinition = "Firmware update has been initiated.";
            public const string RV700AvailableDefination = "Firmware update has been deployed and is waiting for device to call home.";
            public const string RV700CompleteDefination = "Device firmware upgrade is complete.";
            public const string RV700FailureDefination = "Device firmware upgrade has failed.";
        }

        public FirmwareStatusPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        [FindsBy(How = How.Id, Using = Locators.InformationPopUpId)]
        public IWebElement InformationPopUp { get; set; }

        [FindsBy(How = How.Id, Using = Locators.AssetTypeDropdownId)]
        public IWebElement AssetTypeDropdown { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ReportTypeDropdownId)]
        public IWebElement ReportTypeDropdown { get; set; }

        [FindsBy(How = How.Id, Using = Locators.GetReportButtonId)]
        public IWebElement GetReportButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.InformationButtonId)]
        public IWebElement InformationButton { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.InformationPopUpHeaderClassName)]
        public IWebElement InformationPopUpHeader { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.InformationPopUpCloseButtonclassName)]
        public IWebElement InformationPopUpCloseButton { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.InformationPopUpDataClassName)]
        public IWebElement InformationPopUpData { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.StatusLabelClassName)]
        public IList<IWebElement> StatusLabel { get; set; }

        public IDictionary<string, string> GetstatusTable(string statusData)
        {
            string[] splitRowdata = statusData.Split("\r\n");
            IDictionary<string, string> statusDefinationPairs = new Dictionary<string, string>();
            for (int row = 0; row <= splitRowdata.Length - 1; row++)
            {
                string ele = splitRowdata[row];
                string label = GetStatusLabel(row);
                string stat = ele.Substring(0, label.Length);
                string defination = ele.Substring(label.Length);
                statusDefinationPairs.Add(stat, defination.Trim());
            }
            return (statusDefinationPairs);
        }

        public string GetStatusLabel(int row)
        {
            return (StatusLabel[row].Text);
        }
    }
}
