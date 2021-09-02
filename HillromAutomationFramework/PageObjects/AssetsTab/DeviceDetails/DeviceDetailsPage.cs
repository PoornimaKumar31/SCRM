using HillromAutomationFramework.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HillromAutomationFramework.PageObjects
{
    public class DeviceDetailsPage
    {
        public static class Locators
        {
            //Asset details
            public const string AssetLabelClassName = "deviceLabel";
            public const string AssetDataClassName = "deviceData";
            //Editing device details
            public const string CVSMDeviceEditButtonID = "cvsm-edit";
        }
      

        public DeviceDetailsPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        [FindsBy(How =How.ClassName,Using =Locators.AssetLabelClassName)]
        public IWebElement AssetLabel { get; set; }

        [FindsBy(How =How.ClassName,Using =Locators.AssetDataClassName)]
        public IWebElement AssetData { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CVSMDeviceEditButtonID)]
        public IWebElement CVSMDeviceEditButton { get; set; }
    }
}
