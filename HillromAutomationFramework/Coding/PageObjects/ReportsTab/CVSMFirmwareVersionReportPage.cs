using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HillromAutomationFramework.Coding.PageObjects.ReportsTab
{
    class CVSMFirmwareVersionReportPage
    {
        public CVSMFirmwareVersionReportPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        public static class Locator
        {
            public const string FirmwareVersionReportTitleLabelID = "reportTitleHeader";
            public const string ComponentColumnHeaderID = "component";
            public const string FirmwareVersionColumnHeaderID = "firm_version";
            public const string TotalDevicesColumnHeaderID = "device_count";
            public const string TotalRowID = "location_header0";

        }

        [FindsBy(How = How.Id, Using = Locator.FirmwareVersionReportTitleLabelID)]
        public IWebElement FirmwareVersionReportTitleLabel { get; set; }


        [FindsBy(How = How.Id, Using = Locator.ComponentColumnHeaderID)]
        public IWebElement ComponentColumnHeader { get; set; }

        [FindsBy(How = How.Id, Using = Locator.FirmwareVersionColumnHeaderID)]
        public IWebElement FirmwareVersionColumnHeader { get; set; }


        [FindsBy(How = How.Id, Using = Locator.TotalDevicesColumnHeaderID)]
        public IWebElement TotalDevicesColumnHeader { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TotalRowID)]
        public IWebElement TotalRow { get; set; }

    }
}
