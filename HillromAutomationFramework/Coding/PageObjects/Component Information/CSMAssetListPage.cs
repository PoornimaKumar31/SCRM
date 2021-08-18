using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HillromAutomationFramework.Coding.PageObjects.Component_Information
{
    public class CSMAssetListPage
    {
        public CSMAssetListPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        public class ExpectedValue
        {
            public const int UsageColumnIndex = 5;
        }


        public class Locator
        {
            public const string DeviceRowID = "555566667777";
            public const string CSMDetailsPageID = "device-main";
            public const string CSMDetailsSummaryID = "csm_details_summary";
            public const string EditButtonID = "csm-edit";
            public const string PreventiveMaintenanceTabXPath = "//div[text()=\"Preventive maintenance\"]";
            public const string ComponentInformationTabXPath = "//div[text()=\"Component information\"]";
            public const string LogsTabXPath = "//div[text()=\"Logs\"]";
            public const string AssetDetailsSubsectionID = "device-details";

            //Connex Spot Monitor
            public const string NameXPath = "//span[@id = \"lbl_total_run_time\"]//parent::div//parent::div/parent::div/div[1]";
            public const string SerialNumberXPath = "//span[@id = \"lbl_total_run_time\"]//parent::div//parent::div/parent::div/div[5]";
            public const string TotalRunTimeLabelID = "lbl_total_run_time";
            public const string TotalRunTimeValueID = "total_run_time";
            public const string RelativeElementXPath = "//span[@id = \"lbl_total_run_time\"]//parent::div//parent::div/parent::div/div";
            public const string UsageColumnXPath = "//span[@id = \"lbl_total_run_time\"]/parent::div/parent::div";

            //Battery
            public const string BatteryRowNameID = "hc_battery_name";
            public const string BatteryRowSerialNumberID = "hc_battery_serialNo";
            public const string BatteryRowManufactureDateID = "hc_battery_manufacture_date";
            public const string BatteryRowCycleCountID = "hc_battery_usage";
            public const string BatteryManufacturerDateLabelID = "lbl_hc_battery_date";
            public const string BatteryManufacturerDateValueID = "hc_battery_date";
            public const string BatterySerialNumberLabelID = "lbl_hc_battery_serial_no";
            public const string BatterySerialNumberValueID = "hc_battery_serial_no";
            public const string BatteryCycleCountLabelID = "lbl_hc_battery_cycle_count";
            public const string BatteryCycleCountValueID = "hc_battery_cycle_count";
            public const string BatteryRowToggelArrowID = "batteryPanasonic";
            public const string BatteryTemparatureValueID = "hc_battery_temp";
            public const string BatteryTemparatureLabelID = "lbl_hc_battery_temp";
            public const string BatteryRemainingCapacityValueID = "hc_battery_remain_cap";
            public const string BatteryRemainingCapacityLabelID = "lbl_hc_battery_remain_cap";
            public const string BatteryVoltageValueID = "hc_battery_voltage";
            public const string BatteryVoltageLabelID = "lbl_hc_battery_voltage";
            public const string BatteryFullChargeCapacityValueID = "hc_battery_full_cap";
            public const string BatteryFullChargeCapacityLabelID = "lbl_hc_battery_full_cap";
            public const string BatteryCurrentValueID = "hc_battery_current";
            public const string BatteryCurrentLabelID = "lbl_hc_battery_current";
            public const string BatteryDesignedCapacityValueID = "hc_battery_designed_cap";
            public const string BatteryDesignedCapacityLabelID = "lbl_hc_battery_designed_cap";
            public const string BatteryManufacturerNameValueID = "hc_battery_manu_name";
            public const string BatteryManufacturerNameLabelID = "lbl_hc_battery_manu_name";
            public const string BatteryModelNumberLabelID = "lbl_hc_battery_model";
            public const string BatteryModelNumberValueID = "hc_battery_model";
            public const string BatteryRelativeChildElementsXPath = "//div[@id = '" + BatteryRowCycleCountID + "']//parent::div/div";

            //Accessory Power Module
            public const string APMRowNameID = "";
            public const string APMBatteryRowNameID = "apm_battery_name";
            public const string APMBatteryRowManufacturerDateID = "apm_battery_manufacture";
            public const string APMBatteryRowSerialNumberID = "apm_battery_serailNo";
            public const string APMBatteryRowCycleCountID = "apm_usage";
            public const string APMBatteryRowToggleArrowID = "battery";
            public const string APMBatteryTemparatureLabelID = "lbl_apm_battery_temp";
            public const string APMBatteryTemparatureValueID = "apm_battery_temp";
            public const string APMBatteryVoltageLabelID = "lbl_apm_battery_voltage";
            public const string APMBatteryVoltageValueID = "apm_battery_voltage";
            public const string APMBatteryCurrentLabelID = "lbl_apm_battery_current";
            public const string APMBatteryCurrentValueID = "apm_battery_current";
            public const string APMBatteryRemainingCapacityLabelID = "lbl_apm_battery_remain_cap";
            public const string APMBatteryRemainingCapacityValueID = "apm_battery_remain_cap";
            public const string APMBatteryFullChargeCapacityLabelID = "lbl_apm_full_cap";
            public const string APMBatteryFullChargeCapacityValueID = "apm_full_cap";
            public const string APMBatteryCycleCountLabelID = "lbl_apm_cycle_count";
            public const string APMBatteryCycleCountValueID = "apm_cycle_count";
            public const string APMBatteryBatteryDesigedCapacityLabelID = "lbl_apm_battery_cap";
            public const string APMBatteryBatteryDesignedCapacityValueID = "apm_battery_cap";
            public const string APMBatteryManufactureDateLabelID = "lbl_apm_manufacture_date";
            public const string APMBatteryManufactureDateValueID = "apm_manufacture_date";
            public const string APMBatteryManufactureNameLabelID = "lbl_apm_manufacturer_name";
            public const string APMBatteryManufactureNameValueID = "apm_manufacturer_name";
            public const string APMBatterySerialNumberLabelID = "lbl_apm_serial_no";
            public const string APMBatterySerialNumberValueID = "apm_serial_no";
            public const string APMBatteryCombinedBatteryRemainingCapacityLabelID = "lbl_apm_combined_cap";
            public const string APMBatteryCombinedBatteryRemainingCapacityValueID = "apm_combined_cap";
            public const string APMBatteryModelNumberLabelID = "lbl_apm_model";
            public const string APMBatteryModelNumberValueID = "apm_model";
            public const string APMBatteryPICProcessorFirmwareVersionLabelID = "lbl_apm_pic_version";
            public const string APMBatteryPICProcessorFirmwareVersionValueID = "apm_pic_version";
            public const string APMRelativeElementXPath = "//div[@id = \"apm_usage\"]/parent::div/div";
            

            //NIBP
            public const string NIBPRowNameXPath = "//span[@id = \"nibp\"]//parent::div";
            public const string NIBPRowFirmwareVersionID = "nibp_firm_version";
            public const string NIBPRowHardwareVersionID = "nibp_hardware_version";
            public const string NIBPRowSerialNumberID = "nibp_serialNo";
            public const string NIBPRowCycleCountID = "nibp_usage";
            public const string NIBPRowToggleArrowID = "nibp";
            public const string NIBPLastCalibrationDateLabelID = "lbl_nibp_last_cal_date";
            public const string NIBPLastCalibrationDateValueID = "nibp_last_cal_date";
            public const string NIBPModuleCycleCountLabelID = "lbl_nibp_cycle_count";
            public const string NIBPModuleCycleCountValueID = "nibp_cycle_count";
            public const string NIBPCalibrationSignatureLabelID = "lbl_nibp_cal_signature";
            public const string NIBPCalibrationSignatureValueID = "nibp_cal_signature";
            public const string NIBPRelativeElementXPath = "//div[@id = \"nibp_usage\"]/parent::div/div"; 


            //Temparature Probe
            public const string TempProbeRowNameXPath = "//span[@id = \"tempprobe\"]//parent::div";
            public const string TempProbeRowSerialNumberID = "temp_probe_serialNo";
            public const string TempProbeRowCycleCountID = "temp_probe_usage";
            public const string TempProbeRowToggleArrowID = "tempprobe";
            public const string TempProbeTypeLabelID = "lbl_temp_probe_type";
            public const string TempProbeTypeValueID = "temp_probe_type";
            public const string TempProbeCycleCountLabelID = "lbl_temp_probe_cycle_count";
            public const string TempProbeCycleCountValueID = "temp_probe_cycle_count";
            public const string TempProbePartNumberLabelID = "lbl_temp_probe_part_no";
            public const string TempProbePartNumberValueID = "temp_probe_part_no";
            public const string TempProbeLotCodeLabelID = "lbl_temp_probe_lot_code";
            public const string TempProbeLotCodeValueID = "temp_probe_lot_code";
            public const string TempProbeLotSequenceNumberLabelID = "lbl_temp_probe_lot_no";
            public const string TempProbeLotSequenceNumberValueID = "temp_probe_lot_no";
            public const string TempProbeCalibrationDateLabelID = "lbl_temp_probe_cal_date";
            public const string TempProbeCalibrationDateValueID = "temp_probe_cal_date";
            public const string TempProbeCalibrationSignatureLabelID = "lbl_temp_probe_cal_sig";
            public const string TempProbeCalibrationSignatureValueID = "temp_probe_cal_sig";
            public const string TempProbeLastDeviceSerialNumberLabelID = "lbl_temp_probe_last_serial";
            public const string TempProbeLastDeviceSerialNumberValueID = "temp_probe_last_serial";
            public const string TempProbeNumberOfTimesProbeChangedLabelID = "lbl_temp_probe_change";
            public const string TempProbeNumberOfTimesProbeChangedValueID = "temp_probe_change";
            public const string TempProbeRelativeElementXPath = "//div[@id = \"temp_probe_usage\"]/parent::div/div";


            //SureTemp
            public const string SureTempNameXpath = "//div[@id = \"sure_temp_firm_version\"]//parent::div//div";
            public const string SureTempFirmwareVersionID = "sure_temp_firm_version";
            public const string SureTempHardwareVersionID = "sure_temp_hardware_version";
            public const string SureTempSerialNumberID = "temp_probe_serial_no";
            public const string SureTempCycleCountID = "sure_temp_usage";
            public const string SureTempRelativeElementXPath = "//div[@id = \"sure_temp_usage\"]/parent::div/div";


            //Spo2 Masimo
            public const string Spo2MasimoNameID = "spo2_name";
            public const string MasimoToggleArrowID = "spo2Sensor";
            public const string MasimoFirmwareVersionXPath = "//*[@id=\"csm-component-info-detail\"]/div/div/div[12]/div[2]";
            public const string MasimoHardwareVersionXPath = "//*[@id=\"csm-component-info-detail\"]/div/div/div[12]/div[3]";
            public const string MasimoSerialNummberXPath = "//*[@id=\"csm-component-info-detail\"]/div/div/div[12]/div[5]";
            public const string MasimoModelNumberLabelID = "lbl_spo2_model";
            public const string MasimoModelNumberValueID = "spo2_model";
            public const string MasimoModuleTypeLabelID = "lbl_spo2_module";
            public const string MasimoModuleTypeValueID = "spo2_module";

            //Spo2 Nellcor
            public const string Spo2NellcorNameID = "spo2_name";
            public const string NellcorToggleArrowID = "spo2Sensor";
            public const string NellcorFirmwareVersionXPath = "//*[@id=\"csm-component-info-detail\"]/div/div/div[12]/div[2]";
            public const string NellcorHardwareVersionXPath = "//*[@id=\"csm-component-info-detail\"]/div/div/div[12]/div[3]";
            public const string NellcorSerialNummberXPath = "//*[@id=\"csm-component-info-detail\"]/div/div/div[12]/div[5]";
            public const string NellcorModelNumberLabelID = "lbl_spo2_model";
            public const string NellcorModelNumberValueID = "spo2_model";
            public const string NellcorModuleTypeLabelID = "lbl_spo2_module";
            public const string NellcorModuleTypeValueID = "spo2_module";


            //Spo2 Nonin
            public const string Spo2NoninNameID = "spo2_name";
            public const string NoninToggleArrowID = "spo2Sensor";
            public const string NoninFirmwareVersionXPath = "//*[@id=\"csm-component-info-detail\"]/div/div/div[12]/div[2]";
            public const string NoninHardwareVersionXPath = "//*[@id=\"csm-component-info-detail\"]/div/div/div[12]/div[3]";
            public const string NoninSerialNummberXPath = "//*[@id=\"csm-component-info-detail\"]/div/div/div[12]/div[5]";
            public const string NoninModelNumberLabelID = "lbl_spo2_model";
            public const string NoninModelNumberValueID = "spo2_model";
            public const string NoninModuleTypeLabelID = "lbl_spo2_module";
            public const string NoninModuleTypeValueID = "spo2_module";

            //Radio Newmarr
            public const string RadioNewmarRowNameXPath = "//span[@id = \"radioLamar\"]//parent::div";
            public const string RadioNewmarRowFirmwareVersionID = "radio_firm_version";
            public const string RadioNewmarRowSerialNumberID = "radio_serialNo";
            public const string RadioNewmarRowToggleArrowID = "radioLamar";
            public const string RadioNewmarAPMacAddressLabelID = "lbl_radio_mac_address";
            public const string RadioNewmarAPMacAddressValueID = "radio_mac_address";
            public const string RadioNewmarChannelLabelID = "lbl_radio_channel";
            public const string RadioNewmarChannelValueID = "radio_channel";
            public const string RadioNewmarConnectionModeLabelID = "lbl_radio_connection_mode";
            public const string RadioNewmarConnectionModeValueID = "radio_connection_mode";
            public const string RadioNewmarSSIDLabelID = "lbl_radio_ssid";
            public const string RadioNewmarSSIDValueID = "radio_ssid";
            public const string RadioNewmarRSSILabelID = "lbl_radio_rssi";
            public const string RadioNewmarRSSIValueID = "radio_rssi";

            //Summary
            public const string SummaryCSMImageID = "csm_img";
            public const string SummaryAssetNameLabelID = "csm_lbl_asset_name";
            public const string SummaryAssetNameValueID = "csm_asset_name";
            public const string SummarySerialNumberLabelID = "csm_lbl_serial";
            public const string SummarySerialNumberValueID = "csm_serial";
            public const string SummaryModelLabelID = "csm_lbl_model";
            public const string SummaryModelValueID = "csm_model";
            public const string SummaryFacilityLabelID = "csm_lbl_facility";
            public const string SummaryFacilityValueID = "csm_facility";
            public const string SummaryLastVitalSentLabelID = "csm_lbl_vital";
            public const string SummaryLastVitalSentValueID = "csm_vital";
            public const string SummaryLocationLabelID = "csm_lbl_loc";
            public const string SummaryLocationValueID = "csm_loc";
            public const string SummaryRoomBedLabelID = "csm_lbl_room";
            public const string SummaryRoomBedValueID = "csm_room";
            public const string SummaryAssetTagLabelID = "csm_lbl_asset_tag";
            public const string SummaryAssetTagValueID = "csm_asset_tag";
            public const string SummaryIPAddressLabelID = "csm_lbl_ip";
            public const string SummaryIPAddressValueID = "csm_ip";
            public const string SummaryEthernetMacAddressLabelID = "csm_lbl_mac";
            public const string SummaryEthernetMacAddressValueID = "csm_mac";
            public const string SummaryRadioIPAddressLabelID = "csm_lbl_radio";
            public const string SummaryRadioIpAddressValueID = "csm_radio";
            public const string SummaryConnectionStatusLabelID = "csm_lbl_connection";
            public const string SummaryConnectionStatusValueID = "csm_connection";


        }

        [FindsBy(How = How.XPath, Using = Locator.SureTempRelativeElementXPath)]
        public IList<IWebElement> SureTempElementList { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.TempProbeRelativeElementXPath)]
        public IList<IWebElement> TempProbeElementList { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.NIBPRelativeElementXPath)]
        public IList<IWebElement> NIBPElementList { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.APMRelativeElementXPath)]
        public IList<IWebElement> APMElementList { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.UsageColumnXPath)]
        public IWebElement UsageColumn { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SummaryCSMImageID)]
        public IWebElement SummaryCSMImage { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SummaryAssetNameLabelID)]
        public IWebElement SummaryAssetNameLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SummaryAssetNameValueID)]
        public IWebElement SummaryAssetNameValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SummarySerialNumberLabelID)]
        public IWebElement SummarySerialNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SummarySerialNumberValueID)]
        public IWebElement SummarySerialNumberValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SummaryModelLabelID)]
        public IWebElement SummaryModelLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SummaryModelValueID)]
        public IWebElement SummaryModelValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SummaryFacilityLabelID)]
        public IWebElement SummaryFacilityLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SummaryFacilityValueID)]
        public IWebElement SummaryFacilityValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SummaryLastVitalSentLabelID)]
        public IWebElement SummaryLastVitalSentLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SummaryLastVitalSentValueID)]
        public IWebElement SummaryLastVitalSentValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SummaryLocationLabelID)]
        public IWebElement SummaryLocationLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SummaryLocationValueID)]
        public IWebElement SummaryLocationValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SummaryIPAddressLabelID)]
        public IWebElement SummaryIPAddressLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SummaryIPAddressValueID)]
        public IWebElement SummaryIPAddressValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SummaryRadioIPAddressLabelID)]
        public IWebElement SummaryRadioIPAddressLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SummaryRadioIpAddressValueID)]
        public IWebElement SummaryRadioIpAddressValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SummaryRoomBedLabelID)]
        public IWebElement SummaryRoomBedLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SummaryRoomBedValueID)]
        public IWebElement SummaryRoomBedValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SummaryAssetTagLabelID)]
        public IWebElement SummaryAssetTagLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SummaryAssetTagValueID)]
        public IWebElement SummaryAssetTagValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SummaryEthernetMacAddressLabelID)]
        public IWebElement SummaryEthernetMacAddressLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SummaryEthernetMacAddressValueID)]
        public IWebElement SummaryEthernetMacAddressValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SummaryConnectionStatusLabelID)]
        public IWebElement SummaryConnectionStatusLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SummaryConnectionStatusValueID)]
        public IWebElement SummaryConnectionStatusValue { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.RadioNewmarRowNameXPath)]
        public IWebElement RadioNewmarRowName { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarRowFirmwareVersionID)]
        public IWebElement RadioNewmarRowFirmwareVersion { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarRowSerialNumberID)]
        public IWebElement RadioNewmarRowSerialNumber { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarRowToggleArrowID)]
        public IWebElement RadioNewmarRowToggleArrow { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarAPMacAddressLabelID)]
        public IWebElement RadioNewmarAPMacAddressLabel { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.RadioNewmarAPMacAddressValueID)]
        public IWebElement RadioNewmarAPMacAddressValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarChannelLabelID)]
        public IWebElement RadioNewmarChannelLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarChannelValueID)]
        public IWebElement RadioNewmarChannelValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarConnectionModeLabelID)]
        public IWebElement RadioNewmarConnectionModeLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarConnectionModeValueID)]
        public IWebElement RadioNewmarConnectionModeValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarSSIDLabelID)]
        public IWebElement RadioNewmarSSIDLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarSSIDValueID)]
        public IWebElement RadioNewmarSSIDValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarRSSILabelID)]
        public IWebElement RadioNewmarRSSILabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarRSSIValueID)]
        public IWebElement RadioNewmarRSSIValue { get; set; }


        [FindsBy(How = How.XPath, Using = Locator.NoninFirmwareVersionXPath)]
        public IWebElement NoninFirmwareVersion { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.NoninHardwareVersionXPath)]
        public IWebElement NoninHardwareVersion { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.NoninSerialNummberXPath)]
        public IWebElement NoninSerialNummber { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Spo2NoninNameID)]
        public IWebElement Spo2NoninName { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NoninToggleArrowID)]
        public IWebElement NoninToggleArrow { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NoninModelNumberLabelID)]
        public IWebElement NoninModelNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NoninModelNumberValueID)]
        public IWebElement NoninModelNumberValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NoninModuleTypeLabelID)]
        public IWebElement NoninModuleTypeLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NoninModuleTypeValueID)]
        public IWebElement NoninModuleTypeValue { get; set; }



        [FindsBy(How = How.XPath, Using = Locator.NellcorFirmwareVersionXPath)]
        public IWebElement NellcorFirmwareVersion { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.NellcorHardwareVersionXPath)]
        public IWebElement NellcorHardwareVersion { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.NellcorSerialNummberXPath)]
        public IWebElement NellcorSerialNummber { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Spo2NellcorNameID)]
        public IWebElement Spo2NellcorName { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NellcorToggleArrowID)]
        public IWebElement NellcorToggleArrow { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NellcorModelNumberLabelID)]
        public IWebElement NellcorModelNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NellcorModelNumberValueID)]
        public IWebElement NellcorModelNumberValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NellcorModuleTypeLabelID)]
        public IWebElement NellcorModuleTypeLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NellcorModuleTypeValueID)]
        public IWebElement NellcorModuleTypeValue { get; set; }



        [FindsBy(How = How.XPath, Using = Locator.MasimoFirmwareVersionXPath)]
        public IWebElement MasimoFirmwareVersion { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.MasimoHardwareVersionXPath)]
        public IWebElement MasimoHardwareVersion { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.MasimoSerialNummberXPath)]
        public IWebElement MasimoSerialNummber { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Spo2MasimoNameID)]
        public IWebElement Spo2MasimoName { get; set; }

        [FindsBy(How = How.Id, Using = Locator.MasimoToggleArrowID)]
        public IWebElement MasimoToggleArrow { get; set; }

        [FindsBy(How = How.Id, Using = Locator.MasimoModelNumberLabelID)]
        public IWebElement MasimoModelNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.MasimoModelNumberValueID)]
        public IWebElement MasimoModelNumberValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.MasimoModuleTypeLabelID)]
        public IWebElement MasimoModuleTypeLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.MasimoModuleTypeValueID)]
        public IWebElement MasimoModuleTypeValue { get; set; }




        [FindsBy(How = How.XPath, Using = Locator.SureTempNameXpath)]
        public IWebElement SureTempName { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SureTempFirmwareVersionID)]
        public IWebElement SureTempFirmwareVersion { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SureTempHardwareVersionID)]
        public IWebElement SureTempHardwareVersion { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SureTempSerialNumberID)]
        public IWebElement SureTempSerialNumber { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SureTempCycleCountID)]
        public IWebElement SureTempCycleCount { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.TempProbeRowNameXPath)]
        public IWebElement TempProbeRowName { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeRowSerialNumberID)]
        public IWebElement TempProbeRowSerialNumber { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeRowCycleCountID)]
        public IWebElement TempProbeRowCycleCount { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeRowToggleArrowID)]
        public IWebElement TempProbeRowToggleArrow { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeTypeLabelID)]
        public IWebElement TempProbeTypeLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeTypeValueID)]
        public IWebElement TempProbeTypeValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeCycleCountLabelID)]
        public IWebElement TempProbeCycleCountLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeCycleCountValueID)]
        public IWebElement TempProbeCycleCountValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbePartNumberLabelID)]
        public IWebElement TempProbePartNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbePartNumberValueID)]
        public IWebElement TempProbePartNumberValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeLotCodeLabelID)]
        public IWebElement TempProbeLotCodeLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeLotCodeValueID)]
        public IWebElement TempProbeLotCodeValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeLotSequenceNumberLabelID)]
        public IWebElement TempProbeLotSequenceNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeLotSequenceNumberValueID)]
        public IWebElement TempProbeLotSequenceNumberValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeCalibrationDateLabelID)]
        public IWebElement TempProbeCalibrationDateLabel { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.TempProbeCalibrationDateValueID)]
        public IWebElement TempProbeCalibrationDateValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeCalibrationSignatureLabelID)]
        public IWebElement TempProbeCalibrationSignatureLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeCalibrationSignatureValueID)]
        public IWebElement TempProbeCalibrationSignatureValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeLastDeviceSerialNumberLabelID)]
        public IWebElement TempProbeLastDeviceSerialNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeLastDeviceSerialNumberValueID)]
        public IWebElement TempProbeLastDeviceSerialNumberValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeNumberOfTimesProbeChangedLabelID)]
        public IWebElement TempProbeNumberOfTimesProbeChangedLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeNumberOfTimesProbeChangedValueID)]
        public IWebElement TempProbeNumberOfTimesProbeChangedValue { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.NIBPRowNameXPath)]
        public IWebElement NIBPRowName { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.NIBPRowFirmwareVersionID)]
        public IWebElement NIBPRowFirmwareVersion { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.NIBPRowHardwareVersionID)]
        public IWebElement NIBPRowHardwareVersion { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.NIBPRowSerialNumberID)]
        public IWebElement NIBPRowSerialNumber { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.NIBPRowCycleCountID)]
        public IWebElement NIBPRowCycleCount { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.NIBPRowToggleArrowID)]
        public IWebElement NIBPRowToggleArrow { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.NIBPLastCalibrationDateLabelID)]
        public IWebElement NIBPLastCalibrationDateLabel { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.NIBPLastCalibrationDateValueID)]
        public IWebElement NIBPLastCalibrationDateValue { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.NIBPModuleCycleCountLabelID)]
        public IWebElement NIBPModuleCycleCountLabel { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.NIBPModuleCycleCountValueID)]
        public IWebElement NIBPModuleCycleCountValue { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.NIBPCalibrationSignatureLabelID)]
        public IWebElement NIBPCalibrationSignatureLabel { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.NIBPCalibrationSignatureValueID)]
        public IWebElement NIBPCalibrationSignatureValue { get; set; }


        [FindsBy(How = How.Id, Using = Locator.APMRowNameID)]
        public IWebElement APMRowName { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryRowNameID)]
        public IWebElement APMBatteryRowName { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryRowManufacturerDateID)]
        public IWebElement APMBatteryRowManufacturerDate { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryRowSerialNumberID)]
        public IWebElement APMBatteryRowSerialNumber { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryRowCycleCountID)]
        public IWebElement APMBatteryRowCycleCount { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryRowToggleArrowID)]
        public IWebElement APMBatteryRowToggleArrow { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryTemparatureLabelID)]
        public IWebElement APMBatteryTemparatureLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryTemparatureValueID)]
        public IWebElement APMBatteryTemparatureValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryVoltageLabelID)]
        public IWebElement APMBatteryVoltageLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryVoltageValueID)]
        public IWebElement APMBatteryVoltageValue { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.APMBatteryCurrentLabelID)]
        public IWebElement APMBatteryCurrentLabel { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.APMBatteryCurrentValueID)]
        public IWebElement APMBatteryCurrentValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryRemainingCapacityLabelID)]
        public IWebElement APMBatteryRemainingCapacityLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryRemainingCapacityValueID)]
        public IWebElement APMBatteryRemainingCapacityValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryFullChargeCapacityLabelID)]
        public IWebElement APMBatteryFullChargeCapacityLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryFullChargeCapacityValueID)]
        public IWebElement APMBatteryFullChargeCapacityValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryCycleCountLabelID)]
        public IWebElement APMBatteryCycleCountLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryCycleCountValueID)]
        public IWebElement APMBatteryCycleCountValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryBatteryDesigedCapacityLabelID)]
        public IWebElement APMBatteryBatteryDesigedCapacityLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryBatteryDesignedCapacityValueID)]
        public IWebElement APMBatteryBatteryDesignedCapacityValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryManufactureDateLabelID)]
        public IWebElement APMBatteryManufactureDateLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryManufactureDateValueID)]
        public IWebElement APMBatteryManufactureDateValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryManufactureNameLabelID)]
        public IWebElement APMBatteryManufactureNameLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryManufactureNameValueID)]
        public IWebElement APMBatteryManufactureNameValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatterySerialNumberLabelID)]
        public IWebElement APMBatterySerialNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatterySerialNumberValueID)]
        public IWebElement APMBatterySerialNumberValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryCombinedBatteryRemainingCapacityLabelID)]
        public IWebElement APMBatteryCombinedBatteryRemainingCapacityLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryCombinedBatteryRemainingCapacityValueID)]
        public IWebElement APMBatteryCombinedBatteryRemainingCapacityValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryModelNumberLabelID)]
        public IWebElement APMBatteryModelNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryModelNumberValueID)]
        public IWebElement APMBatteryModelNumberValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryPICProcessorFirmwareVersionLabelID)]
        public IWebElement APMBatteryPICProcessorFirmwareVersionLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.APMBatteryPICProcessorFirmwareVersionValueID)]
        public IWebElement APMBatteryPICProcessorFirmwareVersionValue { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.BatteryRelativeChildElementsXPath)]
        public IList<IWebElement> BatteryElementList { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryRowNameID)]
        public IWebElement BatteryRowName { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryRowSerialNumberID)]
        public IWebElement BatteryRowSerialNumber { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryRowManufactureDateID)]
        public IWebElement BatteryRowManufactureDate { get; set; }


        [FindsBy(How = How.Id, Using = Locator.BatteryRowCycleCountID)]
        public IWebElement BatteryRowCycleCount { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryManufacturerDateLabelID)]
        public IWebElement BatteryManufacturerDateLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryManufacturerDateValueID)]
        public IWebElement BatteryManufacturerDateValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatterySerialNumberLabelID)]
        public IWebElement BatterySerialNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatterySerialNumberValueID)]
        public IWebElement BatterySerialNumberValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryCycleCountLabelID)]
        public IWebElement BatteryCycleCountLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryCycleCountValueID)]
        public IWebElement BatteryCycleCountValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryRowToggelArrowID)]
        public IWebElement BatteryRowToggelArrow { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryTemparatureLabelID)]
        public IWebElement BatteryTemparatureLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryTemparatureValueID)]
        public IWebElement BatteryTemparatureValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryRemainingCapacityLabelID)]
        public IWebElement BatteryRemainingCapacityLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryRemainingCapacityValueID)]
        public IWebElement BatteryRemainingCapacityValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryVoltageLabelID)]
        public IWebElement BatteryVoltageLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryVoltageValueID)]
        public IWebElement BatteryVoltageValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryFullChargeCapacityLabelID)]
        public IWebElement BatteryFullChargeCapacityLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryFullChargeCapacityValueID)]
        public IWebElement BatteryFullChargeCapacityValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryCurrentLabelID)]
        public IWebElement BatteryCurrentLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryCurrentValueID)]
        public IWebElement BatteryCurrentValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryDesignedCapacityLabelID)]
        public IWebElement BatteryDesignedCapacityLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryDesignedCapacityValueID)]
        public IWebElement BatteryDesignedCapacityValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryModelNumberLabelID)]
        public IWebElement BatteryModelNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryModelNumberValueID)]
        public IWebElement BatteryModelNumberValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryManufacturerNameLabelID)]
        public IWebElement BatteryManufacturerNameLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryManufacturerNameValueID)]
        public IWebElement BatteryManufacturerNameValue { get; set; }


        [FindsBy(How = How.XPath, Using = Locator.RelativeElementXPath)]
        public IList<IWebElement> ConnexElementList { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.NameXPath)]
        public IWebElement Name { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.SerialNumberXPath)]
        public IWebElement SerialNumber { get; set; }


        [FindsBy(How = How.Id, Using = Locator.TotalRunTimeLabelID)]
        public IWebElement TotalRunTimeLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TotalRunTimeValueID)]
        public IWebElement TotalRunTimeValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.AssetDetailsSubsectionID)]
        public IWebElement AssetDetailsSubsection { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.LogsTabXPath)]
        public IWebElement LogsTab { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.ComponentInformationTabXPath)]
        public IWebElement ComponentInformationTab { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.PreventiveMaintenanceTabXPath)]
        public IWebElement PreventiveMaintenanceTab { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DeviceRowID)]
        public IList<IWebElement> DeviceList { get; set; }

        [FindsBy(How = How.Id, Using = Locator.CSMDetailsPageID)]
        public IWebElement CSMDetailsPage { get; set; }

        [FindsBy(How = How.Id, Using = Locator.CSMDetailsSummaryID)]
        public IWebElement CSMDetailsSummary { get; set; }

        [FindsBy(How = How.Id, Using = Locator.EditButtonID)]
        public IWebElement EditButton { get; set; }

        public int GetDeviceCount()
        {
            return DeviceList.Count;
        }
    }
}
