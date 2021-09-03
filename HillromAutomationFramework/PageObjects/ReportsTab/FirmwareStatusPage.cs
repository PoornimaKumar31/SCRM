using HillromAutomationFramework.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FluentAssertions;

namespace HillromAutomationFramework.PageObjects
{
    class FirmwareStatusPage
    {
        public static class Locators
        {
            //Firmware status
            public const string InformationButtonId = "fs-info";
            public const string InformationPopUpId = "myHelp";
            public const string InformationPopUpHeaderClassName = "heading";
            public const string InformationPopUpCloseButtonclassName = "ok";
            public const string InformationPopUpDataClassName = "para";
            public const string StatusLabelClassName = "key";
            public const string FirmwareReportTitleID = "reportTitleHeader";
            public const string PrintButtonID = "fs-print";
            public const string DownloadButtonID = "fs-download";
            public const string SearchBoxID = "search";

            //Firmware Upgrade status(CSM) table elements
            public const string SerialNumberHeadingID = "serialNo";
            public const string FirmwareVerionHeadingID = "firmVer";
            public const string LocationHeadingID = "loc";
            public const string StatusHeadingID = "status";
            public const string LastDeployedHeadingID = "lastDeploy";
            public const string LastConnectedHeadingID = "lastConnect";
            public const string TableHeaderClassName = "device-info-list";

            //pagination
            public const string PaginationNextIconID = "next";
            public const string PaginationPreviousIconID = "previous";
            public const string PaginationXofYClassName = "paginationMessage";
            public const string PaginationDisplayXYClassName = "dataTables_info";


            //Search Column Elements
            public const string ColumnCommonXpath = "//div[@class='measurements']/div/div";
        }
        public static class ExpectedValues
        {
            public const string FirmwareUpgradeStatusCSMLabel = "FIRMWARE UPGRADE STATUS (CSM)";
            public const string FirmwareUpgradeStatusRV700Label = "FIRMWARE UPGRADE STATUS (RV700)";
            public const string FirmwareUpgradeStatusCentrellaLabel = "FIRMWARE UPGRADE STATUS (CENTRELLA)";

            //Firmware Upgrade status(CSM) table elements
            public const string SerialNumberHeadingText = "Serial number";
            public const string FirmwareVesrionHeadingText = "Firmware version";
            public const string LocationHeadingText = "Location";
            public const string StatusHeadingText = "Status";
            public const string LastDeployedHeadingText = "Last deployed";
            public const string LastConnectedHeadingText = "Last connected";

            //Firmware status
            public const string CSMDeviceName = "Connex Spot Monitor (CSM)";
            public const string RV700DeviceName = "RetinaVue 700 (RV700)";
            public const string Firmware = "Firmware Status";
            public const string CSMFirmwareStatusReportName = "Firmware_Status_Report.csv";
            public const string RV700FirmwareStatusReportName = "Firmware_Status_Report.csv";
            public const string CentrellaFirmwareStatusReportName = "Firmware_Status_Report.csv";
            
           



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

            //Centrella Status information
            public const string CentrellaInformationPopUpHeaderText = "Centrella Firmware Report Statuses:";
            public const string CentrellaStartedDefination = "A request has been sent to update the firmware on the bed.";
            public const string CentrellaDownloadingDefination = "The firmware is downloading on the bed.";
            public const string CentrellaStagingDefination = "The firmware is distributing to the boards.";
            public const string CentrellaStagingCompleteDefination = "The boards have received the firmware.";
            public const string CentrellaTogglingDefination = "The bed is updating to the new firmware.";
            public const string CentrellaTogglingCompleteDefination = "The firmware update is complete. A bed restart is required to apply the new firmware.";
            public const string CentrellaUpgradeSuccessDefination = "The bed successfully updated to the new firmware.";
            public const string CentrellaDownloadFailureDefination = "A failure occurred when downloading the firmware.";
            public const string CentrellaStagingFailureDefination = "A failure occurred when distributing the firmware to the boards.";
            public const string CentrellaStagingInconsistentDefination = "The downloaded firmware and boards are inconsistent. Bed features may not work as expected.";
            public const string CentrellaToggeleFailureDefination = "A failure occurred during the new firmware application to boards.";

            //Centrella Search Text
            public const string CentrellaSerialNumberSearchText = "PY673002";
            public const string CentrellaFirmwareVersionSearchText = "1.33.006";
            public const string CentrellaStatusSearchText = "Started";
            public const string CentrellaLocationSearchText = "Batesville";
            public const string CentrellaLastDeployedSearchText = "1.36.00";

