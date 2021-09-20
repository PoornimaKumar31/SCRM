using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AssetsTab;
using HillromAutomationFramework.PageObjects.AssetsTab.ComponentInformation;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.AssetsTab.ComponentInformation
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5714")]
    public sealed class Req5714Steps
    {

        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly RV700AssetListPage _rv700AssetListPage;

        private readonly WebDriverWait _wait;
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public Req5714Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
            _rv700AssetListPage = new RV700AssetListPage(driver);
        }

        [Given(@"user is on Asset List page with more than one RV700")]
        public void GivenUserIsOnAssetListPageWithMoreThanOneRV()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(_landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title, _driver,"LNT Automated Eye Test Organization Facility Test1 Title");
            _landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.Click();
            _wait.Message = "Main page asset list is not displayed";
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.AssetTypeDropDown.SelectDDL(MainPageExpectedValue.RV700DeviceName);
            //Wait till the data is loaded
            Thread.Sleep(1000);
            int deviceCount = _mainPage.DeviceListRow.GetElementCount();
            deviceCount.Should().BeGreaterThan(0, "atleast one RV700 device should be present.");
        }

        [When(@"user clicks any RV700")]
        public void WhenUserClicksAnyRV()
        {
            _mainPage.DeviceListRow[1].Click();
        }

        [Then(@"Asset Details landing page is displayed")]
        public void ThenAssetDetailsLandingPageIsDisplayed()
        {
            bool IsAssetDetailsPageDispalyed = (_rv700AssetListPage.ComponentInformationTab.GetElementVisibility());
            IsAssetDetailsPageDispalyed.Should().BeTrue("Asset Details page is not displayed.");
        }

        [Then(@"Asset Detail summary subsection with Edit button is displayed")]
        public void ThenAssetDetailSummarySubsectionWithEditButtonIsDisplayed()
        {
            _rv700AssetListPage.SummarySection.GetElementVisibility().Should().BeTrue("Asset details summary section is not displayed.");
            _rv700AssetListPage.EditButton.GetElementVisibility().Should().BeTrue( "Edit button is not displayed on asset details page.");
        }

        [Then(@"Component Information tab is displayed")]
        public void ThenComponentInformationTabIsDisplayed()
        {
            _rv700AssetListPage.ComponentInformationTab.GetElementVisibility().Should().BeTrue( "Component information tab is not displayed.");
        }

        [Then(@"Logs tab is displayed")]
        public void ThenLogsTabIsDisplayed()
        {
            _rv700AssetListPage.LogsTab.GetElementVisibility().Should().BeTrue( "Logs tab is not displayed.");
        }

        [Then(@"Asset Detail subsection is displayed")]
        public void ThenAssetDetailSubsectionIsDisplayed()
        {
            _rv700AssetListPage.AssetDetailsSubSection.GetElementVisibility().Should().BeTrue("Asset details subsection is not displayed.");
        }


        [Given(@"user is on Component details page for RV700 Serial number ""(.*)""")]
        public void GivenUserIsOnComponentDetailsPageForRVSerialNumber(string serailNumber)
        {
            //Loging-in
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(_landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title,_driver, "LNT Automated Eye Test Organization Facility Test1 Title");
            _landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.Click();
            _wait.Message = "Main page asset list is not displayed";
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.SearchSerialNumberAndClick(serailNumber);

            //Wait till data is loaded in device details page.
            Thread.Sleep(3000);

            //Checking if assert page is displayed
            bool IsAssetDetailsPageDispalyed = (_rv700AssetListPage.ComponentInformationTab.GetElementVisibility()) || (_rv700AssetListPage.LogsTab.GetElementVisibility());
            IsAssetDetailsPageDispalyed.Should().BeTrue("Asset Details page is not displayed.");
            
        }

        [Then(@"""(.*)"" is ""(.*)""")]
        public void ThenIs(string labelName, string Expectedvalue)
        {
            IWebElement webElement=null;
            switch(labelName.ToLower().Trim())
            {
                case "name":
                    webElement = _rv700AssetListPage.DeviceName;
                    break;

                case "firmware version":
                    webElement = _rv700AssetListPage.FirmwareVersion;
                    break;

                case "serial number":
                    webElement = _rv700AssetListPage.SerialNumber;
                    break;

                default: Assert.Fail(labelName + " is a invalid label name.");
                    break;
            }
            webElement.GetElementVisibility().Should().BeTrue(labelName+" is not dispalyed.");
            webElement.Text.ToLower().Should().BeEquivalentTo(Expectedvalue.ToLower().Trim(), labelName +" is not matching the expected value.");
        }


        [Then(@"Radio ""(.*)"" is ""(.*)""")]
        public void ThenRadioIs(string labelName, string ExpectedValue)
        {
            IWebElement labelElement=null;
            switch(labelName.ToLower().Trim())
            {
                case "name":
                    labelElement = _rv700AssetListPage.NewMarName;
                    break;

                case "firmware version":
                    labelElement = _rv700AssetListPage.NewMarFirmwareVersion;
                    break;

                case "serial number":
                    labelElement = _rv700AssetListPage.NewMarSerialNumber;
                    break;

                case "mac address":
                    labelElement = _rv700AssetListPage.NewMarMACAddresValue;
                    break;

                case "ip address":
                    labelElement = _rv700AssetListPage.NewMarIPAdressValue;
                    break;

                case "rssi":
                    labelElement = _rv700AssetListPage.NewMarRSSIValue;
                    break;

                case "guid":
                    labelElement = _rv700AssetListPage.NewMarGUIDValue;
                    break;

                default: Assert.Fail(labelName + " is a invalid label name.");
                    break;
            }
            labelElement.GetElementVisibility().Should().BeTrue(labelName+" is not displayed.");
            labelElement.Text.ToLower().Should().BeEquivalentTo(ExpectedValue.ToLower().Trim(), labelName+" is not matching the expected value.");
        }

        [When(@"user clicks Newmar toggle arrow")]
        public void WhenUserClicksNewmarToggleArrow()
        {
            _rv700AssetListPage.NewMarToggleArrow.Click();
        }

        [Then(@"Radio ""(.*)"" label is displayed")]
        public void ThenRadioLabelIsDisplayed(string labelName)
        {
            IWebElement labelElement = null;
            switch(labelName.ToLower().Trim())
            {
                case "mac address":
                    labelElement = _rv700AssetListPage.NewMarMACAddressLabel;
                    break;
                case "ip address":
                    labelElement = _rv700AssetListPage.NewMarIPAdressLabel;
                    break;

                case "rssi":
                    labelElement = _rv700AssetListPage.NewMarRSSILabel;
                    break;

                case "guid":
                    labelElement = _rv700AssetListPage.NewMarGUIDLabel;
                    break;

                default: Assert.Fail(labelName + "is a invalid label name.");
                    break;
            }

            labelElement.GetElementVisibility().Should().BeTrue(labelName+" is not displayed.");
        }


        [Then(@"RV700 image is displayed")]
        public void ThenRVImageIsDisplayed()
        {
            _rv700AssetListPage.RV700Image.GetElementVisibility().Should().BeTrue("Rv700 image is not displayed.");
        }

        [Then(@"summary ""(.*)"" label is displayed")]
        public void ThenSummaryLabelIsDisplayed(string labelName)
        {
            IWebElement labelElement=null;
            switch(labelName.ToLower().Trim())
            {
                case "asset name":
                    labelElement = _rv700AssetListPage.SummaryAssetNameLabel;
                    break;

                case "asset tag":
                    labelElement = _rv700AssetListPage.SummaryAssetTagLabel;
                    break;

                case "serial number":
                    labelElement = _rv700AssetListPage.SummarySerialNumberLabel;
                    break;
                case "ip address":
                    labelElement = _rv700AssetListPage.SummaryIPAddressLabel;
                    break;
                case "model":
                    labelElement = _rv700AssetListPage.SummaryModelNumberLabel;
                    break;
                case "radio mac address":
                    labelElement = _rv700AssetListPage.SummaryRadioMACAddressLabel;
                    break;
                case "facility":
                    labelElement = _rv700AssetListPage.SummaryFacilityLabel;
                    break;
                case "radio ip address":
                    labelElement = _rv700AssetListPage.SummaryRadioIPAddressLabel;
                    break;
                case "location":
                    labelElement = _rv700AssetListPage.SummaryLocationLabel;
                    break;
                case "connection status":
                    labelElement = _rv700AssetListPage.SummaryLabelConnectionStatusLabel;
                    break;
                case "room/bed":
                    labelElement = _rv700AssetListPage.SummaryRoomBedLabel;
                    break;
                case "last firmware deployed":
                    labelElement = _rv700AssetListPage.SummaryLastFirmwareDeployedLabel;
                    break;
                case "last configuration deployed":
                    labelElement = _rv700AssetListPage.SummaryLastConfigurationLabel;
                    break;

                default: Assert.Fail(labelName + " is a invalid label name.");
                    break;
            }
            labelElement.GetElementVisibility().Should().BeTrue( labelName+" label is not displayed.");
        }

        [Then(@"summary ""(.*)"" is ""(.*)""")]
        public void ThenSummaryIs(string labelName, string Expectedvalue)
        {
            IWebElement labelValueElement=null;
            switch(labelName.ToLower().Trim())
            {
                case "asset name":
                    labelValueElement = _rv700AssetListPage.SummaryAssetNameValue;
                    break;
                case "serial number":
                    labelValueElement = _rv700AssetListPage.SummarySerialNumberValue;
                    break;
                case "ip address":
                    labelValueElement = _rv700AssetListPage.SummaryIPAddressValue;
                    break;
                case "model":
                    labelValueElement = _rv700AssetListPage.SummaryModelValue;
                    break;
                case "radio mac address":
                    labelValueElement = _rv700AssetListPage.SummaryRadioMACAddressValue;
                    break;
                case "facility":
                    labelValueElement = _rv700AssetListPage.SummaryFacilityValue;
                    break;
                case "location":
                    labelValueElement = _rv700AssetListPage.SummaryLocationValue;
                    break;
                case "room/bed":
                    labelValueElement = _rv700AssetListPage.SummaryRoomBedValue;
                    break;
                default: Assert.Fail(labelName + " is a invalid label name.");
                    break;
            }
            labelValueElement.GetElementVisibility().Should().BeTrue( labelName+" value is not displayed.");
            labelValueElement.Text.ToLower().Should().BeEquivalentTo(Expectedvalue.ToLower().Trim(), labelName+ " is not matching the expected value");
        }

        [Then(@"summary ""(.*)"" is blank")]
        public void ThenSummaryIsBlank(string labelName)
        {
            IWebElement labelElement = null;
            switch(labelName.ToLower().Trim())
            {
                case "asset tag":
                    labelElement = _rv700AssetListPage.SummaryAssetTagValue;
                    break;
                case "radio ip address":
                    labelElement = _rv700AssetListPage.SummaryRadioIPAddressValue;
                    break;
                case "last firmware deployed":
                    labelElement = _rv700AssetListPage.SummaryLastFirmwareDeployedValue;
                    break;
                case "last configuration deployed":
                    labelElement = _rv700AssetListPage.SummaryLastFirmwareDeployedValue;
                    break;
                default: Assert.Fail(labelName + " is a invalid label name.");
                    break;
            }
            labelElement.Text.Length.Should().Be(0,labelName+" value is not blank");
        }
    }
}
