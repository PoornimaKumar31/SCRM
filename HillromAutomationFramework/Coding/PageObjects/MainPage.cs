using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HillromAutomationFramework.Coding.PageObjects
{
    public class MainPage
    {
        public static class Locators
        {
            //Links
            public const string GlobalSeviceCenterID = "gsc";
            public const string ContactUsID = "contactus";

            //Tabs
            public const string AssetsTabID = "assetsTab";
            public const string ReportsTabID = "reportsTab";
            public const string UpdatesTabID = "updatesTab";
            public const string AdvancedTabID = "advancedTab";

            //dropdownID
            public const string AssetTypeDropDownID = "assetFilter";


            public const string DeviceListRowID = "555566667777";
            public const string DeviceTypeClassName = "ng-star-inserted";
            public const string FirmwareVersionClassName = "firmware";
            public const string ConfigFileClassName = "configFile";
            public const string AssetTagClassName = "asset";
            public const string SerialNumberClassName = "serial";
            public const string LocationClassName = "location";
            public const string LastConnectionClassName = "connection";
        }
        public static class ExpectedValues
        {
            public const string GlobalServiceCenterURL = "https://www.hillrom.com/en/services/";
            public const string ContactUsURL = "https://www.hillrom.com/en/about-us/contact-us/";

            public const string CSMDeviceName = "Connex Spot Monitor (CSM)";
        }

        public MainPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        [FindsBy(How =How.Id,Using =Locators.GlobalSeviceCenterID)]
        public IWebElement GlobalServiceCenter { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ContactUsID)]
        public IWebElement ContactUs { get; set; }

        [FindsBy(How = How.Id, Using = Locators.AssetsTabID)]
        public IWebElement AssetsTab { get; set; }

        [FindsBy(How =How.Id, Using =Locators.AssetTypeDropDownID)]
        public IWebElement AssetTypeDropDown { get; set; }
    }
}
