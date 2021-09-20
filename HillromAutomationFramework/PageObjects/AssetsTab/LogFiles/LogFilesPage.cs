using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace HillromAutomationFramework.PageObjects
{
    class LogFilesPage
    {
        public static class Locator
        {
            public const string LogsTabXpath = "//div[text()='Logs']";
            public const string ComponentInformationTabXpath = "//div[text()='Component information']";
            public const string RequestLogsButtonID = "request-logs";
            public const string LogFilesLabelID = "lbl_request_log";

            public const string LogFilesID = "logName";
            public const string LogDateClassName = "col-md-4";
            public const string NameComumnID = "logs_name";
            public const string DateColumnID = "date";
            public const string SortingIndicatorID = "date";
            public const string PreviousIconID = "previous";
            public const string NextIconID = "next";
            public const string PageNumberID = "pageNumber";

            public const string LogsPendingMessageXPath = "//div[@class = 'col-xs-8']";
            public const string LogsDescendingClassName = "col-md-4 descending";
            public const string LogsAscendingClassName = "col-md-4 ascending";

        }
        public LogFilesPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = Locator.LogsTabXpath)]
        public IWebElement LogsTab { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.ComponentInformationTabXpath)]
        public IWebElement ComponentInformationTab { get; set; }

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
        public IWebElement PreviousPageIcon { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NextIconID)]
        public IWebElement NextPageIcon { get; set; }

        [FindsBy(How = How.Id, Using = Locator.LogFilesID)]
        public IList<IWebElement> LogFiles { get; set; }

        [FindsBy(How = How.ClassName, Using = Locator.LogDateClassName)]
        public IList<IWebElement> LogDateList { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.LogsPendingMessageXPath)]
        public IWebElement LogsPendingMessage { get; set; }


        /// <summary>
        /// Function to verify N newest Logs presence by comparing Last Log Date of Current page 
        /// with First Log Date of Next Page
        /// </summary>
        /// <param name="n">Expected Number of Logs</param>
        /// <returns>Boolean</returns>
        public bool NNewestLogsPresence(int n)
        {
            DateTime FirstElementLastPage;
            DateTime LastElementFirstPage;

            Thread.Sleep(3000);
            IList<IWebElement> LogDateListInitialPage = LogDateList;
            LastElementFirstPage = DateTime.Parse(LogDateListInitialPage[n].Text);
            int count = LogDateListInitialPage.Count - 1;
            Thread.Sleep(3000);
            NextPageIcon.Click();
            Thread.Sleep(3000);
            IList<IWebElement> LogDateListNextPage = LogDateList;
            FirstElementLastPage = DateTime.Parse(LogDateListNextPage[1].Text);
            PreviousPageIcon.Click();
            Thread.Sleep(3000);
            if (count.Equals(n))
            {
                if (LastElementFirstPage >= FirstElementLastPage)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// Function to verify N older Logs presence by comparing First Log Date of Current page 
        /// with Last Log Date of Next Page
        /// </summary>
        /// <param name="n">Expected Number of Logs</param>
        /// <returns>Boolean</returns>
        public bool NOlderLogsPresence(int n)
        {
            DateTime FirstElementCurrentPage;
            DateTime LastElementPreviousPage;

            Thread.Sleep(3000);
            IList<IWebElement> LogDateListCurrentPage = LogDateList;
            FirstElementCurrentPage = DateTime.Parse(LogDateListCurrentPage[1].Text);
            int count = LogDateListCurrentPage.Count - 1;
            Thread.Sleep(3000);
            PreviousPageIcon.Click();
            Thread.Sleep(3000);
            IList<IWebElement> LogDateListPreviousPage = LogDateList;
            LastElementPreviousPage = DateTime.Parse(LogDateListPreviousPage[n].Text);
            NextPageIcon.Click();
            Thread.Sleep(3000);
            if (count.Equals(n))
            {
                if (FirstElementCurrentPage <= LastElementPreviousPage)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

    }
}
