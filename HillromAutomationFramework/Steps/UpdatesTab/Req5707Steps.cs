using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Updates
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5707")]
    class Req5707Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        UpdatesSelectUpdatePage updatesSelectUpdatePage = new UpdatesSelectUpdatePage();

        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        private ScenarioContext _scenarioContext;

        public Req5707Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        

        [Given(@"user is on Select Updates page")]
        public void GivenUserIsOnSelectUpdatesPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestEastOrganizationFacilityPanelTest4Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.UpdatesTab.JavaSciptClick();
        }

        [Given(@"CSM Asset type is selected")]
        public void GivenCSMAssetTypeIsSelected()
        {
            updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.CSMDeviceName);
            string SelectedAssetType = updatesSelectUpdatePage.AssetTypeDropDown.GetSelectedOptionFromDDL();
            string ExpectedAssetType = UpdatesSelectUpdatePage.ExpectedValues.CSMDeviceName;
            Assert.AreEqual(ExpectedAssetType, SelectedAssetType, "CSM is not selected as asset type.\n");
        }

        [Given(@"Upgrade Update type is selected")]
        public void GivenUpgradeUpdateTypeIsSelected()
        {
            updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade);
        }

        [When(@"user clicks Manage Active Updates button")]
        public void WhenUserClicksManageActiveUpdatesButton()
        {
            updatesSelectUpdatePage.ManageActiveUpgradesButton.Click();
        }

        [Then(@"Manage Upgrades page is displayed")]
        public void ThenManageUpgradesPageIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.ManageUpgradeLabel.GetElementVisibility(), "Manage Upgrades page is not displayed.");
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
            Assert.AreEqual(true, updatesSelectUpdatePage.DestinationLabel.GetElementVisibility(), "Destination label is not displayed");
            Assert.AreEqual(UpdatesSelectUpdatePage.ExpectedValues.ManageUpgradesDestinationLabel, updatesSelectUpdatePage.DestinationLabel.Text, "Destination label is not matching with the expected value.");
        }

        [Then(@"location hierarchy selectors are displayed")]
        public void ThenLocationHierarchySelectorsAreDisplayed()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(UpdatesSelectUpdatePage.Locators.ManageUpgradesFirstDeviceID)));
            Assert.AreEqual(true, updatesSelectUpdatePage.LocationHeiearchySelector.GetElementVisibility(), "Location Heirarchy label is not displayed");
        }

        [Then(@"count of selected devices is displayed")]
        public void ThenCountOfSelectedDevicesIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.CountOfSelectedDevice.GetElementVisibility(), "Count of device is not displayed");
        }

        [Then(@"Page x of y label is displayed")]
        public void ThenPageXOfYLabelIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.PaginationXofY.GetElementVisibility(), "Pagination label is not displayed");
        }

        [Then(@"Displaying x to y of z results label is displayed")]
        public void ThenDisplayingXToYOfZResultsLabelIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.PaginationDisplayXY.GetElementVisibility(), "Result label is not displayed");
        }

        [Then(@"Cancel Upgrade button is displayed")]
        public void ThenCancelUpgradeButtonIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.CancelUpgradeButton.GetElementVisibility(), "CancelUpgrade button is not displayed");
        }

        [Then(@"Cancel Upgrade button is disabled")]
        public void ThenCancelUpgradeButtonIsDisabled()
        {
            Assert.AreEqual(false, updatesSelectUpdatePage.CancelUpgradeButton.Enabled,"Button is Enabled");
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string HeadingName)
        {
            IWebElement HeadingElement = null;
            string ExpectedHeadingText = null;
            switch (HeadingName.ToLower().Trim())
            { 
            case "firmware":
                    HeadingElement = updatesSelectUpdatePage.ManageUpgradesFirmwareHeading;
                ExpectedHeadingText = UpdatesSelectUpdatePage.ExpectedValues.FirmwareHeadingText;
                break;
            case "new firmware":
                    HeadingElement = updatesSelectUpdatePage.ManageUpgradeNewFirmwareHeading;
                    ExpectedHeadingText = UpdatesSelectUpdatePage.ExpectedValues.NewFirmwareHeadingText;
                    break;
            case "schedule":
                    HeadingElement = updatesSelectUpdatePage.ManageUpgradeScheduleHeading;
                    ExpectedHeadingText = UpdatesSelectUpdatePage.ExpectedValues.ScheduleHeadingText;
                    break;
            case "serial number":
                    HeadingElement = updatesSelectUpdatePage.ManageUpgradeSerialNumberHeading;
                    ExpectedHeadingText = UpdatesSelectUpdatePage.ExpectedValues.SerialNumberHeadingText;
                    break;
            case "location":
                    HeadingElement = updatesSelectUpdatePage.ManageUpgradeLocationHeading;
                    ExpectedHeadingText = UpdatesSelectUpdatePage.ExpectedValues.LocationHeadingText;
                    break;

            default:
                    Assert.Fail(HeadingName + " is a invalid heading name");
                    break;
        }
             Assert.AreEqual(true, HeadingElement.GetElementVisibility(), HeadingName + " is not displayed.");
             string ActualHeadingText = HeadingElement.Text.ToLower();
             Assert.AreEqual(ExpectedHeadingText.ToLower(), ActualHeadingText, HeadingName + " not matches with the expected value");
        }



        [Then(@"Select all checkbox is in column (.*)")]
        public void ThenSelectAllCheckboxIsInColumn(int columnNumber)
        {
            string firstcolumnId = updatesSelectUpdatePage.ManageUpgradesTableHeading.FindElements(By.TagName("div"))[columnNumber - 1].FindElement(By.TagName("input")).GetAttribute("id");
            Assert.AreEqual("selectall", firstcolumnId, "Select all checkbox is not in column " + columnNumber);
        }

        [Then(@"""(.*)"" label is in column (.*)")]
        public void ThenLabelIsInColumn(string columnHeading, int columnNumber)
        {
            IList<IWebElement> columns = updatesSelectUpdatePage.ManageUpgradesTableHeading.FindElements(By.TagName("div"));
            Assert.AreEqual(columnHeading.ToLower().Trim(), columns[columnNumber - 1].Text.ToLower(), columnHeading + " is not in " + columnNumber);
        }



        [Then(@"Select all checkbox is unchecked")]
        public void ThenSelectAllCheckboxIsUnchecked()
        {
            Assert.AreEqual(false, updatesSelectUpdatePage.ManageUpgradesSelectAllCheckBox.Selected, "Select all checkbox in column 1 is not displayed");
        }
        [When(@"user selects device")]
        public void WhenUserSelectsDevice()
        {
            updatesSelectUpdatePage.ManageUpgradesFirstDevice.Click();
        }

        [When(@"clicks Cancel upgrade button")]
        public void WhenClicksCancelUpgradeButton()
        {
            SetMethods.ScrollToBottomofWebpage();
            updatesSelectUpdatePage.CancelUpgradeButton.Click();
        }

        [Then(@"Selected Updates have been cancelled message is displayed")]
        public void ThenSelectedUpdatesHaveBeenCancelledMessageIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.ManageUpgradesMessage.GetElementVisibility(), "Upgrade Cancelled message is not displayed.");
            Assert.AreEqual(UpdatesSelectUpdatePage.ExpectedValues.ManageUpgradeCancelMessage, updatesSelectUpdatePage.ManageUpgradesMessage.Text, "Upgrade Cancelled message is not matching the expected value.");
        }

        [Then(@"Manage Active Updates page is displayed")]
        public void ThenManageActiveUpdatesPageIsDisplayed()
        {
            ThenManageUpgradesPageIsDisplayed();
        }

    }
}
