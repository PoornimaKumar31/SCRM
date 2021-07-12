using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5904")]
    public class Req5904Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        CSMConfigStatusPage csmConfigStatusPage = new CSMConfigStatusPage();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        IDictionary<string, string> statusDefinationPairs;

        [Given(@"user is on CSM Configuration Update Status page")]
        public void GivenUserIsOnCSMConfigurationUpdateStatusPage()
        {
            loginPage.SignIn("AdminWithRollUp");
            landingPage.Organization0Facility0Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("deviceTable")));
            mainPage.ReportsTab.JavaSciptClick();
            csmConfigStatusPage.AssetTypeDropdown.SelectDDL(CSMConfigStatusPage.ExpectedValues.CSMDeviceName);
            csmConfigStatusPage.ReportTypeDropdown.SelectDDL(CSMConfigStatusPage.ExpectedValues.CSMConfiguration);
            csmConfigStatusPage.GetReportButton.Click();
        }
        
        [When(@"user clicks Information button")]
        public void WhenUserClicksInformationButton()
        {
            csmConfigStatusPage.InformationButton.Click();
        }
        
        [Then(@"CSM Configuration report Statuses dialog is displayed")]
        public void ThenCSMConfigurationReportStatusesDialogIsDisplayed()
        {
            Assert.AreEqual(csmConfigStatusPage.InformationPopUp.GetElementVisibility(), true, "Information popup is not displayed.\n");
        }
        
        [Then(@"user can see CSM Configuration Report Statuses header")]
        public void ThenUserCanSeeCSMConfigurationReportStatusesHeader()
        {
            Assert.AreEqual(csmConfigStatusPage.InformationPopUpHeader.GetElementVisibility(), true, "CSM Configuration report status header is not visible");
            string ActualHeaderText = csmConfigStatusPage.InformationPopUpHeader.Text;
            string ExpectedHeaderText = CSMConfigStatusPage.ExpectedValues.InformationPopUPHeaderText;
            Assert.AreEqual(ExpectedHeaderText, ActualHeaderText, "CSM Configuration report status header text is not matching with the expected value.\n");
        }

        [Then(@"user can see ""(.*)"" status and definition")]
        public void ThenUserCanSeeStartedStatusAndDefinition(string statustitle)
        {
            //defination
            string statusTabledata = csmConfigStatusPage.InformationPopUpData.Text;
            statusDefinationPairs = csmConfigStatusPage.GetstatusTable(statusTabledata);
            string ActualDefination = statusDefinationPairs[statustitle];
            string ExpectedDefinaton=null;
            switch(statustitle.ToLower().Trim())
            {
                case "started":
                    ExpectedDefinaton = CSMConfigStatusPage.ExpectedValues.stratredDefinition;
                    break;
                case "transferred":
                    ExpectedDefinaton = CSMConfigStatusPage.ExpectedValues.transferred_Definitation;
                    break;
                case "available":
                    ExpectedDefinaton = CSMConfigStatusPage.ExpectedValues.availableDefinitation;
                    break;
                case "applied":
                    ExpectedDefinaton = CSMConfigStatusPage.ExpectedValues.appliedDefinitation;
                    break;
                case "failed":
                    ExpectedDefinaton = CSMConfigStatusPage.ExpectedValues.failedDefinition;
                    break;
                default: Assert.Fail(statustitle+" does not exist in test data");
                    break;
            }
            Assert.AreEqual(ExpectedDefinaton, ActualDefination, statustitle + " defination does not match with expected");
        }        
        [Then(@"user can see Close button")]
        public void ThenUserCanSeeCloseButton()
        {
            Assert.AreEqual(csmConfigStatusPage.InformationPopUpCloseButton.GetElementVisibility(), true, "Close button is not displayed.\n");
        }

        [Given(@"CSM Configuration Report Statuses dialog is displayed")]
        public void GivenCSMConfigurationReportStatusesDialogIsDisplayed()
        {
            csmConfigStatusPage.InformationButton.Click();
            Assert.AreEqual(csmConfigStatusPage.InformationPopUp.GetElementVisibility(), true, "CSM Configuration report status is not displayed");
        }

        [When(@"user clicks Close button")]
        public void WhenUserClicksCloseButton()
        {
            csmConfigStatusPage.InformationPopUpCloseButton.Click();
        }

        [Then(@"CSM Configuration Report Statuses dialog closes")]
        public void ThenCSMConfigurationReportStatusesDialogCloses()
        {
            Assert.AreEqual(csmConfigStatusPage.InformationPopUp.GetElementVisibility(), false, "CSM Configuration report status is not closed");
        }

        [Then(@"user is on CSM Configuration Update Status page")]
        public void ThenUserIsOnCSMConfigurationUpdateStatusPage()
        {
            Assert.AreEqual(csmConfigStatusPage.InformationButton.GetElementVisibility(), true, "User is not on Configuration update status page");
        }


    }
}
