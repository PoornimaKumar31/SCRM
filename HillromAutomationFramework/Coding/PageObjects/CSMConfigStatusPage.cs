using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HillromAutomationFramework.Coding.PageObjects
{
    public class CSMConfigStatusPage
    {
        public static class Locators
        {
            public const string AssetTypeDropdownId = "modelFilter";
            public const string ReportTypeDropdownId = "typeFilter";
            public const string GetReportButtonId = "getReport";
            public const string InformationButtonId = "cu-info";       //"fs-info"
            public const string InformationPopUpId = "myHelp";
            public const string InformationPopUpHeaderClassName = "heading";
            public const string InformationPopUpCloseButtonclassName = "ok";

            public const string InformationPopUpDataClassName = "para";
        }
        public static class ExpectedValues
        {
            public const string CSMDeviceName = "Connex Spot Monitor (CSM)";
            public const string CSMConfiguration = "CFG Update Status";
            public const string InformationPopUPHeaderText = "CSM Configuration Report Statuses:";
            public const string StratedDefinition = "Configuration update has been initiated.";
            public const string TransferredDefinitation = "Configuration update has been transferred.";
            public const string AvailableDefinitation = "Configuration update has been received by Service Monitor and is waiting for device to call home.";
            public const string AppliedDefinitation = "Configuration update successful. Device is currently using the new configuration.";
            public const string FailedDefinition = "Configuration update aborted. Check logs for details.";
        }

        public CSMConfigStatusPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }
        [FindsBy(How = How.Id, Using = Locators.InformationPopUpId)]
        public IWebElement InformationPopUp { get; set; }

        [FindsBy(How = How.Id, Using = Locators.AssetTypeDropdownId)]
        public IWebElement AssetTypeDropdown { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ReportTypeDropdownId)]
        public IWebElement ReportTypeDropdown { get; set; }

        [FindsBy(How = How.Id, Using = Locators.GetReportButtonId)]
        public IWebElement GetReportButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.InformationButtonId)]
        public IWebElement InformationButton { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.InformationPopUpHeaderClassName)]
        public IWebElement InformationPopUpHeader { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.InformationPopUpCloseButtonclassName)]
        public IWebElement InformationPopUpCloseButton { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.InformationPopUpDataClassName)]
        public IWebElement InformationPopUpData { get; set; }

        public IDictionary<string,string> GetstatusTable(string statusData)
        {
            string[] splitRowdata = statusData.Split("\r\n");
            IDictionary<string, string> statusDefinationPairs = new Dictionary<string, string>();
            for (int row = 0; row <= splitRowdata.Length - 1; row++)
            {
                string ele = splitRowdata[row];
                string[] splitrow = ele.Split(" ", 2);
                statusDefinationPairs.Add(splitrow[0], splitrow[1]);
            }
            return (statusDefinationPairs);
        }
    }
}
