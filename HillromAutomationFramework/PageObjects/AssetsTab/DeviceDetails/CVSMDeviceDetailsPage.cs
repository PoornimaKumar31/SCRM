using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

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

    }
}