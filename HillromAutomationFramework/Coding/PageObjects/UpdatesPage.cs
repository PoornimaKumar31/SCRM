using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HillromAutomationFramework.Coding.PageObjects
{
    class UpdatesPage 
    {
        public static class Locators
        {
            

            //SelectDeviceTab
            public const string SelectDevicesHeadingID = "select_asset";


            //Review action
            public const string ReviewActionHeadingID = "select_review";
        }
        public static class ExpectedValues
        {
            public const string HighlightedHeadingColor = "rgba(84, 104, 229, 1)";
            public const string NonHighlightedHeadingColor = "rgba(68, 68, 68, 1)";
        }

        public UpdatesPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        

    }
}
