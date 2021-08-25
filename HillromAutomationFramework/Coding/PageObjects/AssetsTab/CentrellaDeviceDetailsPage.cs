using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HillromAutomationFramework.Coding.PageObjects.AssetsTab
{
    class CentrellaDeviceDetailsPage
    {
        public CentrellaDeviceDetailsPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        public class Locators
        {
            public const string ErrorCodeTabXPath = "//div[@class = 'mat-tab-list']/div/div[1]";
            public const string PreventiveMaintenanceTabXPath = "//div[@class = 'mat-tab-list']/div/div[2]";
            public const string NoErrorReportedLabelXPath = "//div[@id = 'centrella-errorcode-details']/div[2]";
            public const string ReferenceButtonID = "btn_reference";
            public const string SaverityColumnHeadingID = "severity";
            public const string TimeStampColumnHeadingID = "time_stamp";
            public const string CodeColumnHeadingID = "code";
            public const string DescriptionColumnHeadingID = "description";
            public const string ColumnHeadingElementsXPath = "//div[@id = 'severity']/parent::div/div";
            public const string ErrorRowExpenstionArrowXPath = "//div[@id ='error0']/div/img";
           
        }

        [FindsBy(How = How.XPath, Using = Locators.ErrorRowExpenstionArrowXPath)]
        public IWebElement ErrorRowExpenstionArrow { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.ColumnHeadingElementsXPath)]
        public IList<IWebElement> ColumnHeadingElements { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SaverityColumnHeadingID)]
        public IWebElement SaverityColumnHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.TimeStampColumnHeadingID)]
        public IWebElement TimeStampColumnHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CodeColumnHeadingID)]
        public IWebElement CodeColumnHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DescriptionColumnHeadingID)]
        public IWebElement DescriptionColumnHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ReferenceButtonID)]
        public IWebElement ReferenceButton { get; set; }


        [FindsBy(How = How.XPath, Using = Locators.ErrorCodeTabXPath)]
        public IWebElement ErrorCodeTab { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.PreventiveMaintenanceTabXPath)]
        public IWebElement PreventiveMaintenanceTab { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.NoErrorReportedLabelXPath)]
        public IWebElement NoErrorReportedLabel { get; set; }
    }
}
