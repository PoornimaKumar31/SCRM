using FluentAssertions;
using HillromAutomationFramework.Coding.SupportingCode;
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
            public const string SearchFieldCancelButtonXpath= "//*[@id=\"leftNav\"]/div[2]/c8y-hillrom-devices/div[1]/div[3]/div/div/div";

            //organization filters
            public const string SelectedOrganizationNameID = "orgFilterText3";
            public const string SelectedFacilityNameID = "orgFilterText4";
            public const string AllOrganizationDefaultID = "orgFilterText2";
            public const string AutomatedEyeTestDDLSelectionID = "org2";
            public const string LNTAutmatedTestDDLSelectionID = "org1";
            public const string LNTAutmatedTestDDLExpensionArrowID = "caret1";
            public const string LNTAutmatedTestDDLFacility1ID = "facility10";
            public const string LNTAutmatedTestDDLFacility1ExpensionArrowID = "caret10";
            public const string LNTAutmatedTestDDLFacility1Unit1ID = "unit100";
            public const string AllOrganizationsOptionID = "allEnterprises";

            //device list
            public const string DeviceListTableHeaderID = "table-header";
            public const string DeviceListTableBodyID = "tbody_assets";
            public const string DeviceListTableID = "deviceTable";
            public const string DeviceListRowID = "555566667777";
            public const string CompInfXPath = "//div[contains(text(),\"Component information\")]";
            public const string RadioNewMarrID = "radioLamar";
            public const string MACAddressID = "radio_mac_address";
            //table headings
            public const string TypeHeadingID = "type";
            public const string FirmwareHeadingID = "firmware";
            public const string ConfigFileHeadingID = "config";
            public const string AssetTagHeadingID = "asset";
            public const string SerialNumberHeadingID = "serialNo";
            public const string LocationHeadingID = "loc";
            public const string LastConnectedHeadingID = "last";
            public const string PMDueHeadingID = "calibration";
            public const string StatusHeadingID = "status";

            //rows
            public const string DeviceTypeXPath = "//tbody[@id='tbody_assets']/tr[1]/td[1]";
            public const string DeviceFirmwareVersionClassName = "firmware sorting";
            public const string DeviceConfigFileClassName = "configfile";
            public const string DeviceAssetTagClassName = "asset";
            public const string DeviceSerialNumberClassName = "serial";
            public const string DeviceLocationClassName = "location";
            public const string DeviceLastConnectionClassName = "connection";
            public const string DevicePMDueClassName = "pmdue";
            public const string DeviceStatusXPath = "//tbody[@id='tbody_assets']/tr[1]/td[2]";

            //pagination
            public const string PaginationXOfYLabelID = "currentPage";
            public const string PaginationDisplayID = "displayMsg";
            public const string PaginationNextIconID = "next";
            public const string PaginationPreviousIconID = "previous";
        }
        public static class ExpectedValues
        {
            public static string MainpageURL = PropertyClass.BaseURL+ "/index.html#/landing-page/devices";

            public const string GlobalServiceCenterTitle = "Services | Hillrom";
            public const string ContactUsTitle = "Contact Us | Hillrom";
            public const string TermsConditonTitle = "Hillrom Terms and Conditions | Hillrom";
            public const string PrivacyPolicyTitle = "Global Privacy Notice | Hillrom";

            public const string OrganizationLabelText = "Organization";
            public const string AssetTypeLabelText = "Asset type";

            //table headings
            public const string TypeHeadingText = "Type";
            public const string FirmwareHeadingText = "Firmware";
            public const string ConfigFileHeadingText = "Config file";
            public const string AssetTagHeadingText = "Asset tag";
            public const string SerialNumberHeadingText = "Serial number";
            public const string LocationHeadingText = "Location";
            public const string LastConnectedHeadingText = "Last connected";
            public const string PmDueHeadingText = "PM due";
            public const string StatusHeadingText = "Status";


            //Asset type dropdowm elements
            public const string AllAssetsText = "All assets";
            public const string CSMDeviceName = "Connex Spot Monitor (CSM)";
            public const string CVSMDeviceName = "Connex Vital Signs Monitor (CVSM)";
            public const string RV700DeviceName = "RetinaVue 700 (RV700)";
            public const string CentrellaDeviceName = "Centrella";

            //search elements
            public static int AllOrganizationsDevicesListWithRollUp = 31;
            public const string SearchFieldHintText = "Search";
            public const string PartialFirmwareVersionText = "1.52";
            public const string ValidPartialString = "CV";
            public static string PartialTypeText = "CV";
            public static string PartialAssetTagText = "CV";
            public const string PartialSerialNumberText = "10001";
            public const string InvalidPartialString = "ICV";
            public const string MACAddressText = "AP=B4:DE:31:0B:91:E4";
            public const int MACTotalRecords = 7;

            //device count
            public const int AllOrgnaizationDevicesCount = 1293;
            public const int AllOrgnaizationCSMDevicesCount = 12;
            public const int AllOrgnaizationCVSMDevicesCount = 19;
            public const int AllOrgnaizationRV700DevicesCount = 24;
            public const int LNTAutomatedTestOrganizationDeviceCount = 194;
            public const int LNTAutomatedTestOrganizationFacilityOneDeviceCount = 31;
            public const int LNTAutomatedTestOrganizationFacilityOneUnitOneDeviceCount = 12;
            public const int PSSServiceBastesvilleDeviceCount = 58;

        }

        public MainPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        [FindsBy(How = How.Id, Using = Locators.StatusHeadingID)]
        public IWebElement StatusHeading { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.DeviceFirmwareVersionClassName)]
        public IWebElement DeviceFirmwareVersion { get; set; }
        
        [FindsBy(How = How.ClassName, Using = Locators.DeviceConfigFileClassName)]
        public IWebElement DeviceConfigFile { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.DeviceAssetTagClassName)]
        public IWebElement DeviceAssetTag { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.DeviceSerialNumberClassName)]
        public IWebElement DeviceSerialNumber { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.DeviceLocationClassName)]
        public IWebElement DeviceLocation { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.DeviceLastConnectionClassName)]
        public IWebElement DeviceLastConnection { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.DevicePMDueClassName)]
        public IWebElement DevicePMDue { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.DeviceStatusXPath)]
        public IWebElement DeviceStatus { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.DeviceTypeXPath)]
        public IWebElement DeviceType { get; set; }

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

        [FindsBy(How = How.XPath, Using = Locators.SearchFieldCancelButtonXpath)]
        public IWebElement SearchFieldCancelButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeviceListTableHeaderID)]
        public IWebElement DeviceListTableHeader { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeviceListTableBodyID)]
        public IWebElement DeviceListTableBody { get; set; }

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

        [FindsBy(How = How.XPath, Using = Locators.CompInfXPath)]
        public IWebElement CompInfo { get; set; }

        [FindsBy(How = How.Id, Using = Locators.MACAddressID)]
        public IWebElement MACAddress { get; set; }

        [FindsBy(How = How.Id, Using = Locators.RadioNewMarrID)]
        public IWebElement RadioNewMarr { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SelectedOrganizationNameID)]
        public IWebElement SelectedOrganizationName { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SelectedFacilityNameID)]
        public IWebElement SelectedFacilityName { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PaginationXOfYLabelID)]
        public IWebElement PaginationXOfYLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PaginationDisplayID)]
        public IWebElement PaginationDisplay { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PaginationNextIconID)]
        public IWebElement PaginationNextIcon { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PaginationPreviousIconID)]
        public IWebElement PaginationPreviousIcon { get; set; }

        [FindsBy(How = How.Id, Using = Locators.AllOrganizationDefaultID)]
        public IWebElement AllOrganizationDefault { get; set; }

        [FindsBy(How = How.Id, Using = Locators.AutomatedEyeTestDDLSelectionID)]
        public IWebElement AutomatedEyeTestDDLSelection { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LNTAutmatedTestDDLSelectionID)]
        public IWebElement LNTAutomatedTestDDLSelection { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LNTAutmatedTestDDLExpensionArrowID)]
        public IWebElement LNTAutomatedTestDDLExpensionArrow { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LNTAutmatedTestDDLFacility1ID)]
        public IWebElement LNTAutomatedTestDDLFacility1 { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LNTAutmatedTestDDLFacility1ExpensionArrowID)]
        public IWebElement LNTAutmatedTestDDLFacility1ExpensionArrow { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LNTAutmatedTestDDLFacility1Unit1ID)]
        public IWebElement LNTAutmatedTestDDLFacility1Unit1 { get; set; }

        [FindsBy(How = How.Id, Using = Locators.AllOrganizationsOptionID)]
        public IWebElement AllOrganizationsOption { get; set; }

        //Search the Serial number and click on the device.
        public void SearchSerialNumberAndClick(string serialNumber)
        {
            Thread.Sleep(2000);
            SearchField.Clear();
            SearchField.EnterText(serialNumber);
            SearchField.EnterText(Keys.Enter);
            //Waiting for data to load
            Thread.Sleep(3000);
            Assert.AreEqual(1, DeviceListRow.GetElementCount(), "More than one devices are present matching with serial number " + serialNumber);
            
            //1.Should().BeGreaterThan(DeviceListRow.GetElementCount(), "More than one devices are present matching with serial number " + serialNumber);

            DeviceListRow[0].Click();
        }


    

        /// <summary>
        /// Getting column data from the Asset list Page
        /// </summary>
        /// <param name="ColumnName">Name of column from which data needs to be retrived</param>
        /// <returns>List of Column Data</returns>
        public List<string> GetColumnData(string ColumnName)
        {
            //Finding the index of sorted column
            int columnNumber = GetColumnIndex(ColumnName);
            
            //Taking the column data from the application
            IList<IWebElement> ColumnDataWebElementList = DeviceListTableBody.FindElements(By.XPath("//td[" + columnNumber + "]"));

            List<string> ColumnData = new List<string>();
            foreach(IWebElement rowdata in ColumnDataWebElementList)
            {
                ColumnData.Add(rowdata.Text);
            }

            return (ColumnData);
        }

        /// <summary>
        /// Gets the index of the specified column(1 based indexing).
        /// </summary>
        /// <param name="columnName">Name of the column</param>
        /// <returns>Index of the column</returns>
        public int GetColumnIndex(string columnName)
        {
            IList<IWebElement> DeviceTableHeadingElements = DeviceListTableHeader.FindElements(By.TagName("th"));
            List<string> DeviceTableHeadingElementsText = (DeviceTableHeadingElements.Select(columnHeading => columnHeading.Text.ToString().ToLower())).ToList();
            int columnNumber = DeviceTableHeadingElementsText.IndexOf(columnName.ToLower().Trim()) + 1;
            return (columnNumber);
        }


        //function for checking display page result
        public void DisplayPageResults(string[] PageInfo, int expectedCurrentPage, int expectedLastPage, int expectedTotalRecords)
        {
            string currentPageLastPageInfo = PageInfo[1];
            char[] currentAndLastPage = currentPageLastPageInfo.ToCharArray();
            int[] pageNumericValue = Array.ConvertAll(currentAndLastPage, c => (int)Char.GetNumericValue(c));
            int actualCurrentPage = pageNumericValue[0];
            int actualLastPage = pageNumericValue[2];
            string totalRecords = PageInfo[3];
            int actualTotalRecords = int.Parse(totalRecords);

            actualCurrentPage.Should().Be(expectedCurrentPage, "Current page should display zero.");
            actualLastPage.Should().Be(expectedLastPage, "Last page should display zero.");
            actualTotalRecords.Should().Be(expectedTotalRecords, "Total record should display zero.");
        }

        public bool APMACAddressesMatchSearchText(IWebElement CompInfo, IWebElement RadioNewMarr, IWebElement MACAddress)
        {
            IWebElement AnyOneRecord = PropertyClass.Driver.FindElement(By.XPath("//tr[" + 1 + "]/td[" + 1 + "]"));
            AnyOneRecord.Click();
            CompInfo.JavaSciptClick();
            RadioNewMarr.Click();
            bool IsMACAddressVisible = MACAddress.GetElementVisibility();
            return IsMACAddressVisible;
        }

        /// <summary>
        /// Method for Verifying whether expected number of devices are present or not 
        /// for organization/facility/unit.
        /// </summary>
        /// <param name="ExpectedDeviceCount">Expected Device Count</param>
        /// <returns>Boolean</returns>
        public int VerifyRecordPresence()
        {
            string[] PaginationDetails = PaginationDisplay.Text.Split();
            Thread.Sleep(2000);
            int TotalRecords = int.Parse(PaginationDetails[3]);           

            return TotalRecords;           
        }

        /// <summary>
        /// Returns the Web Element for given column name and serial number
        /// </summary>
        /// <param name="columnnName">Column Name for which data required</param>
        /// <param name="serialNumber">Serial number of the Device</param>
        /// <returns>Web Element for given column name and Serial Number</returns>
        public IWebElement GetDeviceColumnData(string columnnName, string serialNumber)
        {
            SearchField.Clear();
            SearchField.EnterText(serialNumber);
            SearchField.EnterText(Keys.Enter);
            //Waiting for data to load
            Thread.Sleep(2000);

            if (DeviceListRow.GetElementCount() == 1)
            {
                switch (columnnName.ToLower().Trim())
                {
                    case "type":
                        return DeviceType;

                    case "status":
                        return DeviceStatus;

                    case "firmware":
                        return DeviceFirmwareVersion;

                    case "config file":
                        return DeviceConfigFile;

                    case "asset tag":
                        return DeviceAssetTag;

                    case "serial number":
                        return DeviceSerialNumber;

                    case "location":
                        return DeviceLocation;

                    case "last connected":
                        return DeviceLastConnection;

                    case "pm due":
                        return DevicePMDue;

                    default:
                        throw new ArgumentException("Column Name is not valid");
                }
            }
            else
                throw new ArgumentException("Serial Number is not valid");
        }
    }
}
