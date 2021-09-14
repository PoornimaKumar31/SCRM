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

namespace HillromAutomationFramework.Steps.UpdatesTab.UpgradeUpdate
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5707")]
    class Req5707Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly UpdatesSelectUpdatePage _updatesSelectUpdatePage;

        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverWait _wait;
        private readonly IWebDriver _driver;


        public Req5707Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
            _updatesSelectUpdatePage = new UpdatesSelectUpdatePage(driver);
        }


        [Given(@"user is on Select Updates page")]
        public void GivenUserIsOnSelectUpdatesPage()
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestEastOrganizationFacilityPanelTest4Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.UpdatesTab.JavaSciptClick(_driver);
        }

        [Given(@"CSM Asset type is selected")]
        public void GivenCSMAssetTypeIsSelected()
        {
            _updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.CSMDeviceName);
            string SelectedAssetType = _updatesSelectUpdatePage.AssetTypeDropDown.GetSelectedOptionFromDDL();
            string ExpectedAssetType = UpdatesSelectUpdatePage.ExpectedValues.CSMDeviceName;
            (SelectedAssetType).Should().BeEquivalentTo(ExpectedAssetType, because:"CSM Asset type should be selected when User CSM as Asset type");
        }

        [Given(@"Upgrade Update type is selected")]
        public void GivenUpgradeUpdateTypeIsSelected()
        {
            _updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade);
        }

        [When(@"user clicks Manage Active Updates button")]
        public void WhenUserClicksManageActiveUpdatesButton()
        {
            _updatesSelectUpdatePage.ManageActiveUpgradesButton.Click();
        }

        [Then(@"Manage Upgrades page is displayed"), Then(@"Manage Active Updates page is displayed")]
        public void ThenManageUpgradesPageIsDisplayed()
        {
            (_updatesSelectUpdatePage.ManageUpgradeLabel.GetElementVisibility()).Should().BeTrue(because: "Manage Upgrades page should be displayed when user clicks Manage Active Updates button in CSM Upgrades page");
        }

        [Given(@"user is on Manage Upgrades page")]
        public void GivenUserIsOnManageUpgradesPage()
        {
            GivenUserIsOnSelectUpdatesPage();
            GivenCSMAssetTypeIsSelected();
            GivenUpgradeUpdateTypeIsSelected();
            WhenUserClicksManageActiveUpdatesButton();
            ThenManageUpgradesPageIsDisplayed();
        }

        [Then(@"Destinations label is displayed")]
        public void ThenDestinationsLabelIsDisplayed()
        {
            (_updatesSelectUpdatePage.DestinationLabel.GetElementVisibility()).Should().BeTrue(because: "Destination label should be displayed in CSM Manage Active Upgrades page");
            string DestinationLabelText = _updatesSelectUpdatePage.DestinationLabel.Text;
            (DestinationLabelText).Should().BeEquivalentTo(UpdatesSelectUpdatePage.ExpectedValues.ManageUpgradesDestinationLabel, because: "Destination label should match with the expected value in CSM Manage Active Upgrades page");
        }

        [Then(@"location hierarchy selectors are displayed")]
        public void ThenLocationHierarchySelectorsAreDisplayed()
        {
            _wait.Until(ExplicitWait.ElementExists(By.Id(UpdatesSelectUpdatePage.Locators.ManageUpgradesFirstDeviceID)));
            (_updatesSelectUpdatePage.LocationHeiearchySelector.GetElementVisibility()).Should().BeTrue(because: "Location Heirarchy should be displayed in CSM Manage Active Upgrades page");
        }

        [Then(@"count of selected devices is displayed")]
        public void ThenCountOfSelectedDevicesIsDisplayed()
        {
            (_updatesSelectUpdatePage.CountOfSelectedDevice.GetElementVisibility()).Should().BeTrue(because: "Count of selected device should be displayed in CSM Manage Active Upgrades page");
        }

        [Then(@"Page x of y label is displayed")]
        public void ThenPageXOfYLabelIsDisplayed()
        {
            (_updatesSelectUpdatePage.PaginationXofY.GetElementVisibility()).Should().BeTrue(because: "Page x of y label should be displayed in CSM Manage Active Upgrades page");
        }

        [Then(@"Displaying x to y of z results label is displayed")]
        public void ThenDisplayingXToYOfZResultsLabelIsDisplayed()
        {
            (_updatesSelectUpdatePage.PaginationDisplayXY.GetElementVisibility()).Should().BeTrue(because: "Result label should be displayed in CSM Manage Active Upgrades page");
        }

        [Then(@"Cancel Upgrade button is displayed")]
        public void ThenCancelUpgradeButtonIsDisplayed()
        {
            (_updatesSelectUpdatePage.CancelUpgradeButton.GetElementVisibility()).Should().BeTrue(because: "Cancel Upgrade button should be displayed in CSM Manage Active Upgrades page");
        }

        [Then(@"Cancel Upgrade button is disabled")]
        public void ThenCancelUpgradeButtonIsDisabled()
        {
            (_updatesSelectUpdatePage.CancelUpgradeButton.Enabled).Should().BeFalse(because: "Cancel upgrade button should be disabled since user didn't select any device in CSM Manage Active Upgrades page");
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string HeadingName)
        {
            IWebElement HeadingElement = null;
            switch (HeadingName.ToLower().Trim())
            { 
                case "firmware":
                        HeadingElement = _updatesSelectUpdatePage.ManageUpgradesFirmwareHeading;
                    break;
                case "new firmware":
                        HeadingElement = _updatesSelectUpdatePage.ManageUpgradeNewFirmwareHeading;
                        break;
                case "schedule":
                        HeadingElement = _updatesSelectUpdatePage.ManageUpgradeScheduleHeading;
                        break;
                case "serial number":
                        HeadingElement = _updatesSelectUpdatePage.ManageUpgradeSerialNumberHeading;
                        break;
                case "location":
                        HeadingElement = _updatesSelectUpdatePage.ManageUpgradeLocationHeading;
                        break;

                default:
                        Assert.Fail(HeadingName + " is a invalid heading name");
                        break;
            }
            (HeadingElement.GetElementVisibility()).Should().BeTrue(because: HeadingName + " column heading should be displayed in CSM Manage Active Upgrades page table");
             string ActualHeadingText = HeadingElement.Text;
            (ActualHeadingText).Should().BeEquivalentTo(HeadingName, because: HeadingName + " column heading should match with the expected value in CSM Manage Active Upgrades page table");
        }



        [Then(@"Select all checkbox is in column (.*)")]
        public void ThenSelectAllCheckboxIsInColumn(int columnNumber)
        {
            string firstcolumnId = _updatesSelectUpdatePage.ManageUpgradesTableHeading.FindElements(By.TagName("div"))[columnNumber - 1].FindElement(By.TagName("input")).GetAttribute("id");
            (firstcolumnId).Should().BeEquivalentTo(UpdatesSelectUpdatePage.Locators.ManageUpgradesSelectAllCheckBoxID, because: "Select all checkbox should be in column number " + columnNumber+ " in CSM Manage Active Upgrades page table");
        }

        [Then(@"""(.*)"" label is in column (.*)")]
        public void ThenLabelIsInColumn(string columnHeading, int columnNumber)
        {
            IList<IWebElement> columnsList = _updatesSelectUpdatePage.ManageUpgradesTableHeading.FindElements(By.TagName("div"));

            List<string> columnListText = new List<string>();
            foreach (IWebElement column in columnsList)
            {
                columnListText.Add(column.Text.ToLower());
            }
            //Making as zero based Indexing
            columnNumber--;
            columnListText.Should().HaveElementAt(columnNumber, columnHeading.ToLower(), because: columnHeading + " column heading should be in column number " + columnNumber+ " in CSM Manage Active Upgrades page table");
        }



        [Then(@"Select all checkbox is unchecked")]
        public void ThenSelectAllCheckboxIsUnchecked()
        {
            (_updatesSelectUpdatePage.ManageUpgradesSelectAllCheckBox.Selected).Should().BeFalse(because: "Select all checkbox should be unchecked by default in CSM Manage Active Upgrades page");
        }
        [When(@"user selects device")]
        public void WhenUserSelectsDevice()
        {
            _updatesSelectUpdatePage.ManageUpgradesFirstDevice.Click();
        }

        [When(@"clicks Cancel upgrade button")]
        public void WhenClicksCancelUpgradeButton()
        {
            SetMethods.ScrollToBottomofWebpage(_driver);
            _updatesSelectUpdatePage.CancelUpgradeButton.Click();
        }

        [Then(@"Selected Updates have been cancelled message is displayed")]
        public void ThenSelectedUpdatesHaveBeenCancelledMessageIsDisplayed()
        {
            (_updatesSelectUpdatePage.ManageUpgradesMessage.GetElementVisibility()).Should().BeTrue(because: "Upgrade Cancelled message should be displayed when user clicks enabled cancel button in CSM Manage Active Upgrades page");
            string UpdateCancelMessageText = _updatesSelectUpdatePage.ManageUpgradesMessage.Text;
            (UpdateCancelMessageText).Should().BeEquivalentTo(UpdatesSelectUpdatePage.ExpectedValues.ManageUpgradeCancelMessage, because: "Upgrade Cancelled message should match with the expected value in CSM Manage Active Upgrades page");
        }

    }
}
