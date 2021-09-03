using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.UpdatesTab.ConfigurationUpdate
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5698")]
    public class Req5698Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly UpdatesSelectUpdatePage _updatesSelectUpdatePage;
        private readonly WebDriverWait _wait;
        
        private readonly ScenarioContext _scenarioContext;

        private string ConfigFileName;

        public Req5698Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage();
            _landingPage = new LandingPage();
            _mainPage = new MainPage();
            _updatesSelectUpdatePage = new UpdatesSelectUpdatePage();
        }

        [Given(@"user is on CVSM Updates page")]
        public void GivenUserIsOnCVSMUpdatesPage()
        {
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestEastOrganizationFacilityPanelTest4Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.UpdatesTab.JavaSciptClick();
        }
        
        [Given(@"CVSM Asset type is selected")]
        public void GivenCVSMAssetTypeIsSelected()
        {
            _updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.CVSMDeviceName);
        }
        
        [Given(@"Configuration Update type is selected")]
        public void GivenConfigurationUpdateTypeIsSelected()
        {
            _updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeConfiguration);
        }
        
        [When(@"user selects CVSM configuration")]
        public void WhenUserSelectsCVSMConfiguration()
        {
            _updatesSelectUpdatePage.FirstFileCVSMAndCentrellaInTable.Click();
        }
        
        [When(@"user clicks Delete button")]
        public void WhenUserClicksDeleteButton()
        {
            _updatesSelectUpdatePage.DeleteButton.Click();
        }
        
        [Then(@"CVSM Configuration File Delete Confirmation dialog is displayed")]
        public void ThenCVSMConfigurationFileDeleteConfirmationDialogIsDisplayed()
        {
            (_updatesSelectUpdatePage.DeleteConfigFilePopUp.GetElementVisibility()).Should().BeTrue(because: "CVSM Configuration File Delete Confirmation dialog should be displayed when user clicks delete button");
        }

        [Then(@"CVSM Updates page is displayed")]
        public void ThenCVSMUpdatesPageIsDisplayed()
        {
            bool IsCvsmUpdatePageDisplayed = (_updatesSelectUpdatePage.AssetTypeDropDown.GetElementVisibility()) || (_updatesSelectUpdatePage.UpgradeTypeDropDown.GetElementVisibility());
            (IsCvsmUpdatePageDisplayed).Should().BeTrue(because: "User should be on CVSM Updates page");
        }


        [Given(@"user is on CVSM Configuration File Delete dialog")]
        public void GivenUserIsOnCVSMConfigurationFileDeleteDialog()
        {
            //Go to updates page
            GivenUserIsOnCVSMUpdatesPage();
            
            //Select CVSM Configuration
            _updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.CVSMDeviceName);
            _updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeConfiguration);

            //Clicking on the first file
            _updatesSelectUpdatePage.FirstFileCVSMAndCentrellaInTable.Click();

            //Strong the first file name
            ConfigFileName = _updatesSelectUpdatePage.FirstFileCVSMAndCentrellaInTable.FindElement(By.Id("name")).Text;
            _updatesSelectUpdatePage.DeleteButton.Click();
        }

        [Then(@"selected Configuration file is displayed")]
        public void ThenSelectedConfigurationFileIsDisplayed()
        {
            (_updatesSelectUpdatePage.DeleteConfigFileName.GetElementVisibility()).Should().BeTrue(because: "Configuration file name should be displayed on delete pop up dialog box.");
            string DeleteConfigFileName = _updatesSelectUpdatePage.DeleteConfigFileName.Text;
            (DeleteConfigFileName).Should().BeEquivalentTo(ConfigFileName, because: "Selected Configuration file name should match the expected value.");
        }

        [Then(@"Are you sure message is displayed")]
        public void ThenAreYouSureMessageIsDisplayed()
        {
            (_updatesSelectUpdatePage.DeleteAreYouSureMessage.GetElementVisibility()).Should().BeTrue(because: "Are you sure message should be displayed in configuration delete pop up dialog box");
            (_updatesSelectUpdatePage.DeleteAreYouSureMessage.Text.ToLower()).Should().BeEquivalentTo(UpdatesSelectUpdatePage.ExpectedValues.DeleteConfigAreYouSureText, because: "Are you sure message should match with the expected value.");
        }

        [Then(@"Yes button is displayed")]
        public void ThenYesButtonIsDisplayed()
        {
            (_updatesSelectUpdatePage.DeletePopUpYesButton.GetElementVisibility()).Should().BeTrue(because: "Yes button should be displayed in configuration delete pop up dialog box");
        }

        [Then(@"No button is displayed")]
        public void ThenNoButtonIsDisplayed()
        {
            (_updatesSelectUpdatePage.DeletePopUpNoButton.GetElementVisibility()).Should().BeTrue(because: "No button should be displayed in configuration delete pop up dialog box");
        }

        [Then(@"configuration is not deleted from Configuration list")]
        public void ThenConfigurationIsFromConfigurationList()
        {
            (_updatesSelectUpdatePage.IsFilePresent(ConfigFileName)).Should().BeTrue(because: ConfigFileName + " config file name should be deleted frm configuration list");
        }
        [When(@"user clicks No button")]
        public void WhenUserClicksNoButton()
        {
            _updatesSelectUpdatePage.DeletePopUpNoButton.Click();
        }
    }
}
