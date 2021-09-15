using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.UpdatesTab;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.UpdatesTab.ConfigurationUpdate
{
    [Binding, Scope(Tag = "SoftwareRequirementID_5704")]
    public class Req5704Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly UpdatesSelectUpdatePage _updatesSelectUpdatePage;
        private readonly UpdateSelectDevicesPage _updateSelectDevicesPage;
        private readonly UpdateReviewActionPage _updateReviewActionPage;

        private readonly WebDriverWait _wait;
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public Req5704Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
            _updatesSelectUpdatePage = new UpdatesSelectUpdatePage(driver);
            _updateSelectDevicesPage = new UpdateSelectDevicesPage(driver);
            _updateReviewActionPage = new UpdateReviewActionPage(driver);
        }

        [Given(@"user is on Updates page")]
        public void GivenUserIsOnUpdatesPage()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.UpdatesTab.JavaSciptClick(_driver);
        }

        [When(@"user selects CSM Asset type")]
        public void WhenUserSelectsCSMAssetType()
        {
            _updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePageExpectedValues.CSMDeviceName);
        }

        [Then(@"CSM displays as Asset type")]
        public void ThenCSMDisplaysAsAssetType()
        {
            string selectedOptionInAssetTypeDropdown = _updatesSelectUpdatePage.AssetTypeDropDown.GetSelectedOptionFromDDL();
            (selectedOptionInAssetTypeDropdown).Should().BeEquivalentTo(UpdatesSelectUpdatePageExpectedValues.CSMDeviceName, because: "CSM should be displayed as asset type when user select CSM in Asset type dropdown.");
        }

        [Then(@"Update type drop down contains Upgrade and Configuration entries")]
        public void ThenUpdateTypeDropDownContainsUpgradeAndConfigurationEntries()
        {
            IList<IWebElement> dropdownOptionList = _updatesSelectUpdatePage.UpgradeTypeDropDown.GetAllOptionsFromDDL();
            List<string> dropdownOptionTextList = new List<string>();
            //Extracting text fro the dropdown
            foreach (IWebElement option in dropdownOptionList)
            {
                dropdownOptionTextList.Add(option.Text.ToLower());
            }

            dropdownOptionTextList.Should().BeEquivalentTo(new List<string> { UpdatesSelectUpdatePageExpectedValues.UpdateTypeDropdownDefault.ToLower(), UpdatesSelectUpdatePageExpectedValues.UpdateTypeConfiguration.ToLower(), UpdatesSelectUpdatePageExpectedValues.UpdateTypeUpgrade.ToLower() }, because: "Update type drop down should contain only select, configuration and upgrade options when user selects CSM as Asset type");
        }

        [Given(@"user is on CSM Updates page")]
        public void GivenUserIsOnCSMUpdatesPage()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.UpdatesTab.JavaSciptClick(_driver);
        }

        [Given(@"CSM Asset type is selected")]
        public void GivenCSMAssetTypeIsSelected()
        {
            _updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePageExpectedValues.CSMDeviceName);
        }

        [When(@"user selects Configuration Update type")]
        public void WhenUserSelectsConfigurationUpdateType()
        {
            _updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePageExpectedValues.UpdateTypeConfiguration);
        }

        [Then(@"Configuration displays as Update type")]
        public void ThenConfigurationDisplaysAsUpdateType()
        {
            string selectOptionInUpdateTypeDropDown = _updatesSelectUpdatePage.UpgradeTypeDropDown.GetSelectedOptionFromDDL();
            (selectOptionInUpdateTypeDropDown).Should().BeEquivalentTo(UpdatesSelectUpdatePageExpectedValues.UpdateTypeConfiguration, because: "Configuration should be selected when user selects CSM in asset type dropdown and Configuration in update type dropdown");
        }

        [Then(@"CSM configuration list is displayed")]
        public void ThenCSMConfigurationListIsDisplayed()
        {
            (_updatesSelectUpdatePage.FileTableList.GetElementVisibility()).Should().BeTrue(because: "CSM configuration list should be displayed when user select the CSM configuration in select update page.");
        }

        [Then(@"Name column heading is displayed")]
        public void ThenNameColumnHeadingIsDisplayed()
        {
            (_updatesSelectUpdatePage.NameColumnHeading.GetElementVisibility()).Should().BeTrue(because:"Name column heading should be displayed in CSM configuration select update table");
            string ActualNameColumnHeadingText = _updatesSelectUpdatePage.NameColumnHeading.Text;
            (ActualNameColumnHeadingText).Should().BeEquivalentTo(UpdatesSelectUpdatePageExpectedValues.TableNameHeadingText, because:"Name heading name text should match with the expected value in CSM configuration select update table");
        }

        [Then(@"Date created column heading is displayed")]
        public void ThenDateCreatedColumnHeadingIsDisplayed()
        { 
           (_updatesSelectUpdatePage.DateColumnHeading.GetElementVisibility()).Should().BeTrue(because: "Date column heading should be displayed in CSM configuration select update table");
            string ActualDateColumnHeadingText = _updatesSelectUpdatePage.DateColumnHeading.Text;
            (ActualDateColumnHeadingText).Should().BeEquivalentTo(UpdatesSelectUpdatePageExpectedValues.TableDateHeadingText, because: "Date heading name text should match with the expected value in CSM configuration select update table");
        }

        [Then(@"Next button is disabled")]
        public void ThenNextButtonIsDisabled()
        {
            (_updatesSelectUpdatePage.NextButton.Enabled).Should().BeFalse(because: "Next button should be disabled");
        }

        [Then(@"Page x of y label is displayed")]
        public void ThenPageXOfYLabelIsDisplayed()
        {
            (_updatesSelectUpdatePage.PaginationXofY.GetElementVisibility()).Should().BeTrue(because: "Page x of y should be displayed in updates page");
        }

        [Then(@"Displaying x to y of z label is displayed")]
        public void ThenDisplayingXToYOfZLabelIsDisplayed()
        {
            SetMethods.ScrollToBottomofWebpage(_driver);
            (_updatesSelectUpdatePage.PaginationDisplayXY.GetElementVisibility()).Should().BeTrue(because: "Displaying x to y of z label should be displayed in updates page");
        }

        [Given(@"Configuration Update type is selected")]
        public void GivenConfigurationUpdateTypeIsSelected()
        {
            _updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePageExpectedValues.UpdateTypeConfiguration);
        }

        [Given(@"Configuration list is not empty")]
        public void GivenConfigurationListIsNotEmpty()
        {
            (_updatesSelectUpdatePage.FileNameList.GetElementCount()).Should().BeGreaterThan(0, because: "Configuration list should not be empty");
        }

        [Then(@"configuration files are sorted in ascending alphabetical order")]
        public void ThenConfigurationFilesAreSortedInAscendingAlphabeticalOrder()
        {
            List<string> ConfigurationFilesList = _updatesSelectUpdatePage.GetListOfConfigFiles(_updatesSelectUpdatePage.FileNameList);
            ConfigurationFilesList.Should().BeInAscendingOrder(because: "Configuration files should be sorted in alphabetical order");
        }

        [Given(@"user is on CSM Updates page with ""(.*)"" entries")]
        public void GivenUserIsOnCSMUpdatesPageWithEntries(string noOfEntries)
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            switch (noOfEntries)
            {
                case "<=50": 
                    _landingPage.LNTAutomatedTestOrganizationFacilityTest2Title.Click();
                    break;
                case ">50":
                    _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
                    break;
                case ">50 and <=100":
                    _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
                    break;
                default: Assert.Fail("Invalid no of entries:" + noOfEntries);
                    break;
            }
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.UpdatesTab.JavaSciptClick(_driver);
            _updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePageExpectedValues.CSMDeviceName);
            _updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePageExpectedValues.UpdateTypeConfiguration);
        }

        [Given(@"user is on page 1")]
        public void GivenUserIsOnPage()
        {
            SetMethods.ScrollToBottomofWebpage(_driver);
            string PageNumber = _updatesSelectUpdatePage.PaginationXofY.Text;
            PageNumber.Should().StartWithEquivalentOf("Page 1", because: "User should be on page one in select update page");
        }

        [Then(@"Previous page icon is disabled")]
        public void ThenPreviousPageIconIsDisabled()
        {
            SetMethods.ScrollToBottomofWebpage(_driver);
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(UpdatesSelectUpdatePage.Locators.PaginationPreviousIconID)));
            string PaginationPreviousIconImageURL = _updatesSelectUpdatePage.PaginationPreviousIcon.FindElement(By.TagName("img")).GetAttribute("src");
            (PaginationPreviousIconImageURL).Should().BeEquivalentTo(PropertyClass.BaseURL + UpdatesSelectUpdatePageExpectedValues.PaginationPreviousIconDisabledSource, because: "Previous page icon should be disabled in First page of entries in select update page");
        }

        [Then(@"Next page icon is enabled")]
        public void ThenNextPageIconIsEnabled()
        {
            SetMethods.ScrollToBottomofWebpage(_driver);
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(UpdatesSelectUpdatePage.Locators.PaginationNextIconID)));
            string PaginationNextIconImageURL = _updatesSelectUpdatePage.PaginationNextIcon.FindElement(By.TagName("img")).GetAttribute("src");
            (PaginationNextIconImageURL).Should().BeEquivalentTo(PropertyClass.BaseURL + UpdatesSelectUpdatePageExpectedValues.PaginationNextIconEnabledSource, because: "Next page icon should be enabled");
        }

        [When(@"user clicks Next page icon")]
        public void WhenUserClicksNextPageIcon()
        {
            SetMethods.ScrollToBottomofWebpage(_driver);
            _updatesSelectUpdatePage.PaginationNextIcon.Click();
        }

        [Then(@"second page of entries is displayed")]
        public void ThenSecondPageOfEntriesIsDisplayed()
        {
            Thread.Sleep(1000);
            string PageNumber = _updatesSelectUpdatePage.PaginationXofY.Text;
            (PageNumber).Should().StartWithEquivalentOf("Page 2", because: "second page entries should be displayed");
            (_updatesSelectUpdatePage.FileNameList.GetElementCount()).Should().BeGreaterThan(0, because: "Atleast one entry should be present in the Second page");
        }

        [Then(@"Next page icon is disabled")]
        public void ThenNextPageIconIsDisabled()
        {
            SetMethods.ScrollToBottomofWebpage(_driver);
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(UpdatesSelectUpdatePage.Locators.PaginationNextIconID)));
            string PaginationNextIconImageURL = _updatesSelectUpdatePage.PaginationNextIcon.FindElement(By.TagName("img")).GetAttribute("src");
            (PaginationNextIconImageURL).Should().BeEquivalentTo(PropertyClass.BaseURL + UpdatesSelectUpdatePageExpectedValues.PaginationNextIconDisabledSource, because: "Next page icon should be disabled");
        }

        [Then(@"Previous page icon is enabled")]
        public void ThenPreviousPageIconIsEnabled()
        {
            SetMethods.ScrollToBottomofWebpage(_driver);
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(UpdatesSelectUpdatePage.Locators.PaginationPreviousIconID)));
            string PaginationPreviousIconImageURL = _updatesSelectUpdatePage.PaginationPreviousIcon.FindElement(By.TagName("img")).GetAttribute("src");
            (PaginationPreviousIconImageURL).Should().BeEquivalentTo(PropertyClass.BaseURL + UpdatesSelectUpdatePageExpectedValues.PaginationPreviousIconEnabledSource, because: "Previous page icon should be enabled in second page of entries in select update page");
        }

        [Given(@"configuration file is selected")]
        public void GivenConfigurationFileIsSelected()
        {
            _updatesSelectUpdatePage.FirstFileCSMInTable.Click();
        }

        [When(@"user clicks Next button")]
        public void WhenUserClicksNextButton()
        {
            _updatesSelectUpdatePage.NextButton.Click();
        }

        [Then(@"CSM Select devices page is displayed")]
        public void ThenCSMSelectDevicesPageIsDisplayed()
        {
            bool IsSelectAssetPageDisplayed = (_updateSelectDevicesPage.DeployHead.GetElementVisibility()) || (_updateSelectDevicesPage.DestinationLabel.GetElementVisibility());
            (IsSelectAssetPageDisplayed).Should().BeTrue(because: "Select assets page should be displayed when user clicks enabled next button in select update page.");
        }

        [Given(@"user is on CSM Configuration Select assets page")]
        public void GivenUserIsOnCSMConfigurationSelectAssetsPage()
        {
            //Login and click on updates tab
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.UpdatesTab.JavaSciptClick(_driver);

            //Select CSM Configuration
            _updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePageExpectedValues.CSMDeviceName);
            _updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePageExpectedValues.UpdateTypeConfiguration);
            _updatesSelectUpdatePage.FirstFileCSMInTable.Click();
            _updatesSelectUpdatePage.NextButton.Click();

            ThenCSMSelectDevicesPageIsDisplayed();
        }

        [Then(@"Select update indicator is not highlighted")]
        public void ThenSelectUpdateIndicatorIsNotHighlighted()
        {
            string selectUpdateIndicatorColor = _updatesSelectUpdatePage.Heading.GetCssValue("color");
            (selectUpdateIndicatorColor).Should().BeEquivalentTo(UpdatesSelectUpdatePageExpectedValues.NonHighlightedHeadingColor, because: "Select Update tab indicator should not be highlighted.");
        }

        [Then(@"Select devices indicator is highlighted")]
        public void ThenSelectDevicesIndicatorIsHighlighted()
        {
            string selectAssetsIndicatorColor = _updateSelectDevicesPage.Heading.GetCssValue("color");
            (selectAssetsIndicatorColor).Should().BeEquivalentTo(UpdateSelectDevicesPageExpectedValues.HighlightedHeadingColor, because: "Select devices tab should not be highlighted");
        }

        [Then(@"Review action indicator is not highlighted")]
        public void ThenReviewActionIndicatorIsNotHighlighted()
        {
            string reviewActionColor = _updateReviewActionPage.Heading.GetCssValue("color");
            (reviewActionColor).Should().BeEquivalentTo(UpdateReviewActionPageExpectedValues.NonHighlightedHeadingColor, because: "Review action indicator should not be highlighted");
        }

        [Then(@"""(.*)"" label is displayed")]
        public void ThenLabelIsDisplayed(string labelName)
        {
            IWebElement labelElement = null;
            string ExpectedText = "";
            switch (labelName.ToLower().Trim())
            {
                case "item to push": labelElement = _updateSelectDevicesPage.ItemtoPush;
                    ExpectedText = UpdateSelectDevicesPageExpectedValues.ItemToPushLabelText;
                    break;
                case "device type":
                    labelElement = _updateSelectDevicesPage.DeviceTypeLabel;
                    ExpectedText = UpdateSelectDevicesPageExpectedValues.CSMDeviceName;
                    break;
                case "update type":
                    labelElement = _updateSelectDevicesPage.TypeofUpdateConfigLabel;
                    ExpectedText = UpdateSelectDevicesPageExpectedValues.ConfigureLabelText;
                    break;
                case "config file to push":
                    labelElement = _updateSelectDevicesPage.FileName;
                    ExpectedText = UpdateSelectDevicesPageExpectedValues.FirstConfigFileName;
                    break;
                case "destinations":
                    labelElement = _updateSelectDevicesPage.DestinationLabel;
                    ExpectedText = UpdateSelectDevicesPageExpectedValues.DestinationLabelText;
                    break;
                default: Assert.Fail(labelName + " is an invalid label name");
                    break;
            }

            (labelElement.GetElementVisibility()).Should().BeTrue(because: labelName + " label name should be displayed in select assets page");
            string labelText = labelElement.Text;
            (labelText).Should().BeEquivalentTo(ExpectedText, because: labelName + " label name should match the expected value.");
        }

        [Then(@"location hierarchy selectors are displayed")]
        public void ThenLocationHierarchySelectorsAreDisplayed()
        {
            (_updateSelectDevicesPage.LocationHierarchy.GetElementVisibility()).Should().BeTrue(because: "Location hierarchy selectors should be displayed in CSM Configuration Select Assets page.");
        }

        [Then(@"count of selected devices is displayed")]
        public void ThenCountOfSelectedDevicesIsDisplayed()
        {
            (_updateSelectDevicesPage.DeviceCount.GetElementVisibility()).Should().BeTrue(because: "Selected device count should be displayed in CSM Configuration Select Assets page");
        }

        [Then(@"Previous button is enabled")]
        public void ThenPreviousButtonIsEnabled()
        {
            (_updateSelectDevicesPage.PreviousButton.GetElementVisibility()).Should().BeTrue(because: "Previous button should be displayed in CSM Configuration Select Assets page");
        }

        [Then(@"Select all checkbox is displayed")]
        public void ThenSelectAllCheckboxIsDisplayed()
        {
            (_updateSelectDevicesPage.SelectAllcheckBox.GetElementVisibility()).Should().BeTrue(because: "Select all checkbox should be displayed in CSM Configuration Select Assets page");
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string columnHeadingName)
        {
            IWebElement HeadingWebElement = null;
            switch (columnHeadingName.ToLower().Trim())
            {
                case "firmware": HeadingWebElement = _updateSelectDevicesPage.FirmwareHeading;
                    break;
                case "config":
                    HeadingWebElement = _updateSelectDevicesPage.ConfigHeading;
                    break;
                case "asset tag":
                    HeadingWebElement = _updateSelectDevicesPage.AssetTagHeading;
                    break;
                case "serial number":
                    HeadingWebElement = _updateSelectDevicesPage.SerialNoHeading;
                    break;
                case "location":
                    HeadingWebElement = _updateSelectDevicesPage.LocationHeading;
                    break;
                case "last files deployed":
                    HeadingWebElement = _updateSelectDevicesPage.LastFilesDeployedHeading;
                    break;
                default: Assert.Fail(columnHeadingName + " is a invalid heading name");
                    break;
            }
            (HeadingWebElement.GetElementVisibility()).Should().BeTrue(because: HeadingWebElement + " column heading should be displayed in CSM configuration select assets table");
            string ActualHeadingText = HeadingWebElement.Text;
            (ActualHeadingText).Should().BeEquivalentTo(columnHeadingName, because: columnHeadingName + " heading name text should match with the expected value in CSM configuration select assets table.");

        }


        [Then(@"Select all checkbox is in column (.*)")]
        public void ThenSelectAllCheckboxIsInColumn(int columnNumber)
        {
            string firstcolumnId = _updateSelectDevicesPage.TableHeading.FindElements(By.TagName("div"))[columnNumber - 1].GetAttribute("id");
            (firstcolumnId).Should().BeEquivalentTo(UpdateSelectDevicesPage.Locators.SelectAllcheckBoxID, because: "Select all checkbox should be in column " + columnNumber);
        }

        [Then(@"""(.*)"" label is in column (.*)")]
        public void ThenLabelIsInColumn(string columnHeading, int columnNumber)
        {
            IList<IWebElement> columnsList = _updateSelectDevicesPage.TableHeading.FindElements(By.TagName("div"));
            List<string> columnListText = new List<string>();
            foreach (IWebElement column in columnsList)
            {
                columnListText.Add(column.Text.ToLower());
            }
            //Making as zero based Indexing
            columnNumber--;
            columnListText.Should().HaveElementAt(columnNumber, columnHeading.ToLower(), because: columnHeading + " column heading should be in column number " + columnNumber);
        }



        [When(@"user selects one device")]
        public void WhenUserSelectsOneDevice()
        {
            _updateSelectDevicesPage.FirstDeviceCheckBox.Click();
        }

        [Then(@"count of selected devices changes from 0 to 1")]
        public void ThenCountOfSelectedDevicesChangesFromTo()
        {
            string ActualDestinationCountText = _updateSelectDevicesPage.DeviceCount.Text;
            (ActualDestinationCountText).Should().BeEquivalentTo(UpdateSelectDevicesPageExpectedValues.Desination1DeviceCountText, because: "Count of selected devices should change when user selects one device in select assets page.");
        }

        [Then(@"Next button is enabled")]
        public void ThenNextButtonIsEnabled()
        {
            (_updatesSelectUpdatePage.NextButton.Enabled).Should().BeTrue(because: "Next button should be enabled when select any one device in the list in CSM selct device page.");
        }

        [When(@"user clicks Previous button")]
        public void WhenUserClicksPreviousButton()
        {
            _updateSelectDevicesPage.PreviousButton.Click();
        }

        [Then(@"user is on CSM Updates page")]
        public void ThenUserIsOnCSMUpdatesPage()
        {
            bool IsUpdatePage = (_updatesSelectUpdatePage.AssetTypeDropDown.GetElementVisibility()) || (_updatesSelectUpdatePage.UpgradeTypeDropDown.GetElementVisibility());
            IsUpdatePage.Should().BeTrue(because: "User should be on CSM Updates page when user cliks on previous button in CSM select assets page");
        }

        [When(@"clicks Next button")]
        public void WhenClicksNextButton()
        {
            _updateSelectDevicesPage.NextButton.Click();

        }

        [Then(@"CSM Review Action page is displayed")]
        public void ThenCSMReviewActionPageIsDisplayed()
        {
            bool IsReviewActionPage = (_updateReviewActionPage.ItemToPushLabel.GetElementVisibility()) || (_updateReviewActionPage.DestinationLabel.GetElementVisibility());
            (IsReviewActionPage).Should().BeTrue(because: "CSM Review action page should display when user clicks Next button in CSM select device page");
        }

        [Given(@"user is on CSM Review Action page")]
        public void GivenUserIsOnCSMReviewActionPage()
        {
            GivenUserIsOnCSMConfigurationSelectAssetsPage();
            _updateSelectDevicesPage.FirstDeviceCheckBox.Click();
            _updateSelectDevicesPage.NextButton.Click();
            ThenCSMReviewActionPageIsDisplayed();
        }

        [Then(@"Item to push label is displayed")]
        public void ThenItemToPushLabelIsDisplayed()
        {
            (_updateReviewActionPage.ItemToPushLabel.GetElementVisibility()).Should().BeTrue(because: "Item to push label should be displayed in CSM Review action page page.");
            string ActualItemToPushLabelText = _updateReviewActionPage.ItemToPushLabel.Text;
            (ActualItemToPushLabelText).Should().BeEquivalentTo(UpdateReviewActionPageExpectedValues.ItemToPushLabelText, because: "Item to push label text should match with expected value in CSM Review action page.");
        }

        [Then(@"Item to push value is displayed")]
        public void ThenItemToPushValueIsDisplayed()
        {
            (_updateReviewActionPage.ItemToPushValue.GetElementVisibility()).Should().BeTrue(because: "Item to push value should be displayed in CSM review action page");
        }

        [Then(@"Destinations label is displayed")]
        public void ThenDestinationsLabelIsDisplayed()
        {
            (_updateReviewActionPage.DestinationLabel.GetElementVisibility()).Should().BeTrue(because: "Destination label should be displayed in CSM review action Page.");
            string ActualDesinationLabelText = _updateReviewActionPage.DestinationLabel.Text;
            ActualDesinationLabelText.Should().BeEquivalentTo(UpdateReviewActionPageExpectedValues.DestinationLabelText, because: "Destination label text should match with expected value in CSM review action Page.");
        }

        [Then(@"Destinations value is displayed")]
        public void ThenDestinationsValueIsDisplayed()
        {
            (_updateReviewActionPage.DestinationValue.GetElementVisibility()).Should().BeTrue(because: "Destinations value should be displayed in CSM review action page");
        }

        [Then(@"Select devices indicator is not highlighted")]
        public void ThenSelectDevicesIndicatorIsNotHighlighted()
        {
            string SelectAssetsColor = _updateSelectDevicesPage.Heading.GetCssValue("color");
            (SelectAssetsColor).Should().BeEquivalentTo(UpdateSelectDevicesPageExpectedValues.NonHighlightedHeadingColor, because: "Select assets indicator should not be highlighted.");
        }

        [Then(@"Review action indicator is highlighted")]
        public void ThenReviewActionIndicatorIsHighlighted()
        {
            string reviewActionColor = _updateReviewActionPage.Heading.GetCssValue("color");
            (reviewActionColor).Should().BeEquivalentTo(UpdateReviewActionPageExpectedValues.HighlightedHeadingColor, because: "Review action indicator should be highlighted in CSM review action page");
        }
        
        [Then(@"Confirm button is enabled")]
        public void ThenConfirmButtonIsEnabled()
        {
            (_updateReviewActionPage.ConfirmButton.Enabled).Should().BeTrue(because: "Confirm button should be enabled in CSM review action page.");
        }

        [When(@"user clicks Confirm button")]
        public void WhenUserClicksConfirmButton()
        {
            _updateReviewActionPage.ConfirmButton.Click();
        }

        [Then(@"Update process has been established message is displayed")]
        public void ThenUpdateProcessHasBeenEstablishedMessageIsDisplayed()
        {
            (_updateSelectDevicesPage.SuccessUpadteMessage.GetElementVisibility()).Should().BeTrue(because: "Update process Message should be displayed when user clicks confirm button on CSM review action page.");
            (_updateSelectDevicesPage.SuccessUpadteMessage.Text).Should().BeEquivalentTo(UpdateSelectDevicesPageExpectedValues.UpdateProcessMessageText, because: "Update message should match with the expected value.");
        }

        [Then(@"Select devices page is displayed")]
        public void ThenSelectDevicesPageIsDisplayed()
        {
            bool IsSelectDevicePageDisplayed = (_updateSelectDevicesPage.ItemtoPush.GetElementVisibility()) || (_updateSelectDevicesPage.DeviceTypeLabel.GetElementVisibility());
            IsSelectDevicePageDisplayed.Should().BeTrue(because: "Select devices page should be displayed when user clicks confirm button in the CSM review action page");
        }


    }
}
