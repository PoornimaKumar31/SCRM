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
            public const string TotalUnitAllDeviceID = "unitMetrics0";
            public const string AndyDeskUnitID = "location_header2";
            public const string AndyDeskUnitAllDevicesID = "unitMetrics2";
            public const string ConnexCS1UnitID = "location_header3";
            public const string ConnexCS1UnitAllDevicesID = "unitMetrics3";
            public const string LuWenUnitID = "location_header4";
            public const string LuWenUnitAllDevicesID = "unitMetrics4";
            public const string Station1UnitID = "location_header7";
            public const string Station1UnitAllDevicesID = "unitMetrics7";


        }

        [FindsBy(How = How.Id, Using = Locator.AndyDeskUnitAllDevicesID)]
        public IWebElement AndyDeskUnitAllDevices { get; set; }

        [FindsBy(How = How.Id, Using = Locator.ConnexCS1UnitAllDevicesID)]
        public IWebElement ConnexCS1UnitAllDevices { get; set; }

        [FindsBy(How = How.Id, Using = Locator.LuWenUnitAllDevicesID)]
        public IWebElement LuWenUnitAllDevices { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Station1UnitAllDevicesID)]
        public IWebElement Station1UnitAllDevices { get; set; }

        [FindsBy(How = How.Id, Using = Locator.AndyDeskUnitID)]
        public IWebElement AndyDeskUnit { get; set; }

        [FindsBy(How = How.Id, Using = Locator.ConnexCS1UnitID)]
        public IWebElement ConnexCS1Unit { get; set; }

        [FindsBy(How = How.Id, Using = Locator.LuWenUnitID)]
        public IWebElement LuWenUnit { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Station1UnitID)]
        public IWebElement Station1Unit { get; set; }

        [FindsBy(How = How.Id, Using = Locator.TotalUnitAllDeviceID)]
        public IWebElement TotalUnitAllDevice { get; set; }


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
