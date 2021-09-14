using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.UpdatesTab.ServiceMonitor
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5709")]
    public class Req5709Steps
    {

        private readonly LoginPage _loginPage;
        private readonly MainPage _mainPage;
        private readonly ServiceMonitorPage _serviceMoniterPage ;

        private readonly WebDriverWait _wait;
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public Req5709Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _mainPage = new MainPage(driver);
            _serviceMoniterPage = new ServiceMonitorPage(driver);
        }

        [Given(@"user is on Main page")]
        public void GivenUserIsOnMainPage()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithOutRollUpPage);
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            (_mainPage.AssetsTab.GetElementVisibility()).Should().BeTrue(because:"User should be on the main page after login without roll-up");
        }
        
        [When(@"user clicks Updates")]
        public void WhenUserClicksUpdates()
        {
            _mainPage.UpdatesTab.JavaSciptClick(_driver);
        }
        
        [When(@"user selects Service Monitor")]
        public void WhenUserSelectsServiceMonitor()
        {
            _serviceMoniterPage.AssetTypeDropDown.SelectDDL(ServiceMonitorPage.Inputs.ServiceMoniterText);
        }
        
        [Then(@"Service Monitor Settings page displays")]
        public void ThenServiceMonitorSettingsPageDisplays()
        {
            (_serviceMoniterPage.ServiceMoniterLabel.GetElementVisibility()).Should().BeTrue("Service Monitor Settings page is displayed when user selects Service Monitor");
        }

        [Given(@"user is on Service Monitor Settings page")]
        public void GivenUserIsOnServiceMonitorSettingsPage()
        {
            GivenUserIsOnMainPage();
            _mainPage.UpdatesTab.JavaSciptClick(_driver);
            _serviceMoniterPage.AssetTypeDropDown.SelectDDL(ServiceMonitorPage.Inputs.ServiceMoniterText);
            (_serviceMoniterPage.ServiceMoniterLabel.GetElementVisibility()).Should().BeTrue("Service Monitor Settings page is displayed when user selects Service Monitor");
        }

        [When(@"user clicks Call home period drop-down")]
        public void WhenUserClicksCallHomePeriodDrop_Down()
        {
            (_serviceMoniterPage.CallHomePeriodDropDown.GetElementVisibility()).Should().BeTrue(because: "Call home period drop-down should be displayed in service moniter page");
            _serviceMoniterPage.CallHomePeriodDropDown.Click();
        }

        [Then(@"drop down displays P1D \(24 HOURS\), PT8H \(8 HOURS\), PT4H \(4 HOURS\), PT15M \(15 MINUTES\)")]
        public void ThenDropDownDisplaysPDHOURSPTHHOURSPTHHOURSPTMMINUTES()
        {
            IList<IWebElement> DropdownWebElementList = _serviceMoniterPage.CallHomePeriodDropDown.GetAllOptionsFromDDL();
            List<string> DropDownListText = new List<string>();
            foreach(IWebElement option in DropdownWebElementList)
            {
                DropDownListText.Add(option.Text);
            }
            DropDownListText.Should().BeEquivalentTo(new List<string> { ServiceMonitorPage.ExpectedValues.CallHomePeriodDropdownOptionP1D , ServiceMonitorPage.ExpectedValues.CallHomePeriodDropdownOptionPT8H , ServiceMonitorPage.ExpectedValues.CallHomePeriodDropdownOptionPT4H , ServiceMonitorPage.ExpectedValues.CallHomePeriodDropdownOptionPT15M }, because:"Drop down list should contain only expected options");
        }


        [When(@"user clicks Deployment mode drop-down")]
        public void WhenUserClicksDeploymentModeDrop_Down()
        {
            _serviceMoniterPage.DeploymentModeDropDown.Click();
        }

        [Then(@"drop down displays FALSE, TRUE")]
        public void ThenDropDownDisplaysFALSETRUE()
        {
            IList<IWebElement> Dropdownlist = _serviceMoniterPage.DeploymentModeDropDown.GetAllOptionsFromDDL();
            IList<string> DropDownListString = new List<string>();
            foreach (IWebElement option in Dropdownlist)
            {
                DropDownListString.Add(option.Text);
            }
            DropDownListString.Should().BeEquivalentTo(new List<string> { ServiceMonitorPage.ExpectedValues.DeploymentModeDropdownOptionTrue , ServiceMonitorPage.ExpectedValues.DeploymentModeDropdownOptionFalse }, because: "Deployment mode drop-down should contain only true and false");
        }

        [When(@"user clicks Previous button")]
        public void WhenUserClicksPreviousButton()
        {
            _serviceMoniterPage.PreviousButton.Click();
        }


        [Then(@"Updates page is displayed")]
        public void ThenUpdatesPageIsDisplayed()
        {
            (_serviceMoniterPage.AssetTypeDropDown.GetElementVisibility()).Should().BeTrue(because: "Updates page should display when clicks previous button in service moniter settings page");
        }

        [Given(@"no devices are selected")]
        public void GivenNoDevicesAreSelected()
        {
            (_serviceMoniterPage.DestinationDeviceCount.Text).Should().BeEquivalentTo(ServiceMonitorPage.ExpectedValues.DestinationNoDeviceCountText, "No device should be selected in Service Monitor Settings page intially");
        }

        [Then(@"Service Monitor Settings label is displayed")]
        public void ThenServiceMonitorSettingsLabelIsDisplayed()
        {
            (_serviceMoniterPage.ServiceMoniterLabel.GetElementVisibility()).Should().BeTrue(because: "Service Monitor Settings label should be displayed in Service Monitor Settings page");
            string ActualServiceMoniterSettingsLabelText = _serviceMoniterPage.ServiceMoniterLabel.Text;
            (ActualServiceMoniterSettingsLabelText).Should().BeEquivalentTo(ServiceMonitorPage.ExpectedValues.ServiceMoniterLabel, because: "Service Monitor Settings label text should match with the expected text");
        }

        [Then(@"Call home period label is displayed")]
        public void ThenCallHomePeriodLabelIsDisplayed()
        {
            (_serviceMoniterPage.CallHomePeroidLabel.GetElementVisibility()).Should().BeTrue(because: "Call home period label should be displayed in Service Monitor Settings page");
            string ActualCallHomePeriodLabelText = _serviceMoniterPage.CallHomePeroidLabel.Text;
            (ActualCallHomePeriodLabelText).Should().BeEquivalentTo(ServiceMonitorPage.ExpectedValues.CallHomePeriodLabel, because: "Call home period label text shoud match with the expected text in Service Monitor Settings page");
        }

        [Then(@"Call home period dropdown is displayed")]
        public void ThenCallHomePeriodDropdownIsDisplayed()
        {
            (_serviceMoniterPage.CallHomePeriodDropDown.GetElementVisibility()).Should().BeTrue(because: "Call home period dropdown should be displayed in Service Monitor Settings page");
        }

        [Then(@"Deployment mode label is displayed")]
        public void ThenDeploymentModeLabelIsDisplayed()
        {
            (_serviceMoniterPage.DeploymentModeLabel.GetElementVisibility()).Should().BeTrue(because: "Deployment mode label should be displayed in Service Monitor Settings page");
            string ActualDeploymentModeLabelText = _serviceMoniterPage.DeploymentModeLabel.Text;
            (ActualDeploymentModeLabelText).Should().BeEquivalentTo(ServiceMonitorPage.ExpectedValues.DeploymentModeLabel,because: "Deployment mode label text does not match with the expected text in Service Monitor Settings page");
        }

        [Then(@"Deployment mode drop down is displayed")]
        public void ThenDeploymentModeDropDownIsDisplayed()
        {
            (_serviceMoniterPage.DeploymentModeDropDown.GetElementVisibility()).Should().BeTrue(because: "Deployment mode drop down should be displayed in Service Monitor Settings page");
        }

        [Then(@"Destinations label is displayed")]
        public void ThenDestinationsLabelIsDisplayed()
        {
            (_serviceMoniterPage.DestinationLabel.GetElementVisibility()).Should().BeTrue(because: "Destinations label should be displayed in Service Monitor Settings page");
            string ActualDestinationLabelLabelText = _serviceMoniterPage.DestinationLabel.Text;
            (ActualDestinationLabelLabelText).Should().BeEquivalentTo(ServiceMonitorPage.ExpectedValues.DestinationLabel, because: "Destinations label text should match with the expected text");
        }

        [Then(@"location hierarchy selectors are displayed")]
        public void ThenLocationHierarchySelectorsAreDisplayed()
        {
            (_serviceMoniterPage.LocationHierarchySelectors.GetElementVisibility()).Should().BeTrue(because: "location hierarchy selectors should be displayed in Service Monitor Settings page");
        }

        [Then(@"count of selected devices is displayed")]
        public void ThenCountOfSelectedDevicesIsDisplayed()
        {
            (_serviceMoniterPage.DestinationDeviceCount.GetElementVisibility()).Should().BeTrue(because: "count of selected devices should be displayed in Service Monitor Settings page");
        }

        [Then(@"count of selected locations is displayed")]
        public void ThenCountOfSelectedLocationsIsDisplayed()
        {
            (_serviceMoniterPage.DestinationDeviceCount.GetElementVisibility()).Should().BeTrue(because: "count of selected location should be displayed in Service Monitor Settings page");
        }

        [Then(@"Previous button is enabled")]
        public void ThenPreviousButtonIsEnabled()
        {
            (_serviceMoniterPage.PreviousButton.Enabled).Should().BeTrue(because: "Previous button should be enabled in Service moniter settings page");
        }

        [Then(@"Deploy button is disabled")]
        public void ThenDeployButtonIsDisabled()
        {
            (_serviceMoniterPage.DeployButton.Enabled).Should().BeFalse(because: "Deploy button should not be enabled when no service moniter device is selected.");
        }

        [Then(@"Page x of y label is displayed")]
        public void ThenPageXOfYLabelIsDisplayed()
        {
            (_serviceMoniterPage.PaginationXofY.GetElementVisibility()).Should().BeTrue(because: "Page x of y label should be displayed in Service Monitor Settings page");
        }

        [Then(@"Displaying x to y of z results label is displayed")]
        public void ThenDisplayingXToYOfZResultsLabelIsDisplayed()
        {
            (_serviceMoniterPage.PaginationDisplayXofY.GetElementVisibility()).Should().BeTrue(because: "Displaying x to y of z results label should be displayed in Service Monitor Settings page");
        }

        [Then(@"Select all checkbox is unchecked")]
        public void ThenSelectAllCheckboxIsUnchecked()
        {
            (_serviceMoniterPage.SelectAllCheckBox.Selected).Should().BeFalse(because: "Select all checkbox should be unchecked Intially when service moniter settings page got loaded initially");
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenInColumnIsDisplayed(string headingName)
        {
            IWebElement headingElement=null;
            switch(headingName.ToLower().Trim())
            {
                case "serial number": headingElement = _serviceMoniterPage.SerialNumHeading;
                    break;
                case "call home period":
                    headingElement = _serviceMoniterPage.CallHomePeriodHeading;
                    break;
                case "deployment mode":
                    headingElement = _serviceMoniterPage.DeploymentModeHeading;
                    break;
                case "location":
                    headingElement = _serviceMoniterPage.LocationHeading;
                    break;
                case "last files deployed":
                    headingElement = _serviceMoniterPage.LastFilesDeployedHeading;
                    break;
                default: Assert.Fail(headingName+" does not exist in the test data.\n");
                    break;
            }
            (headingElement.GetElementVisibility()).Should().BeTrue(because: headingName + " column heading should be displayed in service moniter settings page table");
            string ActualColumnHeadingText = headingElement.Text;
            (ActualColumnHeadingText).Should().BeEquivalentTo(headingName, because: headingName + " column heading should match with the expected value");
        }

        [Then(@"Select all checkbox is in column (.*)")]
        public void ThenSelectAllCheckboxIsInColumn(int columnNumber)
        {
            string firstcolumnId = _serviceMoniterPage.TableHeading.FindElements(By.TagName("div"))[columnNumber - 1].FindElement(By.TagName("input")).GetAttribute("id");
            (firstcolumnId).Should().BeEquivalentTo(ServiceMonitorPage.Locators.SelectAllCheckBoxID, because: "Select all checkbox should be displayed in olumn number" + columnNumber);
        }

        [Then(@"""(.*)"" label is in column (.*)")]
        public void ThenLabelIsInColumn(string columnHeading, int columnNumber)
        {
            IList<IWebElement> columnsList = _serviceMoniterPage.TableHeading.FindElements(By.TagName("div"));

            List<string> columnListText = new List<string>();
            foreach (IWebElement column in columnsList)
            {
                columnListText.Add(column.Text.ToLower());
            }
            //Making as zero based Indexing
            columnNumber--;
            columnListText.Should().HaveElementAt(columnNumber, columnHeading.ToLower(), because: columnHeading + " column heading should be in column number " + columnNumber);
        }



        [Given(@"user is on Service Monitor Settings page with ""(.*)"" entries")]
        public void GivenUserIsOnServiceMonitorSettingsPageWithEntries(string noOfEntries)
        {
            switch(noOfEntries)
            {
                case "<=50":
                    GivenUserIsOnServiceMonitorSettingsPage();
                    break;
                default: Assert.Fail(noOfEntries+" is a Invalid no of service moniter");
                    break;
            }
            _wait.Until(ExplicitWait.ElementExists(By.Id(ServiceMonitorPage.Locators.FirstDeviceCheckBoxID)));
        }

        [Then(@"Previous page icon is disabled")]
        public void ThenPreviousPageIconIsDisabled()
        {
            String ActualPreviousIconPageNumberImageSrc = _serviceMoniterPage.PaginationPreviousButton.FindElement(By.TagName("img")).GetAttribute("src");
            (ActualPreviousIconPageNumberImageSrc).Should().BeEquivalentTo(ServiceMonitorPage.ExpectedValues.PaginationPreviousIconDisabledSrc, because: "Previous page button should be disabled in service moniter setting page which has less than 50 devices");
        }

        [Then(@"Next page icon is disabled")]
        public void ThenNextPageIconIsDisabled()
        {
            String ActualPreviousIconPageNumberImageSrc = _serviceMoniterPage.PaginationNextButton.FindElement(By.TagName("img")).GetAttribute("src");
            (ActualPreviousIconPageNumberImageSrc).Should().BeEquivalentTo(ServiceMonitorPage.ExpectedValues.PaginationNextIconDisabledSrc, because: "Next page button should be disabled in service moniter setting page which has less than 50 devices");
        }

        [Given(@"user selects Call home period as P1D \(24 HOURS\)")]
        public void GivenUserSelectsCallHomePeriodAsPDHOURS()
        { 
            _serviceMoniterPage.CallHomePeriodDropDown.SelectDDL(ServiceMonitorPage.ExpectedValues.CallHomePeriodDropdownOptionP1DPatialText, true);
        }

        [Given(@"Deployment mode as FALSE")]
        public void GivenDeploymentModeAsFALSE()
        {
            _serviceMoniterPage.DeploymentModeDropDown.SelectDDL(ServiceMonitorPage.ExpectedValues.DeploymentModeDropdownOptionFalsePartialText,partialMatch:true);
        }


        [When(@"user selects checkbox for first data row in table")]
        public void WhenUserSelectsCheckboxForFirstDataRowInTable()
        {
            _serviceMoniterPage.FirstDeviceCheckBox.Click();
        }

        [Then(@"Upgrade count label updates with selection of row")]
        public void ThenUpgradeCountLabelUpdatedWithSelectionOfRow()
        {
            (_serviceMoniterPage.DestinationDeviceCount.Text).Should().BeEquivalentTo(ServiceMonitorPage.ExpectedValues.Destination1DeviceCountText, because: "Upgrade count label should be updated when user selects one device in service moniter settings page");
        }

        [Then(@"Deploy button is enabled")]
        public void ThenDeployButtonIsEnabled()
        {
            (_serviceMoniterPage.DeployButton.Enabled).Should().BeTrue(because: "Deploy button should be enabled when user selects one device in service moniter settings page");
        }
    }
}
