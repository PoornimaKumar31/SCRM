using FluentAssertions;
using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.UpdatesTab
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5715")]
    public class Req5715Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        UpdatesSelectUpdatePage updatesSelectUpdatePage = new UpdatesSelectUpdatePage();
        UpdateSelectDevicesPage updateSelectDevicesPage = new UpdateSelectDevicesPage();
        UpdateReviewActionPage updateReviewActionPage = new UpdateReviewActionPage();


        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        private ScenarioContext _scenarioContext;

        string firstFileName = "";

        public Req5715Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"user is on RV700 Updates page")]
        public void GivenUserIsOnRVUpdatesPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.UpdatesTab.JavaSciptClick();
            updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.RV700DeviceName);
        }
        
        [Given(@"RV700 Asset type is selected")]
        public void GivenRVAssetTypeIsSelected()
        {
            Assert.AreEqual(UpdatesSelectUpdatePage.ExpectedValues.RV700DeviceName, updatesSelectUpdatePage.AssetTypeDropDown.GetSelectedOptionFromDDL(),"RV700 device is not selected in asset type dropdown.");
        }
        
        [When(@"user selects Upgrade Update type")]
        public void WhenUserSelectsUpgradeUpdateType()
        {
            updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade);
        }
        
        [Then(@"Upgrade displays as Update type")]
        public void ThenUpgradeDisplaysAsUpdateType()
        {
            Assert.AreEqual(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade, updatesSelectUpdatePage.UpgradeTypeDropDown.GetSelectedOptionFromDDL(), "Update type is not selected in Upgrade type dropdown.");
        }
        
        [Then(@"RV700 upgrade list is displayed")]
        public void ThenRVUpgradeListIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.FileTableList.GetElementVisibility(),"Rv700 upgrade list is not displayed.");
        }
        
        [Then(@"Name column heading is displayed")]
        public void ThenNameColumnHeadingIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.RV700NameColumnHeading.GetElementVisibility(),"Name column heading is not displayed.");
        }
        
        [Then(@"Date created column heading is displayed")]
        public void ThenDateCreatedColumnHeadingIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.RV700DateColumnHeading.GetElementVisibility(), "Date column heading is not displayed.");
        }
        
        [Then(@"Next button is disabled")]
        public void ThenNextButtonIsDisabled()
        {
            if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("rv700 upgrade elements"))
            {
                Assert.AreEqual(false, updatesSelectUpdatePage.NextButton.Enabled, "Next button is enabled.");
            }
            else if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("rv700 select assets elements"))
            {
                Assert.AreEqual(false, updateSelectDevicesPage.NextButton.Enabled, "Next button is enabled.");
            }
            else
            {
                Assert.Fail(_scenarioContext.ScenarioInfo.Title + " does not have step defination for " + _scenarioContext.StepContext.StepInfo.Text);
            }
            
        }
        
        [Then(@"Page x of y label is displayed")]
        public void ThenPageXOfYLabelIsDisplayed()
        {
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("rv700 upgrade elements"))
            {
                Assert.IsTrue(updatesSelectUpdatePage.PaginationXofY.GetElementVisibility(), "Page X of Y label is not displayed.");
            }
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("rv700 select assets elements"))
            {
                Assert.IsTrue(updateSelectDevicesPage.PaginationXofY.GetElementVisibility(), "Page X of Y label is not displayed.");
            }
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
                Assert.AreEqual(true, updatesSelectUpdatePage.PaginationDisplayXY.GetElementVisibility(), "Displaying X - Y of z results label is not displayed.");
            }
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("rv700 select assets elements"))
            {
                Assert.AreEqual(true, updateSelectDevicesPage.PaginationDisplayXY.GetElementVisibility(), "Displaying X - Y of z results label is not displayed.");
            }
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
            updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade);
            if(entries.Trim().Equals("<=50"))
            {
                ExpectedNoOfEntires = 50;
            }
            int ActualNumberOfEntries = updatesSelectUpdatePage.RV700FileNameList.GetElementCount();
            Assert.LessOrEqual(ActualNumberOfEntries,ExpectedNoOfEntires, ActualNumberOfEntries + " entries are displayed");
        }

        [Then(@"Previous page icon is disabled")]
        public void ThenPreviousPageIconIsDisabled()
        {
            //Checking the image source
            string ActualPreviousPageIconState = updatesSelectUpdatePage.PaginationPreviousIcon.FindElement(By.TagName("img")).GetAttribute("src");
            string ExpectedPreviousPageIconState = PropertyClass.BaseURL + UpdatesSelectUpdatePage.ExpectedValues.PaginationPreviousIconDiabledSource;
            Assert.AreEqual(ExpectedPreviousPageIconState, ActualPreviousPageIconState, "Previous page icon is not disabled.");
        }

        [Then(@"Next page icon is disabled")]
        public void ThenNextPageIconIsDisabled()
        {
            string ActualNextPageIconState = updatesSelectUpdatePage.PaginationNextIcon.FindElement(By.TagName("img")).GetAttribute("src");
            string ExpectedNextPageIconState = PropertyClass.BaseURL + UpdatesSelectUpdatePage.ExpectedValues.PaginationNextIconDiabledSource;
            Assert.AreEqual(ExpectedNextPageIconState, ActualNextPageIconState, "Next page icon is not disabled.");
        }

        [Given(@"Upgrade Update type is selected")]
        public void GivenUpgradeUpdateTypeIsSelected()
        {
            updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade);
        }

        [Given(@"user has selected Upgrade file")]
        public void GivenUserHasSelectedUpgradeFile()
        {
            //Clicking on the first file
            updatesSelectUpdatePage.RV700FileNameList[0].Click();
        }

        [When(@"user clicks Next button")]
        public void WhenUserClicksNextButton()
        {
            updatesSelectUpdatePage.NextButton.Click();
        }

        [Then(@"RV700 Select assets page is displayed")]
        public void ThenRVSelectAssetsPageIsDisplayed()
        {
            bool IsSelectAssetPageDisplayed = (updateSelectDevicesPage.ItemtoPush.GetElementVisibility()) || (updateSelectDevicesPage.DestinationLabel.GetElementVisibility());
            Assert.IsTrue(IsSelectAssetPageDisplayed, "Select assets page is not displayed.");
        }

        [Given(@"user is on RV700 Upgrade Select assets page")]
        public void GivenUserIsOnRVUpgradeSelectAssetsPage()
        {
            //Go to updates page
            GivenUserIsOnRVUpdatesPage();
            updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade);
            //Clicking on the first file
            updatesSelectUpdatePage.RV700FileNameList[0].Click();
            firstFileName = updatesSelectUpdatePage.RV700FileNameList[0].Text;
            updatesSelectUpdatePage.NextButton.Click();
            ThenRVSelectAssetsPageIsDisplayed();
        }

        [Then(@"Select update indicator is not highlighted")]
        public void ThenSelectUpdateIndicatorIsNotHighlighted()
        {
            //Checking the font color
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
        public void ThenLabelIsDisplayed(string LabelName)
        {
            IWebElement label=null;
            string ExpectedLabelName = "";
           switch (LabelName.ToLower().Trim())
            {
                case "item to push":
                    label = updateSelectDevicesPage.ItemtoPush;
                    ExpectedLabelName = UpdateSelectDevicesPage.ExpectedValues.ItemToPushLabelText;
                    break;
                case "device type":
                    label = updateSelectDevicesPage.DeviceTypeLabel;
                    ExpectedLabelName = UpdateSelectDevicesPage.ExpectedValues.RV700DeviceName;
                    break;
                case "update type":
                    label = updateSelectDevicesPage.TypeofUpdateConfigLabel;
                    ExpectedLabelName = UpdateSelectDevicesPage.ExpectedValues.ConfigureLabelText;
                    break;
                case "upgrade file to push":
                    label = updateSelectDevicesPage.FileName;
                    ExpectedLabelName = firstFileName;
                    break;
                case "destinations":
                    label = updateSelectDevicesPage.DestinationLabel;
                    ExpectedLabelName = UpdateSelectDevicesPage.ExpectedValues.DestinationLabelText;
                    break;
                default: Assert.Fail(LabelName + " is a invalid label name.");
                    break;
            }
            Assert.IsTrue(label.GetElementVisibility(), LabelName+" label name is not displayed.");
            Assert.AreEqual(ExpectedLabelName.ToLower(), label.Text.ToLower(), LabelName + " label name is not matching with the expected value.");
        }

        [Then(@"location hierarchy selectors are displayed")]
        public void ThenLocationHierarchySelectorsAreDisplayed()
        {
            Assert.IsTrue(updateSelectDevicesPage.LocationHierarchy.GetElementVisibility(), "location hierarchy selectors are not displayed");
        }

        [Then(@"count of selected devices is displayed")]
        public void ThenCountOfSelectedDevicesIsDisplayed()
        {
            Assert.IsTrue(updateSelectDevicesPage.DeviceCount.GetElementVisibility(), "count of selected devices is not displayed");
        }

        [Then(@"Previous button is enabled")]
        public void ThenPreviousButtonIsEnabled()
        {
            Assert.IsTrue(updateSelectDevicesPage.PreviousButton.Enabled, "Previous button is disabled.");
        }

        [Then(@"Select all checkbox is unchecked")]
        public void ThenSelectAllCheckboxIsUnchecked()
        {
            Assert.IsFalse(updateSelectDevicesPage.SelectAllcheckBox.Selected,"Select all checkbox is checked.");
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string columnHeading)
        {
            IWebElement HeadingElement = null;
            string ExpectedHeadingText = null;
            switch (columnHeading.ToLower().Trim())
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
                    Assert.Fail(columnHeading + " is a invalid heading name");
                    break;
            }
            Assert.AreEqual(true, HeadingElement.GetElementVisibility(), columnHeading + " is not displayed.");
            string ActualHeadingText = HeadingElement.Text.ToLower();
            Assert.AreEqual(ExpectedHeadingText.ToLower(), ActualHeadingText, columnHeading + " not matches with the expected value");
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

        [Then(@"count of selected devices changes from 0 to 1")]
        public void ThenCountOfSelectedDevicesChangesFromTo()
        {
            string deviceCount = updateSelectDevicesPage.DeviceCount.Text.ToLower();
            Assert.AreEqual(UpdateSelectDevicesPage.ExpectedValues.Desination1DeviceCountText.ToLower(), deviceCount,"Device count is not updated. device count:"+deviceCount);
        }

        [Then(@"Next button is enabled")]
        public void ThenNextButtonIsEnabled()
        {
            Assert.IsTrue(updateSelectDevicesPage.NextButton.Enabled, "Next button is disabled.");
        }

        [When(@"user clicks Previous button")]
        public void WhenUserClicksPreviousButton()
        {
            updateSelectDevicesPage.PreviousButton.Click();
        }

        [Then(@"RV700 Updates page is displayed")]
        public void ThenRVUpdatesPageIsDisplayed()
        {
            bool IsUpdatePageDisplayed = (updatesSelectUpdatePage.AssetTypeDropDown.GetElementVisibility()) || (updatesSelectUpdatePage.UpgradeTypeDropDown.GetElementVisibility());
            Assert.IsTrue(IsUpdatePageDisplayed, "RV700 Updates page is not displayed");
        }

        [When(@"Clicks Next button")]
        public void WhenClicksNextButton()
        {
            updateSelectDevicesPage.NextButton.Click();
        }

        [Then(@"RV700 Review Action page is displayed")]
        public void ThenRVReviewActionPageIsDisplayed()
        {
            bool IsReviewActionPageDisplayed = (updateReviewActionPage.ItemToPushLabel.GetElementVisibility()) || (updateReviewActionPage.DestinationLabel.GetElementVisibility());
            Assert.IsTrue(IsReviewActionPageDisplayed, "RV700 Review Action page is not displayed.");
        }

        [Given(@"user is on RV700 Review Action page")]
        public void GivenUserIsOnRVReviewActionPage()
        {
            GivenUserIsOnRVUpgradeSelectAssetsPage();
            updateSelectDevicesPage.FirstDeviceCheckBox.Click();
            updateSelectDevicesPage.NextButton.Click();
            ThenRVReviewActionPageIsDisplayed();
        }

        [Then(@"Item to push label is displayed")]
        public void ThenItemToPushLabelIsDisplayed()
        {
            Assert.IsTrue(updateReviewActionPage.ItemToPushLabel.GetElementVisibility(),"Item to push label is not displayed.");
            Assert.AreEqual(UpdateReviewActionPage.ExpectedValues.ItemToPushLabelText.ToLower(), updateReviewActionPage.ItemToPushLabel.Text.ToLower(),"Item to push label is not matching with the expected text.");
        }

        [Then(@"Item to push value is displayed")]
        public void ThenItemToPushValueIsDisplayed()
        {
            Assert.IsTrue(updateReviewActionPage.ItemToPushValue.GetElementVisibility(), "Item to push value is not displayed.");
        }

        [Then(@"Destinations label is displayed")]
        public void ThenDestinationsLabelIsDisplayed()
        {
            Assert.IsTrue(updateReviewActionPage.DestinationLabel.GetElementVisibility(),"Destination label is not displayed.");
            Assert.AreEqual(UpdateReviewActionPage.ExpectedValues.DestinationLabelText.ToLower(), updateReviewActionPage.DestinationLabel.Text.ToLower(),"Destination label is not matching the expected value.");
        }

        [Then(@"Destinations value is displayed")]
        public void ThenDestinationsValueIsDisplayed()
        {
            Assert.IsTrue(updateReviewActionPage.DestinationValue.GetElementVisibility(), "Destination value is not displayed.");
        }

        [Then(@"Select assets indicator is not highlighted")]
        public void ThenSelectAssetsIndicatorIsNotHighlighted()
        {
            Assert.AreEqual(UpdateSelectDevicesPage.ExpectedValues.NonHighlightedHeadingColor,updateSelectDevicesPage.Heading.GetCssValue("color"),"Select devices tab is highlighted.");
        }

        [Then(@"Review action indicator is highlighted")]
        public void ThenReviewActionIndicatorIsHighlighted()
        {
            Assert.AreEqual(UpdateReviewActionPage.ExpectedValues.HighlightedHeadingColor, updateReviewActionPage.Heading.GetCssValue("color"),"Review action indicator is not highlighted.");
        }

        [Then(@"Confirm button is enabled")]
        public void ThenConfirmButtonIsEnabled()
        {
            //Assert.IsTrue(updateReviewActionPage.ConfirmButton.Enabled, "Confirm buton is disabled.");
            bool IsConfirmButtonEnabled = updateReviewActionPage.ConfirmButton.Enabled;
            (IsConfirmButtonEnabled).Should().Be(true,"Confirm button should be enabled in the review action page.");
        }

        [When(@"user clicks Confirm button")]
        public void WhenUserClicksConfirmButton()
        {
            updateReviewActionPage.ConfirmButton.Click();
        }

        [Then(@"Update process has been established message is displayed")]
        public void ThenUpdateProcessHasBeenEstablishedMessageIsDisplayed()
        {
            Assert.IsTrue(updateSelectDevicesPage.SuccessUpadteMessage.GetElementVisibility(),"Update success message is not displayed.");
            Assert.AreEqual(UpdateSelectDevicesPage.ExpectedValues.UpdateProcessMessageText.ToLower(),updateSelectDevicesPage.SuccessUpadteMessage.Text.ToLower(),"Update success message is not matching the expected value.");
        }

        [Then(@"Select assets page is displayed")]
        public void ThenSelectAssetsPageIsDisplayed()
        {
            bool IsSelectAssetPageDisplayed = (updateSelectDevicesPage.ItemtoPush.GetElementVisibility()) || (updateSelectDevicesPage.DestinationLabel.GetElementVisibility());
            Assert.IsTrue(IsSelectAssetPageDisplayed, "Select assets page is not displayed.");
        }

    }
}
