using FluentAssertions;
using HillromAutomationFramework.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HillromAutomationFramework.PageObjects
{
    public class ConfigStatusReportPage
    {
        public static class Locators
        {
            public const string DownloadButtonId = "cu-download";
            public const string InformationButtonId = "cu-info";
            public const string InformationPopUpId = "myHelp";
            public const string InformationPopUpHeaderClassName = "heading";
            public const string InformationPopUpCloseButtonclassName = "ok"; 
            public const string InformationPopUpDataClassName = "para";
            public const string StatusLabelClassName = "key";

            public const string ReportTitleID = "reportTitleHeader";
            public const string SearchBoxID = "search";
            public const string PrintButtonID = "cu-print";
            public const string PreviousPaginationIconID = "previous";
            public const string NextPaginationIconID = "next";
            public const string PageXOfYXpath = "//div[contains(text(),'Page')]";
            public const string PageDisplayClassName = "dataTables_info";

            //Configuration Update status(CSM) table elements
            public const string SerialNumberHeadingID = "serialNo";
            public const string ConfigurationHeadingID = "config";
            public const string LocationHeadingID = "loc";
            public const string StatusHeadingID = "status";
            public const string LastDeployedHeadingID = "lastDeployed";
            public const string LastConnectedHeadingID = "lastConnected";
            public const string TableHeadingClassName = "device-info-list";

            //Search elements
            public const string SerialNumberColumnXpath = "//div[@class='measurements']//div//div[1]";
            public const string ConfigurationColumnXpath = "//div[@class='measurements']//div//div[2]";
            public const string LocationColumnXpath = "//div[@class='measurements']//div//div[3]";
            public const string StatusColumnXpath = "//div[@class='measurements']//div//div[4]";
            public const string LastDeployedColumnXpath = "//div[@class='measurements']//div//div[5]";
            public const string LastConnectedColumnXpath = "//div[@class='measurements']//div//div[6]";

            public const string ColumnCommonXpath = "//div[@class='measurements']/div/div";
        }

        public ConfigStatusReportPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = Locators.SearchBoxID)]
        public IWebElement SearchBox { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ReportTitleID)]
        public IWebElement ReportTitle { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PrintButtonID)]
        public IWebElement PrintButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PreviousPaginationIconID)]
        public IWebElement PreviousPaginationIcon { get; set; }

        [FindsBy(How = How.Id, Using = Locators.NextPaginationIconID)]
        public IWebElement NextPaginationIcon { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.PageXOfYXpath)]
        public IWebElement PageXOfY { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.PageDisplayClassName)]
        public IWebElement PageDisplay { get; set; }

        //Configuration Update status(CSM) table elements
        [FindsBy(How = How.Id, Using = Locators.SerialNumberHeadingID)]
        public IWebElement SerialNumberHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ConfigurationHeadingID)]
        public IWebElement ConfigurationHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LocationHeadingID)]
        public IWebElement LocationHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.StatusHeadingID)]
        public IWebElement StatusHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LastDeployedHeadingID)]
        public IWebElement LastDeployedHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LastConnectedHeadingID)]
        public IWebElement LastConnectedHeading { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.TableHeadingClassName)]
        public IWebElement TableHeading { get; set; }

        //Search elements
        [FindsBy(How = How.XPath, Using = Locators.SerialNumberColumnXpath)]
        public IList<IWebElement> SerialNumberColumn { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.ConfigurationColumnXpath)]
        public IList<IWebElement> ConfigurationColumn { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.LocationColumnXpath)]
        public IList<IWebElement> LocationColumn { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.StatusColumnXpath)]
        public IList<IWebElement> StatusColumn { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.LastDeployedColumnXpath)]
        public IList<IWebElement> LastDeployedColumn { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.LastConnectedColumnXpath)]
        public IList<IWebElement> LastConnectedColumn { get; set; }


        //information and status

        [FindsBy(How = How.Id, Using = Locators.InformationPopUpId)]
        public IWebElement InformationPopUp { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DownloadButtonId)]
        public IWebElement DownloadButton { get; set; }

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

        public IDictionary<string,string> GetstatusTable(string statusData)
        {
            string[] splitRowdata = statusData.Split("\r\n");
            IDictionary<string, string> statusDefinationPairs = new Dictionary<string, string>();
            for (int row = 0; row <= splitRowdata.Length - 1; row++)
            {
                string ele = splitRowdata[row];
                string label = GetStatusLabel(row);
                string stat = ele.Substring(0, label.Length);
                string defination = ele.Substring(label.Length);
                statusDefinationPairs.Add(stat, defination.Trim());
            }
            return (statusDefinationPairs);
        }

        public string GetStatusLabel(int row)
        {
            return (StatusLabel[row].Text);
        }

        /// <summary>
        /// Getting specific column Data
        /// </summary>
        /// <param name="columnName">Name of the column specified</param>
        /// <returns>Returns list of data of specified column</returns>
        public List<string> GetColumnData(IWebDriver driver,string columnName)
        {
            //Getting columnHeading
            IList<IWebElement> columnList;
            columnList = TableHeading.FindElements(By.TagName("div"));

            //Getting index of the column
            List<string> columnHeadingList = (columnList.Select(column => column.Text.ToLower())).ToList();

            //Check if column is present in the 
            columnHeadingList.Should().Contain(columnName.ToLower(), columnName + " is a invalid column heading.");

            int columnIndex = columnHeadingList.IndexOf(columnName.ToLower()) + 1;

            //Check if any device match the search result
            int columnDataCount;
            try
            {
                columnDataCount = (driver.FindElements(By.XPath(Locators.ColumnCommonXpath + "[" + columnIndex + "]"))).Count;
            }
            catch (Exception)
            {
                columnDataCount = 0;
            }

            columnDataCount.Should().BeGreaterThan(0, "Atleast one device should present in table with data " + columnName);

            //Getting column Data
            List<string> columnDataList = new List<string>();

            columnList = driver.FindElements(By.XPath(Locators.ColumnCommonXpath + "[" + columnIndex + "]"));
            columnDataList.AddRange(columnList.Select(rowData => rowData.Text.ToLower()));
            return (columnDataList);
        }
    }
}
