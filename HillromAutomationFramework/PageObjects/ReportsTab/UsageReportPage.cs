using FluentAssertions;
using HillromAutomationFramework.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HillromAutomationFramework.PageObjects.ReportsTab
{
    class UsageReportPage
    {
        public UsageReportPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        public static class Locator
        {
            public const string ReportTitleHeaderID = "reportTitleHeader";
            public const string PrintButtonXpath = "//button[text()='Print']";
            public const string NumberOfdevicesOneachFloorLabelID = "number_of_devices";
            public const string PieChartID = "myCanva";
            public const string TotalUsageComponentsLabelClassName = "total-usage";
            public const string UnitToggleArrowXPath = "//div[@id=\"modelName\"]//span[@id=\"report0\"]";
            public const string Station1DeviceContainerID = "devices0";
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

            public const string SerailNumberUnit1ColumnXpath= "//div[@id='devices0']//div//div[3]";
            public const string SerialNumberUnit2ColumnXpath = "//div[@id='devices1']//div//div[3]";
            public const string SerialNumberUnit3ColumnXpath = "//div[@id='devices2']//div//div[3]";
            public const string SerialNumberUnit4ColumnXpath = "//div[@id='devices3']//div//div[3]";
            public const string SerialNumberUnit5ColumnXpath = "//div[@id='devices4']//div//div[3]";

            public const string UnitsRowListXpath = "//*[starts-with(@id,'location')]";
        }

        public static class ExpectedValues
        {
            public const string ReportTitleHeaderCVSM = "ASSET USAGE REPORT (CVSM)";
            public const string ReportTiltleHeaderCSM= "ASSET USAGE REPORT (CSM)";
            public const string NumberofDevicesOnEachFlorrLabelText = "NUMBER OF DEVICES ON EACH FLOOR";
            public const string TotalUsageDetailsComponentLabelText = "TOTAL USAGE DETAILS - COMPONENTS";

            public const string Station1HiddenDeviceStyleAttribute = "display: none;";
            public const string Station1VisibleDeviceStyleAttribute = "display: block;";

            //Tables
            public const string ModelHeadingText = "Model";
            public const string AssetTagHeadingText = "Asset tag";
            public const string SerialNumberHeadingText = "Serial number";
            public const string BatteryCycleCountHeadingText = "Battery cycle count";
            public const string SureTempThermometerCycleCountHeadingText = "Suretemp thermometer cycle count";
            public const string NIBPSensorCycleCountHeadingText = "NIBP Sensor cycle count";
            public const string SPHBCycleCountHeadingText = "SPHB cycle count";
            
            //CSM Devices
            //unit1
            public static List<string> Unit1CSMDeviceSerialNumbers = new List<string>()
            {
                "100010000000",
                "100010000001",
                "200010000001"
            };

            //unit2
            public static List<string> Unit2CSMDevicesSerialNumber = new List<string>()
            {
                "100010000005",
                "100010000004",
                "100010000006",
                "100010000007"
            };

            //unit3
            public static List<string> Unit3CSMDevicesSerialNumber = new List<string>()
            {
                "100001232114",
                "100027113318",
                "100055940720",
                "100001954714"
            };

            //unit4
            public static List<string> Unit4CSMDevicesSerialNumber = new List<string>()
            {
                "100015671718"
            };


            //CVSM
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

        [FindsBy(How = How.Id, Using = Locator.Station1DeviceContainerID)]
        public IWebElement Station1DeviceContainer { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.SerailNumberUnit1ColumnXpath)]
        public IList<IWebElement> SerialNumberUnit1Column { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.SerialNumberUnit2ColumnXpath)]
        public IList<IWebElement> SerialNumberUnit2Column { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.UnitToggleArrowXPath)]
        public IWebElement UnitToggleArrow { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.SerialNumberUnit3ColumnXpath)]
        public IList<IWebElement> SerialNumberUnit3Column { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.SerialNumberUnit4ColumnXpath)]
        public IList<IWebElement> SerialNumberUnit4Column { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.SerialNumberUnit5ColumnXpath)]
        public IList<IWebElement> SerialNumberUnit5Column { get; set; }

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

        [FindsBy(How = How.XPath, Using = Locator.UnitsRowListXpath)]
        public IList<IWebElement> UnitsRowList { get; set; }
        
        /// <summary>
        /// Checks if all the devices under the unit is displayed
        /// </summary>
        /// <param name="serialNumberList">List of web elements of serial numbers under the unit</param>
        /// <param name="expectedSerialNumberList">Expected list of serial number of devices comes under the list</param>
        public void CheckAllDevicesUnderUnitsIsDisplayed(IList<IWebElement> serialNumberList,List<string> expectedSerialNumberList)
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
