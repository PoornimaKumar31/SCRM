using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HillromAutomationFramework.Coding.PageObjects
{
    public class DeviceDetailsPage
    {
        public static class Locators
        {
            public const string CSMDeviceEditButtonID = "csm-edit";
            public const string CVSMDeviceEditButtonID = "cvsm-edit";
            public const string DeviceEditRoomID = "room";
            public const string DeviceEditBedID = "bed";
            public const string DeviceEditSaveButtonID = "save-device-detail";
            public const string DeviceEditCancelButtonID = "cancel-device-detail";

        }
        public class ExpectedValues
        {

        }

        public DeviceDetailsPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        [FindsBy(How = How.Id, Using = Locators.CSMDeviceEditButtonID)]
        public IWebElement CSMDeviceEditButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CVSMDeviceEditButtonID)]
        public IWebElement CVSMDeviceEditButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeviceEditRoomID)]
        public IWebElement DeviceEditRoom { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeviceEditBedID)]
        public IWebElement DeviceEditBed { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeviceEditSaveButtonID)]
        public IWebElement DeviceEditSaveButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeviceEditCancelButtonID)]
        public IWebElement DeviceEditCancelButton { get; set; }

    }
}
