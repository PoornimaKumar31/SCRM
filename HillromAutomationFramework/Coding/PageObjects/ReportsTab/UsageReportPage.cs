using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HillromAutomationFramework.Coding.PageObjects.ReportsTab
{
    class UsageReportPage
    {
        public UsageReportPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }
        public static class Locator
        {
            public const string ReportTitleHeaderID = "reportTitleHeader";
        }
        [FindsBy(How =How.Id,Using =Locator.ReportTitleHeaderID)]
        public IWebElement ReportsTitleHeader { get; set; }
    }
}
