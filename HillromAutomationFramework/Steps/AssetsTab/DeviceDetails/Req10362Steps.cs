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
    [Binding,Scope(Tag = "SoftwareRequirementID_10362")]
    class Req10362Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly ProgressaDeviceDetailsPage _progressaDeviceDetailsPage;


        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public Req10362Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _mainPage = new MainPage(driver);
            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _progressaDeviceDetailsPage = new ProgressaDeviceDetailsPage(driver);
        }

        [Given(@"user is on Asset List page with more than one Progressa")]
        public void GivenUserIsOnAssetListPageWithMoreThanOneProgressa()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(_landingPage.PSSServiceOrganizationFacilityBatesville, _driver, "Progressa Orgaization");
            _landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.DeviceListRow.GetElementCount().Should().BeGreaterThan(1, "More than one device is not displayed");

        }

        [When(@"user clicks any Progressa")]
        public void WhenUserClicksAnyProgressa()
        {
            _mainPage.DeviceListRow[0].Click();
        }

        [Then(@"Asset Details landing page is displayed")]
        public void ThenAssetDetailsLandingPageIsDisplayed()
        {
            _progressaDeviceDetailsPage.ProgressaDeviceSummarySubSection.GetElementVisibility().Should().BeTrue("Asset Details Page should be displayed");
        }

        [Then(@"Asset Detail summary subsection is displayed")]
        public void ThenAssetDetailSummarySubsectionIsDisplayed()
        {
            _progressaDeviceDetailsPage.ProgressaDeviceSummarySubSection.GetElementVisibility().Should().BeTrue("Asset Details Page should be displayed");
        }

        [Then(@"Error codes tab is displayed")]
        public void ThenErrorCodesTabIsDisplayed()
        {
            _progressaDeviceDetailsPage.ErrorCodeTab.GetElementVisibility().Should().BeTrue("Error code tab is not displayed");
        }

        [Then(@"Preventive maintenance tab is displayed")]
        public void ThenPreventiveMaintenanceTabIsDisplayed()
        {
            _progressaDeviceDetailsPage.PreventiveMaintenanceTab.GetElementVisibility().Should().BeTrue("Preventive maintanance tab is not displayed");
        }

        [Given(@"user is on device details page for Progressa Serial number ""(.*)""")]
        public void GivenUserIsOnDeviceDetailsPageForProgressaSerialNumber(string serialNumber)
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(_landingPage.PSSServiceOrganizationFacilityBatesville, _driver, "Progressa Orgaization");
            _landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.SearchSerialNumberAndClick(serialNumber);
        }



        [Then(@"Summary Progressa image is displayed")]
        public void ThenSummaryProgressaImageIsDisplayed()
        {
            _progressaDeviceDetailsPage.ProgressaDeviceImage.GetElementVisibility().Should().BeTrue("Image is not displayed");
        }

        [Then(@"Summary ""(.*)"" label is displayed")]
        public void ThenSummaryLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            bool ExpectedValue = true;
            switch (LabelName.ToLower().Trim())
            {
                case "radio ip address":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaRadioIPAddressLabel.GetElementVisibility();
                    break;
                case "radio mac address":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaRadioMACAddressLabel.GetElementVisibility();
                    break;
                case "model":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaModelLabel.GetElementVisibility();
                    break;
                case "asset name":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaAssetNameLabel.GetElementVisibility();
                    break;
                case "serial number":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaSerialNumberLabel.GetElementVisibility();
                    break;
                case "facility":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaFacilityLabel.GetElementVisibility();
                    break;
                case "location":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaLocationLabel.GetElementVisibility();
                    break;
                case "room/bed/presence":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaRoomBedLabel.GetElementVisibility();
                    break;
                case "radio ssid":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaRadioSSIDLabel.GetElementVisibility();
                    break;
                case "radio rssi":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaRadioRSSILabel.GetElementVisibility();
                    break;
                case "firmware version":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaFirmwareVersionLabel.GetElementVisibility();
                    break;

                case "connection status":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaConnectionStatusLabel.GetElementVisibility();
                    break;
                case "last connected on":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaLastConnectedLabel.GetElementVisibility();
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
                    ActualValue = _progressaDeviceDetailsPage.ProgressaRadioIPAddressValue.Text;
                    break;
                case "radio mac address":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaRadioMACAddressValue.Text;
                    break;
                case "model":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaModelValue.Text;
                    break;
                case "asset name":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaAssetNameValue.Text;
                    break;
                case "serial number":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaSerialNumberValue.Text;
                    break;
                case "facility":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaFacilityValue.Text;
                    break;
                case "location":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaLocationValue.Text;
                    break;
                case "room/bed/presence":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaRoomBedValue.Text;
                    break;
                case "radio ssid":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaRadioSSIDValue.Text;
                    break;
                case "radio rssi":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaRadioRSSIValue.Text;
                    break;
                case "firmware version":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaFirmwareVersionValue.Text;
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
            _progressaDeviceDetailsPage.PreventiveMaintenanceTab.Click();
            Thread.Sleep(2000);
            _progressaDeviceDetailsPage.ErrorCodeTab.Click();
            _progressaDeviceDetailsPage.PreventiveMaintenanceTab.Click();
            SetMethods.ScrollToBottomofWebpage(_driver);
        }

        [Then(@"""(.*)"" label is displayed")]
        public void ThenLabelIsDisplayed(string labelName)
        {
            bool ActualValue = false;

            switch (labelName.ToLower().Trim())
            {
                case "preventive maintenance":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaPreventiveMaintenanceLabel.GetElementVisibility();
                    break;

                case "recent maintenance history":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaRecentMaintenanceHistoryLabel.GetElementVisibility();
                    break;

                case "there is no maintenance history.":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaNoMaintenanceHistoryLabel.GetElementVisibility();
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
            _progressaDeviceDetailsPage.ProgressaServiceDatePickerControl.GetElementVisibility().Should().BeTrue("Date Picker is not displayed");
        }

        [When(@"clicks service date picker control")]
        public void WhenClicksServiceDatePickerControl()
        {
            _progressaDeviceDetailsPage.ProgressaServiceDatePickerControl.Click();
        }

        [When(@"clicks a date other than today and not the same as the Maintenance date in the first row of the table")]
        public void WhenClicksADateOtherThanTodayAndNotTheSameAsTheMaintenanceDateInTheFirstRowOfTheTable()
        {
            _progressaDeviceDetailsPage.ProgressaServiceDatePickerPreviousArrow.Click();
            _progressaDeviceDetailsPage.RandomDate(_driver).Click();
            Thread.Sleep(2000);
            if (!_progressaDeviceDetailsPage.ProgressaNoMaintenanceHistoryLabel.GetElementVisibility())
            {
                string SelectedDateInTextBox = _progressaDeviceDetailsPage.ProgressaCurrentMaintenanceDateTextBox.GetAttribute("value");
                
                string LastmaintenanceDate = DateTime.ParseExact(_progressaDeviceDetailsPage.ProgressaRecentlyAddedEntryDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("M'/'d'/'yyyy");

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
            string ActualDateInTextBox = _progressaDeviceDetailsPage.ProgressaCurrentMaintenanceDateTextBox.GetAttribute("value");
            
            string ExpectedDateInTextBox = _progressaDeviceDetailsPage.SelectedDate();
            
            ActualDateInTextBox.Should().NotBeNullOrEmpty("Current Date Maintenance Date should not be empty");

            ActualDateInTextBox.Should().BeEquivalentTo(ExpectedDateInTextBox);
        }

        [Then(@"Save button is displayed")]
        public void ThenSaveButtonIsDisplayed()
        {
            _progressaDeviceDetailsPage.ProgressaSaveButton.GetElementVisibility().Should().BeTrue("Save button is not displayed");
        }

        [Then(@"Cancel button is displayed")]
        public void ThenCancelButtonIsDisplayed()
        {
            _progressaDeviceDetailsPage.ProgressaCancelButton.GetElementVisibility().Should().BeTrue("Cancel button is not displayed");
        }

        [When(@"user clicks Save button")]
        public void WhenUserClicksSaveButton()
        {
            _progressaDeviceDetailsPage.ProgressaSaveButton.Click();
        }

        [Then(@"Recently added Maintenance date is date picked")]
        public void ThenRecentlyAddedMaintenanceDateIsDatePicked()
        {
            //Wait untill data is loaded
            Thread.Sleep(3000);
            string DatePicked = _progressaDeviceDetailsPage.SelectedDate();
            string maintenanceDate = DateTime.ParseExact(_progressaDeviceDetailsPage.ProgressaRecentlyAddedEntryDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("M'/'d'/'yyyy");
            maintenanceDate.Should().BeEquivalentTo(DatePicked);
        }

        [Then(@"Recently added Modification date is today's date")]
        public void ThenRecentlyAddedModificationDateIsTodaySDate()
        {
            string CurrentDate = DateTime.Now.ToString("dd MMM yyyy");
            string LastUpdateEntryModificationDateTime = _progressaDeviceDetailsPage.ProgressaRecentlyAddedEntryModifiationDateTime.Text;
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
                    ActualValue = _progressaDeviceDetailsPage.ProgressaMaintenanceDateColumn.GetElementVisibility();
                    break;

                case "user id":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaUserIDColumn.GetElementVisibility();
                    break;

                case "modification date/time":
                    ActualValue = _progressaDeviceDetailsPage.ProgressaModificationDateColumn.GetElementVisibility();
                    break;
                default:
                    Assert.Fail(columnName + " is Invalid");
                    break;

            }

            ActualValue.Should().BeTrue();
        }


    }
}
