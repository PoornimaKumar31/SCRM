using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.UpdatesTab.UpgradeUpdate
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5705")]
    class Req5705Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        UpdatesSelectUpdatePage updatesSelectUpdatePage = new UpdatesSelectUpdatePage();
        UpdateSelectDevicesPage updateSelectDevicesPage = new UpdateSelectDevicesPage();
        UpdateReviewActionPage updateReviewActionPage = new UpdateReviewActionPage();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        private ScenarioContext _scenarioContext;
        string UpgardeFileName;

        public Req5705Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"user is on CSM Updates page")]
        public void GivenUserIsOnCSMUpdatesPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.UpdatesTab.JavaSciptClick();
            updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.CSMDeviceName);
        }

        [Given(@"CSM Asset type is selected")]
        public void GivenCSMAssetTypeIsSelected()
        {
            string SelectedAssetType = updatesSelectUpdatePage.AssetTypeDropDown.GetSelectedOptionFromDDL();
            string ExpectedAssetType = UpdatesSelectUpdatePage.ExpectedValues.CSMDeviceName;
            Assert.AreEqual(ExpectedAssetType, SelectedAssetType, "CSM is not selected as asset type.");
        }

        [When(@"user selects Upgrade Update type")]
        public void WhenUserSelectsUpgradeUpdateType()
        {
            updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade);
        }

        [Then(@"Upgrade displays as Update type")]
        public void ThenUpgradeDisplaysAsUpdateType()
        {
            string SelectedUpdateType = updatesSelectUpdatePage.UpgradeTypeDropDown.GetSelectedOptionFromDDL();
            string ExpectedUpdateType = UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade;
            Assert.AreEqual(ExpectedUpdateType, SelectedUpdateType, "Upgrade is not selected as Update type.");
        }

        [Then(@"CSM upgrade list is displayed")]
        public void ThenCSMUpgradeListIsDisplayed()
        {
            Thread.Sleep(4000);
            Assert.AreEqual(true, updatesSelectUpdatePage.FileNameList.GetElementCount()>0, "CSM Update List is not displayed");
        }

        [Then(@"Manage Active Updates button is displayed")]
        public void ThenManageActiveUpdatesButtonIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.ManageActiveUpgradesButton.GetElementVisibility(), "Manage Active button label is not displayed");
        }

        [Then(@"Name column heading is displayed")]
        public void ThenNameColumnHeadingIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.NameColumnHeading.GetElementVisibility(), "Name column heading is not displayed");
            Assert.AreEqual(UpdatesSelectUpdatePage.ExpectedValues.TableNameHeadingText, updatesSelectUpdatePage.NameColumnHeading.Text, "Name column heading is not matching with the expected value.");
        }

        [Then(@"Date created column heading is displayed")]
        public void ThenDateCreatedColumnHeadingIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.DateColumnHeading.GetElementVisibility(), "Date Column heading is not displayed");
            Assert.AreEqual(UpdatesSelectUpdatePage.ExpectedValues.TableDateHeadingText, updatesSelectUpdatePage.DateColumnHeading.Text, "Date column heading is not matching the expected value.");
        }

        [Then(@"Next button is disabled")]
        public void ThenNextButtonIsDisabled()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.NextButton.GetElementVisibility(), "Next Button is not displayed");
        }

        [Then(@"Page x of y label is displayed")]
        public void ThenPageXOfYLabelIsDisplayed()
        {
            SetMethods.ScrollToBottomofWebpage();
            Assert.AreEqual(true, updatesSelectUpdatePage.PaginationXofY.GetElementVisibility(), "Page x of y label is not displayed");
        }

        [Then(@"Displaying x to y of z results label is displayed")]
        public void ThenDisplayingXToYOfZResultsLabelIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.PaginationDisplayXY.GetElementVisibility(), "x to y of z results label is not displayed");
        }

        [Given(@"user is on CSM Updates page with ""(.*)"" entries")]
        public void GivenUserIsOnCSMUpdatesPageWithEntries(string noOfEntries)
        {
            switch (noOfEntries)
            {
                case "<= 50":
                    GivenUserIsOnCSMUpdatesPage();
                    updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade);
                    break;
                case ">50 and <=100":
                    GivenUserIsOnCSMUpdatesPage();
                    updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade);
                    break;
                default:
                    Assert.Fail("Invalid no of entries:" + noOfEntries);
                    break;
            }
        }


        [Then(@"Previous page icon is disabled")]
        public void ThenPreviousPageIconIsDisabled()
        {
            string PreviousPageIconImageSrc = updatesSelectUpdatePage.PaginationPreviousIcon.FindElement(By.TagName("img")).GetAttribute("src"); 
            string ExpectedImageSrc = UpdatesSelectUpdatePage.ExpectedValues.PaginationPreviousIconDiabledSource;
            Assert.AreEqual(ExpectedImageSrc,PreviousPageIconImageSrc, "Previous page icon is not disabled.");
        }

        [Then(@"Next page icon is disabled")]
        public void ThenNextPageIconIsDisabled()
        {
            string NextPageIconImageSrc = updatesSelectUpdatePage.PaginationNextIcon.FindElement(By.TagName("img")).GetAttribute("src");
            string ExpectedImageSrc = UpdatesSelectUpdatePage.ExpectedValues.PaginationNextIconDiabledSource;
            Assert.AreEqual(ExpectedImageSrc, NextPageIconImageSrc, "Next page icon is not disabled.");
        }

        [Then(@"Next page icon is enabled")]
        public void ThenNextPageIconIsEnabled()
        {
            string NextPageIconImageSrc = updatesSelectUpdatePage.PaginationNextIcon.FindElement(By.TagName("img")).GetAttribute("src");
            string ExpectedImageSrc = UpdatesSelectUpdatePage.ExpectedValues.PaginationNextIconEnabledSource;
            Assert.AreEqual(ExpectedImageSrc, NextPageIconImageSrc, "Next page icon is disabled.");
        }

        [When(@"first (.*) entries are displayed")]
        public void GivenFirstEntriesAreDisplayed(int noOfEntries)
        {
            int Entries = updatesSelectUpdatePage.FileNameList.GetElementCount();
            Assert.AreEqual(noOfEntries, Entries ,"Only "+Entries+" entries are displayed.");
        }

        [When(@"user clicks Next page button")]
        public void WhenUserClicksNextPageButton()
        {
            Thread.Sleep(1000);
            updatesSelectUpdatePage.PaginationNextIcon.JavaSciptClick();
        }

        [Then(@"second page of entries is displayed")]
        public void ThenSecondPageOfEntriesIsDisplayed()
        {
            SetMethods.ScrollToBottomofWebpage();
            string PageNumber = updatesSelectUpdatePage.PaginationXofY.Text;
            Assert.AreEqual(UpdatesSelectUpdatePage.ExpectedValues.SecondPageNumber, PageNumber, "User is not on second page");
            Assert.AreEqual(true, updatesSelectUpdatePage.FileNameList.GetElementCount() > 0, "Next page entries are not displayed.");
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
            updatesSelectUpdatePage.FirstFileCVSMAndCentrellaInTable.Click();
            UpgardeFileName = updatesSelectUpdatePage.FirstFileCVSMAndCentrellaInTable.FindElement(By.Id("name")).Text;
        }

        [When(@"user clicks Next button")]
        public void WhenUserClicksNextButton()
        {
            updatesSelectUpdatePage.NextButton.Click();
        }

        [Then(@"CSM Select assets page is displayed")]
        public void ThenCSMSelectAssetsPageIsDisplayed()
        {
            bool IsSelectDevicePage = (updateSelectDevicesPage.ItemtoPush.GetElementVisibility()) || (updateSelectDevicesPage.DeviceTypeLabel.GetElementVisibility());
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
            Assert.AreEqual(UpdateSelectDevicesPage.ExpectedValues.NonHighlightedHeadingColor, updatesSelectUpdatePage.Heading.GetCssValue("color"), "Select update indicator is highlighted");
        }

        [Then(@"Select assets indicator is highlighted")]
        public void ThenSelectAssetsIndicatorIsHighlighted()
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
            string ExpectedText="";
            switch (labelName.ToLower().Trim())
            {
                case "item to push":
                    labelElement = updateSelectDevicesPage.ItemtoPush;
                    ExpectedText = UpdateSelectDevicesPage.ExpectedValues.ItemToPushLabelText;
                    break;
                case "device type":
                    labelElement = updateSelectDevicesPage.DeviceTypeLabel;
                    ExpectedText = UpdateSelectDevicesPage.ExpectedValues.CSMDeviceName;
                    break;
                case "update type":
                    labelElement = updateSelectDevicesPage.TypeOfUpdateUpgradeLabel;
                    ExpectedText = UpdateSelectDevicesPage.ExpectedValues.UpgradeLabelText;
                    break;
                case "upgrade file to push":
                    labelElement = updateSelectDevicesPage.FileName;
                    ExpectedText = UpgardeFileName;
                    break;
                case "destinations":
                    labelElement = updateSelectDevicesPage.DestinationLabel;
                    ExpectedText = UpdateSelectDevicesPage.ExpectedValues.DestinationLabelText;
                    break;
                default:
                    Assert.Fail(labelName + " is an invalid label name");
                    break;
            }
            Assert.AreEqual(true, labelElement.GetElementVisibility(), labelName + " label is not dispalyed");
            Assert.AreEqual(ExpectedText.ToLower(), labelElement.Text.ToLower(), labelName+" is not matching the expected value.");
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

        [Then(@"Previous page icon is enabled")]
        public void ThenPreviousPageIconIsEnabled()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.PaginationPreviousIcon.Enabled, "Previous page icon is not enabled");
        }


        [Then(@"Select all checkbox is unchecked")]
        public void ThenSelectAllCheckboxIsUnchecked()
        {
            Assert.AreEqual(false, updateSelectDevicesPage.SelectAllcheckBox.Selected, "Select all checkbox in column 1 is not displayed");
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string HeadingName)
        {
            IWebElement HeadingElement = null;
            string ExpectedHeadingText = null;
            switch (HeadingName.ToLower().Trim())
            {
                case "firmware":
                    HeadingElement = updateSelectDevicesPage.FirmwareHeading;
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
                case "serial number":
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
            string firstcolumnId = updateSelectDevicesPage.TableHeading.FindElements(By.TagName("div"))[columnNumber - 1].GetAttribute("id");
            Assert.AreEqual(UpdateSelectDevicesPage.Locators.SelectAllcheckBoxID, firstcolumnId, "Select all checkbox is not in column " + columnNumber);
        }

        [Then(@"""(.*)"" label is in column (.*)")]
        public void ThenLabelIsInColumn(string columnHeading, int columnNumber)
        {
            IList<IWebElement> columns = updateSelectDevicesPage.TableHeading.FindElements(By.TagName("div"));
            Assert.AreEqual(columnHeading.ToLower().Trim(), columns[columnNumber - 1].Text.ToLower(), columnHeading + " is not in " + columnNumber);
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

        [Then(@"CSM Updates page is displayed")]
        public void ThenCSMUpdatesPageIsDisplayed()
        {
            bool IsUpdatePage = (updatesSelectUpdatePage.AssetTypeDropDown.GetElementVisibility()) || (updatesSelectUpdatePage.UpgradeTypeDropDown.GetElementVisibility());
            Assert.AreEqual(true, IsUpdatePage, "CSM update page is not displayed");
        }

        [When(@"Clicks Next button")]
        public void WhenClicksNextButton()
        {
            updateSelectDevicesPage.NextButton.Click();
        }

        [Then(@"CSM Review Action page is displayed")]
        public void ThenCSMReviewActionPageIsDisplayed()
        {
            bool IsReviewActionPage = (updateReviewActionPage.ItemToPushLabel.GetElementVisibility()) || (updateReviewActionPage.DestinationLabel.GetElementVisibility());
            Assert.AreEqual(true, IsReviewActionPage, "CSM Review action page is not displayed.");
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
            Assert.AreEqual(true, updateReviewActionPage.ItemToPushLabel.GetElementVisibility(), "Item to push label is not displayed.");
            Assert.AreEqual(UpdateReviewActionPage.ExpectedValues.ItemToPushLabelText, updateReviewActionPage.ItemToPushLabel.Text, "Item to push label is not matching the expected value.");
        }

        [Then(@"Item to push value is displayed")]
        public void ThenItemToPushValueIsDisplayed()
        {
            Assert.AreEqual(true, updateReviewActionPage.ItemToPushValue.GetElementVisibility(), "Item to push value is not displayed.");
            Assert.AreEqual(UpgardeFileName.ToLower(), updateReviewActionPage.ItemToPushValue.Text.ToLower(), "Item to push value is not matching the expected value.");
        }

        [Then(@"Destinations label is displayed")]
        public void ThenDestinationsLabelIsDisplayed()
        {
            Assert.AreEqual(true, updateReviewActionPage.DestinationLabel.GetElementVisibility(), "Destinations label is not displayed.");
            Assert.AreEqual(UpdateReviewActionPage.ExpectedValues.DestinationLabelText.ToLower(), updateReviewActionPage.DestinationLabel.Text.ToLower(),"Destination text is not matching the expected value.");
        }

        [Then(@"Destinations value is displayed")]
        public void ThenDestinationsValueIsDisplayed()
        {
            Assert.AreEqual(true, updateReviewActionPage.DestinationValue.GetElementVisibility(), "Destinations value is not displayed.");    
        }

        [Then(@"Date or Time of push label is displayed")]
        public void ThenDateOrTimeOfPushLabelIsDisplayed()
        {
            Assert.AreEqual(true, updateReviewActionPage.DateOrTimePushLabel.GetElementVisibility(), "Date or Time Label is not displayed");
            Assert.AreEqual(UpdateReviewActionPage.ExpectedValues.DateOrTimeOfPushLabelText.ToLower(), updateReviewActionPage.DateOrTimePushLabel.Text.ToLower(), "Date or time label is not matching with the expected value.");
        }

        [Then(@"Immediately label is displayed")]
        public void ThenImmediatelyLabelIsDisplayed()
        {
            Assert.AreEqual(true, updateReviewActionPage.ImmediateLabel.GetElementVisibility(), "Immediate label is not displayed");
            Assert.AreEqual(UpdateReviewActionPage.ExpectedValues.ImmediatelyLabel.ToLower(), updateReviewActionPage.ImmediateLabel.Text.ToLower(),"Immediate label is not matching with expected value.");
        }

        [Then(@"Radio Button is displayed for Immediately")]
        public void ThenCheckboxIsDisplayedForImmediately()
        {
            Assert.AreEqual(true, updateReviewActionPage.ImmediateCheckbox.GetElementVisibility(), "Checkbox is not displayed");
            
        }

        [Then(@"it is selected")]
        public void AndItIsSelected()
        {
            Assert.AreEqual(true, updateReviewActionPage.ImmediateCheckbox.Selected, "CheckBox is not selected");
        }

        [Then(@"Radio Button is displayed for schedule")]
        public void ThenCheckboxIsDisplayedForSchedule()
        {
            Assert.AreEqual(true, updateReviewActionPage.ScheduleCheckbox.GetElementVisibility(), "Schedule checkbox is not displayed");
        }

        [Then(@"Schedule label is displayed")]
        public void ThenScheduleLabelIsDisplayed()
        {
            Assert.AreEqual(true, updateReviewActionPage.ScheduleLabel.GetElementVisibility(), "Schedule Label is not displayed");
            Assert.AreEqual(UpdateReviewActionPage.ExpectedValues.ScheduleLabelText.ToLower(), updateReviewActionPage.ScheduleLabel.Text.ToLower(),"Schedule label is not matchig with the expected value.");
        }

        [Then(@"Select assets indicator is not highlighted")]
        public void ThenSelectAssetsIndicatorIsNotHighlighted()
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
            Assert.AreEqual(true,updateSelectDevicesPage.SuccessUpadteMessage.GetElementVisibility(),"Update message is not displayed.");
            Assert.AreEqual(UpdateSelectDevicesPage.ExpectedValues.UpdateProcessMessageText.ToLower(), updateSelectDevicesPage.SuccessUpadteMessage.Text.ToLower(),"Update message is not matching with expected value.");
        }

        [Then(@"Select assets page is displayed")]
        public void ThenSelectAssetsPageIsDisplayed()
        {
            bool IsSelectDevicePage = (updateSelectDevicesPage.ItemtoPush.GetElementVisibility()) || (updateSelectDevicesPage.DeviceTypeLabel.GetElementVisibility());
            Assert.AreEqual(true, IsSelectDevicePage, "Select devices page is not displayed");
        }

    }
}
