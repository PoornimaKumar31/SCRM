using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HillromAutomationFramework.Coding.PageObjects
{
    public class ServiceMoniterPage
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

            public const string PreviousButtonXpath = "/html/body/c8y-bootstrap/div/div[2]/div/c8y-hillrom-home-page/c8y-hillrom-landing-page/div/div/div[2]/c8y-hillrom-configure-service-monitor-deployment/div/div/div[5]/div/button[1]";
            public const string DeployButtonID = "deploy";
            public const string PaginationXofYID = "pagination";
            public const string PaginationPreviousButtonXpath = "/html/body/c8y-bootstrap/div/div[2]/div/c8y-hillrom-home-page/c8y-hillrom-landing-page/div/div/div[2]/c8y-hillrom-configure-service-monitor-deployment/div/div/div[3]/div[3]/div[6]/div[2]/span[1]";
            public const string PaginationNextButtonID = "next";
            public const string PaginationDisplayXofYClassName = "dataTables_info";
            public const string DestinalitioDeviceCountClassName = "showCount";
            public const string UpdateMessageXpath= "//*[@id=\"cdk-overlay-0\"]/snack-bar-container";
        }

        public static class Inputs
        {
            public const string ServiceMoniterText = "Service Monitor";
        }

        public static class ExpectedValues
        {
            public const string ServiceMoniterLabel = "Service Monitor Settings";
            public const string CallHomePeriodLabel = "Call home Period";
            public const string DeploymentModeLabel = "Deployment mode";
            public const string DestinationLabel = "DESTINATIONS";

            //Call home period drop down option
            public const string CallHomePeriodDropdownOptionP1D = "P1D (24 HOURS)";
            public const string CallHomePeriodDropdownOptionPT8H = "PT8H (8 HOURS)";
            public const string CallHomePeriodDropdownOptionPT4H = "PT4H (4 HOURS)";
            public const string CallHomePeriodDropdownOptionPT15M = "PT15M (15 MINUTES)";

            //Deployment mode dropdown option
            public const string DeploymentModeDropdownOptionTrue = "TRUE";
            public const string DeploymentModeDropdownOptionFalse = "FALSE";

            public const string DestinationNoDeviceCountText = "0 devices in 0 locations";
            public const string Destination1DeviceCountText = "1 devices in 1 locations";

            //table elements
            public const string SerialNumHeadingText = "Serial Number";
            public const string CallHomePeriodHeadingText = "Call Home Period";
            public const string DeploymentModeHeadingText = "Deployment Mode";
            public const string LocationHeadingText = "Location";
            public const string LastFilesDeployedHeadingText = "Last Files Deployed";
        }

        public ServiceMoniterPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);   
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

        [FindsBy(How = How.XPath, Using = Locators.PreviousButtonXpath)]
        public IWebElement PreviousButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeployButtonID)]
        public IWebElement DeployButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PaginationXofYID)]
        public IWebElement PaginationXofY { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.PaginationDisplayXofYClassName)]
        public IWebElement PaginationDisplayXofY { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.PaginationPreviousButtonXpath)]
        public IWebElement PaginationPreviousButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PaginationNextButtonID)]
        public IWebElement PaginationNextButton { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.DestinalitioDeviceCountClassName)]
        public IWebElement DestinalitioDeviceCount { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.UpdateMessageXpath)]
        public IWebElement UpdateMessage { get; set; }
    }
}
