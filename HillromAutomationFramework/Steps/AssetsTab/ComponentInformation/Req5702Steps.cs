using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.Component_Information;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.AssetsTab.ComponentInformation
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5702")]
    class Req5702Steps
    {
        private readonly LoginPage _loginPage = new LoginPage();
        private readonly LandingPage _landingPage = new LandingPage();
        private readonly CSMAssetListPage _csmAssetListPage = new CSMAssetListPage();
        private readonly MainPage _mainPage = new MainPage();

        readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        

        //Context Injection
        private ScenarioContext _scenarioContext;
        public Req5702Steps(ScenarioContext scnenarioContext)
        {
            _scenarioContext = scnenarioContext;
            _loginPage = new LoginPage();
            _landingPage = new LandingPage();
            _csmAssetListPage = new CSMAssetListPage();
            _mainPage = new MainPage();
        }


        [Given(@"user is on Asset List page with more than one CSM")]
        public void GivenUserIsOnAssetListPageWithMoreThanOneCSM()
        {
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CSMDeviceName);
            _csmAssetListPage.GetDeviceCount().Should().BeGreaterThan(1);
        }

        [When(@"user clicks any CSM")]
        public void WhenUserClicksAnyCSM()
        {
            Thread.Sleep(2000);
            _mainPage.SearchSerialNumberAndClick("100010000000");
        }

        [Then(@"Asset Details landing page is displayed")]
        public void ThenAssetDetailsLandingPageIsDisplayed()
        {
            _csmAssetListPage.CSMDetailsPage.GetElementVisibility().Should().BeTrue( "Asset Details Landing Page is not displayed");
        }

        [Then(@"Asset Detail summary subsection with Edit button is displayed")]
        public void ThenAssetDetailSummarySubsectionWithEditButtonIsDisplayed()
        {
            _csmAssetListPage.CSMDetailsSummary.GetElementVisibility().Should().BeTrue( "CVSM details summary subsection is not displayed");
            _csmAssetListPage.EditButton.GetElementVisibility().Should().BeTrue( "Edit Button is not displayed");
        }

        [Then(@"Preventive Maintenance tab is displayed")]
        public void ThenPreventiveMaintenanceTabIsDisplayed()
        {
            _csmAssetListPage.PreventiveMaintenanceTab.GetElementVisibility().Should().BeTrue( "Preventive Mainetenance Tab is not displayed");
        }

        [Then(@"Component Information tab is displayed")]
        public void ThenComponentInformationTabIsDisplayed()
        {
            _csmAssetListPage.ComponentInformationTab.GetElementVisibility().Should().BeTrue( "Component information tab is not displayed");
        }

        [Then(@"Logs tab is displayed")]
        public void ThenLogsTabIsDisplayed()
        {
            _csmAssetListPage.LogsTab.GetElementVisibility().Should().BeTrue( "Logs tab is not displayed");
        }

        [Then(@"Asset Detail subsection is displayed")]
        public void ThenAssetDetailSubsectionIsDisplayed()
        {
            _csmAssetListPage.AssetDetailsSubsection.GetElementVisibility().Should().BeTrue( "Asset Details Subsection is not displayed");
        }


        [Given(@"user is on Component details page for CSM Serial number ""(.*)""")]
        public void GivenUserIsOnComponentDetailsPageForCSMSerialNumber(string SerialNumber)
        {
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CSMDeviceName);
            
            _csmAssetListPage.GetDeviceCount().Should().BeGreaterThan(1);
            Thread.Sleep(2000);
            
            _mainPage.SearchSerialNumberAndClick(SerialNumber);
            _csmAssetListPage.ComponentInformationTab.Click();
            Thread.Sleep(2000);
        }

        [Then(@"""(.*)"" is ""(.*)""")]
        public void ThenIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _csmAssetListPage.Name.Text;
                    break;
                case "serial number":
                    ActualValue = _csmAssetListPage.SerialNumber.Text;
                    break;
                case "device hours on":
                    ActualValue = _csmAssetListPage.TotalRunTimeValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + "value is not as Expected Value");;
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
                    ActualColumnIndex = _csmAssetListPage.ConnexElementList.IndexOf(_csmAssetListPage.UsageColumn);
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualColumnIndex.Should().Be(ExpectedColumnIndex, LabelName + " is not in " + ColumnName);

        }

        [Then(@"battery row ""(.*)"" is ""(.*)""")]
        public void ThenBatteryRowIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "manufacture date":
                    ActualValue = _csmAssetListPage.BatteryRowManufactureDate.Text;
                    break;
                case "serial number":
                    ActualValue = _csmAssetListPage.BatteryRowSerialNumber.Text;
                    break;
                case "cycle count":
                    ActualValue = _csmAssetListPage.BatteryRowCycleCount.Text;
                    break;
                case "name":
                    ActualValue = _csmAssetListPage.BatteryRowName.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + "value is not as Expected Value");;
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
                    ActualColumnIndex = _csmAssetListPage.BatteryElementList.IndexOf(_csmAssetListPage.BatteryRowCycleCount);
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualColumnIndex.Should().Be(ExpectedColumnIndex, LabelName + "is not in" + ColumnName);
        }



        [Then(@"battery ""(.*)"" is ""(.*)""")]
        public void ThenBatteryIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "manufacture date":
                    ActualValue = _csmAssetListPage.BatteryManufacturerDateValue.Text;
                    break;
                case "serial number":
                    ActualValue = _csmAssetListPage.BatterySerialNumberValue.Text;
                    break;
                case "cycle count":
                    ActualValue = _csmAssetListPage.BatteryCycleCountValue.Text;
                    break;
                case "temperature":
                    ActualValue = _csmAssetListPage.BatteryTemparatureValue.Text;
                    break;
                case "remaining capacity":
                    ActualValue = _csmAssetListPage.BatteryRemainingCapacityValue.Text;
                    break;
                case "voltage":
                    ActualValue = _csmAssetListPage.BatteryVoltageValue.Text;
                    break;
                case "full charge capacity":
                    ActualValue = _csmAssetListPage.BatteryFullChargeCapacityValue.Text;
                    break;
                case "current":
                    ActualValue = _csmAssetListPage.BatteryCurrentValue.Text;
                    break;
                case "designed capacity":
                    ActualValue = _csmAssetListPage.BatteryDesignedCapacityValue.Text;
                    break;
                case "model number":
                    ActualValue = _csmAssetListPage.BatteryModelNumberValue.Text;
                    break;
                case "manufacture name":
                    ActualValue = _csmAssetListPage.BatteryManufacturerNameValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + "value is not as Expected Value");;
        }

        [Then(@"battery ""(.*)"" label is displayed")]
        public void ThenBatteryLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            switch (LabelName.ToLower().Trim())
            {
              
                case "manufacture date":
                    ActualValue = _csmAssetListPage.BatteryManufacturerDateLabel.GetElementVisibility();
                    break;
                case "serial number":
                    ActualValue = _csmAssetListPage.BatterySerialNumberLabel.GetElementVisibility();
                    break;
                case "cycle count":
                    ActualValue = _csmAssetListPage.BatteryCycleCountLabel.GetElementVisibility();
                    break;
                case "temperature":
                    ActualValue = _csmAssetListPage.BatteryTemparatureLabel.GetElementVisibility();
                    break;
                case "remaining capacity":
                    ActualValue = _csmAssetListPage.BatteryRemainingCapacityLabel.GetElementVisibility();
                    break;
                case "voltage":
                    ActualValue = _csmAssetListPage.BatteryVoltageLabel.GetElementVisibility();
                    break;
                case "full charge capacity":
                    ActualValue = _csmAssetListPage.BatteryFullChargeCapacityLabel.GetElementVisibility();
                    break;
                case "current":
                    ActualValue = _csmAssetListPage.BatteryCurrentLabel.GetElementVisibility();
                    break;
                case "designed capacity":
                    ActualValue = _csmAssetListPage.BatteryDesignedCapacityLabel.GetElementVisibility();
                    break;
                case "model number":
                    ActualValue = _csmAssetListPage.BatteryModelNumberLabel.GetElementVisibility();
                    break;
                case "manufacture name":
                    ActualValue = _csmAssetListPage.BatteryManufacturerNameLabel.GetElementVisibility();
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeTrue(LabelName+"Label is not displayed");
        }

        [When(@"user clicks battery row toggle arrow")]
        public void WhenUserClicksBatteryRowToggleArrow()
        {
            _csmAssetListPage.BatteryRowToggelArrow.Click();
            Thread.Sleep(2000);
        }


        [Then(@"APM row ""(.*)"" is ""(.*)""")]
        public void ThenAPMRowIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _csmAssetListPage.APMRowName.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + "value is not as Expected Value");;
        }

        [Then(@"APM battery row ""(.*)"" is ""(.*)""")]
        public void ThenAPMBatteryRowIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _csmAssetListPage.APMBatteryRowName.Text;
                    break;
                case "manufacture date":
                    ActualValue = _csmAssetListPage.APMBatteryRowManufacturerDate.Text;
                    break;
                case "serial number":
                    ActualValue = _csmAssetListPage.APMBatteryRowSerialNumber.Text;
                    break;
                case "cycle count":
                    ActualValue = _csmAssetListPage.APMBatteryRowCycleCount.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + "value is not as Expected Value");;
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
                    ActualColumnIndex = _csmAssetListPage.APMElementList.IndexOf(_csmAssetListPage.APMBatteryRowCycleCount);
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualColumnIndex.Should().Be(ExpectedColumnIndex, LabelName + " is not in " + ColumnName);
        }

        [When(@"user clicks APM battery row toggle arrow")]
        public void WhenUserClicksAPMBatteryRowToggleArrow()
        {
            _csmAssetListPage.APMBatteryRowToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"APM battery ""(.*)"" label is displayed")]
        public void ThenAPMBatteryLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            switch (LabelName.ToLower().Trim())
            {

                case "manufacture date":
                    ActualValue = _csmAssetListPage.APMBatteryManufactureDateLabel.GetElementVisibility();
                    break;
                case "serial number":
                    ActualValue = _csmAssetListPage.APMBatterySerialNumberLabel.GetElementVisibility();
                    break;
                case "cycle count":
                    ActualValue = _csmAssetListPage.APMBatteryCycleCountLabel.GetElementVisibility();
                    break;
                case "temperature":
                    ActualValue = _csmAssetListPage.APMBatteryTemparatureLabel.GetElementVisibility();
                    break;
                case "remaining capacity":
                    ActualValue = _csmAssetListPage.APMBatteryRemainingCapacityLabel.GetElementVisibility();
                    break;
                case "voltage":
                    ActualValue = _csmAssetListPage.APMBatteryVoltageLabel.GetElementVisibility();
                    break;
                case "full charge capacity":
                    ActualValue = _csmAssetListPage.APMBatteryFullChargeCapacityLabel.GetElementVisibility();
                    break;
                case "current":
                    ActualValue = _csmAssetListPage.APMBatteryCurrentLabel.GetElementVisibility();
                    break;
                case "battery designed capacity":
                    ActualValue = _csmAssetListPage.APMBatteryBatteryDesigedCapacityLabel.GetElementVisibility();
                    break;
                case "model number":
                    ActualValue = _csmAssetListPage.APMBatteryModelNumberLabel.GetElementVisibility();
                    break;
                case "manufacture name":
                    ActualValue = _csmAssetListPage.APMBatteryManufactureNameLabel.GetElementVisibility();
                    break;
                case "combined battery remaining capacity":
                    ActualValue = _csmAssetListPage.APMBatteryCombinedBatteryRemainingCapacityLabel.GetElementVisibility();
                    break;
                case "pic processor firmware version":
                    ActualValue = _csmAssetListPage.APMBatteryPICProcessorFirmwareVersionLabel.GetElementVisibility();
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeTrue(LabelName+"Label is not displayed");
        }   
        

        [Then(@"APM battery ""(.*)"" is ""(.*)""")]
        public void ThenAPMBatteryIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
           
            switch (LabelName.ToLower().Trim())
            {

                case "manufacture date":
                    ActualValue = _csmAssetListPage.APMBatteryManufactureDateValue.Text;
                    break;
                case "serial number":
                    ActualValue = _csmAssetListPage.APMBatterySerialNumberValue.Text;
                    break;
                case "cycle count":
                    ActualValue = _csmAssetListPage.APMBatteryCycleCountValue.Text;
                    break;
                case "temperature":
                    ActualValue = _csmAssetListPage.APMBatteryTemparatureValue.Text;
                    break;
                case "remaining capacity":
                    ActualValue = _csmAssetListPage.APMBatteryRemainingCapacityValue.Text;
                    break;
                case "voltage":
                    ActualValue = _csmAssetListPage.APMBatteryVoltageValue.Text;
                    break;
                case "full charge capacity":
                    ActualValue = _csmAssetListPage.APMBatteryFullChargeCapacityValue.Text;
                    break;
                case "current":
                    ActualValue = _csmAssetListPage.APMBatteryCurrentValue.Text;
                    break;
                case "battery designed capacity":
                    ActualValue = _csmAssetListPage.APMBatteryBatteryDesignedCapacityValue.Text;
                    break;
                case "model number":
                    ActualValue = _csmAssetListPage.APMBatteryModelNumberValue.Text;
                    break;
                case "manufacture name":
                    ActualValue = _csmAssetListPage.APMBatteryManufactureNameValue.Text;
                    break;
                case "combined battery remaining capacity":
                    ActualValue = _csmAssetListPage.APMBatteryCombinedBatteryRemainingCapacityValue.Text;
                    break;
                case "pic processor firmware version":
                    ActualValue = _csmAssetListPage.APMBatteryPICProcessorFirmwareVersionValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + "value is not as Expected Value");;
        }



        [Then(@"NIBP row ""(.*)"" is ""(.*)""")]
        public void ThenNIBPRowIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _csmAssetListPage.NIBPRowName.Text;
                    break;
                case "firmware version":
                    ActualValue = _csmAssetListPage.NIBPRowFirmwareVersion.Text;
                    break;
                case "serial number":
                    ActualValue = _csmAssetListPage.NIBPRowSerialNumber.Text;
                    break;
                case "cycle count":
                    ActualValue = _csmAssetListPage.NIBPRowCycleCount.Text;
                    break;
                case "hardware version":
                    ActualValue = _csmAssetListPage.NIBPRowHardwareVersion.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + "value is not as Expected Value");;
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
                    ActualColumnIndex = _csmAssetListPage.NIBPElementList.IndexOf(_csmAssetListPage.NIBPRowCycleCount);
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualColumnIndex.Should().Be(ExpectedColumnIndex, LabelName + " is not in " + ColumnName);
        }

        [When(@"user clicks NIBP row sensor toggle arrow")]
        public void WhenUserClicksNIBPRowSensorToggleArrow()
        {
            _csmAssetListPage.NIBPRowToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"NIBP ""(.*)"" label is displayed")]
        public void ThenNIBPLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            switch (LabelName.ToLower().Trim())
            {

                case "last calibration date":
                    ActualValue = _csmAssetListPage.NIBPLastCalibrationDateLabel.GetElementVisibility();
                    break;
                case "nibp module cycle count":
                    ActualValue = _csmAssetListPage.NIBPModuleCycleCountLabel.GetElementVisibility();
                    break;
                case "calibration signature":
                    ActualValue = _csmAssetListPage.NIBPCalibrationSignatureLabel.GetElementVisibility();
                    break;
                
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeTrue(LabelName+"Label is not displayed");
        }

        [Then(@"NIBP ""(.*)"" is ""(.*)""")]
        public void ThenNIBPIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {

                case "last calibration date":
                    ActualValue = _csmAssetListPage.NIBPLastCalibrationDateValue.Text;
                    break;
                case "nibp module cycle count":
                    ActualValue = _csmAssetListPage.NIBPModuleCycleCountValue.Text;
                    break;
                case "calibration signature":
                    ActualValue = _csmAssetListPage.NIBPCalibrationSignatureValue.Text;
                    break;

                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + "value is not as Expected Value");;
        }


        [Then(@"Temperature probe row ""(.*)"" is ""(.*)""")]
        public void ThenTemperatureProbeRowIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _csmAssetListPage.TempProbeRowName.Text;
                    break;
                case "cycle count":
                    ActualValue = _csmAssetListPage.TempProbeRowCycleCount.Text;
                    ActualValue = GetMethods.CleanString(ActualValue);
                    break;
                case "serial number":
                    ActualValue = _csmAssetListPage.TempProbeRowSerialNumber.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + "value is not as Expected Value");;
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
                    ActualColumnIndex = _csmAssetListPage.TempProbeElementList.IndexOf(_csmAssetListPage.TempProbeRowCycleCount);
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualColumnIndex.Should().Be(ExpectedColumnIndex, LabelName + " is not in " + ColumnName);
        }

        [When(@"user clicks Temperature probe row toggle arrow")]
        public void WhenUserClicksTemperatureProbeRowToggleArrow()
        {
            _csmAssetListPage.TempProbeRowToggleArrow.Click();
            Thread.Sleep(2000);
        }


        [Then(@"Temperature probe ""(.*)"" label is displayed")]
        public void ThenTemperatureProbeLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            switch (LabelName.ToLower().Trim())
            {

                case "probe type":
                    ActualValue = _csmAssetListPage.TempProbeTypeLabel.GetElementVisibility();
                    break;
                case "probe cycle count":
                    ActualValue = _csmAssetListPage.TempProbeCycleCountLabel.GetElementVisibility();
                    break;
                case "part number":
                    ActualValue = _csmAssetListPage.TempProbePartNumberLabel.GetElementVisibility();
                    break;
                case "lot code":
                    ActualValue = _csmAssetListPage.TempProbeLotCodeLabel.GetElementVisibility();
                    break;
                case "lot sequence number":
                    ActualValue = _csmAssetListPage.TempProbeLotSequenceNumberLabel.GetElementVisibility();
                    break;
                case "calibration date":
                    ActualValue = _csmAssetListPage.TempProbeCalibrationDateLabel.GetElementVisibility();
                    break;
                case "calibration signature":
                    ActualValue = _csmAssetListPage.TempProbeCalibrationSignatureLabel.GetElementVisibility();
                    break;
                case "last device serial number":
                    ActualValue = _csmAssetListPage.TempProbeLastDeviceSerialNumberLabel.GetElementVisibility();
                    break;
                case "number of times probe changed devices":
                    ActualValue = _csmAssetListPage.TempProbeNumberOfTimesProbeChangedLabel.GetElementVisibility();
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeTrue(LabelName+"Label is not displayed");
        }


        [Then(@"Temperature probe ""(.*)"" is ""(.*)""")]
        public void ThenTemperatureProbeIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {

                case "probe type":
                    ActualValue = _csmAssetListPage.TempProbeTypeValue.Text;
                    break;
                case "probe cycle count":
                    ActualValue = _csmAssetListPage.TempProbeCycleCountValue.Text;
                    break;
                case "part number":
                    ActualValue = _csmAssetListPage.TempProbePartNumberValue.Text;
                    break;
                case "lot code":
                    ActualValue = _csmAssetListPage.TempProbeLotCodeValue.Text;
                    break;
                case "lot sequence number":
                    ActualValue = _csmAssetListPage.TempProbeLotSequenceNumberValue.Text;
                    break;
                case "calibration date":
                    ActualValue = _csmAssetListPage.TempProbeCalibrationDateValue.Text;
                    break;
                case "calibration signature":
                    ActualValue = _csmAssetListPage.TempProbeCalibrationSignatureValue.Text;
                    break;
                case "last device serial number":
                    ActualValue = _csmAssetListPage.TempProbeLastDeviceSerialNumberValue.Text;
                    break;
                case "number of times probe changed devices":
                    ActualValue = _csmAssetListPage.TempProbeNumberOfTimesProbeChangedValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }
            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + "value is not as Expected Value");;
        }


        [Then(@"SureTemp ""(.*)"" is ""(.*)""")]
        public void ThenSureTempIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _csmAssetListPage.SureTempName.Text;
                    break;
                case "firmware version":
                    ActualValue = _csmAssetListPage.SureTempFirmwareVersion.Text;
                    break;
                case "serial number":
                    ActualValue = _csmAssetListPage.SureTempSerialNumber.Text;
                    break;
                case "cycle count":
                    ActualValue = _csmAssetListPage.SureTempCycleCount.Text;
                    break;
                case "hardware version":
                    ActualValue = _csmAssetListPage.SureTempHardwareVersion.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + "value is not as Expected Value");;
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
                    ActualColumnIndex = _csmAssetListPage.SureTempElementList.IndexOf(_csmAssetListPage.SureTempCycleCount);
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualColumnIndex.Should().Be(ExpectedColumnIndex, LabelName + " is not in " + ColumnName);
        }



        [Then(@"SpO2 Masimo ""(.*)"" is ""(.*)""")]
        public void ThenSpOMasimoIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _csmAssetListPage.Spo2MasimoName.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + "value is not as Expected Value");;
        }

        [When(@"user clicks Masimo MX-7 toggle arrow")]
        public void WhenUserClicksToggleArrow()
        {
            _csmAssetListPage.MasimoToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Masimo ""(.*)"" is ""(.*)""")]
        public void ThenMasimoIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "firmware version":
                    ActualValue = _csmAssetListPage.MasimoFirmwareVersion.Text;
                    break;

                case "hardware version":
                    ActualValue = _csmAssetListPage.MasimoHardwareVersion.Text;
                    break;
                case "serial number":
                    ActualValue = _csmAssetListPage.MasimoSerialNummber.Text;
                    break;
                case "model number":
                    ActualValue = _csmAssetListPage.MasimoModelNumberValue.Text;
                    break;
                case "module type":
                    ActualValue = _csmAssetListPage.MasimoModuleTypeValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + "value is not as Expected Value");;
        }

        [Then(@"Masimo ""(.*)"" label is displayed")]
        public void ThenMasimoLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;

            switch (LabelName.ToLower().Trim())
            {
                case "model number":
                    ActualValue = _csmAssetListPage.MasimoModelNumberLabel.GetElementVisibility();
                    break;
                case "module type":
                    ActualValue = _csmAssetListPage.MasimoModuleTypeLabel.GetElementVisibility();
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeTrue(LabelName+"Label is not displayed");
        }

        [Then(@"SpO2 Nellcor ""(.*)"" is ""(.*)""")]
        public void ThenSpONellcorIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _csmAssetListPage.Spo2NellcorName.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + "value is not as Expected Value");;
        }

        [When(@"user clicks Nellcor toggle arrow")]
        public void WhenUserClicksNellcorToggleArrow()
        {
            _csmAssetListPage.NellcorToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Nellcor ""(.*)"" is ""(.*)""")]
        public void ThenNellcorIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "firmware version":
                    ActualValue = _csmAssetListPage.NellcorFirmwareVersion.Text;
                    break;

                case "hardware version":
                    ActualValue = _csmAssetListPage.NellcorHardwareVersion.Text;
                    break;
                case "serial number":
                    ActualValue = _csmAssetListPage.NellcorSerialNummber.Text;
                    break;
                case "model number":
                    ActualValue = _csmAssetListPage.NellcorModelNumberValue.Text;
                    break;
                case "module type":
                    ActualValue = _csmAssetListPage.NellcorModuleTypeValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + "value is not as Expected Value");;
        }

        [Then(@"Nellcor ""(.*)"" label is displayed")]
        public void ThenNellcorLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;

            switch (LabelName.ToLower().Trim())
            {
                case "model number":
                    ActualValue = _csmAssetListPage.NellcorModelNumberLabel.GetElementVisibility();
                    break;
                case "module type":
                    ActualValue = _csmAssetListPage.NellcorModuleTypeLabel.GetElementVisibility();
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeTrue(LabelName+"Label is not displayed");
        }


        [Then(@"SpO2 Nonin ""(.*)"" is ""(.*)""")]
        public void ThenSpONoninIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _csmAssetListPage.Spo2NoninName.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + "value is not as Expected Value");;
        }

        [When(@"user clicks Nonin toggle arrow")]
        public void WhenUserClicksNoninToggleArrow()
        {
            _csmAssetListPage.NoninToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Nonin ""(.*)"" is ""(.*)""")]
        public void ThenNoninIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "firmware version":
                    ActualValue = _csmAssetListPage.NoninFirmwareVersion.Text;
                    break;

                case "hardware version":
                    ActualValue = _csmAssetListPage.NoninHardwareVersion.Text;
                    break;
                case "serial number":
                    ActualValue = _csmAssetListPage.NoninSerialNummber.Text;
                    break;
                case "model number":
                    ActualValue = _csmAssetListPage.NoninModelNumberValue.Text;
                    break;
                case "module type":
                    ActualValue = _csmAssetListPage.NoninModuleTypeValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + "value is not as Expected Value");;
        }

        [Then(@"Nonin ""(.*)"" label is displayed")]
        public void ThenNoninLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            
            switch (LabelName.ToLower().Trim())
            {
                case "model number":
                    ActualValue = _csmAssetListPage.NoninModelNumberLabel.GetElementVisibility();
                    break;
                case "module type":
                    ActualValue = _csmAssetListPage.NoninModuleTypeLabel.GetElementVisibility();
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeTrue(LabelName+"Label is not displayed");
        }


        [Then(@"Radio Newmar row ""(.*)"" is ""(.*)""")]
        public void ThenRadioNewmarRowIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _csmAssetListPage.RadioNewmarRowName.Text;
                    break;
                case "firmware version":
                    ActualValue = _csmAssetListPage.RadioNewmarRowFirmwareVersion.Text;
                    break;
                case "serial number":
                    ActualValue = _csmAssetListPage.RadioNewmarRowSerialNumber.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + "value is not as Expected Value");;
        }

        [When(@"user clicks Radio-Newmar toggle arrow")]
        public void WhenUserClicksRadio_NewmarToggleArrow()
        {
            _csmAssetListPage.RadioNewmarRowToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Radio Newmar ""(.*)"" label is displayed")]
        public void ThenRadioNewmarLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            
            switch (LabelName.ToLower().Trim())
            {
                case "access point mac address":
                    ActualValue = _csmAssetListPage.RadioNewmarAPMacAddressLabel.GetElementVisibility();
                    break;
                case "channel":
                    ActualValue = _csmAssetListPage.RadioNewmarChannelLabel.GetElementVisibility();
                    break;
                case "connection mode":
                    ActualValue = _csmAssetListPage.RadioNewmarConnectionModeLabel.GetElementVisibility();
                    break;
                case "ssid":
                    ActualValue = _csmAssetListPage.RadioNewmarSSIDLabel.GetElementVisibility();
                    break;
                case "rssi":
                    ActualValue = _csmAssetListPage.RadioNewmarRSSILabel.GetElementVisibility();
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;

            }

            ActualValue.Should().BeTrue(LabelName+"Label is not displayed");
        }

        [Then(@"Radio Newmar ""(.*)"" is ""(.*)""")]
        public void ThenRadioNewmarIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "access point mac address":
                    ActualValue = _csmAssetListPage.RadioNewmarAPMacAddressValue.Text;
                    break;
                case "channel":
                    ActualValue = _csmAssetListPage.RadioNewmarChannelValue.Text;
                    break;
                case "connection mode":
                    ActualValue = _csmAssetListPage.RadioNewmarConnectionModeValue.Text;
                    break;
                case "ssid":
                    ActualValue = _csmAssetListPage.RadioNewmarSSIDValue.Text;
                    break;
                case "rssi":
                    ActualValue = _csmAssetListPage.RadioNewmarRSSIValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;

            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + "value is not as Expected Value");;
        }


        [Then(@"Summary CSM image is displayed")]
        public void ThenSummaryCSMImageIsDisplayed()
        {
            _csmAssetListPage.SummaryCSMImage.GetElementVisibility().Should().BeTrue( "Image is not displayed");
                
        }

        [Then(@"Summary ""(.*)"" label is displayed")]
        public void ThenSummaryLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            switch (LabelName.ToLower().Trim())
            {
                case "ip address":
                    ActualValue = _csmAssetListPage.SummaryIPAddressLabel.GetElementVisibility();
                    break;
                case "radio ip address":
                    ActualValue = _csmAssetListPage.SummaryRadioIPAddressLabel.GetElementVisibility();
                    break;
                case "ethernet mac address":
                    ActualValue = _csmAssetListPage.SummaryEthernetMacAddressLabel.GetElementVisibility();
                    break;
                case "model":
                    ActualValue = _csmAssetListPage.SummaryModelLabel.GetElementVisibility();
                    break;
                case "asset name":
                    ActualValue = _csmAssetListPage.SummaryAssetNameLabel.GetElementVisibility();
                    break;
                case "serial number":
                    ActualValue = _csmAssetListPage.SummarySerialNumberLabel.GetElementVisibility();
                    break;
                case "facility":
                    ActualValue = _csmAssetListPage.SummaryFacilityLabel.GetElementVisibility();
                    break;
                case "location":
                    ActualValue = _csmAssetListPage.SummaryLocationLabel.GetElementVisibility();
                    break;
                case "room/bed":
                    ActualValue = _csmAssetListPage.SummaryRoomBedLabel.GetElementVisibility();
                    break;
                case "asset tag":
                    ActualValue = _csmAssetListPage.SummaryAssetTagLabel.GetElementVisibility();
                    break;
                case "connection status":
                    ActualValue = _csmAssetListPage.SummaryConnectionStatusLabel.GetElementVisibility();
                    break;
                case "last vital sent":
                    ActualValue = _csmAssetListPage.SummaryLastVitalSentLabel.GetElementVisibility();
                    break;

                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }

            ActualValue.Should().BeTrue(LabelName + " is not displayed");
        }

        [Then(@"Summary ""(.*)"" is ""(.*)""")]
        public void ThenSummaryIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "ip address":
                    ActualValue = _csmAssetListPage.SummaryIPAddressValue.Text;
                    break;
                case "radio ip address":
                    ActualValue = _csmAssetListPage.SummaryRadioIpAddressValue.Text;
                    break;
                case "ethernet mac address":
                    ActualValue = _csmAssetListPage.SummaryEthernetMacAddressValue.Text;
                    break;
                case "model":
                    ActualValue = _csmAssetListPage.SummaryModelValue.Text;
                    break;
                case "asset name":
                    ActualValue = _csmAssetListPage.SummaryAssetNameValue.Text;
                    break;
                case "serial number":
                    ActualValue = _csmAssetListPage.SummarySerialNumberValue.Text;
                    break;
                case "facility":
                    ActualValue = _csmAssetListPage.SummaryFacilityValue.Text;
                    break;
                case "location":
                    ActualValue = _csmAssetListPage.SummaryLocationValue.Text;
                    break;
                
                case "asset tag":
                    ActualValue = _csmAssetListPage.SummaryAssetTagValue.Text;
                    break;
                case "last vital sent":
                    ActualValue = GetMethods.ConvertDateTimeLocalToUTC(_csmAssetListPage.SummaryLastVitalSentValue.Text);
                    ExpectedValue = GetMethods.ConvertNewYorkTimetoUTC(ExpectedValue);
                    break;
                case "room/bed":
                    ActualValue = _csmAssetListPage.SummaryRoomBedValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + "value is not as Expected Value");;
        }

    }
}
