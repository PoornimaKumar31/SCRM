using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

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
            public const string RoomAndBedDetailsXpath = "//*[@id=\"device-main\"]/div[1]/div[3]/p[6]";

            //Log files
            public const string LogsButtonXpath = "//*[@id=\"device-main\"]/div[2]/div/div/div[3]";
            public const string LogFilesID = "device-details";
        }

        public static class ExpectedValues
        {
            public const string NewRoomValue = "New Room";
            public const string NewBedValue = "New Bed";
            public const string UpdateRoomValue = "Update Room";
            public const string UpdateBedValue = "Update Bed";
            public const string RoomAndBedNotSet = "(not set)";
        }

        [FindsBy(How = How.Id, Using = "555566667777")]
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

        [FindsBy(How = How.XPath, Using = Locators.RoomAndBedDetailsXpath)]
        public IWebElement RoomAndBedDetails { get; set; }

        //Log files related
        [FindsBy(How = How.XPath, Using = Locators.LogsButtonXpath)]
        public IWebElement LogsButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LogFilesID)]
        public IWebElement LogFiles { get; set; }

        
    }
}
