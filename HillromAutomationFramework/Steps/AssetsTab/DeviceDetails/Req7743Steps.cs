using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AssetsTab;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Globalization;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.AssetsTab.DeviceDetails
{
    [Binding,Scope(Tag = "SoftwareRequirementID_7743")]
    class Req7743Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly CentrellaDeviceDetailsPage _centrellaDeviceDetailsPage;


        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public Req7743Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _mainPage = new MainPage(driver);
            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _centrellaDeviceDetailsPage = new CentrellaDeviceDetailsPage(driver);
        }

        [Given(@"user is on Asset List page with more than one Centrella")]
        public void GivenUserIsOnAssetListPageWithMoreThanOneCentrella()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(_landingPage.PSSServiceOrganizationFacilityBatesville, _driver, "Centrella Orgaization");
            _landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.DeviceListRow.GetElementCount().Should().BeGreaterThan(1, "More than one device is not displayed");

        }

        [When(@"user clicks any Centrella")]
        public void WhenUserClicksAnyCentrella()
        {
            _mainPage.DeviceListRow[0].Click();
        }

        [Then(@"Asset Details landing page is displayed")]
        public void ThenAssetDetailsLandingPageIsDisplayed()
        {
            _centrellaDeviceDetailsPage.CentrellaDeviceSummarySubSection.GetElementVisibility().Should().BeTrue("Asset Details Page should be displayed");
        }

        [Then(@"Asset Detail summary subsection is displayed")]
        public void ThenAssetDetailSummarySubsectionIsDisplayed()
        {
            _centrellaDeviceDetailsPage.CentrellaDeviceSummarySubSection.GetElementVisibility().Should().BeTrue("Asset Details Page should be displayed");
        }

        [Then(@"Error codes tab is displayed")]
        public void ThenErrorCodesTabIsDisplayed()
        {
            _centrellaDeviceDetailsPage.ErrorCodeTab.GetElementVisibility().Should().BeTrue("Error code tab is not displayed");
        }

        [Then(@"Preventive maintenance tab is displayed")]
        public void ThenPreventiveMaintenanceTabIsDisplayed()
        {
            _centrellaDeviceDetailsPage.PreventiveMaintenanceTab.GetElementVisibility().Should().BeTrue("Preventive maintanance tab is not displayed");
        }

        [Given(@"user is on device details page for Centrella Serial number ""(.*)""")]
        public void GivenUserIsOnDeviceDetailsPageForCentrellaSerialNumber(string serialNumber)
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(_landingPage.PSSServiceOrganizationFacilityBatesville, _driver, "Centrella Orgaization");
            _landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.SearchSerialNumberAndClick(serialNumber);
        }



        [Then(@"Summary Centrella image is displayed")]
        public void ThenSummaryCentrellaImageIsDisplayed()
        {
            _centrellaDeviceDetailsPage.CentrellaDeviceImage.GetElementVisibility().Should().BeTrue("Image is not displayed");
        }

        [Then(@"Summary ""(.*)"" label is displayed")]
        public void ThenSummaryLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            bool ExpectedValue = true;
            switch (LabelName.ToLower().Trim())
            {
                case "radio ip address":
                    ActualValue = _centrellaDeviceDetailsPage.CentrellaRadioIPAddressLabel.GetElementVisibility();
                    break;
                case "radio mac address":
                    ActualValue = _centrellaDeviceDetailsPage.CentrellaRadioMACAddressLabel.GetElementVisibility();
                    break;
                case "model":
                    ActualValue = _centrellaDeviceDetailsPage.CentrellaModelLabel.GetElementVisibility();
                    break;
                case "asset name":
                    ActualValue = _centrellaDeviceDetailsPage.CentrellaAssetNameLabel.GetElementVisibility();
                    break;
                case "serial number":
                    ActualValue = _centrellaDeviceDetailsPage.CentrellaSerialNumberLabel.GetElementVisibility();
                    break;
                case "facility":
                    ActualValue = _centrellaDeviceDetailsPage.CentrellaFacilityLabel.GetElementVisibility();
                    break;
                case "location":
                    ActualValue = _centrellaDeviceDetailsPage.CentrellaLocationLabel.GetElementVisibility();
                    break;
                case "room/bed/presence":
                    ActualValue = _centrellaDeviceDetailsPage.CentrellaRoomBedLabel.GetElementVisibility();
                    break;
                case "radio ssid":
                    ActualValue = _centrellaDeviceDetailsPage.CentrellaRadioSSIDLabel.GetElementVisibility();
                    break;
                case "radio rssi":
                    ActualValue = _centrellaDeviceDetailsPage.CentrellaRadioRSSILabel.GetElementVisibility();
                    break;
                case "firmware version":
                    ActualValue = _centrellaDeviceDetailsPage.CentrellaFirmwareVersionLabel.GetElementVisibility();
                    break;

                case "connection status":
                    ActualValue = _centrellaDeviceDetailsPage.CentrellaConnectionStatusLabel.GetElementVisibility();
                    break;
                case "last connected on":
                    ActualValue = _centrellaDeviceDetailsPage.CentrellaLastConnectedLabel.GetElementVisibility();
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
                    ActualValue = _centrellaDeviceDetailsPage.CentrellaRadioIPAddressValue.Text;
                    break;
                case "radio mac address":
                    ActualValue = _centrellaDeviceDetailsPage.CentrellaRadioMACAddressValue.Text;
                    break;
                case "model":
                    ActualValue = _centrellaDeviceDetailsPage.CentrellaModelValue.Text;
                    break;
                case "asset name":
                    ActualValue = _centrellaDeviceDetailsPage.CentrellaAssetNameValue.Text;
                    break;
                case "serial number":
                    ActualValue = _centrellaDeviceDetailsPage.CentrellaSerialNumberValue.Text;
                    break;
                case "facility":
                    ActualValue = _centrellaDeviceDetailsPage.CentrellaFacilityValue.Text;
                    break;
                case "location":
                    ActualValue = _centrellaDeviceDetailsPage.CentrellaLocationValue.Text;
                    break;
                case "room/bed/presence":
                    ActualValue = _centrellaDeviceDetailsPage.CentrellaRoomBedValue.Text;
                    break;
                case "radio ssid":
                    ActualValue = _centrellaDeviceDetailsPage.CentrellaRadioSSIDValue.Text;
                    break;
                case "radio rssi":
                    ActualValue = _centrellaDeviceDetailsPage.CentrellaRadioRSSIValue.Text;
                    break;
                case "firmware version":
                    ActualValue = _centrellaDeviceDetailsPage.CentrellaFirmwareVersionValue.Text;
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
            _centrellaDeviceDetailsPage.PreventiveMaintenanceTab.Click();
            Thread.Sleep(2000);
            _centrellaDeviceDetailsPage.ErrorCodeTab.Click();
            _centrellaDeviceDetailsPage.PreventiveMaintenanceTab.Click();
            SetMethods.ScrollToBottomofWebpage(_driver);
        }

        [Then(@"""(.*)"" label is displayed")]
        public void ThenLabelIsDisplayed(string labelName)
        {
            bool ActualValue = false;

            switch (labelName.ToLower().Trim())
            {
                case "preventive maintenance":
                    ActualValue = _centrellaDeviceDetailsPage.PreventiveMaintenanceLabel.GetElementVisibility();
                    break;

                case "recent maintenance history":
                    ActualValue = _centrellaDeviceDetailsPage.RecentMaintenanceHistoryLabel.GetElementVisibility();
                    break;

                case "there is no maintenance history":
                    ActualValue = _centrellaDeviceDetailsPage.NoMaintenanceHistoryLabel.GetElementVisibility();
                    break;
                default:
                    Assert.Fail(labelName + " is Invalid");
                    break;

            }
            
            ActualValue.Should().BeTrue(labelName+" should be dislpayed when no records are present.");
        }

        [Then(@"service date picker control is displayed")]
        public void ThenServiceDatePickerControlIsDisplayed()
        {
            _centrellaDeviceDetailsPage.ServiceDatePickerControl.GetElementVisibility().Should().BeTrue("Date Picker is not displayed");
        }

        [When(@"clicks service date picker control")]
        public void WhenClicksServiceDatePickerControl()
        {
            _centrellaDeviceDetailsPage.ServiceDatePickerControl.Click();
        }

        [When(@"clicks a date other than today and not the same as the Maintenance date in the first row of the table")]
        public void WhenClicksADateOtherThanTodayAndNotTheSameAsTheMaintenanceDateInTheFirstRowOfTheTable()
        {
            _centrellaDeviceDetailsPage.ServiceDatePickerPreviousArrow.Click();
            _centrellaDeviceDetailsPage.RandomDate(_driver).Click();
            Thread.Sleep(2000);
            if (!_centrellaDeviceDetailsPage.NoMaintenanceHistoryLabel.GetElementVisibility())
            {
                string SelectedDateInTextBox = _centrellaDeviceDetailsPage.CurrentMaintenanceDateTextBox.GetAttribute("value");
                
                string LastmaintenanceDate = DateTime.ParseExact(_centrellaDeviceDetailsPage.RecentlyAddedEntryDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("M'/'d'/'yyyy");

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
            string ActualDateInTextBox = _centrellaDeviceDetailsPage.CurrentMaintenanceDateTextBox.GetAttribute("value");
            
            string ExpectedDateInTextBox = _centrellaDeviceDetailsPage.SelectedDate();
            
            ActualDateInTextBox.Should().NotBeNullOrEmpty("Current Date Maintenance Date should not be empty");

            ActualDateInTextBox.Should().BeEquivalentTo(ExpectedDateInTextBox);
        }

        [Then(@"Save button is displayed")]
        public void ThenSaveButtonIsDisplayed()
        {
            _centrellaDeviceDetailsPage.SaveButton.GetElementVisibility().Should().BeTrue("Save button is not displayed");
        }

        [Then(@"Cancel button is displayed")]
        public void ThenCancelButtonIsDisplayed()
        {
            _centrellaDeviceDetailsPage.CancelButton.GetElementVisibility().Should().BeTrue("Cancel button is not displayed");
        }

        [When(@"user clicks Save button")]
        public void WhenUserClicksSaveButton()
        {
            _centrellaDeviceDetailsPage.SaveButton.Click();
        }

        [Then(@"Recently added Maintenance date is date picked")]
        public void ThenRecentlyAddedMaintenanceDateIsDatePicked()
        {
            //Wait untill data is loaded
            Thread.Sleep(3000);
            string DatePicked = _centrellaDeviceDetailsPage.SelectedDate();
            string maintenanceDate = DateTime.ParseExact(_centrellaDeviceDetailsPage.RecentlyAddedEntryDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("M'/'d'/'yyyy");
            maintenanceDate.Should().BeEquivalentTo(DatePicked);
        }

        [Then(@"Recently added Modification date is today's date")]
        public void ThenRecentlyAddedModificationDateIsTodaySDate()
        {
            string CurrentDate = DateTime.Now.ToString("dd MMM yyyy");
            string LastUpdateEntryModificationDateTime = _centrellaDeviceDetailsPage.RecentlyAddedEntryModifiationDateTime.Text;
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
                    ActualValue = _centrellaDeviceDetailsPage.MaintenanceDateColumn.GetElementVisibility();
                    break;

                case "user id":
                    ActualValue = _centrellaDeviceDetailsPage.UserIDColumn.GetElementVisibility();
                    break;

                case "modification date/time":
                    ActualValue = _centrellaDeviceDetailsPage.ModificationDateColumn.GetElementVisibility();
                    break;
                default:
                    Assert.Fail(columnName + " is Invalid");
                    break;

            }

            ActualValue.Should().BeTrue();
        }


    }
}
