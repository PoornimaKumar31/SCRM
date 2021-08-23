using FluentAssertions;
using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5714")]
    public sealed class Req5714Steps
    {

        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        RV700DeviceDetailsPage rv700DeviceDetailsPage = new RV700DeviceDetailsPage();

        private readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        private readonly ScenarioContext _scenarioContext;

        public Req5714Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"user is on Asset List page with more than one RV700")]
        public void GivenUserIsOnAssetListPageWithMoreThanOneRV()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title, "LNT Automated Eye Test Organization Facility Test1 Title");
            landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.Click();
            wait.Message = "Main page asset list is not displayed";
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.RV700DeviceName);
            //Wait till the data is loaded
            Thread.Sleep(1000);
            int deviceCount = mainPage.DeviceListRow.GetElementCount();
            deviceCount.Should().BeGreaterThan(0, "atleast one RV700 device should be present.");
        }

        [When(@"user clicks any RV700")]
        public void WhenUserClicksAnyRV()
        {
            mainPage.DeviceListRow[1].Click();
        }

        [Then(@"Asset Details landing page is displayed")]
        public void ThenAssetDetailsLandingPageIsDisplayed()
        {
            bool IsAssetDetailsPageDispalyed = (rv700DeviceDetailsPage.ComponentInformationTab.GetElementVisibility()) || (rv700DeviceDetailsPage.LogsTab.GetElementVisibility());
            Assert.IsTrue(IsAssetDetailsPageDispalyed,"Asset Details page is not displayed.");
        }

        [Then(@"Asset Detail summary subsection with Edit button is displayed")]
        public void ThenAssetDetailSummarySubsectionWithEditButtonIsDisplayed()
        {
            Assert.IsTrue(rv700DeviceDetailsPage.SummarySection.GetElementVisibility(),"Asset details summary section is not displayed.");
            Assert.IsTrue(rv700DeviceDetailsPage.EditButton.GetElementVisibility(), "Edit button is not displayed on asset details page.");
        }

        [Then(@"Component Information tab is displayed")]
        public void ThenComponentInformationTabIsDisplayed()
        {
            Assert.IsTrue(rv700DeviceDetailsPage.ComponentInformationTab.GetElementVisibility(), "Component information tab is not displayed.");
        }

        [Then(@"Logs tab is displayed")]
        public void ThenLogsTabIsDisplayed()
        {
            Assert.IsTrue(rv700DeviceDetailsPage.LogsTab.GetElementVisibility(), "Logs tab is not displayed.");
        }

        [Then(@"Asset Detail subsection is displayed")]
        public void ThenAssetDetailSubsectionIsDisplayed()
        {
            Assert.IsTrue(rv700DeviceDetailsPage.AssetDetailsSubSection.GetElementVisibility(),"Asset details subsection is not displayed.");
        }


        [Given(@"user is on Component details page for RV700 Serial number ""(.*)""")]
        public void GivenUserIsOnComponentDetailsPageForRVSerialNumber(string serailNumber)
        {
            //Loging-in
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title, "LNT Automated Eye Test Organization Facility Test1 Title");
            landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.Click();
            wait.Message = "Main page asset list is not displayed";
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.SearchSerialNumberAndClick(serailNumber);

            //Wait till data is loaded in device details page.
            Thread.Sleep(3000);

            //Checking if assert page is displayed
            bool IsAssetDetailsPageDispalyed = (rv700DeviceDetailsPage.ComponentInformationTab.GetElementVisibility()) || (rv700DeviceDetailsPage.LogsTab.GetElementVisibility());
            Assert.IsTrue(IsAssetDetailsPageDispalyed, "Asset Details page is not displayed.");
            
        }

        [Then(@"""(.*)"" is ""(.*)""")]
        public void ThenIs(string labelName, string Expectedvalue)
        {
            IWebElement webElement=null;
            switch(labelName.ToLower().Trim())
            {
                case "name":
                    webElement = rv700DeviceDetailsPage.DeviceName;
                    break;

                case "firmware version":
                    webElement = rv700DeviceDetailsPage.FirmwareVersion;
                    break;

                case "serial number":
                    webElement = rv700DeviceDetailsPage.SerialNumber;
                    break;

                default: Assert.Fail(labelName + " is a invalid label name.");
                    break;
            }
            Assert.IsTrue(webElement.GetElementVisibility(),labelName+" is not dispalyed.");
            Assert.AreEqual(Expectedvalue.ToLower().Trim(), webElement.Text.ToLower(), labelName+" is not matching the expected value.");
        }


        [Then(@"Radio ""(.*)"" is ""(.*)""")]
        public void ThenRadioIs(string labelName, string ExpectedValue)
        {
            IWebElement labelElement=null;
            switch(labelName.ToLower().Trim())
            {
                case "name":
                    labelElement = rv700DeviceDetailsPage.NewMarName;
                    break;

                case "firmware version":
                    labelElement = rv700DeviceDetailsPage.NewMarFirmwareVersion;
                    break;

                case "serial number":
                    labelElement = rv700DeviceDetailsPage.NewMarSerialNumber;
                    break;

                case "mac address":
                    labelElement = rv700DeviceDetailsPage.NewMarMACAddresValue;
                    break;

                case "ip address":
                    labelElement = rv700DeviceDetailsPage.NewMarIPAdressValue;
                    break;

                case "model number":
                    //model number element is not present
                    _scenarioContext.Pending();
                    break;
                case "rssi":
                    labelElement = rv700DeviceDetailsPage.NewMarRSSIValue;
                    break;

                case "guid":
                    labelElement = rv700DeviceDetailsPage.NewMarGUIDValue;
                    break;

                default: Assert.Fail(labelName + " is a invalid label name.");
                    break;
            }
            Assert.IsTrue(labelElement.GetElementVisibility(),labelName+" is not displayed.");
            Assert.AreEqual(ExpectedValue.ToLower().Trim(), labelElement.Text.ToLower(),labelName+" is not matching the expected value.");
        }

        [When(@"user clicks Newmar toggle arrow")]
        public void WhenUserClicksNewmarToggleArrow()
        {
            rv700DeviceDetailsPage.NewMarToggleArrow.Click();
        }

        [Then(@"Radio ""(.*)"" label is displayed")]
        public void ThenRadioLabelIsDisplayed(string labelName)
        {
            IWebElement labelElement = null;
            switch(labelName.ToLower().Trim())
            {
                case "mac address":
                    labelElement = rv700DeviceDetailsPage.NewMarMACAddressLabel;
                    break;
                case "ip address":
                    labelElement = rv700DeviceDetailsPage.NewMarIPAdressLabel;
                    break;
                case "model number":
                    //model number element is not present
                    _scenarioContext.Pending();
                    break;

                case "rssi":
                    labelElement = rv700DeviceDetailsPage.NewMarRSSILabel;
                    break;

                case "guid":
                    labelElement = rv700DeviceDetailsPage.NewMarGUIDLabel;
                    break;

                default: Assert.Fail(labelName + "is a invalid label name.");
                    break;
            }

            Assert.IsTrue(labelElement.GetElementVisibility(),labelName+" is not displayed.");
        }


        [Then(@"RV700 image is displayed")]
        public void ThenRVImageIsDisplayed()
        {
            Assert.IsTrue(rv700DeviceDetailsPage.RV700Image.GetElementVisibility(),"Rv700 image is not displayed.");
        }

        [Then(@"summary ""(.*)"" label is displayed")]
        public void ThenSummaryLabelIsDisplayed(string labelName)
        {
            IWebElement labelElement=null;
            switch(labelName.ToLower().Trim())
            {
                case "asset name":
                    labelElement = rv700DeviceDetailsPage.SummaryAssetNameLabel;
                    break;

                case "asset tag":
                    labelElement = rv700DeviceDetailsPage.SummaryAssetTagLabel;
                    break;

                case "serial number":
                    labelElement = rv700DeviceDetailsPage.SummarySerialNumberLabel;
                    break;
                case "ip address":
                    labelElement = rv700DeviceDetailsPage.SummaryIPAddressLabel;
                    break;
                case "model":
                    labelElement = rv700DeviceDetailsPage.SummaryModelNumberLabel;
                    break;
                case "radio mac address":
                    labelElement = rv700DeviceDetailsPage.SummaryRadioMACAddressLabel;
                    break;
                case "facility":
                    labelElement = rv700DeviceDetailsPage.SummaryFacilityLabel;
                    break;
                case "radio ip address":
                    labelElement = rv700DeviceDetailsPage.SummaryRadioIPAddressLabel;
                    break;
                case "location":
                    labelElement = rv700DeviceDetailsPage.SummaryLocationLabel;
                    break;
                case "connection status":
                    labelElement = rv700DeviceDetailsPage.SummaryLabelConnectionStatusLabel;
                    break;
                case "room/bed":
                    labelElement = rv700DeviceDetailsPage.SummaryRoomBedLabel;
                    break;
                case "last firmware deployed":
                    labelElement = rv700DeviceDetailsPage.SummaryLastFirmwareDeployedLabel;
                    break;
                case "last configuration deployed":
                    labelElement = rv700DeviceDetailsPage.SummaryLastConfigurationLabel;
                    break;

                default: Assert.Fail(labelName + " is a invalid label name.");
                    break;
            }
            Assert.IsTrue(labelElement.GetElementVisibility(), labelName+" label is not displayed.");
        }

        [Then(@"summary ""(.*)"" is ""(.*)""")]
        public void ThenSummaryIs(string labelName, string Expectedvalue)
        {
            IWebElement labelValueElement=null;
            switch(labelName.ToLower().Trim())
            {
                case "asset name":
                    labelValueElement = rv700DeviceDetailsPage.SummaryAssetNameValue;
                    break;
                case "serial number":
                    labelValueElement = rv700DeviceDetailsPage.SummarySerialNumberValue;
                    break;
                case "ip address":
                    labelValueElement = rv700DeviceDetailsPage.SummaryIPAddressValue;
                    break;
                case "model":
                    labelValueElement = rv700DeviceDetailsPage.SummaryModelValue;
                    break;
                case "radio mac address":
                    labelValueElement = rv700DeviceDetailsPage.SummaryRadioMACAddressValue;
                    break;
                case "facility":
                    labelValueElement = rv700DeviceDetailsPage.SummaryFacilityValue;
                    break;
                case "location":
                    labelValueElement = rv700DeviceDetailsPage.SummaryLocationValue;
                    break;
                case "connection status":
                    labelValueElement = rv700DeviceDetailsPage.SummaryConnectionStatusValue;
                    break;
                case "room/bed":
                    labelValueElement = rv700DeviceDetailsPage.SummaryRoomBedValue;
                    break;
                default: Assert.Fail(labelName + " is a invalid label name.");
                    break;
            }
            Assert.IsTrue(labelValueElement.GetElementVisibility(), labelName+" value is not displayed.");
            Assert.AreEqual(Expectedvalue.ToLower().Trim(), labelValueElement.Text.ToLower(),labelName+ " is not matching the expected value");
        }

        [Then(@"summary ""(.*)"" is blank")]
        public void ThenSummaryIsBlank(string labelName)
        {
            IWebElement labelElement = null;
            switch(labelName.ToLower().Trim())
            {
                case "asset tag":
                    labelElement = rv700DeviceDetailsPage.SummaryAssetTagValue;
                    break;
                case "radio ip address":
                    labelElement = rv700DeviceDetailsPage.SummaryRadioIPAddressValue;
                    break;
                case "last firmware deployed":
                    labelElement = rv700DeviceDetailsPage.SummaryLastFirmwareDeployedValue;
                    break;
                case "last configuration deployed":
                    labelElement = rv700DeviceDetailsPage.SummaryLastFirmwareDeployedValue;
                    break;
                default: Assert.Fail(labelName + " is a invalid label name.");
                    break;
            }
            Assert.AreEqual(0, labelElement.Text.Length,labelName+" value is not blank");
        }
    }
}
