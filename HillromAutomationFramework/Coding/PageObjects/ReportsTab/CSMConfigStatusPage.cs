using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace HillromAutomationFramework.Coding.PageObjects
{
    public class CSMConfigStatusPage
    {
        public static class Locators
        {
            public const string AssetTypeDropdownId = "modelFilter";
            public const string ReportTypeDropdownId = "typeFilter";
            public const string GetReportButtonId = "getReport";
            public const string DownloadButtonXpath = "//button[contains(text(),'Download')]";
            public const string InformationButtonId = "cu-info";
            public const string InformationPopUpId = "myHelp";
            public const string InformationPopUpHeaderClassName = "heading";
            public const string InformationPopUpCloseButtonclassName = "ok"; 
            public const string InformationPopUpDataClassName = "para";
            public const string StatusLabelClassName = "key";

            public const string ReportTitleID = "reportTitleHeader";
            public const string SearchBoxID = "search";
            public const string PrintButtonID = "cu-print";
            public const string PreviousPaginationIconID = "previous";
            public const string NextPaginationIconID = "next";
            public const string PageXOfYXpath = "//div[contains(text(),'Page')]";
            public const string PageDisplayClassName = "dataTables_info";

            //Configuration Update status(CSM) table elements
            public const string SerialNumberHeadingID = "serialNo";
            public const string ConfigurationHeadingID = "config";
            public const string LocationHeadingID = "loc";
            public const string StatusHeadingID = "status";
            public const string LastDeployedHeadingID = "lastDeployed";
            public const string LastConnectedHeadingID = "lastConnected";
            public const string TableHeadingClassName = "device-info-list";
        }
        public static class ExpectedValues
        {
            public const string ConfigurationUpdateStatusCSMLabelText = "CONFIGURATION UPDATE STATUS (CSM)";


            public const string CSMConfigurationStatusReportFileName = "Configuration_Update_Status_Report_(CSM).csv";

            public const string CSMDeviceName = "Connex Spot Monitor (CSM)";
            public const string CSMConfigurationReport = "CFG Update Status";
            public const string CSMFirmwareStatusReport = "Firmware Status";
            public const string CSMActivityReport = "Activity";
            public const string CSMActivityReportName = "Activity_Status_Report_(CSM).csv";
            //status heading
            public const string InformationPopUPHeaderText = "CSM Configuration Report Statuses:";
            public const string StratedDefinition = "Configuration update has been initiated.";
            public const string TransferredDefinitation = "Configuration update has been transferred.";
            public const string AvailableDefinitation = "Configuration update has been received by Service Monitor and is waiting for device to call home.";
            public const string AppliedDefinitation = "Configuration update successful. Device is currently using the new configuration.";
            public const string FailedDefinition = "Configuration update aborted. Check logs for details.";

            //Configuration Update status(CSM) table elements
            public const string SerialNumberHeadingText = "Serial number";
            public const string ConfigurationHeadingText = "Configuration";
            public const string LocationHeadingText = "Location";
            public const string StatusHeadingText = "Status";
            public const string LastDeployedHeadingText = "Last deployed";
            public const string LastConnectedHeadingText = "Last connected";
        }

        public CSMConfigStatusPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        [FindsBy(How = How.Id, Using = Locators.SearchBoxID)]
        public IWebElement SearchBox { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ReportTitleID)]
        public IWebElement ReportTitle { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PrintButtonID)]
        public IWebElement PrintButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PreviousPaginationIconID)]
        public IWebElement PreviousPaginationIcon { get; set; }

        [FindsBy(How = How.Id, Using = Locators.NextPaginationIconID)]
        public IWebElement NextPaginationIcon { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.PageXOfYXpath)]
        public IWebElement PageXOfY { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.PageDisplayClassName)]
        public IWebElement PageDisplay { get; set; }

        //Configuration Update status(CSM) table elements
        [FindsBy(How = How.Id, Using = Locators.SerialNumberHeadingID)]
        public IWebElement SerialNumberHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ConfigurationHeadingID)]
        public IWebElement ConfigurationHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LocationHeadingID)]
        public IWebElement LocationHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.StatusHeadingID)]
        public IWebElement StatusHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LastDeployedHeadingID)]
        public IWebElement LastDeployedHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LastConnectedHeadingID)]
        public IWebElement LastConnectedHeading { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.TableHeadingClassName)]
        public IWebElement TableHeading { get; set; }

        //information and status

        [FindsBy(How = How.Id, Using = Locators.InformationPopUpId)]
        public IWebElement InformationPopUp { get; set; }

        [FindsBy(How = How.Id, Using = Locators.AssetTypeDropdownId)]
        public IWebElement AssetTypeDropdown { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ReportTypeDropdownId)]
        public IWebElement ReportTypeDropdown { get; set; }

        [FindsBy(How = How.Id, Using = Locators.GetReportButtonId)]
        public IWebElement GetReportButton { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.DownloadButtonXpath)]
        public IWebElement DownloadButton { get; set; }

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

        public IDictionary<string,string> GetstatusTable(string statusData)
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
