using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HillromAutomationFramework.Coding.PageObjects.Component_Information
{
    public class CSMAssetListPage
    {
        public CSMAssetListPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        public class Locator
        {
            public const string DeviceRowID = "555566667777";
            public const string CSMDetailsPageID = "device-main";
            public const string CSMDetailsSummaryID = "csm_details_summary";
            public const string EditButtonID = "csm-edit";
            public const string PreventiveMaintenanceTabXPath = "//div[text()=\"Preventive maintenance\"]";
            public const string ComponentInformationTabXPath = "//div[text()=\"Component information\"]";
            public const string LogsTabXPath = "//div[text()=\"Logs\"]";
            public const string AssetDetailsSubsectionID = "device-details";

        }

        [FindsBy(How = How.Id, Using = Locator.AssetDetailsSubsectionID)]
        public IWebElement AssetDetailsSubsection { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.LogsTabXPath)]
        public IWebElement LogsTab { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.ComponentInformationTabXPath)]
        public IWebElement ComponentInformationTab { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.PreventiveMaintenanceTabXPath)]
        public IWebElement PreventiveMaintenanceTab { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DeviceRowID)]
        public IList<IWebElement> DeviceList { get; set; }

        [FindsBy(How = How.Id, Using = Locator.CSMDetailsPageID)]
        public IWebElement CSMDetailsPage { get; set; }

        [FindsBy(How = How.Id, Using = Locator.CSMDetailsSummaryID)]
        public IWebElement CSMDetailsSummary { get; set; }

        [FindsBy(How = How.Id, Using = Locator.EditButtonID)]
        public IWebElement EditButton { get; set; }

        public int GetDeviceCount()
        {
            return DeviceList.Count;
        }
    }
}
