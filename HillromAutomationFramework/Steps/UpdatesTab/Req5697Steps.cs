using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5697")]
    public class Req5697Steps
    {
        LoginPage loginPage = new LoginPage();
        MainPage mainPage = new MainPage();
        CVSMUpdateConfig cvsmUpdateConfig = new CVSMUpdateConfig();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        ScenarioContext _scenarioContext;

        public Req5697Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext=scenarioContext;
        }

        [Given(@"user is on Main page")]
        public void GivenUserIsOnMainPage()
        {
            loginPage.SignIn("adminwithoutrollup");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("deviceTable")));
            
        }
        
        [When(@"user clicks Updates")]
        public void WhenUserClicksUpdates()
        {
            mainPage.UpdatesTab.JavaSciptClick();
        }
        
        [Then(@"Select update indicator is highlighted")]
        public void ThenSelectUpdateIndicatorIsHighlighted()
        {
            //Assert.AreEqual(cvsmUpdateConfig.SelectUpdateCircle.GetAttribute("class"), CVSMUpdateConfig.ExpectedValues.HighlightedSectionCircleClassName, "Select Update tab circle is not highlighted.\n");
            //string HighlightedText = cvsmUpdateConfig.HighlightedSectionHeading.Text;
            // Assert.AreEqual("Select update", HighlightedText, "Select update indicator is not highlighted.\n");
            Assert.AreEqual("col-xs-3 filter-select selectUpdate", cvsmUpdateConfig.SelectUpdateTab.GetAttribute("class"), "Select update indicator is not highlighted.\n");
        }
        
        [Then(@"Select assets indicator is not highlighted")]
        public void ThenSelectAssetsIndicatorIsNotHighlighted()
        {
            //Assert.AreNotEqual(cvsmUpdateConfig.SelectDeviceCircle.GetAttribute("class"), CVSMUpdateConfig.ExpectedValues.HighlightedSectionCircleClassName, "Select assets tab circle is highlighted.\n");
            //string HighlightedText = cvsmUpdateConfig.HighlightedSectionHeading.Text;
            //Assert.AreNotEqual("Select assets", HighlightedText, "Select assets indicator is highlighted.\n");
        }
        
        [Then(@"Review action indicator is not highlighted")]
        public void ThenReviewActionIndicatorIsNotHighlighted()
        {
            //Assert.AreNotEqual(cvsmUpdateConfig.ReviewActionTabCircle.GetAttribute("class"), CVSMUpdateConfig.ExpectedValues.HighlightedSectionCircleClassName, "Review action tab circle is highlighted.\n");
            //string HighlightedText = cvsmUpdateConfig.HighlightedSectionHeading.Text;
            //Assert.AreNotEqual("Review action", HighlightedText, "Review action indicator is highlighted.\n");
        }

        [Then(@"Asset type label is visible")]
        public void ThenAssetTypeLabelIsVisible()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.AssetTypeLabel.GetElementVisibility(), "Asset type label is not displayed.\n");
        }
        
        [Then(@"Update type label is visible")]
        public void ThenUpdateTypeLabelIsVisible()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.UpgradeTypeLabel.GetElementVisibility(), "Update type label is not displayed.\n");
        }
        
        [Then(@"Asset type drop down is visible")]
        public void ThenAssetTypeDropDownIsVisible()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.AssetTypeDropDown.GetElementVisibility(), "Asset type dropdown is not displayed.\n");
        }
        
        [Then(@"Update type drop down is visible")]
        public void ThenUpdateTypeDropDownIsVisible()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.UpgradeTypeDropDown.GetElementVisibility(), "Update type drop down is not displayed.\n");
        }
        
        [Then(@"Next button is disabled")]
        public void ThenNextButtonIsDisabled()
        {
            Assert.AreEqual(false, cvsmUpdateConfig.SelectUpdateNextButton.Enabled, "Next button is not disabled.\n");
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
            cvsmUpdateConfig.AssetTypeDropDown.SelectDDL(CVSMUpdateConfig.Inputs.CVSMDeviceName);
        }

        [Then(@"CVSM displays as Asset type")]
        public void ThenCVSMDisplaysAsAssetType()
        {
            Assert.AreEqual(CVSMUpdateConfig.Inputs.CVSMDeviceName, cvsmUpdateConfig.AssetTypeDropDown.GetSelectedOptionFromDDL(), "CVSM is not displayed as asset type");
        }

        [Then(@"Update type drop down contains Configuration entry only")]
        public void ThenUpdateTypeDropDownContainsConfigurationEntryOnly()
        {
            SelectElement updateTypeDropdown = new SelectElement(cvsmUpdateConfig.UpgradeTypeDropDown);
            //2 entries the select is the default one
            Assert.AreEqual(true, updateTypeDropdown.Options.Count == 2, "Update type configuration has more than one entry.\n");
            Assert.AreEqual(CVSMUpdateConfig.ExpectedValues.UpdateTypeDropdownDefault, updateTypeDropdown.Options[0].Text, "Update type default option is not Select.\n");
            Assert.AreEqual(CVSMUpdateConfig.ExpectedValues.UpdateTypeConfiguration, updateTypeDropdown.Options[1].Text, "Configuartion option is not present.\n");
        }

        [Given(@"user is on CVSM Updates page")]
        public void GivenUserIsOnCVSMUpdatesPage()
        {
            GivenUserIsOnMainPage();
            mainPage.UpdatesTab.JavaSciptClick();
            cvsmUpdateConfig.AssetTypeDropDown.SelectDDL(CVSMUpdateConfig.Inputs.CVSMDeviceName);
        }

        [Given(@"CVSM Asset type is selected")]
        public void GivenCVSMAssetTypeIsSelected()
        {
            Assert.AreEqual(CVSMUpdateConfig.Inputs.CVSMDeviceName, cvsmUpdateConfig.AssetTypeDropDown.GetSelectedOptionFromDDL(),"CVSM Asset type is not selected.\n");
        }

        [When(@"user selects Configuration Update type")]
        public void WhenUserSelectsConfigurationUpdateType()
        {
            cvsmUpdateConfig.UpgradeTypeDropDown.SelectDDL(CVSMUpdateConfig.ExpectedValues.UpdateTypeConfiguration);
        }

        [Then(@"Configuration displays as Update type")]
        public void ThenConfigurationDisplaysAsUpdateType()
        {
            Assert.AreEqual(CVSMUpdateConfig.ExpectedValues.UpdateTypeConfiguration, cvsmUpdateConfig.UpgradeTypeDropDown.GetSelectedOptionFromDDL(), "Configuration is not displayed as update type.\n");
        }

        [Then(@"CVSM configuration list is visible")]
        public void ThenCVSMConfigurationListIsVisible()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.ConfigList.GetElementVisibility(), "CVSM configuration list is not displayed.\n");
        }

        [Then(@"Name column heading is visible")]
        public void ThenNameColumnHeadingIsVisible()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.NameColumnHeading.GetElementVisibility(), "Name heading is not displayed");
            string ActualNameText = cvsmUpdateConfig.NameColumnHeading.Text;
            string ExpecedNameText = CVSMUpdateConfig.ExpectedValues.NameHeadingText;
            Assert.AreEqual(ExpecedNameText, ActualNameText, "Name column heading is not matching the expected value.\n");
        }

        [Then(@"Date created column heading is visible")]
        public void ThenDateCreatedColumnHeadingIsVisible()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.DateColumnHeading.GetElementVisibility(), "Date created column heading is not displayed");
            string ActualNameText = cvsmUpdateConfig.DateColumnHeading.Text;
            string ExpecedNameText = CVSMUpdateConfig.ExpectedValues.DateColumnHeadingText;
            Assert.AreEqual(ExpecedNameText, ActualNameText, "Date created column heading is not matching the expected value.\n");
        }

        [Then(@"Delete button is visible")]
        public void ThenDeleteButtonIsVisible()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.DeleteButton.GetElementVisibility(), "Delete button is not displayed");
        }

        [Given(@"user is on CVSM Updates page with ""(.*)"" entries")]
        public void GivenUserIsOnCVSMUpdatesPageWithEntries(string noOfEntries)
        {
            switch(noOfEntries)
            {
                case "<=50":
                    GivenUserIsOnCVSMUpdatesPage();
                    cvsmUpdateConfig.UpgradeTypeDropDown.SelectDDL(CVSMUpdateConfig.ExpectedValues.UpdateTypeConfiguration);
                    break;

                case ">50":
                    //Yet to get updates about the no of configuration files
                    _scenarioContext.Pending();
                    break;

                case ">50 and <= 100":
                    //Yet to get updates about the no of configuration files
                    _scenarioContext.Pending();
                    break;
            }
        }

        [Then(@"Previous page button is disabled")]
        public void ThenPreviousPageButtonIsDisabled()
        {
            SetMethods.ScrollToBottomofWebpage();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(CVSMUpdateConfig.Locators.PaginationPreviousIconID)));
            string PaginationTextBeforeClick = cvsmUpdateConfig.PaginationXOfY.Text;
            cvsmUpdateConfig.PaginationPreviousIcon.JavaSciptClick();
            string PaginationTextAfterClick= cvsmUpdateConfig.PaginationXOfY.Text;
            Assert.AreEqual(PaginationTextBeforeClick, PaginationTextAfterClick, "Previous page button is not disabled");
        }

        [Then(@"Next page button is disabled")]
        public void ThenNextPageButtonIsDisabled()
        {
            SetMethods.ScrollToBottomofWebpage();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(CVSMUpdateConfig.Locators.PaginationNextIconID)));
            string PaginationTextBeforeClick = cvsmUpdateConfig.PaginationXOfY.Text;
            cvsmUpdateConfig.PaginationNextIcon.Click();
            string PaginationTextAfterClick = cvsmUpdateConfig.PaginationXOfY.Text;
            Assert.AreEqual(PaginationTextBeforeClick, PaginationTextAfterClick, "Next page button is not disabled");
        }



        [Given(@"Configuration Update type is selected")]
        public void GivenConfigurationUpdateTypeIsSelected()
        {
            cvsmUpdateConfig.UpgradeTypeDropDown.SelectDDL(CVSMUpdateConfig.ExpectedValues.UpdateTypeConfiguration);
        }

        [When(@"user selects CVSM configuration from the list")]
        public void WhenUserSelectsCVSMConfigurationFromTheList()
        {
            cvsmUpdateConfig.FirstConfigFile.Click();
        }

        [Then(@"Next button is enabled")]
        public void ThenNextButtonIsEnabled()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.SelectUpdateNextButton.Enabled, "Next button is not enabled");
        }

        [Then(@"clicks next button")]
        public void ThenClicksNextButton()
        {
            cvsmUpdateConfig.SelectUpdateNextButton.Click();
        }

        [Then(@"Select assets page is displayed")]
        public void ThenSelectAssetsPageIsDisplayed()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.DeployHead.GetElementVisibility(), "Select assets page is not displayed");
        }

        [Given(@"user is on CVSM Configuration Select assets page")]
        public void GivenUserIsOnCVSMConfigurationSelectAssetsPage()
        {
            GivenUserIsOnCVSMUpdatesPage();
            cvsmUpdateConfig.UpgradeTypeDropDown.SelectDDL(CVSMUpdateConfig.ExpectedValues.UpdateTypeConfiguration);
            cvsmUpdateConfig.FirstConfigFile.Click();
            cvsmUpdateConfig.SelectUpdateNextButton.Click();
        }

        [Then(@"Select update indicator is not highlighted")]
        public void ThenSelectUpdateIndicatorIsNotHighlighted()
        {
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName(CVSMUpdateConfig.Locators.HighlightedSectionHeadingClassName)));
            Assert.AreNotEqual(cvsmUpdateConfig.SelectUpdateCircle.GetAttribute("class"), CVSMUpdateConfig.ExpectedValues.HighlightedSectionCircleClassName, "Select Update tab circle is highlighted.\n");
            //string HighlightedText = cvsmUpdateConfig.HighlightedSectionHeading.Text;
            //Assert.AreNotEqual("Select update", HighlightedText, "Select update indicator is highlighted.\n");
        }

        [Then(@"Select assets indicator is highlighted")]
        public void ThenSelectAssetsIndicatorIsHighlighted()
        {
            Assert.AreEqual(cvsmUpdateConfig.SelectDeviceCircle.GetAttribute("class"), CVSMUpdateConfig.ExpectedValues.HighlightedSectionCircleClassName, "Select devices tab circle is not highlighted.\n");
            //string HighlightedText = cvsmUpdateConfig.HighlightedSectionHeading.Text;
            //Assert.AreEqual("Select devices", HighlightedText, "Select devices indicator is not highlighted.\n");
        }

        [Then(@"Item to push label is visible")]
        public void ThenItemToPushLabelIsVisible()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.ItemtoPush.GetElementVisibility(), "Item to push label is not displayed.\n");
            string ActualText = cvsmUpdateConfig.ItemtoPush.Text;
            string ExpectedText = CVSMUpdateConfig.ExpectedValues.ItemToPushLabelText;
            Assert.AreEqual(ExpectedText, ActualText, "Item to push label text is not matching with expected value.\n");
        }

        [Then(@"device type label is visible")]
        public void ThenDeviceTypeLabelIsVisible()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.DeviceTypeLabel.GetElementVisibility(), "Device type label is not displayed.\n");
        }

        [Then(@"update type label is visible")]
        public void ThenupdateTypeLabelIsVisible()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.TypeofUpdateLabel.GetElementVisibility(), "Update type label is not displayed.\n");
        }

        [Then(@"config file to push label is visible")]
        public void ThenConfigFileToPushLabelIsVisible()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.ConfigFileName.GetElementVisibility(), "Config file name is not displayed.\n");
        }

        [Then(@"Destinations label is visible")]
        public void ThenDestinationsLabelIsVisible()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.DestinationLabel.GetElementVisibility(), "Destination label is not displayed.\n");
            string ActualLabelText = cvsmUpdateConfig.DestinationLabel.Text;
            string ExpectedLabelText = CVSMUpdateConfig.ExpectedValues.DestinationLabelText;
            Assert.AreEqual(ExpectedLabelText, ActualLabelText, "Destination label text is not matching with expected value.\n");
        }

        [Then(@"location hierarchy selectors are displayed")]
        public void ThenLocationHierarchySelectorsAreDisplayed()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.LocationHierarchy.GetElementVisibility(), "Location hierarchy selectors are not displayed.\n");
        }

        [Then(@"count of selected devices is displayed")]
        public void ThenCountOfSelectedDevicesIsDisplayed()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.DeviceCount.GetElementVisibility(), "Selected device count is not displayed");
        }

        [Then(@"Previous button is enabled")]
        public void ThenPreviousButtonIsEnabled()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.PreviousButton.Enabled, "Previous button is not enabled.\n");
        }

        [Then(@"Next button is disabled in select assets page")]
        public void ThenNextButtonIsDisabled1()
        {
            Assert.AreEqual(false, cvsmUpdateConfig.SelectDevicesNextButton.Enabled, "Next button is not disabled.\n");
        }

        [Then(@"user will see Page x of y indicator")]
        public void ThenUserWillSeePageXOfYIndicator()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.PaginationXOfY.GetElementVisibility(), "Page x of y indicator is not displayed.\n");
        }

        [Then(@"user will see Displaying x to y of z results indicator")]
        public void ThenUserWillSeeDisplayingXToYOfZResultsIndicator()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.DisplayPaginationText.GetElementVisibility(), "x to y of z results indicator is not diisplayed");
        }

        [Then(@"Select all checkbox in column 1 is unchecked")]
        public void ThenSelectAllCheckboxInColumnIsUnchecked()
        {
            Assert.AreEqual(false, cvsmUpdateConfig.SelectAllcheckBox.Selected,"Select all check box is not uncheked.\n");
        }

        [Then(@"""(.*)"" column (.*) heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string HeadingName, int p1)
        {
            IWebElement Heading=null;
            string ExpectedHeadingText=null;
            switch(HeadingName.ToLower().Trim())
            {
                case "firmware": Heading = cvsmUpdateConfig.FirmwareHeading;
                    ExpectedHeadingText = CVSMUpdateConfig.ExpectedValues.FirwareHeadingText;
                                break;
                case "config":
                    Heading = cvsmUpdateConfig.ConfigHeading;
                    ExpectedHeadingText = CVSMUpdateConfig.ExpectedValues.ConfigHeadingText;
                    break;
                case "asset tag":
                    Heading = cvsmUpdateConfig.AssetTagHeading;
                    ExpectedHeadingText = CVSMUpdateConfig.ExpectedValues.AssetTagHeadingText;
                    break;
                case "serial":
                    Heading = cvsmUpdateConfig.SerialNoHeading;
                    ExpectedHeadingText = CVSMUpdateConfig.ExpectedValues.SerialHeadingText;
                    break;
                case "location":
                    Heading = cvsmUpdateConfig.LocationHeading;
                    ExpectedHeadingText = CVSMUpdateConfig.ExpectedValues.LocationHeadingText;
                    break;
                case "last files deployed":
                    Heading = cvsmUpdateConfig.LastFilesDeployedHeading;
                    ExpectedHeadingText = CVSMUpdateConfig.ExpectedValues.LastFilesDeployedHeadingText;
                    break;
                default: Assert.Fail(HeadingName+"is not present on the test data");
                    break;
            }
            Assert.AreEqual(true, Heading.GetElementVisibility(), Heading+" is not displayed.\n");
            string ActualHeadingText = Heading.Text;
            Assert.AreEqual(ExpectedHeadingText, ActualHeadingText, HeadingName+" text is not matxhing with the expected value.\n");
        }

        [When(@"user selects one device")]
        public void WhenUserSelectsOneDevice()
        {
            cvsmUpdateConfig.FirstDeviceCheckBox.Click();
        }

        [Then(@"count of selected devices changes from 0 to 1")]
        public void ThenCountOfSelectedDevicesChangesFromTo()
        {
            string ActualDestinationCountText = cvsmUpdateConfig.DeviceCount.Text;
            string ExpectedDestinationCountText = CVSMUpdateConfig.ExpectedValues.Desination1DeviceCountText;
            Assert.AreEqual(ExpectedDestinationCountText, ActualDestinationCountText, "Count of selected devices does not change.\n");
        }

        [Then(@"Next button is enabled on select assets page")]
        public void ThenNextButtonIsEnabledOnSelectAssetsPage()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.SelectDevicesNextButton.Enabled, "Next button is not enabled.\n");
        }

        [When(@"user clicks Previous button")]
        public void WhenUserClicksPreviousButton()
        {
            Thread.Sleep(2000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(CVSMUpdateConfig.Locators.PreviousButtonID)));
            cvsmUpdateConfig.PreviousButton.JavaSciptClick();
        }

        [Then(@"user is on CVSM Updates page")]
        public void ThenUserIsOnCVSMUpdatesPage()
        {
            bool UpdatePageElements = (cvsmUpdateConfig.AssetTypeDropDown.GetElementVisibility()) || (cvsmUpdateConfig.UpgradeTypeDropDown.GetElementVisibility()); 
            Assert.AreEqual(true, UpdatePageElements, "User is not on CVSM Update page");
        }

        [When(@"Clicks Next button")]
        public void WhenClicksNextButton()
        {
            cvsmUpdateConfig.SelectDevicesNextButton.Click();
        }

        [Then(@"CVSM Review Action page is displayed")]
        public void ThenCVSMReviewActionPageIsDisplayed()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.ReviewActionPushItems.GetElementVisibility(), "CVSM review action page is not displayed.\n");
        }

        [Given(@"user is on CVSM Review Action page")]
        public void GivenUserIsOnCVSMReviewActionPage()
        {
            GivenUserIsOnCVSMConfigurationSelectAssetsPage();
            cvsmUpdateConfig.FirstDeviceCheckBox.Click();
            cvsmUpdateConfig.SelectDevicesNextButton.Click();
            Assert.AreEqual(true, cvsmUpdateConfig.ReviewActionPushItems.GetElementVisibility(), "CVSM review action page is not displayed.\n");
        }

        [Then(@"Item to push label is displayed")]
        public void ThenItemToPushLabelIsDisplayed()
        {
            Assert.AreEqual(true,cvsmUpdateConfig.ReviewActionItemToPushLabel.GetElementVisibility(), "Item to push label is not displayed.\n");
        }

        [Then(@"Item to push value is displayed")]
        public void ThenItemToPushValueIsDisplayed()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.ReviewActionItemToPushValue.GetElementVisibility(), "Item to push value is not displayed");
        }

        [Then(@"Destinations label is displayed")]
        public void ThenDestinationsLabelIsDisplayed()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.ReviewActionDestinationLabel.GetElementVisibility(), "Destinations label is not displayed.\n");
        }

        [Then(@"Destinations value is displayed")]
        public void ThenDestinationsValueIsDisplayed()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.ReviewActionDestinationValue.GetElementVisibility(), "Destinations value is not displayed.\n");
        }

        [Then(@"Review action indicator is highlighted")]
        public void ThenReviewActionIndicatorIsHighlighted()
        {
            Assert.AreEqual(CVSMUpdateConfig.ExpectedValues.HighlightedSectionCircleClassName, cvsmUpdateConfig.ReviewActionTabCircle.GetAttribute("class"), "Review action indicator is not highlighted.\n");
        }

        [Then(@"Confirm button is enabled")]
        public void ThenConfirmButtonIsEnabled()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.ReviewActionConfirmButton.Enabled, "Confirm button is not enabled.\n");
        }


        [When(@"user clicks Confirm button")]
        public void WhenUserClicksConfirmButton()
        {
            cvsmUpdateConfig.ReviewActionConfirmButton.Click();
        }

        [Then(@"Update process has been established message is displayed")]
        public void ThenUpdateProcessHasBeenEstablishedMessageIsDisplayed()
        {
            Thread.Sleep(1000);
           Assert.AreEqual(true, cvsmUpdateConfig.SucessUpadteMessage.GetElementVisibility(), "Update process has been established message is not displayed");
        }

        [Then(@"Select devices page is displayed")]
        public void ThenSelectDevicesPageIsDisplayed()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(CVSMUpdateConfig.Locators.SelectAllcheckBoxID)));
            bool SelectDevicePageElements = (cvsmUpdateConfig.SelectAllcheckBox.GetElementVisibility()) || (cvsmUpdateConfig.DeployHead.GetElementVisibility());
            Assert.AreEqual(true, SelectDevicePageElements, "Select devices page is not displayed.\n");
        }

        [Then(@"Next page button is enabled")]
        public void ThenNextPageButtonIsEnabled()
        {
            SetMethods.ScrollToBottomofWebpage();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(CVSMUpdateConfig.Locators.PaginationNextIconID)));
            string PaginationTextBeforeClick = cvsmUpdateConfig.PaginationXOfY.Text;
            cvsmUpdateConfig.PaginationNextIcon.Click();
            string PaginationTextAfterClick = cvsmUpdateConfig.PaginationXOfY.Text;
            Assert.AreNotEqual(PaginationTextBeforeClick, PaginationTextAfterClick, "Next page button is not disabled");
        }

        [Given(@"first (.*) entries are displayed")]
        public void GivenFirstEntriesAreDisplayed(int p0)
        {
            Assert.AreEqual(50, cvsmUpdateConfig.SelectUpdateConfigFileNameList.GetElementCount(), "First 50 entries are not displayed");
        }

        [When(@"user clicks Next page button")]
        public void WhenUserClicksNextPageButton()
        {
            SetMethods.ScrollToBottomofWebpage();
            cvsmUpdateConfig.PaginationNextIcon.Click();
        }

        [Then(@"second page of entries is displayed")]
        public void ThenSecondPageOfEntriesIsDisplayed()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.SelectUpdateConfigFileNameList.GetElementCount() > 0, "second page of entries are not displayed");
        }

    }
}
