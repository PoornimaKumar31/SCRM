using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AssetsTab;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.AssetsTab.DeviceDetails
{
    [Binding, Scope(Tag = "UISID_8674")]
    class UIS8674Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly CentrellaDeviceDetailsPage _centrellaDeviceDetailsPage;

        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;


        public UIS8674Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
            _centrellaDeviceDetailsPage = new CentrellaDeviceDetailsPage(driver);

        }


        [Given(@"manager user is on device details page for Centrella Serial number ""(.*)""")]
        public void GivenManagerUserIsOnDeviceDetailsPageForCentrellaSerialNumber(string serialNumber)
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(_landingPage.PSSServiceOrganizationFacilityBatesville, _driver, "Centrella Orgaization");
            _landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.SearchSerialNumberAndClick(serialNumber);
        }

        [When(@"user clicks Locate Asset button")]
        public void WhenUserClicksLocateAssetButton()
        {
            _centrellaDeviceDetailsPage.CentrellaLocateAssetButton.Click();
        }

        [Then(@"Locate Asset pop-up dialog is displayed")]
        public void ThenLocateAssetPop_UpDialogIsDisplayed()
        {
            _wait.Until(ExplicitWait.ElementIsVisible(By.XPath(CentrellaDeviceDetailsPage.Locators.APMappingLocateAssetPopupDialogXPath)));
            _centrellaDeviceDetailsPage.APMappingLocateAssetPopupDialog.GetElementVisibility().Should().BeTrue("Dialog box is not displayed");
        }

        [Then(@"""(.*)"" label and value is ""(.*)""")]
        public void ThenLabelAndValueIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "source":
                    ActualValue = _centrellaDeviceDetailsPage.APMappingSourceLabelValue.Text;
                    break;
                case "mac address":
                    ActualValue = _centrellaDeviceDetailsPage.APMappingMacAddressLabelValue.Text;
                    break;
                case "rssi":
                    ActualValue = _centrellaDeviceDetailsPage.APMappingRSSILabelValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }

            ActualValue.Should().Equals(ExpectedValue);
        }

        [Then(@"Add AP Mapping button is displayed")]
        public void ThenAddAPMappingButtonIsDisplayed()
        {
            _centrellaDeviceDetailsPage.APMappingAddAPMappingButton.GetElementVisibility().Should().BeTrue("Add AP Mapping Button is not displayed");
        }

        [Then(@"Close button is displayed")]
        public void ThenCloseButtonIsDisplayed()
        {
            _centrellaDeviceDetailsPage.APMappingCloseButton.GetElementVisibility().Should().BeTrue("Close Button is not displayed");
        }

        [Then(@"Edit AP Mapping button is displayed")]
        public void ThenEditAPMappingButtonIsDisplayed()
        {
            _centrellaDeviceDetailsPage.APMappingEditAPMappingButton.GetElementVisibility().Should().BeTrue("Edit AP Mapping Button is not displayed");
        }

        [Given(@"regular user is on device details page for Centrella Serial number ""(.*)""")]
        public void GivenRegularUserIsOnDeviceDetailsPageForCentrellaSerialNumber(string serialNumber)
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.StandardUserWithoutRollUpPage);
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.SearchSerialNumberAndClick(serialNumber);
        }

        [Then(@"Edit AP Mapping button is not displayed")]
        public void ThenEditAPMappingButtonIsNotDisplayed()
        {
            _centrellaDeviceDetailsPage.APMappingEditAPMappingButton.GetElementVisibility().Should().BeFalse("Edit AP Mapping Button is displayed");
        }

        [Then(@"Add AP Mapping button is not displayed")]
        public void ThenAddAPMappingButtonIsNotDisplayed()
        {
            _centrellaDeviceDetailsPage.APMappingAddAPMappingButton.GetElementVisibility().Should().BeFalse("Add AP Mapping Button is displayed");
        }

        [Given(@"manager user is on Locate Asset pop-up dialog for Centrella Serial number ""(.*)""")]
        public void GivenManagerUserIsOnLocateAssetPop_UpDialogForCentrellaSerialNumber(string serialNumber)
        {
            GivenManagerUserIsOnDeviceDetailsPageForCentrellaSerialNumber(serialNumber);
            WhenUserClicksLocateAssetButton();
            ThenLocateAssetPop_UpDialogIsDisplayed();
        }


        [Given(@"regular user is on Locate Asset pop-up dialog for Centrella Serial number ""(.*)""")]
        public void GivenRegularUserIsOnLocateAssetPop_UpDialogForCentrellaSerialNumber(string serialNumber)
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.StandardUserWithoutRollUpPage);
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.SearchSerialNumberAndClick(serialNumber);
            WhenUserClicksLocateAssetButton();
            ThenLocateAssetPop_UpDialogIsDisplayed();
        }



        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string columnName)
        {
            bool ActualValue = false;

            switch (columnName.ToLower().Trim())
            {
                case "campus":
                    ActualValue = _centrellaDeviceDetailsPage.APMappingCampusColumnHeading.GetElementVisibility();
                    break;

                case "building":
                    ActualValue = _centrellaDeviceDetailsPage.APMappingBuildingColumnHeading.GetElementVisibility();
                    break;

                case "floor":
                    ActualValue = _centrellaDeviceDetailsPage.APMappingFloorColumnHeading.GetElementVisibility();
                    break;

                case "ap location":
                    ActualValue = _centrellaDeviceDetailsPage.APMappingAPLocationColumnHeading.GetElementVisibility();
                    break;

                default:
                    Assert.Fail(columnName + " is Invalid");
                    break;
            }

            ActualValue.Should().BeTrue();
        }

        [Then(@"value in ""(.*)"" column is ""(.*)""")]
        public void ThenValueInColumnIs(string columnName, string ExpectedValue)
        {
            string ActualValue = null;

            switch (columnName.ToLower().Trim())
            {
                case "campus":
                    ActualValue = _centrellaDeviceDetailsPage.APMappingCampusColumnHeading.Text;
                    break;

                case "building":
                    ActualValue = _centrellaDeviceDetailsPage.APMappingBuildingColumnHeading.Text;
                    break;

                case "floor":
                    ActualValue = _centrellaDeviceDetailsPage.APMappingFloorColumnHeading.Text;
                    break;

                case "ap location":
                    ActualValue = _centrellaDeviceDetailsPage.APMappingAPLocationColumnHeading.Text;
                    break;

                default:
                    Assert.Fail(columnName + " is Invalid");
                    break;
            }

            ActualValue.Should().Equals(ExpectedValue);
        }

        [When(@"user clicks Add AP mapping button")]
        public void WhenUserClicksAddAPMappingButton()
        {
            _centrellaDeviceDetailsPage.APMappingAddAPMappingButton.Click();
        }

        [Then(@"""(.*)"" entry field with ""(.*)"" hint text is displayed")]
        public void ThenEntryFieldWithHintTextIsDisplayed(string textBoxName, string ExpectedHintText)
        {
            string ActualValue = null;

            switch (textBoxName.ToLower().Trim())
            {
                case "campus":
                    _centrellaDeviceDetailsPage.APMappingCampusTextBox.GetElementVisibility().Should().BeTrue(textBoxName+ " is not displayed");
                    ActualValue = _centrellaDeviceDetailsPage.APMappingCampusTextBox.GetAttribute("placeholder");
                    break;

                case "building":
                    _centrellaDeviceDetailsPage.APMappingBuildingTextBox.GetElementVisibility().Should().BeTrue(textBoxName + " is not displayed");
                    ActualValue = _centrellaDeviceDetailsPage.APMappingBuildingTextBox.GetAttribute("placeholder");
                    break;

                case "floor":
                    _centrellaDeviceDetailsPage.APMappingFloorTextBox.GetElementVisibility().Should().BeTrue(textBoxName + " is not displayed");
                    ActualValue = _centrellaDeviceDetailsPage.APMappingFloorTextBox.GetAttribute("placeholder");
                    break;

                case "ap location":
                    _centrellaDeviceDetailsPage.APMappingAPLocationTextBox.GetElementVisibility().Should().BeTrue(textBoxName + " is not displayed");
                    ActualValue = _centrellaDeviceDetailsPage.APMappingAPLocationTextBox.GetAttribute("placeholder");
                    break;

                default:
                    Assert.Fail(textBoxName + " is Invalid");
                    break;
            }

            ActualValue.Should().Equals(ExpectedHintText);
        }


        [Then(@"Save button is displayed")]
        public void ThenSaveButtonIsDisplayed()
        {
            _centrellaDeviceDetailsPage.APMappingSaveButton.GetElementVisibility().Should().BeTrue("Save Button is not displayed");
        }

        [When(@"user clicks Edit AP mapping button")]
        public void WhenUserClicksEditAPMappingButton()
        {
            _centrellaDeviceDetailsPage.APMappingEditAPMappingButton.Click();
        }

        [Then(@"""(.*)"" entry field with ""(.*)"" value is displayed")]
        public void ThenEntryFieldWithValueIsDisplayed(string textBoxName, string ExpectedValue)
        {
            string ActualValue = null;

            switch (textBoxName.ToLower().Trim())
            {
                case "campus":
                    _centrellaDeviceDetailsPage.APMappingCampusTextBox.GetElementVisibility().Should().BeTrue(textBoxName + " is not displayed");
                    ActualValue = _centrellaDeviceDetailsPage.APMappingCampusTextBox.GetAttribute("value");
                    break;

                case "building":
                    _centrellaDeviceDetailsPage.APMappingBuildingTextBox.GetElementVisibility().Should().BeTrue(textBoxName + " is not displayed");
                    ActualValue = _centrellaDeviceDetailsPage.APMappingBuildingTextBox.GetAttribute("value");
                    break;

                case "floor":
                    _centrellaDeviceDetailsPage.APMappingFloorTextBox.GetElementVisibility().Should().BeTrue(textBoxName + " is not displayed");
                    ActualValue = _centrellaDeviceDetailsPage.APMappingFloorTextBox.GetAttribute("value");
                    break;

                case "ap location":
                    _centrellaDeviceDetailsPage.APMappingAPLocationTextBox.GetElementVisibility().Should().BeTrue(textBoxName + " is not displayed");
                    ActualValue = _centrellaDeviceDetailsPage.APMappingAPLocationTextBox.GetAttribute("value");
                    break;

                default:
                    Assert.Fail(textBoxName + " is Invalid");
                    break;
            }

            ActualValue.Should().Equals(ExpectedValue);
        }


    }
}
