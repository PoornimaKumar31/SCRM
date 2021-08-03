using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HillromAutomationFramework.Coding.PageObjects
{
    class ReportsPage
    {
        public ReportsPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        public static class Locator
        {
            public const string FacilityDDLID = "orgFilter";
            public const string AssetTypeDDLID = "modelFilter";
            public const string ReportTypeDDLID = "typeFilter";
            public const string GetReportButtonID = "getReport";
            public const string FacilityLabelID = "orgFilterLabel";
            public const string AssetTypeLabelID = "asset_type";
            public const string ReportTypeLabelID = "report_type";
        }

        public static class ExpectedValues
        {
            public const string CSMDeviceName = "Connex Spot Monitor (CSM)";
            public const string CVSMDeviceName = "Connex Vital Signs Monitor (CVSM)";
            public const string RV700DeviceName = "RetinaVue 700 (RV700)";
            public const string GetReportButtonID = "getReport";
            public const string FacilityLabelID = "orgFilterLabel";
            public const string AssetTypeLabelID = "asset_type";
            public const string ReportTypeLabelID = "report_type";
            public const string ConfigurationReportType = "CFG Update Status";
            public const string FirmwareVersionReportType = "Firmware Version";
            public const string ActivityReportType = "Activity";
            public const string FirmwareStatusReportType = "Firmware Status";
            public const string UsageReportType = "Usage";
            public const string APLocationReportType = "Access Point Locations";


        }

        [FindsBy(How = How.Id, Using = Locator.FacilityDDLID)]
        public IWebElement FacilityDDL { get; set; }

        [FindsBy(How = How.Id, Using = Locator.FacilityLabelID)]
        public IWebElement FacilityLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.AssetTypeDDLID)]
        public IWebElement AssetTypeDDL { get; set; }

        [FindsBy(How = How.Id, Using = Locator.AssetTypeLabelID)]
        public IWebElement AssetTypeLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.ReportTypeDDLID)]
        public IWebElement ReportTypeDDL { get; set; }

        [FindsBy(How = How.Id, Using = Locator.ReportTypeLabelID)]
        public IWebElement ReportTypeLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.GetReportButtonID)]
        public IWebElement GetReportButton { get; set; }


    }
}

