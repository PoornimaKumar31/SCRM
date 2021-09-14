using HillromAutomationFramework.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HillromAutomationFramework.PageObjects
{
    class CVSMDeviceDetailsPage
    {
        public static class Locators
        {
            //Editing device details
            public const string EditButtonID = "cvsm-edit";
            public const string EditAssetDetailsPopUpTitleID = "lbl_edit_asset_details";
            //Asset Tag
            public const string EditAssetDetailsPopUPAssetTagLabelID = "lbl_asset_tag";
            public const string EditAssetDetailsPopUPAssetTagValueID = "asset_tag_value";
            //Facility
            public const string EditAssetDetailsPopUPFacilityLabelID = "lbl_facility";
            public const string EditAssetDetailsPopUPFacilityValueID = "facility_value";
            //Location
            public const string EditAssetDetailsPopUPLocationLabelID = "lbl_location";
            public const string EditAssetDetailsPopUPLocationValueID = "location_value";

            public const string RoomLabelID = "lbl_room";
            public const string BedLabelID = "lbl_bed";
            public const string RoomFieldID = "room";
            public const string BedFieldID = "bed";
            public const string SaveButtonID = "save_device_detail";
            public const string CancelButtonID = "cancel_device_detail";
            public const string RoomAndBedDetailsID = "cvsm_room";
            public const string CVSMDeviceID = "555566667777";

            //Log files
            public const string LogsTabID = "mat-tab-label-0-2";
            public const string LogFilesID = "logName";
            public const string LogsNextButtonID = "next";
            public const string LogsPreviousButtonID = "previous";
            public const string LogsPageNumberID = "pageNumber";
            public const string LogsPageRequestButtonID = "request-logs";
            public const string LogsPendingMessageXPath = "//div[@class = 'col-xs-8']";
            public const string LogsDescendingClassName = "col-md-4 descending";
            public const string LogsAscendingClassName = "col-md-4 ascending";
            public const string DateSortingID = "date";
            public const string LogDateClassName = "col-md-4";
        }
        public static class ExpectedValues
        {
            public const string RequestLogButtonDisabledClassName = "requestLogsbtn disable";
            public const string EditAssetDetailsPopUpTitle = "EDIT ASSET DETAILS";
            public const string EditAssetDetailsPopUpAssetTagLabel = "Asset tag";
            public const string EditAssetDetailsPopUpFacilityLabel = "Facility";
            public const string EditAssetDetailsPopUpLocationLabel = "Location";
            public const string RoomLabelHintText = "Room";
            public const string BedLabelHintText = "Bed";

            public static string SortDecreasingIconURL = "url(\""+PropertyClass.BaseURL+"/icon_sort_up.svg\")";
            public static string SortIncreasingIconURL = "url(\""+PropertyClass.BaseURL+"/icon_sort_down.svg\")";
            public static string PreviousDisableImageURL = PropertyClass.BaseURL+"/left_disabled.png";
            public static string PreviousEnableImageURL = PropertyClass.BaseURL+"/icon_page_previous.svg";
            public static string NextDisableImageURL = PropertyClass.BaseURL+"/right_disabled.png";
            public static string NextEnableImageURL = PropertyClass.BaseURL+"/icon_page_next.svg";
        }

        public CVSMDeviceDetailsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = Locators.CVSMDeviceID)]
        public IList<IWebElement> CVSMDevices { get; set; }

        //Device details related
        [FindsBy(How = How.Id, Using = Locators.EditButtonID)]
        public IWebElement EditButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.EditAssetDetailsPopUpTitleID)]
        public IWebElement EditAssetDetailsPopUpTitle { get; set; }

        [FindsBy(How = How.Id, Using = Locators.EditAssetDetailsPopUPAssetTagLabelID)]
        public IWebElement EditAssetDetailsPopUPAssetTagLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.EditAssetDetailsPopUPAssetTagValueID)]
        public IWebElement EditAssetDetailsPopUPAssetTagValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.EditAssetDetailsPopUPFacilityLabelID)]
        public IWebElement EditAssetDetailsPopUPFacilityLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.EditAssetDetailsPopUPFacilityValueID)]
        public IWebElement EditAssetDetailsPopUPFacilityValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.EditAssetDetailsPopUPLocationLabelID)]
        public IWebElement EditAssetDetailsPopUPLocationLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.EditAssetDetailsPopUPLocationValueID)]
        public IWebElement EditAssetDetailsPopUPLocationValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.RoomLabelID)]
        public IWebElement RoomLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.BedLabelID)]
        public IWebElement BedLabel { get; set; }

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
            int count = LogDateListInitialPage.Count-1;
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