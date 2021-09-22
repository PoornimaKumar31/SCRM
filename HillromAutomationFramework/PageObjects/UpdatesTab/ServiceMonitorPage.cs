using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HillromAutomationFramework.PageObjects
{
    public class ServiceMonitorPage
    {
        public static class Locators
        {
            public const string AssetTypeDropDownID = "modelFilter";
            public const string ServiceMoniterLabelID = "lbl_service_monitor";
            public const string CallHomePeroidLabelID = "lbl_call_home_period";
            public const string CallHomePeriodDropDownID = "callHomePeriod";
            public const string DeploymentModeLabelID = "lbl_deploy_mode";
            public const string DeploymentModeDropDownID = "deploymentMode";
            public const string DestinationLabelXpath = "//*[@id=\"configure-items\"]/div[2]/div/div/div[1]/span";
            public const string LocationHierarchySelectorsID = "caret0";

            //table elements
            public const string TableHeadingXpath= "//*[@id=\"configure-items\"]/div[3]/div[2]";
            public const string SelectAllCheckBoxID = "selectall";
            public const string SerialNumHeadingID = "SNo";
            public const string CallHomePeriodHeadingID = "CallHome";
            public const string DeploymentModeHeadingID = "DeployMode";
            public const string LocationHeadingID = "Location";
            public const string LastFilesDeployedHeadingID = "FileDeploy";
            public const string FirstDeviceCheckBoxID = "checkbox-0";

            public const string PreviousButtonID = "previous-btn";
            public const string DeployButtonID = "deploy";
            public const string PaginationXofYXpath = "//div[@class='config-pagecount']//span[2]";
            public const string PaginationPreviousButtonXpath = "//span[@id='previous']";
            public const string PaginationNextButtonID = "next";
            public const string PaginationDisplayXofYClassName = "dataTables_info";
            public const string DestinationDeviceCountClassName = "showCount";
            public const string UpdateMessageXpath= "//*[@id=\"cdk-overlay-0\"]/snack-bar-container";
        }

        public ServiceMonitorPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = Locators.AssetTypeDropDownID)]
        public IWebElement AssetTypeDropDown { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ServiceMoniterLabelID)]
        public IWebElement ServiceMoniterLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CallHomePeroidLabelID)]
        public IWebElement CallHomePeroidLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CallHomePeriodDropDownID)]
        public IWebElement CallHomePeriodDropDown { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeploymentModeLabelID)]
        public IWebElement DeploymentModeLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeploymentModeDropDownID)]
        public IWebElement DeploymentModeDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.DestinationLabelXpath)]
        public IWebElement DestinationLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LocationHierarchySelectorsID)]
        public IWebElement LocationHierarchySelectors { get; set; }

        //table elements
        [FindsBy(How = How.XPath, Using = Locators.TableHeadingXpath)]
        public IWebElement TableHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SelectAllCheckBoxID)]
        public IWebElement SelectAllCheckBox { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SerialNumHeadingID)]
        public IWebElement SerialNumHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CallHomePeriodHeadingID)]
        public IWebElement CallHomePeriodHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeploymentModeHeadingID)]
        public IWebElement DeploymentModeHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LocationHeadingID)]
        public IWebElement LocationHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LastFilesDeployedHeadingID)]
        public IWebElement LastFilesDeployedHeading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.FirstDeviceCheckBoxID)]
        public IWebElement FirstDeviceCheckBox { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PreviousButtonID)]
        public IWebElement PreviousButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeployButtonID)]
        public IWebElement DeployButton { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.PaginationXofYXpath)]
        public IWebElement PaginationXofY { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.PaginationDisplayXofYClassName)]
        public IWebElement PaginationDisplayXofY { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.PaginationPreviousButtonXpath)]
        public IWebElement PaginationPreviousButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PaginationNextButtonID)]
        public IWebElement PaginationNextButton { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.DestinationDeviceCountClassName)]
        public IWebElement DestinationDeviceCount { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.UpdateMessageXpath)]
        public IWebElement UpdateMessage { get; set; }
    }
}
