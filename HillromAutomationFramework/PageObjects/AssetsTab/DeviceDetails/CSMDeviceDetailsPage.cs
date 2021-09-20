using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace HillromAutomationFramework.PageObjects
{
    class CSMDeviceDetailsPage
    {
        public CSMDeviceDetailsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
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
            

        }

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
    }
}
