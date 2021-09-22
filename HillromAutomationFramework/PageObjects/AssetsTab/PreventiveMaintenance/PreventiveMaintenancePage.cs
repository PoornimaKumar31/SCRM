using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace HillromAutomationFramework.PageObjects.AssetsTab.PreventiveMaintainenece
{
    class PreventiveMaintenancePage
    {
        public static class Locators
        {
            public const string PMNameHeadngID = "lbl_name";
            public const string PMLastCalibrationHeadingId = "lbl_lastCalDate";
            public const string LastCalibrationDateID = "lastCalDate";
            public const string CalibrationOverDueArrowID = "icon_overdue";
            public const string CalibrationOverDueTextID = "cal_overdue";
            public const string CalenderXPath = "(//div[@class=\"col-xs-12\"])[3]";
            public const string LeftArrowID = "prev_year_arrow";
            public const string RightArrowID = "next_year_arrow";
            public const string CurrentCalenderYearID = "current_year";
            public const string NextCalenderYearID = "next_year";
            public const string CalibrationOverDueDateID = "caldue_date";
            public const string PMTabXpath = "//div[text()='Preventive maintenance']";
            public const string HostControllerGraphicID = "host_controller_img";
            public const string HostControllerID = "name";
            public const string PreventiveMaintenanceLabelID = "prev-maintenance";
            public const string PMSHeaderXPath = "//div[@id=\"lbl_name\"]/parent::div/div";
            public const string PMSRowXPath = "//div[@id='lastCalDate']/parent::div//div";
            public const string HostContollerColumnXPath = "//span[@id='name']/parent::div";
            public const string PreventiveMaintenanceID = "device-details";
            public const string CSMAssetDetailsSummaryID = "csm_details_summary";
            public const string CVSMAssetDetailsSummaryID = "cvsm_details_summary";
        }

        public PreventiveMaintenancePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = Locators.PMTabXpath)]
        public IWebElement PMTab { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CSMAssetDetailsSummaryID)]
        public IWebElement CSMAssetDetailsSummary { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CVSMAssetDetailsSummaryID)]
        public IWebElement CVSMAssetDetailsSummary { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PreventiveMaintenanceID)]
        public IWebElement PreventiveMaintenance { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.PMSHeaderXPath)]
        public IList<IWebElement> PMSHeader { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.PMSRowXPath)]
        public IList<IWebElement> PMSRow { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PMNameHeadngID)]
        public IWebElement PMNameHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PMLastCalibrationHeadingId)]
        public IWebElement PMLastCalibrationHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LastCalibrationDateID)]
        public IWebElement LastCalibrationDate { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CalibrationOverDueArrowID)]
        public IWebElement CalibrationOverDueArrow { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CalibrationOverDueTextID)]
        public IWebElement CalibrationOverDueText { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CalibrationOverDueDateID)]
        public IWebElement CalibrationOverDueDate { get; set; }

        [FindsBy(How = How.Id, Using = Locators.NextCalenderYearID)]
        public IWebElement NextCalenderYear { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CurrentCalenderYearID)]
        public IWebElement CurrentCalenderYear { get; set; }

        [FindsBy(How = How.Id, Using = Locators.RightArrowID)]
        public IWebElement RightArrow { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LeftArrowID)]
        public IWebElement LeftArrow { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.CalenderXPath)]
        public IWebElement CalenderXP { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.HostContollerColumnXPath)]
        public IWebElement HostContollerColumn { get; set; }

        [FindsBy(How = How.Id, Using = Locators.HostControllerGraphicID)]
        public IWebElement HostControllerGraphic { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PreventiveMaintenanceLabelID)]
        public IWebElement PreventiveMaintenanceLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.HostControllerID)]
        public IWebElement HostController { get; set; }
    }
}
