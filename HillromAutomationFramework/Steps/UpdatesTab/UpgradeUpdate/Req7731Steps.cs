using FluentAssertions;
using HillromAutomationFramework.PageObjects;
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
    [Binding,Scope(Tag = "SoftwareRequirementID_7731")]
    public sealed class Req7731Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly UpdatesSelectUpdatePage _updatesSelectUpdatePage;
        private readonly UpdateSelectDevicesPage _updateSelectDevicesPage;
        private readonly UpdateReviewActionPage _updateReviewActionPage;

        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverWait _wait;
        private readonly IWebDriver _driver;

        string FirstUpadeFileName;

        public Req7731Steps(ScenarioContext scenarioContext, IWebDriver driver)
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

        [Given(@"user is on Centrella Updates page")]
        public void GivenUserIsOnCentrellaUpdatesPage()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(_landingPage.PSSServiceOrganizationFacilityBatesville, _driver, "Centrella Orgaization");
            _landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.UpdatesTab.JavaSciptClick(_driver);
        }

        [Given(@"Centrella Asset type is selected")]
        public void GivenCentrellaAssetTypeIsSelected()
        {
            _updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.CentrellaDeviceName);
        }

        [When(@"user selects Upgrade Update type")]
        public void WhenUserSelectsUpgradeUpdateType()
        {
            _updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade);
        }

        [Then(@"Upgrade displays as Update type")]
        public void ThenUpgradeDisplaysAsUpdateType()
        {
            string selectedUpdateType = _updatesSelectUpdatePage.UpgradeTypeDropDown.GetSelectedOptionFromDDL();
            (selectedUpdateType).Should().BeEquivalentTo(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade, because: "Upgrade type should be displayed when user selects Update as option in Upgrade type dropdown in Centrella select updates page");
        }

        [Then(@"Centrella upgrade list is displayed")]
        public void ThenCentrellaUpgradeListIsDisplayed()
        {
            (_updatesSelectUpdatePage.FileTableList.GetElementVisibility()).Should().BeTrue(because: "Centrella upgrade list should be displayed in Centrella select updates page");
        }

        [Then(@"Name column heading is displayed")]
        public void ThenNameColumnHeadingIsDisplayed()
        {
            (_updatesSelectUpdatePage.CentrellaAndRV700NameColumnHeading.GetElementVisibility()).Should().BeTrue(because: "Name column heading should be displayed in in Centrella select updates page table");
            string ActualNameColumnHeadingText = _updatesSelectUpdatePage.CentrellaAndRV700NameColumnHeading.Text;
            (ActualNameColumnHeadingText).Should().BeEquivalentTo(UpdatesSelectUpdatePage.ExpectedValues.TableNameHeadingText, because: "Name heading name text should match with the expected value in Centrella select updates page table");
        }

        [Then(@"Date created column heading is displayed")]
        public void ThenDateCreatedColumnHeadingIsDisplayed()
        {
            (_updatesSelectUpdatePage.CentrellaAndRV700DateColumnHeading.GetElementVisibility()).Should().BeTrue(because: "Date column heading should be displayed in Centrella select updates page table");
            string ActualDateColumnHeadingText = _updatesSelectUpdatePage.CentrellaAndRV700DateColumnHeading.Text;
            (ActualDateColumnHeadingText).Should().BeEquivalentTo(UpdatesSelectUpdatePage.ExpectedValues.TableDateHeadingText, because: "Date heading name text should match with the expected value in Centrella select updates page table");
        }

        [Then(@"Next button is disabled")]
        public void ThenNextButtonIsDisabled()
        {
            //For select update page
            if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("centrella upgrade elements"))
            {
                (_updatesSelectUpdatePage.NextButton.Enabled).Should().BeFalse(because: "Next button should be disabled since user didn't select any upgrade file in Centrella select Update page");
            }
            //for select assets page
            else if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("centrella select assets elements"))
            {
                (_updateSelectDevicesPage.NextButton.Enabled).Should().BeFalse(because: "Next button should be disabled since user didn't select any device in Centrella select assets page");
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
                SetMethods.MoveTotheElement(_updatesSelectUpdatePage.PaginationXofY, _driver, "Page x of y label");
                (_updatesSelectUpdatePage.PaginationXofY.GetElementVisibility()).Should().BeTrue(because: "Page x of y label should be displayed in Centrella Select Update page");
            }
            //for select assets page
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("centrella select assets elements"))
            {
                SetMethods.MoveTotheElement(_updateSelectDevicesPage.PaginationXofY, _driver, "Page x of y label");
                (_updateSelectDevicesPage.PaginationXofY.GetElementVisibility()).Should().BeTrue(because: "Page x of y label should be displayed in Centrella Select assets page");
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
                SetMethods.MoveTotheElement(_updatesSelectUpdatePage.PaginationDisplayXY, _driver, "Displaying x to y of z results label");
                (_updatesSelectUpdatePage.PaginationDisplayXY.GetElementVisibility()).Should().BeTrue(because: "Displaying X - Y of z results label should be displayed in Centrella Select Update page");
            }
            //for select assets page
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("centrella select assets elements"))
            {
                SetMethods.MoveTotheElement(_updateSelectDevicesPage.PaginationDisplayXY, _driver, "Displaying x to y of z results label");
                (_updateSelectDevicesPage.PaginationDisplayXY.GetElementVisibility()).Should().BeTrue(because: "Displaying X - Y of z results label should be displayed in Centrella Select assets page");
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
            _updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade);
        }

        [Given(@"user has selected Upgrade file")]
        public void GivenUserHasSelectedUpgradeFile()
        {
            _updatesSelectUpdatePage.FirstFileCVSMAndCentrellaInTable.Click();
        }

        [When(@"user clicks Next button")]
        public void WhenUserClicksNextButton()
        {
            _updatesSelectUpdatePage.NextButton.Click();
        }

        [Then(@"Centrella Select assets page is displayed")]
        public void ThenCentrellaSelectAssetsPageIsDisplayed()
        {
            bool IsSelectAssetPageDisplayed = (_updateSelectDevicesPage.ItemtoPush.GetElementVisibility()) || (_updateSelectDevicesPage.DestinationLabel.GetElementVisibility());
            (IsSelectAssetPageDisplayed).Should().BeTrue(because: "Select assets page should be displayed since user clicked Enabled next button in Centrella Select assets page");
        }

        [Given(@"user is on Centrella Upgrade Select assets page")]
        public void GivenUserIsOnCentrellaUpgradeSelectAssetsPage()
        {
            //go to updates tab
            GivenUserIsOnCentrellaUpdatesPage();

            //Select centrella
            _updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.CentrellaDeviceName);

            //Select upgrade in upgrade type
            _updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade);

            //Select upgrade file and click on next button
            _updatesSelectUpdatePage.FirstFileCVSMAndCentrellaInTable.Click();
            FirstUpadeFileName = _updatesSelectUpdatePage.FirstFileCVSMAndCentrellaInTable.FindElement(By.Id(UpdatesSelectUpdatePage.Locators.RV700AndCentrellaFileNameListID)).Text;
            _updatesSelectUpdatePage.NextButton.Click();
        }

        [Then(@"Select update indicator is not highlighted")]
        public void ThenSelectUpdateIndicatorIsNotHighlighted()
        {
            //Asserting the color(R,G,B,A) value of the Select update element
            string selectUpdateIndicatorColor = _updatesSelectUpdatePage.Heading.GetCssValue("color");
            (selectUpdateIndicatorColor).Should().BeEquivalentTo(UpdatesSelectUpdatePage.ExpectedValues.NonHighlightedHeadingColor, because: "Select Update tab indicator should not be highlighted.");
        }

        [Then(@"Select assets indicator is highlighted")]
        public void ThenSelectAssetsIndicatorIsHighlighted()
        {
            //Asserting the color(R,G,B,A) value of the Select assets element
            string selectAssetsIndicatorColor = _updateSelectDevicesPage.Heading.GetCssValue("color");
            (selectAssetsIndicatorColor).Should().BeEquivalentTo(UpdateSelectDevicesPage.ExpectedValues.HighlightedHeadingColor, because: "Select devices tab should be highlighted in select device tab");
        }

        [Then(@"Review action indicator is not highlighted")]
        public void ThenReviewActionIndicatorIsNotHighlighted()
        {
            //Asserting the color(R,G,B,A) value of the Review action element
            string ReviewActionColor = _updateReviewActionPage.Heading.GetCssValue("color");
            (ReviewActionColor).Should().BeEquivalentTo(UpdateReviewActionPage.ExpectedValues.NonHighlightedHeadingColor, because: "Review action indicator should not be highlighted.");
        }

        [Then(@"""(.*)"" label is displayed")]
        public void ThenLabelIsDisplayed(string labelName)
        {
            IWebElement label = null;
            string ExpectedLabelName = null;
            switch(labelName.ToLower().Trim())
            {
                case "item to push":
                    label = _updateSelectDevicesPage.ItemtoPush;
                    ExpectedLabelName = UpdateSelectDevicesPage.ExpectedValues.ItemToPushLabelText;
                    break;
                case "device type":
                    label = _updateSelectDevicesPage.DeviceTypeLabel;
                    ExpectedLabelName = UpdateSelectDevicesPage.ExpectedValues.CentrellaDeviceName;
                    break;
                case "update type":
                    label = _updateSelectDevicesPage.TypeOfUpdateUpgradeLabel;
                    ExpectedLabelName = UpdateSelectDevicesPage.ExpectedValues.UpgradeLabelText;
                    break;
                case "upgrade file to push":
                    label = _updateSelectDevicesPage.FileName;
                    ExpectedLabelName = FirstUpadeFileName;
                    break;
                case "destinations":
                    label = _updateSelectDevicesPage.DestinationLabel;
                    ExpectedLabelName = UpdateSelectDevicesPage.ExpectedValues.DestinationLabelText;
                    break;
                default: Assert.Fail(labelName + " is a invalid label name.");
                    break;
            }
            (label.GetElementVisibility()).Should().BeTrue(because: labelName + " label name should be displayed in Centrella Select Assets page");
            string LabelText = label.Text;
            (LabelText).Should().BeEquivalentTo(ExpectedLabelName, because: labelName + " label name should match with the expected value in Centrella Select Assets page");
        }

        [Then(@"location hierarchy selectors are displayed")]
        public void ThenLocationHierarchySelectorsAreDisplayed()
        {
            (_updateSelectDevicesPage.LocationHierarchy.GetElementVisibility()).Should().BeTrue(because: "location hierarchy selectors should be displayed in Centrella Select assets page.");
        }

        [Then(@"count of selected devices is displayed")]
        public void ThenCountOfSelectedDevicesIsDisplayed()
        {
            (_updateSelectDevicesPage.DeviceCount.GetElementVisibility()).Should().BeTrue(because: "count of selected devices should be displayed in Centrella Select assets page");
        }

        [Then(@"Previous button is enabled")]
        public void ThenPreviousButtonIsEnabled()
        {
            //for select assets page
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("centrella select assets elements"))
            {
                (_updateSelectDevicesPage.PreviousButton.Enabled).Should().BeTrue(because: "Previous button should be enabled in Centrella Select assets page");
            }
            //for review action page
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("centrella review action elements"))
            {
                (_updateReviewActionPage.PreviousButton.Enabled).Should().BeTrue(because: "Previous button should be enabled in Centrella Review Action page");
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
            (_updateSelectDevicesPage.SelectAllcheckBox.Selected).Should().BeFalse(because: "Select all checkbox should be unchecked by default in Centrella Select assets page");
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string columnHeadingName)
        {
            IWebElement HeadingElement = null;
            switch (columnHeadingName.ToLower().Trim())
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
                    Assert.Fail(columnHeadingName + " is a invalid heading name");
                    break;
            }
            (HeadingElement.GetElementVisibility()).Should().BeTrue(columnHeadingName + " column heading should be displayed in Centrella select Assets page");
            string ActualHeadingText = HeadingElement.Text.ToLower();
            (ActualHeadingText).Should().BeEquivalentTo(columnHeadingName, because: columnHeadingName + " column heading should match with the expected value in centrella select assets page");
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
            (_updateSelectDevicesPage.NextButton.Enabled).Should().BeTrue(because: "Next button should be enabled when user selects atleast one device in Centrella Upgrade Select Assets page");
        }

        [When(@"user clicks Previous button")]
        public void WhenUserClicksPreviousButton()
        {
            
            //For select update page
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("centrella select assets previous"))
            {
                _updateSelectDevicesPage.PreviousButton.Click();
            }
            //for select assets page
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Equals("centrella review action previous"))
            {
                _updateReviewActionPage.PreviousButton.Click();
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
            bool IsUpdatePageDisplayed = (_updatesSelectUpdatePage.AssetTypeDropDown.GetElementVisibility()) || (_updatesSelectUpdatePage.UpgradeTypeDropDown.GetElementVisibility());
            (IsUpdatePageDisplayed).Should().BeTrue(because: "RV700 update page should be displayed when user cliks previous button in Centrella Upgrade Select Assets page");
        }

        [When(@"clicks Next button")]
        public void WhenClicksNextButton()
        {
            _updateSelectDevicesPage.NextButton.Click();
        }

        [Then(@"Centrella Review Action page is displayed")]
        public void ThenCentrellaReviewActionPageIsDisplayed()
        {
            bool IsReviewActionPageDisplayed = (_updateReviewActionPage.ItemToPushLabel.GetElementVisibility()) || (_updateReviewActionPage.DestinationLabel.GetElementVisibility());
            (IsReviewActionPageDisplayed).Should().BeTrue(because: "Review action page should be displayed when user clicks enabled next button in Centrella Upgrade Select Assets page");
        }

        [Given(@"user is on Centrella Review Action page")]
        public void GivenUserIsOnCentrellaReviewActionPage()
        {
            //Navigate select assets page
            GivenUserIsOnCentrellaUpgradeSelectAssetsPage();

            //Select first Device
            _updateSelectDevicesPage.FirstDeviceCheckBox.Click();

            //Click on Next Button
            _updateSelectDevicesPage.NextButton.Click();

            //Verify Review page is displayed
            ThenCentrellaReviewActionPageIsDisplayed();
        }

        [When(@"user clicks Confirm button")]
        public void WhenUserClicksConfirmButton()
        {
            _updateReviewActionPage.ConfirmButton.Click();
        }

        [Then(@"Update process has been established message is displayed")]
        public void ThenUpdateProcessHasBeenEstablishedMessageIsDisplayed()
        {
            (_updateSelectDevicesPage.SuccessUpadteMessage.GetElementVisibility()).Should().BeTrue(because: "Update process Message should be displayed when user clicks confirm button In Centrella Upgrade review action page.");
            (_updateSelectDevicesPage.SuccessUpadteMessage.Text).Should().BeEquivalentTo(UpdateSelectDevicesPage.ExpectedValues.UpdateProcessMessageText, because: "Update message should match with the expected value in Centrella Upgrade review action page");
        }

        [Then(@"Select assets page is displayed")]
        public void ThenSelectAssetsPageIsDisplayed()
        {
            bool IsSelectDevicePageDisplayed = (_updateSelectDevicesPage.ItemtoPush.GetElementVisibility()) || (_updateSelectDevicesPage.DeviceTypeLabel.GetElementVisibility());
            (IsSelectDevicePageDisplayed).Should().BeTrue(because: "Select devices page should be displayed");
        }

        [Then(@"Item to push label is displayed")]
        public void ThenItemToPushLabelIsDisplayed()
        {
            (_updateReviewActionPage.ItemToPushLabel.GetElementVisibility()).Should().BeTrue(because: "Item to push label should be displayed in Centrella Upgrade Review action page.");
            string ActualItemToPushLabelText = _updateReviewActionPage.ItemToPushLabel.Text;
            (ActualItemToPushLabelText).Should().BeEquivalentTo(UpdateReviewActionPage.ExpectedValues.ItemToPushLabelText, because: "Item to push label text should match with expected value in Centrella Upgrade Review action page");
        }

        [Then(@"Item to push value is displayed")]
        public void ThenItemToPushValueIsDisplayed()
        {
            (_updateReviewActionPage.ItemToPushValue.GetElementVisibility()).Should().BeTrue(because: "Item to push value should be displayed in Centrella Upgrade review action page");
        }

        [Then(@"Destinations label is displayed")]
        public void ThenDestinationsLabelIsDisplayed()
        {
            (_updateReviewActionPage.DestinationLabel.GetElementVisibility()).Should().BeTrue(because: "Destination label should be displayed in Centrella upgrade review action Page.");
            string ActualDesinationLabelText = _updateReviewActionPage.DestinationLabel.Text;
            ActualDesinationLabelText.Should().BeEquivalentTo(UpdateReviewActionPage.ExpectedValues.DestinationLabelText, because: "Destination label text should match with expected value in Centrella upgrade review action Page.");
        }

        [Then(@"Destinations value is displayed")]
        public void ThenDestinationsValueIsDisplayed()
        {
            (_updateReviewActionPage.DestinationValue.GetElementVisibility()).Should().BeTrue(because: "Destinations value should be displayed in Centrella upgrade review action page");
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
            (reviewActionColor).Should().BeEquivalentTo(UpdateReviewActionPage.ExpectedValues.HighlightedHeadingColor, because: "Review action indicator should be highlighted in Centrella review action page");
        }

        [Then(@"Confirm button is enabled")]
        public void ThenConfirmButtonIsEnabled()
        {
            bool IsConfirmButtonEnabled = _updateReviewActionPage.ConfirmButton.Enabled;
            (IsConfirmButtonEnabled).Should().Be(true, "Confirm button should be enabled in the Centrella review action page.");
        }


    }
}
