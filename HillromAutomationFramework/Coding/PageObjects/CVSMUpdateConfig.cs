using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HillromAutomationFramework.Coding.PageObjects
{
    class CVSMUpdateConfig
    {
        public static class Locators
        {
            public const string AssetTypeLabelID = "lbl_asset_type";
            public const string AssetTypeDropDownID = "modelFilter";
            public const string UpgradeTypeLabelID = "lbl_update_type";
            public const string UpgradeTypeDropDownID = "typeFilter";
            public const string SelectUpdateTabID = "select_update";
            public const string SelectUpdateCircleID = "circle1";
            public const string SelectDeviceTabID = "select_asset";
            public const string SelectDeviceCircleID = "circle2";
            public const string ReveiewActionTabID = "select_review";
            public const string ReviewActionTabCircleID = "circle3";

            //select update
            public const string ConfigListClassName = "config-list";
            public const string NameColumnHeadingID = "config-heading-name";
            public const string DateColumnHeadingID = "config-heading-date";
            public const string FirstConfigFileID = "cvsm_config0";
            public const string SelectUpdateNextButtonID = "update";
            public const string DeleteButtonID = "delete";
            

            //select devices
            public const string DeployHeadID = "deployhead";
            public const string ItemtoPushID = "lbl_item_to_push";
            public const string DeviceTypeLabelID = "device_type";
            public const string TypeofUpdateLabelID = "config";
            public const string ConfigFileNameID = "file_name";
            public const string DestinationLabelID = "lbl_destination";
            public const string DeviceCountID = "destination_count";
            public const string LocationHierarchyID = "caret0";
            public const string SelectAllcheckBoxID = "check_all";
            public const string FirmwareHeadingID = "firmware";
            public const string ConfigHeadingID = "Config";
            public const string AssetTagHeadingID = "AssetTag";
            public const string SerialNoHeadingID = "Sno";
            public const string LocationHeadingID = "Location";
            public const string LastFilesDeployedHeadingID = "LastFile";
            public const string FirstDeviceCheckBoxID = "checkbox-0";

            //review action
            public const string ReviewActionPushItemsID = "push-item";
            public const string ReviewActionItemToPushLabelID = "lbl_push_item";
            public const string ReviewActionItemToPushValueID = "push_item_value";
            public const string ReviewActionDestinationLabelXpath = "/html/body/c8y-bootstrap/div/div[2]/div/c8y-hillrom-home-page/c8y-hillrom-landing-page/div/div/div[2]/c8y-hillrom-cvsm-deployment/div/div[1]/div[6]/div/div[2]/span";
            public const string ReviewActionDestinationValueID = "destination_value";
            public const string ReviewActionConfirmButtonID = "confirm";
            public const string SucessUpadteMessageXpath = "//*[@id=\"cdk-overlay-1\"]/snack-bar-container/simple-snack-bar";

            public const string HighlightedSectionHeadingClassName = "wizardHeadings selection";
            public const string PreviousButtonID = "previous";
            public const string SelectDevicesNextButtonID = "nextbtn";
            public const string PaginationPreviousIconID = "previous";
            public const string PaginationNextIconID = "next";
            public const string DisplayXYPaginationTextID = "pagination_text";
            public const string PaginationXOfYID = "pagination";
        }

        public static class Inputs
        {
            public const string CVSMDeviceName = "Connex Vital Signs Monitor (CVSM)";
        }
        public static class ExpectedValues
        {
            public const string HighlightedSectionCircleClassName = "circle selectedStep";
            public const string UpdateTypeDropdownDefault = "Select";
            public const string UpdateTypeConfiguration = "Configuration";

            //select update
            public const string NameHeadingText = "Name";
            public const string DateColumnHeadingText = "Date created";

            //select devices or select assets
            public const string ItemToPushLabelText = "Item to push";
            public const string DestinationLabelText = "DESTINATIONS";
            public const string FirwareHeadingText = "Firmware";
            public const string ConfigHeadingText = "Config";
            public const string AssetTagHeadingText = "Asset Tag";
            public const string SerialHeadingText = "Serial";
            public const string LocationHeadingText = "Location";
            public const string LastFilesDeployedHeadingText = "Last Files Deployed";
            public const string Desination1DeviceCountText = "1 assets selected in 1 locations";
        }

        public CVSMUpdateConfig()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        [FindsBy(How =How.Id,Using =Locators.AssetTypeLabelID)]
        public IWebElement AssetTypeLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.AssetTypeDropDownID)]
        public IWebElement AssetTypeDropDown { get; set; }

        [FindsBy(How = How.Id, Using = Locators.UpgradeTypeLabelID)]
        public IWebElement UpgradeTypeLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.UpgradeTypeDropDownID)]
        public IWebElement UpgradeTypeDropDown { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SelectUpdateTabID)]
        public IWebElement SelectUpdateTab { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SelectUpdateCircleID)]
        public IWebElement SelectUpdateCircle { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SelectDeviceTabID)]
        public IWebElement SelectDeviceTab { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SelectDeviceCircleID)]
        public IWebElement SelectDeviceCircle { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ReveiewActionTabID)]
        public IWebElement ReveiewActionTab { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ReviewActionTabCircleID)]
        public IWebElement ReviewActionTabCircle { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.HighlightedSectionHeadingClassName)]
        public IWebElement HighlightedSectionHeading { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.ConfigListClassName)]
        public IWebElement ConfigList { get; set; }

        [FindsBy(How = How.Id, Using = Locators.NameColumnHeadingID)]
        public IWebElement NameColumnHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DateColumnHeadingID)]
        public IWebElement DateColumnHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.FirstConfigFileID)]
        public IWebElement FirstConfigFile { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SelectUpdateNextButtonID)]
        public IWebElement SelectUpdateNextButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeleteButtonID)]
        public IWebElement DeleteButton { get; set; }

        //select devices
        [FindsBy(How = How.Id, Using = Locators.DeployHeadID)]
        public IWebElement DeployHead { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ItemtoPushID)]
        public IWebElement ItemtoPush { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeviceTypeLabelID)]
        public IWebElement DeviceTypeLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.TypeofUpdateLabelID)]
        public IWebElement TypeofUpdateLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ConfigFileNameID)]
        public IWebElement ConfigFileName { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DestinationLabelID)]
        public IWebElement DestinationLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeviceCountID)]
        public IWebElement DeviceCount { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LocationHierarchyID)]
        public IWebElement LocationHierarchy { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SelectAllcheckBoxID)]
        public IWebElement SelectAllcheckBox { get; set; }

        [FindsBy(How = How.Id, Using = Locators.FirmwareHeadingID)]
        public IWebElement FirmwareHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ConfigHeadingID)]
        public IWebElement ConfigHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.AssetTagHeadingID)]
        public IWebElement AssetTagHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SerialNoHeadingID)]
        public IWebElement SerialNoHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LocationHeadingID)]
        public IWebElement LocationHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LastFilesDeployedHeadingID)]
        public IWebElement LastFilesDeployedHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.FirstDeviceCheckBoxID)]
        public IWebElement FirstDeviceCheckBox { get; set; }

        //Review action page elements
        [FindsBy(How = How.Id, Using = Locators.ReviewActionPushItemsID)]
        public IWebElement ReviewActionPushItems { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ReviewActionItemToPushLabelID)]
        public IWebElement ReviewActionItemToPushLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ReviewActionItemToPushValueID)]
        public IWebElement ReviewActionItemToPushValue { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.ReviewActionDestinationLabelXpath)]
        public IWebElement ReviewActionDestinationLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ReviewActionDestinationValueID)]
        public IWebElement ReviewActionDestinationValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ReviewActionConfirmButtonID)]
        public IWebElement ReviewActionConfirmButton { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.SucessUpadteMessageXpath)]
        public IWebElement SucessUpadteMessage { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PreviousButtonID)]
        public IWebElement PreviousButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SelectDevicesNextButtonID)]
        public IWebElement SelectDevicesNextButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PaginationPreviousIconID)]
        public IWebElement PaginationPreviousIcon { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PaginationNextIconID)]
        public IWebElement PaginationNextIcon { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DisplayXYPaginationTextID)]
        public IWebElement DisplayPaginationText { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PaginationXOfYID)]
        public IWebElement PaginationXOfY { get; set; }
    }
}
