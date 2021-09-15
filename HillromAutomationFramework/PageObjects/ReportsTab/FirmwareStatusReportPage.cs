using HillromAutomationFramework.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FluentAssertions;

namespace HillromAutomationFramework.PageObjects
{
    class FirmwareStatusReportPage
    {
        public static class Locators
        {
            //Firmware status
            public const string InformationButtonId = "fs-info";
            public const string InformationPopUpId = "myHelp";
            public const string InformationPopUpHeaderClassName = "heading";
            public const string InformationPopUpCloseButtonclassName = "ok";
            public const string InformationPopUpDataClassName = "para";
            public const string StatusLabelClassName = "key";
            public const string FirmwareReportTitleID = "reportTitleHeader";
            public const string PrintButtonID = "fs-print";
            public const string DownloadButtonID = "fs-download";
            public const string SearchBoxID = "search";

            //Firmware Upgrade status(CSM) table elements
            public const string SerialNumberHeadingID = "serialNo";
            public const string FirmwareVerionHeadingID = "firmVer";
            public const string LocationHeadingID = "loc";
            public const string StatusHeadingID = "status";
            public const string LastDeployedHeadingID = "lastDeploy";
            public const string LastConnectedHeadingID = "lastConnect";
            public const string TableHeaderClassName = "device-info-list";

            //pagination
            public const string PaginationNextIconID = "next";
            public const string PaginationPreviousIconID = "previous";
            public const string PaginationXofYClassName = "paginationMessage";
            public const string PaginationDisplayXYClassName = "dataTables_info";


            //Search Column Elements
            public const string ColumnCommonXpath = "//div[@class='measurements']/div/div";
        }

        public FirmwareStatusReportPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = Locators.FirmwareReportTitleID)]
        public IWebElement FirmwareReportTitle { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PrintButtonID)]
        public IWebElement PrintButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DownloadButtonID)]
        public IWebElement DownloadButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SearchBoxID)]
        public IWebElement SearchBox { get; set; }

        //Pagination
        [FindsBy(How = How.Id, Using = Locators.PaginationPreviousIconID)]
        public IWebElement PaginationPreviousIcon { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PaginationNextIconID)]
        public IWebElement PaginationNextIcon { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.PaginationXofYClassName)]
        public IWebElement PaginationXofY { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.PaginationDisplayXYClassName)]
        public IWebElement PaginationDisplayXY { get; set; }

        //Firmware Upgrade status table elements
        [FindsBy(How = How.Id, Using = Locators.SerialNumberHeadingID)]
        public IWebElement SerialNumberHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.FirmwareVerionHeadingID)]
        public IWebElement FirmwareVerionHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LocationHeadingID)]
        public IWebElement LocationHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.StatusHeadingID)]
        public IWebElement StatusHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LastDeployedHeadingID)]
        public IWebElement LastDeployedHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LastConnectedHeadingID)]
        public IWebElement LastConnectedHeading { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.TableHeaderClassName)]
        public IWebElement TableHeader { get; set; }

        //Firmware status
        [FindsBy(How = How.Id, Using = Locators.InformationPopUpId)]
        public IWebElement InformationPopUp { get; set; }

        [FindsBy(How = How.Id, Using = Locators.InformationButtonId)]
        public IWebElement InformationButton { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.InformationPopUpHeaderClassName)]
        public IWebElement InformationPopUpHeader { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.InformationPopUpCloseButtonclassName)]
        public IWebElement InformationPopUpCloseButton { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.InformationPopUpDataClassName)]
        public IWebElement InformationPopUpData { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.StatusLabelClassName)]
        public IList<IWebElement> StatusLabel { get; set; }


        /// <summary>
        /// Split the data from the information table into status and defination.
        /// </summary>
        /// <param name="statusData">string with all status and its defination</param>
        /// <returns>Dictionary of status and defination pair</returns>

        public IDictionary<string, string> GetstatusTable(string statusData)
        {
            string[] splitRowdata = statusData.Split("\r\n");
            IDictionary<string, string> statusDefinationPairs = new Dictionary<string, string>();
            for (int row = 0; row <= splitRowdata.Length - 1; row++)
            {
                string ele = splitRowdata[row];
                string label = GetStatusLabel(row);
                string stat = ele.Substring(0, label.Length);
                string defination = ele[label.Length..];
                statusDefinationPairs.Add(stat, defination.Trim());
            }
            return (statusDefinationPairs);
        }
        /// <summary>
        /// Gets the the status label of spefied row.
        /// </summary>
        /// <param name="row">Row number</param>
        /// <returns>Status</returns>
        public string GetStatusLabel(int row)
        {
            return (StatusLabel[row].Text);
        }

        /// <summary>
        /// Get Data from the respecive column
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns>List of data present in respective column</returns>
        public List<string> GetColumnData(IWebDriver driver,string columnName)
        {
            //Getting columnHeading
            IList<IWebElement> columnList;
            columnList= TableHeader.FindElements(By.TagName("div"));

            //Getting index of the column
            List<string> columnHeadingList = (columnList.Select(column => column.Text.ToLower())).ToList();
        
            //Check if column is present in the 
            columnHeadingList.Should().Contain(columnName.ToLower(), columnName + " is a invalid column heading.");

            int columnIndex = columnHeadingList.IndexOf(columnName.ToLower())+1;

            //Check if any device match the search result
            int searchMatchCount;
            try
            {
                searchMatchCount = (driver.FindElements(By.XPath(Locators.ColumnCommonXpath + "[" + columnIndex + "]"))).Count;
            }
            catch(Exception)
            {
                searchMatchCount = 0;
            }
           
            searchMatchCount.Should().BeGreaterThan(0, "Atleast one search Result should match the search by " +columnName);

            //Getting column Data
            List<string> columnDataList = new List<string>();

            columnList = driver.FindElements(By.XPath(Locators.ColumnCommonXpath + "[" + columnIndex + "]"));
            columnDataList.AddRange(columnList.Select(rowData => rowData.Text.ToLower()));
            return (columnDataList);
        }
    }
}
