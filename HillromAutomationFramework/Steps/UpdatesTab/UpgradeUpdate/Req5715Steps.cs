using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.UpdatesTab;
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
    [Binding,Scope(Tag = "SoftwareRequirementID_5715")]
    public class Req5715Steps
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

        string firstFileName = "";

        public Req5715Steps(ScenarioContext scenarioContext, IWebDriver driver)
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

        [Given(@"user is on RV700 Updates page")]
        public void GivenUserIsOnRVUpdatesPage()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.UpdatesTab.JavaSciptClick(_driver);
            _updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePageExpectedValues.RV700DeviceName);
        }
        
        [Given(@"RV700 Asset type is selected")]
        public void GivenRVAssetTypeIsSelected()
        {
            string selectedAssetType = _updatesSelectUpdatePage.AssetTypeDropDown.GetSelectedOptionFromDDL();
            (selectedAssetType).Should().BeEquivalentTo(UpdatesSelectUpdatePageExpectedValues.RV700DeviceName, because: "RV700 device should be selected when selects RV700 in asset type dropdown in Select upadtes tab.");
        }
        
        [When(@"user selects Upgrade Update type")]
        public void WhenUserSelectsUpgradeUpdateType()
        {
            _updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePageExpectedValues.UpdateTypeUpgrade);
        }
        
        [Then(@"Upgrade displays as Update type")]
        public void ThenUpgradeDisplaysAsUpdateType()
        {
            string selectedUpdateType = _updatesSelectUpdatePage.UpgradeTypeDropDown.GetSelectedOptionFromDDL();
            (selectedUpdateType).Should().BeEquivalentTo(UpdatesSelectUpdatePageExpectedValues.UpdateTypeUpgrade, because: "Upgrade type should be displayed when user selects Update as option in Upgrade type dropdown in RV700 select updates page");
        }
        
        [Then(@"RV700 upgrade list is displayed")]
        public void ThenRVUpgradeListIsDisplayed()
        {
            (_updatesSelectUpdatePage.FileTableList.GetElementVisibility()).Should().BeTrue(because: "RV700 upgrade list should be displayed in RV700 update in slect updates page");
        }
           
        [Then(@"Next button is disabled")]
        public void ThenNextButtonIsDisabled()
        {
            if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("rv700 upgrade elements"))
            {
                (_updatesSelectUpdatePage.NextButton.Enabled).Should().BeFalse(because: "Next button should be disabled since user didn't select any upgrade file in RV700 select Update page");
            }
            else if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("rv700 select assets elements"))
            {
                (_updateSelectDevicesPage.NextButton.Enabled).Should().BeFalse(because: "Next button should be disabled since user didn't select any device in RV700 select assets page");
            }
            //if test step does not belong to any scenario
            else
            {
                Assert.Fail(_scenarioContext.ScenarioInfo.Title + " does not have step defination for " + _scenarioContext.StepContext.StepInfo.Text);
            }
            
        }
        
        [Then(@"Page x of y label is displayed")]
        public void ThenPageXOfYLabelIsDisplayed()
        {
            SetMethods.ScrollToBottomofWebpage(_driver);
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("rv700 upgrade elements"))
            {
                (_updatesSelectUpdatePage.PaginationXofY.GetElementVisibility()).Should().BeTrue(because: "Page x of y label should be displayed in RV700 Select Update page");
            }
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("rv700 select assets elements"))
            {
                (_updateSelectDevicesPage.PaginationXofY.GetElementVisibility()).Should().BeTrue(because: "Page x of y label should be displayed in RV700 Select assets page");
            }
            //if test step does not belong to any scenario
            else
            {
                Assert.Fail(_scenarioContext.ScenarioInfo.Title + " does not have step defination for " + _scenarioContext.StepContext.StepInfo.Text);
            }
            
        }
        
        [Then(@"Displaying x to y of z results label is displayed")]
        public void ThenDisplayingXToYOfZResultsLabelIsDisplayed()
        {
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("rv700 upgrade elements"))
            {
                (_updatesSelectUpdatePage.PaginationDisplayXY.GetElementVisibility()).Should().BeTrue(because: "Displaying X - Y of z results label should be displayed in RV700 Select Update page");
            }
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("rv700 select assets elements"))
            {
                (_updateSelectDevicesPage.PaginationDisplayXY.GetElementVisibility()).Should().BeTrue(because: "Displaying X - Y of z results label should be displayed in RV700 Select assets page");
            }
            //if test step does not belong to any scenario
            else
            {
                Assert.Fail(_scenarioContext.ScenarioInfo.Title + " does not have step defination for " + _scenarioContext.StepContext.StepInfo.Text);
            }
            
        }

        [Given(@"user is on RV700 Updates page with ""(.*)"" entries")]
        public void GivenUserIsOnRVUpdatesPageWithEntries(string entries)
        {
            int ExpectedNoOfEntires=0;
            GivenUserIsOnRVUpdatesPage();
            _updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePageExpectedValues.UpdateTypeUpgrade);
            if(entries.Trim().Equals("<=50"))
            {
                ExpectedNoOfEntires = 50;
            }
            int ActualNumberOfEntries = _updatesSelectUpdatePage.RV700AndCentrellaFileNameList.GetElementCount();
            (ActualNumberOfEntries).Should().BeLessOrEqualTo(ExpectedNoOfEntires, because: ExpectedNoOfEntires+" entries should be displayed in RV700 Select updates page.");
        }

        [Then(@"Previous page icon is disabled")]
        public void ThenPreviousPageIconIsDisabled()
        {
            //Checking the image source
            string PreviousPageIconImageSrc = _updatesSelectUpdatePage.PaginationPreviousIcon.FindElement(By.TagName("img")).GetAttribute("src");
            (PreviousPageIconImageSrc).Should().BeEquivalentTo(PropertyClass.BaseURL+ UpdatesSelectUpdatePageExpectedValues.PaginationPreviousIconDisabledSource, because: "Previous page icon should be disabled in First page entries list in RV700 upgrades page");
        }

        [Then(@"Next page icon is disabled")]
        public void ThenNextPageIconIsDisabled()
        {
            string NextPageIconImageSrc = _updatesSelectUpdatePage.PaginationNextIcon.FindElement(By.TagName("img")).GetAttribute("src");
            (NextPageIconImageSrc).Should().BeEquivalentTo(PropertyClass.BaseURL+ UpdatesSelectUpdatePageExpectedValues.PaginationNextIconDisabledSource, because: "Next page icon should be disabled in RV700 upgrades page where total no of entries are less than or equal to 50.");
        }

        [Given(@"Upgrade Update type is selected")]
        public void GivenUpgradeUpdateTypeIsSelected()
        {
            _updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePageExpectedValues.UpdateTypeUpgrade);
        }

        [Given(@"user has selected Upgrade file")]
        public void GivenUserHasSelectedUpgradeFile()
        {
            //Clicking on the first file
            _updatesSelectUpdatePage.RV700AndCentrellaFileNameList[0].Click();
        }

        [When(@"user clicks Next button")]
        public void WhenUserClicksNextButton()
        {
            _updatesSelectUpdatePage.NextButton.Click();
        }

        [Then(@"RV700 Select assets page is displayed")]
        public void ThenRVSelectAssetsPageIsDisplayed()
        {
            bool IsSelectAssetPageDisplayed = (_updateSelectDevicesPage.ItemtoPush.GetElementVisibility()) || (_updateSelectDevicesPage.DestinationLabel.GetElementVisibility());
            (IsSelectAssetPageDisplayed).Should().BeTrue(because: "Select assets page should be displayed since user clicked Enabled next button in RV700 Select assets page");
        }

        [Given(@"user is on RV700 Upgrade Select assets page")]
        public void GivenUserIsOnRVUpgradeSelectAssetsPage()
        {
            //Go to updates page
            GivenUserIsOnRVUpdatesPage();
            _updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePageExpectedValues.UpdateTypeUpgrade);

            //Clicking on the first file
            _updatesSelectUpdatePage.RV700AndCentrellaFileNameList[0].Click();
            firstFileName = _updatesSelectUpdatePage.RV700AndCentrellaFileNameList[0].Text;

            //Clicking on next button
            _updatesSelectUpdatePage.NextButton.Click();
            ThenRVSelectAssetsPageIsDisplayed();
        }

        [Then(@"Select update indicator is not highlighted")]
        public void ThenSelectUpdateIndicatorIsNotHighlighted()
        {
            //Checking the font color
            string selectUpdateIndicatorColor = _updatesSelectUpdatePage.Heading.GetCssValue("color");
            (selectUpdateIndicatorColor).Should().BeEquivalentTo(UpdatesSelectUpdatePageExpectedValues.NonHighlightedHeadingColor, because: "Select Update tab indicator should not be highlighted.");
        }

        [Then(@"Select assets indicator is highlighted")]
        public void ThenSelectAssetsIndicatorIsHighlighted()
        {
            string selectAssetsIndicatorColor = _updateSelectDevicesPage.Heading.GetCssValue("color");
            (selectAssetsIndicatorColor).Should().BeEquivalentTo(UpdateSelectDevicesPageExpectedValues.HighlightedHeadingColor, because: "Select devices tab should be highlighted in select device tab");
        }

        [Then(@"Review action indicator is not highlighted")]
        public void ThenReviewActionIndicatorIsNotHighlighted()
        {
            string ReviewActionColor = _updateReviewActionPage.Heading.GetCssValue("color");
            (ReviewActionColor).Should().BeEquivalentTo(UpdateReviewActionPageExpectedValues.NonHighlightedHeadingColor, because: "Review action indicator should not be highlighted.");
        }

        [Then(@"""(.*)"" label is displayed")]
        public void ThenLabelIsDisplayed(string LabelName)
        {
            IWebElement label=null;
            string ExpectedLabelName = "";
           switch (LabelName.ToLower().Trim())
            {
                case "item to push":
                    label = _updateSelectDevicesPage.ItemtoPush;
                    ExpectedLabelName = UpdateSelectDevicesPageExpectedValues.ItemToPushLabelText;
                    break;
                case "asset type":
                    label = _updateSelectDevicesPage.DeviceTypeLabel;
                    ExpectedLabelName = UpdateSelectDevicesPageExpectedValues.RV700DeviceName;
                    break;
                case "update type":
                    label = _updateSelectDevicesPage.TypeOfUpdateUpgradeLabel;
                    ExpectedLabelName = UpdateSelectDevicesPageExpectedValues.UpgradeLabelText;
                    break;
                case "upgrade file to push":
                    label = _updateSelectDevicesPage.FileName;
                    ExpectedLabelName = firstFileName;
                    break;
                case "destinations":
                    label = _updateSelectDevicesPage.DestinationLabel;
                    ExpectedLabelName = UpdateSelectDevicesPageExpectedValues.DestinationLabelText;
                    break;
                default: Assert.Fail(LabelName + " is a invalid label name.");
                    break;
            }
            (label.GetElementVisibility()).Should().BeTrue(because: LabelName + " label name should be displayed in RV700 Select Assets page");
            string LabelText = label.Text;
            (LabelText).Should().BeEquivalentTo(ExpectedLabelName, because: LabelName + " label name should match with the expected value in RV700 Select Assets page");
        }

        [Then(@"location hierarchy selectors are displayed")]
        public void ThenLocationHierarchySelectorsAreDisplayed()
        {
            (_updateSelectDevicesPage.LocationHierarchy.GetElementVisibility()).Should().BeTrue(because: "location hierarchy selectors should be displayed in RV700 Select assets page.");
        }

        [Then(@"count of selected devices is displayed")]
        public void ThenCountOfSelectedDevicesIsDisplayed()
        {
            (_updateSelectDevicesPage.DeviceCount.GetElementVisibility()).Should().BeTrue(because: "count of selected devices should be displayed in RV700 Select assets page");
        }

        [Then(@"Previous button is enabled")]
        public void ThenPreviousButtonIsEnabled()
        {
            if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("rv700 select assets elements"))
            {
                (_updateSelectDevicesPage.PreviousButton.Enabled).Should().BeTrue(because: "Previous button should be enabled in RV700 Select assets page");
            }
            else if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("rv700 review action elements"))
            {
                (_updateReviewActionPage.PreviousButton.Enabled).Should().BeTrue(because: "Previous button should be enabled in RV700 Review Action page");
            }
            //if test step does not belong to any scenario
            else
            {
                Assert.Fail(_scenarioContext.ScenarioInfo.Title + " does not have step defination for " + _scenarioContext.StepContext.StepInfo.Text);
            }
            
        }

        [Then(@"Select all checkbox is unchecked")]
        public void ThenSelectAllCheckboxIsUnchecked()
        {
            (_updateSelectDevicesPage.SelectAllcheckBox.Selected).Should().BeFalse(because: "Select all checkbox should be unchecked by default in RV700 Select assets page");
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string columnHeading)
        {
            IWebElement HeadingElement = null;

            if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("rv700 upgrade elements"))
            {
                switch (columnHeading.ToLower().Trim())
                {
                    //For select update page
                    case "name":
                        HeadingElement = _updatesSelectUpdatePage.CentrellaAndRV700NameColumnHeading;
                        break;

                    case "date created":
                        HeadingElement = _updatesSelectUpdatePage.CentrellaAndRV700DateColumnHeading;
                        break;
                    default:
                        Assert.Fail(columnHeading + " is a invalid heading name");
                        break;
                }
                (HeadingElement.GetElementVisibility()).Should().BeTrue(columnHeading + " column heading should be displayed in RV700 select updates page");
                string ActualHeadingText = HeadingElement.Text.ToLower();
                (ActualHeadingText).Should().BeEquivalentTo(columnHeading, because: columnHeading + " column heading should match with the expected value in RV700 select updates page");
            }
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("rv700 select assets elements table"))
            {
                switch (columnHeading.ToLower().Trim())
                {
                    //For select device page.
                    case "firmware":
                        HeadingElement = _updateSelectDevicesPage.FirmwareHeading;
                        break;
                    case "config":
                        HeadingElement = _updateSelectDevicesPage.ConfigHeading;
                        break;
                    case "asset tag":
                        HeadingElement = _updateSelectDevicesPage.AssetTagHeading;
                        break;
                    case "serial number":
                        HeadingElement = _updateSelectDevicesPage.SerialNoHeading;
                        break;
                    case "ownership":
                        HeadingElement = _updateSelectDevicesPage.LocationHeading;
                        break;
                    case "last files deployed":
                        HeadingElement = _updateSelectDevicesPage.LastFilesDeployedHeading;
                        break;
                    default:
                        Assert.Fail(columnHeading + " is a invalid heading name");
                        break;
                }
                (HeadingElement.GetElementVisibility()).Should().BeTrue(columnHeading + " column heading should be displayed in RV700 select Assets page");
                string ActualHeadingText = HeadingElement.Text.ToLower();
                (ActualHeadingText).Should().BeEquivalentTo(columnHeading, because: columnHeading + " column heading should match with the expected value in RV700 select assets page");
            }
            //if test step does not belong to any scenario
            else
            {
                Assert.Fail(_scenarioContext.ScenarioInfo.Title + " does not have step defination for " + _scenarioContext.StepContext.StepInfo.Text);
            }
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
            (_updateSelectDevicesPage.NextButton.Enabled).Should().BeTrue(because: "Next button should be enabled when user selects atleast one device in RV700 Upgrade Select Assets page");
        }

        [When(@"user clicks Previous button")]
        public void WhenUserClicksPreviousButton()
        {
            _updateSelectDevicesPage.PreviousButton.Click();
        }

        [Then(@"RV700 Updates page is displayed")]
        public void ThenRVUpdatesPageIsDisplayed()
        {
            bool IsUpdatePageDisplayed = (_updatesSelectUpdatePage.AssetTypeDropDown.GetElementVisibility()) || (_updatesSelectUpdatePage.UpgradeTypeDropDown.GetElementVisibility());
            (IsUpdatePageDisplayed).Should().BeTrue(because: "RV700 update page should be displayed when user cliks previous button in RV700 Upgrade Select Assets page");
        }

        [When(@"Clicks Next button")]
        public void WhenClicksNextButton()
        {
            _updateSelectDevicesPage.NextButton.Click();
        }

        [Then(@"RV700 Review Action page is displayed")]
        public void ThenRVReviewActionPageIsDisplayed()
        {
            bool IsReviewActionPageDisplayed = (_updateReviewActionPage.ItemToPushLabel.GetElementVisibility()) || (_updateReviewActionPage.DestinationLabel.GetElementVisibility());
            (IsReviewActionPageDisplayed).Should().BeTrue(because: "Review action page should be displayed when user clicks enabled next button in RV700 Upgrade Select Assets page");
        }

        [Given(@"user is on RV700 Review Action page")]
        public void GivenUserIsOnRVReviewActionPage()
        {
            GivenUserIsOnRVUpgradeSelectAssetsPage();
            //Select first device
            _updateSelectDevicesPage.FirstDeviceCheckBox.Click();
            //Click on next button
            _updateSelectDevicesPage.NextButton.Click();
            ThenRVReviewActionPageIsDisplayed();
        }

        [Then(@"Item to push label is displayed")]
        public void ThenItemToPushLabelIsDisplayed()
        {
            (_updateReviewActionPage.ItemToPushLabel.GetElementVisibility()).Should().BeTrue(because: "Item to push label should be displayed in RV700 Upgrade Review action page.");
            string ActualItemToPushLabelText = _updateReviewActionPage.ItemToPushLabel.Text;
            (ActualItemToPushLabelText).Should().BeEquivalentTo(UpdateReviewActionPageExpectedValues.ItemToPushLabelText, because: "Item to push label text should match with expected value in RV700 Upgrade Review action page");
        }

        [Then(@"Item to push value is displayed")]
        public void ThenItemToPushValueIsDisplayed()
        {
            (_updateReviewActionPage.ItemToPushValue.GetElementVisibility()).Should().BeTrue(because: "Item to push value should be displayed in RV700 Upgrade review action page");
        }

        [Then(@"Destinations label is displayed")]
        public void ThenDestinationsLabelIsDisplayed()
        {
            (_updateReviewActionPage.DestinationLabel.GetElementVisibility()).Should().BeTrue(because: "Destination label should be displayed in RV700 upgrade review action Page.");
            string ActualDesinationLabelText = _updateReviewActionPage.DestinationLabel.Text;
            ActualDesinationLabelText.Should().BeEquivalentTo(UpdateReviewActionPageExpectedValues.DestinationLabelText, because: "Destination label text should match with expected value in RV700 upgrade review action Page.");
        }

        [Then(@"Destinations value is displayed")]
        public void ThenDestinationsValueIsDisplayed()
        {
            (_updateReviewActionPage.DestinationValue.GetElementVisibility()).Should().BeTrue(because: "Destinations value should be displayed in RV700 upgrade review action page");
        }

        [Then(@"Select assets indicator is not highlighted")]
        public void ThenSelectAssetsIndicatorIsNotHighlighted()
        {
            string SelectAssetsColor = _updateSelectDevicesPage.Heading.GetCssValue("color");
            (SelectAssetsColor).Should().BeEquivalentTo(UpdateSelectDevicesPageExpectedValues.NonHighlightedHeadingColor, because: "Select assets indicator should not be highlighted.");
        }

        [Then(@"Review action indicator is highlighted")]
        public void ThenReviewActionIndicatorIsHighlighted()
        {
            string reviewActionColor = _updateReviewActionPage.Heading.GetCssValue("color");
            (reviewActionColor).Should().BeEquivalentTo(UpdateReviewActionPageExpectedValues.HighlightedHeadingColor, because: "Review action indicator should be highlighted in RV700 review action page");
        }

        [Then(@"Confirm button is enabled")]
        public void ThenConfirmButtonIsEnabled()
        {
            bool IsConfirmButtonEnabled = _updateReviewActionPage.ConfirmButton.Enabled;
            (IsConfirmButtonEnabled).Should().Be(true,"Confirm button should be enabled in the review action page.");
        }

        [When(@"user clicks Confirm button")]
        public void WhenUserClicksConfirmButton()
        {
            _updateReviewActionPage.ConfirmButton.Click();
        }

        [Then(@"Update process has been established message is displayed")]
        public void ThenUpdateProcessHasBeenEstablishedMessageIsDisplayed()
        {
            (_updateSelectDevicesPage.SuccessUpadteMessage.GetElementVisibility()).Should().BeTrue(because: "Update process Message should be displayed when user clicks confirm button In RV700 Upgrade review action page.");
            (_updateSelectDevicesPage.SuccessUpadteMessage.Text).Should().BeEquivalentTo(UpdateSelectDevicesPageExpectedValues.UpdateProcessMessageText, because: "Update message should match with the expected value in RV700 Upgrade review action page");
        }

        [Then(@"Select assets page is displayed")]
        public void ThenSelectAssetsPageIsDisplayed()
        {
            bool IsSelectAssetPageDisplayed = (_updateSelectDevicesPage.ItemtoPush.GetElementVisibility()) || (_updateSelectDevicesPage.DestinationLabel.GetElementVisibility());
            (IsSelectAssetPageDisplayed).Should().BeTrue(because: "Select devices page should be displayed");
        }

    }
}
