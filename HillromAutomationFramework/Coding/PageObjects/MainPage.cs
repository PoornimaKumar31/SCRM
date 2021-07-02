using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HillromAutomationFramework.Coding.PageObjects
{
    public class MainPage
    {
        public static class Locators
        {
            public const string GlobalSeviceCenterID = "gsc";
            public const string ContactUsID = "contactus";
            public const string AssetsTabID = "assetsTab";
        }
        public static class ExpectedValues
        {
            public const string GlobalServiceCenterURL = "https://www.hillrom.com/en/services/";
            public const string ContactUsURL = "https://www.hillrom.com/en/about-us/contact-us/";
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

    }
}
