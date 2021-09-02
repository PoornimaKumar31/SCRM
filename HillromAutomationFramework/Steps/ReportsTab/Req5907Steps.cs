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

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5907")]
    public class Req5907Steps
    {

        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly ReportsPage _reportsPage;
        private readonly FirmwareStatusPage _firmwareStatusPage;
        private readonly WebDriverWait _wait;

        IDictionary<string, string> statusDefinationPairs;

        private readonly ScenarioContext _scenarioContext;

        public Req5907Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage();
            _landingPage = new LandingPage();
            _mainPage = new MainPage();
            _reportsPage = new ReportsPage();
            _firmwareStatusPage = new FirmwareStatusPage();
        }

        [Given(@"user is on CSM Firmware Upgrade Status report page")]
        public void GivenUserIsOnCSMFirmwareUpgradeStatusReportPage()
        {
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id("deviceTable")));
            _mainPage.ReportsTab.JavaSciptClick();
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CSMDeviceName);
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareStatusReportType);
            _reportsPage.GetReportButton.Click();
        }
        
        [When(@"user clicks Information button")]
        public void WhenUserClicksInformationButton()
        {
            _firmwareStatusPage.InformationButton.Click();
        }
        
        [Then(@"CSM Firmware Report Statuses dialog is displayed")]
        public void ThenCSMFirmwareReportStatusesDialogIsDisplayed()
        {
            (_firmwareStatusPage.InformationPopUp.GetElementVisibility()).Should().BeTrue(because: "CSM firmware report status dialog box should be displayed when user clicks on information button in CSM Firmware Upgrade Status report page");
        }
        
        [Then(@"CSM Firmware Report Statuses header is displayed")]
        public void ThenCSMFirmwareReportStatusesHeaderIsDisplayed()
        {
            (_firmwareStatusPage.InformationPopUpHeader.GetElementVisibility()).Should().BeTrue(because: "CSM Firmware report staus header should be displayed in CSM firmware report status dialog box");
            string ActualHeaderText = _firmwareStatusPage.InformationPopUpHeader.Text;
            string ExpectedHeaderText = FirmwareStatusPage.ExpectedValues.CSMInformationPopUPHeaderText;
            ActualHeaderText.Should().BeEquivalentTo(ExpectedHeaderText, because: "CSM Firmware report status header text should match with the expected text");
        }

        [Then(@"""(.*)"" status and definition is displayed")]
        public void ThenStatusAndDefinitionIsDisplayed(string statustitle)
        {
            //status defination
            string statusTabledata = _firmwareStatusPage.InformationPopUpData.Text;
            statusDefinationPairs = _firmwareStatusPage.GetstatusTable(statusTabledata);
            string ActualDefination = statusDefinationPairs[statustitle];
            string ExpectedDefinaton = null;
            switch (statustitle.ToLower().Trim())
            {
                case "started":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.CSMStratedDefinition;
                    break;
                case "available":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.CSMAvailableDefination;
                    break;
                case "downloading":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.CSMDownloadingDefination;
                    break;
                case "downloaded":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.CSMDownloadedDefination;
                    break;
                case "scheduled":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.CSMScheduledDefination;
                    break;
                case "updating":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.CSMUpdatingDefination;
                    break;
                case "applied":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.CSMAppliedDefination;
                    break;
                case "cancel requested":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.CSMCancelRequestedDefination;
                    break;
                case "canceling":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.CSMCancelingDefination;
                    break;
                case "download failed":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.CSMDownloadFailedDefination;
                    break;
                case "failed":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.CSMFailedDefination;
                    break;
                default:
                    Assert.Fail(statustitle + " does not exist in test data");
                    break;
            }
            ActualDefination.Should().BeEquivalentTo(ExpectedDefinaton,because: statustitle + " defination should match with expected text");
        }

        [Then(@"Close button is displayed")]
        public void CloseButtonIsDisplayed()
        {
            (_firmwareStatusPage.InformationPopUpCloseButton.GetElementVisibility()).Should().BeTrue("Close button should be displayed  in CSM firmware report status dialog box");
        }

        [Given(@"CSM Firmware Report Statuses dialog is displayed")]
        public void GivenCSMFirmwareReportStatusesDialogIsDisplayed()
        {
            _firmwareStatusPage.InformationButton.Click();
            (_firmwareStatusPage.InformationPopUp.GetElementVisibility()).Should().BeTrue(because: "CSM firmware report status dialog box should be displayed when user clicks on information button in CSM Firmware Upgrade Status report page");
        }

        [When(@"user clicks Close button")]
        public void WhenUserClicksCloseButton()
        {
            _firmwareStatusPage.InformationPopUpCloseButton.Click();
        }

        [Then(@"CSM Firmware Report Statuses dialog closes")]
        public void ThenCSMFirmwareReportStatusesDialogCloses()
        {
            (_firmwareStatusPage.InformationPopUp.GetElementVisibility()).Should().BeFalse(because: "Firmware report status dialog should be closed when user clicks on close button");
        }

        [Then(@"CSM Firmware Upgrade Status page is displayed")]
        public void ThenUserIsOnCSMFirmwareUpgradeStatusPage()
        {
            (_firmwareStatusPage.InformationButton.GetElementVisibility()).Should().BeTrue(because: "User should be CSM firmware Upgrade status page when user clicks on close button in Firmware report status dialog box");
        }


        [Given(@"user is on RV700 Firmware Upgrade Status report page")]
        public void GivenUserIsOnRVFirmwareUpgradeStatusReportPage()
        {
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(_landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title,"L&T Automated Eye Test.");
            _landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));

            _mainPage.ReportsTab.JavaSciptClick();
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.RV700DeviceName);
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareStatusReportType);
            _reportsPage.GetReportButton.Click();
        }

        [Then(@"RV700 Firmware Report Statuses dialog is displayed")]
        public void ThenRVFirmwareReportStatusesDialogIsDisplayed()
        {
            (_firmwareStatusPage.InformationPopUp.GetElementVisibility()).Should().BeTrue("RV700 Firmware Report Statuses dialog box should be displayed when user clicks on information button in RV700 Firmware Upgrade Status report page");
        }

        [Then(@"RV700 Firmware Report Statuses header is displayed")]
        public void ThenRVFirmwareReportStatusesHeaderIsDisplayed()
        {
            (_firmwareStatusPage.InformationPopUpHeader.GetElementVisibility()).Should().BeTrue(because: "RV700 Firmware report status header should be displayed in RV700 Firmware Report Statuses dialog box");
            string ActualHeaderText = _firmwareStatusPage.InformationPopUpHeader.Text;
            string ExpectedHeaderText = FirmwareStatusPage.ExpectedValues.RV700InformationPopUPHeaderText;
            ActualHeaderText.Should().BeEquivalentTo(ExpectedHeaderText, because: "RV700 report status header text should match with expected text.");
        }

        [Then(@"""(.*)"" status and definition of RV700 is displayed")]
        public void ThenUserCanSeeStatusAndDefinitionOfRV(string statusTitle)
        {
            //status and defination
            string statusTabledata = _firmwareStatusPage.InformationPopUpData.Text;
            statusDefinationPairs = _firmwareStatusPage.GetstatusTable(statusTabledata);
            string ActualDefination = statusDefinationPairs[statusTitle];
            string ExpectedDefinaton = null;
            switch (statusTitle.ToLower().Trim())
            {
                case "started":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.RV700StratedDefinition;
                    break;
                case "available":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.RV700AvailableDefination;
                    break;
                case "complete":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.RV700CompleteDefination;
                    break;
                case "failure":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.RV700FailureDefination;
                    break;
                default:
                    Assert.Fail(statusTitle + " does not exist in test data");
                    break;
            }
            ActualDefination.Should().BeEquivalentTo(ExpectedDefinaton,because: statusTitle + " defination should match with expected text");
        }


        [Given(@"RV700 Firmware Report Statuses dialog is displayed")]
        public void GivenRVFirmwareReportStatusesDialogIsDisplayed()
        {
            _firmwareStatusPage.InformationButton.Click();
            (_firmwareStatusPage.InformationPopUp.GetElementVisibility()).Should().BeTrue(because: "RV700 Firmware Report Statuses dialog should be displayed When user clicks information button on RV700 Firmware Upgrade Status report page.");
        }

        [Then(@"RV700 Firmware Report Statuses dialog closes")]
        public void ThenRVFirmwareReportStatusesDialogCloses()
        {
            (_firmwareStatusPage.InformationPopUp.GetElementVisibility()).Should().BeFalse("RV700 Firmware Report Statuses dialog should be closed when user clicks close button in RV700 Firmware Report Statuses dialog box");
        }

        [Then(@"RV700 Firmware Upgrade Status page is displayed")]
        public void ThenRVFirmwareUpgradeStatusPageIsDisplayed()
        {
            (_firmwareStatusPage.InformationButton.GetElementVisibility()).Should().BeTrue("RV700 firmware upgrade status page should be displayed when user clicks close button in RV700 Firmware Report Statuses dialog box");
        }

        [Given(@"user is on Centrella Firmware Upgrade Status report page")]
        public void GivenUserIsOnCentrellaFirmwareUpgradeStatusReportPage()
        {
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(_landingPage.PSSServiceOrganizationFacilityBatesville, "Centrella Orgaization");
            _landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));

            _mainPage.ReportsTab.JavaSciptClick();
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CentrellaDeviceName);
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareStatusReportType);
            _reportsPage.GetReportButton.Click();
        }

        [Then(@"Centrella Firmware Report Statuses dialog is displayed")]
        public void ThenCentrellaFirmwareReportStatusesDialogIsDisplayed()
        {
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(FirmwareStatusPage.Locators.InformationPopUpId)));
            (_firmwareStatusPage.InformationPopUp.GetElementVisibility()).Should().BeTrue("Centrella Firmware Report Statuses dialog should be displayed When user clicks information button on Centrella Firmware Upgrade Status report page.");
        }

        [Then(@"Centrella Firmware Report Statuses header is displayed")]
        public void ThenCentrellaFirmwareReportStatusesHeaderIsDisplayed()
        {
            (_firmwareStatusPage.InformationPopUpHeader.GetElementVisibility()).Should().BeTrue(because: "Centrella firmware report header should be displayed in Centrella Firmware Report Statuses dialog");
            (_firmwareStatusPage.InformationPopUpHeader.Text).Should().BeEquivalentTo(FirmwareStatusPage.ExpectedValues.CentrellaInformationPopUpHeaderText, because: "Centrella firmware report header should match with the expected value.");
        }

        [Then(@"""(.*)"" status and definition of Centrella is displayed")]
        public void ThenStatusAndDefinitionOfCentrellaIsDisplayed(string statusTitle)
        {
            //status and defination
            string statusTabledata = _firmwareStatusPage.InformationPopUpData.Text;
            statusDefinationPairs = _firmwareStatusPage.GetstatusTable(statusTabledata);
            string ActualDefination = statusDefinationPairs[statusTitle];
            string ExpectedDefinaton = null;
            switch (statusTitle.ToLower().Trim())
            {
                case "started":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.CentrellaStartedDefination;
                    break;
                case "downloading":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.CentrellaDownloadingDefination;
                    break;
                case "staging":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.CentrellaStagingDefination;
                    break;
                case "staging complete":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.CentrellaStagingCompleteDefination;
                    break;
                case "toggling":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.CentrellaTogglingDefination;
                    break;
                case "toggle complete":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.CentrellaTogglingCompleteDefination;
                    break;
                case "upgrade success":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.CentrellaUpgradeSuccessDefination;
                    break;
                case "download failure":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.CentrellaDownloadFailureDefination;
                    break;
                case "staging failure":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.CentrellaStagingFailureDefination;
                    break;
                case "staging inconsistent":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.CentrellaStagingInconsistentDefination;
                    break;
                case "toggle failure":
                    ExpectedDefinaton = FirmwareStatusPage.ExpectedValues.CentrellaToggeleFailureDefination;
                    break;
                default:
                    Assert.Fail(statusTitle + " does not exist in test data");
                    break;
            }
            ActualDefination.Should().BeEquivalentTo(ExpectedDefinaton, because: statusTitle + " defination should match with expected text");
        }

        [Given(@"Centrella Firmware Report Statuses dialog is displayed")]
        public void GivenCentrellaFirmwareReportStatusesDialogIsDisplayed()
        {
            _firmwareStatusPage.InformationButton.Click();
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(FirmwareStatusPage.Locators.InformationPopUpId)));
            (_firmwareStatusPage.InformationPopUp.GetElementVisibility()).Should().BeTrue("Centrella Firmware Report Statuses dialog should be displayed When user clicks information button on Centrella Firmware Upgrade Status report page.");
        }

        [Then(@"Centrella Firmware Report Statuses dialog closes")]
        public void ThenCentrellaFirmwareReportStatusesDialogCloses()
        {
            (_firmwareStatusPage.InformationPopUp.GetElementVisibility()).Should().BeFalse(because: "when user clicks on the close button in Centrella Firmware Report Statuses dialog,Then Centrella Firmware Report Statuses dialog should be closed");
        }

        [Then(@"Centrella Firmware Upgrade Status page is displayed")]
        public void ThenCentrellaFirmwareUpgradeStatusPageIsDisplayed()
        {
            (_firmwareStatusPage.InformationButton.GetElementVisibility()).Should().BeTrue("when user clicks on close button in Centrella Firmware Report Statuses dialog,Then Centrella firmware upgrade status page should be displayed");
        }

    }
}
