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
        }

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
    }
}
