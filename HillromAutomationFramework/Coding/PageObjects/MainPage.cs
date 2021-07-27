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
            public const string PaginationNextIconID = "next";
            public const string PaginationPreviousIconID = "previous";
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

            //search elements
            public static int AllOrganizationsDevicesListWithRollUp = 15;
            public const string SearchFieldHintText = "Search";
            public const string PartialFirmwareVersionText = "1.52";
            public const string ValidPartialString = "CV";
            public static string PartialTypeText = "CV";
            public static string PartialAssetTagText = "CV";
            public const string PartialSerialNumberText = "10001";
            public const string InvalidPartialString = "ICV";
            public const string MACAddressText = "AP=B4:DE:31:0B:91:E4";
            public const int MACTotalRecords = 6;

            //device count
            public const int AllOrgnaizationDevicesCount = 219;
            public const int AllOrgnaizationCSMDevicesCount = 6;
            public const int AllOrgnaizationCVSMDevicesCount = 9;
            public const int AllOrgnaizationRV700DevicesCount = 24;
            public const int LNTAutomatedTestOrganizationDeviceCount = 194;
            public const int LNTAutomatedTestOrganizationFacilityOneDeviceCount = 16;
            public const int LNTAutomatedTestOrganizationFacilityOneUnitOneDeviceCount = 12;


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

        [FindsBy(How = How.XPath, Using = Locators.SearchFieldCancelButtonXpath)]
        public IWebElement SearchFieldCancelButton { get; set; }

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

        [FindsBy(How = How.XPath, Using = Locators.CompInfXPath)]
        public IWebElement CompInfo { get; set; }

        [FindsBy(How = How.Id, Using = Locators.MACAddressID)]
        public IWebElement MACAddress { get; set; }

        [FindsBy(How = How.Id, Using = Locators.RadioNewMarrID)]
        public IWebElement RadioNewMarr { get; set; }

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

        //function for checking display page result
        public bool DisplayPageResults(string[] PageInfo, int p0, int p1, int p2)
        {
            string str0 = PageInfo[1];
            char[] cha = str0.ToCharArray();
            int[] Aint = Array.ConvertAll(cha, c => (int)Char.GetNumericValue(c));
            int a1 = Aint[0];
            int a11 = Aint[2];
            string str2 = PageInfo[3];
            int NoOfPages = int.Parse(str2);
            bool boo = a1 == p0 && a11 == p1 && NoOfPages == p2;
            return boo;
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

        //Method for Verifying whether expected number of devices are present or not for organization/facility/unit.
        public bool VerifyRecordPresence(int ExpectedDeviceCount)
        {
            int count = 0;
            for (int page = 1; page <= (ExpectedDeviceCount / 50)+1; page++)
            {   
                count = count + DeviceListRow.Count;
                if (ExpectedDeviceCount > 50)
                {
                    PaginationNextIcon.Click();
                }
                Thread.Sleep(3000);
            }
            Console.WriteLine("Actual Count = "+count);
            return (ExpectedDeviceCount == count);
        }

    }
}
