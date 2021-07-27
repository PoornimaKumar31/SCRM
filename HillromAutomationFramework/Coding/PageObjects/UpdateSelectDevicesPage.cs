using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HillromAutomationFramework.Coding.PageObjects
{
    class UpdateSelectDevicesPage
    {
        public static class Locators
        {
            public const string HeadingID = "select_asset";
            public const string DeployHeadID = "deployhead";
            public const string ItemtoPushID = "lbl_item_to_push";
            public const string DeviceTypeLabelID = "device_type";
            public const string TypeofUpdateConfigLabelID = "config";
            public const string TypeOfUpdateUpgradeLabelID = "upgrade";
            public const string FileNameID = "file_name";
            public const string DestinationLabelID = "lbl_destination";
            public const string DeviceCountID = "destination_count";
            public const string LocationHierarchyID = "caret0";

            //Tables
            public const string TableHeadingXpath = "//*[@id=\"configure-items\"]/div[3]/div[2]/div[2]";
            public const string SelectAllcheckBoxID = "check_all";
            public const string FirmwareHeadingID = "firmware";
            public const string ConfigHeadingID = "Config";
            public const string AssetTagHeadingID = "AssetTag";
            public const string SerialNoHeadingID = "Sno";
            public const string LocationHeadingID = "Location";
            public const string LastFilesDeployedHeadingID = "LastFile";
            public const string FirstDeviceCheckBoxID = "checkbox-0";

            //button
            public const string PreviousButtonID = "previousbtn";
            public const string NextButtonID = "nextbtn";

            public const string SuccessUpadteMessageXpath = "//div[@id=\"snackbar\"]";

            //Pagination
            public const string PaginationPreviousIconID = "previous";
            public const string PaginationNextIconID = "next";
            public const string PaginationXofYID = "pagination";
            public const string PaginationDisplayXYID = "pagination_text";
        }
        public static class ExpectedValues
        {
            //Color of selected tab
            public const string HighlightedHeadingColor = "rgba(84, 104, 229, 1)";
            public const string NonHighlightedHeadingColor = "rgba(68, 68, 68, 1)";

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

        public UpdateSelectDevicesPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        [FindsBy(How = How.Id, Using = Locators.HeadingID)]
        public IWebElement Heading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeployHeadID)]
        public IWebElement DeployHead { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ItemtoPushID)]
        public IWebElement ItemtoPush { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeviceTypeLabelID)]
        public IWebElement DeviceTypeLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.TypeofUpdateConfigLabelID)]
        public IWebElement TypeofUpdateConfigLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.TypeOfUpdateUpgradeLabelID)]
        public IWebElement TypeOfUpdateUpgradeLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.FileNameID)]
        public IWebElement FileName { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DestinationLabelID)]
        public IWebElement DestinationLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeviceCountID)]
        public IWebElement DeviceCount { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LocationHierarchyID)]
        public IWebElement LocationHierarchy { get; set; }

        //tables
        [FindsBy(How = How.XPath, Using = Locators.TableHeadingXpath)]
        public IWebElement TableHeading { get; set; }


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

        //button
        [FindsBy(How = How.Id, Using = Locators.PreviousButtonID)]
        public IWebElement PreviousButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.NextButtonID)]
        public IWebElement NextButton { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.SuccessUpadteMessageXpath)]
        public IWebElement SuccessUpadteMessage { get; set; }

        //pagination
        [FindsBy(How = How.Id, Using = Locators.PaginationPreviousIconID)]
        public IWebElement PaginationPreviousIcon { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PaginationNextIconID)]
        public IWebElement PaginationNextIcon { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PaginationXofYID)]
        public IWebElement PaginationXofY { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PaginationDisplayXYID)]
        public IWebElement PaginationDisplayXY { get; set; }
    }
}
