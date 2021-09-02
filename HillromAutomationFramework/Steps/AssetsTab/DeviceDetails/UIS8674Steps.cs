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
        MainPage mainPage = new MainPage();
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        CentrellaDeviceDetailsPage centrellaDeviceDetailsPage = new CentrellaDeviceDetailsPage();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

        [Given(@"manager user is on device details page for Centrella Serial number ""(.*)""")]
        public void GivenManagerUserIsOnDeviceDetailsPageForCentrellaSerialNumber(string serialNumber)
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(landingPage.PSSServiceOrganizationFacilityBatesville, "Centrella Orgaization");
            landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.SearchSerialNumberAndClick(serialNumber);
        }

        [When(@"user clicks Locate Asset button")]
        public void WhenUserClicksLocateAssetButton()
        {
            centrellaDeviceDetailsPage.CentrellaLocateAssetButton.Click();
        }

        [Then(@"Locate Asset pop-up dialog is displayed")]
        public void ThenLocateAssetPop_UpDialogIsDisplayed()
        {
            wait.Until(ExplicitWait.ElementIsVisible(By.XPath(CentrellaDeviceDetailsPage.Locators.APMappingLocateAssetPopupDialogXPath)));
            centrellaDeviceDetailsPage.APMappingLocateAssetPopupDialog.GetElementVisibility().Should().BeTrue("Dialog box is not displayed");
        }

        [Then(@"""(.*)"" label and value is ""(.*)""")]
        public void ThenLabelAndValueIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "source":
                    ActualValue = centrellaDeviceDetailsPage.APMappingSourceLabelValue.Text;
                    break;
                case "mac address":
                    ActualValue = centrellaDeviceDetailsPage.APMappingMacAddressLabelValue.Text;
                    break;
                case "rssi":
                    ActualValue = centrellaDeviceDetailsPage.APMappingRSSILabelValue.Text;
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
            centrellaDeviceDetailsPage.APMappingAddAPMappingButton.GetElementVisibility().Should().BeTrue("Add AP Mapping Button is not displayed");
        }

        [Then(@"Close button is displayed")]
        public void ThenCloseButtonIsDisplayed()
        {
            centrellaDeviceDetailsPage.APMappingCloseButton.GetElementVisibility().Should().BeTrue("Close Button is not displayed");
        }

        [Then(@"Edit AP Mapping button is displayed")]
        public void ThenEditAPMappingButtonIsDisplayed()
        {
            centrellaDeviceDetailsPage.APMappingEditAPMappingButton.GetElementVisibility().Should().BeTrue("Edit AP Mapping Button is not displayed");
        }

        [Given(@"regular user is on device details page for Centrella Serial number ""(.*)""")]
        public void GivenRegularUserIsOnDeviceDetailsPageForCentrellaSerialNumber(string serialNumber)
        {
            loginPage.LogIn(LoginPage.LogInType.StandardUserWithoutRollUpPage);
            wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.SearchSerialNumberAndClick(serialNumber);
        }

        [Then(@"Edit AP Mapping button is not displayed")]
        public void ThenEditAPMappingButtonIsNotDisplayed()
        {
            centrellaDeviceDetailsPage.APMappingEditAPMappingButton.GetElementVisibility().Should().BeFalse("Edit AP Mapping Button is displayed");
        }

        [Then(@"Add AP Mapping button is not displayed")]
        public void ThenAddAPMappingButtonIsNotDisplayed()
        {
            centrellaDeviceDetailsPage.APMappingAddAPMappingButton.GetElementVisibility().Should().BeFalse("Add AP Mapping Button is displayed");
        }

        [Given(@"manager user is on Locate Asset pop-up dialog for Centrella Serial number ""(.*)""")]
        public void GivenManagerUserIsOnLocateAssetPop_UpDialogForCentrellaSerialNumber(string serialNumber)
        {
            GivenManagerUserIsOnDeviceDetailsPageForCentrellaSerialNumber(serialNumber);
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
                    ActualValue = centrellaDeviceDetailsPage.APMappingCampusColumnHeading.GetElementVisibility();
                    break;

                case "building":
                    ActualValue = centrellaDeviceDetailsPage.APMappingBuildingColumnHeading.GetElementVisibility();
                    break;

                case "floor":
                    ActualValue = centrellaDeviceDetailsPage.APMappingFloorColumnHeading.GetElementVisibility();
                    break;

                case "ap location":
                    ActualValue = centrellaDeviceDetailsPage.APMappingAPLocationColumnHeading.GetElementVisibility();
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
                    ActualValue = centrellaDeviceDetailsPage.APMappingCampusColumnHeading.Text;
                    break;

                case "building":
                    ActualValue = centrellaDeviceDetailsPage.APMappingBuildingColumnHeading.Text;
                    break;

                case "floor":
                    ActualValue = centrellaDeviceDetailsPage.APMappingFloorColumnHeading.Text;
                    break;

                case "ap location":
                    ActualValue = centrellaDeviceDetailsPage.APMappingAPLocationColumnHeading.Text;
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
            centrellaDeviceDetailsPage.APMappingAddAPMappingButton.Click();
        }

        [Then(@"""(.*)"" entry field with ""(.*)"" hint text is displayed")]
        public void ThenEntryFieldWithHintTextIsDisplayed(string textBoxName, string ExpectedHintText)
        {
            string ActualValue = null;

            switch (textBoxName.ToLower().Trim())
            {
                case "campus":
                    centrellaDeviceDetailsPage.APMappingCampusTextBox.GetElementVisibility().Should().BeTrue(textBoxName+ " is not displayed");
                    ActualValue = centrellaDeviceDetailsPage.APMappingCampusTextBox.GetAttribute("placeholder");
                    break;

                case "building":
                    centrellaDeviceDetailsPage.APMappingBuildingTextBox.GetElementVisibility().Should().BeTrue(textBoxName + " is not displayed");
                    ActualValue = centrellaDeviceDetailsPage.APMappingBuildingTextBox.GetAttribute("placeholder");
                    break;

                case "floor":
                    centrellaDeviceDetailsPage.APMappingFloorTextBox.GetElementVisibility().Should().BeTrue(textBoxName + " is not displayed");
                    ActualValue = centrellaDeviceDetailsPage.APMappingFloorTextBox.GetAttribute("placeholder");
                    break;

                case "ap location":
                    centrellaDeviceDetailsPage.APMappingAPLocationTextBox.GetElementVisibility().Should().BeTrue(textBoxName + " is not displayed");
                    ActualValue = centrellaDeviceDetailsPage.APMappingAPLocationTextBox.GetAttribute("placeholder");
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
            centrellaDeviceDetailsPage.APMappingSaveButton.GetElementVisibility().Should().BeTrue("Save Button is not displayed");
        }

        [When(@"user clicks Edit AP mapping button")]
        public void WhenUserClicksEditAPMappingButton()
        {
            centrellaDeviceDetailsPage.APMappingEditAPMappingButton.Click();
        }

        [Then(@"""(.*)"" entry field with ""(.*)"" value is displayed")]
        public void ThenEntryFieldWithValueIsDisplayed(string textBoxName, string ExpectedValue)
        {
            string ActualValue = null;

            switch (textBoxName.ToLower().Trim())
            {
                case "campus":
                    centrellaDeviceDetailsPage.APMappingCampusTextBox.GetElementVisibility().Should().BeTrue(textBoxName + " is not displayed");
                    ActualValue = centrellaDeviceDetailsPage.APMappingCampusTextBox.GetAttribute("value");
                    break;

                case "building":
                    centrellaDeviceDetailsPage.APMappingBuildingTextBox.GetElementVisibility().Should().BeTrue(textBoxName + " is not displayed");
                    ActualValue = centrellaDeviceDetailsPage.APMappingBuildingTextBox.GetAttribute("value");
                    break;

                case "floor":
                    centrellaDeviceDetailsPage.APMappingFloorTextBox.GetElementVisibility().Should().BeTrue(textBoxName + " is not displayed");
                    ActualValue = centrellaDeviceDetailsPage.APMappingFloorTextBox.GetAttribute("value");
                    break;

                case "ap location":
                    centrellaDeviceDetailsPage.APMappingAPLocationTextBox.GetElementVisibility().Should().BeTrue(textBoxName + " is not displayed");
                    ActualValue = centrellaDeviceDetailsPage.APMappingAPLocationTextBox.GetAttribute("value");
                    break;

                default:
                    Assert.Fail(textBoxName + " is Invalid");
                    break;
            }

            ActualValue.Should().Equals(ExpectedValue);
        }


    }
}
