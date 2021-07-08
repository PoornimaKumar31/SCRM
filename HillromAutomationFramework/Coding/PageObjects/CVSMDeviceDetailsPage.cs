using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HillromAutomationFramework.Coding.PageObjects
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
            public const string LogsPageNumberClassName = "pageNumber";
            public const string LogsPageRequestButtonID = "request-logs";
            public const string LogsPendingMessageXPath = "//*[@id=\"mat-tab-content-0-2\"]/div/div/c8y-hillrom-request-logs/div/div[3]/div[1]/div[1]";
            public const string LogsDescendingClassName = "col-md-4 descending";
            public const string LogsAscendingClassName = "col-md-4 ascending";
            public const string DateSortingID = "date";
        }
        public static class ExpectedValues
        {
            public const string EditAssetDetailsPopUpTitle = "EDIT ASSET DETAILS";
            public const string EditAssetDetailsPopUpAssetTagLabel = "Asset tag";
            public const string EditAssetDetailsPopUpFacilityLabel = "Facility";
            public const string EditAssetDetailsPopUpLocationLabel = "Location";
            public const string RoomLabelHintText = "Room";
            public const string BedLabelHintText = "Bed";

            public const string NewRoomValue = "New Room";
            public const string NewBedValue = "New Bed";
            public const string UpdateRoomValue = "Update Room";
            public const string UpdateBedValue = "Update Bed";
            public const string RoomAndBedNotSet = "(not set)";
        }

        public CVSMDeviceDetailsPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
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
        [FindsBy(How = How.XPath, Using = Locators.LogsTabID)]
        public IWebElement LogsTab { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LogFilesID)]
        public IList<IWebElement> LogFiles { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LogsNextButtonID)]
        public IWebElement LogsNextButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LogsPreviousButtonID)]
        public IWebElement LogsPreviousButton { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.LogsPageNumberClassName)]
        public IWebElement LogsCurrentPageNumber { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LogsPageRequestButtonID)]
        public IWebElement LogsRequestButton { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.LogsPendingMessageXPath)]
        public IWebElement LogsPendingMessage { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.DateSortingID)]
        public IWebElement DateSorting { get; set; }

    }
}
