using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HillromAutomationFramework.Coding.PageObjects
{
    class CSMConfigDeliverPage
    {
        public static class Locators
        {
            //tabs ID
            public const string SelectUpdateTabId = "select_update";
            public const string SelectDevicesTabId = "select_asset";
            public const string ReviewActionTabId = "select_review";

            //tabs circle id
            public const string SelectUpdateCircleID = "circle1";
            public const string SelectDevicesCircleID = "circle2";
            public const string ReviewActionCircleID = "circle3";

            public const string AssetTypeDropDownID = "modelFilter";
            public const string UpdateTypeDropDownID = "typeFilter";
            public const string ConfigListClassName = "config-list";
            public const string ConfigListTableNameHeadingID = "config-heading-name";
            public const string ConfigListTableDateHeadingID = "config-heading-date";
            public const string SelectUpdateNextButtonID = "update";
            public const string PaginationXOfYID = "pagination";
            public const string PaginationDisplayXYClassName = "dataTables_info";
            public const string FirstConfigFileID = "config0";
            public const string ConfigFileNameID = "name";
            public const string PaginationPreviousIconXpath = "/html/body/c8y-bootstrap/div/div[2]/div/c8y-hillrom-home-page/c8y-hillrom-landing-page/div/div/div[2]/c8y-hillrom-updates/div/div[1]/div[3]/div[2]/div/c8y-hillrom-csm-configure-list/div[54]/div[2]/span[1]";
            public const string PaginationNextIconID = "next";

            //select devices
            public const string ItemToPushLabelID = "lbl_item_to_push";
            public const string DestinationDeviceCountID = "destination_count";
            public const string DeviceTypeID = "device_type";
            public const string UpdateTypeID = "config";
            public const string ConfigFileToPushID = "file_name";
            public const string DestinationLabelID = "lbl_destination";
            public const string LocationHirarcyID = "caret0";
            public const string PreviousButtonXpath = "/html/body/c8y-bootstrap/div/div[2]/div/c8y-hillrom-home-page/c8y-hillrom-landing-page/div/div/div[2]/c8y-hillrom-cvsm-deployment/div/div[2]/div/button[1]";
            public const string SelectDeviceNextButtonID = "nextbtn";
            //select device table elements
            public const string SelectAllDeviceCheckBoxID = "selectall";
            public const string FirmwareHeadingID = "firmware";
            public const string ConfigHeadingID = "Config";
            public const string AssetTagHeadingID = "AssetTag";
            public const string SerialHeadingID = "Sno";
            public const string LocationHeadingID = "Location";
            public const string LastFilesDeployedHeadingID = "LastFile";
        }

        public static class ExpectedValues
        {
            public const string CSMDeviceName = "Connex Spot Monitor (CSM)";
            public const string UpdateTypeConfiguration = "Configuration";
            public const string UpdateTypeUpgrade = "Upgrade";
            public const string ConfigListTableNameHeadingText = "Name";
            public const string ConfigListTableDateHeadingText = "Date created";

            //select device heading text
            public const string FirmwareHeadingText = "Firmware";
            public const string ConfigHeadingText = "Config";
            public const string AssetTagHeadingText = "Asset tag";
            public const string SerialHeadingText = "Serial";
            public const string LocationHeadingText = "Location";
            public const string LastFilesDeployedHeadingText = "Last Files Deployed";

            public const string HighlightedCircleClassName = "circle selectedStep";
        }

        public CSMConfigDeliverPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        [FindsBy(How = How.Id, Using = Locators.SelectUpdateTabId)]
        public IWebElement SelectUpdateTab { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SelectDevicesTabId)]
        public IWebElement SelectDevicesTab { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ReviewActionTabId)]
        public IWebElement ReviewActionTab { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SelectUpdateCircleID)]
        public IWebElement SelectUpdateCircle { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SelectDevicesCircleID)]
        public IWebElement SelectDevicesCircle { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ReviewActionCircleID)]
        public IWebElement ReviewActionCircle { get; set; }

        [FindsBy(How =How.Id, Using =Locators.AssetTypeDropDownID)]
        public IWebElement AssetTypeDropDown { get; set; }

        [FindsBy(How = How.Id, Using = Locators.UpdateTypeDropDownID)]
        public IWebElement UpdateTypeDropDown { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.ConfigListClassName)]
        public IWebElement ConfigList { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ConfigListTableNameHeadingID)]
        public IWebElement ConfigListTableNameHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ConfigListTableDateHeadingID)]
        public IWebElement ConfigListTableDateHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SelectUpdateNextButtonID)]
        public IWebElement SelectUpdateNextButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PaginationXOfYID)]
        public IWebElement PaginationXOfY { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.PaginationDisplayXYClassName)]
        public IWebElement PaginationDisplayXY { get; set; }

        [FindsBy(How = How.Id, Using = Locators.FirstConfigFileID)]
        public IWebElement FirstConfigFile { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ConfigFileNameID)]
        public IList<IWebElement> ConfigFileName { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.PaginationPreviousIconXpath)]
        public IWebElement PaginationPreviousIcon { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PaginationNextIconID)]
        public IWebElement PaginationNextIcon { get; set; }


        //select devices
        [FindsBy(How = How.Id, Using = Locators.ItemToPushLabelID)]
        public IWebElement ItemToPushLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeviceTypeID)]
        public IWebElement DeviceType { get; set; }

        [FindsBy(How = How.Id, Using = Locators.UpdateTypeID)]
        public IWebElement UpdateType { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ConfigFileToPushID)]
        public IWebElement ConfigFileToPush { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DestinationLabelID)]
        public IWebElement DestinationLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LocationHirarcyID)]
        public IWebElement LocationHirarcy { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DestinationDeviceCountID)]
        public IWebElement DestinationDeviceCount { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.PreviousButtonXpath)]
        public IWebElement PreviousButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SelectDeviceNextButtonID)]
        public IWebElement SelectDeviceNextButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SelectAllDeviceCheckBoxID)]
        public IWebElement SelectAllDeviceCheckBox { get; set; }

        //select device table elements
        [FindsBy(How = How.Id, Using = Locators.FirmwareHeadingID)]
        public IWebElement FirmwareHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ConfigHeadingID)]
        public IWebElement ConfigHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.AssetTagHeadingID)]
        public IWebElement AssetTagHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SerialHeadingID)]
        public IWebElement SerialHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LocationHeadingID)]
        public IWebElement LocationHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LastFilesDeployedHeadingID)]
        public IWebElement LastFilesDeployedHeading { get; set; }

        public bool IsConfigFileSorted(IList<IWebElement> elements)
        {
            List<string> configListName = new List<string>();
            foreach(IWebElement configname in elements)
            {
                configListName.Add(configname.Text.ToString());
            }
            List<string> UnSortedList = new List<string>(configListName);
            configListName.Sort((s1,s2) => s1.CompareTo(s2));
            return (Enumerable.SequenceEqual(configListName, UnSortedList));
        }
    }
}
