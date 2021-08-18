using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HillromAutomationFramework.Coding.PageObjects.ReportsTab
{
    class CVSMUsageReportPage
    {
        public CVSMUsageReportPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        public static class ExpectedValue
        {
            public const string Station1HiddenDeviceStyleAttribute = "display: none;";
            public const string Station1VisibleDeviceStyleAttribute = "display: block;";
        }

        public static class Locator
        {
            public const string ReportTitleHeaderID = "reportTitleHeader";
            public const string PrintButtonID = "print";
            public const string NumberOfDevicesOnEachFloorLabelID = "number_of_devices";
            public const string PieChartID = "myCanva";
            public const string TotalUsageDetailsLabelClassName = "total-usage";
            public const string UnitToggleArrowXPath = "//div[@id=\"modelName\"]//span[@id=\"report0\"]";
            public const string Station1DeviceContainerID = "devices0";
            public const string ModelColumnHeaderID = "model";
            public const string AssetTagColumnHeaderID = "asset_tag";
            public const string SerialNumberColumnHeaderID = "serial";
            public const string BatteryCycleCountColumnHeaderID = "battery_cycle_count";
            public const string SureTempThermometerCycleCountColumnHeaderID = "temp_cycle_count";
            public const string NIBPSensorCycleCountCoulumnHeaderID = "sensor_cycle_count";
            public const string SpHbCycleCountColumnHeaderID = "sphb_cycle_count";
            public const string ReportHeadRowXPath = "//div[@id=\"usage_table\"]//div[2]//div[1]//div[@class=\"row reportsHead\"]";
        }

        [FindsBy(How = How.XPath,Using =Locator.ReportHeadRowXPath)]
        public IWebElement ReportHeadRow { get; set; }

        [FindsBy(How = How.Id,Using =Locator.ReportTitleHeaderID)]
        public IWebElement ReportTitleHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locator.PrintButtonID)]
        public IWebElement PrintButton { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NumberOfDevicesOnEachFloorLabelID)]
        public IWebElement NumberOfDevicesOnEachFloorLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.PieChartID)]
        public IWebElement PieChart { get; set; }

        [FindsBy(How = How.ClassName, Using = Locator.TotalUsageDetailsLabelClassName)]
        public IWebElement TotalUsageDetailsLabel { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.UnitToggleArrowXPath)]
        public IWebElement UnitToggleArrow { get; set; }

        [FindsBy(How = How.Id,Using = Locator.Station1DeviceContainerID)]
        public IWebElement Station1DeviceContainer { get; set; }

        [FindsBy(How = How.Id, Using = Locator.ModelColumnHeaderID)]
        public IWebElement ModelColumnHeader { get; set; }

        [FindsBy(How = How.Id, Using = Locator.AssetTagColumnHeaderID)]
        public IWebElement AssetTagColumnHeader { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SerialNumberColumnHeaderID)]
        public IWebElement SerialNumberColumnHeader { get; set; }

        [FindsBy(How = How.Id, Using = Locator.BatteryCycleCountColumnHeaderID)]
        public IWebElement BatteryCycleCountColumnHeader { get; set; }


        [FindsBy(How = How.Id, Using = Locator.SureTempThermometerCycleCountColumnHeaderID)]
        public IWebElement SureTempThermometerCycleCountColumnHeader { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.NIBPSensorCycleCountCoulumnHeaderID)]
        public IWebElement NIBPSensorCycleCountCoulumnHeader { get; set; }

        [FindsBy(How = How.Id, Using = Locator.SpHbCycleCountColumnHeaderID)]
        public IWebElement SpHbCycleCountColumnHeader { get; set; }
    }
}