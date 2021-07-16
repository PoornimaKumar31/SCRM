using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Updates
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5698")]
    public class Req5698Steps
    {
        LoginPage loginPage = new LoginPage();
        MainPage mainPage = new MainPage();
        CVSMUpdateConfig cvsmUpdateConfig = new CVSMUpdateConfig();
        string ConfigFileName;
        private ScenarioContext _scenarioContext;

        public Req5698Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"user is on CVSM Updates page")]
        public void GivenUserIsOnCVSMUpdatesPage()
        {
            loginPage.SignIn("AdminWithoutRollUp");
            mainPage.UpdatesTab.JavaSciptClick();
        }
        
        [Given(@"CVSM Asset type is selected")]
        public void GivenCVSMAssetTypeIsSelected()
        {
            cvsmUpdateConfig.AssetTypeDropDown.SelectDDL(CVSMUpdateConfig.Inputs.CVSMDeviceName);
        }
        
        [Given(@"Configuration Update type is selected")]
        public void GivenConfigurationUpdateTypeIsSelected()
        {
            cvsmUpdateConfig.UpgradeTypeDropDown.SelectDDL(CVSMUpdateConfig.ExpectedValues.UpdateTypeConfiguration);
        }
        
        [When(@"user selects CVSM configuration")]
        public void WhenUserSelectsCVSMConfiguration()
        {
            cvsmUpdateConfig.FirstConfigFile.Click();
        }
        
        [When(@"user clicks Delete button")]
        public void WhenUserClicksDeleteButton()
        {
            cvsmUpdateConfig.DeleteButton.Click();
        }
        
        [Then(@"CVSM Configuration File Delete Confirmation dialog is displayed")]
        public void ThenCVSMConfigurationFileDeleteConfirmationDialogIsDisplayed()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.DeleteConfigFilePopUp.GetElementVisibility(), "CVSM Configuration File Delete Confirmation dialog is not displayed");
        }

        [Given(@"user is on CVSM Configuration File Delete dialog")]
        public void GivenUserIsOnCVSMConfigurationFileDeleteDialog()
        {
            GivenUserIsOnCVSMUpdatesPage();
            cvsmUpdateConfig.AssetTypeDropDown.SelectDDL(CVSMUpdateConfig.Inputs.CVSMDeviceName);
            cvsmUpdateConfig.UpgradeTypeDropDown.SelectDDL(CVSMUpdateConfig.ExpectedValues.UpdateTypeConfiguration);
            cvsmUpdateConfig.FirstConfigFile.Click();
            ConfigFileName = cvsmUpdateConfig.FirstConfigFile.Text;
            cvsmUpdateConfig.DeleteButton.Click();
        }

        [Then(@"selected Configuration file is displayed")]
        public void ThenSelectedConfigurationFileIsDisplayed()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.DeleteConfigFileName.GetElementVisibility(), "Configuration file name is not displayed on delete pop up.");
            string DeleteConfigFileName = cvsmUpdateConfig.DeleteConfigFileName.Text;
            Assert.AreEqual(true, ConfigFileName.Contains(DeleteConfigFileName), "Selected Configuration file name is not displayed.");
        }

        [Then(@"Are you sure message is displayed")]
        public void ThenAreYouSureMessageIsDisplayed()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.DeleteAreYouSureMessage.GetElementVisibility(), "Are you sure message is not displayed");
        }

        [Then(@"Yes button is displayed")]
        public void ThenYesButtonIsDisplayed()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.DeletePopUpYesButton.GetElementVisibility(), "Yes button is not displayed");
        }

        [Then(@"No button is displayed")]
        public void ThenNoButtonIsDisplayed()
        {
            Assert.AreEqual(true, cvsmUpdateConfig.DeletePopUpNoButton.GetElementVisibility(), "No button is not displayed");
        }

        [When(@"user clicks Yes button")]
        public void WhenUserClicksYesButton()
        {
            cvsmUpdateConfig.DeletePopUpYesButton.Click();
        }

        [Then(@"configuration is ""(.*)"" from Configuration list")]
        public void ThenConfigurationIsFromConfigurationList(string condition)
        {
            switch(condition.ToLower().Trim())
            {
                //implement a function to check is deleted or not
                case "deleted": _scenarioContext.Pending();
                    break;
                case "not deleted":_scenarioContext.Pending();
                    break;
                default: Assert.Fail("Deleted or not deleted should be mentioned");
                    break;
            }
        }

        [When(@"user clicks No button")]
        public void WhenUserClicksNoButton()
        {
            cvsmUpdateConfig.DeletePopUpNoButton.Click();
        }


    }
}
