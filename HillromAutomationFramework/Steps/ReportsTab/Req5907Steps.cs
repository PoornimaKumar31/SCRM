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
    [Binding,Scope(Tag = "SoftwareRequirementID_5907")]
    public class Req5907Steps
    {

        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly ReportsPage _reportsPage;
        private readonly FirmwareStatusReportPage _firmwareStatusPage;

        IDictionary<string, string> statusDefinationPairs;

        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverWait _wait;
        private readonly IWebDriver _driver;

        public Req5907Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
            _reportsPage = new ReportsPage(driver);
            _firmwareStatusPage = new FirmwareStatusReportPage(driver);
        }

        [Given(@"user is on CSM Firmware Upgrade Status report page")]
        public void GivenUserIsOnCSMFirmwareUpgradeStatusReportPage()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id("deviceTable")));
            _mainPage.ReportsTab.JavaSciptClick(_driver);
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPageExpectedValues.CSMDeviceName);
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.FirmwareStatusReportType);
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
            string ExpectedHeaderText = FirmwareStatusReportPageExpectedValues.CSMInformationPopUPHeaderText;
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
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.CSMStartedDefinition;
                    break;
                case "available":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.CSMAvailableDefination;
                    break;
                case "downloading":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.CSMDownloadingDefination;
                    break;
                case "downloaded":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.CSMDownloadedDefination;
                    break;
                case "scheduled":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.CSMScheduledDefination;
                    break;
                case "updating":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.CSMUpdatingDefination;
                    break;
                case "applied":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.CSMAppliedDefination;
                    break;
                case "cancel requested":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.CSMCancelRequestedDefination;
                    break;
                case "canceling":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.CSMCancelingDefination;
                    break;
                case "download failed":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.CSMDownloadFailedDefination;
                    break;
                case "failed":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.CSMFailedDefination;
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
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(_landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title, _driver, "L&T Automated Eye Test.");
            _landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));

            _mainPage.ReportsTab.JavaSciptClick(_driver);
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPageExpectedValues.RV700DeviceName);
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.FirmwareStatusReportType);
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
            string ExpectedHeaderText = FirmwareStatusReportPageExpectedValues.RV700InformationPopUPHeaderText;
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
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.RV700StartedDefinition;
                    break;
                case "available":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.RV700AvailableDefination;
                    break;
                case "complete":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.RV700CompleteDefination;
                    break;
                case "failure":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.RV700FailureDefination;
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
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(_landingPage.PSSServiceOrganizationFacilityBatesville, _driver, "Centrella Orgaization");
            _landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));

            _mainPage.ReportsTab.JavaSciptClick(_driver);
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPageExpectedValues.CentrellaDeviceName);
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.FirmwareStatusReportType);
            _reportsPage.GetReportButton.Click();
        }

        [Then(@"Centrella Firmware Report Statuses dialog is displayed")]
        public void ThenCentrellaFirmwareReportStatusesDialogIsDisplayed()
        {
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(FirmwareStatusReportPage.Locators.InformationPopUpId)));
            (_firmwareStatusPage.InformationPopUp.GetElementVisibility()).Should().BeTrue("Centrella Firmware Report Statuses dialog should be displayed When user clicks information button on Centrella Firmware Upgrade Status report page.");
        }

        [Then(@"Centrella Firmware Report Statuses header is displayed")]
        public void ThenCentrellaFirmwareReportStatusesHeaderIsDisplayed()
        {
            (_firmwareStatusPage.InformationPopUpHeader.GetElementVisibility()).Should().BeTrue(because: "Centrella firmware report header should be displayed in Centrella Firmware Report Statuses dialog");
            (_firmwareStatusPage.InformationPopUpHeader.Text).Should().BeEquivalentTo(FirmwareStatusReportPageExpectedValues.CentrellaInformationPopUpHeaderText, because: "Centrella firmware report header should match with the expected value.");
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
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.CentrellaStartedDefination;
                    break;
                case "downloading":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.CentrellaDownloadingDefination;
                    break;
                case "staging":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.CentrellaStagingDefination;
                    break;
                case "staging complete":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.CentrellaStagingCompleteDefination;
                    break;
                case "toggling":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.CentrellaTogglingDefination;
                    break;
                case "toggle complete":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.CentrellaTogglingCompleteDefination;
                    break;
                case "upgrade success":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.CentrellaUpgradeSuccessDefination;
                    break;
                case "download failure":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.CentrellaDownloadFailureDefination;
                    break;
                case "staging failure":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.CentrellaStagingFailureDefination;
                    break;
                case "staging inconsistent":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.CentrellaStagingInconsistentDefination;
                    break;
                case "toggle failure":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.CentrellaToggeleFailureDefination;
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
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(FirmwareStatusReportPage.Locators.InformationPopUpId)));
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

        //Progressa Firmware Status Information Close

        [Given(@"user is on Progressa Firmware Upgrade Status report page")]
        public void GivenUserIsOnProgressaFirmwareUpgradeStatusReportPage()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(_landingPage.PSSServiceOrganizationFacilityBatesville, _driver, "Progressa Orgaization");
            _landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));

            _mainPage.ReportsTab.JavaSciptClick(_driver);
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPageExpectedValues.ProgressaDeviceName);
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.FirmwareStatusReportType);
            _reportsPage.GetReportButton.Click();
        }

        [Given(@"Progressa Firmware Report Statuses dialog is displayed")]
        public void GivenProgressaFirmwareReportStatusesDialogIsDisplayed()
        {
            _firmwareStatusPage.InformationButton.Click();
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(FirmwareStatusReportPage.Locators.InformationPopUpId)));
            (_firmwareStatusPage.InformationPopUp.GetElementVisibility()).Should().BeTrue("Progressa Firmware Report Statuses dialog should be displayed When user clicks information button on Progressa Firmware Upgrade Status report page.");
        }

        [Then(@"Progressa Firmware Report Statuses dialog closes")]
        public void ThenProgressaFirmwareReportStatusesDialogCloses()
        {
            (_firmwareStatusPage.InformationPopUp.GetElementVisibility()).Should().BeFalse(because: "when user clicks on the close button in Progressa Firmware Report Statuses dialog,Then Progressa Firmware Report Statuses dialog should be closed");
        }

        [Then(@"Progressa Firmware Upgrade Status page is displayed")]
        public void ThenProgressaFirmwareUpgradeStatusPageIsDisplayed()
        {
            (_firmwareStatusPage.InformationButton.GetElementVisibility()).Should().BeTrue("when user clicks on close button in Progressa Firmware Report Statuses dialog,Then Progressa firmware upgrade status page should be displayed");
        }

        [Then(@"Progressa Firmware Report Statuses dialog is displayed")]
        public void ThenProgresaFirmwareReportStatusesDialogIsDisplayed()
        {
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(FirmwareStatusReportPage.Locators.InformationPopUpId)));
            (_firmwareStatusPage.InformationPopUp.GetElementVisibility()).Should().BeTrue("Centrella Firmware Report Statuses dialog should be displayed When user clicks information button on Centrella Firmware Upgrade Status report page.");
        }

        [Then(@"Progressa Firmware Report Statuses header is displayed")]
        public void ThenProgressaFirmwareReportStatusesHeaderIsDisplayed()
        {
            (_firmwareStatusPage.InformationPopUpHeader.GetElementVisibility()).Should().BeTrue(because: "Progressa firmware report header should be displayed in Progressa Firmware Report Statuses dialog");
            (_firmwareStatusPage.InformationPopUpHeader.Text).Should().BeEquivalentTo(FirmwareStatusReportPageExpectedValues.ProgressaInformationPopUpHeaderText, because: "Progressa firmware report header should match with the expected value.");
        }

        [Then(@"""(.*)"" status and definition of Progressa is displayed")]
        public void ThenStatusAndDefinitionOfProgressaIsDisplayed(string statusTitle)
        {
            //status and defination
            string statusTabledata = _firmwareStatusPage.InformationPopUpData.Text;
            statusDefinationPairs = _firmwareStatusPage.GetstatusTable(statusTabledata);
            string ActualDefination = statusDefinationPairs[statusTitle];
            string ExpectedDefinaton = null;
            switch (statusTitle.ToLower().Trim())
            {
                case "downloading":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.ProgressaDownloadingDefination;
                    break;
                case "mounting":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.ProgressaMountingDefination;
                    break;
                case "mounting complete":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.ProgressaMountingCompleteDefination;
                    break;
                case "initializing":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.ProgressaInitializingDefination;
                    break;
                case "staging":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.ProgressaStagingDefination;
                    break;
                case "updating wam":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.ProgressaUpdatingWAMDefination;
                    break;
                case "upgrade success":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.ProgressaUpgradeSuccessDefination;
                    break;
                case "local upgrade performed":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.ProgressaLocalUpgradePerformedDefination;
                    break;
                case "download failure":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.ProgressaDownloadFailureDefination;
                    break;
                case "inconsistent software error":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.ProgressaInconsistentSoftwareErrorDefination;
                    break;
                case "initializing failure":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.ProgressaInitializingFailureDefination;
                    break;
                case "mounting failure":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.ProgressaMountingFailureDefination;
                    break;
                case "staging failure":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.ProgressaStagingFailureDefination;
                    break;
                case "wam update failure":
                    ExpectedDefinaton = FirmwareStatusReportPageExpectedValues.ProgressaWamUpdateFailureDefination;
                    break;
                default:
                    Assert.Fail(statusTitle + " does not exist in test data");
                    break;
            }
            ActualDefination.Should().BeEquivalentTo(ExpectedDefinaton, because: statusTitle + " defination should match with expected text");
        }

    }
}
