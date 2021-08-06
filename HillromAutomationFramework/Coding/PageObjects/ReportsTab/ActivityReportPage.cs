using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HillromAutomationFramework.Coding.PageObjects.ReportsTab
{
    class ActivityReportPage
    {
        public static class Locators
        {
            public const string ActivityReportHeaderID = "reportTitleHeader";
            //ACTIVITY REPORT (CSM) table elements
            public const string SerialNumberHeadingID = "serialNo";
            public const string LocationHeadingID = "loc";
            public const string LastVitalSentHeadingID = "lastVital";
            public const string TableHeadingClassName = "device-info-list";
        }
        public static class ExpectedValues
        {
            public const string ActivityReportCSMHeader = "ACTIVITY REPORT (CSM)";
            public const string SerialNumberHeadingText = "Serial number";
            public const string LocationHeadingText = "Location";
            public const string LastVitalSentHeadingText = "Last vital sent";
            
        }

        public ActivityReportPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        [FindsBy(How =How.Id,Using =Locators.ActivityReportHeaderID)]
        public IWebElement ActivityReportHeader { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SerialNumberHeadingID)]
        public IWebElement SerialNumberHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LocationHeadingID)]
        public IWebElement LocationHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LastVitalSentHeadingID)]
        public IWebElement LastVitalSentHeading { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.TableHeadingClassName)]
        public IWebElement TableHeading { get; set; }
    }
}
