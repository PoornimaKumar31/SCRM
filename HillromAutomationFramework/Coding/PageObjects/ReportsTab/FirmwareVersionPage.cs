using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HillromAutomationFramework.Coding.PageObjects.ReportsTab
{
    class FirmwareVersionPage
    {
        public static class Locators
        {
            public const string FirmwareReportTitleID = "reportTitleHeader";
            public const string ComponentsHeadingID = "component";
            public const string FirmwareVersionHeadingID = "firm_version";
            public const string TotaldevicesHeadingID = "device_count";
            public const string TotalRowID = "location_header0";
            public const string TotalRowDetailsID = "unitMetrics0";
            public const string Unit1RowID = "location_header1";
            public const string Unit1RowDetailsID = "unitMetrics1";
            public const string PrintButtonID = "fv-print";
            public const string FirmwareVesrionReportHeaderLabelID = "reportTitleHeader";

        }
        public static class ExpectedValues
        {
            public const string ReportCSMLabelText = "FIRMWARE VERSION REPORT (CSM)";
            public const string ReportRV700LabelText = "FIRMWARE VERSION REPORT (RV700)";
            public const string ComponentsHeadingText = "Components";
            public const string FirmwareVersionHeadingText = "Firmware version";
            public const string TotalDevicesHeadingText = "Total devices";
        }

        public FirmwareVersionPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        [FindsBy(How = How.Id, Using = Locators.FirmwareReportTitleID)]
        public IWebElement FirmwareReportTitle { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ComponentsHeadingID)]
        public IWebElement ComponentsHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.FirmwareVersionHeadingID)]
        public IWebElement FirmwareVersionHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.TotaldevicesHeadingID)]
        public IWebElement TotaldevicesHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.TotalRowID)]
        public IWebElement TotalRow { get; set; }

        [FindsBy(How = How.Id, Using = Locators.TotalRowDetailsID)]
        public IWebElement TotalRowDetails { get; set; }

        [FindsBy(How = How.Id, Using = Locators.Unit1RowID)]
        public IWebElement Unit1Row { get; set; }

        [FindsBy(How = How.Id, Using = Locators.Unit1RowDetailsID)]
        public IWebElement Unit1RowDetails { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PrintButtonID)]
        public IWebElement PrintButton { get; set; }
    }
}
