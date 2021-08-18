using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.PageObjects.Component_Information;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5702")]
    class Req5702Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        CSMAssetListPage csmAssetListPage = new CSMAssetListPage();
        MainPage mainPage = new MainPage();
        

        //Context Injection
        private ScenarioContext _scenarioContext;
        public Req5702Steps(ScenarioContext scnenarioContext)
        {
            _scenarioContext = scnenarioContext;              
        }


        [Given(@"user is on Asset List page with more than one CSM")]
        public void GivenUserIsOnAssetListPageWithMoreThanOneCSM()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CSMDeviceName);
            Assert.Greater(csmAssetListPage.GetDeviceCount(), 2);
        }

        [When(@"user clicks any CSM")]
        public void WhenUserClicksAnyCSM()
        {
            Thread.Sleep(2000);
            mainPage.SearchSerialNumberAndClick("100010000000");
        }

        [Then(@"Asset Details landing page is displayed")]
        public void ThenAssetDetailsLandingPageIsDisplayed()
        {
            Assert.IsTrue(csmAssetListPage.CSMDetailsPage.GetElementVisibility(), "Asset Details Landing Page is not displayed");
        }

        [Then(@"Asset Detail summary subsection with Edit button is displayed")]
        public void ThenAssetDetailSummarySubsectionWithEditButtonIsDisplayed()
        {
            Assert.IsTrue(csmAssetListPage.CSMDetailsSummary.GetElementVisibility(), "CVSM details summary subsection is not displayed");
            Assert.IsTrue(csmAssetListPage.EditButton.GetElementVisibility(), "Edit Button is not displayed");
        }

        [Then(@"Preventive Maintenance tab is displayed")]
        public void ThenPreventiveMaintenanceTabIsDisplayed()
        {
            Assert.IsTrue(csmAssetListPage.PreventiveMaintenanceTab.GetElementVisibility(), "Preventive Mainetenance Tab is not displayed");
        }

        [Then(@"Component Information tab is displayed")]
        public void ThenComponentInformationTabIsDisplayed()
        {
            Assert.IsTrue(csmAssetListPage.ComponentInformationTab.GetElementVisibility(), "Component information tab is not displayed");
        }

        [Then(@"Logs tab is displayed")]
        public void ThenLogsTabIsDisplayed()
        {
            Assert.IsTrue(csmAssetListPage.LogsTab.GetElementVisibility(), "Logs tab is not displayed");
        }

        [Then(@"Asset Detail subsection is displayed")]
        public void ThenAssetDetailSubsectionIsDisplayed()
        {
            Assert.IsTrue(csmAssetListPage.AssetDetailsSubsection.GetElementVisibility(), "Asset Details Subsection is not displayed");
        }


        [Given(@"user is on Component details page for CSM Serial number ""(.*)""")]
        public void GivenUserIsOnComponentDetailsPageForCSMSerialNumber(string SerialNumber)
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CSMDeviceName);
            Assert.Greater(csmAssetListPage.GetDeviceCount(), 2);
            Thread.Sleep(2000);
            mainPage.SearchSerialNumberAndClick(SerialNumber);
            csmAssetListPage.ComponentInformationTab.Click();
            Thread.Sleep(2000);
        }

        [Then(@"""(.*)"" is ""(.*)""")]
        public void ThenIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = csmAssetListPage.Name.Text;
                    break;
                case "serial number":
                    ActualValue = csmAssetListPage.SerialNumber.Text;
                    break;
                case "device hours on":
                    ActualValue = csmAssetListPage.TotalRunTimeValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " value is not as Expected Value");
        }

        [Then(@"""(.*)"" label is displayed in ""(.*)"" column")]
        public void ThenLabelIsDisplayedInColumn(string LabelName, string ColumnName)
        {
            int ActualColumnIndex = -1;
            int ExpectedColumnIndex = -2;
            switch (ColumnName.ToLower().Trim())
            {
                case "usage":
                    ExpectedColumnIndex = CSMAssetListPage.ExpectedValue.UsageColumnIndex;
                    break;
                default:
                    Assert.Fail(ColumnName + " is invalid");
                    break;
            }

            switch (LabelName.ToLower().Trim())
            {
                case "device hours on":
                    ActualColumnIndex = csmAssetListPage.ConnexElementList.IndexOf(csmAssetListPage.UsageColumn);
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedColumnIndex, ActualColumnIndex, LabelName + " is not in " + ColumnName);

        }

        [Then(@"battery row ""(.*)"" is ""(.*)""")]
        public void ThenBatteryRowIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "manufacture date":
                    ActualValue = csmAssetListPage.BatteryRowManufactureDate.Text;
                    break;
                case "serial number":
                    ActualValue = csmAssetListPage.BatteryRowSerialNumber.Text;
                    break;
                case "cycle count":
                    ActualValue = csmAssetListPage.BatteryRowCycleCount.Text;
                    break;
                case "name":
                    ActualValue = csmAssetListPage.BatteryRowName.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " value is not as Expected Value");
        }

        [Then(@"battery row ""(.*)"" is displayed in ""(.*)"" column")]
        public void ThenBatteryRowIsDisplayedInColumn(string LabelName, string ColumnName)
        {
            int ActualColumnIndex = -1;
            int ExpectedColumnIndex = -2;
            switch (ColumnName.ToLower().Trim())
            {
                case "usage":
                    ExpectedColumnIndex = CSMAssetListPage.ExpectedValue.UsageColumnIndex;
                    break;
                default:
                    Assert.Fail(ColumnName + " is invalid");
                    break;
            }

            switch (LabelName.ToLower().Trim())
            {
                case "cycle count":
                    ActualColumnIndex = csmAssetListPage.BatteryElementList.IndexOf(csmAssetListPage.BatteryRowCycleCount);
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedColumnIndex, ActualColumnIndex, LabelName + "is not in" + ColumnName);
        }



        [Then(@"battery ""(.*)"" is ""(.*)""")]
        public void ThenBatteryIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "manufacture date":
                    ActualValue = csmAssetListPage.BatteryManufacturerDateValue.Text;
                    break;
                case "serial number":
                    ActualValue = csmAssetListPage.BatterySerialNumberValue.Text;
                    break;
                case "cycle count":
                    ActualValue = csmAssetListPage.BatteryCycleCountValue.Text;
                    break;
                case "temperature":
                    ActualValue = csmAssetListPage.BatteryTemparatureValue.Text;
                    break;
                case "remaining capacity":
                    ActualValue = csmAssetListPage.BatteryRemainingCapacityValue.Text;
                    break;
                case "voltage":
                    ActualValue = csmAssetListPage.BatteryVoltageValue.Text;
                    break;
                case "full charge capacity":
                    ActualValue = csmAssetListPage.BatteryFullChargeCapacityValue.Text;
                    break;
                case "current":
                    ActualValue = csmAssetListPage.BatteryCurrentValue.Text;
                    break;
                case "designed capacity":
                    ActualValue = csmAssetListPage.BatteryDesignedCapacityValue.Text;
                    break;
                case "model number":
                    ActualValue = csmAssetListPage.BatteryModelNumberValue.Text;
                    break;
                case "manufacture name":
                    ActualValue = csmAssetListPage.BatteryManufacturerNameValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " value is not as Expected Value");
        }

        [Then(@"battery ""(.*)"" label is displayed")]
        public void ThenBatteryLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            bool ExpectedValue = true;
            switch (LabelName.ToLower().Trim())
            {
              
                case "manufacture date":
                    ActualValue = csmAssetListPage.BatteryManufacturerDateLabel.GetElementVisibility();
                    break;
                case "serial number":
                    ActualValue = csmAssetListPage.BatterySerialNumberLabel.GetElementVisibility();
                    break;
                case "cycle count":
                    ActualValue = csmAssetListPage.BatteryCycleCountLabel.GetElementVisibility();
                    break;
                case "temperature":
                    ActualValue = csmAssetListPage.BatteryTemparatureLabel.GetElementVisibility();
                    break;
                case "remaining capacity":
                    ActualValue = csmAssetListPage.BatteryRemainingCapacityLabel.GetElementVisibility();
                    break;
                case "voltage":
                    ActualValue = csmAssetListPage.BatteryVoltageLabel.GetElementVisibility();
                    break;
                case "full charge capacity":
                    ActualValue = csmAssetListPage.BatteryFullChargeCapacityLabel.GetElementVisibility();
                    break;
                case "current":
                    ActualValue = csmAssetListPage.BatteryCurrentLabel.GetElementVisibility();
                    break;
                case "designed capacity":
                    ActualValue = csmAssetListPage.BatteryDesignedCapacityLabel.GetElementVisibility();
                    break;
                case "model number":
                    ActualValue = csmAssetListPage.BatteryModelNumberLabel.GetElementVisibility();
                    break;
                case "manufacture name":
                    ActualValue = csmAssetListPage.BatteryManufacturerNameLabel.GetElementVisibility();
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " label is not displayed");
        }

        [When(@"user clicks battery row toggle arrow")]
        public void WhenUserClicksBatteryRowToggleArrow()
        {
            csmAssetListPage.BatteryRowToggelArrow.Click();
            Thread.Sleep(2000);
        }


        [Then(@"APM row ""(.*)"" is ""(.*)""")]
        public void ThenAPMRowIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = csmAssetListPage.APMRowName.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " value is not as Expected Value");
        }

        [Then(@"APM battery row ""(.*)"" is ""(.*)""")]
        public void ThenAPMBatteryRowIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = csmAssetListPage.APMBatteryRowName.Text;
                    break;
                case "manufacture date":
                    ActualValue = csmAssetListPage.APMBatteryRowManufacturerDate.Text;
                    break;
                case "serial number":
                    ActualValue = csmAssetListPage.APMBatteryRowSerialNumber.Text;
                    break;
                case "cycle count":
                    ActualValue = csmAssetListPage.APMBatteryRowCycleCount.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " value is not as Expected Value");
        }

        [Then(@"APM battery row ""(.*)"" is displayed in ""(.*)"" column")]
        public void ThenAPMBatteryRowIsDisplayedInColumn(string LabelName, string ColumnName)
        {
            int ActualColumnIndex = -1;
            int ExpectedColumnIndex = -2;
            switch (ColumnName.ToLower().Trim())
            {
                case "usage":
                    ExpectedColumnIndex = CSMAssetListPage.ExpectedValue.UsageColumnIndex;
                    break;
                default:
                    Assert.Fail(ColumnName + " is invalid");
                    break;
            }

            switch (LabelName.ToLower().Trim())
            {
                case "cycle count":
                    ActualColumnIndex = csmAssetListPage.APMElementList.IndexOf(csmAssetListPage.APMBatteryRowCycleCount);
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedColumnIndex, ActualColumnIndex, LabelName + " is not in " + ColumnName);
        }

        [When(@"user clicks APM battery row toggle arrow")]
        public void WhenUserClicksAPMBatteryRowToggleArrow()
        {
            csmAssetListPage.APMBatteryRowToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"APM battery ""(.*)"" label is displayed")]
        public void ThenAPMBatteryLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            bool ExpectedValue = true;
            switch (LabelName.ToLower().Trim())
            {

                case "manufacture date":
                    ActualValue = csmAssetListPage.APMBatteryManufactureDateLabel.GetElementVisibility();
                    break;
                case "serial number":
                    ActualValue = csmAssetListPage.APMBatterySerialNumberLabel.GetElementVisibility();
                    break;
                case "cycle count":
                    ActualValue = csmAssetListPage.APMBatteryCycleCountLabel.GetElementVisibility();
                    break;
                case "temperature":
                    ActualValue = csmAssetListPage.APMBatteryTemparatureLabel.GetElementVisibility();
                    break;
                case "remaining capacity":
                    ActualValue = csmAssetListPage.APMBatteryRemainingCapacityLabel.GetElementVisibility();
                    break;
                case "voltage":
                    ActualValue = csmAssetListPage.APMBatteryVoltageLabel.GetElementVisibility();
                    break;
                case "full charge capacity":
                    ActualValue = csmAssetListPage.APMBatteryFullChargeCapacityLabel.GetElementVisibility();
                    break;
                case "current":
                    ActualValue = csmAssetListPage.APMBatteryCurrentLabel.GetElementVisibility();
                    break;
                case "battery designed capacity":
                    ActualValue = csmAssetListPage.APMBatteryBatteryDesigedCapacityLabel.GetElementVisibility();
                    break;
                case "model number":
                    ActualValue = csmAssetListPage.APMBatteryModelNumberLabel.GetElementVisibility();
                    break;
                case "manufacture name":
                    ActualValue = csmAssetListPage.APMBatteryManufactureNameLabel.GetElementVisibility();
                    break;
                case "combined battery remaining capacity":
                    ActualValue = csmAssetListPage.APMBatteryCombinedBatteryRemainingCapacityLabel.GetElementVisibility();
                    break;
                case "pic processor firmware version":
                    ActualValue = csmAssetListPage.APMBatteryPICProcessorFirmwareVersionLabel.GetElementVisibility();
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " label is not displayed");
        }   
        

        [Then(@"APM battery ""(.*)"" is ""(.*)""")]
        public void ThenAPMBatteryIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
           
            switch (LabelName.ToLower().Trim())
            {

                case "manufacture date":
                    ActualValue = csmAssetListPage.APMBatteryManufactureDateValue.Text;
                    break;
                case "serial number":
                    ActualValue = csmAssetListPage.APMBatterySerialNumberValue.Text;
                    break;
                case "cycle count":
                    ActualValue = csmAssetListPage.APMBatteryCycleCountValue.Text;
                    break;
                case "temperature":
                    ActualValue = csmAssetListPage.APMBatteryTemparatureValue.Text;
                    break;
                case "remaining capacity":
                    ActualValue = csmAssetListPage.APMBatteryRemainingCapacityValue.Text;
                    break;
                case "voltage":
                    ActualValue = csmAssetListPage.APMBatteryVoltageValue.Text;
                    break;
                case "full charge capacity":
                    ActualValue = csmAssetListPage.APMBatteryFullChargeCapacityValue.Text;
                    break;
                case "current":
                    ActualValue = csmAssetListPage.APMBatteryCurrentValue.Text;
                    break;
                case "battery designed capacity":
                    ActualValue = csmAssetListPage.APMBatteryBatteryDesignedCapacityValue.Text;
                    break;
                case "model number":
                    ActualValue = csmAssetListPage.APMBatteryModelNumberValue.Text;
                    break;
                case "manufacture name":
                    ActualValue = csmAssetListPage.APMBatteryManufactureNameValue.Text;
                    break;
                case "combined battery remaining capacity":
                    ActualValue = csmAssetListPage.APMBatteryCombinedBatteryRemainingCapacityValue.Text;
                    break;
                case "pic processor firmware version":
                    ActualValue = csmAssetListPage.APMBatteryPICProcessorFirmwareVersionValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " value is not as Expected Value");
        }



        [Then(@"NIBP row ""(.*)"" is ""(.*)""")]
        public void ThenNIBPRowIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = csmAssetListPage.NIBPRowName.Text;
                    break;
                case "firmware version":
                    ActualValue = csmAssetListPage.NIBPRowFirmwareVersion.Text;
                    break;
                case "serial number":
                    ActualValue = csmAssetListPage.NIBPRowSerialNumber.Text;
                    break;
                case "cycle count":
                    ActualValue = csmAssetListPage.NIBPRowCycleCount.Text;
                    break;
                case "hardware version":
                    ActualValue = csmAssetListPage.NIBPRowHardwareVersion.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " value is not as Expected Value");
        }

        [Then(@"NIBP row ""(.*)"" is displayed in ""(.*)"" column")]
        public void ThenNIBPRowIsDisplayedInColumn(string LabelName, string ColumnName)
        {
            int ActualColumnIndex = -1;
            int ExpectedColumnIndex = -2;
            switch (ColumnName.ToLower().Trim())
            {
                case "usage":
                    ExpectedColumnIndex = CSMAssetListPage.ExpectedValue.UsageColumnIndex;
                    break;
                default:
                    Assert.Fail(ColumnName + " is invalid");
                    break;
            }

            switch (LabelName.ToLower().Trim())
            {
                case "cycle count":
                    ActualColumnIndex = csmAssetListPage.NIBPElementList.IndexOf(csmAssetListPage.NIBPRowCycleCount);
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedColumnIndex, ActualColumnIndex, LabelName + " is not in " + ColumnName);
        }

        [When(@"user clicks NIBP row sensor toggle arrow")]
        public void WhenUserClicksNIBPRowSensorToggleArrow()
        {
            csmAssetListPage.NIBPRowToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"NIBP ""(.*)"" label is displayed")]
        public void ThenNIBPLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            bool ExpectedValue = true;
            switch (LabelName.ToLower().Trim())
            {

                case "last calibration date":
                    ActualValue = csmAssetListPage.NIBPLastCalibrationDateLabel.GetElementVisibility();
                    break;
                case "nibp module cycle count":
                    ActualValue = csmAssetListPage.NIBPModuleCycleCountLabel.GetElementVisibility();
                    break;
                case "calibration signature":
                    ActualValue = csmAssetListPage.NIBPCalibrationSignatureLabel.GetElementVisibility();
                    break;
                
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " label is not displayed");
        }

        [Then(@"NIBP ""(.*)"" is ""(.*)""")]
        public void ThenNIBPIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {

                case "last calibration date":
                    ActualValue = csmAssetListPage.NIBPLastCalibrationDateValue.Text;
                    break;
                case "nibp module cycle count":
                    ActualValue = csmAssetListPage.NIBPModuleCycleCountValue.Text;
                    break;
                case "calibration signature":
                    ActualValue = csmAssetListPage.NIBPCalibrationSignatureValue.Text;
                    break;

                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " value is not as Expected Value");
        }


        [Then(@"Temperature probe row ""(.*)"" is ""(.*)""")]
        public void ThenTemperatureProbeRowIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = csmAssetListPage.TempProbeRowName.Text;
                    break;
                case "cycle count":
                    ActualValue = csmAssetListPage.TempProbeRowCycleCount.Text;
                    break;
                case "serial number":
                    ActualValue = csmAssetListPage.TempProbeRowSerialNumber.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " value is not as Expected Value");
        }

        [Then(@"Temperature probe row ""(.*)"" is displayed in ""(.*)"" column")]
        public void ThenTemperatureProbeRowIsDisplayedInColumn(string LabelName, string ColumnName)
        {
            int ActualColumnIndex = -1;
            int ExpectedColumnIndex = -2;
            switch (ColumnName.ToLower().Trim())
            {
                case "usage":
                    ExpectedColumnIndex = CSMAssetListPage.ExpectedValue.UsageColumnIndex;
                    break;
                default:
                    Assert.Fail(ColumnName + " is invalid");
                    break;
            }

            switch (LabelName.ToLower().Trim())
            {
                case "cycle count":
                    ActualColumnIndex = csmAssetListPage.TempProbeElementList.IndexOf(csmAssetListPage.TempProbeRowCycleCount);
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedColumnIndex, ActualColumnIndex, LabelName + " is not in " + ColumnName);
        }

        [When(@"user clicks Temperature probe row toggle arrow")]
        public void WhenUserClicksTemperatureProbeRowToggleArrow()
        {
            csmAssetListPage.TempProbeRowToggleArrow.Click();
            Thread.Sleep(2000);
        }


        [Then(@"Temperature probe ""(.*)"" label is displayed")]
        public void ThenTemperatureProbeLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            bool ExpectedValue = true;
            switch (LabelName.ToLower().Trim())
            {

                case "probe type":
                    ActualValue = csmAssetListPage.TempProbeTypeLabel.GetElementVisibility();
                    break;
                case "probe cycle count":
                    ActualValue = csmAssetListPage.TempProbeCycleCountLabel.GetElementVisibility();
                    break;
                case "part number":
                    ActualValue = csmAssetListPage.TempProbePartNumberLabel.GetElementVisibility();
                    break;
                case "lot code":
                    ActualValue = csmAssetListPage.TempProbeLotCodeLabel.GetElementVisibility();
                    break;
                case "lot sequence number":
                    ActualValue = csmAssetListPage.TempProbeLotSequenceNumberLabel.GetElementVisibility();
                    break;
                case "calibration date":
                    ActualValue = csmAssetListPage.TempProbeCalibrationDateLabel.GetElementVisibility();
                    break;
                case "calibration signature":
                    ActualValue = csmAssetListPage.TempProbeCalibrationSignatureLabel.GetElementVisibility();
                    break;
                case "last device serial number":
                    ActualValue = csmAssetListPage.TempProbeLastDeviceSerialNumberLabel.GetElementVisibility();
                    break;
                case "number of times probe changed devices":
                    ActualValue = csmAssetListPage.TempProbeNumberOfTimesProbeChangedLabel.GetElementVisibility();
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " label is not displayed");
        }


        [Then(@"Temperature probe ""(.*)"" is ""(.*)""")]
        public void ThenTemperatureProbeIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {

                case "probe type":
                    ActualValue = csmAssetListPage.TempProbeTypeValue.Text;
                    break;
                case "probe cycle count":
                    ActualValue = csmAssetListPage.TempProbeCycleCountValue.Text;
                    break;
                case "part number":
                    ActualValue = csmAssetListPage.TempProbePartNumberValue.Text;
                    break;
                case "lot code":
                    ActualValue = csmAssetListPage.TempProbeLotCodeValue.Text;
                    break;
                case "lot sequence number":
                    ActualValue = csmAssetListPage.TempProbeLotSequenceNumberValue.Text;
                    break;
                case "calibration date":
                    ActualValue = csmAssetListPage.TempProbeCalibrationDateValue.Text;
                    break;
                case "calibration signature":
                    ActualValue = csmAssetListPage.TempProbeCalibrationSignatureValue.Text;
                    break;
                case "last device serial number":
                    ActualValue = csmAssetListPage.TempProbeLastDeviceSerialNumberValue.Text;
                    break;
                case "number of times probe changed devices":
                    ActualValue = csmAssetListPage.TempProbeNumberOfTimesProbeChangedValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }
            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " value is not as Expected Value");
        }


        [Then(@"SureTemp ""(.*)"" is ""(.*)""")]
        public void ThenSureTempIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = csmAssetListPage.SureTempName.Text;
                    break;
                case "firmware version":
                    ActualValue = csmAssetListPage.SureTempFirmwareVersion.Text;
                    break;
                case "serial number":
                    ActualValue = csmAssetListPage.SureTempSerialNumber.Text;
                    break;
                case "cycle count":
                    ActualValue = csmAssetListPage.SureTempCycleCount.Text;
                    break;
                case "hardware version":
                    ActualValue = csmAssetListPage.SureTempHardwareVersion.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " value is not as Expected Value");
        }


        [Then(@"SureTemp ""(.*)"" is displayed in ""(.*)"" column")]
        public void ThenSureTempIsDisplayedInColumn(string LabelName, string ColumnName)
        {
            int ActualColumnIndex = -1;
            int ExpectedColumnIndex = -2;
            switch (ColumnName.ToLower().Trim())
            {
                case "usage":
                    ExpectedColumnIndex = CSMAssetListPage.ExpectedValue.UsageColumnIndex;
                    break;
                default:
                    Assert.Fail(ColumnName + " is invalid");
                    break;
            }

            switch (LabelName.ToLower().Trim())
            {
                case "cycle count":
                    ActualColumnIndex = csmAssetListPage.SureTempElementList.IndexOf(csmAssetListPage.SureTempCycleCount);
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedColumnIndex, ActualColumnIndex, LabelName + " is not in " + ColumnName);
        }



        [Then(@"SpO2 Masimo ""(.*)"" is ""(.*)""")]
        public void ThenSpOMasimoIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = csmAssetListPage.Spo2MasimoName.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " value is not as Expected Value");
        }

        [When(@"user clicks Masimo MX-7 toggle arrow")]
        public void WhenUserClicksToggleArrow(string p0)
        {
            csmAssetListPage.MasimoToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Masimo ""(.*)"" is ""(.*)""")]
        public void ThenMasimoIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "firmware version":
                    ActualValue = csmAssetListPage.MasimoFirmwareVersion.Text;
                    break;

                case "hardware version":
                    ActualValue = csmAssetListPage.MasimoHardwareVersion.Text;
                    break;
                case "serial number":
                    ActualValue = csmAssetListPage.MasimoSerialNummber.Text;
                    break;
                case "model number":
                    ActualValue = csmAssetListPage.MasimoModelNumberValue.Text;
                    break;
                case "module type":
                    ActualValue = csmAssetListPage.MasimoModuleTypeValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " value is not as Expected Value");
        }

        [Then(@"Masimo ""(.*)"" label is displayed")]
        public void ThenMasimoLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            bool ExpectedValue = true;

            switch (LabelName.ToLower().Trim())
            {
                case "model number":
                    ActualValue = csmAssetListPage.MasimoModelNumberLabel.GetElementVisibility();
                    break;
                case "module type":
                    ActualValue = csmAssetListPage.MasimoModuleTypeLabel.GetElementVisibility();
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " label is not displayed");
        }

        [Then(@"SpO2 Nellcor ""(.*)"" is ""(.*)""")]
        public void ThenSpONellcorIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = csmAssetListPage.Spo2NellcorName.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " value is not as Expected Value");
        }

        [When(@"user clicks Nellcor toggle arrow")]
        public void WhenUserClicksNellcorToggleArrow()
        {
            csmAssetListPage.NellcorToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Nellcor ""(.*)"" is ""(.*)""")]
        public void ThenNellcorIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "firmware version":
                    ActualValue = csmAssetListPage.NellcorFirmwareVersion.Text;
                    break;

                case "hardware version":
                    ActualValue = csmAssetListPage.NellcorHardwareVersion.Text;
                    break;
                case "serial number":
                    ActualValue = csmAssetListPage.NellcorSerialNummber.Text;
                    break;
                case "model number":
                    ActualValue = csmAssetListPage.NellcorModelNumberValue.Text;
                    break;
                case "module type":
                    ActualValue = csmAssetListPage.NellcorModuleTypeValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " value is not as Expected Value");
        }

        [Then(@"Nellcor ""(.*)"" label is displayed")]
        public void ThenNellcorLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            bool ExpectedValue = true;

            switch (LabelName.ToLower().Trim())
            {
                case "model number":
                    ActualValue = csmAssetListPage.NellcorModelNumberLabel.GetElementVisibility();
                    break;
                case "module type":
                    ActualValue = csmAssetListPage.NellcorModuleTypeLabel.GetElementVisibility();
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " label is not displayed");
        }


        [Then(@"SpO2 Nonin ""(.*)"" is ""(.*)""")]
        public void ThenSpONoninIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = csmAssetListPage.Spo2NoninName.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " value is not as Expected Value");
        }

        [When(@"user clicks Nonin toggle arrow")]
        public void WhenUserClicksNoninToggleArrow()
        {
            csmAssetListPage.NoninToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Nonin ""(.*)"" is ""(.*)""")]
        public void ThenNoninIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "firmware version":
                    ActualValue = csmAssetListPage.NoninFirmwareVersion.Text;
                    break;

                case "hardware version":
                    ActualValue = csmAssetListPage.NoninHardwareVersion.Text;
                    break;
                case "serial number":
                    ActualValue = csmAssetListPage.NoninSerialNummber.Text;
                    break;
                case "model number":
                    ActualValue = csmAssetListPage.NoninModelNumberValue.Text;
                    break;
                case "module type":
                    ActualValue = csmAssetListPage.NoninModuleTypeValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " value is not as Expected Value");
        }

        [Then(@"Nonin ""(.*)"" label is displayed")]
        public void ThenNoninLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            bool ExpectedValue = true;

            switch (LabelName.ToLower().Trim())
            {
                case "model number":
                    ActualValue = csmAssetListPage.NoninModelNumberLabel.GetElementVisibility();
                    break;
                case "module type":
                    ActualValue = csmAssetListPage.NoninModuleTypeLabel.GetElementVisibility();
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " label is not displayed");
        }


        [Then(@"Radio Newmar row ""(.*)"" is ""(.*)""")]
        public void ThenRadioNewmarRowIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = csmAssetListPage.RadioNewmarRowName.Text;
                    break;
                case "firmware version":
                    ActualValue = csmAssetListPage.RadioNewmarRowFirmwareVersion.Text;
                    break;
                case "serial number":
                    ActualValue = csmAssetListPage.RadioNewmarRowSerialNumber.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " value is not as Expected Value");
        }

        [When(@"user clicks Radio-Newmar toggle arrow")]
        public void WhenUserClicksRadio_NewmarToggleArrow()
        {
            csmAssetListPage.RadioNewmarRowToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Radio Newmar ""(.*)"" label is displayed")]
        public void ThenRadioNewmarLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            bool ExpectedValue = true;

            switch (LabelName.ToLower().Trim())
            {
                case "access point mac address":
                    ActualValue = csmAssetListPage.RadioNewmarAPMacAddressLabel.GetElementVisibility();
                    break;
                case "channel":
                    ActualValue = csmAssetListPage.RadioNewmarChannelLabel.GetElementVisibility();
                    break;
                case "connection mode":
                    ActualValue = csmAssetListPage.RadioNewmarConnectionModeLabel.GetElementVisibility();
                    break;
                case "ssid":
                    ActualValue = csmAssetListPage.RadioNewmarSSIDLabel.GetElementVisibility();
                    break;
                case "rssi":
                    ActualValue = csmAssetListPage.RadioNewmarRSSILabel.GetElementVisibility();
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;

            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " label is not displayed");
        }

        [Then(@"Radio Newmar ""(.*)"" is ""(.*)""")]
        public void ThenRadioNewmarIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "access point mac address":
                    ActualValue = csmAssetListPage.RadioNewmarAPMacAddressValue.Text;
                    break;
                case "channel":
                    ActualValue = csmAssetListPage.RadioNewmarChannelValue.Text;
                    break;
                case "connection mode":
                    ActualValue = csmAssetListPage.RadioNewmarConnectionModeValue.Text;
                    break;
                case "ssid":
                    ActualValue = csmAssetListPage.RadioNewmarSSIDValue.Text;
                    break;
                case "rssi":
                    ActualValue = csmAssetListPage.RadioNewmarRSSIValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;

            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " value is not as Expected Value");
        }


        [Then(@"Summary CSM image is displayed")]
        public void ThenSummaryCSMImageIsDisplayed()
        {
            Assert.IsTrue(csmAssetListPage.SummaryCSMImage.GetElementVisibility(), "Image is not displayed");
                
        }

        [Then(@"Summary ""(.*)"" label is displayed")]
        public void ThenSummaryLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            bool ExpectedValue = true;
            switch (LabelName.ToLower().Trim())
            {
                case "ip address":
                    ActualValue = csmAssetListPage.SummaryIPAddressLabel.GetElementVisibility();
                    break;
                case "radio ip address":
                    ActualValue = csmAssetListPage.SummaryRadioIPAddressLabel.GetElementVisibility();
                    break;
                case "ethernet mac address":
                    ActualValue = csmAssetListPage.SummaryEthernetMacAddressLabel.GetElementVisibility();
                    break;
                case "model":
                    ActualValue = csmAssetListPage.SummaryModelLabel.GetElementVisibility();
                    break;
                case "asset name":
                    ActualValue = csmAssetListPage.SummaryAssetNameLabel.GetElementVisibility();
                    break;
                case "serial number":
                    ActualValue = csmAssetListPage.SummarySerialNumberLabel.GetElementVisibility();
                    break;
                case "facility":
                    ActualValue = csmAssetListPage.SummaryFacilityLabel.GetElementVisibility();
                    break;
                case "location":
                    ActualValue = csmAssetListPage.SummaryLocationLabel.GetElementVisibility();
                    break;
                case "room/bed":
                    ActualValue = csmAssetListPage.SummaryRoomBedLabel.GetElementVisibility();
                    break;
                case "asset tag":
                    ActualValue = csmAssetListPage.SummaryAssetTagLabel.GetElementVisibility();
                    break;
                case "connection status":
                    ActualValue = csmAssetListPage.SummaryConnectionStatusLabel.GetElementVisibility();
                    break;
                case "last vital sent":
                    ActualValue = csmAssetListPage.SummaryLastVitalSentLabel.GetElementVisibility();
                    break;

                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }

            Assert.AreEqual(ActualValue, ExpectedValue, LabelName + " is not displayed");
        }

        [Then(@"Summary ""(.*)"" is ""(.*)""")]
        public void ThenSummaryIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "ip address":
                    ActualValue = csmAssetListPage.SummaryIPAddressValue.Text;
                    break;
                case "radio ip address":
                    ActualValue = csmAssetListPage.SummaryRadioIpAddressValue.Text;
                    break;
                case "ethernet mac address":
                    ActualValue = csmAssetListPage.SummaryEthernetMacAddressValue.Text;
                    break;
                case "model":
                    ActualValue = csmAssetListPage.SummaryModelValue.Text;
                    break;
                case "asset name":
                    ActualValue = csmAssetListPage.SummaryAssetNameValue.Text;
                    break;
                case "serial number":
                    ActualValue = csmAssetListPage.SummarySerialNumberValue.Text;
                    break;
                case "facility":
                    ActualValue = csmAssetListPage.SummaryFacilityValue.Text;
                    break;
                case "location":
                    ActualValue = csmAssetListPage.SummaryLocationValue.Text;
                    break;
                
                case "asset tag":
                    ActualValue = csmAssetListPage.SummaryAssetTagValue.Text;
                    break;
                case "connection status":
                    ActualValue = csmAssetListPage.SummaryConnectionStatusValue.Text;
                    break;
                case "last vital sent":
                    ActualValue = csmAssetListPage.SummaryLastVitalSentValue.Text;
                    break;
                case "room/bed":
                    ActualValue = csmAssetListPage.SummaryRoomBedValue.Text;
                    break;

                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " value is not as Expected Value");
        }

        [Then(@"Summary ""(.*)"" is blank")]
        public void ThenSummaryIsBlank(string LabelName)
        {
            switch(LabelName.Trim().ToLower())
            {
                case "room/bed":
                    Assert.IsEmpty(csmAssetListPage.SummaryRoomBedValue.Text, LabelName+" is not blank");
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }
        }
    }
}
