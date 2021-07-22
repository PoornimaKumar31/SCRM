﻿using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace HillromAutomationFramework.Coding.PageObjects
{
    public class MainPage
    {
        public static class Locators
        {
            //Links
            public const string GlobalSeviceCenterID = "gsc";
            public const string ContactUsID = "contactus";

            //Tabs
            public const string AssetsTabID = "assetsTab";
            public const string ReportsTabID = "reportsTab";
            public const string UpdatesTabID = "updatesTab";
            public const string AdvancedTabID = "advancedTab";

            //Device filter elements
            public const string OrganizationLabelXpath= "//*[@id=\"leftNav\"]/div[2]/c8y-hillrom-devices/div[1]/div[1]/div/label";
            public const string OrganizationDropdownID = "orgFilter";
            public const string AssetTypeLabelXpath = "//*[@id=\"leftNav\"]/div[2]/c8y-hillrom-devices/div[1]/div[2]/div/label";
            public const string AssetTypeDropDownID = "assetFilter";
            public const string SearchFieldID = "search";

            //organization filters
            public const string SelectedOrganizationNameID = "orgFilterText3";
            public const string SelectedFacilityNameID = "orgFilterText4";


            //device list
            public const string DeviceListTableHeaderID = "table-header";
            public const string DeviceListTableBodyID = "tbody_assets";
            public const string DeviceListTableID = "deviceTable";
            public const string DeviceListRowID = "555566667777";
            //table headings
            public const string TypeHeadingID = "type";
            public const string FirmwareHeadingID = "firmware";
            public const string ConfigFileHeadingID = "config";
            public const string AssetTagHeadingID = "asset";
            public const string SerialNumberHeadingID = "serialNo";
            public const string LocationHeadingID = "loc";
            public const string LastConnectedHeadingID = "last";
            public const string PMDueHeadingID = "calibration";

            //rows
            public const string DeviceTypeClassName = "ng-star-inserted";
            public const string FirmwareVersionClassName = "firmware";
            public const string ConfigFileClassName = "configFile";
            public const string AssetTagClassName = "asset";
            public const string SerialNumberClassName = "serial";
            public const string LocationClassName = "location";
            public const string LastConnectionClassName = "connection";

            //pagination
            public const string PaginationXOfYLabelID = "currentPage";
            public const string PaginationDisplayID = "displayMsg";
        }
        public static class ExpectedValues
        {
            public const string MainpageURL = "https://incubator.deviot.hillrom.com/apps/remotemanagement-centrella/index.html#/landing-page/devices";

            public const string GlobalServiceCenterTitle = "Services | Hillrom";
            public const string ContactUsTitle = "Contact Us | Hillrom";
            public const string TermsConditonTitle = "Hillrom Terms and Conditions | Hillrom";
            public const string PrivacyPolicyTitle = "Global Privacy Notice | Hillrom";

            //Asset type dropdowm elements
            public const string AllAssetsText = "All assets";
            public const string CSMDeviceName = "Connex Spot Monitor (CSM)";
            public const string CVSMDeviceName = "Connex Vital Signs Monitor (CVSM)";
            public const string RV700DeviceName = "RetinaVue 700 (RV700)";
        }

        public MainPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        [FindsBy(How =How.Id,Using =Locators.GlobalSeviceCenterID)]
        public IWebElement GlobalServiceCenter { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ContactUsID)]
        public IWebElement ContactUs { get; set; }

        [FindsBy(How = How.Id, Using = Locators.AssetsTabID)]
        public IWebElement AssetsTab { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ReportsTabID)]
        public IWebElement ReportsTab { get; set; }

        [FindsBy(How = How.Id, Using = Locators.UpdatesTabID)]
        public IWebElement UpdatesTab { get; set; }

        [FindsBy(How = How.Id, Using = Locators.AdvancedTabID)]
        public IWebElement AdvancedTab { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.OrganizationLabelXpath)]
        public IWebElement OrganizationLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.OrganizationDropdownID)]
        public IWebElement OrganizationDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.AssetTypeLabelXpath)]
        public IWebElement AssetTypeLabel { get; set; }

        [FindsBy(How =How.Id, Using =Locators.AssetTypeDropDownID)]
        public IWebElement AssetTypeDropDown { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SearchFieldID)]
        public IWebElement SearchField { get; set; }
        //table
        [FindsBy(How = How.Id, Using = Locators.DeviceListTableHeaderID)]
        public IWebElement DeviceListTableHeader { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeviceListTableBodyID)]
        public IWebElement DeviceListTableBody { get; set; }


        //table headings
        [FindsBy(How = How.Id, Using = Locators.TypeHeadingID)]
        public IWebElement TypeHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.FirmwareHeadingID)]
        public IWebElement FirmwareHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ConfigFileHeadingID)]
        public IWebElement ConfigFileHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.AssetTagHeadingID)]
        public IWebElement AssetTagHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SerialNumberHeadingID)]
        public IWebElement SerialNumberHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LocationHeadingID)]
        public IWebElement LocationHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LastConnectedHeadingID)]
        public IWebElement LastConnectedHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PMDueHeadingID)]
        public IWebElement PMDueHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeviceListRowID)]
        public IList<IWebElement> DeviceListRow { get; set; }


        //organization filters
        [FindsBy(How = How.Id, Using = Locators.SelectedOrganizationNameID)]
        public IWebElement SelectedOrganizationName { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SelectedFacilityNameID)]
        public IWebElement SelectedFacilityName { get; set; }

        //Pagination 
        [FindsBy(How = How.Id, Using = Locators.PaginationXOfYLabelID)]
        public IWebElement PaginationXOfYLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PaginationDisplayID)]
        public IWebElement PaginationDisplay { get; set; }


        //Search the Serial number and click on the device.
        public void SearchSerialNumberAndClick(string serialNumber)
        {
            SearchField.EnterText(serialNumber + Keys.Enter);
            Thread.Sleep(1000);
            Assert.AreEqual(1, DeviceListRow.GetElementCount(), "Not selected the specified device.");
            DeviceListRow[0].Click();
        }


        //Function to check sorting
        public bool CheckSort(string sortColumnName,string sortingOrder="a")
        {
            IList<IWebElement> DeviceTableHeadingElements = DeviceListTableHeader.FindElements(By.TagName("th"));
            List<string> DeviceTableHeadingElementsText = new List<string>();
            foreach (IWebElement columnHeading in DeviceTableHeadingElements)
            {
                DeviceTableHeadingElementsText.Add(columnHeading.Text.ToString().ToLower());
            }
            int columnNumber = DeviceTableHeadingElementsText.IndexOf(sortColumnName.ToLower().Trim())+1;
            IList<IWebElement> ColumnData = DeviceListTableBody.FindElements(By.XPath("//td["+columnNumber+"]"));
            List<string> ColumnDataText = new List<string>();
            foreach (IWebElement rowdata in ColumnData)
            {
                ColumnDataText.Add(rowdata.Text);
            }
            List<string> UnsortedColumnData = new List<string>(ColumnDataText);
            ColumnDataText.Sort((s1, s2) => s1.CompareTo(s2));
            if (sortingOrder.ToLower().Contains("d"))
            {
                ColumnDataText.Reverse();
            }
            return (Enumerable.SequenceEqual(ColumnDataText, UnsortedColumnData));

        }
    }
}
