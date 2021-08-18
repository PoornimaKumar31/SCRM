using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HillromAutomationFramework.Coding.PageObjects.Component_Information
{
    class CVSMAssetListPage
    {
        public CVSMAssetListPage()
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
            public const string CVSMDetailsSummaryID = "cvsm_details_summary";
            public const string CVSMDetailsPageID = "device-main";
            public const string EditButtonID = "cvsm-edit";
            public const string PreventiveMaintenanceTabXPath = "//div[text()=\"Preventive maintenance\"]";
            public const string ComponentInformationTabXPath = "//div[text()=\"Component information\"]";
            public const string LogsTabXPath = "//div[text()=\"Logs\"]";
            public const string AssetDetailsSubsectionID = "device-details";



            //Component Information

            //Battery
            public const string BatteryNameID = "battery_name";
            public const string BatteryManufacturerDateID = "manufacture_date";
            public const string BatterySerialNumberID = "battery_serial_number";
            public const string BatteryCycleCountID = "battery_cycle_count";
            public const string BatteryToggelArrowID = "battery";
            public const string BatteryTemparatureValueID = "battery_temp";
            public const string BatteryTemparatureLabelID = "lbl_temp";
            public const string BatteryRemainingCapacityValueID = "remain_capacity";
            public const string BatteryRemainingCapacityLabelID = "lbl_remain_capacity";
            public const string BatteryVoltageValueID = "battery_voltage";
            public const string BatteryVoltageLabelID = "lbl_battery_voltage";
            public const string BatteryFullChargeCapacityValueID = "full_charge_capacity";
            public const string BatteryFullChargeCapacityLabelID = "lbl_full_charge_capacity";
            public const string BatteryCurrentValueID = "current";
            public const string BatteryCurrentLabelID = "lbl_current";
            public const string BatteryAvgTimeEmptyValueID = "avg_time_to_empty";
            public const string BatteryAvgTimeEmptyLabelID = "lbl_avg_time_to_empty";
            public const string BatteryDesignedCapacityValueID = "designed_capacity";
            public const string BatteryDesignedCapacityLabelID = "lbl_designed_capacity";
            public const string BatteryAvgTimeFullChargeValueID = "avg_time_to_full_charge";
            public const string BatteryAvgTimeFullChargeLabelID = "lbl_avg_time_to_full_charge";
            public const string BatteryChemistryValueID = "chemistry";
            public const string BatteryChemistryLabelID = "lbl_chemistry";
            public const string BatteryDeviceNameValueID = "";
            public const string BatteryDeviceNameLabelID = "";
            public const string BatteryModelNameValueID = "model_number";
            public const string BatteryModelNameLabelID = "lbl_model_number";



            //Braun Pro 4000 
            public const string BraunNameXPath = "//span[@id=\"braun\"]//parent::div";
            public const string BraunFirmwareVersionValueID = "braun_firm_version";
            public const string BraunHardwareVersionValueID = "braun_hardware_version";
            public const string BraunSerialNumberValueID = "braun_serialNo";
            public const string BraunCycleCountValueID = "braun_usage";
            public const string BraunModelNumberLabelID = "lbl_braun_model";
            public const string BraunModelNumberValueID = "braun_model";
            public const string BraunDockCycleCountLabelID = "lbl_braun_dock_count";
            public const string BraunDockCycleCountValueID = "braun_dock_count";
            public const string BraunToggleArrowID = "braun";

            //CO2
            public const string CO2NameXPath = "//span[@id=\"co2\"]//parent::div";
            public const string CO2FirmwareVersionID = "co2_firmware_version";
            public const string CO2HardwareVersionID = "co2_hardware_version";
            public const string CO2SerialNumberID = "co2_serial_no";
            public const string CO2RunTimeID = "co2_usage";
            public const string CO2HoursToServiceLabelID = "lbl_co2_hours_to_service";
            public const string CO2HoursToServiceValueID = "co2_hours_to_service";
            public const string CO2MaxHourToCalibrationLabelID = "lbl_co2_max_hrs";
            public const string CO2MaxHourToCalibrationValueID = "co2_max_hrs";
            public const string CO2ModelNumberLabelID = "lbl_co2_model_no";
            public const string CO2ModelNumberValueID = "co2_model_no";
            public const string CO2OEMDeviceNameLabelID = "lbl_co2_oem_name";
            public const string CO2OEMDeviceNameValueID = "co2_oem_name";
            public const string CO2OEMSerialNumberLabelID = "lbl_co2_oem_serial_no";
            public const string CO2OEMSerialNumberValueID = "co2_oem_serial_no";
            public const string CO2SensorToggleArrowID = "co2";
            public const string CO2RunTimeValueXPath = "//div[@id = '"+CO2RunTimeID+"']//span[2]";


            //Deluxe Comms
            public const string DeluxeFirmwareVersionID = "deluxe_firmware_version";
            public const string DeluxeSerialNumberXPath = "//div[@id=\"deluxe_firmware_version\"]//parent::div/div[5]";
            public const string DeluxeModuleToggleArrowID = "deluxe";
            public const string DeluxeModelNumberLabelID = "lbl_deluxe_model_no";
            public const string DeluxeModelNumberValueID = "deluxe_model_no";


            //NIBP
            public const string NIBPNameXPath = "//span[@id = \"nibp\"]//parent::div";
            public const string NIBPFirmwareVersionID = "nibp_firm_version";
            public const string NIBPHardwareVersionID = "nibp_hardware_version";
            public const string NIBPSerialNumberID = "nibp_serialNo";
            public const string NIBPCycleCountID = "nibp_usage";
            public const string NIBPSensorToggleButtonID = "nibp";
            public const string NIBPBootloaderVersionLabelID = "nibp_lbl_boot_version";
            public const string NIBPBootloaderVersionValueID = "nibp_boot_version";
            public const string NIBPModelNumberLabelID = "nibp_lbl_model";
            public const string NIBPModelNumberValueID = "nibp_model";
            public const string NIBPSafetyVersionLabelID = "nibp_lbl_safety";
            public const string NIBPSafetyVersionValueID = "nibp_safety";

            //Printer
            public const string PrinterNameXPath = "//span[@id = \"printer\"]//parent::div";
            public const string PrinterToggleArrowID = "printer";
            public const string PrinterFirmwareVersionID = "printer_firm_version";
            public const string PrinterSerialNumberID = "printer_serialNo";
            public const string PrinterModelNumberLabelID = "printer_lbl_model";
            public const string PrinterModelNumberValueID = "printer_model";

            //Temprature Probe
            public const string TempProbeNameXPath = "//span[@id = \"tempProbe\"]//parent::div";
            public const string TempProbeToggleArrowID = "tempProbe";
            public const string TempProbeSerialNumberID = "tempProbe_serialNo";
            public const string TempProbeUsageValueID = "tempProbe_usage";
            public const string TempProbeModelNumberLabelID = "tempProbe_lbl_modelNo";
            public const string TempProbeModelNumberValueID = "tempProbe_modelNo";
            public const string TempProbeProbeTypeLabelID = "tempProbe_lbl_probe_type";
            public const string TempProbeProbeTypeValueID = "tempProbe_probe_type";
            public const string TempProbeLastDeviceSerialNumberLabelID = "tempProbe_lbl_last_serialNo";
            public const string TempProbeLastDeviceSerialNumberValueID = "tempProbe_last_serialNo";
            public const string TempProbeNumberOfTimesProbeChangedDevicesLabelID = "tempProbe_lbl_probe_change";
            public const string TempProbeNumberOfTimesProbeChangedDevicesValueID = "tempProbe_probe_change";
            public const string TempProbePartNumberLabelID = "tempProbe_lbl_partNo";
            public const string TempProbePartNumberValueID = "tempProbe_partNo";

            //Scale
            public const string ScaleNameXPath = "//span[@id = \"scale\"]//parent::div";
            public const string ScaleFirmwareVersionID = "";
            public const string ScaleHardwareVersionID = "";
            public const string ScaleSerialNumberID = "";
            public const string ScaleCycleCountID = "";
            public const string ScaleModelNumberLabelID = "";
            public const string ScaleModelNumberValueID = "";

            //SPO2
            public const string Spo2NameXPath = "//div[@id = \"spo2_firm_version\"]//parent::div//div";
            public const string Spo2FirmwareVersionID = "spo2_firm_version";

            //Masimo License 
            public const string MasimoNameID = "spo2_type_name";
            public const string MasimoToggleArrowID = "spo2";
            public const string MasimoFirmwareVersionID = "spo2_type_firm_version";
            public const string MasimoHardwareVersionID = "spo2_type_hardware_version";
            public const string MasimoSerialNumberID = "spo2_type_serial_no";
            public const string MasimoUsageValueID = "spo2_type_usage";
            public const string MasimoModelNumberLabelID = "spo2_type_lbl_model";
            public const string MasimoModelNumberValueID = "spo2_type_model";
            public const string MasimoRraLicenceLabelID = "spo2_type_lbl_rra";
            public const string MasimoRraLicenceValueID = "spo2_type_rra";
            public const string MasimoSpHbLicenseLabelID = "spo2_type_lbl_sphb";
            public const string MasimoSpHbLicenseValueID = "spo2_type_sphb";

            //Nellcor
            public const string NellcorNameID = "spo2_type_name";
            public const string NellcorFirmwareVersionID = "spo2_type_firm_version";
            public const string NellcorHardwareVersionID = "spo2_type_hardware_version";
            public const string NellcorSerialNumberID = "spo2_type_serial_no";
            public const string NellcorToggleArrowID = "spo2";
            public const string NellcorModelNumberLabelID = "spo2_type_lbl_model";
            public const string NellcorModelNumberValueID = "spo2_type_model";

            //Sure Temp Thermometer
            public const string SureTempNameXPath = "//div[@id = \"sure_temp_firm_version\"]//parent::div//div";
            public const string SureTempFirmwareVersionID = "sure_temp_firm_version";
            public const string SureTempHardwareVersionID = "sure_temp_hardware_version";
            public const string SureTempSerialNumberID = "sure_temp_sNo";
            public const string SureTempUsageValueID = "sure_temp_usage";

            //Radio Lamarr
            public const string RadioLamarrNameXPath = "//span[@id = \"radio\"]//parent::div";
            public const string RadioLamarrSerialNumberID = "hc_radio_serialNo";
            public const string RadioLamarrUsageValueXPath = "//div[@id =\"hc_radio_serialNo\"]//parent::div/div[6]";
            public const string RadioLamarrToggleArrowID = "radio";
            public const string RadioLamarrAPMACAddressLabelID = "";
            public const string RadioLamarrAPMACAddressValueID = "";
            public const string RadioLamarrRadioIPAddressLabelID = "";
            public const string RadioLamarrRadioIPAddressValueID = "";
            public const string RadioLamarrMacAddressLabelID = "lbl_hc_radio_mac";
            public const string RadioLamarrMacAddressValueID = "hc_radio_mac";
            public const string RadioLamarrModelNumberLabelID = "lbl_hc_radio_model";
            public const string RadioLamarrModelNumberValueID = "hc_radio_model";
            public const string RadioLamarrRSSILabelID = "lbl_hc_radio_rssi";
            public const string RadioLamarrRSSIvalueID = "hc_radio_rssi";
            public const string RadioLamarrServerVersionLabelID = "lbl_hc_radio_server";
            public const string RadioLamarrServerVersionValueID = "hc_radio_server";
            public const string RadioLamarrSSIDLabelID = "lbl_hc_radio_ssid";
            public const string RadioLamarrSSIDValueID = "hc_radio_ssid";

            //Radio Newmar
            public const string RadioNewmarNameXPath = "//span[@id = \"radio\"]//parent::div";
            public const string RadioNewmarToggleArrowID = "radio";
            public const string RadioNewmarFirmwareVersionID = "hc_radio_firm_version";
            public const string RadioNewmarSerialNUmberID = "hc_radio_serialNo";
            public const string RadioNewmarApMacAddressLabelID = "";
            public const string RadioNewmarApMacAddressValueID = "";
            public const string RadioNewmarRadioIpAddressLabelID = "";
            public const string RadioNewmarRadioIpAddressValueID = "";
            public const string RadioNewmarMacAddressLabelID = "lbl_hc_radio_mac";
            public const string RadioNewmarMacAddressValueID = "hc_radio_mac";
            public const string RadioNewmarModelNumberLabelID = "lbl_hc_radio_model";
            public const string RadioNewmarModelNumberValueID = "hc_radio_model";
            public const string RadioNewmarRssiLabelID = "lbl_hc_radio_rssi";
            public const string RadioNewmarRssiValueID = "hc_radio_rssi";
            public const string RadioNewmarServerVersionLabelID = "lbl_hc_radio_server";
            public const string RadioNewmarServerVersionValueID = "hc_radio_server";
            public const string RadioNewmarSsidLabelID = "lbl_hc_radio_ssid";
            public const string RadioNewmarSsidValueID = "hc_radio_ssid";


            //Connex Device
            public const string ConnexNameXPath = "//div[@id = \"welch_usage\"]//parent::div//div";
            public const string ConnexSerialNumberXPath = "//div[@id = \"welch_usage\"]//parent::div//div[5]";
            public const string ConnexDeviceHoursLabelID = "lbl_total_run_time";
            public const string ConnexDeviceHoursValueID = "total_run_time";
            public const string ConnexUsageID = "welch_usage";

            //Host Controller
            public const string HostControllerNameXPath = "//div[@id = \"host_firm_version\"]//parent::div//div[1]";
            public const string HostControllerFirmwareVersionID = "host_firm_version";
            public const string HostControllerHardwareVersionID = "host_hardware_version";
            public const string HostControllerSerialNumberXPath = "//div[@id = \"host_firm_version\"]//parent::div//div[5]";

            //CVSM Details Summary
            public const string DetailsSummaryCVSMImageID = "cvsm_img";
            public const string DetailsSummaryAssetNameLabelID = "cvsm_lbl_asset_name";
            public const string DetailsSummaryAssetNameValueID = "cvsm_asset_name";
            public const string DetailsSummarySerialNumberLabelID = "cvsm_lbl_serial";
            public const string DetailsSummarySerialNumberValueID = "cvsm_serial";
            public const string DetailsSummaryModelLabelID = "cvsm_lbl_serial";
            public const string DetailsSummaryModelValueID = "cvsm_model";
            public const string DetailsSummaryFacilityLabelID = "cvsm_lbl_facility";
            public const string DetailsSummaryFacilityValueID = "cvsm_facility";
            public const string DetailsSummaryLocationLabelID = "cvsm_lbl_loc";
            public const string DetailsSummaryLocationValueID = "cvsm_loc";
            public const string DetailsSummaryRoomBedLabelID = "cvsm_lbl_room";
            public const string DetailsSummaryRoomBedValueID = "cvsm_room";
            public const string DetailsSummaryAssetTagLabelID = "cvsm_lbl_asset_tag";
            public const string DetailsSummaryAssetTagValueID = "cvsm_asset_tag";
            public const string DetailsSummaryIPAddressLabelID = "cvsm_lbl_ip";
            public const string DetailsSummaryIPAddressValueID = "cvsm_ip";
            public const string DetailsSummaryEthernetMacAddressLabelID = "cvsm_lbl_mac";
            public const string DetailsSummaryEthernetMacAddressValueID = "cvsm_mac";
            public const string DetailsSummaryRadioIPAddressLabelID = "cvsm_lbl_radio_ip";
            public const string DetailsSummaryRadioIPAddressValueID = "cvsm_radio_ip";
            public const string DetailsSummaryConnectionStatusLabelID = "cvsm_lbl_connection";
            public const string DetailsSummaryConnectionStatusValueID = "cvsm_connection";
            public const string DetailsSummaryLastCustomizationDeployedLabelID = "cvsm_lbl_last";
            public const string DetailsSummaryLastCustomizationDeployedValueID = "cvsm_last";
            public const string DetailsSummaryLastConfigurationDeployedLabelID = "cvsm_lbl_config";
            public const string DetailsSummaryLastConfigurationDeployedValueID = "cvsm_config";
            public const string DetailsSummaryLocateAssetButtonID = "cvsm-locate-asset";

            //ParentXpath
            public const string BatteryRelativeChildElementsXPath = "//div[@id = '"+ BatteryCycleCountID +"']//parent::div/div";
            public const string BraunRelativeChildElementsXPath = "//div[@id = '" + BraunCycleCountValueID + "']//parent::div/div";
            public const string CO2RelativeChiledElementXPath = "//div[@id = '"+CO2RunTimeID+ "']//parent::div//parent::div/div";
            public const string NIBPRelativeChildElementXPath = "//div[@id = '"+NIBPCycleCountID+"']/parent::div/div";
            public const string ConnexRelativeChildElementXpath = "//div[@id = '"+ConnexUsageID+"']//parent::div/div";

        }


        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryLocateAssetButtonID)]
        public IWebElement DetailsSummaryLocateAssetButton { get; set; }


        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryCVSMImageID)]
        public IWebElement DetailsSummaryCVSMImage { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryLastConfigurationDeployedLabelID)]
        public IWebElement DetailsSummaryLastConfigurationDeployedLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryLastConfigurationDeployedValueID)]
        public IWebElement DetailsSummaryLastConfigurationDeployedValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryLastCustomizationDeployedLabelID)]
        public IWebElement DetailsSummaryLastCustomizationDeployedLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryLastCustomizationDeployedValueID)]
        public IWebElement DetailsSummaryLastCustomizationDeployedValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryAssetNameLabelID)]
        public IWebElement DetailsSummaryAssetNameLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryAssetNameValueID)]
        public IWebElement DetailsSummaryAssetNameValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummarySerialNumberLabelID)]
        public IWebElement DetailsSummarySerialNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummarySerialNumberValueID)]
        public IWebElement DetailsSummarySerialNumberValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryModelLabelID)]
        public IWebElement DetailsSummaryModelLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryModelValueID)]
        public IWebElement DetailsSummaryModelValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryFacilityLabelID)]
        public IWebElement DetailsSummaryFacilityLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryFacilityValueID)]
        public IWebElement DetailsSummaryFacilityValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryLocationLabelID)]
        public IWebElement DetailsSummaryLocationLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryLocationValueID)]
        public IWebElement DetailsSummaryLocationValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryRoomBedLabelID)]
        public IWebElement DetailsSummaryRoomBedLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryRoomBedValueID)]
        public IWebElement DetailsSummaryRoomBedValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryAssetTagLabelID)]
        public IWebElement DetailsSummaryAssetTagLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryAssetTagValueID)]
        public IWebElement DetailsSummaryAssetTagValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryIPAddressLabelID)]
        public IWebElement DetailsSummaryIPAddressLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryIPAddressValueID)]
        public IWebElement DetailsSummaryIPAddressValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryEthernetMacAddressLabelID)]
        public IWebElement DetailsSummaryEthernetMacAddressLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryEthernetMacAddressValueID)]
        public IWebElement DetailsSummaryEthernetMacAddressValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryRadioIPAddressLabelID)]
        public IWebElement DetailsSummaryRadioIPAddressLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryRadioIPAddressValueID)]
        public IWebElement DetailsSummaryRadioIPAddressValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryConnectionStatusLabelID)]
        public IWebElement DetailsSummaryConnectionStatusLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DetailsSummaryConnectionStatusValueID)]
        public IWebElement DetailsSummaryConnectionStatusValue { get; set; }


        [FindsBy(How = How.Id, Using = Locator.HostControllerFirmwareVersionID)]
        public IWebElement HostControllerFirmwareVersion { get; set; }


        [FindsBy(How = How.XPath, Using = Locator.HostControllerNameXPath)]
        public IWebElement HostControllerName { get; set; }

        [FindsBy(How = How.Id, Using = Locator.HostControllerHardwareVersionID)]
        public IWebElement HostControllerHardwareVersion { get; set; }


        [FindsBy(How = How.XPath, Using = Locator.HostControllerSerialNumberXPath)]
        public IWebElement HostControllerSerialNumber { get; set; }

        [FindsBy(How = How.Id, Using = Locator.ConnexUsageID)]
        public IWebElement ConnexUsage { get; set; }


        [FindsBy(How = How.XPath, Using = Locator.ConnexRelativeChildElementXpath)]
        public IList<IWebElement> ConnexElementList { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.ConnexNameXPath)]
        public IWebElement ConnexName { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.ConnexSerialNumberXPath)]
        public IWebElement ConnexSerialNumber { get; set; }

        [FindsBy(How = How.Id, Using = Locator.ConnexDeviceHoursLabelID)]
        public IWebElement ConnexDeviceHoursLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.ConnexDeviceHoursValueID)]
        public IWebElement ConnexDeviceHoursValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarFirmwareVersionID)]
        public IWebElement RadioNewmarFirmwareVersion { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarSerialNUmberID)]
        public IWebElement RadioNewmarSerialNUmber { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarToggleArrowID)]
        public IWebElement RadioNewmarToggleArrow { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarApMacAddressLabelID)]
        public IWebElement RadioNewmarApMacAddressLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarApMacAddressValueID)]
        public IWebElement RadioNewmarApMacAddressValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarRadioIpAddressLabelID)]
        public IWebElement RadioNewmarRadioIpAddressLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarRadioIpAddressValueID)]
        public IWebElement RadioNewmarRadioIpAddressValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarMacAddressLabelID)]
        public IWebElement RadioNewmarMacAddressLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarMacAddressValueID)]
        public IWebElement RadioNewmarMacAddressValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarModelNumberLabelID)]
        public IWebElement RadioNewmarModelNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarModelNumberValueID)]
        public IWebElement RadioNewmarModelNumberValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarRssiLabelID)]
        public IWebElement RadioNewmarRssiLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarRssiValueID)]
        public IWebElement RadioNewmarRssiValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarServerVersionLabelID)]
        public IWebElement RadioNewmarServerVersionLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarServerVersionValueID)]
        public IWebElement RadioNewmarServerVersionValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarSsidLabelID)]
        public IWebElement RadioNewmarSsidLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioNewmarSsidValueID)]
        public IWebElement RadioNewmarSsidValue { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.RadioNewmarNameXPath)]
        public IWebElement RadioNewmarName { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioLamarrSerialNumberID)]
        public IWebElement RadioLamarrSerialNumber { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioLamarrToggleArrowID)]
        public IWebElement RadioLamarrToggleArrow { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioLamarrAPMACAddressLabelID)]
        public IWebElement RadioLamarrAPMACAddressLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioLamarrAPMACAddressValueID)]
        public IWebElement RadioLamarrAPMACAddressValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioLamarrRadioIPAddressLabelID)]
        public IWebElement RadioLamarrRadioIPAddressLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioLamarrRadioIPAddressValueID)]
        public IWebElement RadioLamarrRadioIPAddressValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioLamarrMacAddressLabelID)]
        public IWebElement RadioLamarrMacAddressLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioLamarrMacAddressValueID)]
        public IWebElement RadioLamarrMacAddressValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioLamarrModelNumberLabelID)]
        public IWebElement RadioLamarrModelNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioLamarrModelNumberValueID)]
        public IWebElement RadioLamarrModelNumberValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioLamarrRSSILabelID)]
        public IWebElement RadioLamarrRSSILabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioLamarrRSSIvalueID)]
        public IWebElement RadioLamarrRSSIvalue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioLamarrServerVersionLabelID)]
        public IWebElement RadioLamarrServerVersionLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioLamarrServerVersionValueID)]
        public IWebElement RadioLamarrServerVersionValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioLamarrSSIDLabelID)]
        public IWebElement RadioLamarrSSIDLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RadioLamarrSSIDValueID)]
        public IWebElement RadioLamarrSSIDValue { get; set; }


        [FindsBy(How = How.XPath, Using = Locator.RadioLamarrNameXPath)]
        public IWebElement RadioLamarrName { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.RadioLamarrUsageValueXPath)]
        public IWebElement RadioLamarrUsageValue { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.SureTempNameXPath)]
        public IWebElement SureTempName { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SureTempFirmwareVersionID)]
        public IWebElement SureTempFirmwareVersion { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SureTempHardwareVersionID)]
        public IWebElement SureTempHardwareVersion { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SureTempSerialNumberID)]
        public IWebElement SureTempSerialNumber { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SureTempUsageValueID)]
        public IWebElement SureTempUsageValue { get; set; }


        [FindsBy(How = How.Id, Using = Locator.NellcorHardwareVersionID)]
        public IWebElement NellcorHardwareVersion { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NellcorSerialNumberID)]
        public IWebElement NellcorSerialNumber { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NellcorToggleArrowID)]
        public IWebElement NellcorToggleArrow { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NellcorModelNumberLabelID)]
        public IWebElement NellcorModelNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NellcorModelNumberValueID)]
        public IWebElement NellcorModelNumberValue { get; set; }


        [FindsBy(How = How.Id, Using = Locator.NellcorNameID)]
        public IWebElement NellcorName { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NellcorFirmwareVersionID)]
        public IWebElement NellcorFirmwareVersion { get; set; }

        [FindsBy(How = How.Id, Using = Locator.MasimoNameID)]
        public IWebElement MasimoName { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.MasimoFirmwareVersionID)]
        public IWebElement MasimoFirmwareVersion { get; set; }

        [FindsBy(How = How.Id, Using = Locator.MasimoHardwareVersionID)]
        public IWebElement MasimoHardwareVersion { get; set; }

        [FindsBy(How = How.Id, Using = Locator.MasimoSerialNumberID)]
        public IWebElement MasimoSerialNumber { get; set; }

        [FindsBy(How = How.Id, Using = Locator.MasimoUsageValueID)]
        public IWebElement MasimoUsageValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.MasimoToggleArrowID)]
        public IWebElement MasimoToggleArrow { get; set; }

        [FindsBy(How = How.Id, Using = Locator.MasimoModelNumberLabelID)]
        public IWebElement MasimoModelNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.MasimoModelNumberValueID)]
        public IWebElement MasimoModelNumberValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.MasimoRraLicenceLabelID)]
        public IWebElement MasimoRraLicenceLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.MasimoRraLicenceValueID)]
        public IWebElement MasimoRraLicenceValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.MasimoSpHbLicenseLabelID)]
        public IWebElement MasimoSpHbLicenseLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.MasimoSpHbLicenseValueID)]
        public IWebElement MasimoSpHbLicenseValue { get; set; }



        [FindsBy(How = How.XPath, Using = Locator.Spo2NameXPath)]
        public IWebElement Spo2Name { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Spo2FirmwareVersionID)]
        public IWebElement Spo2FirmwareVersion { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.TempProbeNameXPath)]
        public IWebElement TempProbeName { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeSerialNumberID)]
        public IWebElement TempProbeSerialNumber { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeUsageValueID)]
        public IWebElement TempProbeUsageValue { get; set; }


        [FindsBy(How = How.Id, Using = Locator.TempProbeToggleArrowID)]
        public IWebElement TempProbeToggleArrow { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeModelNumberLabelID)]
        public IWebElement TempProbeModelNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeModelNumberValueID)]
        public IWebElement TempProbeModelNumberValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeProbeTypeLabelID)]
        public IWebElement TempProbeProbeTypeLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeProbeTypeValueID)]
        public IWebElement TempProbeProbeTypeValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeLastDeviceSerialNumberLabelID)]
        public IWebElement TempProbeLastDeviceSerialNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeLastDeviceSerialNumberValueID)]
        public IWebElement TempProbeLastDeviceSerialNumberValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeNumberOfTimesProbeChangedDevicesLabelID)]
        public IWebElement TempProbeNumberOfTimesProbeChangedDevicesLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbeNumberOfTimesProbeChangedDevicesValueID)]
        public IWebElement TempProbeNumberOfTimesProbeChangedDevicesValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbePartNumberLabelID)]
        public IWebElement TempProbePartNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TempProbePartNumberValueID)]
        public IWebElement TempProbePartNumberValue { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.PrinterNameXPath)]
        public IWebElement PrinterName { get; set; }

        [FindsBy(How = How.Id, Using = Locator.PrinterToggleArrowID)]
        public IWebElement PrinterToggleArrow { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.PrinterFirmwareVersionID)]
        public IWebElement PrinterFirmwareVersion { get; set; }

        [FindsBy(How = How.Id, Using = Locator.PrinterSerialNumberID)]
        public IWebElement PrinterSerialNumber { get; set; }

        [FindsBy(How = How.Id, Using = Locator.PrinterModelNumberLabelID)]
        public IWebElement PrinterModelNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.PrinterModelNumberValueID)]
        public IWebElement PrinterModelNumberValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NIBPFirmwareVersionID)]
        public IWebElement NIBPFirmwareVersion { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.NIBPHardwareVersionID)]
        public IWebElement NIBPHardwareVersion { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.NIBPSerialNumberID)]
        public IWebElement NIBPSerialNumber { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.NIBPCycleCountID)]
        public IWebElement NIBPCycleCount { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.NIBPSensorToggleButtonID)]
        public IWebElement NIBPSensorToggleButton { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.NIBPBootloaderVersionLabelID)]
        public IWebElement NIBPBootloaderVersionLabel { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.NIBPBootloaderVersionValueID)]
        public IWebElement NIBPBootloaderVersionValue { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.NIBPModelNumberLabelID)]
        public IWebElement NIBPModelNumberLabel { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.NIBPModelNumberValueID)]
        public IWebElement NIBPModelNumberValue { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.NIBPSafetyVersionLabelID)]
        public IWebElement NIBPSafetyVersionLabel { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.NIBPSafetyVersionValueID)]
        public IWebElement NIBPSafetyVersionValue { get; set; }
        
        [FindsBy(How = How.XPath, Using = Locator.NIBPRelativeChildElementXPath)]
        public IList<IWebElement> NIBPElementList { get; set; }


        [FindsBy(How = How.XPath, Using = Locator.NIBPNameXPath)]
        public IWebElement NIBPName { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.DeluxeSerialNumberXPath)]
        public IWebElement DeluxeSerialNumber { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DeluxeFirmwareVersionID)]
        public IWebElement DeluxeFirmwareVersion { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DeluxeModuleToggleArrowID)]
        public IWebElement DeluxeModuleToggleArrow { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DeluxeModelNumberLabelID)]
        public IWebElement DeluxeModelNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DeluxeModelNumberValueID)]
        public IWebElement DeluxeModelNumberValue { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.CO2RunTimeValueXPath)]
        public IWebElement CO2RunTimeValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.CO2SensorToggleArrowID)]
        public IWebElement CO2SensorToggleArrow { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.CO2RelativeChiledElementXPath)]
        public IList<IWebElement> CO2ElementList { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.CO2NameXPath)]
        public IWebElement CO2Name { get; set; }

        [FindsBy(How = How.Id, Using = Locator.CO2FirmwareVersionID)]
        public IWebElement CO2FirmwareVersion { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.CO2HardwareVersionID)]
        public IWebElement CO2HardwareVersion { get; set; }

        [FindsBy(How = How.Id, Using = Locator.CO2SerialNumberID)]
        public IWebElement CO2SerialNumber { get; set; }

        [FindsBy(How = How.Id, Using = Locator.CO2RunTimeID)]
        public IWebElement CO2RunTime { get; set; }

        [FindsBy(How = How.Id, Using = Locator.CO2HoursToServiceLabelID)]
        public IWebElement CO2HoursToServiceLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.CO2HoursToServiceValueID)]
        public IWebElement CO2HoursToServiceValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.CO2MaxHourToCalibrationLabelID)]
        public IWebElement CO2MaxHourToCalibrationLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.CO2MaxHourToCalibrationValueID)]
        public IWebElement CO2MaxHourToCalibrationValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.CO2ModelNumberLabelID)]
        public IWebElement CO2ModelNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.CO2ModelNumberValueID)]
        public IWebElement CO2ModelNumberValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.CO2OEMDeviceNameLabelID)]
        public IWebElement CO2OEMDeviceNameLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.CO2OEMDeviceNameValueID)]
        public IWebElement CO2OEMDeviceNameValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.CO2OEMSerialNumberLabelID)]
        public IWebElement CO2OEMSerialNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.CO2OEMSerialNumberValueID)]
        public IWebElement CO2OEMSerialNumberValue { get; set; }



        [FindsBy(How = How.Id, Using = Locator.BraunToggleArrowID)]
        public IWebElement BraunToggleArrow { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.BraunRelativeChildElementsXPath)]
        public IList<IWebElement> BraunElementList { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BraunModelNumberLabelID)]
        public IWebElement BraunModelNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BraunModelNumberValueID)]
        public IWebElement BraunModelNumberValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BraunDockCycleCountLabelID)]
        public IWebElement BraunDockCycleCountLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BraunCycleCountValueID)]
        public IWebElement BraunCycleCountValue { get; set; }


        [FindsBy(How = How.Id, Using = Locator.BraunSerialNumberValueID)]
        public IWebElement BraunSerialNumberValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BraunHardwareVersionValueID)]
        public IWebElement BraunHardwareVersionValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BraunFirmwareVersionValueID)]
        public IWebElement BraunFirmwareVersionValue { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.BraunNameXPath)]
        public IWebElement BraunNameValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryTemparatureLabelID)]
        public IWebElement BatteryTemparatureLabel { get; set; }
        
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
        
        [FindsBy(How = How.Id, Using = Locator.BatteryAvgTimeEmptyLabelID)]
        public IWebElement BatteryAvgTimeEmptyLabel { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.BatteryAvgTimeEmptyValueID)] 
        public IWebElement BatteryAvgTimeEmptyValue { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.BatteryDesignedCapacityLabelID)]
        public IWebElement BatteryDesignedCapacityLabel { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.BatteryDesignedCapacityValueID)]
        public IWebElement BatteryDesignedCapacityValue { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.BatteryAvgTimeFullChargeLabelID)]
        public IWebElement BatteryAvgTimeFullChargeLabel { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.BatteryAvgTimeFullChargeValueID)]
        public IWebElement BatteryAvgTimeFullChargeValue { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.BatteryChemistryLabelID)]
        public IWebElement BatteryChemistryLabel { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.BatteryChemistryValueID)]
        public IWebElement BatteryChemistryValue { get; set; }
        

        [FindsBy(How = How.Id, Using = Locator.BatteryModelNameLabelID)]
        public IWebElement BatteryModelNameLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryModelNameValueID)]
        public IWebElement BatteryModelNameValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryTemparatureValueID)]
        public IWebElement BatteryTemparatureValue { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryToggelArrowID)]
        public IWebElement BatteryToggelArrow { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryManufacturerDateID)]
        public IWebElement BatteryManufacturerDate { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatterySerialNumberID)]
        public IWebElement BatterySerialNumber { get; set; }


        [FindsBy(How = How.Id, Using = Locator.BatteryNameID)]
        public IWebElement BatteryName { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.BatteryRelativeChildElementsXPath)]
        public IList<IWebElement> BatteryElementList { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryCycleCountID)]
        public IWebElement BatteryCycleCount { get; set; }


        [FindsBy(How = How.Id, Using = Locator.AssetDetailsSubsectionID)]
        public IWebElement AssetDetailsSubsection { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.LogsTabXPath)]
        public IWebElement LogsTab { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.ComponentInformationTabXPath)]
        public IWebElement ComponentInformationTab { get; set; }
        
        [FindsBy(How = How.XPath, Using = Locator.PreventiveMaintenanceTabXPath)]
        public IWebElement PreventiveMaintenanceTab { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.EditButtonID)]
        public IWebElement EditButton { get; set; }

        [FindsBy(How = How.Id, Using = Locator.CVSMDetailsPageID)]
        public IWebElement CVSMDetailsPage { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DeviceRowID)]
        public IList<IWebElement> DeviceList { get; set; }

        [FindsBy(How = How.Id, Using = Locator.CVSMDetailsSummaryID)]
        public IWebElement CVSMDetailsSummary { get; set; }


        /// <summary>
        /// Function for getting number of CVSM devices present
        /// </summary>
        /// <returns>Integer</returns>
        public int GetDeviceCount()
        {
            return DeviceList.Count;
        }
    }
}
