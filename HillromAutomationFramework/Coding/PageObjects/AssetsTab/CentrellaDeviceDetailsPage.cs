using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HillromAutomationFramework.Coding.PageObjects.AssetsTab
{
    class CentrellaDeviceDetailsPage
    {
        public string randomDate;
        public CentrellaDeviceDetailsPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        public class ExpectedValue
        {
            public const string ServiceManualPDFName = "193588_11.pdf";
        }

        public class Locators
        {
            public const string ErrorCodeTabXPath = "//div[@class = 'mat-tab-list']/div/div[1]";
            public const string PreventiveMaintenanceTabXPath = "//div[@class = 'mat-tab-list']/div/div[2]";
            public const string NoErrorReportedLabelXPath = "//div[@id = 'centrella-errorcode-details']/div[2]";
            public const string ReferenceButtonID = "btn_reference";
            public const string SaverityColumnHeadingID = "severity";
            public const string TimeStampColumnHeadingID = "time_stamp";
            public const string CodeColumnHeadingID = "code";
            public const string DescriptionColumnHeadingID = "description";
            public const string ColumnHeadingElementsXPath = "//div[@id = 'severity']/parent::div/div";
            public const string ErrorRowExpenstionArrowXPath = "//div[@id ='error0']/div/img";

            //Error popup
            public const string ErrorPopupDialogBoxXPath = "//mat-dialog-container[contains(@id, 'mat-dialog')]";
            public const string ErrorCodeTitleLabelID = "lbl_error_title";
            public const string ErrorCodeLabelID = "";
            public const string ErrorValueID = "";
            public const string ErrorDescriptionLabelID = "";
            public const string ErrorDescriptionValueID = "";
            public const string ErrorSolutionLabelID = "";
            public const string ErrorSolutionValueID = "";
            public const string ErrorReferenceLinkID = "ref_link";
            public const string ErrorCloseButtonID = "btn_close";


            //Centrella Details Summary
            public const string CentrellaDeviceSummarySubSectionID = "centrella_details_summary";
            public const string CentrellaAssetNameLabelID = "cen_lbl_asset_name";
            public const string CentrellaAssetNameValueID = "cen_asset_name";
            public const string CentrellaSerialNumberLabelID = "cen_lbl_serial";
            public const string CentrellaSerialNumberValueID = "cen_serial";
            public const string CentrellaModelLabelID = "cen_lbl_model";
            public const string CentrellaModelValueID = "cen_model";
            public const string CentrellaFacilityLabelID = "cen_lbl_facility";
            public const string CentrellaFacilityValueID = "cen_facility";
            public const string CentrellaLocationLabelID = "cen_lbl_loc";
            public const string CentrellaLocationValueID = "cen_loc";
            public const string CentrellaRoomBedLabelID = "cen_lbl_room";
            public const string CentrellaRoomBedValueID = "cen_room";
            public const string CentrellaFirmwareVersionLabelID = "cen_lbl_firmware";
            public const string CentrellaFirmwareVersionValueID = "cen_firmware";
            public const string CentrellaRadioIPAddressLabelID = "cen_lbl_radio";
            public const string CentrellaRadioIPAddressValueID = "cen_radio";
            public const string CentrellaRadioMACAddressLabelID = "cen_lbl_mac";
            public const string CentrellaRadioMACAddressValueID = "cen_mac";
            public const string CentrellaRadioSSIDLabelID = "cen_lbl_ssid";
            public const string CentrellaRadioSSIDValueID = "cen_ssid";
            public const string CentrellaRadioRSSILabelID = "cen_lbl_rssi";
            public const string CentrellaRadioRSSIValueID = "cen_rssi";
            public const string CentrellaConnectionStatusLabelID = "cen_lbl_connection";
            public const string CentrellaConnectionStatusValueID = "cen_connection";
            public const string CentrellaLastConnectedLabelID = "cen_lbl_last";
            public const string CentrellaLastConnectedValueID = "cen_last";
            public const string CentrellaLocateAssetButtonID = "cen-locate-asset";
            public const string CentrellaDeviceImageID = "centrella_img";

            //Preventive Maintenance Tab
            public const string PreventiveMaintenanceLabelID = "lbl-prev-maintenance";
            public const string RecentMaintenanceHistoryLabelID = "lbl-maintenance-history";
            public const string NoMaintenanceHistoryLabelXPath = "//*[@id = 'centrella-pre-maintenance-details']/div[2]/div[3]/span";
            public const string ServiceDatePickerControlID = "date_picker_icon";
            public const string SaveButtonClassName = "saveButton";
            public const string CancelButtonClassName = "cancelButton";
            public const string CurrentMaintenanceDateTextBoxID = "current-maintenance-date";
            public const string FirstRowOfTableID = "item0";
            public const string RecentlyAddedEntryDateXPath = "//div[@id = 'item0']/div[1]";
            public const string RecentlyAddedEntryUserXpath = "//div[@id = 'item0']/div[2]";
            public const string RecentlyAddedEntryModifiationDateTimeXPath = "//div[@id = 'item0']/div[3]";
            public const string ServiceDatePickerPreviousArrowXPath = "//button[contains(@class, 'previous-button')]";
            public const string MaintenanceDateColumnID = "lbl_maintenance_date";
            public const string UserIDColumnID = "lbl_user_id";
            public const string ModificationDateColumnID = "lbl_date";

            //Locate Asset Popup
            public const string APMappingLocateAssetPopupDialogXPath = "//mat-dialog-container[contains(@id, 'mat-dialog')]";
            public const string APMappingSourceLabelValueID = "lbl_source";
            public const string APMappingMacAddressLabelValueID = "lbl_mac";
            public const string APMappingRSSILabelValueID = "lbl_rssi";
            public const string APMappingAddAPMappingButtonID = "add_ap_mapping";
            public const string APMappingCloseButtonID = "close_ap_mapping";
            public const string APMappingEditAPMappingButtonID = "edit_ap_mapping";
            public const string APMappingCampusColumnHeadingID = "lbl_campus";
            public const string APMappingBuildingColumnHeadingID = "lbl_building";
            public const string APMappingFloorColumnHeadingID = "lbl_floor";
            public const string APMappingAPLocationColumnHeadingID = "lbl_ap_location";
            public const string APMappingCampusColumnValueID = "campus_value";
            public const string APMappingBuildingColumnValueID = "building_value";
            public const string APMappingFloorColumnValueID = "floor_value";
            public const string APMappingAPLocationColumnValueID = "aplocation_value";
            public const string APMappingCampusTextBoxID = "campus_input";
            public const string APMappingBuildingTextBoxID = "building_input";
            public const string APMappingFloorTextBoxID = "floor_input";
            public const string APMappingAPLocationTextBoxID = "aplocation_input";
            public const string APMappingSaveButtonID = "save_ap_mapping";

        }

        [FindsBy(How = How.Id, Using = Locators.APMappingSaveButtonID)]
        public IWebElement APMappingSaveButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.APMappingCampusColumnHeadingID)]
        public IWebElement APMappingCampusColumnHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.APMappingBuildingColumnHeadingID)]
        public IWebElement APMappingBuildingColumnHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.APMappingFloorColumnHeadingID)]
        public IWebElement APMappingFloorColumnHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.APMappingAPLocationColumnHeadingID)]
        public IWebElement APMappingAPLocationColumnHeading { get; set; }


        [FindsBy(How = How.Id, Using = Locators.APMappingCampusTextBoxID)]
        public IWebElement APMappingCampusTextBox { get; set; }

        [FindsBy(How = How.Id, Using = Locators.APMappingBuildingTextBoxID)]
        public IWebElement APMappingBuildingTextBox { get; set; }

        [FindsBy(How = How.Id, Using = Locators.APMappingFloorTextBoxID)]
        public IWebElement APMappingFloorTextBox { get; set; }

        [FindsBy(How = How.Id, Using = Locators.APMappingAPLocationTextBoxID)]
        public IWebElement APMappingAPLocationTextBox { get; set; }


        [FindsBy(How = How.Id, Using = Locators.APMappingCampusColumnValueID)]
        public IWebElement APMappingCampusColumnValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.APMappingBuildingColumnValueID)]
        public IWebElement APMappingBuildingColumnValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.APMappingFloorColumnValueID)]
        public IWebElement APMappingFloorColumnValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.APMappingAPLocationColumnValueID)]
        public IWebElement APMappingAPLocationColumnValue { get; set; }


        [FindsBy(How = How.Id, Using = Locators.APMappingEditAPMappingButtonID)]
        public IWebElement APMappingEditAPMappingButton { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.APMappingLocateAssetPopupDialogXPath)]
        public IWebElement APMappingLocateAssetPopupDialog { get; set; }


        [FindsBy(How = How.Id, Using = Locators.APMappingSourceLabelValueID)]
        public IWebElement APMappingSourceLabelValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.APMappingMacAddressLabelValueID)]
        public IWebElement APMappingMacAddressLabelValue { get; set; }
       
        [FindsBy(How = How.Id, Using = Locators.APMappingRSSILabelValueID)]
        public IWebElement APMappingRSSILabelValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.APMappingAddAPMappingButtonID)]
        public IWebElement APMappingAddAPMappingButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.APMappingCloseButtonID)]
        public IWebElement APMappingCloseButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.MaintenanceDateColumnID)]
        public IWebElement MaintenanceDateColumn { get; set; }


        [FindsBy(How = How.Id, Using = Locators.UserIDColumnID)]
        public IWebElement UserIDColumn { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ModificationDateColumnID)]
        public IWebElement ModificationDateColumn { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.ServiceDatePickerPreviousArrowXPath)]
        public IWebElement ServiceDatePickerPreviousArrow { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.RecentlyAddedEntryDateXPath)]
        public IWebElement RecentlyAddedEntryDate { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.RecentlyAddedEntryUserXpath)]
        public IWebElement RecentlyAddedEntryUser { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.RecentlyAddedEntryModifiationDateTimeXPath)]
        public IWebElement RecentlyAddedEntryModifiationDateTime { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CurrentMaintenanceDateTextBoxID)]
        public IWebElement CurrentMaintenanceDateTextBox { get; set; }


        [FindsBy(How = How.ClassName, Using = Locators.SaveButtonClassName)]
        public IWebElement SaveButton { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.CancelButtonClassName)]
        public IWebElement CancelButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PreventiveMaintenanceLabelID)]
        public IWebElement PreventiveMaintenanceLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.RecentMaintenanceHistoryLabelID)]
        public IWebElement RecentMaintenanceHistoryLabel { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.NoMaintenanceHistoryLabelXPath)]
        public IWebElement NoMaintenanceHistoryLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ServiceDatePickerControlID)]
        public IWebElement ServiceDatePickerControl { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaDeviceImageID)]
        public IWebElement CentrellaDeviceImage { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaDeviceSummarySubSectionID)]
        public IWebElement CentrellaDeviceSummarySubSection { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaAssetNameLabelID)]
        public IWebElement CentrellaAssetNameLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaAssetNameValueID)]
        public IWebElement CentrellaAssetNameValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaSerialNumberLabelID)]
        public IWebElement CentrellaSerialNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaSerialNumberValueID)]
        public IWebElement CentrellaSerialNumberValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaModelLabelID)]
        public IWebElement CentrellaModelLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaModelValueID)]
        public IWebElement CentrellaModelValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaFacilityLabelID)]
        public IWebElement CentrellaFacilityLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaFacilityValueID)]
        public IWebElement CentrellaFacilityValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaLocationLabelID)]
        public IWebElement CentrellaLocationLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaLocationValueID)]
        public IWebElement CentrellaLocationValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaRoomBedLabelID)]
        public IWebElement CentrellaRoomBedLabel { get; set; }


        [FindsBy(How = How.Id, Using = Locators.CentrellaRoomBedValueID)]
        public IWebElement CentrellaRoomBedValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaFirmwareVersionLabelID)]
        public IWebElement CentrellaFirmwareVersionLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaFirmwareVersionValueID)]
        public IWebElement CentrellaFirmwareVersionValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaRadioIPAddressLabelID)]
        public IWebElement CentrellaRadioIPAddressLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaRadioIPAddressValueID)]
        public IWebElement CentrellaRadioIPAddressValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaRadioMACAddressLabelID)]
        public IWebElement CentrellaRadioMACAddressLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaRadioMACAddressValueID)]
        public IWebElement CentrellaRadioMACAddressValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaRadioSSIDLabelID)]
        public IWebElement CentrellaRadioSSIDLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaRadioSSIDValueID)]
        public IWebElement CentrellaRadioSSIDValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaRadioRSSILabelID)]
        public IWebElement CentrellaRadioRSSILabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaRadioRSSIValueID)]
        public IWebElement CentrellaRadioRSSIValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaConnectionStatusLabelID)]
        public IWebElement CentrellaConnectionStatusLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaConnectionStatusValueID)]
        public IWebElement CentrellaConnectionStatusValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaLastConnectedLabelID)]
        public IWebElement CentrellaLastConnectedLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaLastConnectedValueID)]
        public IWebElement CentrellaLastConnectedValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CentrellaLocateAssetButtonID)]
        public IWebElement CentrellaLocateAssetButton { get; set; }


        [FindsBy(How = How.Id, Using = Locators.ErrorCloseButtonID)]
        public IWebElement ErrorCloseButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ErrorSolutionValueID)]
        public IWebElement ErrorSolutionValue { get; set; }
        
        [FindsBy(How = How.Id, Using = Locators.ErrorReferenceLinkID)]
        public IWebElement ErrorReferenceLink { get; set; }


        [FindsBy(How = How.Id, Using = Locators.ErrorCodeTitleLabelID)]
        public IWebElement ErrorCodeTitleLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ErrorCodeLabelID)]
        public IWebElement ErrorCodeLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ErrorValueID)]
        public IWebElement ErrorValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ErrorDescriptionLabelID)]
        public IWebElement ErrorDescriptionLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ErrorDescriptionValueID)]
        public IWebElement ErrorDescriptionValue { get; set; }


        [FindsBy(How = How.Id, Using = Locators.ErrorSolutionLabelID)]
        public IWebElement ErrorSolutionLabel { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.ErrorPopupDialogBoxXPath)]
        public IWebElement ErrorPopupDialogBox { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.ErrorRowExpenstionArrowXPath)]
        public IWebElement ErrorRowExpenstionArrow { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.ColumnHeadingElementsXPath)]
        public IList<IWebElement> ColumnHeadingElements { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SaverityColumnHeadingID)]
        public IWebElement SaverityColumnHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.TimeStampColumnHeadingID)]
        public IWebElement TimeStampColumnHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CodeColumnHeadingID)]
        public IWebElement CodeColumnHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DescriptionColumnHeadingID)]
        public IWebElement DescriptionColumnHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ReferenceButtonID)]
        public IWebElement ReferenceButton { get; set; }


        [FindsBy(How = How.XPath, Using = Locators.ErrorCodeTabXPath)]
        public IWebElement ErrorCodeTab { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.PreventiveMaintenanceTabXPath)]
        public IWebElement PreventiveMaintenanceTab { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.NoErrorReportedLabelXPath)]
        public IWebElement NoErrorReportedLabel { get; set; }

        public IWebElement RandomDate()
        {
            Random ran = new Random();
            randomDate = ran.Next(1, 28).ToString();
            IWebElement date = PropertyClass.Driver.FindElement(By.XPath("//td/div[contains(text(),'" + randomDate + "')]"));
            return date;
        }

        public string SelectedDate()
        {
            return DateTime.Now.Month-1 + "/" + randomDate + "/" + DateTime.Now.Year;
        }
    }
}