            //CSMSearch Text
            public const string CSMSerialNumberSearchText = "100010000000";
            public const string CSMFirmwareVersionSearchText = "1.00.00-A0001";
            public const string CSMStatusSearchText = "Scheduled";
            public const string CSMLocationSearchText = "Station2";
            public const string CSMLastDeployedSearchText = "1.52.00-A0002";
        }

        public FirmwareStatusPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        [FindsBy(How = How.Id, Using = Locators.FirmwareReportTitleID)]
        public IWebElement FirmwareReportTitle { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PrintButtonID)]
        public IWebElement PrintButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DownloadButtonID)]
        public IWebElement DownloadButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SearchBoxID)]
        public IWebElement SearchBox { get; set; }

        //Pagination
        [FindsBy(How = How.Id, Using = Locators.PaginationPreviousIconID)]
        public IWebElement PaginationPreviousIcon { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PaginationNextIconID)]
        public IWebElement PaginationNextIcon { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.PaginationXofYClassName)]
        public IWebElement PaginationXofY { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.PaginationDisplayXYClassName)]
        public IWebElement PaginationDisplayXY { get; set; }

        //Firmware Upgrade status table elements
        [FindsBy(How = How.Id, Using = Locators.SerialNumberHeadingID)]
        public IWebElement SerialNumberHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.FirmwareVerionHeadingID)]
        public IWebElement FirmwareVerionHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LocationHeadingID)]
        public IWebElement LocationHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.StatusHeadingID)]
        public IWebElement StatusHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LastDeployedHeadingID)]
        public IWebElement LastDeployedHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LastConnectedHeadingID)]
        public IWebElement LastConnectedHeading { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.TableHeaderClassName)]
        public IWebElement TableHeader { get; set; }

        //Firmware status
        [FindsBy(How = How.Id, Using = Locators.InformationPopUpId)]
        public IWebElement InformationPopUp { get; set; }

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


        /// <summary>
        /// Split the data from the information table into status and defination.
        /// </summary>
        /// <param name="statusData">string with all status and its defination</param>
        /// <returns>Dictionary of status and defination pair</returns>

        public IDictionary<string, string> GetstatusTable(string statusData)
        {
            string[] splitRowdata = statusData.Split("\r\n");
            IDictionary<string, string> statusDefinationPairs = new Dictionary<string, string>();
            for (int row = 0; row <= splitRowdata.Length - 1; row++)
            {
                string ele = splitRowdata[row];
                string label = GetStatusLabel(row);
                string stat = ele.Substring(0, label.Length);
                string defination = ele[label.Length..];
                statusDefinationPairs.Add(stat, defination.Trim());
            }
            return (statusDefinationPairs);
        }
        /// <summary>
        /// Gets the the status label of spefied row.
        /// </summary>
        /// <param name="row">Row number</param>
        /// <returns>Status</returns>
        public string GetStatusLabel(int row)
        {
            return (StatusLabel[row].Text);
        }

        /// <summary>
        /// Get Data from the respecive column
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns>List of data present in respective column</returns>
        public List<string> GetColumnData(string columnName)
        {
            //Getting columnHeading
            IList<IWebElement> columnList;
            columnList= TableHeader.FindElements(By.TagName("div"));

            //Getting index of the column
            List<string> columnHeadingList = (columnList.Select(column => column.Text.ToLower())).ToList();
        
            //Check if column is present in the 
            columnHeadingList.Should().Contain(columnName.ToLower(), columnName + " is a invalid column heading.");

            int columnIndex = columnHeadingList.IndexOf(columnName.ToLower())+1;

            //Check if any device match the search result
            int searchMatchCount;
            try
            {
                searchMatchCount = (PropertyClass.Driver.FindElements(By.XPath(Locators.ColumnCommonXpath + "[" + columnIndex + "]"))).Count;
            }
            catch(Exception)
            {
                searchMatchCount = 0;
            }
           
            searchMatchCount.Should().BeGreaterThan(0, "Atleast one search Result should match the search by " +columnName);

            //Getting column Data
            List<string> columnDataList = new List<string>();

            columnList = PropertyClass.Driver.FindElements(By.XPath(Locators.ColumnCommonXpath + "[" + columnIndex + "]"));
            columnDataList.AddRange(columnList.Select(rowData => rowData.Text.ToLower()));
            return (columnDataList);
        }
    }
}
