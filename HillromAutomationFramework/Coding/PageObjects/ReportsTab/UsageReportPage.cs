﻿using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
            public const string PrintButtonXpath = "//button[text()='Print']";
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
            public const string TableHeaderXpath = "//div[@class='report-information-container']/div";

            public const string SerailnumberUnit1ColumnXpath= "//div[@id=\"devices0\"]//div//div[3]";
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
            
            public static List<string> Station1CSMDeviceSerialNumbers = new List<string>()
            {
                "100010000000",
                "100010000001",
                "200010000001"
            };
        }

        [FindsBy(How =How.Id,Using =Locator.ReportTitleHeaderID)]
        public IWebElement ReportsTitleHeader { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.PrintButtonXpath)]
        public IWebElement PrintButton { get; set; }

        [FindsBy(How = How.Id, Using = Locator.NumberOfdevicesOneachFloorLabelID)]
        public IWebElement NumberOfdevicesOneachFloorLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.PieChartID)]
        public IWebElement PieChart { get; set; }

        [FindsBy(How = How.ClassName, Using = Locator.TotalUsageComponentsLabelClassName)]
        public IWebElement TotalUsageComponentsLabel { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.SerailnumberUnit1ColumnXpath)]
        public IList<IWebElement> SerailnumberUnit1Column { get; set; }

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

        [FindsBy(How = How.XPath, Using = Locator.TableHeaderXpath)]
        public IWebElement TableHeader { get; set; }

    }
}
