using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.ReportsTab;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5904")]
    public class Req5904Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly ReportsPage _reportsPage;
        private readonly ConfigStatusReportPage _csmConfigStatusPage;


        IDictionary<string, string> statusDefinationPairs;
        private readonly WebDriverWait _wait;
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public Req5904Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
            _reportsPage = new ReportsPage(driver);
            _csmConfigStatusPage = new ConfigStatusReportPage(driver);
        }


        [Given(@"user is on CSM Configuration Update Status page")]
        public void GivenUserIsOnCSMConfigurationUpdateStatusPage()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id("deviceTable")));
            _mainPage.ReportsTab.JavaSciptClick(_driver);
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPageExpectedValues.CSMDeviceName);
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.ConfigurationReportType);
            _reportsPage.GetReportButton.Click();
        }
        
        [When(@"user clicks Information button")]
        public void WhenUserClicksInformationButton()
        {
            _csmConfigStatusPage.InformationButton.Click();
        }
        
        [Then(@"CSM Configuration report Statuses dialog is displayed")]
        public void ThenCSMConfigurationReportStatusesDialogIsDisplayed()
        {
            (_csmConfigStatusPage.InformationPopUp.GetElementVisibility()).Should().BeTrue("Information popup dialog box should be displayed when user clicks on the Information button");
        }
        
        [Then(@"CSM Configuration Report Statuses header is displayed")]
        public void ThenUserCanSeeCSMConfigurationReportStatusesHeader()
        {
            (_csmConfigStatusPage.InformationPopUpHeader.GetElementVisibility()).Should().BeTrue("CSM Configuration report status header should be displayed in information dialog box");
            string ActualHeaderText = _csmConfigStatusPage.InformationPopUpHeader.Text;
            string ExpectedHeaderText = ConfigStatusReportPageExpectedValues.InformationPopUPHeaderText;
            ActualHeaderText.Should().BeEquivalentTo(ExpectedHeaderText, "CSM Configuration report status header text should match with the expected value");
        }

        [Then(@"""(.*)"" status and definition is displayed")]
        public void ThenUserCanSeeStartedStatusAndDefinition(string statustitle)
        {
            //status defination
            string statusTabledata = _csmConfigStatusPage.InformationPopUpData.Text;
            statusDefinationPairs = _csmConfigStatusPage.GetstatusTable(statusTabledata);
            string ActualDefination = statusDefinationPairs[statustitle];
            string ExpectedDefinaton=null;
            switch(statustitle.ToLower().Trim())
            {
                case "started":
                    ExpectedDefinaton = ConfigStatusReportPageExpectedValues.StratedDefinition;
                    break;
                case "transferred":
                    ExpectedDefinaton = ConfigStatusReportPageExpectedValues.TransferredDefinitation;
                    break;
                case "available":
                    ExpectedDefinaton = ConfigStatusReportPageExpectedValues.AvailableDefinitation;
                    break;
                case "applied":
                    ExpectedDefinaton = ConfigStatusReportPageExpectedValues.AppliedDefinitation;
                    break;
                case "failed":
                    ExpectedDefinaton = ConfigStatusReportPageExpectedValues.FailedDefinition;
                    break;
                default: Assert.Fail(statustitle+" does not exist in test data");
                    break;
            }
            ActualDefination.Should().BeEquivalentTo(ExpectedDefinaton, statustitle + " definationshould match with the expected value.");
        }        
        [Then(@"Close button is displayed")]
        public void ThenUserCanSeeCloseButton()
        {
            (_csmConfigStatusPage.InformationPopUpCloseButton.GetElementVisibility()).Should().BeTrue("Close button should be displayed in the information pop up dialog box");
        }

        [Given(@"CSM Configuration Report Statuses dialog is displayed")]
        public void GivenCSMConfigurationReportStatusesDialogIsDisplayed()
        {
            _csmConfigStatusPage.InformationButton.Click();
            (_csmConfigStatusPage.InformationPopUp.GetElementVisibility()).Should().BeTrue("CSM Configuration report status dialog should be displayed when user clicks Information button in Configuration update status report page.");
        }

        [When(@"user clicks Close button")]
        public void WhenUserClicksCloseButton()
        {
            _csmConfigStatusPage.InformationPopUpCloseButton.Click();
        }

        [Then(@"CSM Configuration Report Statuses dialog closes")]
        public void ThenCSMConfigurationReportStatusesDialogCloses()
        {
            (_csmConfigStatusPage.InformationPopUp.GetElementVisibility()).Should().BeFalse("CSM Configuration report status dialog should be closed when user clicks close button in Information Dialog box");
        }

        [Then(@"CSM Configuration Update Status page is displayed")]
        public void ThenCSMConfigurationUpdateStatusPageIsDisplayed()
        {
            (_csmConfigStatusPage.InformationButton.GetElementVisibility()).Should().BeTrue("User should be on Configuration update status page aftre clicking on close button in Information dialog box");
        }


    }
}
