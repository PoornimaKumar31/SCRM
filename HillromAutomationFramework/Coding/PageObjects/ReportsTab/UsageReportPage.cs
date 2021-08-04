using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HillromAutomationFramework.Coding.PageObjects.ReportsTab
{
    class UsageReportPage
    {
        public UsageReportPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }
        public static class Locator
        {
            public const string ReportTitleHeaderID = "reportTitleHeader";
            public const string PrintButtonID = "print";
            public const string NumberOfdevicesOneachFloorLabelID = "number_of_devices";
            public const string PieChartID = "myCanva";
            public const string TotalUsageComponentsLabelClassName = "total-usage";


            //Tables

            public const string ModelHeadingID = "model";
            public const string AssetTagHeadingID = "asset_tag";
            public const string SerialNumberHeadingID = "serial";
            public const string BatteryCycleCountHeadingID = "battery_cycle_count";
            public const string SureTempThermometerCycyleCountHeadingID = "temp_cycle_count";
            public const string NIBPSensorCycleHeadingID = "sensor_cycle_count";
            public const string SPHBCycleCountHeadingID = "sphb_cycle_count";
            public const string Station1ID = "location0";
            public const string Station1DevicesId = "devices0";

        }

        public static class ExpectedValues
        {
            public const string ReportTiltleHeaderCSM= "ASSET USAGE REPORT (CSM)";
            public const string NumberofDevicesOnEachFlorrLabelText = "NUMBER OF DEVICES ON EACH FLOOR";
            public const string TotalUsageDetailsComponentLabelText = "TOTAL USAGE DETAILS - COMPONENTS";

            //Tables
            public const string ModelHeadingText = "Model";
            public const string AssetTagHeadingText = "Asset tag";
            public const string SerialNumberHeadingText = "Serial number";
            public const string BatteryCycleCountHeadingText = "Battery cycle count";
            public const string SureTempThermometerCycleCountHeadingText = "Suretemp thermometer cycle count";
            public const string NIBPSensorCycleCountHeadingText = "NIBP Sensor cycle count";
            public const string SPHBCycleCountHeadingText = "SPHB cycle count";

        }

        [FindsBy(How =How.Id,Using =Locator.ReportTitleHeaderID)]
        public IWebElement ReportsTitleHeader { get; set; }

        [FindsBy(How = How.Id, Using = Locator.PrintButtonID)]
        public IWebElement PrintButton { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NumberOfdevicesOneachFloorLabelID)]
        public IWebElement NumberOfdevicesOneachFloorLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.PieChartID)]
        public IWebElement PieChart { get; set; }

        [FindsBy(How = How.ClassName, Using = Locator.TotalUsageComponentsLabelClassName)]
        public IWebElement TotalUsageComponentsLabel { get; set; }

        //Tables
        [FindsBy(How = How.Id, Using = Locator.ModelHeadingID)]
        public IWebElement ModelHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locator.AssetTagHeadingID)]
        public IWebElement AssetTagHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SerialNumberHeadingID)]
        public IWebElement SerialNumberHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryCycleCountHeadingID)]
        public IWebElement BatteryCycleCountHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SureTempThermometerCycyleCountHeadingID)]
        public IWebElement SureTempThermometerCycyleCountHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NIBPSensorCycleHeadingID)]
        public IWebElement NIBPSensorCycleHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SPHBCycleCountHeadingID)]
        public IWebElement SPHBCycleCountHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Station1ID)]
        public IWebElement Station1 { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Station1DevicesId)]
        public IWebElement Station1Devices { get; set; }

    }
}
