using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace HillromAutomationFramework.PageObjects.ReportsTab
{
    class ActivityReportPage
    {
        public static class Locators
        {
            public const string ActivityReportHeaderID = "reportTitleHeader";
            public const string SearchBoxID = "search";
            public const string PrintButtonID = "ac-print";
            public const string DownloadButtonID = "ac-download";
            //ACTIVITY REPORT (CSM) table elements
            public const string SerialNumberHeadingID = "serialNo";
            public const string LocationHeadingID = "apLoc";
            public const string LastVitalSentHeadingID = "lastVital";
            public const string PMDueHeadingID = "pmDue";
            public const string TableHeadingClassName = "device-info-list";

            //ACTIVITY REPORT (CENTRELLA and PROGRESSA) table elements
            public const string PatientPresentID = "patientPresence";
            //Table elements
            public const string PaginationPreviousPageIconId = "previous";
            public const string PaginationNextPageIconId = "next";
            public const string PaginationPageXofYXpath = "//div[@id='next']/parent::div/div[2]";
            public const string PaginationDisplayXYClassName = "dataTables_info";

            public const string SerialNumberColumnXpath = "//div[@class='measurements']//div//div[1]";
            public const string LocationColumnXpath = "//div[@class='measurements']//div//div[2]";
            public const string LastVitalSentColumnXpath = "//div[@class='measurements']//div//div[3]";
        }

        public ActivityReportPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How =How.Id,Using =Locators.ActivityReportHeaderID)]
        public IWebElement ActivityReportHeader { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SearchBoxID)]
        public IWebElement SearchBox { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PrintButtonID)]
        public IWebElement PrintButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DownloadButtonID)]
        public IWebElement DownloadButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SerialNumberHeadingID)]
        public IWebElement SerialNumberHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LocationHeadingID)]
        public IWebElement LocationHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PatientPresentID)]
        public IWebElement PatientPresentHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LastVitalSentHeadingID)]
        public IWebElement LastVitalSentHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PMDueHeadingID)]
        public IWebElement PMDueHeading { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.TableHeadingClassName)]
        public IWebElement TableHeading { get; set; }

        //Table elements
        [FindsBy(How = How.Id, Using = Locators.PaginationNextPageIconId)]
        public IWebElement PaginationNextPageIcon { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PaginationPreviousPageIconId)]
        public IWebElement PaginationPreviousPageIcon { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.PaginationPageXofYXpath)]
        public IWebElement PaginationPageXofY { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.PaginationDisplayXYClassName)]
        public IWebElement PaginationDisplayXY { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.SerialNumberColumnXpath)]
        public IList<IWebElement> SerialNumberColumn { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.LocationColumnXpath)]
        public IList<IWebElement> LocationColumn { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.LastVitalSentColumnXpath)]
        public IList<IWebElement> LastVitalSentColumn { get; set; }
    }
}
