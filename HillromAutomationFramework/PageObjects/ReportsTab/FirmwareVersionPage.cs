using HillromAutomationFramework.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HillromAutomationFramework.PageObjects.ReportsTab
{
    class FirmwareVersionPage
    {
        public static class Locators
        {
            public const string FirmwareReportTitleID = "reportTitleHeader";
            public const string ComponentsHeadingID = "component";
            public const string FirmwareVersionHeadingID = "firm_version";
            public const string TotaldevicesHeadingID = "device_count";

            //CSM
            public const string TotalRowID = "location_header0";
            public const string TotalRowDetailsID = "unitMetrics0";
            public const string Unit1RowID = "location_header1";
            public const string Unit1RowDetailsID = "unitMetrics1";

            //CVSM
            public const string AndyDeskUnitID = "location_header2";
            public const string AndyDeskUnitAllDevicesID = "unitMetrics2";
            public const string ConnexCS1UnitID = "location_header3";
            public const string ConnexCS1UnitAllDevicesID = "unitMetrics3";
            public const string LuWenUnitID = "location_header4";
            public const string LuWenUnitAllDevicesID = "unitMetrics4";
            public const string Station1UnitID = "location_header7";
            public const string Station1UnitAllDevicesID = "unitMetrics7";
            public const string PrintButtonID = "fv-print";

        }
        public static class ExpectedValues
        {
            public const string ReportCVSMLabelText = "FIRMWARE VERSION REPORT (CVSM)";
            public const string ReportCSMLabelText = "FIRMWARE VERSION REPORT (CSM)";
            public const string ReportRV700LabelText = "FIRMWARE VERSION REPORT (RV700)";
            public const string ReportCentrellaLabelText = "FIRMWARE VERSION REPORT (CENTRELLA)";
            public const string ComponentsHeadingText = "Components";
            public const string FirmwareVersionHeadingText = "Firmware version";
            public const string TotalDevicesHeadingText = "Total devices";
        }

        public FirmwareVersionPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
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

        //CVSM

        [FindsBy(How = How.Id, Using = Locators.AndyDeskUnitAllDevicesID)]
        public IWebElement AndyDeskUnitAllDevices { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ConnexCS1UnitAllDevicesID)]
        public IWebElement ConnexCS1UnitAllDevices { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LuWenUnitAllDevicesID)]
        public IWebElement LuWenUnitAllDevices { get; set; }

        [FindsBy(How = How.Id, Using = Locators.Station1UnitAllDevicesID)]
        public IWebElement Station1UnitAllDevices { get; set; }

        [FindsBy(How = How.Id, Using = Locators.AndyDeskUnitID)]
        public IWebElement AndyDeskUnit { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ConnexCS1UnitID)]
        public IWebElement ConnexCS1Unit { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LuWenUnitID)]
        public IWebElement LuWenUnit { get; set; }

        [FindsBy(How = How.Id, Using = Locators.Station1UnitID)]
        public IWebElement Station1Unit { get; set; }
    }
}
