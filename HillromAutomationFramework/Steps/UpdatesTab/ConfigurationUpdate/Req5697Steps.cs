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
    [Binding,Scope(Tag = "SoftwareRequirementID_5697")]
    public class Req5697Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly UpdatesSelectUpdatePage _updatesSelectUpdatePage;
        private readonly UpdateSelectDevicesPage _updateSelectDevicePage;
        private readonly UpdateReviewActionPage _updateReviewActionPage;

        private readonly WebDriverWait _wait;
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public Req5697Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _mainPage = new MainPage(driver);
            _landingPage = new LandingPage(driver);
            _updatesSelectUpdatePage = new UpdatesSelectUpdatePage(driver);
            _updateSelectDevicePage = new UpdateSelectDevicesPage(driver);
            _updateReviewActionPage = new UpdateReviewActionPage(driver);
        }

        [Given(@"user is on Main page")]
        public void GivenUserIsOnMainPage()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithOutRollUpPage);
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
        }
        
        [When(@"user clicks Updates")]
        public void WhenUserClicksUpdates()
        {
            _mainPage.UpdatesTab.JavaSciptClick(_driver);
        }
        
        [Then(@"Select update indicator is highlighted")]
        public void ThenSelectUpdateIndicatorIsHighlighted()
        {
            string SelectUpdatecolor = _updatesSelectUpdatePage.Heading.GetCssValue("color");
            (SelectUpdatecolor).Should().BeEquivalentTo(UpdatesSelectUpdatePageExpectedValues.HighlightedHeadingColor,because: "Select update indicator should be highlighted in select update page.");
        }
        
        [Then(@"Select assets indicator is not highlighted")]
        public void ThenSelectAssetsIndicatorIsNotHighlighted()
        {
            string SelectAssetsColor = _updateSelectDevicePage.Heading.GetCssValue("color");
            (SelectAssetsColor).Should().BeEquivalentTo(UpdateSelectDevicesPageExpectedValues.NonHighlightedHeadingColor, because: "Select assets indicator should not be highlighted.");
        }

        [Then(@"Review action indicator is not highlighted")]
        public void ThenReviewActionIndicatorIsNotHighlighted()
        {
            string ReviewActionColor = _updateReviewActionPage.Heading.GetCssValue("color");
            (ReviewActionColor).Should().BeEquivalentTo(UpdateReviewActionPageExpectedValues.NonHighlightedHeadingColor, because: "Review action indicator should not be highlighted.");
        }

        [Then(@"Asset type label is displayed")]
        public void ThenAssetTypeLabelIsDisplayed()
        {
            (_updatesSelectUpdatePage.AssetTypeLabel.GetElementVisibility()).Should().BeTrue(because: "Asset type label should be displayed in Select update page.");
            (_updatesSelectUpdatePage.AssetTypeLabel.Text).Should().BeEquivalentTo(UpdatesSelectUpdatePageExpectedValues.AssetTypeLabelText, because: "Asset type label text should match with the expected value in select update page.");
        }


        [Then(@"Update type label is displayed")]
        public void ThenUpdateTypeLabelIsDisplayed()
        {
            //select updates elements
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("select updates elements"))
            {
                (_updatesSelectUpdatePage.UpgradeTypeLabel.GetElementVisibility()).Should().BeTrue(because: "Update type label should be displayed in Select update page.");
                (_updatesSelectUpdatePage.UpgradeTypeLabel.Text).Should().BeEquivalentTo(UpdatesSelectUpdatePageExpectedValues.UpdateTypeLabelText,because: "Update type label text should match with the expected value in select update page.");
            }
            //cvsm select assets elements
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("cvsm select assets elements"))
            {
                (_updateSelectDevicePage.TypeofUpdateConfigLabel.GetElementVisibility()).Should().BeTrue(because: "Update type label should be displayed in select assets page.");
                (_updateSelectDevicePage.TypeofUpdateConfigLabel.Text).Should().BeEquivalentTo(UpdateSelectDevicesPageExpectedValues.ConfigureLabelText, because: "Update type label text should match with the expected value.");
            }
            //If test step does not belong to any scenario
            else
            {
                Assert.Fail(_scenarioContext.ScenarioInfo.Title + "sceanrio has no step defination for " + _scenarioContext.StepContext.StepInfo.Text);
            }
            
        }
        
        [Then(@"Asset type drop down is displayed")]
        public void ThenAssetTypeDropDownIsDisplayed()
        {
            (_updatesSelectUpdatePage.AssetTypeDropDown.GetElementVisibility()).Should().BeTrue(because: "Asset type dropdown should be displayed in select update page");
        }
        
        [Then(@"Update type drop down is displayed")]
        public void ThenUpdateTypeDropDownIsDisplayed()
        {
            (_updatesSelectUpdatePage.UpgradeTypeDropDown.GetElementVisibility()).Should().BeTrue(because: "Update type drop down should be displayed in Select update page");
        }
        
        [Then(@"Next button is displayed")]
        public void ThenNextButtonIsDisplayed()
        {
            (_updatesSelectUpdatePage.NextButton.GetElementVisibility()).Should().BeTrue(because: "Next button should be displayed in select assets page.");
        }

        [Given(@"user is on Updates page")]
        public void GivenUserIsOnUpdatesPage()
        {
            GivenUserIsOnMainPage();
            _mainPage.UpdatesTab.JavaSciptClick(_driver);
        }

        [When(@"user selects CVSM Asset type")]
        public void WhenUserSelectsCVSMAssetType()
        {
            _updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePageExpectedValues.CVSMDeviceName);
        }

        [Then(@"CVSM displays as Asset type")]
        public void ThenCVSMDisplaysAsAssetType()
        {
            string selectedOptionInAssetTypeDropdown = _updatesSelectUpdatePage.AssetTypeDropDown.GetSelectedOptionFromDDL();
            (selectedOptionInAssetTypeDropdown).Should().BeEquivalentTo(UpdatesSelectUpdatePageExpectedValues.CVSMDeviceName,because: "CVSM should be displayed as asset type when user select CVSM in Asset type dropdown.");
        }

        [Then(@"Update type drop down contains Configuration entry only")]
        public void ThenUpdateTypeDropDownContainsConfigurationEntryOnly()
        {
            IList<IWebElement> dropdownOptionList = _updatesSelectUpdatePage.UpgradeTypeDropDown.GetAllOptionsFromDDL();
            List<string> dropdownOptionTextList = new List<string>();
            //Extracting text fro the dropdown
            foreach(IWebElement option in dropdownOptionList)
            {
                dropdownOptionTextList.Add(option.Text.ToLower());
            }

            dropdownOptionTextList.Should().BeEquivalentTo(new List<string> { UpdatesSelectUpdatePageExpectedValues.UpdateTypeDropdownDefault.ToLower(), UpdatesSelectUpdatePageExpectedValues.UpdateTypeConfiguration.ToLower() },because:"Update type drop down should contain only selct and configuration options when user selects CVSM as Asset type");
        }

        [Given(@"user is on CVSM Updates page")]
        public void GivenUserIsOnCVSMUpdatesPage()
        {
            GivenUserIsOnMainPage();
            _mainPage.UpdatesTab.JavaSciptClick(_driver);
            _updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePageExpectedValues.CVSMDeviceName);
        }

        [Given(@"CVSM Asset type is selected")]
        public void GivenCVSMAssetTypeIsSelected()
        {
            string selectOptionInAssetTypeDropDown = _updatesSelectUpdatePage.AssetTypeDropDown.GetSelectedOptionFromDDL();
            (selectOptionInAssetTypeDropDown).Should().BeEquivalentTo(UpdatesSelectUpdatePageExpectedValues.CVSMDeviceName, because: "CVSM Asset type should be selected when user selects CVSM in asset type dropdown");
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
            (selectOptionInUpdateTypeDropDown).Should().BeEquivalentTo(UpdatesSelectUpdatePageExpectedValues.UpdateTypeConfiguration, because: "Configuration should be selected when user selects CVSM in asset type dropdown and Configuration in update type dropdown");
        }

        [Then(@"CVSM configuration list is displayed")]
        public void ThenCVSMConfigurationListIsDisplayed()
        {
            (_updatesSelectUpdatePage.FileTableList.GetElementVisibility()).Should().BeTrue(because: "CVSM configuration list should be displayed when user select the CVSM configuration in select update page.");
        }

        [Then(@"Delete button is displayed")]
        public void ThenDeleteButtonIsDisplayed()
        {
            (_updatesSelectUpdatePage.DeleteButton.GetElementVisibility()).Should().BeTrue(because: "Delete button should be displayed in CVSM configuration select update page.");
        }

        [Given(@"user is on CVSM Updates page with ""(.*)"" entries")]
        public void GivenUserIsOnCVSMUpdatesPageWithEntries(string noOfEntries)
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            //Selecting right Organizaion for the configuration
            switch (noOfEntries)
            {
                case "<=50":
                    _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
                    break;
                case ">50":
                    _landingPage.LNTAutomatedTestOrganizationFacilityTest2Title.Click();
                    break;

                case ">50 and <=100":
                    _landingPage.LNTAutomatedTestOrganizationFacilityTest2Title.Click();
                    break;
                default: Assert.Fail(noOfEntries+" is a invalid number of configuration files.");
                    break;
            }
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.UpdatesTab.JavaSciptClick(_driver);
            _updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePageExpectedValues.CVSMDeviceName);
            _updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePageExpectedValues.UpdateTypeConfiguration);
        }

        [Then(@"Previous page icon is disabled")]
        public void ThenPreviousPageiconIsDisabled()
        {
            SetMethods.ScrollToBottomofWebpage(_driver);
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(UpdatesSelectUpdatePage.Locators.PaginationPreviousIconID)));
            string PaginationPreviousIconImageURL = _updatesSelectUpdatePage.PaginationPreviousIcon.FindElement(By.TagName("img")).GetAttribute("src");
            (PaginationPreviousIconImageURL).Should().BeEquivalentTo(UpdatesSelectUpdatePageExpectedValues.PaginationPreviousIconDiabledSource, because:"Previous page icon should be disabled in First page of entries in select update page");
        }

        [Then(@"Next page icon is disabled")]
        public void ThenNextPageIconIsDisabled()
        {
            SetMethods.ScrollToBottomofWebpage(_driver);
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(UpdatesSelectUpdatePage.Locators.PaginationNextIconID)));
            string PaginationNextIconImageURL = _updatesSelectUpdatePage.PaginationNextIcon.FindElement(By.TagName("img")).GetAttribute("src");
            (PaginationNextIconImageURL).Should().BeEquivalentTo(UpdatesSelectUpdatePageExpectedValues.PaginationNextIconDiabledSource, because: "Next page icon should be disabled");
        }

        [Then(@"Previous page icon is enabled")]
        public void ThenPreviousPageIconIsEnabled()
        {
            SetMethods.ScrollToBottomofWebpage(_driver);
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(UpdatesSelectUpdatePage.Locators.PaginationPreviousIconID)));
            string PaginationPreviousIconImageURL = _updatesSelectUpdatePage.PaginationPreviousIcon.FindElement(By.TagName("img")).GetAttribute("src");
            (PaginationPreviousIconImageURL).Should().BeEquivalentTo(UpdatesSelectUpdatePageExpectedValues.PaginationPreviousIconEnabledSource, because: "Previous page icon should be enabled in second page of entries in select update page");
        }


        [Given(@"Configuration Update type is selected")]
        public void GivenConfigurationUpdateTypeIsSelected()
        {
            _updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePageExpectedValues.UpdateTypeConfiguration);
        }

        [When(@"user selects CVSM configuration from the list")]
        public void WhenUserSelectsCVSMConfigurationFromTheList()
        {
            //Selecting first file
            _updatesSelectUpdatePage.FirstFileCVSMAndCentrellaInTable.Click();
        }

        [Then(@"Next button is enabled")]
        public void ThenNextButtonIsEnabled()
        {
            (_updatesSelectUpdatePage.NextButton.Enabled).Should().BeTrue(because: "Next button should be enabled when select any one entries in the list.");
        }

        [Then(@"user clicks Next button")]
        public void ThenClicksNextButton()
        {
            _updatesSelectUpdatePage.NextButton.Click();
        }

        [Then(@"Select Assets page is displayed")]
        public void ThenSelectAssetsPageIsDisplayed()
        {
            bool IsSelectAssetPageDisplayed = (_updateSelectDevicePage.DeployHead.GetElementVisibility()) || (_updateSelectDevicePage.DestinationLabel.GetElementVisibility());
            (IsSelectAssetPageDisplayed).Should().BeTrue(because: "Select assets page should be displayed when user clicks enabled next button in select update page.");
        }

        [Given(@"user is on CVSM Configuration Select assets page")]
        public void GivenUserIsOnCVSMConfigurationSelectAssetsPage()
        {
            GivenUserIsOnCVSMUpdatesPage();
            _updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePageExpectedValues.UpdateTypeConfiguration);
            _updatesSelectUpdatePage.FirstFileCVSMAndCentrellaInTable.Click();
            _updatesSelectUpdatePage.NextButton.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(UpdateSelectDevicesPage.Locators.DeviceCountID)));
        }

        [Then(@"Select update indicator is not highlighted")]
        public void ThenSelectUpdateIndicatorIsNotHighlighted()
        {
            _wait.Until(ExplicitWait.ElementExists(By.Id(UpdateSelectDevicesPage.Locators.DeviceCountID)));
            string selectUpdateIndicatorColor = _updatesSelectUpdatePage.Heading.GetCssValue("color");
            (selectUpdateIndicatorColor).Should().BeEquivalentTo(UpdatesSelectUpdatePageExpectedValues.NonHighlightedHeadingColor,because: "Select Update tab indicator should not be highlighted.");
        }

        [Then(@"Select assets indicator is highlighted")]
        public void ThenSelectAssetsIndicatorIsHighlighted()
        {
            string selectAssetsIndicatorColor = _updateSelectDevicePage.Heading.GetCssValue("color");
            (selectAssetsIndicatorColor).Should().BeEquivalentTo(UpdateSelectDevicesPageExpectedValues.HighlightedHeadingColor, because: "Select devices tab should not be highlighted");
        }

        [Given(@"Configuration list is not empty")]
        public void GivenConfigurationListIsNotEmpty()
        {
            (_updatesSelectUpdatePage.FileNameList.GetElementCount()).Should().BeGreaterThan(0, because:"Configuration list should not be empty");
        }

        [Then(@"configuration files are sorted in ascending alphabetical order")]
        public void ThenConfigurationFilesAreSortedInAscendingAlphabeticalOrder()
        {
            List<string> ConfigurationFilesList = _updatesSelectUpdatePage.GetListOfConfigFiles(_updatesSelectUpdatePage.FileNameList);
            ConfigurationFilesList.Should().BeInAscendingOrder(because: "Configuration files should be sorted in alphabetical order");
        }


        //for select devices page
        [Then(@"Item to push label is displayed")]
        public void ThenItemToPushLabelIsDisplayed()
        {
            //For CVSM Select assets page
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("cvsm select assets elements"))
            {
                (_updateSelectDevicePage.ItemtoPush.GetElementVisibility()).Should().BeTrue(because: "Item to push label should be displayed in CVSM select assets page.");
                string ActualItemToPushLabelText = _updateSelectDevicePage.ItemtoPush.Text;
                (ActualItemToPushLabelText).Should().BeEquivalentTo(UpdateSelectDevicesPageExpectedValues.ItemToPushLabelText, because: "Item to push label text should match with expected value in CVSM select assets page.");
            }
            //For CVSM Review action page
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("cvsm review action elements"))
            {
                (_updateReviewActionPage.ItemToPushLabel.GetElementVisibility()).Should().BeTrue(because: "Item to push label should be displayed in CVSM Review action page.");
                string ActualItemToPushLabelText = _updateReviewActionPage.ItemToPushLabel.Text;
                (ActualItemToPushLabelText).Should().BeEquivalentTo(UpdateReviewActionPageExpectedValues.ItemToPushLabelText, because: "Item to push label text should match with expected value in CVSM Review action page.");
            }
            //If this does not belong to any scenario
            else
            {
                Assert.Fail(_scenarioContext.ScenarioInfo.Title + " does not have a step defination for " + _scenarioContext.StepContext.StepInfo.Text);
            }
            
        }

        [Then(@"Device type label is displayed")]
        public void ThenDeviceTypeLabelIsDisplayed()
        {
            (_updateSelectDevicePage.DeviceTypeLabel.GetElementVisibility()).Should().BeTrue(because: "Device type label should be displayed in CVSM Select Assets Elements.");
        }

        [Then(@"Config file to push label is displayed")]
        public void ThenConfigFileToPushLabelIsDisplayed()
        {
            (_updateSelectDevicePage.FileName.GetElementVisibility()).Should().BeTrue(because: "Config file to push label should be displayed in CVSM Select Assets Elements.");
        }

        [Then(@"Destinations label is displayed")]
        public void ThenDestinationsLabelIsDisplayed()
        {
            //For CVSM Select assets page
            if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("cvsm select assets elements"))
            {
                (_updateSelectDevicePage.DestinationLabel.GetElementVisibility()).Should().BeTrue(because: "Destination label should be displayed in CVSM select assets Page.");
                string ActualDestinationLabelText = _updateSelectDevicePage.DestinationLabel.Text;
                (ActualDestinationLabelText).Should().BeEquivalentTo(UpdateSelectDevicesPageExpectedValues.DestinationLabelText, because: "Destination label text should match with expected value in CVSM select assets Page.");
            }
            //For CVSM Review action page
            else if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("cvsm review action elements"))
            {
                (_updateReviewActionPage.DestinationLabel.GetElementVisibility()).Should().BeTrue(because: "Destination label should be displayed in CVSM review action Page.");
                string ActualDesinationLabelText = _updateReviewActionPage.DestinationLabel.Text;
                ActualDesinationLabelText.Should().BeEquivalentTo(UpdateReviewActionPageExpectedValues.DestinationLabelText, because: "Destination label text should match with expected value in CVSM review action Page.");
            }
            //If this does not belong to any scenario
            else
            {
                Assert.Fail(_scenarioContext.ScenarioInfo.Title + " does not have a step defination for " + _scenarioContext.StepContext.StepInfo.Text);
            }
        }

        [Then(@"location hierarchy selectors are displayed")]
        public void ThenLocationHierarchySelectorsAreDisplayed()
        {
            (_updateSelectDevicePage.LocationHierarchy.GetElementVisibility()).Should().BeTrue(because: "Location hierarchy selectors should be displayed in CVSM Configuration Select Assets page.");
        }

        [Then(@"count of selected devices is displayed")]
        public void ThenCountOfSelectedDevicesIsDisplayed()
        {
            (_updateSelectDevicePage.DeviceCount.GetElementVisibility()).Should().BeTrue(because: "Selected device count should be displayed in CVSM Configuration Select Assets page");
        }

        [Then(@"Previous button is displayed")]
        public void ThenPreviousButtonIsDisplayed()
        {
            (_updateSelectDevicePage.PreviousButton.GetElementVisibility()).Should().BeTrue(because: "Previous button should be displayed in CVSM Configuration Select Assets page");
        }

        [Then(@"Page x of y indicator is displayed")]
        public void ThenPageXOfYIndicatorIsDisplayed()
        {
            (_updateSelectDevicePage.PaginationXofY.GetElementVisibility()).Should().BeTrue(because: "Page x of y indicator should be displayed in CVSM Configuration Select Assets page");
        }

        [Then(@"Displaying x to y of z results indicator is displayed")]
        public void ThenDisplayingXToYOfZResultsIndicatorIsDisplayed()
        {
            (_updateSelectDevicePage.PaginationDisplayXY.GetElementVisibility()).Should().BeTrue(because: "Displaying x to y of z results indicator should be displayed in CVSM Configuration Select Assets page");
        }

        [Then(@"Select all checkbox is unchecked")]
        public void ThenSelectAllCheckboxIsUnchecked()
        {
            (_updateSelectDevicePage.SelectAllcheckBox.Selected).Should().BeFalse(because: "Select all check box should be uncheked in the CVSM Configuration Select Assets page");
        }
        
        //Done till here

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string HeadingName)
        {
            IWebElement HeadingWebElement = null;
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Trim().Equals("select cvsm configuration update type"))
            {
                switch(HeadingName.ToLower().Trim())
                {
                    case "name":
                        HeadingWebElement = _updatesSelectUpdatePage.NameColumnHeading;
                        break;

                    case "date created":
                        HeadingWebElement = _updatesSelectUpdatePage.DateColumnHeading;
                        break;
                    default:
                        Assert.Fail(HeadingName + "is an invalid column heading name.");
                        break;
                }
                (HeadingWebElement.GetElementVisibility()).Should().BeTrue(because: HeadingWebElement + " column heading should be displayed in CVSM configuration select update table");
                string ActualHeadingText = HeadingWebElement.Text;
                (ActualHeadingText).Should().BeEquivalentTo(HeadingName, because: HeadingName + " heading name text should match with the expected value in CVSM configuration select update table");
            }
            else if(_scenarioContext.ScenarioInfo.Title.ToLower().Trim().Equals("cvsm select assets elements table"))
            {
                switch (HeadingName.ToLower().Trim())
                {
                    case "firmware":
                        HeadingWebElement = _updateSelectDevicePage.FirmwareHeading;
                        break;
                    case "config":
                        HeadingWebElement = _updateSelectDevicePage.ConfigHeading;
                        break;
                    case "asset tag":
                        HeadingWebElement = _updateSelectDevicePage.AssetTagHeading;
                        break;
                    case "serial number":
                        HeadingWebElement = _updateSelectDevicePage.SerialNoHeading;
                        break;
                    case "location":
                        HeadingWebElement = _updateSelectDevicePage.LocationHeading;
                        break;
                    case "last files deployed":
                        HeadingWebElement = _updateSelectDevicePage.LastFilesDeployedHeading;
                        break;
                    default:
                        Assert.Fail(HeadingName + "is an invalid column heading name");
                        break;
                }
                (HeadingWebElement.GetElementVisibility()).Should().BeTrue(because: HeadingWebElement + " column heading should be displayed in CVSM configuration select assets table");
                string ActualHeadingText = HeadingWebElement.Text;
                (ActualHeadingText).Should().BeEquivalentTo(HeadingName, because: HeadingName + " heading name text should match with the expected value in CVSM configuration select assets table.");
            }
            //If test step does not belong to any scenario
            else
            {
                Assert.Fail(_scenarioContext.ScenarioInfo.Title + " does not have a step defination for " + _scenarioContext.StepContext.StepInfo.Text);
            }
        }

        [Then(@"Select all checkbox is in column (.*)")]
        public void ThenSelectAllCheckboxIsInColumn(int columnNumber)
        {
            string firstcolumnId = _updateSelectDevicePage.TableHeading.FindElements(By.TagName("div"))[columnNumber - 1].GetAttribute("id");
            (firstcolumnId).Should().BeEquivalentTo(UpdateSelectDevicesPage.Locators.SelectAllcheckBoxID, because: "Select all checkbox should be in column " + columnNumber);
        }

        [Then(@"""(.*)"" label is in column (.*)")]
        public void ThenLabelIsInColumn(string columnHeading, int columnNumber)
        {
            IList<IWebElement> columnsList = _updateSelectDevicePage.TableHeading.FindElements(By.TagName("div"));
            List<string> columnListText = new List<string>();
            foreach(IWebElement column in columnsList)
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
            _updateSelectDevicePage.FirstDeviceCheckBox.Click();
        }

        [Then(@"count of selected devices changes from 0 to 1")]
        public void ThenCountOfSelectedDevicesChangesFromTo()
        {
            string ActualDestinationCountText = _updateSelectDevicePage.DeviceCount.Text;
            (ActualDestinationCountText).Should().BeEquivalentTo(UpdateSelectDevicesPageExpectedValues.Desination1DeviceCountText, because: "Count of selected devices should change when user selects one device in select assets page.");
        }

        [When(@"user clicks Previous button")]
        public void WhenUserClicksPreviousButton()
        {
            _updateSelectDevicePage.PreviousButton.Click();
        }

        [Then(@"user is on CVSM Updates page")]
        public void ThenUserIsOnCVSMUpdatesPage()
        {
            bool IsUpdatePageDisplayed = (_updatesSelectUpdatePage.AssetTypeDropDown.GetElementVisibility()) || (_updatesSelectUpdatePage.UpgradeTypeDropDown.GetElementVisibility()); 
            (IsUpdatePageDisplayed).Should().BeTrue(because: "CVSM update page should be displayed when user clicks previous button CVSM Select Assets Page");
        }

        [When(@"Clicks Next button")]
        public void WhenClicksNextButton()
        {
            _updatesSelectUpdatePage.NextButton.Click();
        }

        [Then(@"CVSM Review Action page is displayed")]
        public void ThenCVSMReviewActionPageIsDisplayed()
        {
            (_updateReviewActionPage.PushItems.GetElementVisibility()).Should().BeTrue(because:"CVSM review action page should be displayed when user clicks next button in CVSM select assets page.");
        }

        [Given(@"user is on CVSM Review Action page")]
        public void GivenUserIsOnCVSMReviewActionPage()
        {
            GivenUserIsOnCVSMConfigurationSelectAssetsPage();
            _updateSelectDevicePage.FirstDeviceCheckBox.Click();
            _updateSelectDevicePage.NextButton.Click();
            (_updateReviewActionPage.PushItems.GetElementVisibility()).Should().BeTrue(because: "CVSM review action page should be displayed when user clicks next button in CVSM select assets page.");
        }
        

        [Then(@"Item to push value is displayed")]
        public void ThenItemToPushValueIsDisplayed()
        {
            (_updateReviewActionPage.ItemToPushValue.GetElementVisibility()).Should().BeTrue(because: "Item to push value should be displayed in CVSM review action page");
        }

        [Then(@"Destinations value is displayed")]
        public void ThenDestinationsValueIsDisplayed()
        {
            (_updateReviewActionPage.DestinationValue.GetElementVisibility()).Should().BeTrue(because: "Destinations value should be displayed in CVSM review action page");
        }

        [Then(@"Review action indicator is highlighted")]
        public void ThenReviewActionIndicatorIsHighlighted()
        {
            string reviewActionColor = _updateReviewActionPage.Heading.GetCssValue("color");
            (reviewActionColor).Should().BeEquivalentTo(UpdateReviewActionPageExpectedValues.HighlightedHeadingColor, because: "Review action indicator should be highlighted in CVSM review action page");
        }

        [Then(@"Confirm button is enabled")]
        public void ThenConfirmButtonIsEnabled()
        {
            (_updateReviewActionPage.ConfirmButton.Enabled).Should().BeTrue(because: "Confirm button should be enabled by default in CVSM review action page.");
        }


        [When(@"user clicks Confirm button")]
        public void WhenUserClicksConfirmButton()
        {
            _updateReviewActionPage.ConfirmButton.Click();
        }

        [Then(@"Update process has been established message is displayed")]
        public void ThenUpdateProcessHasBeenEstablishedMessageIsDisplayed()
        {
            (_updateSelectDevicePage.SuccessUpadteMessage.GetElementVisibility()).Should().BeTrue(because: "Update process Message should be displayed when user clicks confirm button on CVSM review action page.");
            (_updateSelectDevicePage.SuccessUpadteMessage.Text).Should().BeEquivalentTo(UpdateSelectDevicesPageExpectedValues.UpdateProcessMessageText, because: "Update message should match with the expected value.");
        }

        [Then(@"Select devices page is displayed")]
        public void ThenSelectDevicesPageIsDisplayed()
        {
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(UpdateSelectDevicesPage.Locators.SelectAllcheckBoxID)));
            bool IsSelectDevicePageDisplayed = (_updateSelectDevicePage.SelectAllcheckBox.GetElementVisibility()) || (_updateSelectDevicePage.DeployHead.GetElementVisibility());
            (IsSelectDevicePageDisplayed).Should().BeTrue(because: "Select devices page should be displayed");
        }

        [Then(@"Next page icon is enabled")]
        public void ThenNextPageIconIsEnabled()
        {
            SetMethods.ScrollToBottomofWebpage(_driver);
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(UpdatesSelectUpdatePage.Locators.PaginationNextIconID)));
            string PaginationNextIconImageURL = _updatesSelectUpdatePage.PaginationNextIcon.FindElement(By.TagName("img")).GetAttribute("src");
            (PaginationNextIconImageURL).Should().BeEquivalentTo(UpdatesSelectUpdatePageExpectedValues.PaginationNextIconEnabledSource, because: "Next page icon should be enabled");
        }

        [Given(@"first (.*) entries are displayed")]
        public void GivenFirstEntriesAreDisplayed(int noOfEntries)
        {
            (_updatesSelectUpdatePage.FileNameList.GetElementCount()).Should().Be(noOfEntries, because: noOfEntries+" entries should display");
        }

        [When(@"user clicks Next page button")]
        public void WhenUserClicksNextPageButton()
        {
            SetMethods.ScrollToBottomofWebpage(_driver);
            _updatesSelectUpdatePage.PaginationNextIcon.Click();
        }

        [Then(@"second page of entries is displayed")]
        public void ThenSecondPageOfEntriesIsDisplayed()
        {
            Thread.Sleep(1000);
            string PageNumber = _updatesSelectUpdatePage.PaginationXofY.Text;
            (PageNumber).Should().StartWithEquivalentOf("Page 2", because:"second page entries should be displayed");
            (_updatesSelectUpdatePage.FileNameList.GetElementCount()).Should().BeGreaterThan(0, because: "Atleast one entry should be present in the Second page");
        }

        [Then(@"Next button is disabled")]
        public void ThenNextButtonIsDisabled()
        {
            (_updatesSelectUpdatePage.NextButton.Enabled).Should().BeFalse(because: "Next button should be disabled");
        }

        [Then(@"Previous page icon is displayed")]
        public void ThenPreviousPageIconIsDisplayed()
        {
            (_updateSelectDevicePage.PaginationPreviousIcon.GetElementVisibility()).Should().BeTrue(because: "Previous page icon should be displayed in CVSM Select Assets page");
        }

        [Then(@"Next page icon is displayed")]
        public void ThenNextPageIconIsDisplayed()
        {
            (_updateSelectDevicePage.PaginationNextIcon.GetElementVisibility()).Should().BeTrue(because: "Next page icon should be displayed in CVSM Select Assets page");
        }

        [Then(@"Previous button is enabled")]
        public void ThenPreviousButtonIsEnabled()
        {
            (_updateReviewActionPage.PreviousButton.Enabled).Should().BeTrue(because: "previous button should be enabled in CVSM Review Action");
        }

    }
}
