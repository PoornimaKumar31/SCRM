using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HillromAutomationFramework.Coding.PageObjects
{
    class UpdatesSelectUpdateTab
    {
        public static class Locators
        {
            public const string HeadingID = "select_update";
            public const string AssetTypeLabelID = "lbl_asset_type";
            public const string AssetTypeDropDownID = "modelFilter";
            public const string UpgradeTypeLabelID = "lbl_update_type";
            public const string UpgradeTypeDropDownID = "typeFilter";

            public const string ConfigListClassName = "config-list";
            public const string NameColumnHeadingID = "config-heading-name";
            public const string DateColumnHeadingID = "config-heading-date";
            public const string FirstConfigFileID = "cvsm_config0";
            public const string NextButtonID = "nextbtn";
            public const string DeleteButtonID = "delete";
            public const string ConfigFileNameID = "name";
            public const string ConfigFileNameListID = "name";
        }
        public static class ExpectedValues
        {

        }

        public UpdatesSelectUpdateTab()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        [FindsBy(How = How.Id, Using = Locators.HeadingID)]
        public IWebElement Heading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.AssetTypeLabelID)]
        public IWebElement AssetTypeLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.AssetTypeDropDownID)]
        public IWebElement AssetTypeDropDown { get; set; }

        [FindsBy(How = How.Id, Using = Locators.UpgradeTypeLabelID)]
        public IWebElement UpgradeTypeLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.UpgradeTypeDropDownID)]
        public IWebElement UpgradeTypeDropDown { get; set; }

    }
}
