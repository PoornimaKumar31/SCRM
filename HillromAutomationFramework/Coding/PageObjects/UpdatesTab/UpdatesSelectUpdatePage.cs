using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HillromAutomationFramework.Coding.PageObjects
{
    class UpdatesSelectUpdatePage
    {
        public static class Locators
        {
            public const string HeadingID = "select_update";
            public const string AssetTypeLabelID = "lbl_asset_type";
            public const string AssetTypeDropDownID = "modelFilter";
            public const string UpgradeTypeLabelID = "lbl_update_type";
            public const string UpgradeTypeDropDownID = "typeFilter";
            public const string ManageActiveUpgradesButtonID = "active-updates";


            //Heading
            public const string FileTableListClassName = "config-list";
            public const string NameColumnHeadingID = "config-heading-name";
            public const string DateColumnHeadingID = "config-heading-date";
            public const string RV700NameColumnHeadingID = "name";
            public const string RV700DateColumnHeadingID = "lastup";
            public const string FirstFileCVSMInTableID = "cvsm_config0";
            public const string FirstFileCSMInTableID = "config0";
            public const string NextButtonID = "nextbtn";
            public const string DeleteButtonID = "delete";
            public const string FileNameListID = "name";
            public const string RV700FileNameListID = "name_value";



            //Pagination
            public const string PaginationPreviousIconID = "previous";
            public const string PaginationNextIconID = "next";
            public const string PaginationXofYXpath = "//span[contains(text(),'Page')]";
            public const string PaginationDisplayXYClassName = "dataTables_info";

            //DeleteButton Elements
            public const string DeleteConfigFilePopUpID = "usrmgt_confirmation_win";
            public const string DeleteConfigFileNameID = "usrmgt_confirmation_user";
            public const string DeleteAreYouSureMessageXpath = "//*[@id=\"usrmgt_confirmation_win\"]/div[1]/p[2]/span";
            public const string DeletePopUpYesButtonXpath = "//*[@id=\"confirmation_actions\"]//button[1]";
            public const string DeletePopUpNoButtonXpath = "//*[@id=\"confirmation_actions\"]//button[2]";

            //Manage Upgrade Page
            public const string ManageUpgradesLabelID = "lbl_manage_upgrade";
            public const string DestinationLabelID = "destination";
            public const string LocationHeirarchySelectorID = "caret0";
            public const string CountOfSelectedDeviceID = "count";
            public const string CancelUpgradeButtonID = "cancelUpgrade";
            //tables
            public const string ManageUpgradesTableHeadingXpath= "//*[@id=\"configure-items\"]/div[3]/div[2]";
            public const string ManageUpgradesSelectAllCheckBoxID = "selectall";
            public const string ManageUpgradesFirmwareHeadingID = "firmware";
            public const string ManageUpgradeSerialNumberHeadingID = "SerialNumber";
            public const string ManageUpgradeNewFirmwareHeadingID = "NewFirmware";
            public const string ManageUpgradeLocationHeadingID = "Location";
            public const string ManageUpgradeScheduleHeadingID = "Schedule";
            public const string ManageUpgradesFirstDeviceID = "checkbox-0";
            public const string ManageUpgradesMessageClassName = "cdk-overlay-container";


        }
        public static class ExpectedValues
        {
            //Color of selected tab
            public const string HighlightedHeadingColor = "rgba(84, 104, 229, 1)";
            public const string NonHighlightedHeadingColor = "rgba(68, 68, 68, 1)";

            //Pagination
            public static string PaginationNextIconEnabledSource = PropertyClass.BaseURL+"/icon_page_next.svg";
            public static string PaginationNextIconDiabledSource = PropertyClass.BaseURL + "/right_disabled.png";
            public static string PaginationPreviousIconEnabledSource = PropertyClass.BaseURL + "/icon_page_previous.svg";
            public static string PaginationPreviousIconDiabledSource = PropertyClass.BaseURL + "/left_disabled.png";
            public const string SecondPageNumber = "Page 2 of 2";

            public const string CSMDeviceName = "Connex Spot Monitor (CSM)";
            public const string CVSMDeviceName = "Connex Vital Signs Monitor (CVSM)";
            public const string RV700DeviceName = "RetinaVue 700 (RV700)";
            public const string AssetTypeLabelText = "Asset type";
            public const string UpdateTypeLabelText = "Update type";
            public const string UpdateTypeDropdownDefault = "Select";
            public const string UpdateTypeConfiguration = "Configuration";
            public const string UpdateTypeUpgrade = "Upgrade";
            public const string TableNameHeadingText = "Name";
            public const string TableDateHeadingText = "Date created";
            public const string DeleteConfigAreYouSureText = "Are you sure you want to delete this file?";

            //manage upgrades tabel headings
            public const string ManageUpgradesDestinationLabel = "DESTINATIONS";
            public const string FirmwareHeadingText = "Firmware";
            public const string SerialNumberHeadingText = "Serial Number";
            public const string NewFirmwareHeadingText = "New Firmware";
            public const string LocationHeadingText = "Location";
            public const string ScheduleHeadingText = "Schedule";
            public const string ManageUpgradeCancelMessage = "Selected Updates have been cancelled";

        }

        public UpdatesSelectUpdatePage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        [FindsBy(How = How.Id, Using = Locators.HeadingID)]
        public IWebElement Heading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.AssetTypeLabelID)]
        public IWebElement AssetTypeLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.AssetTypeDropDownID)]
        public IWebElement AssetTypeDropDown { get; set; }

        [FindsBy(How = How.Id, Using = Locators.UpgradeTypeLabelID)]
        public IWebElement UpgradeTypeLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.UpgradeTypeDropDownID)]
        public IWebElement UpgradeTypeDropDown { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ManageActiveUpgradesButtonID)]
        public IWebElement ManageActiveUpgradesButton { get; set; }

        //Heading
        [FindsBy(How = How.ClassName, Using = Locators.FileTableListClassName)]
        public IWebElement FileTableList { get; set; }

        [FindsBy(How = How.Id, Using = Locators.NameColumnHeadingID)]
        public IWebElement NameColumnHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DateColumnHeadingID)]
        public IWebElement DateColumnHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.RV700NameColumnHeadingID)]
        public IWebElement RV700NameColumnHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.RV700DateColumnHeadingID)]
        public IWebElement RV700DateColumnHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.FirstFileCVSMInTableID)]
        public IWebElement FirstFileCVSMInTable { get; set; }

        [FindsBy(How = How.Id, Using = Locators.FirstFileCSMInTableID)]
        public IWebElement FirstFileCSMInTable { get; set; }

        [FindsBy(How = How.Id, Using = Locators.NextButtonID)]
        public IWebElement NextButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeleteButtonID)]
        public IWebElement DeleteButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.FileNameListID)]
        public IList<IWebElement> FileNameList { get; set; }

        [FindsBy(How = How.Id, Using = Locators.RV700FileNameListID)]
        public IList<IWebElement> RV700FileNameList { get; set; }

        //Pagination
        [FindsBy(How = How.Id, Using = Locators.PaginationPreviousIconID)]
        public IWebElement PaginationPreviousIcon { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PaginationNextIconID)]
        public IWebElement PaginationNextIcon { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.PaginationXofYXpath)]
        public IWebElement PaginationXofY { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.PaginationDisplayXYClassName)]
        public IWebElement PaginationDisplayXY { get; set; }


        //deleteconfig file elements
        [FindsBy(How = How.Id, Using = Locators.DeleteConfigFilePopUpID)]
        public IWebElement DeleteConfigFilePopUp { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeleteConfigFileNameID)]
        public IWebElement DeleteConfigFileName { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.DeleteAreYouSureMessageXpath)]
        public IWebElement DeleteAreYouSureMessage { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.DeletePopUpYesButtonXpath)]
        public IWebElement DeletePopUpYesButton { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.DeletePopUpNoButtonXpath)]
        public IWebElement DeletePopUpNoButton { get; set; }

        //manageactive upgrades
        [FindsBy(How = How.Id, Using = Locators.ManageUpgradesLabelID)]
        public IWebElement ManageUpgradeLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DestinationLabelID)]
        public IWebElement DestinationLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LocationHeirarchySelectorID)]
        public IWebElement LocationHeiearchySelector { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CountOfSelectedDeviceID)]
        public IWebElement CountOfSelectedDevice { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CancelUpgradeButtonID)]
        public IWebElement CancelUpgradeButton { get; set; }

        //Manage upgrades table

        [FindsBy(How = How.XPath, Using = Locators.ManageUpgradesTableHeadingXpath)]
        public IWebElement ManageUpgradesTableHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ManageUpgradesSelectAllCheckBoxID)]
        public IWebElement ManageUpgradesSelectAllCheckBox { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ManageUpgradesFirmwareHeadingID)]
        public IWebElement ManageUpgradesFirmwareHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ManageUpgradeSerialNumberHeadingID)]
        public IWebElement ManageUpgradeSerialNumberHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ManageUpgradeNewFirmwareHeadingID)]
        public IWebElement ManageUpgradeNewFirmwareHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ManageUpgradeLocationHeadingID)]
        public IWebElement ManageUpgradeLocationHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ManageUpgradeScheduleHeadingID)]
        public IWebElement ManageUpgradeScheduleHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ManageUpgradesFirstDeviceID)]
        public IWebElement ManageUpgradesFirstDevice { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.ManageUpgradesMessageClassName)]
        public IWebElement ManageUpgradesMessage { get; set; }


        /// <summary>
        /// Fuction to check the deleted file is present or not in the list.
        /// </summary>
        /// <param name="rowname">Name of the file deleted</param>
        /// <returns></returns>
        public bool IsFilePresent(string rowname)
        {
            foreach (IWebElement file in FileNameList)
            {
                string fileName = file.Text;
                bool result = rowname.ToLower().Trim().Contains(fileName.ToLower().Trim());
                if (result)
                {
                    return (true);
                }
            }
            return (false);
        }

        /// <summary>
        /// Function to check the sorting of files
        /// </summary>
        /// <param name="elements">List of Iwebelements</param>
        /// <returns></returns>
        public bool IsFileSorted(IList<IWebElement> elements)
        {
            List<string> fileListName = new List<string>();
            foreach (IWebElement configname in elements)
            {
                fileListName.Add(configname.Text.ToString());
            }
            List<string> UnSortedList = new List<string>(fileListName);
            fileListName.Sort((s1, s2) => s1.CompareTo(s2));
            return (Enumerable.SequenceEqual(fileListName, UnSortedList));
        }

    }
}
