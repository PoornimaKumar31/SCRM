using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Updates
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5698")]
    public class Req5698Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        UpdatesSelectUpdatePage updatesSelectUpdatePage = new UpdatesSelectUpdatePage();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        string ConfigFileName;
        private ScenarioContext _scenarioContext;

        public Req5698Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"user is on CVSM Updates page")]
        public void GivenUserIsOnCVSMUpdatesPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestEastOrganizationFacilityPanelTest4Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.UpdatesTab.JavaSciptClick();
        }
        
        [Given(@"CVSM Asset type is selected")]
        public void GivenCVSMAssetTypeIsSelected()
        {
            updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.CVSMDeviceName);
        }
        
        [Given(@"Configuration Update type is selected")]
        public void GivenConfigurationUpdateTypeIsSelected()
        {
            updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeConfiguration);
        }
        
        [When(@"user selects CVSM configuration")]
        public void WhenUserSelectsCVSMConfiguration()
        {
            updatesSelectUpdatePage.FirstFileCVSMAndCentrellaInTable.Click();
        }
        
        [When(@"user clicks Delete button")]
        public void WhenUserClicksDeleteButton()
        {
            updatesSelectUpdatePage.DeleteButton.Click();
        }
        
        [Then(@"CVSM Configuration File Delete Confirmation dialog is displayed")]
        public void ThenCVSMConfigurationFileDeleteConfirmationDialogIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.DeleteConfigFilePopUp.GetElementVisibility(), "CVSM Configuration File Delete Confirmation dialog is not displayed");
        }

        [Then(@"CVSM Updates page is displayed")]
        public void ThenCVSMUpdatesPageIsDisplayed()
        {
            bool UpdatePageElements = (updatesSelectUpdatePage.AssetTypeDropDown.GetElementVisibility()) || (updatesSelectUpdatePage.UpgradeTypeDropDown.GetElementVisibility());
            Assert.AreEqual(true, UpdatePageElements, "User is not on CVSM Update page");
        }


        [Given(@"user is on CVSM Configuration File Delete dialog")]
        public void GivenUserIsOnCVSMConfigurationFileDeleteDialog()
        {
            GivenUserIsOnCVSMUpdatesPage();
            updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.CVSMDeviceName);
            updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeConfiguration);
            updatesSelectUpdatePage.FirstFileCVSMAndCentrellaInTable.Click();
            ConfigFileName = updatesSelectUpdatePage.FirstFileCVSMAndCentrellaInTable.FindElement(By.Id("name")).Text;
            updatesSelectUpdatePage.DeleteButton.Click();
        }

        [Then(@"selected Configuration file is displayed")]
        public void ThenSelectedConfigurationFileIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.DeleteConfigFileName.GetElementVisibility(), "Configuration file name is not displayed on delete pop up.");
            string DeleteConfigFileName = updatesSelectUpdatePage.DeleteConfigFileName.Text;
            Assert.AreEqual(ConfigFileName.ToLower(),DeleteConfigFileName.ToLower(), "Selected Configuration file name is not matching the expected value.");
        }

        [Then(@"Are you sure message is displayed")]
        public void ThenAreYouSureMessageIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.DeleteAreYouSureMessage.GetElementVisibility(), "Are you sure message is not displayed");
            Assert.AreEqual(UpdatesSelectUpdatePage.ExpectedValues.DeleteConfigAreYouSureText.ToLower(), updatesSelectUpdatePage.DeleteAreYouSureMessage.Text.ToLower(), "Are you sure message is not matching the expected value.");
        }

        [Then(@"Yes button is displayed")]
        public void ThenYesButtonIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.DeletePopUpYesButton.GetElementVisibility(), "Yes button is not displayed");
        }

        [Then(@"No button is displayed")]
        public void ThenNoButtonIsDisplayed()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.DeletePopUpNoButton.GetElementVisibility(), "No button is not displayed");
        }

        [Then(@"configuration is not deleted from Configuration list")]
        public void ThenConfigurationIsFromConfigurationList()
        {
            Assert.AreEqual(true, updatesSelectUpdatePage.IsFilePresent(ConfigFileName), "Config file is deleted");        
        }
        [When(@"user clicks No button")]
        public void WhenUserClicksNoButton()
        {
            updatesSelectUpdatePage.DeletePopUpNoButton.Click();
        }
    }
}
