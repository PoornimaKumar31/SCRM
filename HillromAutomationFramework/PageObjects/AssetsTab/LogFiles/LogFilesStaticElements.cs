using HillromAutomationFramework.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HillromAutomationFramework.PageObjects
{
    class LogFilesStaticElements
    {
        public static class Locator
        {
           
            public const string RequestLogsButtonID = "request-logs";
            public const string LogFilesLabelID = "lbl_request_log";
    
            public const string NameComumnID = "logs_name";
            public const string DateColumnID = "date";
            public const string SortingIndicatorID = "date";
            public const string PreviousIconID = "previous";
            public const string NextIconID = "next";
            public const string PageNumberID = "pageNumber";

        }

        /// Expected values in the login page.
        public static class ExpectedValues
        {
            public const string LogFilesLabel = "LOG FILES";
            public const string RequestLogButton = "Request Log";
        }
        public LogFilesStaticElements()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        //Log Files
        [FindsBy(How =How.Id,Using =Locator.SortingIndicatorID)]
        public IWebElement DateSortingIndicator { get; set; }

        [FindsBy(How = How.Id, Using = Locator.PageNumberID)]
        public IWebElement PageNumber { get; set; }

        [FindsBy(How = How.Id, Using = Locator.LogFilesLabelID)]
        public IWebElement LogFilesLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RequestLogsButtonID)]
        public IWebElement RequestLogsButton { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NameComumnID)]
        public IWebElement NameColumn { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DateColumnID)]
        public IWebElement DateColumn { get; set; }

        [FindsBy(How = How.Id, Using = Locator.PreviousIconID)]
        public IWebElement PreviousIcon { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NextIconID)]
        public IWebElement NextIcon { get; set; }
    }
}
