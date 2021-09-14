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
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.AssetsTab.ComponentInformation
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5695")]
    class Req5695Steps
    {

        private readonly LoginPage _loginPage;
        private readonly MainPage _mainPage;
        private readonly LandingPage _landingPage;
        private readonly CVSMAssetListPage _CVSMassetListPage;

        private readonly WebDriverWait _wait;
        private ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public Req5695Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _mainPage = new MainPage(driver);
            _landingPage = new LandingPage(driver);
            _CVSMassetListPage = new CVSMAssetListPage(driver);
        }

        [Given(@"user is on Asset List page with more than one CVSM")]
        public void GivenUserIsOnCVSMassetListPageWithMoreThanOneCVSM()
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CVSMDeviceName);
            _CVSMassetListPage.GetDeviceCount().Should().BeGreaterThan(1);
        }

        [When(@"user clicks any CVSM")]
        public void WhenUserClicksAnyCVSM()
        {
            Thread.Sleep(2000);
            _mainPage.SearchSerialNumberAndClick("100020000001");
        }

        [Then(@"Asset Details landing page is displayed")]
        public void ThenAssetDetailsLandingPageIsDisplayed()
        {
            _CVSMassetListPage.CVSMDetailsPage.GetElementVisibility().Should().BeTrue("Asset Details Landing Page is not displayed");
        }

        [Then(@"Asset Detail summary subsection with Edit button is displayed")]
        public void ThenAssetDetailSummarySubsectionWithEditButtonIsDisplayed()
        {
            _CVSMassetListPage.CVSMDetailsSummary.GetElementVisibility().Should().BeTrue("CVSM details summary subsection is not displayed");
            _CVSMassetListPage.EditButton.GetElementVisibility().Should().BeTrue("Edit Button is not displayed");
        }

        [Then(@"Preventive Maintenance tab is displayed")]
        public void ThenPreventiveMaintenanceTabIsDisplayed()
        {
            _CVSMassetListPage.PreventiveMaintenanceTab.GetElementVisibility().Should().BeTrue("Preventive Mainetenance Tab is not displayed");
        }

        [Then(@"Component Information tab is displayed")]
        public void ThenComponentInformationTabIsDisplayed()
        {
            _CVSMassetListPage.ComponentInformationTab.GetElementVisibility().Should().BeTrue("Component information tab is not displayed");
        }

        [Then(@"Logs tab is displayed")]
        public void ThenLogsTabIsDisplayed()
        {
            _CVSMassetListPage.LogsTab.GetElementVisibility().Should().BeTrue("Logs tab is not displayed");
        }

        [Then(@"Asset Detail subsection is displayed")]
        public void ThenAssetDetailSubsectionIsDisplayed()
        {
            _CVSMassetListPage.AssetDetailsSubsection.GetElementVisibility().Should().BeTrue("Asset Details Subsection is not displayed");
        }

        [Given(@"user is on Component details page for CVSM Serial number ""(.*)""")]
        public void GivenUserIsOnComponentDetailsPageForCVSMSerialNumber(string SerialNumber)
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CVSMDeviceName);

            _CVSMassetListPage.GetDeviceCount().Should().BeGreaterThan(1);
            Thread.Sleep(2000);
            _mainPage.SearchSerialNumberAndClick(SerialNumber);
            _CVSMassetListPage.ComponentInformationTab.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Battery ""(.*)"" is ""(.*)""")]
        public void ThenIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch(LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _CVSMassetListPage.BatteryName.Text;
                    break;
                case "manufacture date":
                    ActualValue = _CVSMassetListPage.BatteryManufacturerDate.Text;
                    break;
                case "serial number":
                    ActualValue = _CVSMassetListPage.BatterySerialNumber.Text;
                    break;
                case "cycle count":
                    ActualValue = _CVSMassetListPage.BatteryCycleCount.Text;
                    break;
                case "temperature":
                    ActualValue = _CVSMassetListPage.BatteryTemparatureValue.Text;
                    break;
                case "devicename":
                    ActualValue = _CVSMassetListPage.BatteryDeviceNameValue.Text;
                    break;
                case "remaining capacity":
                    ActualValue = _CVSMassetListPage.BatteryRemainingCapacityValue.Text;
                    break;
                case "voltage":
                    ActualValue = _CVSMassetListPage.BatteryVoltageValue.Text;
                    break;
                case "full charge capacity":
                    ActualValue = _CVSMassetListPage.BatteryFullChargeCapacityValue.Text;
                    break;
                case "current":
                    ActualValue = _CVSMassetListPage.BatteryCurrentValue.Text;
                    break;
                case "avg time to empty":
                    ActualValue = _CVSMassetListPage.BatteryAvgTimeEmptyValue.Text;
                    break;
                case "designed capacity":
                    ActualValue = _CVSMassetListPage.BatteryDesignedCapacityValue.Text;
                    break;
                case "avg. time to full charge":
                    ActualValue = _CVSMassetListPage.BatteryAvgTimeFullChargeValue.Text;
                    break;
                case "chemistry":
                    ActualValue = _CVSMassetListPage.BatteryChemistryValue.Text;
                    break;
                case "model name":
                    ActualValue = _CVSMassetListPage.BatteryModelNameValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + " value is not as Expected Value");
        }

        [Then(@"Battery ""(.*)"" is displayed in ""(.*)"" column")]
        public void ThenIsDisplayedInColumn(string LabelName, string ColumnName)
        {
            int ActualColumnIndex = -1;
            int ExpectedColumnIndex = -2;
            switch(ColumnName.ToLower().Trim())
            {
                case "usage":
                    ExpectedColumnIndex = CVSMAssetListPage.ExpectedValue.UsageColumnIndex;
                    break;
                default:
                    Assert.Fail(ColumnName + " is invalid");
                    break;
            }
          
            switch (LabelName.ToLower().Trim())
            {
                case "cycle count":
                    ActualColumnIndex = _CVSMassetListPage.BatteryElementList.IndexOf(_CVSMassetListPage.BatteryCycleCount);
                    break;
                default:
                    Assert.Fail(LabelName+" is invalid");
                    break;
            }

            ActualColumnIndex.Should().Be(ExpectedColumnIndex, LabelName + "is not in"+ColumnName);
        }

        [When(@"user clicks battery toggle arrow")]
        public void WhenUserClicksBatteryToggleArrow()
        {
            _CVSMassetListPage.BatteryToggelArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Battery ""(.*)"" label is displayed")]
        public void ThenLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            switch(LabelName.ToLower().Trim())
            {
                case "temperature":
                    ActualValue = _CVSMassetListPage.BatteryTemparatureLabel.GetElementVisibility();
                    break;
                case "remaining capacity":
                    ActualValue = _CVSMassetListPage.BatteryRemainingCapacityLabel.GetElementVisibility();
                    break;
                case "voltage":
                    ActualValue = _CVSMassetListPage.BatteryVoltageLabel.GetElementVisibility();
                    break;
                case "full charge capacity":
                    ActualValue = _CVSMassetListPage.BatteryFullChargeCapacityLabel.GetElementVisibility();
                    break;
                case "current":
                    ActualValue = _CVSMassetListPage.BatteryCurrentLabel.GetElementVisibility();
                    break;
                case "avg. time to empty":
                    ActualValue = _CVSMassetListPage.BatteryAvgTimeEmptyLabel.GetElementVisibility();
                    break;
                case "designed capacity":
                    ActualValue = _CVSMassetListPage.BatteryDesignedCapacityLabel.GetElementVisibility();
                    break;
                case "avg. time to full charge":
                    ActualValue = _CVSMassetListPage.BatteryAvgTimeFullChargeLabel.GetElementVisibility();
                    break;
                case "chemistry":
                    ActualValue = _CVSMassetListPage.BatteryChemistryLabel.GetElementVisibility();
                    break;
                case "model name":
                    ActualValue = _CVSMassetListPage.BatteryModelNameLabel.GetElementVisibility();
                    break;
                case "devicename":
                    ActualValue = _CVSMassetListPage.BatteryDeviceNameLabel.GetElementVisibility();
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualValue.Should().BeTrue(LabelName + " label is not displayed");
        }


        [Then(@"Braun4000 ""(.*)"" is ""(.*)""")]
        public void ThenBraunIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _CVSMassetListPage.BraunNameValue.Text;
                    break;
                case "firmware version":
                    ActualValue = _CVSMassetListPage.BraunFirmwareVersionValue.Text;
                    break;
                case "hardware version":
                    ActualValue = _CVSMassetListPage.BraunHardwareVersionValue.Text;
                    break;
                case "cycle count":
                    ActualValue = _CVSMassetListPage.BraunCycleCountValue.Text;
                    break;
                case "model number":
                    ActualValue = _CVSMassetListPage.BraunModelNumberValue.Text;
                    break;
                case "serial number":
                    ActualValue = _CVSMassetListPage.BraunSerialNumberValue.Text;
                    break;
                case "dock cycle count":
                    ActualValue = _CVSMassetListPage.BraunDockCycleCountValue.Text;
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue,LabelName+" value is not as expected");
        }

        [Then(@"Braun4000 ""(.*)"" is displayed in ""(.*)"" column")]
        public void ThenBraunIsDisplayedInColumn(string LabelName, string ColumnName)
        {
            int ActualColumnIndex = -1;
            int ExpectedColumnIndex = -2;
            switch (ColumnName.ToLower().Trim())
            {
                case "usage":
                    ExpectedColumnIndex = CVSMAssetListPage.ExpectedValue.UsageColumnIndex;
                    break;
                default:
                    Assert.Fail(ColumnName + " is invalid");
                    break;
            }

            switch (LabelName.ToLower().Trim())
            {
                case "cycle count":
                    ActualColumnIndex = _CVSMassetListPage.BraunElementList.IndexOf(_CVSMassetListPage.BraunCycleCountValue);
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualColumnIndex.Should().Be(ExpectedColumnIndex,LabelName + " is not in " + ColumnName);
        }

        [When(@"user clicks Braun Pro 4000 toggle arrow")]
        public void WhenUserClicksBraunProToggleArrow()
        {
            _CVSMassetListPage.BraunToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Braun4000 ""(.*)"" label is displayed")]
        public void ThenBraunLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            switch (LabelName.ToLower().Trim())
            {
                case "model number":
                    ActualValue = _CVSMassetListPage.BraunModelNumberLabel.GetElementVisibility();
                    break;
                case "dock cycle count":
                    ActualValue = _CVSMassetListPage.BraunDockCycleCountLabel.GetElementVisibility();
                    break;

                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;

            }

            ActualValue.Should().BeTrue(LabelName+" is not as expected");
        }


        [Then(@"CO2 ""(.*)"" is ""(.*)""")]
        public void ThenCOIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _CVSMassetListPage.CO2Name.Text;
                    break;
                case "firmware version":
                    ActualValue = _CVSMassetListPage.CO2FirmwareVersion.Text;
                    break;
                case "hardware version":
                    ActualValue = _CVSMassetListPage.CO2HardwareVersion.Text;
                    break;
                case "serial number":
                    ActualValue = _CVSMassetListPage.CO2SerialNumber.Text;
                    break;
                case "run time":
                    ActualValue = _CVSMassetListPage.CO2RunTimeValue.Text;
                    break;

                case "hours to service":
                    ActualValue = _CVSMassetListPage.CO2HoursToServiceValue.Text;
                    break;

                case "max hours to calibration":
                    ActualValue = _CVSMassetListPage.CO2MaxHourToCalibrationValue.Text;
                    break;

                case "model number":
                    ActualValue = _CVSMassetListPage.CO2ModelNumberValue.Text;
                    break;

                case "oem device label":
                    ActualValue = _CVSMassetListPage.CO2OEMDeviceNameValue.Text;
                    break;

                case "oem serial number":
                    ActualValue = _CVSMassetListPage.CO2OEMSerialNumberValue.Text;
                    break;

                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + " value is not as expected");
        }


        [Then(@"CO2 ""(.*)"" is displayed in ""(.*)"" column")]
        public void ThenCOIsDisplayedInColumn(string LabelName, string ColumnName)
        {
            int ActualColumnIndex = -1;
            int ExpectedColumnIndex = -2;
            switch (ColumnName.ToLower().Trim())
            {
                case "usage":
                    ExpectedColumnIndex = CVSMAssetListPage.ExpectedValue.UsageColumnIndex;
                    break;
                default:
                    Assert.Fail(ColumnName + " is invalid");
                    break;
            }

            switch (LabelName.ToLower().Trim())
            {
                //We are decreamenting the Actual column index by one as one extra div element in present in DOM
                case "run time":
                    ActualColumnIndex = _CVSMassetListPage.CO2ElementList.IndexOf(_CVSMassetListPage.CO2RunTime)-1;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualColumnIndex.Should().Be(ExpectedColumnIndex, LabelName + " is not in " + ColumnName);
        }


        [When(@"user clicks CO2 sensor toggle arrow")]
        public void WhenCOUserClicksCOSensorToggleArrow()
        {
            _CVSMassetListPage.CO2SensorToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"CO2 ""(.*)"" label is displayed")]
        public void ThenCOLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            switch (LabelName.ToLower().Trim())
            {
                case "hours to service":
                    ActualValue = _CVSMassetListPage.CO2HoursToServiceLabel.GetElementVisibility();
                    break;
                case "max hours to calibration":
                    ActualValue = _CVSMassetListPage.CO2MaxHourToCalibrationLabel.GetElementVisibility();
                    break;
                case "model number":
                    ActualValue = _CVSMassetListPage.CO2ModelNumberLabel.GetElementVisibility();
                    break;
                case "oem device name":
                    ActualValue = _CVSMassetListPage.CO2OEMDeviceNameLabel.GetElementVisibility();
                    break;
                case "oem serial number":
                    ActualValue = _CVSMassetListPage.CO2OEMSerialNumberLabel.GetElementVisibility();
                    break;

                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;

            }

            ActualValue.Should().BeTrue(LabelName + " is not as expected");
        }

        [Then(@"Deluxe Comms ""(.*)"" is ""(.*)""")]
        public void ThenDeluxeCommsIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "serial number":
                    ActualValue = _CVSMassetListPage.DeluxeSerialNumber.Text;
                    break;
                
                case "firmware version":
                    ActualValue = _CVSMassetListPage.DeluxeFirmwareVersion.Text;
                    break;
          
                case "model number":
                    ActualValue = _CVSMassetListPage.DeluxeModelNumberValue.Text;
                    break;

                default:
                    Assert.Fail(LabelName + " is Invalid.");
                    break;

            }
            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + "value is not as expected");
        }

            [When(@"user clicks Delux comms module toggle arrow")]
        public void WhenUserClicksDeluxCommsModuleToggleArrow()
        {
            _CVSMassetListPage.DeluxeModuleToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Deluxe Comms ""(.*)"" label is displayed")]
        public void ThenDeluxeCommsLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            switch (LabelName.ToLower().Trim())
            {
                case "model number":
                    ActualValue = _CVSMassetListPage.DeluxeModelNumberLabel.GetElementVisibility();
                    break;

                default:
                    Assert.Fail(LabelName + "is Invalid.");
                    break;
            }

            ActualValue.Should().BeTrue(LabelName + " is not displayed");
        }


        [Then(@"NIBP ""(.*)"" is ""(.*)""")]
        public void ThenNIBPIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _CVSMassetListPage.NIBPName.Text;
                    break;
                case "firmware version":
                    ActualValue = _CVSMassetListPage.NIBPFirmwareVersion.Text;
                    break;
                case "hardware version":
                    ActualValue = _CVSMassetListPage.NIBPHardwareVersion.Text;
                    break;
                case "serial number":
                    ActualValue = _CVSMassetListPage.NIBPSerialNumber.Text;
                    break;
                case "cycle count":
                    ActualValue = _CVSMassetListPage.NIBPCycleCount.Text;
                    break;
                case "bootloader version":
                    ActualValue = _CVSMassetListPage.NIBPBootloaderVersionValue.Text;
                    break;
                case "model number":
                    ActualValue = _CVSMassetListPage.NIBPModelNumberValue.Text;
                    break;
                case "safety version":
                    ActualValue = _CVSMassetListPage.NIBPSafetyVersionValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + "is Invalid.");
                    break;
            }
            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + "is not as expected.");
        }

        [Then(@"NIBP ""(.*)"" is displayed in ""(.*)"" column")]
        public void ThenNIBPIsDisplayedInColumn(string LabelName, string ColumnName)
        {
            int ActualColumnIndex = -1;
            int ExpectedColumnIndex = -2;
            switch (ColumnName.ToLower().Trim())
            {
                case "usage":
                    ExpectedColumnIndex = CVSMAssetListPage.ExpectedValue.UsageColumnIndex;
                    break;
                default:
                    Assert.Fail(ColumnName + " is invalid");
                    break;
            }

            switch (LabelName.ToLower().Trim())
            {
           
                case "cycle count":
                    ActualColumnIndex = _CVSMassetListPage.NIBPElementList.IndexOf(_CVSMassetListPage.NIBPCycleCount);
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualColumnIndex.Should().Be(ExpectedColumnIndex, LabelName + " is not in " + ColumnName);
        
    }

        [When(@"user clicks NIBP sensor toggle arrow")]
        public void WhenUserClicksNIBPSensorToggleArrow()
        {
            _CVSMassetListPage.NIBPSensorToggleButton.Click();
            Thread.Sleep(2000);
        }

        [Then(@"NIBP ""(.*)"" label is displayed")]
        public void ThenNIBPLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            switch (LabelName.ToLower().Trim())
            {
                case "cycle count":
                    ActualValue = _CVSMassetListPage.NIBPCycleCount.GetElementVisibility();
                    break;
                case "bootloader version":
                    ActualValue = _CVSMassetListPage.NIBPBootloaderVersionLabel.GetElementVisibility();
                    break;
                case "model number":
                    ActualValue = _CVSMassetListPage.NIBPModelNumberLabel.GetElementVisibility();
                    break;

                case "safety version":
                    ActualValue = _CVSMassetListPage.NIBPSafetyVersionLabel.GetElementVisibility();
                    break;

                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;

            }
            ActualValue.Should().BeTrue(LabelName + " is not displayed");
        }


        [Then(@"Printer ""(.*)"" is ""(.*)""")]
        public void ThenPrinterIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _CVSMassetListPage.PrinterName.Text;
                    break;
                case "firmware version":
                    ActualValue = _CVSMassetListPage.PrinterFirmwareVersion.Text;
                    break;
                case "model number":
                    ActualValue = _CVSMassetListPage.PrinterModelNumberValue.Text;
                    break;
                case "serial number":
                    ActualValue = _CVSMassetListPage.PrinterSerialNumber.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;

            }
            ActualValue.Should().BeEquivalentTo(ExpectedValue,LabelName+ " is not as expected.");
        }

        [When(@"user clicks Printer toggle arrow")]
        public void WhenUserClicksPrinterToggleArrow()
        {
            _CVSMassetListPage.PrinterToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Printer ""(.*)"" label is displayed")]
        public void ThenPrinterLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            switch (LabelName.ToLower().Trim())
            {
                case "model number":
                    ActualValue = _CVSMassetListPage.PrinterModelNumberLabel.GetElementVisibility();
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }

            ActualValue.Should().BeTrue(LabelName + " is not displayed");
        }


        [Then(@"Temp Probe ""(.*)"" is ""(.*)""")]
        public void ThenTempProbeIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _CVSMassetListPage.TempProbeName.Text;
                    break;
                case "usage value":
                    ActualValue = _CVSMassetListPage.TempProbeUsageValue.Text;
                    break;
                case "model number":
                    ActualValue = _CVSMassetListPage.TempProbeModelNumberValue.Text;
                    break;
                case "serial number":
                    ActualValue = _CVSMassetListPage.TempProbeSerialNumber.Text;
                    break;
                case "probe type":
                    ActualValue = _CVSMassetListPage.TempProbeProbeTypeValue.Text;
                    break;
                case "last device serial number":
                    ActualValue = _CVSMassetListPage.TempProbeLastDeviceSerialNumberValue.Text;
                    break;
                case "number of times probe changed devices":
                    ActualValue = _CVSMassetListPage.TempProbeNumberOfTimesProbeChangedDevicesValue.Text;
                    break;
                case "part number":
                    ActualValue = _CVSMassetListPage.TempProbePartNumberValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;

            }
            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + " is not as expected.");
        }

        [When(@"user clicks Temperature probe toggle arrow")]
        public void WhenUserClicksTemperatureProbeToggleArrow()
        {
            _CVSMassetListPage.TempProbeToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Temp Probe ""(.*)"" label is displayed")]
        public void ThenTempProbeLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            switch (LabelName.ToLower().Trim())
            {
                case "model number":
                    ActualValue = _CVSMassetListPage.TempProbeModelNumberLabel.GetElementVisibility();
                    break;
                case "probe type":
                    ActualValue = _CVSMassetListPage.TempProbeProbeTypeLabel.GetElementVisibility();
                    break;
                case "last device serial number":
                    ActualValue = _CVSMassetListPage.TempProbeLastDeviceSerialNumberLabel.GetElementVisibility();
                    break;
                case "number of times probe changed devices":
                    ActualValue = _CVSMassetListPage.TempProbeNumberOfTimesProbeChangedDevicesLabel.GetElementVisibility();
                    break;
                case "part number":
                    ActualValue = _CVSMassetListPage.TempProbePartNumberLabel.GetElementVisibility();
                    break;
                
                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }

            ActualValue.Should().BeTrue(LabelName + " is not displayed");
        }


        [Then(@"Scale ""(.*)"" is ""(.*)""")]
        public void ThenScaleIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _CVSMassetListPage.ScaleName.Text;
                    break;
                case "firmware version":
                    ActualValue = _CVSMassetListPage.ScaleFirmwareVersion.Text;
                    break;
                case "hardware version":
                    ActualValue = _CVSMassetListPage.ScaleHardwareVersion.Text;
                    break;
                case "serial number":
                    ActualValue = _CVSMassetListPage.ScaleSerialNumber.Text;
                    break;
                case "cycle count":
                    ActualValue = _CVSMassetListPage.ScaleCycleCount.Text;
                    break;
                case "model number":
                    ActualValue = _CVSMassetListPage.ScaleModelNumberValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;

            }
            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + " is not as expected.");
        }


        [Then(@"Scale ""(.*)"" is displayed in ""(.*)"" column")]
        public void ThenScaleIsDisplayedInColumn(string LabelName, string ColumnName)
        {
            int ActualColumnIndex = -1;
            int ExpectedColumnIndex = -2;
            switch (ColumnName.ToLower().Trim())
            {
                case "usage":
                    ExpectedColumnIndex = CVSMAssetListPage.ExpectedValue.UsageColumnIndex;
                    break;
                default:
                    Assert.Fail(ColumnName + " is invalid");
                    break;
            }

            switch (LabelName.ToLower().Trim())
            {

                case "cycle count":
                    ActualColumnIndex = _CVSMassetListPage.ScaleElementList.IndexOf(_CVSMassetListPage.ScaleCycleCount);
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualColumnIndex.Should().Be(ExpectedColumnIndex, LabelName + " is not in " + ColumnName);
        }

        [When(@"user clicks Scale toggle arrow")]
        public void WhenUserClicksScaleToggleArrow()
        {
            _CVSMassetListPage.ScaleToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Scale ""(.*)"" label is displayed")]
        public void ThenScaleLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            switch (LabelName.ToLower().Trim())
            {
                case "model number":
                    ActualValue = _CVSMassetListPage.ScaleModelNumberLabel.GetElementVisibility();
                    break;

                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }

            ActualValue.Should().BeTrue(LabelName + " is not displayed");
        }

        [Then(@"spo2 ""(.*)"" is ""(.*)""")]
        public void ThenSpoIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _CVSMassetListPage.Spo2Name.Text;
                    break;
                case "firmware version":
                    ActualValue = _CVSMassetListPage.Spo2FirmwareVersion.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid.");
                    break;
            }

           ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + " is not as expected.");
        }



        [Then(@"Masimo ""(.*)"" is ""(.*)""")]
        public void ThenMasimoIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _CVSMassetListPage.MasimoName.Text;
                    break;
                case "firmware version":
                    ActualValue = _CVSMassetListPage.MasimoFirmwareVersion.Text;
                    break;
                case "hardware version":
                    ActualValue = _CVSMassetListPage.MasimoHardwareVersion.Text;
                    break;
                case "serial number":
                    ActualValue = _CVSMassetListPage.MasimoSerialNumber.Text;
                    break;
                case "usage value":
                    ActualValue = _CVSMassetListPage.MasimoUsageValue.Text;
                    break;
                case "model number":
                    ActualValue = _CVSMassetListPage.MasimoModelNumberValue.Text;
                    break;
                case "rra license value":
                    ActualValue = _CVSMassetListPage.MasimoRraLicenceValue.Text;
                    break;
                case "sphb license value":
                    ActualValue = _CVSMassetListPage.MasimoSpHbLicenseValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid.");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + " is not as expected.");
        }

        [When(@"user clicks Masimo toggle arrow")]
        public void WhenUserClicksMasimoToggleArrow()
        {
            _CVSMassetListPage.MasimoToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Masimo ""(.*)"" label is displayed")]
        public void ThenMasimoLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            switch (LabelName.ToLower().Trim())
            {
                case "model number":
                    ActualValue = _CVSMassetListPage.MasimoModelNumberLabel.GetElementVisibility();
                    break;
                case "rra license":
                    ActualValue = _CVSMassetListPage.MasimoRraLicenceLabel.GetElementVisibility();
                    break;
                case "sphb license":
                    ActualValue = _CVSMassetListPage.MasimoSpHbLicenseLabel.GetElementVisibility();
                    break;

                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }

            ActualValue.Should().BeTrue(LabelName + " is not displayed");
        }


        [Then(@"SPO2 Nellcor ""(.*)"" is ""(.*)""")]
        public void ThenSPONellcorIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _CVSMassetListPage.Spo2Name.Text;
                    break;
                case "firmware version":
                    ActualValue = _CVSMassetListPage.Spo2FirmwareVersion.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid.");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + " is not as expected.");
        }


        [Then(@"Nellcor ""(.*)"" is ""(.*)""")]
        public void ThenNellcorIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _CVSMassetListPage.NellcorName.Text;
                    break;
                case "firmware version":
                    ActualValue = _CVSMassetListPage.NellcorFirmwareVersion.Text;
                    break;
                case "hardware version":
                    ActualValue = _CVSMassetListPage.NellcorHardwareVersion.Text;
                    break;
                case "serial number":
                    ActualValue = _CVSMassetListPage.NellcorSerialNumber.Text;
                    break;
                case "model number":
                    ActualValue = _CVSMassetListPage.NellcorModelNumberValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid.");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + " is not as expected.");
        }

        [When(@"user clicks Nellcor toggle arrow")]
        public void WhenUserClicksNellcorToggleArrow()
        {
            _CVSMassetListPage.NellcorToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Nellcor ""(.*)"" label is displayed")]
        public void ThenNellcorLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            switch (LabelName.ToLower().Trim())
            {
                case "model number":
                    ActualValue = _CVSMassetListPage.NellcorModelNumberLabel.GetElementVisibility();
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }

            ActualValue.Should().BeTrue(LabelName + " is not displayed");
        }

        [Then(@"SureTemp ""(.*)"" is ""(.*)""")]
        public void ThenSureTempIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _CVSMassetListPage.SureTempName.Text;
                    break;
                case "firmware version":
                    ActualValue = _CVSMassetListPage.SureTempFirmwareVersion.Text;
                    break;
                case "hardware version":
                    ActualValue = _CVSMassetListPage.SureTempHardwareVersion.Text;
                    break;
                case "serial number":
                    ActualValue = _CVSMassetListPage.SureTempSerialNumber.Text;
                    break;
                case "usage value":
                    ActualValue = _CVSMassetListPage.SureTempUsageValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid.");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + " is not as expected.");
        }

        [Then(@"Radio Lamarr ""(.*)"" is ""(.*)""")]
        public void ThenRadioLamarrIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _CVSMassetListPage.RadioLamarrName.Text;
                    break;
                case "access point mac address":
                    ActualValue = _CVSMassetListPage.RadioLamarrAPMACAddressValue.Text;
                    break;
                case "radio ip address":
                    ActualValue = _CVSMassetListPage.RadioLamarrRadioIPAddressValue.Text;
                    break;
                case "serial number":
                    ActualValue = _CVSMassetListPage.RadioLamarrSerialNumber.Text;
                    break;
                case "usage value":
                    ActualValue = _CVSMassetListPage.RadioLamarrUsageValue.Text;
                    break;
                case "mac address":
                    ActualValue = _CVSMassetListPage.RadioLamarrMacAddressValue.Text;
                    break;
                case "model number":
                    ActualValue = _CVSMassetListPage.RadioLamarrModelNumberValue.Text;
                    break;
                case "rssi":
                    ActualValue = _CVSMassetListPage.RadioLamarrRSSIvalue.Text;
                    break;
                case "server version":
                    ActualValue = _CVSMassetListPage.RadioLamarrServerVersionValue.Text;
                    break;
                case "ssid":
                    ActualValue = _CVSMassetListPage.RadioLamarrSSIDValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid.");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + " is not as expected.");
        }


        [When(@"user clicks Radio-Lamarr toggle arrow")]
        public void WhenUserClicksRadio_LamarrToggleArrow()
        {
            _CVSMassetListPage.RadioLamarrToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Radio Lamarr ""(.*)"" label is displayed")]
        public void ThenRadioLamarrLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            switch (LabelName.ToLower().Trim())
            {
                case "access point mac address":
                    ActualValue = _CVSMassetListPage.RadioLamarrAPMACAddressLabel.GetElementVisibility();
                    break;
                case "radio ip address":
                    ActualValue = _CVSMassetListPage.RadioLamarrRadioIPAddressLabel.GetElementVisibility();
                    break;
                case "mac address":
                    ActualValue = _CVSMassetListPage.RadioLamarrMacAddressLabel.GetElementVisibility();
                    break;
                case "model number":
                    ActualValue = _CVSMassetListPage.RadioLamarrModelNumberLabel.GetElementVisibility();
                    break;
                case "rssi":
                    ActualValue = _CVSMassetListPage.RadioLamarrRSSILabel.GetElementVisibility();
                    break;
                case "server version":
                    ActualValue = _CVSMassetListPage.RadioLamarrServerVersionLabel.GetElementVisibility();
                    break;
                case "ssid":
                    ActualValue = _CVSMassetListPage.RadioLamarrSSIDLabel.GetElementVisibility();
                    break;

                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }

            ActualValue.Should().BeTrue(LabelName + " is not displayed");
        }


        [Then(@"Radio Newmar ""(.*)"" is ""(.*)""")]
        public void ThenRadioNewmarIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _CVSMassetListPage.RadioNewmarName.Text;
                    break;
                case "access point mac address":
                    ActualValue = _CVSMassetListPage.RadioNewmarApMacAddressValue.Text;
                    break;
                case "radio ip address":
                    ActualValue = _CVSMassetListPage.RadioNewmarRadioIpAddressValue.Text;
                    break;
                case "serial number":
                    ActualValue = _CVSMassetListPage.RadioNewmarSerialNUmber.Text;
                    break;
                case "firmware version":
                    ActualValue = _CVSMassetListPage.RadioNewmarFirmwareVersion.Text;
                    break;
                case "mac address":
                    ActualValue = _CVSMassetListPage.RadioNewmarMacAddressValue.Text;
                    break;
                case "model number":
                    ActualValue = _CVSMassetListPage.RadioNewmarModelNumberValue.Text;
                    break;
                case "rssi":
                    ActualValue = _CVSMassetListPage.RadioNewmarRssiValue.Text;
                    break;
                case "server version":
                    ActualValue = _CVSMassetListPage.RadioNewmarServerVersionValue.Text;
                    break;
                case "ssid":
                    ActualValue = _CVSMassetListPage.RadioNewmarSsidValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid.");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + " is not as expected.");
        }

        [When(@"user clicks Radio-Newmar toggle arrow")]
        public void WhenUserClicksRadio_NewmarToggleArrow()
        {
            _CVSMassetListPage.RadioNewmarToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Radio Newmar ""(.*)"" label is displayed")]
        public void ThenRadioNewmarLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            switch (LabelName.ToLower().Trim())
            {
                case "access point mac address":
                    ActualValue = _CVSMassetListPage.RadioNewmarApMacAddressLabel.GetElementVisibility();
                    break;
                case "radio ip address":
                    ActualValue = _CVSMassetListPage.RadioNewmarRadioIpAddressLabel.GetElementVisibility();
                    break;
                case "mac address":
                    ActualValue = _CVSMassetListPage.RadioNewmarMacAddressLabel.GetElementVisibility();
                    break;
                case "model number":
                    ActualValue = _CVSMassetListPage.RadioNewmarModelNumberLabel.GetElementVisibility();
                    break;
                case "rssi":
                    ActualValue = _CVSMassetListPage.RadioNewmarRssiLabel.GetElementVisibility();
                    break;
                case "server version":
                    ActualValue = _CVSMassetListPage.RadioNewmarServerVersionLabel.GetElementVisibility();
                    break;
                case "ssid":
                    ActualValue = _CVSMassetListPage.RadioNewmarSsidLabel.GetElementVisibility();
                    break;

                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }

            ActualValue.Should().BeTrue(LabelName + " is not displayed");
        }



        [Then(@"Connex Device ""(.*)"" is ""(.*)""")]
        public void ThenConnexDeviceIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _CVSMassetListPage.ConnexName.Text;
                    break;
                case "serial number":
                    ActualValue = _CVSMassetListPage.ConnexSerialNumber.Text;
                    break;
                case "device hours on":
                    ActualValue = _CVSMassetListPage.ConnexDeviceHoursValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid.");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + " is not as expected.");
        }

        [Then(@"Connex Device ""(.*)"" label is displayed in ""(.*)"" column")]
        public void ThenConnexDeviceLabelIsDisplayedInColumn(string LabelName, string ColumnName)
        {

            int ActualColumnIndex = -1;
            int ExpectedColumnIndex = -2;
            switch (ColumnName.ToLower().Trim())
            {
                case "usage":
                    ExpectedColumnIndex = CVSMAssetListPage.ExpectedValue.UsageColumnIndex;
                    break;
                default:
                    Assert.Fail(ColumnName + " is invalid");
                    break;
            }

            switch (LabelName.ToLower().Trim())
            {
                case "device hours on":
                    ActualColumnIndex = _CVSMassetListPage.ConnexElementList.IndexOf(_CVSMassetListPage.ConnexUsage);
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            ActualColumnIndex.Should().Be(ExpectedColumnIndex, LabelName + "is not in" + ColumnName);
        }

        [Then(@"Host Controller ""(.*)"" is ""(.*)""")]
        public void ThenHostControllerIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = _CVSMassetListPage.HostControllerName.Text;
                    break;
                case "serial number":
                    ActualValue = _CVSMassetListPage.HostControllerSerialNumber.Text;
                    break;
                case "firmware version":
                    ActualValue = _CVSMassetListPage.HostControllerFirmwareVersion.Text;
                    break;
                case "hardware version":
                    ActualValue = _CVSMassetListPage.HostControllerHardwareVersion.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid.");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + " is not as expected.");
        }

        [Then(@"CVSM image is displayed")]
        public void ThenCVSMImageIsDisplayed()
        {
            _CVSMassetListPage.DetailsSummaryCVSMImage.GetElementVisibility().Should().BeTrue("CVSM Image is not displayed");
        }

        [Then(@"Details Summary ""(.*)"" label is displayed")]
        public void ThenDetailsSummaryLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            switch (LabelName.ToLower().Trim())
            {
                case "ip address":
                    ActualValue = _CVSMassetListPage.DetailsSummaryIPAddressLabel.GetElementVisibility();
                    break;
                case "radio ip address":
                    ActualValue = _CVSMassetListPage.DetailsSummaryRadioIPAddressLabel.GetElementVisibility();
                    break;
                case "ethernet mac address":
                    ActualValue = _CVSMassetListPage.DetailsSummaryEthernetMacAddressLabel.GetElementVisibility();
                    break;
                case "model":
                    ActualValue = _CVSMassetListPage.DetailsSummaryModelLabel.GetElementVisibility();
                    break;
                case "asset name":
                    ActualValue = _CVSMassetListPage.DetailsSummaryAssetNameLabel.GetElementVisibility();
                    break;
                case "serial number":
                    ActualValue = _CVSMassetListPage.DetailsSummarySerialNumberLabel.GetElementVisibility();
                    break;
                case "facility":
                    ActualValue = _CVSMassetListPage.DetailsSummaryFacilityLabel.GetElementVisibility();
                    break;
                case "location":
                    ActualValue = _CVSMassetListPage.DetailsSummaryLocationLabel.GetElementVisibility();
                    break;
                case "room/bed":
                    ActualValue = _CVSMassetListPage.DetailsSummaryRoomBedLabel.GetElementVisibility();
                    break;
                case "asset tag":
                    ActualValue = _CVSMassetListPage.DetailsSummaryAssetTagLabel.GetElementVisibility();
                    break;
                case "connection status":
                    ActualValue = _CVSMassetListPage.DetailsSummaryConnectionStatusLabel.GetElementVisibility();
                    break;
                case "last configuration deployed":
                    ActualValue = _CVSMassetListPage.DetailsSummaryLastConfigurationDeployedLabel.GetElementVisibility();
                    break;
                case "last customization deployed":
                    ActualValue = _CVSMassetListPage.DetailsSummaryLastCustomizationDeployedLabel.GetElementVisibility();
                    break;

                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }

            ActualValue.Should().BeTrue(LabelName + " is not displayed");
        }

        [Then(@"Details Summary ""(.*)"" is ""(.*)""")]
        public void ThenDetailsSummaryIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "ip address":
                    ActualValue = _CVSMassetListPage.DetailsSummaryIPAddressValue.Text;
                    break;
                case "radio ip address":
                    ActualValue = _CVSMassetListPage.DetailsSummaryRadioIPAddressValue.Text;
                    break;
                case "ethernet mac address":
                    ActualValue = _CVSMassetListPage.DetailsSummaryEthernetMacAddressValue.Text;
                    break;
                case "model":
                    ActualValue = _CVSMassetListPage.DetailsSummaryModelValue.Text;
                    break;
                case "asset name":
                    ActualValue = _CVSMassetListPage.DetailsSummaryAssetNameValue.Text;
                    break;
                case "serial number":
                    ActualValue = _CVSMassetListPage.DetailsSummarySerialNumberValue.Text;
                    break;
                case "facility":
                    ActualValue = _CVSMassetListPage.DetailsSummaryFacilityValue.Text;
                    break;
                case "room/bed":
                    ActualValue = _CVSMassetListPage.DetailsSummaryRoomBedValue.Text;
                    break;
                case "location":
                    ActualValue = _CVSMassetListPage.DetailsSummaryLocationValue.Text;
                    break;
                case "asset tag":
                    ActualValue = _CVSMassetListPage.DetailsSummaryAssetTagValue.Text;
                    break;
                case "last configuration deployed":
                    ActualValue = _CVSMassetListPage.DetailsSummaryLastConfigurationDeployedValue.Text;
                    break;
                case "last customization deployed":
                    ActualValue = _CVSMassetListPage.DetailsSummaryLastCustomizationDeployedValue.Text;
                    break;

                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }

            ActualValue.Should().BeEquivalentTo(ExpectedValue, LabelName + " is not as expected.");
        }

        [Then(@"Details Summary ""(.*)"" is blank")]
        public void ThenDetailsSummaryIsBlank(string LabelName)
        {
            switch(LabelName.ToLower().Trim())
            {
                case "room/bed":
                    Assert.IsEmpty(_CVSMassetListPage.DetailsSummaryRoomBedValue.Text,LabelName+ " is not blank");
                    break;
                case "last customization deployed":
                    Assert.IsEmpty(_CVSMassetListPage.DetailsSummaryLastCustomizationDeployedValue.Text, LabelName + " is not blank");
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;

            }
        }

        [Then(@"Locate Asset button is displayed")]
        public void ThenLocateAssetButtonIsDisplayed()
        {
            _CVSMassetListPage.DetailsSummaryLocateAssetButton.GetElementVisibility().Should().BeTrue("Locate Asset Button is not displayed");
        }


    }
}
