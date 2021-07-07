using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace HillromAutomationFramework.Coding.PageObjects
{
    class CSMDeviceDetailsPage
    {
        public CSMDeviceDetailsPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        public static class Locators
        {
            //Editing device details
            public const string CSMDeviceEditButtonID = "csm-edit";
            public const string RoomFieldID = "room";
            public const string BedFieldID = "bed";
            public const string SaveButtonID = "save-device-detail";
            public const string CancelButtonID = "cancel-device-detail";
            public const string RoomAndBedDetailsID = "csm_room";
            public const string CSMDeviceID = "555566667777";

            //Log files
            public const string LogsTabID = "mat-tab-label-0-2";
            public const string LogFilesID = "logName";
            public const string LogsNextButtonID = "next";
            public const string LogsPreviousButtonID = "previous";
            public const string LogsPageNumberClassName = "pageNumber";
            public const string LogsPageRequestButtonID = "request-logs";
            public const string LogsPendingMessageXPath = "//*[@id=\"mat-tab-content-0-2\"]/div/div/c8y-hillrom-request-logs/div/div[3]/div[1]/div[1]";
            public const string LogsDescendingClassName = "col-md-4 descending";
            public const string LogsAscendingClassName = "col-md-4 ascending";
            public const string DateSortingID = "date";
        }

        public static class ExpectedValues
        {
            public const string NewRoomValue = "New Room";
            public const string NewBedValue = "New Bed";
            public const string UpdateRoomValue = "Update Room";
            public const string UpdateBedValue = "Update Bed";
            public const string RoomAndBedNotSet = "(not set)";
        }

        [FindsBy(How = How.Id, Using = Locators.CSMDeviceID)]
        public IList<IWebElement> CSMDevices { get; set; }

        //Device details related
        [FindsBy(How = How.Id, Using = Locators.CSMDeviceEditButtonID)]
        public IWebElement CSMDeviceEditButton { get; set; }

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

        //Log files related
        [FindsBy(How = How.Id, Using = Locators.LogsTabID)]
        public IWebElement LogsTab { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LogFilesID)]
        public IList<IWebElement> LogFiles { get; set; }

        [FindsBy(How =How.Id, Using = Locators.LogsNextButtonID)]
        public IWebElement LogsNextButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LogsPreviousButtonID)]
        public IWebElement LogsPreviousButton { get; set; }

        [FindsBy(How =How.ClassName,Using =Locators.LogsPageNumberClassName)]
        public IWebElement LogsCurrentPageNumber { get; set; }

        [FindsBy(How =How.Id,Using =Locators.LogsPageRequestButtonID)]
        public IWebElement LogsRequestButton { get; set; }

        [FindsBy(How =How.XPath,Using =Locators.LogsPendingMessageXPath)]
        public IWebElement LogsPendingMessage { get; set; }

        [FindsBy(How =How.Id, Using =Locators.DateSortingID)]
        public IWebElement DateSorting { get; set; }
    }
}
