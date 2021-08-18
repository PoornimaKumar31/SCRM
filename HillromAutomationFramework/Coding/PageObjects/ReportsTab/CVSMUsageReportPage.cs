using FluentAssertions;
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

            //Station 1 unit
            public static List<string> Station1UnitCVSMDeviceSerialNumbers = new List<string>()
            {
                "100020000000",
                "100020000001",
                "100020000008",
                "100020000005",
                "100020000003",
                "100020000004",
                "100020000006",
                "100020000007",
                "100020000002"
            };


            //notset unit
            public static List<string> NotSetUnitCVSMDevicesSerialNumber = new List<string>()
            {
                "103001220212",
                "100085374016",
                "100073764115",
                "103001220213",
                "103001220216",
                "103001220214",
                "100009382218"
            };

            //LuWen Unit
            public static List<string> LuWenUnitCVSMDevicesSerialNumber = new List<string>()
            {
                "100042631718"
            };

            //Connex CS1 Unit
            public static List<string> ConnexCS1UnitCVSMDevicesSerialNumber = new List<string>()
            {
                "103002311813"
            };

            //Andy's Desk Unit
            public static List<string> AndyDeskUnitCVSMDevicesSerialNumber = new List<string>()
            {
                "103001220215"
            };
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
            public const string UnitsRowListXpath = "//*[starts-with(@id,'location')]";

            public const string SerailNumberUnit1ColumnXpath = "//div[@id='devices0']//div//div[3]";
            public const string SerialNumberUnit2ColumnXpath = "//div[@id='devices1']//div//div[3]";
            public const string SerialNumberUnit3ColumnXpath = "//div[@id='devices2']//div//div[3]";
            public const string SerialNumberUnit4ColumnXpath = "//div[@id='devices3']//div//div[3]";
            public const string SerialNumberUnit5ColumnXpath = "//div[@id='devices4']//div//div[3]";


        }

        [FindsBy(How = How.XPath, Using = Locator.SerailNumberUnit1ColumnXpath)]
        public IList<IWebElement> SerialNumberUnit1Column { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.SerialNumberUnit2ColumnXpath)]
        public IList<IWebElement> SerialNumberUnit2Column { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.SerialNumberUnit3ColumnXpath)]
        public IList<IWebElement> SerialNumberUnit3Column { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.SerialNumberUnit4ColumnXpath)]
        public IList<IWebElement> SerialNumberUnit4Column { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.SerialNumberUnit5ColumnXpath)]
        public IList<IWebElement> SerialNumberUnit5Column { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.UnitsRowListXpath)]
        public IList<IWebElement> UnitsRowList { get; set; }

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

        /// <summary>
        /// Checks if all the devices under the unit is displayed
        /// </summary>
        /// <param name="serialNumberList">List of web elements of serial numbers under the unit</param>
        /// <param name="expectedSerialNumberList">Expected list of serial number of devices comes under the list</param>
        public void CheckAllDevicesUnderUnitsIsDisplayed(IList<IWebElement> serialNumberList, List<string> expectedSerialNumberList)
        {
            int DeviceCountUnderUnit = serialNumberList.GetElementCount();
            DeviceCountUnderUnit.Should().BeGreaterThan(0, "Atleast one device should be present under units.");
            List<string> ActualSerialNumberListUnderUnits = new List<string>();
            //Station1
            foreach (IWebElement serialNumber in serialNumberList)
            {
                ActualSerialNumberListUnderUnits.Add(serialNumber.Text);
            }
            //Asserting
            ActualSerialNumberListUnderUnits.Should().BeEquivalentTo(expectedSerialNumberList);

        }
    }
}
