using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.UpdatesTab
{
    [Binding,Scope(Tag = "SoftwareRequirementID_7731")]
    public sealed class Req7731Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        UpdatesSelectUpdatePage updatesSelectUpdatePage = new UpdatesSelectUpdatePage();
        UpdateSelectDevicesPage updateSelectDevicesPage = new UpdateSelectDevicesPage();
        UpdateReviewActionPage updateReviewActionPage = new UpdateReviewActionPage();

        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));


        private readonly ScenarioContext _scenarioContext;

        string FirstUpadeFileName;

        public Req7731Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"user is on Centrella Updates page")]
        public void GivenUserIsOnCentrellaUpdatesPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(landingPage.PSSServiceOrganizationFacilityBatesville, "Centrella Orgaization");
            landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.UpdatesTab.JavaSciptClick();
        }

        [Given(@"Centrella Asset type is selected")]
        public void GivenCentrellaAssetTypeIsSelected()
        {
            updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.CentrellaDeviceName);
        }

        [When(@"user selects Upgrade Update type")]
        public void WhenUserSelectsUpgradeUpdateType()
        {
            updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade);
        }

        [Then(@"Upgrade displays as Update type")]
        public void ThenUpgradeDisplaysAsUpdateType()
        {
            string SelectedOption = updatesSelectUpdatePage.UpgradeTypeDropDown.GetSelectedOptionFromDDL();
            string ExpectedOption = UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade;
            Assert.AreEqual(ExpectedOption, SelectedOption, "Upgrade is not displayed as update type.");
        }

        [Then(@"Centrella upgrade list is displayed")]
        public void ThenCentrellaUpgradeListIsDisplayed()
        {
            Assert.IsTrue(updatesSelectUpdatePage.FileTableList.GetElementVisibility(),"Centrella upgrade list is not displayed.");
        }

        [Then(@"Name column heading is displayed")]
        public void ThenNameColumnHeadingIsDisplayed()
        {
            Assert.IsTrue(updatesSelectUpdatePage.CentrellaAndRV700NameColumnHeading.GetElementVisibility(),"Name column heading is not displayed.");
            Assert.AreEqual(UpdatesSelectUpdatePage.ExpectedValues.TableNameHeadingText.ToLower(),updatesSelectUpdatePage.CentrellaAndRV700NameColumnHeading.Text.ToLower(),"Name column heading is not matching the expected value.");
        }

        [Then(@"Date created column heading is displayed")]
        public void ThenDateCreatedColumnHeadingIsDisplayed()
        {
            Assert.IsTrue(updatesSelectUpdatePage.CentrellaAndRV700DateColumnHeading.GetElementVisibility(), "Date column heading is not displayed.");
            Assert.AreEqual(UpdatesSelectUpdatePage.ExpectedValues.TableDateHeadingText.ToLower(), updatesSelectUpdatePage.CentrellaAndRV700DateColumnHeading.Text.ToLower(), "Date column heading is not matching the expected value.");
        }

        [Then(@"Next button is disabled")]
        public void ThenNextButtonIsDisabled()
        {
            //For select update page
            if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("centrella upgrade elements"))
            {
                Assert.IsFalse(updatesSelectUpdatePage.NextButton.Enabled, "Next button is not disabled.");
            }
            //for select assets page
            else if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("centrella select assets elements"))
            {
                Assert.IsFalse(updateSelectDevicesPage.NextButton.Enabled, "Next button is not disabled.");
            }
            //If this does not belong to any scenario
            else
            {
                Assert.Fail(_scenarioContext.ScenarioInfo.Title + " does not have a step defination for " + _scenarioContext.StepContext.StepInfo.Text);
            }
            
        }

        [Then(@"Page x of y label is displayed")]
        public void ThenPageXOfYLabelIsDisplayed()
        {
            //For select update page
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("centrella upgrade elements"))
            {
                SetMethods.MoveTotheElement(updatesSelectUpdatePage.PaginationXofY, "Page x of y label");
                Assert.IsTrue(updatesSelectUpdatePage.PaginationXofY.GetElementVisibility(), "Page x of y label is not displayed");
            }
            //for select assets page
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("centrella select assets elements"))
            {
                SetMethods.MoveTotheElement(updateSelectDevicesPage.PaginationXofY, "Page x of y label");
                Assert.IsTrue(updateSelectDevicesPage.PaginationXofY.GetElementVisibility(), "Page x of y label is not displayed");
            }
            //If this does not belong to any scenario
            else
            {
                Assert.Fail(_scenarioContext.ScenarioInfo.Title + " does not have a step defination for " + _scenarioContext.StepContext.StepInfo.Text);
            }
        }

        [Then(@"Displaying x to y of z results label is displayed")]
        public void ThenDisplayingXToYOfZResultsLabelIsDisplayed()
        {
            //For select update page
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("centrella upgrade elements"))
            {
                SetMethods.MoveTotheElement(updatesSelectUpdatePage.PaginationDisplayXY, "Displaying x to y of z results label");
                Assert.IsTrue(updatesSelectUpdatePage.PaginationDisplayXY.GetElementVisibility(), "Displaying x to y of z results label is not displayed");
            }
            //for select assets page
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("centrella select assets elements"))
            {
                SetMethods.MoveTotheElement(updateSelectDevicesPage.PaginationDisplayXY, "Displaying x to y of z results label");
                Assert.IsTrue(updateSelectDevicesPage.PaginationDisplayXY.GetElementVisibility(), "Displaying x to y of z results label is not displayed");
            }
            //If this does not belong to any scenario
            else
            {
                Assert.Fail(_scenarioContext.ScenarioInfo.Title + " does not have a step defination for " + _scenarioContext.StepContext.StepInfo.Text);
            }
        }

        [Given(@"Upgrade Update type is selected")]
        public void GivenUpgradeUpdateTypeIsSelected()
        {
            updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade);
        }

        [Given(@"user has selected Upgrade file")]
        public void GivenUserHasSelectedUpgradeFile()
        {
            updatesSelectUpdatePage.FirstFileCVSMAndCentrellaInTable.Click();
        }

        [When(@"user clicks Next button")]
        public void WhenUserClicksNextButton()
        {
            updatesSelectUpdatePage.NextButton.Click();
        }

        [Then(@"Centrella Select assets page is displayed")]
        public void ThenCentrellaSelectAssetsPageIsDisplayed()
        {
            Assert.AreEqual(true, updateSelectDevicesPage.DeployHead.GetElementVisibility(), "Select assets page is not displayed");
        }

        [Given(@"user is on Centrella Upgrade Select assets page")]
        public void GivenUserIsOnCentrellaUpgradeSelectAssetsPage()
        {
            //go to updates tab
            GivenUserIsOnCentrellaUpdatesPage();

            //Select centrella
            updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.CentrellaDeviceName);

            //Select upgrade in upgrade type
            updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade);

            //Select upgrade file and click on next button
            updatesSelectUpdatePage.FirstFileCVSMAndCentrellaInTable.Click();
            FirstUpadeFileName = updatesSelectUpdatePage.FirstFileCVSMAndCentrellaInTable.FindElement(By.Id(UpdatesSelectUpdatePage.Locators.RV700AndCentrellaFileNameListID)).Text;
            updatesSelectUpdatePage.NextButton.Click();
        }

        [Then(@"Select update indicator is not highlighted")]
        public void ThenSelectUpdateIndicatorIsNotHighlighted()
        {
            //Asserting the color(R,G,B,A) value of the Select update element
            Assert.AreEqual(UpdatesSelectUpdatePage.ExpectedValues.NonHighlightedHeadingColor, updatesSelectUpdatePage.Heading.GetCssValue("color"), "Select update indicator is highlighted");
        }

        [Then(@"Select assets indicator is highlighted")]
        public void ThenSelectAssetsIndicatorIsHighlighted()
        {
            //Asserting the color(R,G,B,A) value of the Select assets element
            Assert.AreEqual(UpdateSelectDevicesPage.ExpectedValues.HighlightedHeadingColor, updateSelectDevicesPage.Heading.GetCssValue("color"), "Select devices indicator is not highlighted");
        }

        [Then(@"Review action indicator is not highlighted")]
        public void ThenReviewActionIndicatorIsNotHighlighted()
        {
            //Asserting the color(R,G,B,A) value of the Review action element
            Assert.AreEqual(UpdateReviewActionPage.ExpectedValues.NonHighlightedHeadingColor, updateReviewActionPage.Heading.GetCssValue("color"), "Review action indicator is highlighted");
        }

        [Then(@"""(.*)"" label is displayed")]
        public void ThenLabelIsDisplayed(string labelName)
        {
            IWebElement label = null;
            string ExpectedValue = null;
            switch(labelName.ToLower().Trim())
            {
                case "item to push":
                    label = updateSelectDevicesPage.ItemtoPush;
                    ExpectedValue = UpdateSelectDevicesPage.ExpectedValues.ItemToPushLabelText;
                    break;
                case "device type":
                    label = updateSelectDevicesPage.DeviceTypeLabel;
                    ExpectedValue = UpdateSelectDevicesPage.ExpectedValues.CentrellaDeviceName;
                    break;
                case "update type":
                    label = updateSelectDevicesPage.TypeOfUpdateUpgradeLabel;
                    ExpectedValue = UpdateSelectDevicesPage.ExpectedValues.UpgradeLabelText;
                    break;
                case "upgrade file to push":
                    label = updateSelectDevicesPage.FileName;
                    ExpectedValue = FirstUpadeFileName;
                    break;
                case "destinations":
                    label = updateSelectDevicesPage.DestinationLabel;
                    ExpectedValue = UpdateSelectDevicesPage.ExpectedValues.DestinationLabelText;
                    break;
                default: Assert.Fail(labelName + " is a invalid label name.");
                    break;
            }
            Assert.IsTrue(label.GetElementVisibility(),labelName+" is not displayed");
            Assert.AreEqual(ExpectedValue.ToLower(), label.Text.ToLower(), labelName + " is not matching the expected value.");
        }

        [Then(@"location hierarchy selectors are displayed")]
        public void ThenLocationHierarchySelectorsAreDisplayed()
        {
            Assert.IsTrue(updateSelectDevicesPage.LocationHierarchy.GetElementVisibility(), "Location hierarchy selectors are not displayed");
        }

        [Then(@"count of selected devices is displayed")]
        public void ThenCountOfSelectedDevicesIsDisplayed()
        {
            Assert.IsTrue(updateSelectDevicesPage.DeviceCount.GetElementVisibility(), "count of selected devices is not displayed");
        }

        [Then(@"Previous button is enabled")]
        public void ThenPreviousButtonIsEnabled()
        {
            //for select assets page
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("centrella select assets elements"))
            {
                Assert.IsTrue(updateSelectDevicesPage.PreviousButton.Enabled, "Previous button is not enabled.");
            }
            //for review action page
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("centrella review action elements"))
            {
                Assert.IsTrue(updateReviewActionPage.PreviousButton.Enabled, "Previous button is not enabled.");
            }
            //If this does not belong to any scenario
            else
            {
                Assert.Fail(_scenarioContext.ScenarioInfo.Title + " does not have a step defination for " + _scenarioContext.StepContext.StepInfo.Text);
            }

            
        }

        [Then(@"Select all checkbox is unchecked")]
        public void ThenSelectAllCheckboxIsUnchecked()
        {
            Assert.IsTrue(updateSelectDevicesPage.SelectAllcheckBox.GetElementVisibility(), "Select all checkbox in column 1 is not displayed");
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string columnHeadingName)
        {
            IWebElement HeadingElement = null;
            string ExpectedHeadingText = null;
            switch (columnHeadingName.ToLower().Trim())
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
                    Assert.Fail(columnHeadingName + " is a invalid heading name");
                    break;
            }
            Assert.AreEqual(true, HeadingElement.GetElementVisibility(), columnHeadingName + " is not displayed.");
            string ActualHeadingText = HeadingElement.Text.ToLower();
            Assert.AreEqual(ExpectedHeadingText.ToLower(), ActualHeadingText, columnHeadingName + " not matches with the expected value");
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
            string ActualDesinationCountText = updateSelectDevicesPage.DeviceCount.Text;
            string ExpectedDestinationCountText = UpdateSelectDevicesPage.ExpectedValues.Desination1DeviceCountText;
            Assert.AreEqual(ExpectedDestinationCountText, ActualDesinationCountText, "Count of selected devices are not changed.");
        }

        [Then(@"Next button is enabled")]
        public void ThenNextButtonIsEnabled()
        {
            Assert.IsTrue(updateSelectDevicesPage.NextButton.Enabled, "Next button is not enabled.");
        }

        [When(@"user clicks Previous button")]
        public void WhenUserClicksPreviousButton()
        {
            
            //For select update page
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("centrella select assets previous"))
            {
                updateSelectDevicesPage.PreviousButton.Click();
            }
            //for select assets page
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("centrella review action previous"))
            {
                updateReviewActionPage.PreviousButton.Click();
            }
            //If this does not belong to any scenario
            else
            {
                Assert.Fail(_scenarioContext.ScenarioInfo.Title + " does not have a step defination for " + _scenarioContext.StepContext.StepInfo.Text);
            }

        }

        [Then(@"Centrella Updates page is displayed")]
        public void ThenCentrellaUpdatesPageIsDisplayed()
        {
            bool IsUpdatePageDisplayed = (updatesSelectUpdatePage.AssetTypeDropDown.GetElementVisibility()) || (updatesSelectUpdatePage.UpgradeTypeDropDown.GetElementVisibility());
            Assert.AreEqual(true, IsUpdatePageDisplayed, "CSM update page is not displayed");
        }

        [When(@"clicks Next button")]
        public void WhenClicksNextButton()
        {
            updateSelectDevicesPage.NextButton.Click();
        }

        [Then(@"Centrella Review Action page is displayed")]
        public void ThenCentrellaReviewActionPageIsDisplayed()
        {
            bool IsReviewActionPage = (updateReviewActionPage.ItemToPushLabel.GetElementVisibility()) || (updateReviewActionPage.DestinationLabel.GetElementVisibility());
            Assert.AreEqual(true, IsReviewActionPage, "CSM Reiew action page is not displayed.");
        }

        [Given(@"user is on Centrella Review Action page")]
        public void GivenUserIsOnCentrellaReviewActionPage()
        {
            //Navigate select assets page
            GivenUserIsOnCentrellaUpgradeSelectAssetsPage();

            //Select first Device
            updateSelectDevicesPage.FirstDeviceCheckBox.Click();

            //Click on Next Button
            updateSelectDevicesPage.NextButton.Click();

            //Verify Review page is displayed
            ThenCentrellaReviewActionPageIsDisplayed();
        }

        [When(@"user clicks Confirm button")]
        public void WhenUserClicksConfirmButton()
        {
            updateReviewActionPage.ConfirmButton.Click();
        }

        [Then(@"Update process has been established message is displayed")]
        public void ThenUpdateProcessHasBeenEstablishedMessageIsDisplayed()
        {
            Assert.AreEqual(true, updateSelectDevicesPage.SuccessUpadteMessage.GetElementVisibility(), "Update message is not displayed");
            Assert.AreEqual(UpdateSelectDevicesPage.ExpectedValues.UpdateProcessMessageText.ToLower(), updateSelectDevicesPage.SuccessUpadteMessage.Text.ToLower(), "Update message is not matching with the expected value.");
        }

        [Then(@"Select assets page is displayed")]
        public void ThenSelectAssetsPageIsDisplayed()
        {
            bool IsSelectDevicePage = (updateSelectDevicesPage.ItemtoPush.GetElementVisibility()) || (updateSelectDevicesPage.DeviceTypeLabel.GetElementVisibility());
            Assert.AreEqual(true, IsSelectDevicePage, "Select devices page is not displayed");
        }

        [Then(@"Item to push label is displayed")]
        public void ThenItemToPushLabelIsDisplayed()
        {
            Assert.IsTrue(updateReviewActionPage.ItemToPushLabel.GetElementVisibility(), "Item to push label is not displayed.");
            Assert.AreEqual(UpdateReviewActionPage.ExpectedValues.ItemToPushLabelText.ToLower(), updateReviewActionPage.ItemToPushLabel.Text.ToLower(), "Item to push label is not matching with the expected value.");
        }

        [Then(@"Item to push value is displayed")]
        public void ThenItemToPushValueIsDisplayed()
        {
            Assert.IsTrue(updateReviewActionPage.ItemToPushValue.GetElementVisibility(), "Item to push value is not displayed.");
        }

        [Then(@"Destinations label is displayed")]
        public void ThenDestinationsLabelIsDisplayed()
        {
            Assert.IsTrue(updateReviewActionPage.DestinationLabel.GetElementVisibility(), "Destinations label is not displayed.");
            Assert.AreEqual(UpdateReviewActionPage.ExpectedValues.DestinationLabelText.ToLower(), updateReviewActionPage.DestinationLabel.Text.ToLower(), "Destination label is not displayed.");
        }

        [Then(@"Destinations value is displayed")]
        public void ThenDestinationsValueIsDisplayed()
        {
            Assert.IsTrue(updateReviewActionPage.DestinationValue.GetElementVisibility(), "Destinations value is not displayed.");
        }

        [Then(@"Date or Time of push label is displayed")]
        public void ThenDateOrTimeOfPushLabelIsDisplayed()
        {
            Assert.IsTrue(updateReviewActionPage.DateOrTimePushLabel.GetElementVisibility(), "Date or Time Label is not displayed");
            Assert.AreEqual(UpdateReviewActionPage.ExpectedValues.DateOrTimeOfPushLabelText.ToLower(), updateReviewActionPage.DateOrTimePushLabel.Text.ToLower(), "Date or time label is not matching with the expected value.");
        }

        [Then(@"Immediately label is displayed")]
        public void ThenImmediatelyLabelIsDisplayed()
        {
            Assert.IsTrue(updateReviewActionPage.ImmediateLabel.GetElementVisibility(), "Immediate label is not displayed");
            Assert.AreEqual(UpdateReviewActionPage.ExpectedValues.ImmediatelyLabel.ToLower(), updateReviewActionPage.ImmediateLabel.Text.ToLower(), "Immediate label is not matching with expected value.");
        }

        [Then(@"radio button is displayed for Immediately")]
        public void ThenRadioButtonIsDisplayedForImmediately()
        {
            Assert.IsTrue(updateReviewActionPage.ImmediateCheckbox.GetElementVisibility(), "Immediately radio button is not displayed.");
        }

        [Then(@"it is selected")]
        public void ThenItIsSelected()
        {
            Assert.IsTrue(updateReviewActionPage.ImmediateCheckbox.Selected, "Immediately radio button is not selected");
        }

        [Then(@"radio button is displayed for schedule")]
        public void ThenRadioButtonIsDisplayedForSchedule()
        {
            Assert.IsTrue(updateReviewActionPage.ScheduleCheckbox.GetElementVisibility(), "Schedule radio button is not displayed");
        }

        [Then(@"Schedule label is displayed")]
        public void ThenScheduleLabelIsDisplayed()
        {
            Assert.IsTrue(updateReviewActionPage.ScheduleLabel.GetElementVisibility(), "Schedule Label is not displayed");
            Assert.AreEqual(UpdateReviewActionPage.ExpectedValues.ScheduleLabelText.ToLower(), updateReviewActionPage.ScheduleLabel.Text.ToLower(), "Schedule label is not matching with the expected value.");
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
            Assert.IsTrue(updateReviewActionPage.ConfirmButton.Enabled, "Confirm button is not enabled.");
        }


    }
}
