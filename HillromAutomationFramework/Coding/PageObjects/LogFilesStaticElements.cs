using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HillromAutomationFramework.Coding.PageObjects
{
    class LogFilesStaticElements
    {
        public static class Locator
        {
            public const string OrganizationNameID = "facName00";
            public const string CVSMDeviceXpath = "/html/body/c8y-bootstrap/div/div[2]/div/c8y-hillrom-home-page/c8y-hillrom-landing-page/div/div/div[2]/c8y-hillrom-devices/div[2]/div/div/div/c8y-hillrom-devices-list/div[1]/div/table/tbody/tr[7]";
            public const string CVSMLogsTabXpath = "//*[contains(text(),'Logs')]";
            public const string RequestLogsButtonID = "request-logs";
            public const string LogFilesLabelXPath = "//b[contains(text(), 'LOG FILES')]";
            public const string fileLabel = "//*[@id=\"mat-tab-content-0-2\"]/div/div/c8y-hillrom-request-logs/div/div[1]/div[1]/b";

            public const string NameComumnClassName = "col-md-8";
            public const string DateColumnID = "date";
            public const string PreviousIconID = "previous";
            public const string NextIconID = "next";
            public const string CurrentLogsPageIndicatorClassName = "pageNumber";
            public const string NumberOfLogsPages = "";

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

        [FindsBy(How = How.XPath, Using = Locator.CVSMLogsTabXpath)]
        public IWebElement CVSMLogsTabXPathWebElement { get; set; }


        //Log Files

        [FindsBy(How = How.Id, Using = Locator.OrganizationNameID)]
        public IWebElement OrganizationNameIDWebElement { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.LogFilesLabelXPath)]
        public IWebElement LogFilesWebElement { get; set; }

        [FindsBy(How = How.Id, Using = Locator.RequestLogsButtonID)]
        public IWebElement RequestLogsButtonWebElement { get; set; }

        [FindsBy(How = How.ClassName, Using = Locator.NameComumnClassName)]
        public IWebElement NameColumnWebElement { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DateColumnID)]
        public IWebElement DateColumnWebElement { get; set; }

        [FindsBy(How = How.Id, Using = Locator.PreviousIconID)]
        public IWebElement PreviousIconWebElement { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NextIconID)]
        public IWebElement NextIconWebElement { get; set; }

        [FindsBy(How = How.ClassName, Using = Locator.CurrentLogsPageIndicatorClassName)]
        public IWebElement CurrentLogsPageWebElement { get; set; }
    }
}
