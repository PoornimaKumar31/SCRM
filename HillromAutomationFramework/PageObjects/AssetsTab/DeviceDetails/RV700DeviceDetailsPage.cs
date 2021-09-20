using HillromAutomationFramework.SupportingCode;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HillromAutomationFramework.PageObjects
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

            public const string LogsTabXpath = "//div[text()='Logs']";
            //Component Information
            public const string ComponentInformationTabXpath = "//div[contains(text(),'Component information')]";
            public const string SummarySectionID = "rv700_details_summary";
            public const string AssetDetailsSubSectionId = "device-details";

            //connex device
            public const string DeviceNameID = "device_name";
            public const string FirmwareVersionXpath = "//div[@id='firm_version']";
            public const string SerialNumberID = "serial_number";

            //Newmar
            public const string NewMarNameId = "newmar";
            public const string NewMarFirmwareVersionID = "newmar_firm_version";
            public const string NewMarSerialNumberID = "newmar_serial_number";
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

        public RV700DeviceDetailsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = Locators.LogsTabXpath)]
        public IWebElement LogsTab { get; set; }

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

        [FindsBy(How = How.Id, Using = Locators.DeviceNameID)]
        public IWebElement DeviceName { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SerialNumberID)]
        public IWebElement SerialNumber { get; set; }

        //Newmar
        [FindsBy(How = How.Id, Using = Locators.NewMarNameId)]
        public IWebElement NewMarName { get; set; }

        [FindsBy(How = How.Id, Using = Locators.NewMarFirmwareVersionID)]
        public IWebElement NewMarFirmwareVersion { get; set; }

        [FindsBy(How = How.Id, Using = Locators.NewMarSerialNumberID)]
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
    }
}
