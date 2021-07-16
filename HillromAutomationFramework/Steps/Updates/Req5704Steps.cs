using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Updates
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5704")]
    public class Req5704Steps
    {
        LoginPage loginPage = new LoginPage();
        MainPage mainPage = new MainPage();
        CSMConfigDeliverPage csmConfigDeliverPage = new CSMConfigDeliverPage();
        private ScenarioContext _scenarioContext;

        public Req5704Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"user is on Updates page")]
        public void GivenUserIsOnUpdatesPage()
        {
            loginPage.SignIn("AdminWithoutRollUp");
            mainPage.UpdatesTab.JavaSciptClick();
        }

        [When(@"user selects CSM Asset type")]
        public void WhenUserSelectsCSMAssetType()
        {
            csmConfigDeliverPage.AssetTypeDropDown.SelectDDL(CSMConfigDeliverPage.ExpectedValues.CSMDeviceName);
        }

        [Then(@"CSM displays as Asset type")]
        public void ThenCSMDisplaysAsAssetType()
        {
            string SelectedAssetType = csmConfigDeliverPage.AssetTypeDropDown.GetSelectedOptionFromDDL();
            string ExpectedAssetType = CSMConfigDeliverPage.ExpectedValues.CSMDeviceName;
            Assert.AreEqual(ExpectedAssetType, SelectedAssetType,"CSM is not selected as asset type.\n");
        }

        [Then(@"Update type drop down contains Upgrade and Configuration entries")]
        public void ThenUpdateTypeDropDownContainsUpgradeAndConfigurationEntries()
        {
            IList<IWebElement> DropdownElements = csmConfigDeliverPage.UpdateTypeDropDown.GetAllOptionsFromDDL();
            List<string> DropDownOptionsList = new List<string>();
            foreach(IWebElement option in DropdownElements)
            {
                DropDownOptionsList.Add(option.Text);
            }
            //3 options are present(including select).
            Assert.AreEqual(true, DropDownOptionsList.Count == 3, "Update Type dropdown has more than 2 options");
            Assert.AreEqual(true, DropDownOptionsList.Contains(CSMConfigDeliverPage.ExpectedValues.UpdateTypeConfiguration), "Configuration option is not available on the Update type dropdown");
            Assert.AreEqual(true, DropDownOptionsList.Contains(CSMConfigDeliverPage.ExpectedValues.UpdateTypeUpgrade), "Upgrade option is not available on the Update type dropdown");
        }

        [Given(@"user is on CSM Updates page")]
        public void GivenUserIsOnCSMUpdatesPage()
        {
            loginPage.SignIn("AdminWithoutRollUp");
            mainPage.UpdatesTab.JavaSciptClick();
        }

        [Given(@"CSM Asset type is selected")]
        public void GivenCSMAssetTypeIsSelected()
        {
            csmConfigDeliverPage.AssetTypeDropDown.SelectDDL(CSMConfigDeliverPage.ExpectedValues.CSMDeviceName);
        }

        [When(@"user selects Configuration Update type")]
        public void WhenUserSelectsConfigurationUpdateType()
        {
            csmConfigDeliverPage.UpdateTypeDropDown.SelectDDL(CSMConfigDeliverPage.ExpectedValues.UpdateTypeConfiguration);
        }

        [Then(@"Configuration displays as Update type")]
        public void ThenConfigurationDisplaysAsUpdateType()
        {
            string SelectedUpdateType = csmConfigDeliverPage.UpdateTypeDropDown.GetSelectedOptionFromDDL();
            string ExpectedUpdateType = CSMConfigDeliverPage.ExpectedValues.UpdateTypeConfiguration;
            Assert.AreEqual(ExpectedUpdateType, SelectedUpdateType, "Configuration is not selected as Update type.\n");
        }

        [Then(@"CSM configuration list is displayed")]
        public void ThenCSMConfigurationListIsDisplayed()
        {
            Assert.AreEqual(true, csmConfigDeliverPage.ConfigList.GetElementVisibility(), "Configuration list is not displayed");
        }

        [Then(@"Name column 1 heading is displayed")]
        public void ThenNameColumnHeadingIsDisplayed()
        {
            Assert.AreEqual(true, csmConfigDeliverPage.ConfigListTableNameHeading.GetElementVisibility(), "Name column 1 heading is not displayed");
            string ActualHeadingText = csmConfigDeliverPage.ConfigListTableNameHeading.Text;
            string ExpectedHeadingText = CSMConfigDeliverPage.ExpectedValues.ConfigListTableNameHeadingText;
            Assert.AreEqual(ExpectedHeadingText, ActualHeadingText, "Configuration list table name heading text is not matching with the expected value.");
        }

        [Then(@"Date created column 2 heading is displayed")]
        public void ThenDateCreatedColumnHeadingIsDisplayed()
        {
            Assert.AreEqual(true, csmConfigDeliverPage.ConfigListTableDateHeading.GetElementVisibility(), "Date column 2 heading is not displayed");
            string ActualHeadingText = csmConfigDeliverPage.ConfigListTableDateHeading.Text;
            string ExpectedHeadingText = CSMConfigDeliverPage.ExpectedValues.ConfigListTableDateHeadingText;
            Assert.AreEqual(ExpectedHeadingText, ActualHeadingText, "Configuration list table date heading text is not matching with the expected value.");
        }

        [Then(@"Next button is disabled")]
        public void ThenNextButtonIsDisabled()
        {
            Assert.AreEqual(false, csmConfigDeliverPage.SelectUpdateNextButton.Enabled, "Next button is not disabled.");
        }

        [Then(@"Page x of y label is displayed")]
        public void ThenPageXOfYLabelIsDisplayed()
        {
            Assert.AreEqual(true, csmConfigDeliverPage.PaginationXOfY.GetElementVisibility(), "Page x of y is not displayed");
        }

        [Then(@"Displaying x to y of z label is displayed")]
        public void ThenDisplayingXToYOfZLabelIsDisplayed()
        {
            Assert.AreEqual(true, csmConfigDeliverPage.PaginationDisplayXY.GetElementVisibility(), "Displaying x to y of z label is not displayed");
        }

        [Given(@"Configuration Update type is selected")]
        public void GivenConfigurationUpdateTypeIsSelected()
        {
            csmConfigDeliverPage.UpdateTypeDropDown.SelectDDL(CSMConfigDeliverPage.ExpectedValues.UpdateTypeConfiguration);
        }

        [Given(@"Configuration list is not empty")]
        public void GivenConfigurationListIsNotEmpty()
        {
            Assert.AreEqual(true,csmConfigDeliverPage.ConfigFileName.GetElementCount()>0,"Configuration list is empty"); 
        }

        [Then(@"configuration files are sorted in ascending alphabetical order")]
        public void ThenConfigurationFilesAreSortedInAscendingAlphabeticalOrder()
        {
            Assert.AreEqual(true, csmConfigDeliverPage.IsConfigFileSorted(csmConfigDeliverPage.ConfigFileName), "Configuration files are not sorted in alphabetical order");
        }

        [Given(@"user is on CSM Updates page with ""(.*)"" entries")]
        public void GivenUserIsOnCSMUpdatesPageWithEntries(string noOfEntries)
        {
            switch(noOfEntries)
            {
                case "<= 50": _scenarioContext.Pending();
                    break;
                case "> 50":
                case "> 50 and <= 100":
                    GivenUserIsOnCSMUpdatesPage();
                    csmConfigDeliverPage.AssetTypeDropDown.SelectDDL(CSMConfigDeliverPage.ExpectedValues.CSMDeviceName);
                    csmConfigDeliverPage.UpdateTypeDropDown.SelectDDL(CSMConfigDeliverPage.ExpectedValues.UpdateTypeConfiguration);
                    break;
                default: Assert.Fail("Invalid no of entries:" + noOfEntries);
                    break;
            }
        }

        [Given(@"user is on page 1")]
        public void GivenUserIsOnPage()
        {
            SetMethods.ScrollToBottomofWebpage();
            string PageNumber = csmConfigDeliverPage.PaginationXOfY.Text;
            Assert.AreEqual(true, PageNumber.StartsWith("Page 1"), "User is not on page 1.");
        }

        [Then(@"Previous page icon is disabled")]
        public void ThenPreviousPageIconIsDisabled()
        {
            string PageNumberBeforeClick = csmConfigDeliverPage.PaginationXOfY.Text;
            csmConfigDeliverPage.PaginationPreviousIcon.JavaSciptClick();
            string PageNumberAfterClick = csmConfigDeliverPage.PaginationXOfY.Text;
            Assert.AreEqual(PageNumberBeforeClick, PageNumberAfterClick, "Previous page icon is not disabled.");
        }

        [Then(@"Next page icon is enabled")]
        public void ThenNextPageIconIsEnabled()
        {
            string PageNumberBeforeClick = csmConfigDeliverPage.PaginationXOfY.Text;
            csmConfigDeliverPage.PaginationNextIcon.JavaSciptClick();
            string PageNumberAfterClick = csmConfigDeliverPage.PaginationXOfY.Text;
            Assert.AreNotEqual(PageNumberBeforeClick, PageNumberAfterClick, "Next page icon is not enabled.");
        }

        [When(@"user clicks Next page icon")]
        public void WhenUserClicksNextPageIcon()
        {
           // SetMethods.ScrollToBottomofWebpage();
            csmConfigDeliverPage.PaginationNextIcon.JavaSciptClick();
        }

        [Then(@"second page of entries is displayed")]
        public void ThenSecondPageOfEntriesIsDisplayed()
        {
            //Thread.Sleep(2000);
            Assert.AreEqual(true, csmConfigDeliverPage.ConfigFileName.Count > 0, "Second Page entries are not displayesd.");
            Assert.AreEqual("Vanilla 9", csmConfigDeliverPage.ConfigFileName[0].Text);
        }

        [Then(@"Next page icon is disabled")]
        public void ThenNextPageIconIsDisabled()
        {
            string PageNumberBeforeClick = csmConfigDeliverPage.PaginationXOfY.Text;
            csmConfigDeliverPage.PaginationNextIcon.JavaSciptClick();
            string PageNumberAfterClick = csmConfigDeliverPage.PaginationXOfY.Text;
            Assert.AreEqual(PageNumberBeforeClick, PageNumberAfterClick, "Next page icon is not disabled.");
        }

        [Then(@"Previous page icon is enabled")]
        public void ThenPreviousPageIconIsEnabled()
        {
            string PageNumberBeforeClick = csmConfigDeliverPage.PaginationXOfY.Text;
            csmConfigDeliverPage.PaginationPreviousIcon.JavaSciptClick();
            string PageNumberAfterClick = csmConfigDeliverPage.PaginationXOfY.Text;
            Assert.AreEqual(PageNumberBeforeClick, PageNumberAfterClick, "Previous page icon is not enabled.");
        }

        [Given(@"configuration file is selected")]
        public void GivenConfigurationFileIsSelected()
        {
            csmConfigDeliverPage.FirstConfigFile.Click();
        }

        [When(@"user clicks Next button")]
        public void WhenUserClicksNextButton()
        {
            csmConfigDeliverPage.SelectUpdateNextButton.Click();
        }

        [Then(@"CSM Select devices page is displayed")]
        public void ThenCSMSelectDevicesPageIsDisplayed()
        {
            bool result = (csmConfigDeliverPage.ItemToPushLabel.GetElementVisibility()) || (csmConfigDeliverPage.DestinationDeviceCount.GetElementVisibility());
            Assert.AreEqual(true,result , "User is not on Select devices page.");
        }

        [Given(@"user is on CSM Configuration Select assets page")]
        public void GivenUserIsOnCSMConfigurationSelectAssetsPage()
        {
            GivenUserIsOnCSMUpdatesPage();
            csmConfigDeliverPage.AssetTypeDropDown.SelectDDL(CSMConfigDeliverPage.ExpectedValues.CSMDeviceName);
            csmConfigDeliverPage.UpdateTypeDropDown.SelectDDL(CSMConfigDeliverPage.ExpectedValues.UpdateTypeConfiguration);
            csmConfigDeliverPage.FirstConfigFile.Click();
            csmConfigDeliverPage.SelectUpdateNextButton.Click();
        }

        [Then(@"Select update indicator is not highlighted")]
        public void ThenSelectUpdateIndicatorIsNotHighlighted()
        {
            Assert.AreNotEqual(CSMConfigDeliverPage.ExpectedValues.HighlightedCircleClassName,csmConfigDeliverPage.SelectUpdateCircle.GetAttribute("class"), "Select update indicator is highlighted"); 
        }

        [Then(@"Select devices indicator is highlighted")]
        public void ThenSelectDevicesIndicatorIsHighlighted()
        {
            Assert.AreEqual(CSMConfigDeliverPage.ExpectedValues.HighlightedCircleClassName, csmConfigDeliverPage.SelectDevicesCircle.GetAttribute("class"), "Select devices indicator is not highlighted");
        }

        [Then(@"Review action indicator is not highlighted")]
        public void ThenReviewActionIndicatorIsNotHighlighted()
        {
            Assert.AreNotEqual(CSMConfigDeliverPage.ExpectedValues.HighlightedCircleClassName, csmConfigDeliverPage.ReviewActionCircle.GetAttribute("class"), "Review action indicator is highlighted");
        }

        [Then(@"""(.*)"" label is displayed")]
        public void ThenLabelIsDisplayed(string labelName)
        {
            IWebElement labelElement=null;
            switch(labelName.ToLower().Trim())
            {
                case "item to push": labelElement = csmConfigDeliverPage.ItemToPushLabel;
                    break;
                case "device type":
                    labelElement = csmConfigDeliverPage.DeviceType;
                    break;
                case "update type":
                    labelElement = csmConfigDeliverPage.UpdateType;
                    break;
                case "config file to push":
                    labelElement = csmConfigDeliverPage.ConfigFileToPush;
                    break;
                case "destinations":
                    labelElement = csmConfigDeliverPage.DestinationLabel;
                    break;
                default: Assert.Fail(labelName + " is an invalid label name");
                    break;
            }
            Assert.AreEqual(true, labelElement.GetElementVisibility(), labelName+" label is not dispalyed");
        }

        [Then(@"location hierarchy selectors are displayed")]
        public void ThenLocationHierarchySelectorsAreDisplayed()
        {
            Assert.AreEqual(true, csmConfigDeliverPage.LocationHirarcy.GetElementVisibility(), "location hierarchy selectors are not displayed");
        }

        [Then(@"count of selected devices is displayed")]
        public void ThenCountOfSelectedDevicesIsDisplayed()
        {
            Assert.AreEqual(true, csmConfigDeliverPage.DestinationDeviceCount.GetElementVisibility(), "count of selected devices is not displayed");
        }

        [Then(@"Previous button is enabled")]
        public void ThenPreviousButtonIsEnabled()
        {
            Assert.AreEqual(true, csmConfigDeliverPage.PreviousButton.Enabled, "Previous button is enabled");
        }

        [Then(@"Next button is disabled in select device page")]
        public void ThenNextButtonIsDisabledInSelectDevicePage()
        {
            Assert.AreEqual(false, csmConfigDeliverPage.SelectDeviceNextButton.Enabled, "Next button is not disabled in select device page");
        }

        [Then(@"Select all checkbox in column 1 is displayed")]
        public void ThenSelectAllCheckboxInColumnIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"""(.*)"" column (.*) heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }

      

    }
}
