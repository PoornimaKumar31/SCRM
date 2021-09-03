﻿using HillromAutomationFramework.SupportingCode;
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
            public const string LocationHeadingID = "loc";
            public const string LastVitalSentHeadingID = "lastVital";
            public const string TableHeadingClassName = "device-info-list";
            //Table elements
            public const string PaginationPreviousPageIconId = "previous";
            public const string PaginationNextPageIconId = "next";
            public const string PaginationPageXofYXpath = "//div[@id='next']/parent::div/div[2]";
            public const string PaginationDisplayXYClassName = "dataTables_info";

            public const string SerialNumberColumnXpath = "//div[@class='measurements']//div//div[1]";
            public const string LocationColumnXpath = "//div[@class='measurements']//div//div[2]";
            public const string LastVitalSentColumnXpath = "//div[@class='measurements']//div//div[3]";
        }
      
        public static class ExpectedValues
        {
            //Search text
            public const string SerialNumberSearchText = "100010000000";
            public const string LocationSearchText = "Station1";

            //CSM
            public const string CSMActivityReportName = "Activity_Status_Report_(CSM).csv";
            public const string ActivityReportCSMHeader = "ACTIVITY REPORT (CSM)";
            public const string SerialNumberHeadingText = "Serial number";
            public const string LocationHeadingText = "Location";
            public const string LastVitalSentHeadingText = "Last vital sent";

            //Centrella
            public const string CentrellaActivityReportName = "Activity_Status_Report_(Centrella).csv";
            public const string ActivityReportCentreallaHeader = "ACTIVITY REPORT (CENTRELLA)";

        }

        public ActivityReportPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
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

        [FindsBy(How = How.Id, Using = Locators.LastVitalSentHeadingID)]
        public IWebElement LastVitalSentHeading { get; set; }

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