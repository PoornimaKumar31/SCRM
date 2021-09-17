using FluentAssertions;
using HillromAutomationFramework.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace HillromAutomationFramework.PageObjects
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
            public const string AutomatedEyeTestDDLSelectionID = "org3";
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

        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
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

        /// <summary>
        /// Search the Serial number and click on the device
        /// </summary>
        /// <param name="serialNumber">Srial Number of the device to search</param>
        public void SearchSerialNumberAndClick(string serialNumber)
        {
            Thread.Sleep(2000);
            SearchField.Clear();
            SearchField.EnterText(serialNumber);
            SearchField.EnterText(Keys.Enter);
            //Waiting for data to load
            Thread.Sleep(3000);

            int deviceListCountMatchingSerilaNumber = DeviceListRow.GetElementCount();
            deviceListCountMatchingSerilaNumber.Should().Be(1, because: "Only one device should match the serial number "+ serialNumber);

            DeviceListRow[0].Click();
        }

        /// <summary>
        /// Go to the last page of the device list
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="TotalPage"></param>
        public void GoToLastPage(IWebDriver driver,int TotalPage)
        {
            for(int i =1;i<TotalPage;i++)
            {
                PaginationNextIcon.ClickWebElement(driver);
                //Delay due data load
                Thread.Sleep(10000);
            }
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

        public bool APMACAddressesMatchSearchText(IWebDriver driver,IWebElement CompInfo, IWebElement RadioNewMarr, IWebElement MACAddress)
        {
            IWebElement AnyOneRecord = driver.FindElement(By.XPath("//tr[" + 1 + "]/td[" + 1 + "]"));
            AnyOneRecord.Click();
            CompInfo.JavaSciptClick(driver);
            RadioNewMarr.Click();
            bool IsMACAddressVisible = MACAddress.GetElementVisibility();
            return IsMACAddressVisible;
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
                return columnnName.ToLower().Trim() switch
                {
                    "type" => DeviceType,
                    "status" => DeviceStatus,
                    "firmware" => DeviceFirmwareVersion,
                    "config file" => DeviceConfigFile,
                    "asset tag" => DeviceAssetTag,
                    "serial number" => DeviceSerialNumber,
                    "location" => DeviceLocation,
                    "last connected" => DeviceLastConnection,
                    "pm due" => DevicePMDue,
                    _ => throw new ArgumentException("Column Name is not valid"),
                };
            }
            else
                throw new ArgumentException("Serial Number is not valid");
        }
    }
}
