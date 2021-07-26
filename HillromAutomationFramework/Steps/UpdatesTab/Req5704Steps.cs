using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Updates
{
    [Binding, Scope(Tag = "SoftwareRequirementID_5704")]
    public class Req5704Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        UpdatesSelectUpdatePage updatesSelectUpdatePage = new UpdatesSelectUpdatePage();
        UpdateSelectDevicesPage updateSelectDevicesPage = new UpdateSelectDevicesPage();
        UpdateReviewActionPage updateReviewActionPage = new UpdateReviewActionPage();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10)); 
        private ScenarioContext _scenarioContext;

        public Req5704Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"user is on Updates page")]
        public void GivenUserIsOnUpdatesPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.Organization1Facility0Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.UpdatesTab.JavaSciptClick();
        }

        [When(@"user selects CSM Asset type")]
        public void WhenUserSelectsCSMAssetType()
        {
            updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.CSMDeviceName);
        }

        [Then(@"CSM displays as Asset type")]
        public void ThenCSMDisplaysAsAssetType()
        {
            string SelectedAssetType = updatesSelectUpdatePage.AssetTypeDropDown.GetSelectedOptionFromDDL();
            string ExpectedAssetType = UpdatesSelectUpdatePage.ExpectedValues.CSMDeviceName;
            Assert.AreEqual(ExpectedAssetType, SelectedAssetType, "CSM is not selected as asset type.\n");
        }

        [Then(@"Update type drop down contains Upgrade and Configuration entries")]
        public void ThenUpdateTypeDropDownContainsUpgradeAndConfigurationEntries()
        {
            IList<IWebElement> DropdownElements = updatesSelectUpdatePage.UpgradeTypeDropDown.GetAllOptionsFromDDL();
            List<string> DropDownOptionsList = new List<string>();
            foreach (IWebElement option in DropdownElements)
            {
                DropDownOptionsList.Add(option.Text);
            }
            //3 options are present(including select).
            Assert.AreEqual(true, DropDownOptionsList.Count == 3, "Update Type dropdown has more than 2 options");
            Assert.AreEqual(true, DropDownOptionsList.Contains(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeConfiguration), "Configuration option is not available on the Update type dropdown");
            Assert.AreEqual(true, DropDownOptionsList.Contains(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade), "Upgrade option is not available on the Update type dropdown");
        }

        [Given(@"user is on CSM Updates page")]
        public void GivenUserIsOnCSMUpdatesPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.Organization1Facility0Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.UpdatesTab.JavaSciptClick();
        }

        [Given(@"CSM Asset type is selected")]
        public void GivenCSMAssetTypeIsSelected()
        {
            updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.CSMDeviceName);
        }

        [When(@"user selects Configuration Update type")]
        public void WhenUserSelectsConfigurationUpdateType()
        {
            updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeConfiguration);
        }

        [Then(@"Configuration displays as Update type")]
        public void ThenConfigurationDisplaysAsUpdateType()
        {
            string SelectedUpdateType = updatesSelectUpdatePage.UpgradeTypeDropDown.GetSelectedOptionFromDDL();
            string ExpectedUpdateType = UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeConfiguration;
            Assert.AreEqual(ExpectedUpdateType, SelectedUpdateType, "Configuration is not selected as Update type.\n");
        }

        [Then(@"CSM configuration list is displayed")]
        public void ThenCSMConfigurationListIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.ConfigList.GetElementVisibility(), "Configuration list is not displayed");
        }

        [Then(@"Name column 1 heading is displayed")]
        public void ThenNameColumnHeadingIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.NameColumnHeading.GetElementVisibility(), "Name column 1 heading is not displayed");
            string ActualHeadingText = updatesSelectUpdatePage.NameColumnHeading.Text;
            string ExpectedHeadingText = UpdatesSelectUpdatePage.ExpectedValues.TableNameHeadingText;
            Assert.AreEqual(ExpectedHeadingText, ActualHeadingText, "Configuration list table name heading text is not matching with the expected value.");
        }

        [Then(@"Date created column 2 heading is displayed")]
        public void ThenDateCreatedColumnHeadingIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.DateColumnHeading.GetElementVisibility(), "Date column 2 heading is not displayed");
            string ActualHeadingText = updatesSelectUpdatePage.DateColumnHeading.Text;
            string ExpectedHeadingText = UpdatesSelectUpdatePage.ExpectedValues.TableDateHeadingText;
            Assert.AreEqual(ExpectedHeadingText, ActualHeadingText, "Configuration list table date heading text is not matching with the expected value.");
        }

        [Then(@"Next button is disabled")]
        public void ThenNextButtonIsDisabled()
        {
            Assert.AreEqual(false, updatesSelectUpdatePage.NextButton.Enabled, "Next button is not disabled.");
        }

        [Then(@"Page x of y label is displayed")]
        public void ThenPageXOfYLabelIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.PaginationXofY.GetElementVisibility(), "Page x of y is not displayed");
        }

        [Then(@"Displaying x to y of z label is displayed")]
        public void ThenDisplayingXToYOfZLabelIsDisplayed()
        {
            SetMethods.ScrollToBottomofWebpage();
            Assert.AreEqual(true, updatesSelectUpdatePage.PaginationDisplayXY.GetElementVisibility(), "Displaying x to y of z label is not displayed");
        }

        [Given(@"Configuration Update type is selected")]
        public void GivenConfigurationUpdateTypeIsSelected()
        {
            updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeConfiguration);
        }

        [Given(@"Configuration list is not empty")]
        public void GivenConfigurationListIsNotEmpty()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.FileNameList.GetElementCount()> 0, "Configuration list is empty");
        }

        [Then(@"configuration files are sorted in ascending alphabetical order")]
        public void ThenConfigurationFilesAreSortedInAscendingAlphabeticalOrder()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.IsFileSorted(updatesSelectUpdatePage.FileNameList), "Configuration files are not sorted in alphabetical order");
        }

        [Given(@"user is on CSM Updates page with ""(.*)"" entries")]
        public void GivenUserIsOnCSMUpdatesPageWithEntries(string noOfEntries)
        {
            switch (noOfEntries)
            {
                case "<= 50": 
                    loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
                    landingPage.Organization1Facility1Title.Click();
                    break;
                case "> 50":
                    loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
                    landingPage.Organization1Facility0Title.Click();
                    break;
                case "> 50 and <= 100":
                    loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
                    landingPage.Organization1Facility0Title.Click();
                    break;
                default: Assert.Fail("Invalid no of entries:" + noOfEntries);
                    break;
            }
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.UpdatesTab.JavaSciptClick();
            updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.CSMDeviceName);
            updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeConfiguration);
        }

        [Given(@"user is on page 1")]
        public void GivenUserIsOnPage()
        {
            SetMethods.ScrollToBottomofWebpage();
            string PageNumber = updatesSelectUpdatePage.PaginationXofY.Text;
            Assert.AreEqual(true, PageNumber.StartsWith("Page 1"), "User is not on page 1.");
        }

        [Then(@"Previous page icon is disabled")]
        public void ThenPreviousPageIconIsDisabled()
        {
            string PageNumberBeforeClick = updatesSelectUpdatePage.PaginationXofY.Text;
            updatesSelectUpdatePage.PaginationPreviousIcon.JavaSciptClick();
            string PageNumberAfterClick = updatesSelectUpdatePage.PaginationXofY.Text;
            Assert.AreEqual(PageNumberBeforeClick, PageNumberAfterClick, "Previous page icon is not disabled.");
        }

        [Then(@"Next page icon is enabled")]
        public void ThenNextPageIconIsEnabled()
        {
            string PageNumberBeforeClick = updatesSelectUpdatePage.PaginationXofY.Text;
            updatesSelectUpdatePage.PaginationNextIcon.JavaSciptClick();
            Thread.Sleep(1000);
            string PageNumberAfterClick = updatesSelectUpdatePage.PaginationXofY.Text;
            Assert.AreNotEqual(PageNumberBeforeClick, PageNumberAfterClick, "Next page icon is not enabled.");
        }

        [When(@"user clicks Next page icon")]
        public void WhenUserClicksNextPageIcon()
        {
            SetMethods.ScrollToBottomofWebpage();
            updatesSelectUpdatePage.PaginationNextIcon.Click();
        }

        [Then(@"second page of entries is displayed")]
        public void ThenSecondPageOfEntriesIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.FileNameList.GetElementCount()>0, "Second Page entries are not displayesd.");
            Assert.AreEqual("Vanilla 9", updatesSelectUpdatePage.FileNameList[0].Text);
        }

        [Then(@"Next page icon is disabled")]
        public void ThenNextPageIconIsDisabled()
        {
            string PageNumberBeforeClick = updatesSelectUpdatePage.PaginationXofY.Text;
            updatesSelectUpdatePage.PaginationNextIcon.JavaSciptClick();
            string PageNumberAfterClick = updatesSelectUpdatePage.PaginationXofY.Text;
            Assert.AreEqual(PageNumberBeforeClick, PageNumberAfterClick, "Next page icon is not disabled.");
        }

        [Then(@"Previous page icon is enabled")]
        public void ThenPreviousPageIconIsEnabled()
        {
            string PageNumberBeforeClick = updatesSelectUpdatePage.PaginationXofY.Text;
            updatesSelectUpdatePage.PaginationPreviousIcon.JavaSciptClick();
            string PageNumberAfterClick = updatesSelectUpdatePage.PaginationXofY.Text;
            Assert.AreNotEqual(PageNumberBeforeClick, PageNumberAfterClick, "Previous page icon is not enabled.");
        }

        [Given(@"configuration file is selected")]
        public void GivenConfigurationFileIsSelected()
        {
            updatesSelectUpdatePage.FirstFileCSMInTable.Click();
        }

        [When(@"user clicks Next button")]
        public void WhenUserClicksNextButton()
        {
            updatesSelectUpdatePage.NextButton.Click();
        }

        [Then(@"CSM Select devices page is displayed")]
        public void ThenCSMSelectDevicesPageIsDisplayed()
        {
            bool result = (updateSelectDevicesPage.ItemtoPush.GetElementVisibility()) || (updateSelectDevicesPage.DeviceCount.GetElementVisibility());
            Assert.AreEqual(true, result, "User is not on Select devices page.");
        }

        [Given(@"user is on CSM Configuration Select assets page")]
        public void GivenUserIsOnCSMConfigurationSelectAssetsPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.Organization1Facility0Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.UpdatesTab.JavaSciptClick();
            updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.CSMDeviceName);
            updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeConfiguration);
            updatesSelectUpdatePage.FirstFileCSMInTable.Click();
            updatesSelectUpdatePage.NextButton.Click();
            Assert.AreEqual(true, updateSelectDevicesPage.ItemtoPush.GetElementVisibility(), "user is not on CSM Configuration Select assets page");
        }

        [Then(@"Select update indicator is not highlighted")]
        public void ThenSelectUpdateIndicatorIsNotHighlighted()
        {
            Assert.AreEqual(UpdatesSelectUpdatePage.ExpectedValues.NonHighlightedHeadingColor, updatesSelectUpdatePage.Heading.GetCssValue("color"), "Select update indicator is highlighted");
        }

        [Then(@"Select devices indicator is highlighted")]
        public void ThenSelectDevicesIndicatorIsHighlighted()
        {
            Assert.AreEqual(UpdateSelectDevicesPage.ExpectedValues.HighlightedHeadingColor, updateSelectDevicesPage.Heading.GetCssValue("color"), "Select devices indicator is not highlighted");
        }

        [Then(@"Review action indicator is not highlighted")]
        public void ThenReviewActionIndicatorIsNotHighlighted()
        {
            Assert.AreEqual(UpdateReviewActionPage.ExpectedValues.NonHighlightedHeadingColor, updateReviewActionPage.Heading.GetCssValue("color"), "Review action indicator is highlighted");
        }

        [Then(@"""(.*)"" label is displayed")]
        public void ThenLabelIsDisplayed(string labelName)
        {
            IWebElement labelElement = null;
            switch (labelName.ToLower().Trim())
            {
                case "item to push": labelElement = updateSelectDevicesPage.ItemtoPush;
                    break;
                case "device type":
                    labelElement = updateSelectDevicesPage.DeviceTypeLabel;
                    break;
                case "update type":
                    labelElement = updateSelectDevicesPage.TypeofUpdateConfigLabel;
                    break;
                case "config file to push":
                    labelElement = updateSelectDevicesPage.FileName;
                    break;
                case "destinations":
                    labelElement = updateSelectDevicesPage.DestinationLabel;
                    break;
                default: Assert.Fail(labelName + " is an invalid label name");
                    break;
            }
            Assert.AreEqual(true, labelElement.GetElementVisibility(), labelName + " label is not dispalyed");
        }

        [Then(@"location hierarchy selectors are displayed")]
        public void ThenLocationHierarchySelectorsAreDisplayed()
        {
            Assert.AreEqual(true, updateSelectDevicesPage.LocationHierarchy.GetElementVisibility(), "location hierarchy selectors are not displayed");
        }

        [Then(@"count of selected devices is displayed")]
        public void ThenCountOfSelectedDevicesIsDisplayed()
        {
            Assert.AreEqual(true, updateSelectDevicesPage.DeviceCount.GetElementVisibility(), "count of selected devices is not displayed");
        }

        [Then(@"Previous button is enabled")]
        public void ThenPreviousButtonIsEnabled()
        {
            Assert.AreEqual(true, updateSelectDevicesPage.PreviousButton.Enabled, "Previous button is enabled");
        }

        [Then(@"Select all checkbox in column 1 is displayed")]
        public void ThenSelectAllCheckboxInColumnIsDisplayed()
        {
            Assert.AreEqual(true, updateSelectDevicesPage.SelectAllcheckBox.GetElementVisibility(), "Select all checkbox in column 1 is not displayed");
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string HeadingName)
        {
            IWebElement HeadingElement = null;
            string ExpectedHeadingText = null;
            switch (HeadingName.ToLower().Trim())
            {
                case "firmware": HeadingElement = updateSelectDevicesPage.FirmwareHeading;
                    ExpectedHeadingText = UpdateSelectDevicesPage.ExpectedValues.FirwareHeadingText;
                    break;
                case "config":
                    HeadingElement = updateSelectDevicesPage.ConfigHeading;
                    ExpectedHeadingText = UpdateSelectDevicesPage.ExpectedValues.ConfigHeadingText;
                    break;
                case "asset tag":
                    HeadingElement = updateSelectDevicesPage.AssetTagHeading;
                    ExpectedHeadingText = UpdateSelectDevicesPage.ExpectedValues.AssetTagHeadingText;
                    break;
                case "serial":
                    HeadingElement = updateSelectDevicesPage.SerialNoHeading;
                    ExpectedHeadingText = UpdateSelectDevicesPage.ExpectedValues.SerialHeadingText;
                    break;
                case "location":
                    HeadingElement = updateSelectDevicesPage.LocationHeading;
                    ExpectedHeadingText = UpdateSelectDevicesPage.ExpectedValues.LocationHeadingText;
                    break;
                case "last files deployed":
                    HeadingElement = updateSelectDevicesPage.LastFilesDeployedHeading;
                    ExpectedHeadingText = UpdateSelectDevicesPage.ExpectedValues.LastFilesDeployedHeadingText;
                    break;
                default: Assert.Fail(HeadingName + " is a invalid heading name");
                    break;
            }
            Assert.AreEqual(true, HeadingElement.GetElementVisibility(), HeadingName + " is not displayed.");
            string ActualHeadingText = HeadingElement.Text.ToLower();
            Assert.AreEqual(ExpectedHeadingText.ToLower(), ActualHeadingText, HeadingName + " not matches with the expected value");

        }


        [Then(@"Select all checkbox is in column (.*)")]
        public void ThenSelectAllCheckboxIsInColumn(int columnNumber)
        {
            string firstcolumnId=updateSelectDevicesPage.TableHeading.FindElements(By.TagName("div"))[columnNumber-1].GetAttribute("id");
            Assert.AreEqual(UpdateSelectDevicesPage.Locators.SelectAllcheckBoxID, firstcolumnId, "Select all checkbox is not in column "+columnNumber);
        }

        [Then(@"""(.*)"" label is in column (.*)")]
        public void ThenLabelIsInColumn(string columnHeading, int columnNumber)
        {
            IList<IWebElement> columns = updateSelectDevicesPage.TableHeading.FindElements(By.TagName("div"));
            Assert.AreEqual(columnHeading.ToLower().Trim(),columns[columnNumber-1].Text.ToLower(),columnHeading+" is not in "+ columnNumber);
        }



        [When(@"user selects one device")]
        public void WhenUserSelectsOneDevice()
        {
            updateSelectDevicesPage.FirstDeviceCheckBox.Click();
        }

        [Then(@"count of selected devices changes from (.*) to (.*)")]
        public void ThenCountOfSelectedDevicesChangesFromTo(int p0, int p1)
        {
            string ActualDesinationCountText = updateSelectDevicesPage.DeviceCount.Text;
            string ExpectedDestinationCountText = UpdateSelectDevicesPage.ExpectedValues.Desination1DeviceCountText;
            Assert.AreEqual(ExpectedDestinationCountText, ActualDesinationCountText, "Count of selected devices are not changed.");
        }

        [Then(@"Next button is enabled")]
        public void ThenNextButtonIsEnabled()
        {
            Assert.AreEqual(true, updateSelectDevicesPage.NextButton.Enabled, "Next button is not enabled.");
        }

        [When(@"user clicks Previous button")]
        public void WhenUserClicksPreviousButton()
        {
            updateSelectDevicesPage.PreviousButton.Click();
        }

        [Then(@"user is on CSM Updates page")]
        public void ThenUserIsOnCSMUpdatesPage()
        {
            bool IsUpdatePage = (updatesSelectUpdatePage.AssetTypeDropDown.GetElementVisibility()) || (updatesSelectUpdatePage.UpgradeTypeDropDown.GetElementVisibility());
            Assert.AreEqual(true, IsUpdatePage, "CSM update page is not displayed");
        }

        [When(@"clicks Next button")]
        public void WhenClicksNextButton()
        {
            updateSelectDevicesPage.NextButton.Click();

        }

        [Then(@"CSM Review Action page is displayed")]
        public void ThenCSMReviewActionPageIsDisplayed()
        {
            bool IsReviewActionPage = (updateReviewActionPage.ItemToPushLabel.GetElementVisibility()) || (updateReviewActionPage.DestinationLabel.GetElementVisibility());
            Assert.AreEqual(true, IsReviewActionPage, "CSM Reiew action page is not displayed.");
        }

        [Given(@"user is on CSM Review Action page")]
        public void GivenUserIsOnCSMReviewActionPage()
        {
            GivenUserIsOnCSMConfigurationSelectAssetsPage();
            updateSelectDevicesPage.FirstDeviceCheckBox.Click();
            updateSelectDevicesPage.NextButton.Click();
            Assert.AreEqual(true, updateReviewActionPage.ItemToPushLabel.GetElementVisibility(), "User is not CSM Review action page.");
        }

        [Then(@"Item to push label is displayed")]
        public void ThenItemToPushLabelIsDisplayed()
        {
            Assert.AreEqual(true, updateReviewActionPage.ItemToPushLabel.GetElementVisibility(), "Item to push label is not displayed.");
        }

        [Then(@"Item to push value is displayed")]
        public void ThenItemToPushValueIsDisplayed()
        {
            Assert.AreEqual(true, updateReviewActionPage.ItemToPushValue.GetElementVisibility(), "Item to push value is not displayed.");
        }

        [Then(@"Destinations label is displayed")]
        public void ThenDestinationsLabelIsDisplayed()
        {
            Assert.AreEqual(true, updateReviewActionPage.DestinationLabel.GetElementVisibility(), "Destinations label is not displayed.");
        }

        [Then(@"Destinations value is displayed")]
        public void ThenDestinationsValueIsDisplayed()
        {
            Assert.AreEqual(true, updateReviewActionPage.DestinationValue.GetElementVisibility(), "Destinations value is not displayed.");
        }

        [Then(@"Select devices indicator is not highlighted")]
        public void ThenSelectDevicesIndicatorIsNotHighlighted()
        {
            Assert.AreEqual(UpdateSelectDevicesPage.ExpectedValues.NonHighlightedHeadingColor, updateSelectDevicesPage.Heading.GetCssValue("color"), "Select device indicator is highlighted");
        }

        [Then(@"Review action indicator is highlighted")]
        public void ThenReviewActionIndicatorIsHighlighted()
        {
            Assert.AreEqual(UpdateReviewActionPage.ExpectedValues.HighlightedHeadingColor, updateReviewActionPage.Heading.GetCssValue("color"), "Review action indicator is not highlighted");
        }

        [Then(@"Confirm button is enabled")]
        public void ThenConfirmButtonIsEnabled()
        {
            Assert.AreEqual(true, updateReviewActionPage.ConfirmButton.Enabled, "Confirm button is not enabled");
        }

        [When(@"user clicks Confirm button")]
        public void WhenUserClicksConfirmButton()
        {
            updateReviewActionPage.ConfirmButton.Click();
        }

        [Then(@"Update process has been established message is displayed")]
        public void ThenUpdateProcessHasBeenEstablishedMessageIsDisplayed()
        {
            //Message Id is not available
            _scenarioContext.Pending();
        }

        [Then(@"Select devices page is displayed")]
        public void ThenSelectDevicesPageIsDisplayed()
        {
            bool IsSelectDevicePage = (updateSelectDevicesPage.ItemtoPush.GetElementVisibility()) || (updateSelectDevicesPage.DeviceTypeLabel.GetElementVisibility());
            Assert.AreEqual(true, IsSelectDevicePage, "Select devices page is not displayed");
        }


    }
}
