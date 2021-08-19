using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HillromAutomationFramework.Coding.PageObjects
{
    class RV700DeviceDetailsPage
    {
        public static class Locators
        {
            //Editing device details
            public const string EditButtonID = "rv700-edit";
            public const string RoomFieldID = "room";
            public const string BedFieldID = "bed";
            public const string SaveButtonID = "save_device_detail";
            public const string CancelButtonID = "cancel_device_detail";
            public const string RoomAndBedDetailsID = "rv700_room";
            public const string RV700DeviceID = "555566667777";

            //Log files
            public const string LogsTabID = "mat-tab-label-0-1";
            public const string LogFilesID = "logName";
            public const string LogsNextButtonID = "next";
            public const string LogsPreviousButtonID = "previous";
            public const string LogsPageNumberID = "pageNumber";
            public const string LogsPageRequestButtonID = "request-logs";
            public const string LogsPendingMessageXPath = "//*[@id=\"mat-tab-content-0-1\"]/div/div/c8y-hillrom-request-logs/div/div[3]/div[1]/div[1]";
            public const string LogsDescendingClassName = "col-md-4 descending";
            public const string LogsAscendingClassName = "col-md-4 ascending";
            public const string DateSortingID = "date";
            public const string LogDateClassName = "col-md-4";

            //Component Information
            public const string ComponentInformationTabXpath = "//div[contains(text(),'Component information')]";
            public const string SummarySectionID = "rv700_details_summary";
            public const string AssetDetailsSubSectionId = "device-details";

            //connex device
            public const string DeviceNameXpath = "//div[@id='firm_version']/parent::div/div[1]";
            public const string FirmwareVersionXpath = "//div[@id='firm_version']";
            public const string SerialNumberXpath = "//div[@id='firm_version']/parent::div/div[5]";

            //Newmar
            public const string NewMarNameId = "newmar";
            public const string NewMarFirmwareVersionID = "newmar_firm_version";
            public const string NewMarSerialNumberXpath = "//div[@id='newmar_firm_version']/parent::div/div[5]";
            public const string NewMarToggleArrowId = "radio";
            public const string NewMarMACAddressLabelID = "lbl_newmar_mac";
            public const string NewMarMACAddresValueId = "newmar_mac";
            public const string NewMarIPAdressLabelId = "lbl_newmar_ip";
            public const string NewMarIPAdressValueId = "newmar_ip";
            public const string NewMarRSSILabelId = "lbl_newmar_rssi";
            public const string NewMarRSSIValueId = "newmar_rssi";
            public const string NewMarGUIDLabelXpath = "//div[@id='radioMetrics']/div[1]/div[1]";
            public const string NewMarGUIDValueXpath = "//div[@id='radioMetrics']/div[1]/div[2]";

            //summary section
            public const string RV700ImageId = "rv700_img";
            //labels
            public const string SummaryAssetNameLabelID = "rv700_lbl_asset_name";
            public const string SummarySerialNumberLabelID = "rv700_lbl_serial";
            public const string SummaryModelNumberLabelID = "rv700_lbl_model";
            public const string SummaryFacilityLabelID = "rv700_lbl_facility";
            public const string SummaryLocationLabelID = "rv700_lbl_loc";
            public const string SummaryRoomBedLabelID = "rv700_lbl_room";
            public const string SummaryLastFirmwareDeployedLabelID = "rv700_lbl_last";
            public const string SummaryAssetTagLabelID = "rv700_lbl_asset_tag";
            public const string SummaryIPAddressLabelID = "rv700_lbl_ip";
            public const string SummaryRadioMACAddressLabelId = "rv700_lbl_radio_mac";
            public const string SummaryRadioIPAddressLabelId = "rv700_lbl_radio_ip";
            public const string SummaryLabelConnectionStatusLabelId = "rv700_lbl_connection";
            public const string SummaryLastConfigurationLabelId = "rv700_lbl_config";

            //values
            public const string SummaryAssetNameValueID = "rv700_asset_name";
            public const string SummarySerialNumberValueID = "rv700_serial";
            public const string SummaryModelValueID = "rv700_model";
            public const string SummaryFacilityValueID = "rv700_facility";
            public const string SummaryLocationValueID = "rv700_loc";
            public const string SummaryRoomBedValueID = "rv700_room";
            public const string SummaryLastFirmwareDeployedValueID = "rv700_last";
            public const string SummaryAssetTagValueID = "rv700_asset_tag";
            public const string SummaryIPAddressValueID = "rv700_ip";
            public const string SummaryRadioMACAddressValueID = "rv700_radio_mac";
            public const string SummaryRadioIPAddressValueID = "rv700_radio_ip";
            public const string SummaryConnectionStatusValueID = "rv700_connection";
            public const string SummaryLastConfigurationDeployedValueID = "rv700_config";
        }

        public static class ExpectedValues
        {
            public const string NewRoomValue = "New Room";
            public const string NewBedValue = "New Bed";
            public const string UpdateRoomValue = "Update Room";
            public const string UpdateBedValue = "Update Bed";
            public const string RoomAndBedNotSet = "(not set)";                                                                              
            public static string SortDecreasingIconURL = "url(\""+PropertyClass.BaseURL+"/icon_sort_up.svg\")";
            public static string SortIncreasingIconURL = "url(\""+ PropertyClass.BaseURL+"/icon_sort_down.svg\")";
            public static string PreviousDisableImageURL = PropertyClass.BaseURL + "/left_disabled.png";
            public static string PreviousEnableImageURL = PropertyClass.BaseURL + "/icon_page_previous.svg";
            public static string NextDisableImageURL = PropertyClass.BaseURL + "/right_disabled.png";
            public static string NextEnableImageURL = PropertyClass.BaseURL+"/icon_page_next.svg";
        }

        public RV700DeviceDetailsPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        [FindsBy(How = How.Id, Using = Locators.RV700DeviceID)]
        public IList<IWebElement> RV700Devices { get; set; }

        //Device details related
        [FindsBy(How = How.Id, Using = Locators.EditButtonID)]
        public IWebElement EditButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.RoomFieldID)]
        public IWebElement RoomField { get; set; }

        [FindsBy(How = How.Id, Using = Locators.BedFieldID)]
        public IWebElement BedField { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SaveButtonID)]
        public IWebElement SaveButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CancelButtonID)]
        public IWebElement CancelButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.RoomAndBedDetailsID)]
        public IWebElement RoomAndBedDetails { get; set; }

        //Log files related
        [FindsBy(How = How.Id, Using = Locators.LogsTabID)]
        public IWebElement LogsTab { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LogFilesID)]
        public IList<IWebElement> LogFiles { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LogsNextButtonID)]
        public IWebElement LogsNextButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LogsPreviousButtonID)]
        public IWebElement LogsPreviousButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LogsPageNumberID)]
        public IWebElement LogsPageNumber { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LogsPageRequestButtonID)]
        public IWebElement LogsRequestButton { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.LogsPendingMessageXPath)]
        public IWebElement LogsPendingMessage { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DateSortingID)]
        public IWebElement DateSorting { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.LogDateClassName)]
        public IList<IWebElement> LogDateList { get; set; }

        //Component Information
        [FindsBy(How =How.XPath,Using =Locators.ComponentInformationTabXpath)]
        public IWebElement ComponentInformationTab { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SummarySectionID)]
        public IWebElement SummarySection { get; set; }

        [FindsBy(How = How.Id, Using = Locators.AssetDetailsSubSectionId)]
        public IWebElement AssetDetailsSubSection { get; set; }


        //connex device
        [FindsBy(How = How.XPath, Using = Locators.FirmwareVersionXpath)]
        public IWebElement FirmwareVersion { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.DeviceNameXpath)]
        public IWebElement DeviceName { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.SerialNumberXpath)]
        public IWebElement SerialNumber { get; set; }

        //Newmar
        [FindsBy(How = How.Id, Using = Locators.NewMarNameId)]
        public IWebElement NewMarName { get; set; }

        [FindsBy(How = How.Id, Using = Locators.NewMarFirmwareVersionID)]
        public IWebElement NewMarFirmwareVersion { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.NewMarSerialNumberXpath)]
        public IWebElement NewMarSerialNumber { get; set; }

        [FindsBy(How = How.Id, Using = Locators.NewMarToggleArrowId)]
        public IWebElement NewMarToggleArrow { get; set; }

        [FindsBy(How = How.Id, Using = Locators.NewMarMACAddressLabelID)]
        public IWebElement NewMarMACAddressLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.NewMarMACAddresValueId)]
        public IWebElement NewMarMACAddresValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.NewMarIPAdressLabelId)]
        public IWebElement NewMarIPAdressLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.NewMarIPAdressValueId)]
        public IWebElement NewMarIPAdressValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.NewMarRSSILabelId)]
        public IWebElement NewMarRSSILabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.NewMarRSSIValueId)]
        public IWebElement NewMarRSSIValue { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.NewMarGUIDLabelXpath)]
        public IWebElement NewMarGUIDLabel { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.NewMarGUIDValueXpath)]
        public IWebElement NewMarGUIDValue { get; set; }


        //Summary section
        [FindsBy(How = How.Id, Using = Locators.RV700ImageId)]
        public IWebElement RV700Image { get; set; }

        //labels
        [FindsBy(How = How.Id, Using = Locators.SummaryAssetNameLabelID)]
        public IWebElement SummaryAssetNameLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SummarySerialNumberLabelID)]
        public IWebElement SummarySerialNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SummaryModelNumberLabelID)]
        public IWebElement SummaryModelNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SummaryFacilityLabelID)]
        public IWebElement SummaryFacilityLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SummaryLocationLabelID)]
        public IWebElement SummaryLocationLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SummaryRoomBedLabelID)]
        public IWebElement SummaryRoomBedLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SummaryLastFirmwareDeployedLabelID)]
        public IWebElement SummaryLastFirmwareDeployedLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SummaryAssetTagLabelID)]
        public IWebElement SummaryAssetTagLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SummaryIPAddressLabelID)]
        public IWebElement SummaryIPAddressLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SummaryRadioMACAddressLabelId)]
        public IWebElement SummaryRadioMACAddressLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SummaryRadioIPAddressLabelId)]
        public IWebElement SummaryRadioIPAddressLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SummaryLabelConnectionStatusLabelId)]
        public IWebElement SummaryLabelConnectionStatusLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SummaryLastConfigurationLabelId)]
        public IWebElement SummaryLastConfigurationLabel { get; set; }

        //Label values

        [FindsBy(How = How.Id, Using = Locators.SummaryAssetNameValueID)]
        public IWebElement SummaryAssetNameValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SummarySerialNumberValueID)]
        public IWebElement SummarySerialNumberValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SummaryModelValueID)]
        public IWebElement SummaryModelValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SummaryFacilityValueID)]
        public IWebElement SummaryFacilityValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SummaryLocationValueID)]
        public IWebElement SummaryLocationValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SummaryRoomBedValueID)]
        public IWebElement SummaryRoomBedValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SummaryLastFirmwareDeployedValueID)]
        public IWebElement SummaryLastFirmwareDeployedValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SummaryAssetTagValueID)]
        public IWebElement SummaryAssetTagValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SummaryIPAddressValueID)]
        public IWebElement SummaryIPAddressValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SummaryRadioMACAddressValueID)]
        public IWebElement SummaryRadioMACAddressValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SummaryRadioIPAddressValueID)]
        public IWebElement SummaryRadioIPAddressValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SummaryConnectionStatusValueID)]
        public IWebElement SummaryConnectionStatusValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SummaryLastConfigurationDeployedValueID)]
        public IWebElement SummaryLastConfigurationDeployedValue { get; set; }


        /// <summary>
        /// Function to get List of All Log Dates for device 
        /// </summary>
        /// <param name="n">Number of Logs</param>
        /// <returns>List<DateTime></returns>
        public List<DateTime> AllLogsDate(int n)
        {
            List<DateTime> AllDateList = new List<DateTime>();
            for (int page=1; page<=(n/10)+1; page++)
            {
                WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(LogsPageNumber, page.ToString()));
                foreach (IWebElement element in LogDateList)
                {
                    if (element.Text != "Date")
                    {
                        AllDateList.Add(DateTime.Parse(element.Text));
                    }
                }
                LogsNextButton.Click();  
            }
            return AllDateList;
        }


        /// <summary>
        /// Function to verify N newest Logs presence by comparing Last Log Date of Current page 
        /// with First Log Date of Next Page
        /// </summary>
        /// <param name="n">Expected Number of Logs</param>
        /// <returns>Boolean</returns>
        public bool NNewestLogsPresence(int n)
        {
            DateTime FirstElementLastPage;
            DateTime LastElementFirstPage;

            Thread.Sleep(3000);
            IList<IWebElement> LogDateListInitialPage = LogDateList;
            LastElementFirstPage = DateTime.Parse(LogDateListInitialPage[n].Text);
            int count = LogDateListInitialPage.Count - 1;
            Thread.Sleep(3000);
            LogsNextButton.Click();
            Thread.Sleep(3000);
            IList<IWebElement> LogDateListNextPage = LogDateList;
            FirstElementLastPage = DateTime.Parse(LogDateListNextPage[1].Text);
            LogsPreviousButton.Click();
            Thread.Sleep(3000);
            if (count.Equals(n))
            {
                if (LastElementFirstPage >= FirstElementLastPage)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }


        /// <summary>
        /// Function to verify N older Logs presence by comparing First Log Date of Current page 
        /// with Last Log Date of Next Page
        /// </summary>
        /// <param name="n">Expected Number of Logs</param>
        /// <returns>Boolean</returns>
        public bool NOlderLogsPresence(int n)
        {
            DateTime FirstElementCurrentPage;
            DateTime LastElementPreviousPage;

            Thread.Sleep(3000);
            IList<IWebElement> LogDateListCurrentPage = LogDateList;
            FirstElementCurrentPage = DateTime.Parse(LogDateListCurrentPage[1].Text);
            int count = LogDateListCurrentPage.Count - 1;
            Console.WriteLine("Current Page Logs : ");
            foreach (IWebElement a in LogDateListCurrentPage)
            {
                if (a.Text != "Date")
                {
                    Console.WriteLine(DateTime.Parse(a.Text));
                }
            }
            Thread.Sleep(3000);
            LogsPreviousButton.Click();
            Thread.Sleep(3000);
            IList<IWebElement> LogDateListPreviousPage = LogDateList;
            LastElementPreviousPage = DateTime.Parse(LogDateListPreviousPage[n].Text);
            Console.WriteLine("Previous Page Logs : ");
            foreach (IWebElement a in LogDateListPreviousPage)
            {
                if (a.Text != "Date")
                {
                    Console.WriteLine(DateTime.Parse(a.Text));
                }
            }
            LogsNextButton.Click();
            Thread.Sleep(3000);
            Console.WriteLine("Value :: " + FirstElementCurrentPage + " " + LastElementPreviousPage);
            Console.WriteLine(count);
            if (count.Equals(n))
            {
                if (FirstElementCurrentPage <= LastElementPreviousPage)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}
