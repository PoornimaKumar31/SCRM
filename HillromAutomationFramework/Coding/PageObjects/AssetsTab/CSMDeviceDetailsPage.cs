using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace HillromAutomationFramework.Coding.PageObjects
{
    class CSMDeviceDetailsPage
    {
        public CSMDeviceDetailsPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        public static class Locators
        {
            //Editing device details
            public const string CSMDeviceEditButtonID = "csm-edit";
            public const string RoomFieldID = "room";
            public const string BedFieldID = "bed";
            public const string SaveButtonID = "save_device_detail";
            public const string CancelButtonID = "cancel_device_detail";
            public const string RoomAndBedDetailsID = "csm_room";
            public const string CSMDeviceID = "555566667777";
            public const string CSMID = "csm_asset_name";

            public const string AssetTagPopupID = "asset_tag_value";
            public const string FacilityPopupID = "facility_value";
            public const string LocationPopupID = "location_value";
            public const string EditLabelPopupID = "lbl_edit_asset_details";
            public const string RoomHintTextID = "lbl_room";
            public const string BedHintTextID = "lbl_bed";

            public const string AssetTagValueID = "csm_asset_tag";
            public const string FacilityValueID = "csm_facility";
            public const string LocationValueID = "csm_loc";

            //Log files
            public const string LogsTabID = "mat-tab-label-0-2";
            public const string LogFilesID = "logName";
            public const string LogsNextButtonID = "next";
            public const string LogsPreviousButtonID = "previous";
            public const string LogsPageNumberID = "pageNumber";
            public const string LogsPageRequestButtonID = "request-logs";
            public const string LogsPendingMessageXPath = "//*[@id=\"mat-tab-content-0-2\"]/div/div/c8y-hillrom-request-logs/div/div[3]/div[1]/div[1]";
            public const string LogsDescendingClassName = "col-md-4 descending";
            public const string LogsAscendingClassName = "col-md-4 ascending";
            public const string DateSortingID = "date";
            public const string LogDateClassName = "col-md-4";

            //Preventive maintenance
            public const string PMNameHeadngID = "lbl_name";
            public const string PMLastCalibrationHeadingId = "lbl_lastCalDate";
            public const string LastCalibrationDateID = "lastCalDate";
            public const string CalibrationOverDueArrowID = "icon_overdue";
            public const string CalibrationOverDueTextID = "cal_overdue";
            public const string CalenderXPath = "(//div[@class=\"col-xs-12\"])[3]";
            public const string LeftArrowXPath = "//*[@src=\"./icon_kbd_arrow_left.svg\"]";
            public const string RightArrowXPath = "//*[@src=\"./icon_kbd_arrow_right.svg\"]";
            public const string CurrentCalenderYearXPath = "//*[@src=\"./icon_kbd_arrow_left.svg\"]/parent::span/parent::div";
            public const string NextCalenderYearXPath = "//*[@src=\"./icon_kbd_arrow_right.svg\"]/parent::span/parent::div";
            public const string CalibrationOverDueDateID = "caldue_date";
            public const string PMTabID = "mat-tab-label-0-0";
            public const string HostControllerGraphicXPath = "//*[@class=\"col-xs-7\"]/span/img";
            public const string HostControllerID = "name";
            public const string PreventiveMaintenanceLabelID = "prev-maintenance";
            public const string PMSHeaderXPath = "//div[@id=\"lbl_name\"]/parent::div/div";
            public const string PMSRowXPath = "//div[@id='lastCalDate']/parent::div//div";
            public const string HostContollerColumnXPath = "//span[@id='name']/parent::div";
            public const string PreventiveMaintenanceID = "device-details";
            public const string AssetDetailsSummaryID = "csm_details_summary";

        }

        public static class ExpectedValues
        {
            public const string RequestLogButtonDisabledClassName = "requestLogsbtn disable";
            public const string NewRoomValue = "New Room";
            public const string NewBedValue = "New Bed";
            public const string UpdateRoomValue = "Update Room";
            public const string UpdateBedValue = "Update Bed";
            public const string RoomAndBedNotSet = "(not set)";
            public static string SortDecreasingIconURL = "url(\"" + PropertyClass.BaseURL + "/icon_sort_up.svg\")";
            public static string SortIncreasingIconURL = "url(\""+PropertyClass.BaseURL+"/icon_sort_down.svg\")";
            public static string PreviousDisableImageURL = PropertyClass.BaseURL+"/left_disabled.png";
            public static string PreviousEnableImageURL = PropertyClass.BaseURL+"/icon_page_previous.svg";
            public static string NextDisableImageURL = PropertyClass.BaseURL+"/right_disabled.png";
            public static string NextEnableImageURL = PropertyClass.BaseURL+"/icon_page_next.svg";

            public const string SerialNumberwithRoomAndBed = "100010000005";

            //Preventive maintainenece
            public const string PMNameHeadingText = "Name";
            public const string PMLastCalibrationText = "Last calibration";

        }

        [FindsBy(How = How.Id, Using = Locators.AssetDetailsSummaryID)]
        public IWebElement AssetDetailsSummary { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PreventiveMaintenanceID)]
        public IWebElement PreventiveMaintenance { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CalibrationOverDueDateID)]
        public IWebElement CalibrationOverDueDate { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.NextCalenderYearXPath)]
        public IWebElement NextCalenderYear { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.CurrentCalenderYearXPath)]
        public IWebElement CurrentCalenderYear { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.RightArrowXPath)]
        public IWebElement RightArrow { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.LeftArrowXPath)]
        public IWebElement LeftArrow { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.CalenderXPath)]
        public IWebElement CalenderXP { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.HostContollerColumnXPath)]
        public IWebElement HostContollerColumn { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.PMSRowXPath)]
        public IList<IWebElement> PMSRow { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.PMSHeaderXPath)]
        public IList<IWebElement> PMSHeader { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.HostControllerGraphicXPath)]
        public IWebElement HostControllerGraphic { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PreventiveMaintenanceLabelID)]
        public IWebElement PreventiveMaintenanceLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.HostControllerID)]
        public IWebElement HostController { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PMTabID)]
        public IWebElement PMTab { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CSMDeviceID)]
        public IList<IWebElement> CSMDevices { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CSMID)]
        public IWebElement CSM { get; set; }

        [FindsBy(How = How.Id, Using = Locators.AssetTagValueID)]
        public IWebElement AssetTagValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.FacilityValueID)]
        public IWebElement FacilityValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LocationValueID)]
        public IWebElement LocationValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.RoomHintTextID)]
        public IWebElement RoomHintText { get; set; }

        [FindsBy(How = How.Id, Using = Locators.BedHintTextID)]
        public IWebElement BedHintText { get; set; }

        [FindsBy(How = How.Id, Using = Locators.AssetTagPopupID)]
        public IWebElement AssetTagPopup { get; set; }

        [FindsBy(How = How.Id, Using = Locators.FacilityPopupID)]
        public IWebElement FacilityPopup { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LocationPopupID)]
        public IWebElement LocationPopup { get; set; }

        [FindsBy(How = How.Id, Using = Locators.EditLabelPopupID)]
        public IWebElement EditLabelPopup { get; set; }

        //Device details related
        [FindsBy(How = How.Id, Using = Locators.CSMDeviceEditButtonID)]
        public IWebElement CSMDeviceEditButton { get; set; }

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



        //Preventive maintenance
        [FindsBy(How = How.Id, Using = Locators.PMNameHeadngID)]
        public IWebElement PMNameHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PMLastCalibrationHeadingId)]
        public IWebElement PMLastCalibrationHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LastCalibrationDateID)]
        public IWebElement LastCalibrationDate { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CalibrationOverDueArrowID)]
        public IWebElement CalibrationOverDueArrow { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CalibrationOverDueTextID)]
        public IWebElement CalibrationOverDueText { get; set; }


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
            Thread.Sleep(3000);
            LogsPreviousButton.Click();
            Thread.Sleep(3000);
            IList<IWebElement> LogDateListPreviousPage = LogDateList;
            LastElementPreviousPage = DateTime.Parse(LogDateListPreviousPage[n].Text);
            LogsNextButton.Click();
            Thread.Sleep(3000);

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
