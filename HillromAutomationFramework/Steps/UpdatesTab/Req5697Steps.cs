using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5697")]
    public class Req5697Steps
    {
        LoginPage loginPage = new LoginPage();
        MainPage mainPage = new MainPage();
        LandingPage landingPage = new LandingPage();
        UpdatesSelectUpdatePage updatesSelectUpdatePage = new UpdatesSelectUpdatePage();
        UpdateSelectDevicesPage updateSelectDevicePage = new UpdateSelectDevicesPage();
        UpdateReviewActionPage updateReviewActionPage = new UpdateReviewActionPage();

        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        private ScenarioContext _scenarioContext;

        public Req5697Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext=scenarioContext;
        }

        [Given(@"user is on Main page")]
        public void GivenUserIsOnMainPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithOutRollUpPage);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
        }
        
        [When(@"user clicks Updates")]
        public void WhenUserClicksUpdates()
        {
            mainPage.UpdatesTab.JavaSciptClick();
        }
        
        [Then(@"Select update indicator is highlighted")]
        public void ThenSelectUpdateIndicatorIsHighlighted()
        {
            Assert.AreEqual(UpdatesSelectUpdatePage.ExpectedValues.HighlightedHeadingColor, updatesSelectUpdatePage.Heading.GetCssValue("color"), "Select update indicator is not highlighted.");
        }
        
        [Then(@"Select assets indicator is not highlighted")]
        public void ThenSelectAssetsIndicatorIsNotHighlighted()
        {
            Assert.AreEqual(UpdateSelectDevicesPage.ExpectedValues.NonHighlightedHeadingColor, updateSelectDevicePage.Heading.GetCssValue("color"), "Select assets indicator is highlighted.");
        }

        [Then(@"Review action indicator is not highlighted")]
        public void ThenReviewActionIndicatorIsNotHighlighted()
        {
            Assert.AreEqual(UpdateReviewActionPage.ExpectedValues.NonHighlightedHeadingColor, updateReviewActionPage.Heading.GetCssValue("color"), "Review action indicator is not highlighted.");
        }

        [Then(@"Asset type label is displayed")]
        public void ThenAssetTypeLabelIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.AssetTypeLabel.GetElementVisibility(), "Asset type label is not displayed.");
            Assert.AreEqual(UpdatesSelectUpdatePage.ExpectedValues.AssetTypeLabelText.ToLower(), updatesSelectUpdatePage.AssetTypeLabel.Text.ToLower(),"Asset type label is not matching with the expected value.");
        }


        [Then(@"Update type label is displayed")]
        public void ThenUpdateTypeLabelIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.UpgradeTypeLabel.GetElementVisibility(), "Update type label is not displayed.");
            Assert.AreEqual(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeLabelText.ToLower(), updatesSelectUpdatePage.UpgradeTypeLabel.Text.ToLower(), "Update type label is not matching with the expected value.");
        }
        
        [Then(@"Asset type drop down is displayed")]
        public void ThenAssetTypeDropDownIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.AssetTypeDropDown.GetElementVisibility(), "Asset type dropdown is not displayed.");
        }
        
        [Then(@"Update type drop down is displayed")]
        public void ThenUpdateTypeDropDownIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.UpgradeTypeDropDown.GetElementVisibility(), "Update type drop down is not displayed.");
        }
        
        [Then(@"Next button is displayed")]
        public void ThenNextButtonIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.NextButton.GetElementVisibility(), "Next button is not displayed.");
        }

        [Given(@"user is on Updates page")]
        public void GivenUserIsOnUpdatesPage()
        {
            GivenUserIsOnMainPage();
            mainPage.UpdatesTab.JavaSciptClick();
        }

        [When(@"user selects CVSM Asset type")]
        public void WhenUserSelectsCVSMAssetType()
        {
            updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.CVSMDeviceName);
        }

        [Then(@"CVSM displays as Asset type")]
        public void ThenCVSMDisplaysAsAssetType()
        {
            Assert.AreEqual(UpdatesSelectUpdatePage.ExpectedValues.CVSMDeviceName, updatesSelectUpdatePage.AssetTypeDropDown.GetSelectedOptionFromDDL(), "CVSM is not displayed as asset type.");
        }

        [Then(@"Update type drop down contains Configuration entry only")]
        public void ThenUpdateTypeDropDownContainsConfigurationEntryOnly()
        {
            SelectElement updateTypeDropdown = new SelectElement(updatesSelectUpdatePage.UpgradeTypeDropDown);
            //2 entries the select and Configuration
            Assert.AreEqual(true, updateTypeDropdown.Options.Count == 2, "Update type configuration has more than one entry.");
            Assert.AreEqual(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeDropdownDefault, updateTypeDropdown.Options[0].Text, "Update type default option is not Select.");
            Assert.AreEqual(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeConfiguration, updateTypeDropdown.Options[1].Text, "Configuartion option is not present.");
        }

        [Given(@"user is on CVSM Updates page")]
        public void GivenUserIsOnCVSMUpdatesPage()
        {
            GivenUserIsOnMainPage();
            mainPage.UpdatesTab.JavaSciptClick();
            updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.CVSMDeviceName);
        }

        [Given(@"CVSM Asset type is selected")]
        public void GivenCVSMAssetTypeIsSelected()
        {
            Assert.AreEqual(UpdatesSelectUpdatePage.ExpectedValues.CVSMDeviceName, updatesSelectUpdatePage.AssetTypeDropDown.GetSelectedOptionFromDDL(),"CVSM Asset type is not selected.");
        }

        [When(@"user selects Configuration Update type")]
        public void WhenUserSelectsConfigurationUpdateType()
        {
            updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeConfiguration);
        }

        [Then(@"Configuration displays as Update type")]
        public void ThenConfigurationDisplaysAsUpdateType()
        {
            Assert.AreEqual(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeConfiguration, updatesSelectUpdatePage.UpgradeTypeDropDown.GetSelectedOptionFromDDL(), "Configuration is not displayed as update type.");
        }

        [Then(@"CVSM configuration list is displayed")]
        public void ThenCVSMConfigurationListIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.ConfigList.GetElementVisibility(), "CVSM configuration list is not displayed.");
        }

        [Then(@"Delete button is displayed")]
        public void ThenDeleteButtonIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.DeleteButton.GetElementVisibility(), "Delete button is not displayed");
        }

        [Given(@"user is on CVSM Updates page with ""(.*)"" entries")]
        public void GivenUserIsOnCVSMUpdatesPageWithEntries(string noOfEntries)
        {
            //Selecting right Organizaion for the configuration
            switch(noOfEntries)
            {
                case "<=50":
                    loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
                    landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
                    break;

                case ">50":
                    loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
                    landingPage.LNTAutomatedTestOrganizationFacilityTest2Title.Click();
                    break;

                case ">50 and <=100":
                    loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
                    landingPage.LNTAutomatedTestOrganizationFacilityTest2Title.Click();
                    break;
                default: Assert.Fail(noOfEntries+" is a invalid number of configuration files.");
                    break;
            }
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.UpdatesTab.JavaSciptClick();
            updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.CVSMDeviceName);
            updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeConfiguration);
        }

        [Then(@"Previous page icon is disabled")]
        public void ThenPreviousPageiconIsDisabled()
        {
            SetMethods.ScrollToBottomofWebpage();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(UpdatesSelectUpdatePage.Locators.PaginationPreviousIconID)));
            string PaginationTextBeforeClick = updatesSelectUpdatePage.PaginationXofY.Text;
            updatesSelectUpdatePage.PaginationPreviousIcon.FindElement(By.TagName("img")).JavaSciptClick();
            string PaginationTextAfterClick= updatesSelectUpdatePage.PaginationXofY.Text;
            Assert.AreEqual(PaginationTextBeforeClick, PaginationTextAfterClick, "Previous page button is not disabled");
        }

        [Then(@"Next page icon is disabled")]
        public void ThenNextPageIconIsDisabled()
        {
            SetMethods.ScrollToBottomofWebpage();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(UpdatesSelectUpdatePage.Locators.PaginationNextIconID)));
            string PaginationTextBeforeClick = updatesSelectUpdatePage.PaginationXofY.Text;
            updatesSelectUpdatePage.PaginationNextIcon.JavaSciptClick();
            string PaginationTextAfterClick = updatesSelectUpdatePage.PaginationXofY.Text;
            Assert.AreEqual(PaginationTextBeforeClick, PaginationTextAfterClick, "Next page button is not disabled");
        }

        [Then(@"Previous page icon is enabled")]
        public void ThenPreviousPageIconIsEnabled()
        {
            SetMethods.ScrollToBottomofWebpage();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(UpdatesSelectUpdatePage.Locators.PaginationPreviousIconID)));
            string PaginationTextBeforeClick = updatesSelectUpdatePage.PaginationXofY.Text;
            updatesSelectUpdatePage.PaginationPreviousIcon.FindElement(By.TagName("img")).Click();
            string PaginationTextAfterClick = updatesSelectUpdatePage.PaginationXofY.Text;
            Assert.AreNotEqual(PaginationTextBeforeClick, PaginationTextAfterClick, "Previous page button is not enabled");
        }


        [Given(@"Configuration Update type is selected")]
        public void GivenConfigurationUpdateTypeIsSelected()
        {
            updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeConfiguration);
        }

        [When(@"user selects CVSM configuration from the list")]
        public void WhenUserSelectsCVSMConfigurationFromTheList()
        {
            updatesSelectUpdatePage.FirstFileCVSMInTable.Click();
        }

        [Then(@"Next button is enabled")]
        public void ThenNextButtonIsEnabled()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.NextButton.Enabled, "Next button is not enabled");
        }

        [Then(@"user clicks Next button")]
        public void ThenClicksNextButton()
        {
            updatesSelectUpdatePage.NextButton.Click();
        }

        [Then(@"Select Assets page is displayed")]
        public void ThenSelectAssetsPageIsDisplayed()
        {
            Assert.AreEqual(true, updateSelectDevicePage.DeployHead.GetElementVisibility(), "Select assets page is not displayed");
        }

        [Given(@"user is on CVSM Configuration Select assets page")]
        public void GivenUserIsOnCVSMConfigurationSelectAssetsPage()
        {
            GivenUserIsOnCVSMUpdatesPage();
            updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeConfiguration);
            updatesSelectUpdatePage.FirstFileCVSMInTable.Click();
            updatesSelectUpdatePage.NextButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(UpdateSelectDevicesPage.Locators.DeviceCountID)));
        }

        [Then(@"Select update indicator is not highlighted")]
        public void ThenSelectUpdateIndicatorIsNotHighlighted()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(UpdateSelectDevicesPage.Locators.DeviceCountID)));
            Assert.AreEqual(UpdatesSelectUpdatePage.ExpectedValues.NonHighlightedHeadingColor,updatesSelectUpdatePage.Heading.GetCssValue("color"), "Select Update tab is highlighted.");
        }

        [Then(@"Select assets indicator is highlighted")]
        public void ThenSelectAssetsIndicatorIsHighlighted()
        {
            Assert.AreEqual(UpdateSelectDevicesPage.ExpectedValues.HighlightedHeadingColor,updateSelectDevicePage.Heading.GetCssValue("color"), "Select devices tab is not highlighted.");
        }

        [Given(@"Configuration list is not empty")]
        public void GivenConfigurationListIsNotEmpty()
        {
            Assert.AreEqual(true,updatesSelectUpdatePage.FileNameList.GetElementCount()>0,"Configuration list is empty");
        }

        [Then(@"configuration files are sorted in ascending alphabetical order")]
        public void ThenConfigurationFilesAreSortedInAscendingAlphabeticalOrder()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.IsFileSorted(updatesSelectUpdatePage.FileNameList),"Config file is not sorted");
        }




        //for select devices page
        [Then(@"Item to push label is displayed")]
        public void ThenItemToPushLabelIsDisplayed()
        {
            if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("cvsm select assets elements"))
            {
                Assert.AreEqual(true, updateSelectDevicePage.ItemtoPush.GetElementVisibility(), "Item to push label is not displayed.");
                string ActualText = updateSelectDevicePage.ItemtoPush.Text;
                string ExpectedText = UpdateSelectDevicesPage.ExpectedValues.ItemToPushLabelText;
                Assert.AreEqual(ExpectedText, ActualText, "Item to push label text is not matching with expected value.");
            }
            else if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("cvsm review action elements"))
            {
                Assert.AreEqual(true, updateReviewActionPage.ItemToPushLabel.GetElementVisibility(), "Item to push label is not displayed.");
                string ActualText = updateReviewActionPage.ItemToPushLabel.Text;
                string ExpectedText = UpdateReviewActionPage.ExpectedValues.ItemToPushLabelText;
                Assert.AreEqual(ExpectedText, ActualText, "Item to push label text is not matching with expected value.");
            }
            
        }



        [Then(@"device type label is displayed")]
        public void ThenDeviceTypeLabelIsDisplayed()
        {
            Assert.AreEqual(true, updateSelectDevicePage.DeviceTypeLabel.GetElementVisibility(), "Device type label is not displayed.");
        }

        [Then(@"update type label is displayed")]
        public void ThenupdateTypeLabelIsDisplayed()
        {
            Assert.AreEqual(true, updateSelectDevicePage.TypeofUpdateConfigLabel.GetElementVisibility(), "Update type label is not displayed.");
            Assert.AreEqual(UpdateSelectDevicesPage.ExpectedValues.ConfigureLabelText.ToLower(), updateSelectDevicePage.TypeofUpdateConfigLabel.Text.ToLower(), "Update type lebal is not matching the expected value.");
        }

        [Then(@"config file to push label is displayed")]
        public void ThenConfigFileToPushLabelIsDisplayed()
        {
            Assert.AreEqual(true, updateSelectDevicePage.FileName.GetElementVisibility(), "Config file name is not displayed.");
        }

        [Then(@"Destinations label is displayed"),Scope(Tag = "TestCaseID_9036")]
        public void ThenDestinationsLabelIsDisplayed()
        {
            if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("cvsm select assets elements"))
            {
                Assert.AreEqual(true, updateSelectDevicePage.DestinationLabel.GetElementVisibility(), "Destination label is not displayed.");
                string ActualLabelText = updateSelectDevicePage.DestinationLabel.Text;
                string ExpectedLabelText = UpdateSelectDevicesPage.ExpectedValues.DestinationLabelText;
                Assert.AreEqual(ExpectedLabelText.ToLower(), ActualLabelText.ToLower(), "Destination label text is not matching with expected value.");
            }
            else if(_scenarioContext.ScenarioInfo.Title.ToLower().Equals("cvsm review action elements"))
            {
                Assert.AreEqual(true, updateReviewActionPage.DestinationLabel.GetElementVisibility(), "Destination label is not displayed.");
                string ActualLabelText = updateReviewActionPage.DestinationLabel.Text;
                string ExpectedLabelText = UpdateReviewActionPage.ExpectedValues.DestinationLabelText;
                Assert.AreEqual(ExpectedLabelText.ToLower(), ActualLabelText.ToLower(), "Destination label text is not matching with expected value.");
            }  
        }

        [Then(@"location hierarchy selectors are displayed")]
        public void ThenLocationHierarchySelectorsAreDisplayed()
        {
            Assert.AreEqual(true, updateSelectDevicePage.LocationHierarchy.GetElementVisibility(), "Location hierarchy selectors are not displayed.");
        }

        [Then(@"count of selected devices is displayed")]
        public void ThenCountOfSelectedDevicesIsDisplayed()
        {
            Assert.AreEqual(true, updateSelectDevicePage.DeviceCount.GetElementVisibility(), "Selected device count is not displayed");
        }

        [Then(@"Previous button is displayed")]
        public void ThenPreviousButtonIsDisplayed()
        {
            Assert.AreEqual(true, updateSelectDevicePage.PreviousButton.GetElementVisibility(), "Previous button is not displayed.");
        }

        [Then(@"Page x of y indicator is displayed")]
        public void ThenPageXOfYIndicatorIsDisplayed()
        {
            Assert.AreEqual(true, updateSelectDevicePage.PaginationXofY.GetElementVisibility(), "Page x of y indicator is not displayed.");
        }

        [Then(@"Displaying x to y of z results indicator is displayed")]
        public void ThenDisplayingXToYOfZResultsIndicatorIsDisplayed()
        {
            Assert.AreEqual(true, updateSelectDevicePage.PaginationDisplayXY.GetElementVisibility(), "Displaying x to y of z results indicator is not displayed.");
        }

        [Then(@"Select all checkbox is unchecked")]
        public void ThenSelectAllCheckboxIsUnchecked()
        {
            Assert.AreEqual(false, updateSelectDevicePage.SelectAllcheckBox.Selected,"Select all check box is not uncheked.");
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string HeadingName)
        {
            IWebElement Heading=null;
            string ExpectedHeadingText=null;
            switch(HeadingName.ToLower().Trim())
            {
                case "firmware": Heading = updateSelectDevicePage.FirmwareHeading;
                    ExpectedHeadingText = UpdateSelectDevicesPage.ExpectedValues.FirwareHeadingText;
                                break;
                case "config":
                    Heading = updateSelectDevicePage.ConfigHeading;
                    ExpectedHeadingText = UpdateSelectDevicesPage.ExpectedValues.ConfigHeadingText;
                    break;
                case "asset tag":
                    Heading = updateSelectDevicePage.AssetTagHeading;
                    ExpectedHeadingText = UpdateSelectDevicesPage.ExpectedValues.AssetTagHeadingText;
                    break;
                case "serial":
                    Heading = updateSelectDevicePage.SerialNoHeading;
                    ExpectedHeadingText = UpdateSelectDevicesPage.ExpectedValues.SerialHeadingText;
                    break;
                case "location":
                    Heading = updateSelectDevicePage.LocationHeading;
                    ExpectedHeadingText = UpdateSelectDevicesPage.ExpectedValues.LocationHeadingText;
                    break;
                case "last files deployed":
                    Heading = updateSelectDevicePage.LastFilesDeployedHeading;
                    ExpectedHeadingText = UpdateSelectDevicesPage.ExpectedValues.LastFilesDeployedHeadingText;
                    break;

                case "name":
                    Heading = updatesSelectUpdatePage.NameColumnHeading;
                    ExpectedHeadingText = UpdatesSelectUpdatePage.ExpectedValues.TableNameHeadingText;
                    break;

                case "date created":
                    Heading = updatesSelectUpdatePage.DateColumnHeading;
                    ExpectedHeadingText = UpdatesSelectUpdatePage.ExpectedValues.TableDateHeadingText;
                    break;
                default: Assert.Fail(HeadingName+"is not present on the test data");
                    break;
            }
            Assert.AreEqual(true, Heading.GetElementVisibility(), Heading+" is not displayed.");
            string ActualHeadingText = Heading.Text;
            Assert.AreEqual(ExpectedHeadingText, ActualHeadingText, HeadingName+" text is not matxhing with the expected value.");
        }

        [Then(@"Select all checkbox is in column (.*)")]
        public void ThenSelectAllCheckboxIsInColumn(int columnNumber)
        {
            string firstcolumnId = updateSelectDevicePage.TableHeading.FindElements(By.TagName("div"))[columnNumber - 1].GetAttribute("id");
            Assert.AreEqual(UpdateSelectDevicesPage.Locators.SelectAllcheckBoxID, firstcolumnId, "Select all checkbox is not in column " + columnNumber);
        }

        [Then(@"""(.*)"" label is in column (.*)")]
        public void ThenLabelIsInColumn(string columnHeading, int columnNumber)
        {
            IList<IWebElement> columns = updateSelectDevicePage.TableHeading.FindElements(By.TagName("div"));
            Assert.AreEqual(columnHeading.ToLower().Trim(), columns[columnNumber - 1].Text.ToLower(), columnHeading + " is not in " + columnNumber);
        }




        [When(@"user selects one device")]
        public void WhenUserSelectsOneDevice()
        {
            updateSelectDevicePage.FirstDeviceCheckBox.Click();
        }

        [Then(@"count of selected devices changes from 0 to 1")]
        public void ThenCountOfSelectedDevicesChangesFromTo()
        {
            string ActualDestinationCountText = updateSelectDevicePage.DeviceCount.Text;
            string ExpectedDestinationCountText = UpdateSelectDevicesPage.ExpectedValues.Desination1DeviceCountText;
            Assert.AreEqual(ExpectedDestinationCountText, ActualDestinationCountText, "Count of selected devices does not change.\n");
        }

        [When(@"user clicks Previous button")]
        public void WhenUserClicksPreviousButton()
        {
            updateSelectDevicePage.PreviousButton.Click();
        }

        [Then(@"user is on CVSM Updates page")]
        public void ThenUserIsOnCVSMUpdatesPage()
        {
            bool UpdatePageElements = (updatesSelectUpdatePage.AssetTypeDropDown.GetElementVisibility()) || (updatesSelectUpdatePage.UpgradeTypeDropDown.GetElementVisibility()); 
            Assert.AreEqual(true, UpdatePageElements, "User is not on CVSM Update page");
        }

        [When(@"Clicks Next button")]
        public void WhenClicksNextButton()
        {
            updatesSelectUpdatePage.NextButton.Click();
        }

        [Then(@"CVSM Review Action page is displayed")]
        public void ThenCVSMReviewActionPageIsDisplayed()
        {
            Assert.AreEqual(true, updateReviewActionPage.PushItems.GetElementVisibility(), "CVSM review action page is not displayed.");
        }

        [Given(@"user is on CVSM Review Action page")]
        public void GivenUserIsOnCVSMReviewActionPage()
        {
            GivenUserIsOnCVSMConfigurationSelectAssetsPage();
            updateSelectDevicePage.FirstDeviceCheckBox.Click();
            updateSelectDevicePage.NextButton.Click();
            Assert.AreEqual(true, updateReviewActionPage.PushItems.GetElementVisibility(), "CVSM review action page is not displayed.");
        }

        //for Review action page
        

        [Then(@"Item to push value is displayed")]
        public void ThenItemToPushValueIsDisplayed()
        {
            Assert.AreEqual(true, updateReviewActionPage.ItemToPushValue.GetElementVisibility(), "Item to push value is not displayed");
        }

        [Then(@"Destinations value is displayed")]
        public void ThenDestinationsValueIsDisplayed()
        {
            Assert.AreEqual(true, updateReviewActionPage.DestinationValue.GetElementVisibility(), "Destinations value is not displayed.");
        }

        


        [Then(@"Review action indicator is highlighted")]
        public void ThenReviewActionIndicatorIsHighlighted()
        {
            Assert.AreEqual(UpdateReviewActionPage.ExpectedValues.HighlightedHeadingColor, updateReviewActionPage.Heading.GetCssValue("color"), "Review action indicator is not highlighted.");
        }

        [Then(@"Confirm button is enabled")]
        public void ThenConfirmButtonIsEnabled()
        {
            Assert.AreEqual(true, updateReviewActionPage.ConfirmButton.Enabled, "Confirm button is not enabled.");
        }


        [When(@"user clicks Confirm button")]
        public void WhenUserClicksConfirmButton()
        {
            updateReviewActionPage.ConfirmButton.Click();
        }

        [Then(@"Update process has been established message is displayed")]
        public void ThenUpdateProcessHasBeenEstablishedMessageIsDisplayed()
        {
           Assert.AreEqual(true, updateSelectDevicePage.SuccessUpadteMessage.GetElementVisibility(), "Update process has been established message is not displayed");
            Assert.AreEqual(UpdateSelectDevicesPage.ExpectedValues.UpdateProcessMessageText.ToLower(), updateSelectDevicePage.SuccessUpadteMessage.Text.ToLower(), "Update message is not matching with expected value.");
        }

        [Then(@"Select devices page is displayed")]
        public void ThenSelectDevicesPageIsDisplayed()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(UpdateSelectDevicesPage.Locators.SelectAllcheckBoxID)));
            bool SelectDevicePageElements = (updateSelectDevicePage.SelectAllcheckBox.GetElementVisibility()) || (updateSelectDevicePage.DeployHead.GetElementVisibility());
            Assert.AreEqual(true, SelectDevicePageElements, "Select devices page is not displayed.\n");
        }

        [Then(@"Next page icon is enabled")]
        public void ThenNextPageIconIsEnabled()
        {
            SetMethods.ScrollToBottomofWebpage();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(UpdatesSelectUpdatePage.Locators.PaginationNextIconID)));
            string PaginationTextBeforeClick = updatesSelectUpdatePage.PaginationXofY.Text;
            updatesSelectUpdatePage.PaginationNextIcon.Click();
            string PaginationTextAfterClick = updatesSelectUpdatePage.PaginationXofY.Text;
            Assert.AreNotEqual(PaginationTextBeforeClick, PaginationTextAfterClick, "Next page button is not disabled");
        }

        [Given(@"first (.*) entries are displayed")]
        public void GivenFirstEntriesAreDisplayed(int p0)
        {
            Assert.AreEqual(50, updatesSelectUpdatePage.FileNameList.GetElementCount(), "First 50 entries are not displayed");
        }

        [When(@"user clicks Next page button")]
        public void WhenUserClicksNextPageButton()
        {
            SetMethods.ScrollToBottomofWebpage();
            updatesSelectUpdatePage.PaginationNextIcon.Click();
        }

        [Then(@"second page of entries is displayed")]
        public void ThenSecondPageOfEntriesIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.FileNameList.GetElementCount() > 0, "second page of entries are not displayed");
        }

        [Then(@"Next button is disabled")]
        public void ThenNextButtonIsDisabled()
        {
            Assert.AreEqual(false, updatesSelectUpdatePage.NextButton.Enabled, "Next button is not disabled");
        }

        [Then(@"Previous page icon is displayed")]
        public void ThenPreviousPageIconIsDisplayed()
        {
            Assert.AreEqual(true, updateSelectDevicePage.PaginationPreviousIcon.GetElementVisibility(), "Previous icon is not displayed");
        }

        [Then(@"Next page icon is displayed")]
        public void ThenNextPageIconIsDisplayed()
        {
            Assert.AreEqual(true, updateSelectDevicePage.PaginationNextIcon.GetElementVisibility(), "Next icon is not displayed");
        }

        [Then(@"Previous button is enabled")]
        public void ThenPreviousButtonIsEnabled()
        {
            Assert.AreEqual(true, updateReviewActionPage.PreviousButton.Enabled, "previous button is not enabled");
        }

    }
}
