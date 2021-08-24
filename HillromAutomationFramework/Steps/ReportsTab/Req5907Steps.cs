using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5907")]
    public class Req5907Steps
    {

        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        ReportsPage reportsPage = new ReportsPage();
        FirmwareStatusPage firmwareStatusPage = new FirmwareStatusPage();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        IDictionary<string, string> statusDefinationPairs;

        [Given(@"user is on CSM Firmware Upgrade Status report page")]
        public void GivenUserIsOnCSMFirmwareUpgradeStatusReportPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("deviceTable")));
            mainPage.ReportsTab.JavaSciptClick();
            reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CSMDeviceName);
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareStatusReportType);
            reportsPage.GetReportButton.Click();
        }
        
        [When(@"user clicks Information button")]
        public void WhenUserClicksInformationButton()
        {
            firmwareStatusPage.InformationButton.Click();
        }
        
        [Then(@"CSM Firmware Report Statuses dialog is displayed")]
        public void ThenCSMFirmwareReportStatusesDialogIsDisplayed()
        {
            Assert.AreEqual(firmwareStatusPage.InformationPopUp.GetElementVisibility(), true, "CSM firmware report status dialog box is not displayed");
        }
        
        [Then(@"CSM Firmware Report Statuses header is displayed")]
        public void ThenCSMFirmwareReportStatusesHeaderIsDisplayed()
        {
            Assert.AreEqual(firmwareStatusPage.InformationPopUpHeader.GetElementVisibility(), true, "CSM Firmware report staus header is not displayed");
            string ActualHeaderText = firmwareStatusPage.InformationPopUpHeader.Text;
            string ExpectedHeaderText = FirmwareStatusPage.ExpectedValues.CSMInformationPopUPHeaderText;
            Assert.AreEqual(ExpectedHeaderText, ActualHeaderText, "CSM Firmware report status header text does not match the expected text.\n");
        }

        [Then(@"""(.*)"" status and definition is displayed")]
        public void ThenStatusAndDefinitionIsDisplayed(string statustitle)
        {
            //status defination
            string statusTabledata = firmwareStatusPage.InformationPopUpData.Text;
            statusDefinationPairs = firmwareStatusPage.GetstatusTable(statusTabledata);
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
            Assert.AreEqual(ExpectedDefinaton, ActualDefination, statustitle + " defination does not match with expected text");
        }

        [Then(@"Close button is displayed")]
        public void CloseButtonIsDisplayed()
        {
            Assert.AreEqual(firmwareStatusPage.InformationPopUpCloseButton.GetElementVisibility(), true, "Close button is not displayed");
        }

        [Given(@"CSM Firmware Report Statuses dialog is displayed")]
        public void GivenCSMFirmwareReportStatusesDialogIsDisplayed()
        {
            firmwareStatusPage.InformationButton.Click();
            Assert.AreEqual(true, firmwareStatusPage.InformationPopUp.GetElementVisibility(), "Firmware report status dialog is not displayed");
        }

        [When(@"user clicks Close button")]
        public void WhenUserClicksCloseButton()
        {
            firmwareStatusPage.InformationPopUpCloseButton.Click();
        }

        [Then(@"CSM Firmware Report Statuses dialog closes")]
        public void ThenCSMFirmwareReportStatusesDialogCloses()
        {
            Assert.AreEqual(false, firmwareStatusPage.InformationPopUp.GetElementVisibility(), "Firmware report status dialog is not closed");
        }

        [Then(@"CSM Firmware Upgrade Status page is displayed")]
        public void ThenUserIsOnCSMFirmwareUpgradeStatusPage()
        {
            Assert.AreEqual(true, firmwareStatusPage.InformationButton.GetElementVisibility(), "User is not on Upgrade status page");
        }


        [Given(@"user is on RV700 Firmware Upgrade Status report page")]
        public void GivenUserIsOnRVFirmwareUpgradeStatusReportPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title,"L&T Automated Eye Test.");
            landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.ReportsTab.JavaSciptClick();
            reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.RV700DeviceName);
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareStatusReportType);
            reportsPage.GetReportButton.Click();
        }

        [Then(@"RV700 Firmware Report Statuses dialog is displayed")]
        public void ThenRVFirmwareReportStatusesDialogIsDisplayed()
        {
            Assert.AreEqual(true, firmwareStatusPage.InformationPopUp.GetElementVisibility(), "RV700 Firmware Report Statuses dialog is not displayed");
        }

        [Then(@"RV700 Firmware Report Statuses header is displayed")]
        public void ThenRVFirmwareReportStatusesHeaderIsDisplayed()
        {
            Assert.AreEqual(true, firmwareStatusPage.InformationPopUpHeader.GetElementVisibility(), "Rv700 Firmware report status header is not displayed");
            string ActualHeaderText = firmwareStatusPage.InformationPopUpHeader.Text;
            string ExpectedHeaderText = FirmwareStatusPage.ExpectedValues.RV700InformationPopUPHeaderText;
            Assert.AreEqual(ExpectedHeaderText, ActualHeaderText, "RV700 report status header text is not matching with expected.\n");
        }

        [Then(@"""(.*)"" status and definition of RV700 is displayed")]
        public void ThenUserCanSeeStatusAndDefinitionOfRV(string statusTitle)
        {
            //status and defination
            string statusTabledata = firmwareStatusPage.InformationPopUpData.Text;
            statusDefinationPairs = firmwareStatusPage.GetstatusTable(statusTabledata);
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
            Assert.AreEqual(ExpectedDefinaton, ActualDefination, statusTitle + " defination does not match with expected text");
        }


        [Given(@"RV700 Firmware Report Statuses dialog is displayed")]
        public void GivenRVFirmwareReportStatusesDialogIsDisplayed()
        {
            firmwareStatusPage.InformationButton.Click();
            Assert.AreEqual(true, firmwareStatusPage.InformationPopUp.GetElementVisibility(), "RV700 Firmware Report Statuses dialog is not displayed.\n");
        }

        [Then(@"RV700 Firmware Report Statuses dialog closes")]
        public void ThenRVFirmwareReportStatusesDialogCloses()
        {
            Assert.AreEqual(false, firmwareStatusPage.InformationPopUp.GetElementVisibility(), "RV700 Firmware Report Statuses dialog is not closed");
        }

        [Then(@"RV700 Firmware Upgrade Status page is displayed")]
        public void ThenRVFirmwareUpgradeStatusPageIsDisplayed()
        {
            Assert.AreEqual(true, firmwareStatusPage.InformationButton.GetElementVisibility(), "User is not on RV700 firmware upgrade status page");
        }

        [Given(@"user is on Centrella Firmware Upgrade Status report page")]
        public void GivenUserIsOnCentrellaFirmwareUpgradeStatusReportPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(landingPage.EdenHospitalMedicalCenterOrganizationTitle, "Centrella Orgaization");
            landingPage.EdenHospitalMedicalCenterOrganizationFacilityMedicalCenter.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.ReportsTab.JavaSciptClick();
            reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CentrellaDeviceName);
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareStatusReportType);
            reportsPage.GetReportButton.Click();
        }

        [Then(@"Centrella Firmware Report Statuses dialog is displayed")]
        public void ThenCentrellaFirmwareReportStatusesDialogIsDisplayed()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(FirmwareStatusPage.Locators.InformationPopUpId)));
            Assert.IsTrue(firmwareStatusPage.InformationPopUp.GetElementVisibility(),"Centrella firmware report status dialog is not displayed.");
        }

        [Then(@"Centrella Firmware Report Statuses header is displayed")]
        public void ThenCentrellaFirmwareReportStatusesHeaderIsDisplayed()
        {
            Assert.IsTrue(firmwareStatusPage.InformationPopUpHeader.GetElementVisibility(),"Centrella firmware report header is not displayed.");
            Assert.AreEqual(FirmwareStatusPage.ExpectedValues.CentrellaInformationPopUpHeaderText.ToLower(), firmwareStatusPage.InformationPopUpHeader.Text.ToLower(), "Centrella firmware report header is not matching the expected value.");
        }

        [Then(@"""(.*)"" status and definition of Centrella is displayed")]
        public void ThenStatusAndDefinitionOfCentrellaIsDisplayed(string statusTitle)
        {
            //status and defination
            string statusTabledata = firmwareStatusPage.InformationPopUpData.Text;
            statusDefinationPairs = firmwareStatusPage.GetstatusTable(statusTabledata);
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
            Assert.AreEqual(ExpectedDefinaton, ActualDefination, statusTitle + " defination does not match with expected text");
        }

        [Given(@"Centrella Firmware Report Statuses dialog is displayed")]
        public void GivenCentrellaFirmwareReportStatusesDialogIsDisplayed()
        {
            firmwareStatusPage.InformationButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(FirmwareStatusPage.Locators.InformationPopUpId)));
            Assert.IsTrue(firmwareStatusPage.InformationPopUp.GetElementVisibility(), "Centrella firmware report status dialog is not displayed.");
        }

        [Then(@"Centrella Firmware Report Statuses dialog closes")]
        public void ThenCentrellaFirmwareReportStatusesDialogCloses()
        {
            Assert.IsFalse(firmwareStatusPage.InformationPopUp.GetElementVisibility(), "Centrella Firmware Report Statuses dialog is not closed");
        }

        [Then(@"Centrella Firmware Upgrade Status page is displayed")]
        public void ThenCentrellaFirmwareUpgradeStatusPageIsDisplayed()
        {
            Assert.IsTrue(firmwareStatusPage.InformationButton.GetElementVisibility(), "User is not on Centrella firmware upgrade status page");
        }

    }
}
