using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace HillromAutomationFramework.PageObjects
{
    class RV700DeviceDetailsPage
    {
        public static class Locators
        {
            //Editing device details
            public const string EditButtonID = "rv700-edit";
            public const string RoomFieldID = "room";
            public const string BedFieldID = "bed";
            public const string SaveButtonID = "save_device_detail";
            public const string CancelButtonID = "cancel_device_detail";
            public const string RoomAndBedDetailsID = "rv700_room";
            public const string RV700DeviceID = "555566667777";
        }

        public RV700DeviceDetailsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = Locators.RV700DeviceID)]
        public IList<IWebElement> RV700Devices { get; set; }

        //Device details related
        [FindsBy(How = How.Id, Using = Locators.EditButtonID)]
        public IWebElement EditButton { get; set; }

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

        
    }
}
