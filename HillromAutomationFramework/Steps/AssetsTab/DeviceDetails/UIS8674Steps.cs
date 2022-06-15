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
        private readonly ProgressaDeviceDetailsPage _progressaDeviceDetailsPage;

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
            _progressaDeviceDetailsPage = new ProgressaDeviceDetailsPage(driver);

        }


        [Given(@"manager user is on device details page for Centrella Serial number ""(.*)""")]
        public void GivenManagerUserIsOnDeviceDetailsPageForCentrellaSerialNumber(string serialNumber)
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(_landingPage.PSSServiceOrganizationFacilityBatesville, _driver, "Centrella Orgaization");
            _landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.SearchSerialNumberAndClick(serialNumber);
        }

        [When(@"user clicks Locate Asset button")]
        public void WhenUserClicksLocateAssetButton()
        {
            //Centrella
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("centrella"))
            {
                _centrellaDeviceDetailsPage.CentrellaLocateAssetButton.Click();
            }
            //Progressa
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("progressa"))
            {
                _progressaDeviceDetailsPage.ProgressaLocateAssetButton.Click();
            }
        }

        [Then(@"Locate Asset pop-up dialog is displayed")]
        public void ThenLocateAssetPop_UpDialogIsDisplayed()
        {
            //Centrella
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("centrella"))
            {
                _wait.Until(ExplicitWait.ElementIsVisible(By.XPath(CentrellaDeviceDetailsPage.Locators.APMappingLocateAssetPopupDialogXPath)));
                _centrellaDeviceDetailsPage.APMappingLocateAssetPopupDialog.GetElementVisibility().Should().BeTrue("Dialog box is not displayed");
            }
            //Progressa
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("progressa"))
            {
                _wait.Until(ExplicitWait.ElementIsVisible(By.XPath(ProgressaDeviceDetailsPage.Locators.ProgressaAPMappingLocateAssetPopupDialogXPath)));
                _centrellaDeviceDetailsPage.APMappingLocateAssetPopupDialog.GetElementVisibility().Should().BeTrue("Dialog box is not displayed");
            }
        }

        [Then(@"""(.*)"" label and value is ""(.*)""")]
        public void ThenLabelAndValueIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            //Centrella
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("centrella"))
            {
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

            //Progressa
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("progressa"))
            {
                switch (LabelName.ToLower().Trim())
                {
                    case "source":
                        ActualValue = _progressaDeviceDetailsPage.ProgressaAPMappingSourceLabelValue.Text;
                        break;
                    case "mac address":
                        ActualValue = _progressaDeviceDetailsPage.ProgressaAPMappingMacAddressLabelValue.Text;
                        break;
                    case "rssi":
                        ActualValue = _progressaDeviceDetailsPage.ProgressaAPMappingRSSILabelValue.Text;
                        break;
                    default:
                        Assert.Fail(LabelName + " is Invalid");
                        break;
                }
                ActualValue.Should().Equals(ExpectedValue);
            }
        }

        [Then(@"Add AP Mapping button is displayed")]
        public void ThenAddAPMappingButtonIsDisplayed()
        {
            //Centrella
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("centrella"))
            {
                _centrellaDeviceDetailsPage.APMappingAddAPMappingButton.GetElementVisibility().Should().BeTrue("Add AP Mapping Button is not displayed");
            }
            //Progressa
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("progressa"))
            {
                _progressaDeviceDetailsPage.ProgressaAPMappingAddAPMappingButton.GetElementVisibility().Should().BeTrue("Add AP Mapping Button is not displayed");
            }
        }

        [Then(@"Close button is displayed")]
        public void ThenCloseButtonIsDisplayed()
        {
            //Centrella
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("centrella"))
            {
                _centrellaDeviceDetailsPage.APMappingCloseButton.GetElementVisibility().Should().BeTrue("Close Button is not displayed");
            }
            //Progressa
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("progressa"))
            {
                _progressaDeviceDetailsPage.ProgressaAPMappingCloseButton.GetElementVisibility().Should().BeTrue("Close Button is not displayed");

            }
        }

        [Then(@"Edit AP Mapping button is displayed")]
        public void ThenEditAPMappingButtonIsDisplayed()
        {
            //Centrella
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("centrella"))
            {
                _centrellaDeviceDetailsPage.APMappingEditAPMappingButton.GetElementVisibility().Should().BeTrue("Edit AP Mapping Button is not displayed");
            }
            //Progressa
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("progressa"))
            {
                _progressaDeviceDetailsPage.ProgressaAPMappingEditAPMappingButton.GetElementVisibility().Should().BeTrue("Edit AP Mapping Button is not displayed");
            }
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
            //Centrella
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("centrella"))
            {
                _centrellaDeviceDetailsPage.APMappingEditAPMappingButton.GetElementVisibility().Should().BeFalse("Edit AP Mapping Button is displayed");
            }
            //Progressa
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("progressa"))
            {
                _progressaDeviceDetailsPage.ProgressaAPMappingEditAPMappingButton.GetElementVisibility().Should().BeFalse("Edit AP Mapping Button is displayed");
            }
        }
        [Then(@"Add AP Mapping button is not displayed")]
        public void ThenAddAPMappingButtonIsNotDisplayed()
        {
            //Centrella
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("centrella"))
            {
                _centrellaDeviceDetailsPage.APMappingAddAPMappingButton.GetElementVisibility().Should().BeFalse("Add AP Mapping Button is displayed");
            }
            //Progressa
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("progressa"))
            {
                _progressaDeviceDetailsPage.ProgressaAPMappingAddAPMappingButton.GetElementVisibility().Should().BeFalse("Add AP Mapping Button is displayed");
            }
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

            //Centrella
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("centrella"))
            {
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
            //Progressa
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("progressa"))
            {
                switch (columnName.ToLower().Trim())
                {
                    case "campus":
                        ActualValue = _progressaDeviceDetailsPage.ProgressaAPMappingCampusColumnHeading.GetElementVisibility();
                        break;

                    case "building":
                        ActualValue = _progressaDeviceDetailsPage.ProgressaAPMappingBuildingColumnHeading.GetElementVisibility();
                        break;

                    case "floor":
                        ActualValue = _progressaDeviceDetailsPage.ProgressaAPMappingFloorColumnHeading.GetElementVisibility();
                        break;

                    case "ap location":
                        ActualValue = _progressaDeviceDetailsPage.ProgressaAPMappingAPLocationColumnHeading.GetElementVisibility();
                        break;

                    default:
                        Assert.Fail(columnName + " is Invalid");
                        break;
                }
                ActualValue.Should().BeTrue();
            }
        }

        [Then(@"value in ""(.*)"" column is ""(.*)""")]
        public void ThenValueInColumnIs(string columnName, string ExpectedValue)
        {
            string ActualValue = null;
            //Centrella
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("centrella"))
            {
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
            //Progressa
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("progressa"))
            {
                switch (columnName.ToLower().Trim())
                {
                    case "campus":
                        ActualValue = _progressaDeviceDetailsPage.ProgressaAPMappingCampusColumnHeading.Text;
                        break;

                    case "building":
                        ActualValue = _progressaDeviceDetailsPage.ProgressaAPMappingBuildingColumnHeading.Text;
                        break;

                    case "floor":
                        ActualValue = _progressaDeviceDetailsPage.ProgressaAPMappingFloorColumnHeading.Text;
                        break;

                    case "ap location":
                        ActualValue = _progressaDeviceDetailsPage.ProgressaAPMappingAPLocationColumnHeading.Text;
                        break;

                    default:
                        Assert.Fail(columnName + " is Invalid");
                        break;
                }

                ActualValue.Should().Equals(ExpectedValue);
            }
        }

        [When(@"user clicks Add AP mapping button")]
        public void WhenUserClicksAddAPMappingButton()
        {
            //Centrella
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("centrella"))
            {
                _centrellaDeviceDetailsPage.APMappingAddAPMappingButton.Click();
            }
            //Progressa
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("progressa"))
            {
                _progressaDeviceDetailsPage.ProgressaAPMappingAddAPMappingButton.Click();
            }
        }
        [Then(@"""(.*)"" entry field with ""(.*)"" hint text is displayed")]
        public void ThenEntryFieldWithHintTextIsDisplayed(string textBoxName, string ExpectedHintText)
        {
            string ActualValue = null;
            //Centrella
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("centrella"))
            {
                switch (textBoxName.ToLower().Trim())
                {
                    case "campus":
                        _centrellaDeviceDetailsPage.APMappingCampusTextBox.GetElementVisibility().Should().BeTrue(textBoxName + " is not displayed");
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
            //Progressa
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("progressa"))
            {
                switch (textBoxName.ToLower().Trim())
                {
                    case "campus":
                        _progressaDeviceDetailsPage.ProgressaAPMappingCampusTextBox.GetElementVisibility().Should().BeTrue(textBoxName + " is not displayed");
                        ActualValue = _progressaDeviceDetailsPage.ProgressaAPMappingCampusTextBox.GetAttribute("placeholder");
                        break;

                    case "building":
                        _progressaDeviceDetailsPage.ProgressaAPMappingBuildingTextBox.GetElementVisibility().Should().BeTrue(textBoxName + " is not displayed");
                        ActualValue = _centrellaDeviceDetailsPage.APMappingBuildingTextBox.GetAttribute("placeholder");
                        break;

                    case "floor":
                        _progressaDeviceDetailsPage.ProgressaAPMappingFloorTextBox.GetElementVisibility().Should().BeTrue(textBoxName + " is not displayed");
                        ActualValue = _centrellaDeviceDetailsPage.APMappingFloorTextBox.GetAttribute("placeholder");
                        break;

                    case "ap location":
                        _progressaDeviceDetailsPage.ProgressaAPMappingAPLocationTextBox.GetElementVisibility().Should().BeTrue(textBoxName + " is not displayed");
                        ActualValue = _centrellaDeviceDetailsPage.APMappingAPLocationTextBox.GetAttribute("placeholder");
                        break;

                    default:
                        Assert.Fail(textBoxName + " is Invalid");
                        break;
                }

                ActualValue.Should().Equals(ExpectedHintText);
            }
        }

        [Then(@"Save button is displayed")]
        public void ThenSaveButtonIsDisplayed()
        {
            //Centrella
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("centrella"))
            {
                _centrellaDeviceDetailsPage.APMappingSaveButton.GetElementVisibility().Should().BeTrue("Save Button is not displayed");
            }
            //Progressa
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("progressa"))
            {
                _progressaDeviceDetailsPage.ProgressaAPMappingSaveButton.GetElementVisibility().Should().BeTrue("Save Button is not displayed");
            }
        }
        [When(@"user clicks Edit AP mapping button")]
        public void WhenUserClicksEditAPMappingButton()
        {
            //Centrella
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("centrella"))
            {
                _centrellaDeviceDetailsPage.APMappingEditAPMappingButton.Click();
            }
            //Progressa
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("progressa"))
            {
                _progressaDeviceDetailsPage.ProgressaAPMappingEditAPMappingButton.Click();
            }
        }

        [Then(@"""(.*)"" entry field with ""(.*)"" value is displayed")]
        public void ThenEntryFieldWithValueIsDisplayed(string textBoxName, string ExpectedValue)
        {
            string ActualValue = null;
            //Centrella
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("centrella"))
            {
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
            //Progressa
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("progressa"))
            {
                switch (textBoxName.ToLower().Trim())
                {
                    case "campus":
                        _progressaDeviceDetailsPage.ProgressaAPMappingCampusTextBox.GetElementVisibility().Should().BeTrue(textBoxName + " is not displayed");
                        ActualValue = _progressaDeviceDetailsPage.ProgressaAPMappingCampusTextBox.GetAttribute("value");
                        break;

                    case "building":
                        _progressaDeviceDetailsPage.ProgressaAPMappingBuildingTextBox.GetElementVisibility().Should().BeTrue(textBoxName + " is not displayed");
                        ActualValue = _progressaDeviceDetailsPage.ProgressaAPMappingBuildingTextBox.GetAttribute("value");
                        break;

                    case "floor":
                        _progressaDeviceDetailsPage.ProgressaAPMappingFloorTextBox.GetElementVisibility().Should().BeTrue(textBoxName + " is not displayed");
                        ActualValue = _progressaDeviceDetailsPage.ProgressaAPMappingFloorTextBox.GetAttribute("value");
                        break;

                    case "ap location":
                        _progressaDeviceDetailsPage.ProgressaAPMappingAPLocationTextBox.GetElementVisibility().Should().BeTrue(textBoxName + " is not displayed");
                        ActualValue = _progressaDeviceDetailsPage.ProgressaAPMappingAPLocationTextBox.GetAttribute("value");
                        break;

                    default:
                        Assert.Fail(textBoxName + " is Invalid");
                        break;
                }

                ActualValue.Should().Equals(ExpectedValue);
            }
        }

        [Given(@"manager user is on device details page for Progressa Serial number ""(.*)""")]
        public void GivenManagerUserIsOnDeviceDetailsPageForProgressaSerialNumber(string serialNumber)
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(_landingPage.PSSServiceOrganizationFacilityBatesville, _driver, "Progressa Orgaization");
            _landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.SearchSerialNumberAndClick(serialNumber);
        }

       
        [Given(@"regular user is on device details page for Progressa Serial number ""(.*)""")]
        public void GivenRegularUserIsOnDeviceDetailsPageForProgressaSerialNumber(string serialNumber)
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.StandardUserWithoutRollUpPage);
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.SearchSerialNumberAndClick(serialNumber);
        }

        [Given(@"manager user is on Locate Asset pop-up dialog for Progressa Serial number ""(.*)""")]
        public void GivenManagerUserIsOnLocateAssetPop_UpDialogForProgressaSerialNumber(string serialNumber)
        {
            GivenManagerUserIsOnDeviceDetailsPageForProgressaSerialNumber(serialNumber);
            WhenUserClicksLocateAssetButton();
            ThenLocateAssetPop_UpDialogIsDisplayed();
        }


        [Given(@"regular user is on Locate Asset pop-up dialog for Progressa Serial number ""(.*)""")]
        public void GivenRegularUserIsOnLocateAssetPop_UpDialogForProgressaSerialNumber(string serialNumber)
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.StandardUserWithoutRollUpPage);
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.SearchSerialNumberAndClick(serialNumber);
            WhenUserClicksLocateAssetButton();
            ThenLocateAssetPop_UpDialogIsDisplayed();
        }

       }
}

