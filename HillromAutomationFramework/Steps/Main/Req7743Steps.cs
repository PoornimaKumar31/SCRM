using FluentAssertions;
using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.PageObjects.AssetsTab;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Main
{
    [Binding,Scope(Tag = "SoftwareRequirementID_7743")]
    class Req7743Steps
    {
        MainPage mainPage = new MainPage();
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        CentrellaDeviceDetailsPage centrellaDeviceDetailsPage = new CentrellaDeviceDetailsPage();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        private ScenarioContext _scenarioContext;
        
        public Req7743Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"user is on Asset List page with more than one Centrella")]
        public void GivenUserIsOnAssetListPageWithMoreThanOneCentrella()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(landingPage.PSSServiceOrganizationFacilityBatesville, "Centrella Orgaization");
            landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.DeviceListRow.GetElementCount().Should().BeGreaterThan(1, "More than one device is not displayed");

        }

        [When(@"user clicks any Centrella")]
        public void WhenUserClicksAnyCentrella()
        {
            mainPage.DeviceListRow[0].Click();
        }

        [Then(@"Asset Details landing page is displayed")]
        public void ThenAssetDetailsLandingPageIsDisplayed()
        {
            centrellaDeviceDetailsPage.CentrellaDeviceSummarySubSection.GetElementVisibility().Should().BeTrue("Asset Details Page should be displayed");
        }

        [Then(@"Asset Detail summary subsection is displayed")]
        public void ThenAssetDetailSummarySubsectionIsDisplayed()
        {
            centrellaDeviceDetailsPage.CentrellaDeviceSummarySubSection.GetElementVisibility().Should().BeTrue("Asset Details Page should be displayed");
        }

        [Then(@"Error codes tab is displayed")]
        public void ThenErrorCodesTabIsDisplayed()
        {
            centrellaDeviceDetailsPage.ErrorCodeTab.GetElementVisibility().Should().BeTrue("Error code tab is not displayed");
        }

        [Then(@"Preventive maintenance tab is displayed")]
        public void ThenPreventiveMaintenanceTabIsDisplayed()
        {
            centrellaDeviceDetailsPage.PreventiveMaintenanceTab.GetElementVisibility().Should().BeTrue("Preventive maintanance tab is not displayed");
        }

        [Given(@"user is on device details page for Centrella Serial number ""(.*)""")]
        public void GivenUserIsOnDeviceDetailsPageForCentrellaSerialNumber(string serialNumber)
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(landingPage.PSSServiceOrganizationFacilityBatesville, "Centrella Orgaization");
            landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.SearchSerialNumberAndClick(serialNumber);
        }



        [Then(@"Summary Centrella image is displayed")]
        public void ThenSummaryCentrellaImageIsDisplayed()
        {
            centrellaDeviceDetailsPage.CentrellaDeviceImage.GetElementVisibility().Should().BeTrue("Image is not displayed");
        }

        [Then(@"Summary ""(.*)"" label is displayed")]
        public void ThenSummaryLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            bool ExpectedValue = true;
            switch (LabelName.ToLower().Trim())
            {
                case "radio ip address":
                    ActualValue = centrellaDeviceDetailsPage.CentrellaRadioIPAddressLabel.GetElementVisibility();
                    break;
                case "radio mac address":
                    ActualValue = centrellaDeviceDetailsPage.CentrellaRadioMACAddressLabel.GetElementVisibility();
                    break;
                case "model":
                    ActualValue = centrellaDeviceDetailsPage.CentrellaModelLabel.GetElementVisibility();
                    break;
                case "asset name":
                    ActualValue = centrellaDeviceDetailsPage.CentrellaAssetNameLabel.GetElementVisibility();
                    break;
                case "serial number":
                    ActualValue = centrellaDeviceDetailsPage.CentrellaSerialNumberLabel.GetElementVisibility();
                    break;
                case "facility":
                    ActualValue = centrellaDeviceDetailsPage.CentrellaFacilityLabel.GetElementVisibility();
                    break;
                case "location":
                    ActualValue = centrellaDeviceDetailsPage.CentrellaLocationLabel.GetElementVisibility();
                    break;
                case "room/bed/presence":
                    ActualValue = centrellaDeviceDetailsPage.CentrellaRoomBedLabel.GetElementVisibility();
                    break;
                case "radio ssid":
                    ActualValue = centrellaDeviceDetailsPage.CentrellaRadioSSIDLabel.GetElementVisibility();
                    break;
                case "radio rssi":
                    ActualValue = centrellaDeviceDetailsPage.CentrellaRadioRSSILabel.GetElementVisibility();
                    break;
                case "firmware version":
                    ActualValue = centrellaDeviceDetailsPage.CentrellaFirmwareVersionLabel.GetElementVisibility();
                    break;

                case "connection status":
                    ActualValue = centrellaDeviceDetailsPage.CentrellaConnectionStatusLabel.GetElementVisibility();
                    break;
                case "last connected on":
                    ActualValue = centrellaDeviceDetailsPage.CentrellaLastConnectedLabel.GetElementVisibility();
                    break;

                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }

            ActualValue.Should().Equals(ExpectedValue);
        }

        [Then(@"Summary ""(.*)"" is ""(.*)""")]
        public void ThenSummaryIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "radio ip address":
                    ActualValue = centrellaDeviceDetailsPage.CentrellaRadioIPAddressValue.Text;
                    break;
                case "radio mac address":
                    ActualValue = centrellaDeviceDetailsPage.CentrellaRadioMACAddressValue.Text;
                    break;
                case "model":
                    ActualValue = centrellaDeviceDetailsPage.CentrellaModelValue.Text;
                    break;
                case "asset name":
                    ActualValue = centrellaDeviceDetailsPage.CentrellaAssetNameValue.Text;
                    break;
                case "serial number":
                    ActualValue = centrellaDeviceDetailsPage.CentrellaSerialNumberValue.Text;
                    break;
                case "facility":
                    ActualValue = centrellaDeviceDetailsPage.CentrellaFacilityValue.Text;
                    break;
                case "location":
                    ActualValue = centrellaDeviceDetailsPage.CentrellaLocationValue.Text;
                    break;
                case "room/bed/presence":
                    ActualValue = centrellaDeviceDetailsPage.CentrellaRoomBedValue.Text;
                    break;
                case "radio ssid":
                    ActualValue = centrellaDeviceDetailsPage.CentrellaRadioSSIDValue.Text;
                    break;
                case "radio rssi":
                    ActualValue = centrellaDeviceDetailsPage.CentrellaRadioRSSIValue.Text;
                    break;
                case "firmware version":
                    ActualValue = centrellaDeviceDetailsPage.CentrellaFirmwareVersionValue.Text;
                    break;

                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }
            
            ActualValue.Should().Equals(ExpectedValue);
        }


        [When(@"user clicks Preventive maintenance tab")]
        public void WhenUserClicksPreventiveMaintenanceTab()
        {
            centrellaDeviceDetailsPage.PreventiveMaintenanceTab.Click();
            Thread.Sleep(2000);
            centrellaDeviceDetailsPage.ErrorCodeTab.Click();
            centrellaDeviceDetailsPage.PreventiveMaintenanceTab.Click();
            SetMethods.ScrollToBottomofWebpage();
        }

        [Then(@"""(.*)"" label is displayed")]
        public void ThenLabelIsDisplayed(string labelName)
        {
            bool ActualValue = false;

            switch (labelName.ToLower().Trim())
            {
                case "preventive maintenance":
                    ActualValue = centrellaDeviceDetailsPage.PreventiveMaintenanceLabel.GetElementVisibility();
                    break;

                case "recent maintenance history":
                    ActualValue = centrellaDeviceDetailsPage.RecentMaintenanceHistoryLabel.GetElementVisibility();
                    break;

                case "there is no maintenance history":
                    ActualValue = centrellaDeviceDetailsPage.NoMaintenanceHistoryLabel.GetElementVisibility();
                    break;
                default:
                    Assert.Fail(labelName + " is Invalid");
                    break;

            }
            
            ActualValue.Should().BeTrue();
        }

        [Then(@"service date picker control is displayed")]
        public void ThenServiceDatePickerControlIsDisplayed()
        {
            centrellaDeviceDetailsPage.ServiceDatePickerControl.GetElementVisibility().Should().BeTrue("Date Picker is not displayed");
        }

        [When(@"clicks service date picker control")]
        public void WhenClicksServiceDatePickerControl()
        {
            centrellaDeviceDetailsPage.ServiceDatePickerControl.Click();
        }

        [When(@"clicks a date other than today and not the same as the Maintenance date in the first row of the table")]
        public void WhenClicksADateOtherThanTodayAndNotTheSameAsTheMaintenanceDateInTheFirstRowOfTheTable()
        {
            centrellaDeviceDetailsPage.ServiceDatePickerPreviousArrow.Click();
            centrellaDeviceDetailsPage.RandomDate().Click();
            Thread.Sleep(2000);
            if (!centrellaDeviceDetailsPage.NoMaintenanceHistoryLabel.GetElementVisibility())
            {
                string SelectedDateInTextBox = centrellaDeviceDetailsPage.CurrentMaintenanceDateTextBox.GetAttribute("value");
                
                string LastmaintenanceDate = DateTime.ParseExact(centrellaDeviceDetailsPage.RecentlyAddedEntryDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("M'/'d'/'yyyy");

                if (LastmaintenanceDate == SelectedDateInTextBox)
                {
                    WhenClicksServiceDatePickerControl();
                    WhenClicksADateOtherThanTodayAndNotTheSameAsTheMaintenanceDateInTheFirstRowOfTheTable();
                }
            }
            
        }


        [Then(@"date is displayed in Current maintenance date textbox")]
        public void ThenDateIsDisplayedInCurrentMaintenanceDateTextbox()
        {
            string ActualDateInTextBox = centrellaDeviceDetailsPage.CurrentMaintenanceDateTextBox.GetAttribute("value");
            
            string ExpectedDateInTextBox = centrellaDeviceDetailsPage.SelectedDate();
            
            ActualDateInTextBox.Should().NotBeNullOrEmpty("Current Date Maintenance Date should not be empty");

            ActualDateInTextBox.Should().BeEquivalentTo(ExpectedDateInTextBox);
        }

        [Then(@"Save button is displayed")]
        public void ThenSaveButtonIsDisplayed()
        {
            centrellaDeviceDetailsPage.SaveButton.GetElementVisibility().Should().BeTrue("Save button is not displayed");
        }

        [Then(@"Cancel button is displayed")]
        public void ThenCancelButtonIsDisplayed()
        {
            centrellaDeviceDetailsPage.CancelButton.GetElementVisibility().Should().BeTrue("Cancel button is not displayed");
        }

        [When(@"user clicks Save button")]
        public void WhenUserClicksSaveButton()
        {
            centrellaDeviceDetailsPage.SaveButton.Click();
        }

        [Then(@"Recently added Maintenance date is date picked")]
        public void ThenRecentlyAddedMaintenanceDateIsDatePicked()
        {
            string DatePicked = centrellaDeviceDetailsPage.SelectedDate();
            Thread.Sleep(2000);
            string maintenanceDate = DateTime.ParseExact(centrellaDeviceDetailsPage.RecentlyAddedEntryDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("M'/'d'/'yyyy");
            maintenanceDate.Should().BeEquivalentTo(DatePicked);
        }

        [Then(@"Recently added Modification date is today's date")]
        public void ThenRecentlyAddedModificationDateIsTodaySDate()
        {
            string CurrentDate = DateTime.Now.ToString("dd MMM yyyy");
            string LastUpdateEntryModificationDateTime = centrellaDeviceDetailsPage.RecentlyAddedEntryModifiationDateTime.Text;
            string FormatedModificationDate = DateTime.ParseExact(LastUpdateEntryModificationDateTime, "dd MMM yyyy, hh:mm tt", CultureInfo.InvariantCulture).ToString("dd MMM yyyy");
            FormatedModificationDate.Should().BeEquivalentTo(CurrentDate);
        }

        [Then(@"""(.*)"" column is displayed")]
        public void ThenColumnIsDisplayed(string columnName)
        {
            bool ActualValue = false;

            switch (columnName.ToLower().Trim())
            {
                case "maintenance date":
                    ActualValue = centrellaDeviceDetailsPage.MaintenanceDateColumn.GetElementVisibility();
                    break;

                case "user id":
                    ActualValue = centrellaDeviceDetailsPage.UserIDColumn.GetElementVisibility();
                    break;

                case "modification date/time":
                    ActualValue = centrellaDeviceDetailsPage.ModificationDateColumn.GetElementVisibility();
                    break;
                default:
                    Assert.Fail(columnName + " is Invalid");
                    break;

            }

            ActualValue.Should().BeTrue();
        }


    }
}
