using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace HillromAutomationFramework.PageObjects.AssetsTab
{
    class ProgressaDeviceDetailsPage
    {
        public string randomDate;
        public ProgressaDeviceDetailsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public class Locators
        {
            public const string ErrorCodeTabXPath = "//div[@class = 'mat-tab-list']/div/div[1]";
            public const string PreventiveMaintenanceTabXPath = "//div[@class = 'mat-tab-list']/div/div[2]";
            public const string NoErrorReportedLabelID = "//*[@id='centrella-errorcode-details']/div[2]/span";
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
            public const string ErrorCodeLabelID = "lbl_errorCode";
            public const string ErrorCodeValueID = "error_code";
            public const string ErrorDescriptionLabelID = "lbl_description";
            public const string ErrorDescriptionValueID = "short_desc";
            public const string ErrorSolutionLabelID = "lbl_solution";
            public const string ErrorSolutionValueID = "error_sol";
            public const string ErrorReferenceLinkID = "ref_link";
            public const string ErrorCloseButtonID = "btn_close";


            //Progressa Details Summary
            public const string ProgressaDeviceSummarySubSectionID = "centrella_details_summary";
            public const string ProgressaAssetNameLabelID = "cen_lbl_asset_name";
            public const string ProgressaAssetNameValueID = "cen_asset_name";
            public const string ProgressaSerialNumberLabelID = "cen_lbl_serial";
            public const string ProgressaSerialNumberValueID = "cen_serial";
            public const string ProgressaModelLabelID = "cen_lbl_model";
            public const string ProgressaModelValueID = "cen_model";
            public const string ProgressaFacilityLabelID = "cen_lbl_facility";
            public const string ProgressaFacilityValueID = "cen_facility";
            public const string ProgressaLocationLabelID = "cen_lbl_loc";
            public const string ProgressaLocationValueID = "cen_loc";
            public const string ProgressaRoomBedLabelID = "cen_lbl_room";
            public const string ProgressaRoomBedValueID = "cen_room";
            public const string ProgressaFirmwareVersionLabelID = "cen_lbl_firmware";
            public const string ProgressaFirmwareVersionValueID = "cen_firmware";
            public const string ProgressaRadioIPAddressLabelID = "cen_lbl_radio";
            public const string ProgressaRadioIPAddressValueID = "cen_radio";
            public const string ProgressaRadioMACAddressLabelID = "cen_lbl_mac";
            public const string ProgressaRadioMACAddressValueID = "cen_mac";
            public const string ProgressaRadioSSIDLabelID = "cen_lbl_ssid";
            public const string ProgressaRadioSSIDValueID = "cen_ssid";
            public const string ProgressaRadioRSSILabelID = "cen_lbl_rssi";
            public const string ProgressaRadioRSSIValueID = "cen_rssi";
            public const string ProgressaConnectionStatusLabelID = "cen_lbl_connection";
            public const string ProgressaConnectionStatusValueID = "cen_connection";
            public const string ProgressaLastConnectedLabelID = "cen_lbl_last";
            public const string ProgressaLastConnectedValueID = "cen_last";
            public const string ProgressaLocateAssetButtonID = "cen-locate-asset";
            public const string ProgressaDeviceImageID = "centrella_img";

            //Preventive Maintenance Tab
            public const string ProgressaPreventiveMaintenanceLabelID = "lbl-prev-maintenance";
            public const string ProgressaRecentMaintenanceHistoryLabelID = "lbl-maintenance-history";
            public const string ProgressaNoMaintenanceHistoryLabelID = "//span[contains(text(),'There is no maintenance history.')]";
            public const string ProgressaServiceDatePickerControlID = "date_picker_icon";
            public const string ProgressaSaveButtonClassName = "saveButton";
            public const string ProgressaCancelButtonClassName = "cancelButton";
            public const string ProgressaCurrentMaintenanceDateTextBoxID = "current-maintenance-date";
            public const string ProgressaFirstRowOfTableID = "item0";
            public const string ProgressaRecentlyAddedEntryDateXPath = "//div[@id = 'item0']/div[1]";
            public const string ProgressaRecentlyAddedEntryUserXpath = "//div[@id = 'item0']/div[2]";
            public const string ProgressaRecentlyAddedEntryModifiationDateTimeXPath = "//div[@id = 'item0']/div[3]";
            public const string ProgressaServiceDatePickerPreviousArrowXPath = "//button[contains(@class, 'previous-button')]";
            public const string ProgressaMaintenanceDateColumnID = "lbl_maintenance_date";
            public const string ProgressaUserIDColumnID = "lbl_user_id";
            public const string ProgressaModificationDateColumnID = "lbl_date";

            //Locate Asset Popup
            public const string ProgressaAPMappingLocateAssetPopupDialogXPath = "//mat-dialog-container[contains(@id, 'mat-dialog')]";
            public const string ProgressaAPMappingSourceLabelValueID = "lbl_source";
            public const string ProgressaAPMappingMacAddressLabelValueID = "lbl_mac";
            public const string ProgressaAPMappingRSSILabelValueID = "lbl_rssi";
            public const string ProgressaAPMappingAddAPMappingButtonID = "add_ap_mapping";
            public const string ProgressaAPMappingCloseButtonID = "close_ap_mapping";
            public const string ProgressaAPMappingEditAPMappingButtonID = "edit_ap_mapping";
            public const string ProgressaAPMappingCampusColumnHeadingID = "lbl_campus";
            public const string ProgressaAPMappingBuildingColumnHeadingID = "lbl_building";
            public const string ProgressaAPMappingFloorColumnHeadingID = "lbl_floor";
            public const string ProgressaAPMappingAPLocationColumnHeadingID = "lbl_ap_location";
            public const string ProgressaAPMappingCampusColumnValueID = "campus_value";
            public const string ProgressaAPMappingBuildingColumnValueID = "building_value";
            public const string ProgressaAPMappingFloorColumnValueID = "floor_value";
            public const string ProgressaAPMappingAPLocationColumnValueID = "aplocation_value";
            public const string ProgressaAPMappingCampusTextBoxID = "campus_input";
            public const string ProgressaAPMappingBuildingTextBoxID = "building_input";
            public const string ProgressaAPMappingFloorTextBoxID = "floor_input";
            public const string ProgressaAPMappingAPLocationTextBoxID = "aplocation_input";
            public const string ProgressaAPMappingSaveButtonID = "save_ap_mapping";

        }

        [FindsBy(How = How.Id, Using = Locators.ProgressaAPMappingSaveButtonID)]
        public IWebElement ProgressaAPMappingSaveButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaAPMappingCampusColumnHeadingID)]
        public IWebElement ProgressaAPMappingCampusColumnHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaAPMappingBuildingColumnHeadingID)]
        public IWebElement ProgressaAPMappingBuildingColumnHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaAPMappingFloorColumnHeadingID)]
        public IWebElement ProgressaAPMappingFloorColumnHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaAPMappingAPLocationColumnHeadingID)]
        public IWebElement ProgressaAPMappingAPLocationColumnHeading { get; set; }


        [FindsBy(How = How.Id, Using = Locators.ProgressaAPMappingCampusTextBoxID)]
        public IWebElement ProgressaAPMappingCampusTextBox { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaAPMappingBuildingTextBoxID)]
        public IWebElement ProgressaAPMappingBuildingTextBox { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaAPMappingFloorTextBoxID)]
        public IWebElement ProgressaAPMappingFloorTextBox { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaAPMappingAPLocationTextBoxID)]
        public IWebElement ProgressaAPMappingAPLocationTextBox { get; set; }


        [FindsBy(How = How.Id, Using = Locators.ProgressaAPMappingCampusColumnValueID)]
        public IWebElement ProgressaAPMappingCampusColumnValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaAPMappingBuildingColumnValueID)]
        public IWebElement ProgressaAPMappingBuildingColumnValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaAPMappingFloorColumnValueID)]
        public IWebElement ProgressaAPMappingFloorColumnValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaAPMappingAPLocationColumnValueID)]
        public IWebElement ProgressaAPMappingAPLocationColumnValue { get; set; }


        [FindsBy(How = How.Id, Using = Locators.ProgressaAPMappingEditAPMappingButtonID)]
        public IWebElement ProgressaAPMappingEditAPMappingButton { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.ProgressaAPMappingLocateAssetPopupDialogXPath)]
        public IWebElement ProgressaAPMappingLocateAssetPopupDialog { get; set; }


        [FindsBy(How = How.Id, Using = Locators.ProgressaAPMappingSourceLabelValueID)]
        public IWebElement ProgressaAPMappingSourceLabelValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaAPMappingMacAddressLabelValueID)]
        public IWebElement ProgressaAPMappingMacAddressLabelValue { get; set; }
       
        [FindsBy(How = How.Id, Using = Locators.ProgressaAPMappingRSSILabelValueID)]
        public IWebElement ProgressaAPMappingRSSILabelValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaAPMappingAddAPMappingButtonID)]
        public IWebElement ProgressaAPMappingAddAPMappingButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaAPMappingCloseButtonID)]
        public IWebElement ProgressaAPMappingCloseButton { get; set; }


        [FindsBy(How = How.Id, Using = Locators.ProgressaMaintenanceDateColumnID)]
        public IWebElement ProgressaMaintenanceDateColumn { get; set; }


        [FindsBy(How = How.Id, Using = Locators.ProgressaUserIDColumnID)]
        public IWebElement ProgressaUserIDColumn { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaModificationDateColumnID)]
        public IWebElement ProgressaModificationDateColumn { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.ProgressaServiceDatePickerPreviousArrowXPath)]
        public IWebElement ProgressaServiceDatePickerPreviousArrow { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.ProgressaRecentlyAddedEntryDateXPath)]
        public IWebElement ProgressaRecentlyAddedEntryDate { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.ProgressaRecentlyAddedEntryUserXpath)]
        public IWebElement ProgressaRecentlyAddedEntryUser { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.ProgressaRecentlyAddedEntryModifiationDateTimeXPath)]
        public IWebElement ProgressaRecentlyAddedEntryModifiationDateTime { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaCurrentMaintenanceDateTextBoxID)]
        public IWebElement ProgressaCurrentMaintenanceDateTextBox { get; set; }


        [FindsBy(How = How.ClassName, Using = Locators.ProgressaSaveButtonClassName)]
        public IWebElement ProgressaSaveButton { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.ProgressaCancelButtonClassName)]
        public IWebElement ProgressaCancelButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaPreventiveMaintenanceLabelID)]
        public IWebElement ProgressaPreventiveMaintenanceLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaRecentMaintenanceHistoryLabelID)]
        public IWebElement ProgressaRecentMaintenanceHistoryLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaNoMaintenanceHistoryLabelID)]
        public IWebElement ProgressaNoMaintenanceHistoryLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaServiceDatePickerControlID)]
        public IWebElement ProgressaServiceDatePickerControl { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaDeviceImageID)]
        public IWebElement ProgressaDeviceImage { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaDeviceSummarySubSectionID)]
        public IWebElement ProgressaDeviceSummarySubSection { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaAssetNameLabelID)]
        public IWebElement ProgressaAssetNameLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaAssetNameValueID)]
        public IWebElement ProgressaAssetNameValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaSerialNumberLabelID)]
        public IWebElement ProgressaSerialNumberLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaSerialNumberValueID)]
        public IWebElement ProgressaSerialNumberValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaModelLabelID)]
        public IWebElement ProgressaModelLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaModelValueID)]
        public IWebElement ProgressaModelValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaFacilityLabelID)]
        public IWebElement ProgressaFacilityLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaFacilityValueID)]
        public IWebElement ProgressaFacilityValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaLocationLabelID)]
        public IWebElement ProgressaLocationLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaLocationValueID)]
        public IWebElement ProgressaLocationValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaRoomBedLabelID)]
        public IWebElement ProgressaRoomBedLabel { get; set; }


        [FindsBy(How = How.Id, Using = Locators.ProgressaRoomBedValueID)]
        public IWebElement ProgressaRoomBedValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaFirmwareVersionLabelID)]
        public IWebElement ProgressaFirmwareVersionLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaFirmwareVersionValueID)]
        public IWebElement ProgressaFirmwareVersionValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaRadioIPAddressLabelID)]
        public IWebElement ProgressaRadioIPAddressLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaRadioIPAddressValueID)]
        public IWebElement ProgressaRadioIPAddressValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaRadioMACAddressLabelID)]
        public IWebElement ProgressaRadioMACAddressLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaRadioMACAddressValueID)]
        public IWebElement ProgressaRadioMACAddressValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaRadioSSIDLabelID)]
        public IWebElement ProgressaRadioSSIDLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaRadioSSIDValueID)]
        public IWebElement ProgressaRadioSSIDValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaRadioRSSILabelID)]
        public IWebElement ProgressaRadioRSSILabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaRadioRSSIValueID)]
        public IWebElement ProgressaRadioRSSIValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaConnectionStatusLabelID)]
        public IWebElement ProgressaConnectionStatusLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaConnectionStatusValueID)]
        public IWebElement ProgressaConnectionStatusValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaLastConnectedLabelID)]
        public IWebElement ProgressaLastConnectedLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaLastConnectedValueID)]
        public IWebElement ProgressaLastConnectedValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ProgressaLocateAssetButtonID)]
        public IWebElement ProgressaLocateAssetButton { get; set; }


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

        [FindsBy(How = How.Id, Using = Locators.ErrorCodeValueID)]
        public IWebElement ErrorCodeValue { get; set; }

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

        [FindsBy(How = How.Id, Using = Locators.NoErrorReportedLabelID)]
        public IWebElement NoErrorReportedLabel { get; set; }

        public IWebElement RandomDate(IWebDriver driver)
        {
            Random ran = new Random();
            randomDate = ran.Next(1, 28).ToString();
            IWebElement date = driver.FindElement(By.XPath("//td/div[contains(text(),'" + randomDate + "')]"));
            return date;
        }

        public string SelectedDate()
        {
            return DateTime.Now.Month-1 + "/" + randomDate + "/" + DateTime.Now.Year;
        }
    }
}
