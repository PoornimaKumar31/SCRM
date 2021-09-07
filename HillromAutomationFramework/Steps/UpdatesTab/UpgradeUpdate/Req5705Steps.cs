using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.UpdatesTab.UpgradeUpdate
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5705")]
    class Req5705Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly UpdatesSelectUpdatePage _updatesSelectUpdatePage;
        private readonly UpdateSelectDevicesPage _updateSelectDevicesPage;
        private readonly UpdateReviewActionPage _updateReviewActionPage;
        private readonly WebDriverWait _wait;
        private readonly ScenarioContext _scenarioContext;

        string UpgardeFileName;

        public Req5705Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage();
            _landingPage = new LandingPage();
            _mainPage = new MainPage();
            _updatesSelectUpdatePage = new UpdatesSelectUpdatePage();
            _updateSelectDevicesPage = new UpdateSelectDevicesPage();
            _updateReviewActionPage = new UpdateReviewActionPage(); 
        }
        [Given(@"user is on CSM Updates page")]
        public void GivenUserIsOnCSMUpdatesPage()
        {
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));

            _mainPage.UpdatesTab.JavaSciptClick();
            _updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.CSMDeviceName);
        }

        [Given(@"CSM Asset type is selected")]
        public void GivenCSMAssetTypeIsSelected()
        {
            string SelectedOptionInAssetType = _updatesSelectUpdatePage.AssetTypeDropDown.GetSelectedOptionFromDDL();
            (SelectedOptionInAssetType).Should().BeEquivalentTo(UpdatesSelectUpdatePage.ExpectedValues.CSMDeviceName, because: "CSM option should be displayed in asset type dropdown when user selects asset type as CSM in updates tab.");
        }

        [When(@"user selects Upgrade Update type")]
        public void WhenUserSelectsUpgradeUpdateType()
        {
            _updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade);
        }

        [Then(@"Upgrade displays as Update type")]
        public void ThenUpgradeDisplaysAsUpdateType()
        {
            string SelectedOptionInUpdateType = _updatesSelectUpdatePage.UpgradeTypeDropDown.GetSelectedOptionFromDDL();
            (SelectedOptionInUpdateType).Should().BeEquivalentTo(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade, because: "Upgrade option should be displayed in update type dropdown when user selects update type as Upgrade in updates tab.");
        }

        [Then(@"CSM upgrade list is displayed")]
        public void ThenCSMUpgradeListIsDisplayed()
        {
            Thread.Sleep(3000);
            (_updatesSelectUpdatePage.FileNameList.GetElementCount()).Should().BeGreaterThan(0, because:"Configuration file list should not be empty");
        }

        [Then(@"Manage Active Updates button is displayed")]
        public void ThenManageActiveUpdatesButtonIsDisplayed()
        {
            (_updatesSelectUpdatePage.ManageActiveUpgradesButton.GetElementVisibility()).Should().BeTrue(because: "Manage Active updates button should be displayed in CSM Upgrade page");
        }

        [Then(@"Name column heading is displayed")]
        public void ThenNameColumnHeadingIsDisplayed()
        {
            (_updatesSelectUpdatePage.NameColumnHeading.GetElementVisibility()).Should().BeTrue(because: "Name column heading should be displayed in CSM Upgrades page");
            string NameColumnHeadingText = _updatesSelectUpdatePage.NameColumnHeading.Text;
            (NameColumnHeadingText).Should().BeEquivalentTo(UpdatesSelectUpdatePage.ExpectedValues.TableNameHeadingText, because: "Name column heading should match with the expected value in CSM Upgrades page.");
        }

        [Then(@"Date created column heading is displayed")]
        public void ThenDateCreatedColumnHeadingIsDisplayed()
        {
            (_updatesSelectUpdatePage.DateColumnHeading.GetElementVisibility()).Should().BeTrue(because:"Date column heading should be displayed in CSM Upgrades page");
            string DateColumnHeadingText = _updatesSelectUpdatePage.DateColumnHeading.Text;
            (DateColumnHeadingText).Should().BeEquivalentTo(UpdatesSelectUpdatePage.ExpectedValues.TableDateHeadingText, because: "Date column heading should match with the expected value in CSM Upgrades page.");
        }

        [Then(@"Next button is disabled")]
        public void ThenNextButtonIsDisabled()
        {
            (_updatesSelectUpdatePage.NextButton.Enabled).Should().BeFalse(because: "Next button should be disabled in CSM Upgrades page since user didn't select any upgrade file");
        }

        [Then(@"Page x of y label is displayed")]
        public void ThenPageXOfYLabelIsDisplayed()
        {
            SetMethods.ScrollToBottomofWebpage();
            (_updatesSelectUpdatePage.PaginationXofY.GetElementVisibility()).Should().BeTrue(because: "Page x of y label should be displayed in CSM Upgrades page");
        }

        [Then(@"Displaying x to y of z results label is displayed")]
        public void ThenDisplayingXToYOfZResultsLabelIsDisplayed()
        {
            (_updatesSelectUpdatePage.PaginationDisplayXY.GetElementVisibility()).Should().BeTrue(because: "Displaying x to y of z results label should be displayed in CSM Upgrades page");
        }

        [Given(@"user is on CSM Updates page with ""(.*)"" entries")]
        public void GivenUserIsOnCSMUpdatesPageWithEntries(string noOfEntries)
        {
            switch (noOfEntries)
            {
                case "<= 50":
                    GivenUserIsOnCSMUpdatesPage();
                    _updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade);
                    break;
                case ">50 and <=100":
                    GivenUserIsOnCSMUpdatesPage();
                    _updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade);
                    break;
                default:
                    Assert.Fail("Invalid no of entries:" + noOfEntries);
                    break;
            }
        }


        [Then(@"Previous page icon is disabled")]
        public void ThenPreviousPageIconIsDisabled()
        {
            string PreviousPageIconImageSrc = _updatesSelectUpdatePage.PaginationPreviousIcon.FindElement(By.TagName("img")).GetAttribute("src"); 
            (PreviousPageIconImageSrc).Should().BeEquivalentTo(UpdatesSelectUpdatePage.ExpectedValues.PaginationPreviousIconDiabledSource, because: "Previous page icon should be disabled in First page entries list in CSM upgrades page");
        }

        [Then(@"Next page icon is disabled")]
        public void ThenNextPageIconIsDisabled()
        {
            string NextPageIconImageSrc = _updatesSelectUpdatePage.PaginationNextIcon.FindElement(By.TagName("img")).GetAttribute("src");
            (NextPageIconImageSrc).Should().BeEquivalentTo(UpdatesSelectUpdatePage.ExpectedValues.PaginationNextIconDiabledSource, because: "Next page icon should be disabled in second page entries list in CSM upgrades page where total no of entries are less than hundread.");
        }

        [Then(@"Next page icon is enabled")]
        public void ThenNextPageIconIsEnabled()
        {
            string NextPageIconImageSrc = _updatesSelectUpdatePage.PaginationNextIcon.FindElement(By.TagName("img")).GetAttribute("src");
            (NextPageIconImageSrc).Should().BeEquivalentTo(UpdatesSelectUpdatePage.ExpectedValues.PaginationNextIconEnabledSource, because: "Next page icon should be enabled in first page entries list in CSM upgrades page where total no of entries are greater than fifty.");
        }

        [When(@"first (.*) entries are displayed")]
        public void GivenFirstEntriesAreDisplayed(int noOfEntries)
        {
            int Entries = _updatesSelectUpdatePage.FileNameList.GetElementCount();
            (Entries).Should().Be(noOfEntries, because: noOfEntries+ " should be displayed per page in CSM upgrades page.");
        }

        [When(@"user clicks Next page button")]
        public void WhenUserClicksNextPageButton()
        {
            Thread.Sleep(1000);
            _updatesSelectUpdatePage.PaginationNextIcon.JavaSciptClick();
        }

        [Then(@"second page of entries is displayed")]
        public void ThenSecondPageOfEntriesIsDisplayed()
        {
            SetMethods.ScrollToBottomofWebpage();
            string PageNumber = _updatesSelectUpdatePage.PaginationXofY.Text;
            (PageNumber).Should().StartWithEquivalentOf(UpdatesSelectUpdatePage.ExpectedValues.SecondPageNumber, because: "Second page should be displayed when user clicks on next page icon in CSM Upgrades page.");
            (_updatesSelectUpdatePage.FileNameList.GetElementCount()).Should().BeGreaterThan(0, because: "Second page entries should be displayed when user cliks next page icon");
        }

        [Given(@"Upgrade Update type is selected")]
        public void GivenUpgradeUpdateTypeIsSelected()
        {
            WhenUserSelectsUpgradeUpdateType();
            ThenUpgradeDisplaysAsUpdateType();
        }

        [Given(@"user has selected Upgrade file")]
        public void GivenUserHasSelectedUpgradeFile()
        {
            _updatesSelectUpdatePage.FirstFileCVSMAndCentrellaInTable.Click();
            UpgardeFileName = _updatesSelectUpdatePage.FirstFileCVSMAndCentrellaInTable.FindElement(By.Id("name")).Text;
        }

        [When(@"user clicks Next button")]
        public void WhenUserClicksNextButton()
        {
            _updatesSelectUpdatePage.NextButton.Click();
        }

        [Then(@"CSM Select assets page is displayed")]
        public void ThenCSMSelectAssetsPageIsDisplayed()
        {
            bool IsSelectDevicePage = (_updateSelectDevicesPage.ItemtoPush.GetElementVisibility()) || (_updateSelectDevicesPage.DeviceTypeLabel.GetElementVisibility());
            Assert.AreEqual(true, IsSelectDevicePage, "Select devices page is not displayed");
        }

        [Given(@"user is on CSM Upgrade Select assets page")]
        public void GivenUserIsOnCSMUpgradeSelectassetsPage()
        {
            GivenUserIsOnCSMUpdatesPage();
            GivenCSMAssetTypeIsSelected();
            WhenUserSelectsUpgradeUpdateType();
            GivenUserHasSelectedUpgradeFile();
            WhenUserClicksNextButton();
            ThenCSMSelectAssetsPageIsDisplayed();
        }


        [Then(@"Select update indicator is not highlighted")]
        public void ThenSelectUpdateIndicatorIsNotHighlighted()
        {
            string selectUpdateIndicatorColor = _updatesSelectUpdatePage.Heading.GetCssValue("color");
            (selectUpdateIndicatorColor).Should().BeEquivalentTo(UpdatesSelectUpdatePage.ExpectedValues.NonHighlightedHeadingColor, because: "Select Update tab indicator should not be highlighted.");
        }

        [Then(@"Select assets indicator is highlighted")]
        public void ThenSelectAssetsIndicatorIsHighlighted()
        {
            string selectAssetsIndicatorColor = _updateSelectDevicesPage.Heading.GetCssValue("color");
            (selectAssetsIndicatorColor).Should().BeEquivalentTo(UpdateSelectDevicesPage.ExpectedValues.HighlightedHeadingColor, because: "Select devices tab should not be highlighted");
        }

        [Then(@"Review action indicator is not highlighted")]
        public void ThenReviewActionIndicatorIsNotHighlighted()
        {
            string ReviewActionColor = _updateReviewActionPage.Heading.GetCssValue("color");
            (ReviewActionColor).Should().BeEquivalentTo(UpdateReviewActionPage.ExpectedValues.NonHighlightedHeadingColor, because: "Review action indicator should not be highlighted.");
        }

        [Then(@"""(.*)"" label is displayed")]
        public void ThenLabelIsDisplayed(string labelName)
        {
            IWebElement labelElement = null;
            string ExpectedText="";
            switch (labelName.ToLower().Trim())
            {
                case "item to push":
                    labelElement = _updateSelectDevicesPage.ItemtoPush;
                    ExpectedText = UpdateSelectDevicesPage.ExpectedValues.ItemToPushLabelText;
                    break;
                case "device type":
                    labelElement = _updateSelectDevicesPage.DeviceTypeLabel;
                    ExpectedText = UpdateSelectDevicesPage.ExpectedValues.CSMDeviceName;
                    break;
                case "update type":
                    labelElement = _updateSelectDevicesPage.TypeOfUpdateUpgradeLabel;
                    ExpectedText = UpdateSelectDevicesPage.ExpectedValues.UpgradeLabelText;
                    break;
                case "upgrade file to push":
                    labelElement = _updateSelectDevicesPage.FileName;
                    ExpectedText = UpgardeFileName;
                    break;
                case "destinations":
                    labelElement = _updateSelectDevicesPage.DestinationLabel;
                    ExpectedText = UpdateSelectDevicesPage.ExpectedValues.DestinationLabelText;
                    break;
                default:
                    Assert.Fail(labelName + " is an invalid label name");
                    break;
            }
            (labelElement.GetElementVisibility()).Should().BeTrue(because:labelName+" should be displayed in CSM Select device page.");
            string LabelText = labelElement.Text;
            (LabelText).Should().BeEquivalentTo(ExpectedText, because: labelName + " label name should match with the expected value.");
        }

        [Then(@"location hierarchy selectors are displayed")]
        public void ThenLocationHierarchySelectorsAreDisplayed()
        {
            (_updateSelectDevicesPage.LocationHierarchy.GetElementVisibility()).Should().BeTrue(because: "location hierarchy selectors should be displayed in CSM Select assets page.");
        }

        [Then(@"count of selected devices is displayed")]
        public void ThenCountOfSelectedDevicesIsDisplayed()
        {
            (_updateSelectDevicesPage.DeviceCount.GetElementVisibility()).Should().BeTrue(because: "count of selected devices should be displayed in CSM Select assets page");
        }

        [Then(@"Previous button is enabled")]
        public void ThenPreviousButtonIsEnabled()
        {
            (_updateSelectDevicesPage.PreviousButton.Enabled).Should().BeTrue(because: "Previous button should be enabled in CSM Select assets page");
        }

        [Then(@"Previous page icon is enabled")]
        public void ThenPreviousPageIconIsEnabled()
        {
            SetMethods.ScrollToBottomofWebpage();
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(UpdatesSelectUpdatePage.Locators.PaginationPreviousIconID)));
            string PaginationPreviousIconImageURL = _updatesSelectUpdatePage.PaginationPreviousIcon.FindElement(By.TagName("img")).GetAttribute("src");
            (PaginationPreviousIconImageURL).Should().BeEquivalentTo(UpdatesSelectUpdatePage.ExpectedValues.PaginationPreviousIconEnabledSource, because: "Previous page icon should be enabled in second page of entries in select update page");
        }


        [Then(@"Select all checkbox is unchecked")]
        public void ThenSelectAllCheckboxIsUnchecked()
        {
            (_updateSelectDevicesPage.SelectAllcheckBox.Selected).Should().BeFalse(because: "Select all check box should be uncheked in CSM Upgrade Select Assets page");
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string HeadingName)
        {
            IWebElement HeadingElement = null;
            switch (HeadingName.ToLower().Trim())
            {
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
                case "location":
                    HeadingElement = _updateSelectDevicesPage.LocationHeading;
                    break;
                case "last files deployed":
                    HeadingElement = _updateSelectDevicesPage.LastFilesDeployedHeading;
                    break;
                default:
                    Assert.Fail(HeadingName + " is a invalid heading name");
                    break;
            }
            (HeadingElement.GetElementVisibility()).Should().BeTrue(because: HeadingName + " should be displayed in CSM Upgrade Select Assets page.");
            string ActualHeadingText = HeadingElement.Text;
            (ActualHeadingText).Should().BeEquivalentTo(HeadingName, because: HeadingName + " column heading name match with the expected value in CSM Upgrade Select Assets page.");
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
            (ActualDestinationCountText).Should().BeEquivalentTo(UpdateSelectDevicesPage.ExpectedValues.Desination1DeviceCountText, because: "Count of selected devices should change when user selects one device in select assets page.");
        }

        [Then(@"Next button is enabled")]
        public void ThenNextButtonIsEnabled()
        {
            (_updateSelectDevicesPage.NextButton.Enabled).Should().BeTrue(because: "Next button should be enabled when user selects atleast one device in CSM Upgrade Select Assets page");
        }

        [When(@"user clicks Previous button")]
        public void WhenUserClicksPreviousButton()
        {
            _updateSelectDevicesPage.PreviousButton.Click();
        }

        [Then(@"CSM Updates page is displayed")]
        public void ThenCSMUpdatesPageIsDisplayed()
        {
            bool IsUpdatePageDisplayed = (_updatesSelectUpdatePage.AssetTypeDropDown.GetElementVisibility()) || (_updatesSelectUpdatePage.UpgradeTypeDropDown.GetElementVisibility());
            (IsUpdatePageDisplayed).Should().BeTrue(because: "CSM update page should be displayed when user cliks previous button in CSM Upgrade Select Assets page");
        }

        [When(@"Clicks Next button")]
        public void WhenClicksNextButton()
        {
            _updateSelectDevicesPage.NextButton.Click();
        }

        [Then(@"CSM Review Action page is displayed")]
        public void ThenCSMReviewActionPageIsDisplayed()
        {
            bool IsReviewActionPageDisplayed = (_updateReviewActionPage.ItemToPushLabel.GetElementVisibility()) || (_updateReviewActionPage.DestinationLabel.GetElementVisibility());
            (IsReviewActionPageDisplayed).Should().BeTrue(because: "Review action page should be displayed when user clicks enabled next button in CSM Upgrade Select Assets page");
        }

        [Given(@"user is on CSM Review Action page")]
        public void GivenUserIsOnCSMReviewActionPage()
        {
            GivenUserIsOnCSMUpgradeSelectassetsPage();
            WhenUserSelectsOneDevice();
            WhenClicksNextButton();
            ThenCSMReviewActionPageIsDisplayed();
        }

        [Then(@"Item to push label is displayed")]
        public void ThenItemToPushLabelIsDisplayed()
        {
            (_updateReviewActionPage.ItemToPushLabel.GetElementVisibility()).Should().BeTrue(because: "Item to push label should be displayed in CSM Upgrade Review action page.");
            string ActualItemToPushLabelText = _updateReviewActionPage.ItemToPushLabel.Text;
            (ActualItemToPushLabelText).Should().BeEquivalentTo(UpdateReviewActionPage.ExpectedValues.ItemToPushLabelText, because: "Item to push label text should match with expected value in CSM Upgrade Review action page");
        }

        [Then(@"Item to push value is displayed")]
        public void ThenItemToPushValueIsDisplayed()
        {
            (_updateReviewActionPage.ItemToPushValue.GetElementVisibility()).Should().BeTrue(because: "Item to push value should be displayed in CSM Upgrade review action page");
            string actualItemToPushValue = _updateReviewActionPage.ItemToPushValue.Text;
            (actualItemToPushValue).Should().BeEquivalentTo(UpgardeFileName, because: "Item to push value should match the selcted upgrade file name in CSM Upgrade review action page");
        }

        [Then(@"Destinations label is displayed")]
        public void ThenDestinationsLabelIsDisplayed()
        {
            (_updateReviewActionPage.DestinationLabel.GetElementVisibility()).Should().BeTrue(because: "Destination label should be displayed in CSM upgrade review action Page.");
            string ActualDesinationLabelText = _updateReviewActionPage.DestinationLabel.Text;
            ActualDesinationLabelText.Should().BeEquivalentTo(UpdateReviewActionPage.ExpectedValues.DestinationLabelText, because: "Destination label text should match with expected value in CSM upgrade review action Page.");
        }

        [Then(@"Destinations value is displayed")]
        public void ThenDestinationsValueIsDisplayed()
        {
            (_updateReviewActionPage.DestinationValue.GetElementVisibility()).Should().BeTrue(because: "Destinations value should be displayed in CSM upgrade review action page");   
        }

        [Then(@"Date or Time of push label is displayed")]
        public void ThenDateOrTimeOfPushLabelIsDisplayed()
        {
            (_updateReviewActionPage.DateOrTimePushLabel.GetElementVisibility()).Should().BeTrue(because: "Date or Time Label should be displayed in CSM upgrade review action page");
            string DateTimeLabelText = _updateReviewActionPage.DateOrTimePushLabel.Text;
            (DateTimeLabelText).Should().BeEquivalentTo(UpdateReviewActionPage.ExpectedValues.DateOrTimeOfPushLabelText, because: "Date or time label should match with expected value in CSM upgrade review action Page.");
        }

        [Then(@"Immediately label is displayed")]
        public void ThenImmediatelyLabelIsDisplayed()
        {
            (_updateReviewActionPage.ImmediateLabel.GetElementVisibility()).Should().BeTrue(because: "Immediate label should be displayed in CSM upgrade review action page");
            string ImmediatelyLabelText = _updateReviewActionPage.ImmediateLabel.Text;
            (ImmediatelyLabelText).Should().BeEquivalentTo(UpdateReviewActionPage.ExpectedValues.ImmediatelyLabel, because: "Immediate label should match with expected value in CSM upgrade review action Page");
        }

        [Then(@"Radio Button is displayed for Immediately")]
        public void ThenCheckboxIsDisplayedForImmediately()
        {
            (_updateReviewActionPage.ImmediateCheckbox.GetElementVisibility()).Should().BeTrue(because: "Immediately radio button should be displayed in CSM upgrade review action page");
        }

        [Then(@"it is selected")]
        public void AndItIsSelected()
        {
            (_updateReviewActionPage.ImmediateCheckbox.Selected).Should().BeTrue(because: "Immediately radio button should be selected by default in CSM upgrade review action page");
        }

        [Then(@"Radio Button is displayed for schedule")]
        public void ThenCheckboxIsDisplayedForSchedule()
        {
            (_updateReviewActionPage.ScheduleCheckbox.GetElementVisibility()).Should().BeTrue(because: "Schedule checkbox should be displayed in CSM upgrade review action page");
        }

        [Then(@"Schedule label is displayed")]
        public void ThenScheduleLabelIsDisplayed()
        {
            (_updateReviewActionPage.ScheduleLabel.GetElementVisibility()).Should().BeTrue(because: "Schedule Label should be displayed in CSM upgrade review action page");
            string ScheduleLabelText = _updateReviewActionPage.ScheduleLabel.Text;
            (ScheduleLabelText).Should().BeEquivalentTo(UpdateReviewActionPage.ExpectedValues.ScheduleLabelText,because: "Schedule label should match with expected value in CSM upgrade review action Page");
        }

        [Then(@"Select assets indicator is not highlighted")]
        public void ThenSelectAssetsIndicatorIsNotHighlighted()
        {
            string SelectAssetsColor = _updateSelectDevicesPage.Heading.GetCssValue("color");
            (SelectAssetsColor).Should().BeEquivalentTo(UpdateSelectDevicesPage.ExpectedValues.NonHighlightedHeadingColor, because: "Select assets indicator should not be highlighted.");
        }

        [Then(@"Review action indicator is highlighted")]
        public void ThenReviewActionIndicatorIsHighlighted()
        {
            string reviewActionColor = _updateReviewActionPage.Heading.GetCssValue("color");
            (reviewActionColor).Should().BeEquivalentTo(UpdateReviewActionPage.ExpectedValues.HighlightedHeadingColor, because: "Review action indicator should be highlighted in CSM upgrade review action page");
        }

        [Then(@"Confirm button is enabled")]
        public void ThenConfirmButtonIsEnabled()
        {
            (_updateReviewActionPage.ConfirmButton.Enabled).Should().BeTrue(because: "Confirm button should be enabled by default in CSM upgrade review action page.");
        }

        [When(@"user clicks Confirm button")]
        public void WhenUserClicksConfirmButton()
        {
            _updateReviewActionPage.ConfirmButton.Click();
        }

        [Then(@"Update process has been established message is displayed")]
        public void ThenUpdateProcessHasBeenEstablishedMessageIsDisplayed()
        {
            (_updateSelectDevicesPage.SuccessUpadteMessage.GetElementVisibility()).Should().BeTrue(because: "Update process Message should be displayed when user clicks confirm button on CSM Upgrade review action page.");
            (_updateSelectDevicesPage.SuccessUpadteMessage.Text).Should().BeEquivalentTo(UpdateSelectDevicesPage.ExpectedValues.UpdateProcessMessageText, because: "Update message should match with the expected value.");
        }

        [Then(@"Select assets page is displayed")]
        public void ThenSelectAssetsPageIsDisplayed()
        {
            bool IsSelectDevicePageDisplayed = (_updateSelectDevicesPage.ItemtoPush.GetElementVisibility()) || (_updateSelectDevicesPage.DeviceTypeLabel.GetElementVisibility());
            (IsSelectDevicePageDisplayed).Should().BeTrue(because: "Select devices page should be displayed");
        }

    }
}
