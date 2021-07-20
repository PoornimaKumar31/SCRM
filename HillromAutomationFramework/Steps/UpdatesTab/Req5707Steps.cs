using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Updates
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5707")]
    class Req5707Steps
    {
        private ScenarioContext _scenarioContext;
        public Req5707Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        LoginPage loginPage = new LoginPage();
        CSMUpdatesPage csmUpdatesPage = new CSMUpdatesPage();
        MainPage mainPage = new MainPage();
        CSMConfigDeliverPage csmConfigDeliverPage = new CSMConfigDeliverPage();

        [Given(@"user is on Select Updates page")]
        public void GivenUserIsOnSelectUpdatesPage()
        {
            loginPage.SignIn("AdminWithoutRollUp");
            mainPage.UpdatesTab.JavaSciptClick();
        }

        [Given(@"CSM Asset type is selected")]
        public void GivenCSMAssetTypeIsSelected()
        {
            csmUpdatesPage.AssetTypeDDL.SelectDDL(CSMConfigDeliverPage.ExpectedValues.CSMDeviceName);
            string SelectedAssetType = csmUpdatesPage.AssetTypeDDL.GetSelectedOptionFromDDL();
            string ExpectedAssetType = CSMConfigDeliverPage.ExpectedValues.CSMDeviceName;
            Assert.AreEqual(ExpectedAssetType, SelectedAssetType, "CSM is not selected as asset type.\n");
        }

        [Given(@"Upgrade Update type is selected")]
        public void GivenUpgradeUpdateTypeIsSelected()
        {
            csmUpdatesPage.UpdateTypeDDL.SelectDDL(CSMUpdatesPage.ExpectedValue.UpdateTypeUpgrade);
        }

        [When(@"user clicks Manage Active Updates button")]
        public void WhenUserClicksManageActiveUpdatesButton()
        {
            csmUpdatesPage.ManageActiveUpdate.Click();
        }

        [Then(@"Manage Upgrades page is displayed")]
        public void ThenManageUpgradesPageIsDisplayed()
        {
            Assert.AreEqual(true, csmUpdatesPage.ManageUpgradeLabel.GetElementVisibility(), "Element is not visible");
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
            Assert.AreEqual(true, csmUpdatesPage.DestinationLabel.GetElementVisibility(), "Destination label is not displayed");
        }

        [Then(@"location hierarchy selectors are displayed")]
        public void ThenLocationHierarchySelectorsAreDisplayed()
        {
            //Assert.AreEqual(true, csmUpdatesPage.LocationHeiearchySelector.GetElementVisibility(), "Location Heirarchy label is not displayed");
        }

        [Then(@"count of selected devices is displayed")]
        public void ThenCountOfSelectedDevicesIsDisplayed()
        {
            Assert.AreEqual(true, csmUpdatesPage.CountOfSelectedDevice.GetElementVisibility(), "Count of device is not displayed");
        }

        [Then(@"Page x of y label is displayed")]
        public void ThenPageXOfYLabelIsDisplayed()
        {
            Assert.AreEqual(true, csmUpdatesPage.PaginationLabel.GetElementVisibility(), "Pagination label is not displayed");
        }

        [Then(@"Displaying x to y of z results label is displayed")]
        public void ThenDisplayingXToYOfZResultsLabelIsDisplayed()
        {
            Assert.AreEqual(true, csmUpdatesPage.ResultLabel.GetElementVisibility(), "Result label is not displayed");
        }

        [Then(@"Cancel Upgrade button is displayed")]
        public void ThenCancelUpgradeButtonIsDisplayed()
        {
            Assert.AreEqual(true, csmUpdatesPage.CancelUpgradeButton.GetElementVisibility(), "CancelUpgrade button is not displayed");
        }

        [Then(@"Cancel Upgrade button is disabled")]
        public void ThenCancelUpgradeButtonIsDisabled()
        {
            Assert.AreEqual(false, csmUpdatesPage.CancelUpgradeButton.Enabled,"Button is Enabled");
        }

        [Then(@"column (.*) heading ""(.*)"" is displayed")]
        public void ThenColumnHeadingFirmwareIsDisplayed(int p0, string HeadingName)
        {
            IWebElement HeadingElement = null;
            string ExpectedHeadingText = null;
            switch (HeadingName.ToLower().Trim())
            { 
            case "firmware":
                    HeadingElement = csmConfigDeliverPage.FirmwareHeading;
                ExpectedHeadingText = CSMConfigDeliverPage.ExpectedValues.FirmwareHeadingText;
                break;
            case "new firmware":
                    HeadingElement = csmUpdatesPage.NewFirmware;
                    ExpectedHeadingText = CSMUpdatesPage.ExpectedValue.NewFirmwareExpectedValue;
                    break;
            case "schedule":
                    HeadingElement = csmUpdatesPage.Schedule;
                    ExpectedHeadingText = CSMUpdatesPage.ExpectedValue.ScheduleExpectedValue;
                    break;
            case "serial number":
                    HeadingElement = csmUpdatesPage.SerialNumber;
                    ExpectedHeadingText = CSMUpdatesPage.ExpectedValue.SerialNumberExpectedValue;
                    break;
            case "location":
                    HeadingElement = csmConfigDeliverPage.LocationHeading;
                    ExpectedHeadingText = CSMConfigDeliverPage.ExpectedValues.LocationHeadingText;
                    break;

            default:
                    Assert.Fail(HeadingName + " is a invalid heading name");
            break;
        }
             Assert.AreEqual(true, HeadingElement.GetElementVisibility(), HeadingName + " is not displayed.");
             string ActualHeadingText = HeadingElement.Text.ToLower();
             Assert.AreEqual(ExpectedHeadingText.ToLower(), ActualHeadingText, HeadingName + " not matches with the expected value");
        }

        [Then(@"Select all checkbox in column 1 is unchecked")]
        public void ThenSelectAllCheckboxInColumnIsUnchecked()
        {
            //Assert.AreEqual(true, csmConfigDeliverPage.SelectAllDeviceCheckBox.Displayed, "Select all checkbox in column 1 is not displayed");
        }
        [When(@"user selects device")]
        public void WhenUserSelectsDevice()
        {
            _scenarioContext.Pending();
        }

        [When(@"clicks Cancel upgrade button")]
        public void WhenClicksCancelUpgradeButton()
        {
            _scenarioContext.Pending();
        }

        [Then(@"Selected Updates have been cancelled message is displayed")]
        public void ThenSelectedUpdatesHaveBeenCancelledMessageIsDisplayed()
        {
            _scenarioContext.Pending();
        }

        [Then(@"Upgrade is cancelled")]
        public void ThenUpgradeIsCancelled()
        {
            _scenarioContext.Pending();
        }

        [Then(@"Manage Active Updates page is displayed")]
        public void ThenManageActiveUpdatesPageIsDisplayed()
        {
            _scenarioContext.Pending();
        }

    }
}
