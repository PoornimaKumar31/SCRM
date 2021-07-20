using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HillromAutomationFramework.Coding.PageObjects
{
    class CSMUpdatesPage
    {
        public CSMUpdatesPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        public static class Locator
        {
            public const string AssetTypeDDLID = "modelFilter";
            public const string UpdateTypeDDLID = "typeFilter";
            public const string UpgradeListClassName = "config-list";
            public const string ManageActiveUpdateID = "active-updates";
            public const string NameColumnHeadingID = "config-heading-name";
            public const string DateColumnHeadingID = "config-heading-date";
            public const string NextButtonID = "nextbtn";
            public const string PaginationLabelID = "pagination";
            public const string ResultsLabelClassName = "dataTables_info";
            public const string PreviousPageArrowID = "previous";
            public const string NextPageArrowID = "next";
            public const string UpgradeFileID = "cvsm_config0";          
            public const string ItemToPushID = "lbl_item_to_push";
            public const string DevicceTypeLabelID = "";
            public const string UpdateTypeLabelID = "";
            public const string UpgradeFileToPushID = "";
            

            public const string DateOrTimePushLabelID = "lbl_date_time";
            public const string ImmediateLabelID = "immediately";
            public const string ImmediateCheckboxID = "setInfo";
            public const string ScheduleCheckboxID = "UpgradeInfo";
            public const string ScheduleLabelID = "schedule";

            public const string DateLabelID = "lbl_date";
            public const string CalendarIconClassName = "mat-datepicker-toggle";

            public const string TimeLabelID = "lbl_time";
            public const string HourDDLID = "upgrade_hour";
            public const string MinuteDDLID = "upgrade_minute";
            public const string ConfirmButtonID = "confirm";
            public const string PreviousButtonID = "previousbtn";
            public const string DateClassName = "mat-calendar-body-cell-content";

            //Manage Upgrade Page
            public const string ManageUpgradesLabelID = "lbl_manage_upgrade";
            public const string DestinationLabelID = "destination";
            public const string LocationHeirarchySelectorID = "";
            public const string CountOfSelectedDeviceID = "count";
            public const string CancelUpgradeButtonID = "cancelUpgrade";
            public const string NewFirmwareID = "NewFirmware";
            public const string ScheduleID = "Schedule";
            public const string SerialNumberID = "SerialNumber";


        }

        public static class ExpectedValue
        {
            public const string UpdateTypeUpgrade = "Upgrade";

            public const string NewFirmwareExpectedValue = "New Firmware";

            public const string ScheduleExpectedValue = "Schedule";

            public const string SerialNumberExpectedValue = "Serial Number";
        }

        [FindsBy(How = How.Id, Using = Locator.AssetTypeDDLID)]
        public IWebElement AssetTypeDDL { get; set; }

        [FindsBy(How = How.Id, Using = Locator.UpdateTypeDDLID)]
        public IWebElement UpdateTypeDDL { get; set; }

        [FindsBy(How=How.ClassName,Using =Locator.UpgradeListClassName)]
        public IWebElement UpgradeList { get; set; }

        [FindsBy(How = How.Id, Using = Locator.ManageActiveUpdateID)]
        public IWebElement ManageActiveUpdate { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NameColumnHeadingID)]
        public IWebElement NameColumnHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DateColumnHeadingID)]
        public IWebElement DateColumnHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NextButtonID)]
        public IWebElement NextButton { get; set; }

        [FindsBy(How = How.Id, Using = Locator.PaginationLabelID)]
        public IWebElement PaginationLabel { get; set; }

        [FindsBy(How = How.ClassName, Using = Locator.ResultsLabelClassName)]
        public IWebElement ResultLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.PreviousPageArrowID)]
        public IWebElement PreviousPageArrow { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NextPageArrowID)]
        public IWebElement NextPageArrow { get; set; }

        [FindsBy(How = How.Id,Using = Locator.UpgradeFileID)]
        public IWebElement UpgradeFile { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DateOrTimePushLabelID)]
        public IWebElement DateOrTimePushLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.ImmediateLabelID)]
        public IWebElement ImmediateLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.ImmediateCheckboxID)]
        public IWebElement ImmediateCheckbox { get; set; }

        [FindsBy(How=How.Id,Using =Locator.ScheduleCheckboxID)]
        public IWebElement ScheduleCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = Locator.ScheduleLabelID)]
        public IWebElement ScheduleLabel { get; set; }

        [FindsBy(How =How.Id,Using = Locator.DateLabelID)]
        public IWebElement DateLabel { get; set; }

        [FindsBy(How = How.ClassName, Using = Locator.CalendarIconClassName)]
        public IWebElement CalendarIcon { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TimeLabelID)]
        public IWebElement TimeLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.HourDDLID)]
        public IWebElement HourDDL { get; set; }

        [FindsBy(How = How.Id, Using = Locator.MinuteDDLID)]
        public IWebElement MinuteDDL { get; set; }


        [FindsBy(How =How.Id,Using =Locator.ConfirmButtonID)]
        public IWebElement ConfirmButton { get; set; }

        [FindsBy(How = How.Id, Using = Locator.PreviousButtonID)]
        public IWebElement PreviousButton { get; set; }

        [FindsBy(How =How.ClassName,Using =Locator.DateClassName)]
        public IWebElement Date { get; set; }

        [FindsBy(How = How.Id, Using = Locator.ManageUpgradesLabelID)]
        public IWebElement ManageUpgradeLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DestinationLabelID)]
        public IWebElement DestinationLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.LocationHeirarchySelectorID)]
        public IWebElement LocationHeiearchySelector { get; set; }

        [FindsBy(How = How.Id, Using = Locator.CountOfSelectedDeviceID)]
        public IWebElement CountOfSelectedDevice { get; set; }

        [FindsBy(How = How.Id, Using = Locator.CancelUpgradeButtonID)]
        public IWebElement CancelUpgradeButton { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NewFirmwareID)]
        public IWebElement NewFirmware { get; set; }

        [FindsBy(How = How.Id, Using = Locator.ScheduleID)]
        public IWebElement Schedule { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SerialNumberID)]
        public IWebElement SerialNumber { get; set; }
    }


}
