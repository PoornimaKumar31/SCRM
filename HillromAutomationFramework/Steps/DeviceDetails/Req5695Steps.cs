using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.PageObjects.Component_Information;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5695")]
    class Req5695Steps
    {

        LoginPage loginPage = new LoginPage();
        MainPage mainPage = new MainPage();
        LandingPage landingPage = new LandingPage();
        CVSMAssetListPage CVSMassetListPage = new CVSMAssetListPage();
        readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        private ScenarioContext _scenarioContext;
        public Req5695Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"user is on Asset List page with more than one CVSM")]
        public void GivenUserIsOnCVSMassetListPageWithMoreThanOneCVSM()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CVSMDeviceName);
            Assert.Greater(CVSMassetListPage.GetDeviceCount(), 2);
        }

        [When(@"user clicks any CVSM")]
        public void WhenUserClicksAnyCVSM()
        {
            Thread.Sleep(2000);
            mainPage.SearchSerialNumberAndClick("100020000001");
        }

        [Then(@"Asset Details landing page is displayed")]
        public void ThenAssetDetailsLandingPageIsDisplayed()
        {
            Assert.IsTrue(CVSMassetListPage.CVSMDetailsPage.GetElementVisibility(), "Asset Details Landing Page is not displayed");
        }

        [Then(@"Asset Detail summary subsection with Edit button is displayed")]
        public void ThenAssetDetailSummarySubsectionWithEditButtonIsDisplayed()
        {
            Assert.IsTrue(CVSMassetListPage.CVSMDetailsSummary.GetElementVisibility(), "CVSM details summary subsection is not displayed");
            Assert.IsTrue(CVSMassetListPage.EditButton.GetElementVisibility(),"Edit Button is not displayed");
        }

        [Then(@"Preventive Maintenance tab is displayed")]
        public void ThenPreventiveMaintenanceTabIsDisplayed()
        {
            Assert.IsTrue(CVSMassetListPage.PreventiveMaintenanceTab.GetElementVisibility(), "Preventive Mainetenance Tab is not displayed");
        }

        [Then(@"Component Information tab is displayed")]
        public void ThenComponentInformationTabIsDisplayed()
        {
            Assert.IsTrue(CVSMassetListPage.ComponentInformationTab.GetElementVisibility(), "Component information tab is not displayed");
        }

        [Then(@"Logs tab is displayed")]
        public void ThenLogsTabIsDisplayed()
        {
            Assert.IsTrue(CVSMassetListPage.LogsTab.GetElementVisibility(), "Logs tab is not displayed");
        }

        [Then(@"Asset Detail subsection is displayed")]
        public void ThenAssetDetailSubsectionIsDisplayed()
        {
            Assert.IsTrue(CVSMassetListPage.AssetDetailsSubsection.GetElementVisibility(), "Asset Details Subsection is not displayed");
        }

        [Given(@"user is on Component details page for CVSM Serial number ""(.*)""")]
        public void GivenUserIsOnComponentDetailsPageForCVSMSerialNumber(string SerialNumber)
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CVSMDeviceName);
            Assert.Greater(CVSMassetListPage.GetDeviceCount(), 2);
            Thread.Sleep(2000);
            mainPage.SearchSerialNumberAndClick(SerialNumber);
            CVSMassetListPage.ComponentInformationTab.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Battery ""(.*)"" is ""(.*)""")]
        public void ThenIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch(LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = CVSMassetListPage.BatteryName.Text;
                    break;
                case "manufacture date":
                    ActualValue = CVSMassetListPage.BatteryManufacturerDate.Text;
                    break;
                case "serial number":
                    ActualValue = CVSMassetListPage.BatterySerialNumber.Text;
                    break;
                case "cycle count":
                    ActualValue = CVSMassetListPage.BatteryCycleCount.Text;
                    break;
                case "temperature":
                    ActualValue = CVSMassetListPage.BatteryTemparatureValue.Text;
                    break;
                case "remaining capacity":
                    ActualValue = CVSMassetListPage.BatteryRemainingCapacityValue.Text;
                    break;
                case "voltage":
                    ActualValue = CVSMassetListPage.BatteryVoltageValue.Text;
                    break;
                case "full charge capacity":
                    ActualValue = CVSMassetListPage.BatteryFullChargeCapacityValue.Text;
                    break;
                case "current":
                    ActualValue = CVSMassetListPage.BatteryCurrentValue.Text;
                    break;
                case "avg time to empty":
                    ActualValue = CVSMassetListPage.BatteryAvgTimeEmptyValue.Text;
                    break;
                case "designed capacity":
                    ActualValue = CVSMassetListPage.BatteryDesignedCapacityValue.Text;
                    break;
                case "avg. time to full charge":
                    ActualValue = CVSMassetListPage.BatteryAvgTimeFullChargeValue.Text;
                    break;
                case "chemistry":
                    ActualValue = CVSMassetListPage.BatteryChemistryValue.Text;
                    break;
                case "model name":
                    ActualValue = CVSMassetListPage.BatteryModelNameValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " value is not as Expected Value");
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
                    ActualColumnIndex = CVSMassetListPage.BatteryElementList.IndexOf(CVSMassetListPage.BatteryCycleCount);
                    break;
                default:
                    Assert.Fail(LabelName+" is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedColumnIndex, ActualColumnIndex, LabelName + "is not in"+ColumnName);
        }

        [When(@"user clicks battery toggle arrow")]
        public void WhenUserClicksBatteryToggleArrow()
        {
            CVSMassetListPage.BatteryToggelArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Battery ""(.*)"" label is displayed")]
        public void ThenLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            bool ExpectedValue = true;
            switch(LabelName.ToLower().Trim())
            {
                case "temperature":
                    ActualValue = CVSMassetListPage.BatteryTemparatureLabel.GetElementVisibility();
                    break;
                case "remaining capacity":
                    ActualValue = CVSMassetListPage.BatteryRemainingCapacityLabel.GetElementVisibility();
                    break;
                case "voltage":
                    ActualValue = CVSMassetListPage.BatteryVoltageLabel.GetElementVisibility();
                    break;
                case "full charge capacity":
                    ActualValue = CVSMassetListPage.BatteryFullChargeCapacityLabel.GetElementVisibility();
                    break;
                case "current":
                    ActualValue = CVSMassetListPage.BatteryCurrentLabel.GetElementVisibility();
                    break;
                case "avg. time to empty":
                    ActualValue = CVSMassetListPage.BatteryAvgTimeEmptyLabel.GetElementVisibility();
                    break;
                case "designed capacity":
                    ActualValue = CVSMassetListPage.BatteryDesignedCapacityLabel.GetElementVisibility();
                    break;
                case "avg. time to full charge":
                    ActualValue = CVSMassetListPage.BatteryAvgTimeFullChargeLabel.GetElementVisibility();
                    break;
                case "chemistry":
                    ActualValue = CVSMassetListPage.BatteryChemistryLabel.GetElementVisibility();
                    break;
                case "model name":
                    ActualValue = CVSMassetListPage.BatteryModelNameLabel.GetElementVisibility();
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " label is not displayed");
        }


        [Then(@"Braun4000 ""(.*)"" is ""(.*)""")]
        public void ThenBraunIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = CVSMassetListPage.BraunNameValue.Text;
                    break;
                case "firmware version":
                    ActualValue = CVSMassetListPage.BraunFirmwareVersionValue.Text;
                    break;
                case "hardware version":
                    ActualValue = CVSMassetListPage.BraunHardwareVersionValue.Text;
                    break;
                case "cycle count":
                    ActualValue = CVSMassetListPage.BraunCycleCountValue.Text;
                    break;
                case "model number":
                    ActualValue = CVSMassetListPage.BraunModelNumberValue.Text;
                    break;
                case "serial number":
                    ActualValue = CVSMassetListPage.BraunSerialNumberValue.Text;
                    break;
                case "dock cycle count":
                    ActualValue = CVSMassetListPage.BraunDockCycleCountLabel.Text;
                    break;
            }
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
                    ActualColumnIndex = CVSMassetListPage.BraunElementList.IndexOf(CVSMassetListPage.BraunCycleCountValue);
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedColumnIndex, ActualColumnIndex, LabelName + " is not in " + ColumnName);
        }

        [When(@"user clicks Braun Pro 4000 toggle arrow")]
        public void WhenUserClicksBraunProToggleArrow()
        {
            CVSMassetListPage.BraunToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Braun4000 ""(.*)"" label is displayed")]
        public void ThenBraunLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            bool ExpectedValue = true;
            switch (LabelName.ToLower().Trim())
            {
                case "model number":
                    ActualValue = CVSMassetListPage.BraunModelNumberLabel.GetElementVisibility();
                    break;
                case "dock cycle count":
                    ActualValue = CVSMassetListPage.BraunDockCycleCountLabel.GetElementVisibility();
                    break;

                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;

            }

            Assert.AreEqual(ExpectedValue, ActualValue,LabelName+" is not as expected");
        }


        [Then(@"CO2 ""(.*)"" is ""(.*)""")]
        public void ThenCOIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = CVSMassetListPage.CO2Name.Text;
                    break;
                case "firmware version":
                    ActualValue = CVSMassetListPage.CO2FirmwareVersion.Text;
                    break;
                case "hardware version":
                    ActualValue = CVSMassetListPage.CO2HardwareVersion.Text;
                    break;
                case "serial number":
                    ActualValue = CVSMassetListPage.CO2SerialNumber.Text;
                    break;
                case "run time":
                    ActualValue = CVSMassetListPage.CO2RunTimeValue.Text;
                    break;

                case "hours to service":
                    ActualValue = CVSMassetListPage.CO2HoursToServiceValue.Text;
                    break;

                case "max hours to calibration":
                    ActualValue = CVSMassetListPage.CO2MaxHourToCalibrationValue.Text;
                    break;

                case "model number":
                    ActualValue = CVSMassetListPage.CO2ModelNumberValue.Text;
                    break;

                case "oem device label":
                    ActualValue = CVSMassetListPage.CO2OEMDeviceNameValue.Text;
                    break;

                case "oem serial number":
                    ActualValue = CVSMassetListPage.CO2OEMSerialNumberValue.Text;
                    break;

                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " value is not as expected");
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
                    ActualColumnIndex = CVSMassetListPage.CO2ElementList.IndexOf(CVSMassetListPage.CO2RunTime)-1;
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedColumnIndex, ActualColumnIndex, LabelName + " is not in " + ColumnName);
        }


        [When(@"user clicks CO2 sensor toggle arrow")]
        public void WhenCOUserClicksCOSensorToggleArrow()
        {
            CVSMassetListPage.CO2SensorToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"CO2 ""(.*)"" label is displayed")]
        public void ThenCOLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            bool ExpectedValue = true;
            switch (LabelName.ToLower().Trim())
            {
                case "hours to service":
                    ActualValue = CVSMassetListPage.CO2HoursToServiceLabel.GetElementVisibility();
                    break;
                case "max hours to calibration":
                    ActualValue = CVSMassetListPage.CO2MaxHourToCalibrationLabel.GetElementVisibility();
                    break;
                case "model number":
                    ActualValue = CVSMassetListPage.CO2ModelNumberLabel.GetElementVisibility();
                    break;
                case "oem device name":
                    ActualValue = CVSMassetListPage.CO2OEMDeviceNameLabel.GetElementVisibility();
                    break;
                case "oem serial number":
                    ActualValue = CVSMassetListPage.CO2OEMSerialNumberLabel.GetElementVisibility();
                    break;

                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;

            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " is not as expected");
        }

        [Then(@"Deluxe Comms ""(.*)"" is ""(.*)""")]
        public void ThenDeluxeCommsIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "serial number":
                    ActualValue = CVSMassetListPage.DeluxeSerialNumber.Text;
                    break;
                
                case "firmware version":
                    ActualValue = CVSMassetListPage.DeluxeFirmwareVersion.Text;
                    break;
          
                case "model number":
                    ActualValue = CVSMassetListPage.DeluxeModelNumberValue.Text;
                    break;

                default:
                    Assert.Fail(LabelName + " is Invalid.");
                    break;

            }
            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + "value is not as expected");
        }

            [When(@"user clicks Delux comms module toggle arrow")]
        public void WhenUserClicksDeluxCommsModuleToggleArrow()
        {
            CVSMassetListPage.DeluxeModuleToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Deluxe Comms ""(.*)"" label is displayed")]
        public void ThenDeluxeCommsLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            bool ExpectedValue = true;
            switch (LabelName.ToLower().Trim())
            {
                case "model number":
                    ActualValue = CVSMassetListPage.DeluxeModelNumberLabel.GetElementVisibility();
                    break;

                default:
                    Assert.Fail(LabelName + "is Invalid.");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " is not displayed");
        }


        [Then(@"NIBP ""(.*)"" is ""(.*)""")]
        public void ThenNIBPIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = CVSMassetListPage.NIBPName.Text;
                    break;
                case "firmware version":
                    ActualValue = CVSMassetListPage.NIBPFirmwareVersion.Text;
                    break;
                case "hardware version":
                    ActualValue = CVSMassetListPage.NIBPHardwareVersion.Text;
                    break;
                case "serial number":
                    ActualValue = CVSMassetListPage.NIBPSerialNumber.Text;
                    break;
                case "cycle count":
                    ActualValue = CVSMassetListPage.NIBPCycleCount.Text;
                    break;
                case "bootloader version":
                    ActualValue = CVSMassetListPage.NIBPBootloaderVersionValue.Text;
                    break;
                case "model number":
                    ActualValue = CVSMassetListPage.NIBPModelNumberValue.Text;
                    break;
                case "safety version":
                    ActualValue = CVSMassetListPage.NIBPSafetyVersionValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + "is Invalid.");
                    break;
            }
            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + "is not as expected.");
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
                    ActualColumnIndex = CVSMassetListPage.NIBPElementList.IndexOf(CVSMassetListPage.NIBPCycleCount);
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedColumnIndex, ActualColumnIndex, LabelName + " is not in " + ColumnName);
        
    }

        [When(@"user clicks NIBP sensor toggle arrow")]
        public void WhenUserClicksNIBPSensorToggleArrow()
        {
            CVSMassetListPage.NIBPSensorToggleButton.Click();
            Thread.Sleep(2000);
        }

        [Then(@"NIBP ""(.*)"" label is displayed")]
        public void ThenNIBPLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            bool ExpectedValue = true;
            switch (LabelName.ToLower().Trim())
            {
                case "cycle count":
                    ActualValue = CVSMassetListPage.NIBPCycleCount.GetElementVisibility();
                    break;
                case "bootloader version":
                    ActualValue = CVSMassetListPage.NIBPBootloaderVersionLabel.GetElementVisibility();
                    break;
                case "model number":
                    ActualValue = CVSMassetListPage.NIBPModelNumberLabel.GetElementVisibility();
                    break;

                case "safety version":
                    ActualValue = CVSMassetListPage.NIBPSafetyVersionLabel.GetElementVisibility();
                    break;

                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;

            }
            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " is not displayed");
        }


        [Then(@"Printer ""(.*)"" is ""(.*)""")]
        public void ThenPrinterIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = CVSMassetListPage.PrinterName.Text;
                    break;
                case "firmware version":
                    ActualValue = CVSMassetListPage.PrinterFirmwareVersion.Text;
                    break;
                case "model number":
                    ActualValue = CVSMassetListPage.PrinterModelNumberValue.Text;
                    break;
                case "serial number":
                    ActualValue = CVSMassetListPage.PrinterSerialNumber.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;

            }
            Assert.AreEqual(ExpectedValue, ActualValue,LabelName+ " is not as expected.");
        }

        [When(@"user clicks Printer toggle arrow")]
        public void WhenUserClicksPrinterToggleArrow()
        {
            CVSMassetListPage.PrinterToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Printer ""(.*)"" label is displayed")]
        public void ThenPrinterLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            bool ExpectedValue = true;
            switch (LabelName.ToLower().Trim())
            {
                case "model number":
                    ActualValue = CVSMassetListPage.PrinterModelNumberLabel.GetElementVisibility();
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }

            Assert.AreEqual(ActualValue, ExpectedValue, LabelName + " is not displayed");
        }


        [Then(@"Temp Probe ""(.*)"" is ""(.*)""")]
        public void ThenTempProbeIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = CVSMassetListPage.TempProbeName.Text;
                    break;
                case "usage value":
                    ActualValue = CVSMassetListPage.TempProbeUsageValue.Text;
                    break;
                case "model number":
                    ActualValue = CVSMassetListPage.TempProbeModelNumberValue.Text;
                    break;
                case "serial number":
                    ActualValue = CVSMassetListPage.TempProbeSerialNumber.Text;
                    break;
                case "probe type":
                    ActualValue = CVSMassetListPage.TempProbeProbeTypeValue.Text;
                    break;
                case "last device serial number":
                    ActualValue = CVSMassetListPage.TempProbeLastDeviceSerialNumberValue.Text;
                    break;
                case "number of times probe changed devices":
                    ActualValue = CVSMassetListPage.TempProbeNumberOfTimesProbeChangedDevicesValue.Text;
                    break;
                case "part number":
                    ActualValue = CVSMassetListPage.TempProbePartNumberValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;

            }
            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " is not as expected.");
        }

        [When(@"user clicks Temperature probe toggle arrow")]
        public void WhenUserClicksTemperatureProbeToggleArrow()
        {
            CVSMassetListPage.TempProbeToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Temp Probe ""(.*)"" label is displayed")]
        public void ThenTempProbeLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            bool ExpectedValue = true;
            switch (LabelName.ToLower().Trim())
            {
                case "model number":
                    ActualValue = CVSMassetListPage.TempProbeModelNumberLabel.GetElementVisibility();
                    break;
                case "probe type":
                    ActualValue = CVSMassetListPage.TempProbeProbeTypeLabel.GetElementVisibility();
                    break;
                case "last device serial number":
                    ActualValue = CVSMassetListPage.TempProbeLastDeviceSerialNumberLabel.GetElementVisibility();
                    break;
                case "number of times probe changed devices":
                    ActualValue = CVSMassetListPage.TempProbeNumberOfTimesProbeChangedDevicesLabel.GetElementVisibility();
                    break;
                case "part number":
                    ActualValue = CVSMassetListPage.TempProbePartNumberLabel.GetElementVisibility();
                    break;
                
                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }

            Assert.AreEqual(ActualValue, ExpectedValue, LabelName + " is not displayed");
        }


        [Then(@"Scale ""(.*)"" is ""(.*)""")]
        public void ThenScaleIs(string p0, string p1)
        {
            //waiting for automation IDs
            _scenarioContext.Pending();
        }


        [Then(@"Scale ""(.*)"" is displayed in ""(.*)"" column")]
        public void ThenScaleIsDisplayedInColumn(string p0, string p1)
        {
            //waiting for automation IDs
            _scenarioContext.Pending();
        }

        [When(@"user clicks Scale toggle arrow")]
        public void WhenUserClicksScaleToggleArrow()
        {
            //waiting for automation IDs
            _scenarioContext.Pending();
        }

        [Then(@"Scale ""(.*)"" label is displayed")]
        public void ThenScaleLabelIsDisplayed(string p0)
        {
            //waiting for automation IDs
            _scenarioContext.Pending();
        }

        [Then(@"spo2 ""(.*)"" is ""(.*)""")]
        public void ThenSpoIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = CVSMassetListPage.Spo2Name.Text;
                    break;
                case "firmware version":
                    ActualValue = CVSMassetListPage.Spo2FirmwareVersion.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid.");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " is not as expected.");
        }



        [Then(@"Masimo ""(.*)"" is ""(.*)""")]
        public void ThenMasimoIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = CVSMassetListPage.MasimoName.Text;
                    break;
                case "firmware version":
                    ActualValue = CVSMassetListPage.MasimoFirmwareVersion.Text;
                    break;
                case "hardware version":
                    ActualValue = CVSMassetListPage.MasimoHardwareVersion.Text;
                    break;
                case "serial number":
                    ActualValue = CVSMassetListPage.MasimoSerialNumber.Text;
                    break;
                case "usage value":
                    ActualValue = CVSMassetListPage.MasimoUsageValue.Text;
                    break;
                case "model number":
                    ActualValue = CVSMassetListPage.MasimoModelNumberValue.Text;
                    break;
                case "rra license value":
                    ActualValue = CVSMassetListPage.MasimoRraLicenceValue.Text;
                    break;
                case "sphb license value":
                    ActualValue = CVSMassetListPage.MasimoSpHbLicenseValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid.");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " is not as expected.");
        }

        [When(@"user clicks Masimo toggle arrow")]
        public void WhenUserClicksMasimoToggleArrow()
        {
            CVSMassetListPage.MasimoToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Masimo ""(.*)"" label is displayed")]
        public void ThenMasimoLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            bool ExpectedValue = true;
            switch (LabelName.ToLower().Trim())
            {
                case "model number":
                    ActualValue = CVSMassetListPage.MasimoModelNumberLabel.GetElementVisibility();
                    break;
                case "rra license":
                    ActualValue = CVSMassetListPage.MasimoRraLicenceLabel.GetElementVisibility();
                    break;
                case "sphb license":
                    ActualValue = CVSMassetListPage.MasimoSpHbLicenseLabel.GetElementVisibility();
                    break;

                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }

            Assert.AreEqual(ActualValue, ExpectedValue, LabelName + " is not displayed");
        }


        [Then(@"SPO2 Nellcor ""(.*)"" is ""(.*)""")]
        public void ThenSPONellcorIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = CVSMassetListPage.Spo2Name.Text;
                    break;
                case "firmware version":
                    ActualValue = CVSMassetListPage.Spo2FirmwareVersion.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid.");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " is not as expected.");
        }


        [Then(@"Nellcor ""(.*)"" is ""(.*)""")]
        public void ThenNellcorIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = CVSMassetListPage.NellcorName.Text;
                    break;
                case "firmware version":
                    ActualValue = CVSMassetListPage.NellcorFirmwareVersion.Text;
                    break;
                case "hardware version":
                    ActualValue = CVSMassetListPage.NellcorHardwareVersion.Text;
                    break;
                case "serial number":
                    ActualValue = CVSMassetListPage.NellcorSerialNumber.Text;
                    break;
                case "model number":
                    ActualValue = CVSMassetListPage.NellcorModelNumberValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid.");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " is not as expected.");
        }

        [When(@"user clicks Nellcor toggle arrow")]
        public void WhenUserClicksNellcorToggleArrow()
        {
            CVSMassetListPage.NellcorToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Nellcor ""(.*)"" label is displayed")]
        public void ThenNellcorLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            bool ExpectedValue = true;
            switch (LabelName.ToLower().Trim())
            {
                case "model number":
                    ActualValue = CVSMassetListPage.NellcorModelNumberLabel.GetElementVisibility();
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }

            Assert.AreEqual(ActualValue, ExpectedValue, LabelName + " is not displayed");
        }

        [Then(@"SureTemp ""(.*)"" is ""(.*)""")]
        public void ThenSureTempIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = CVSMassetListPage.SureTempName.Text;
                    break;
                case "firmware version":
                    ActualValue = CVSMassetListPage.SureTempFirmwareVersion.Text;
                    break;
                case "hardware version":
                    ActualValue = CVSMassetListPage.SureTempHardwareVersion.Text;
                    break;
                case "serial number":
                    ActualValue = CVSMassetListPage.SureTempSerialNumber.Text;
                    break;
                case "usage value":
                    ActualValue = CVSMassetListPage.SureTempUsageValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid.");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " is not as expected.");
        }

        [Then(@"Radio Lamarr ""(.*)"" is ""(.*)""")]
        public void ThenRadioLamarrIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = CVSMassetListPage.RadioLamarrName.Text;
                    break;
                case "access point mac address":
                    ActualValue = CVSMassetListPage.RadioLamarrAPMACAddressValue.Text;
                    break;
                case "radio ip Address":
                    ActualValue = CVSMassetListPage.RadioLamarrRadioIPAddressValue.Text;
                    break;
                case "serial number":
                    ActualValue = CVSMassetListPage.RadioLamarrSerialNumber.Text;
                    break;
                case "usage value":
                    ActualValue = CVSMassetListPage.RadioLamarrUsageValue.Text;
                    break;
                case "mac address":
                    ActualValue = CVSMassetListPage.RadioLamarrMacAddressValue.Text;
                    break;
                case "model number":
                    ActualValue = CVSMassetListPage.RadioLamarrModelNumberValue.Text;
                    break;
                case "rssi":
                    ActualValue = CVSMassetListPage.RadioLamarrRSSIvalue.Text;
                    break;
                case "server version":
                    ActualValue = CVSMassetListPage.RadioLamarrServerVersionValue.Text;
                    break;
                case "ssid":
                    ActualValue = CVSMassetListPage.RadioLamarrSSIDValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid.");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " is not as expected.");
        }


        [When(@"user clicks Radio-Lamarr toggle arrow")]
        public void WhenUserClicksRadio_LamarrToggleArrow()
        {
            CVSMassetListPage.RadioLamarrToggleArrow.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Radio Lamarr ""(.*)"" label is displayed")]
        public void ThenRadioLamarrLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            bool ExpectedValue = true;
            switch (LabelName.ToLower().Trim())
            {
                case "access point mac address":
                    ActualValue = CVSMassetListPage.RadioLamarrAPMACAddressLabel.GetElementVisibility();
                    break;
                case "radio ip address":
                    ActualValue = CVSMassetListPage.RadioLamarrRadioIPAddressLabel.GetElementVisibility();
                    break;
                case "mac address":
                    ActualValue = CVSMassetListPage.RadioLamarrMacAddressLabel.GetElementVisibility();
                    break;
                case "model number":
                    ActualValue = CVSMassetListPage.RadioLamarrModelNumberLabel.GetElementVisibility();
                    break;
                case "rssi":
                    ActualValue = CVSMassetListPage.RadioLamarrRSSILabel.GetElementVisibility();
                    break;
                case "server version":
                    ActualValue = CVSMassetListPage.RadioLamarrServerVersionLabel.GetElementVisibility();
                    break;
                case "ssid":
                    ActualValue = CVSMassetListPage.RadioLamarrSSIDLabel.GetElementVisibility();
                    break;

                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }

            Assert.AreEqual(ActualValue, ExpectedValue, LabelName + " is not displayed");
        }


        [Then(@"Radio Newmar ""(.*)"" is ""(.*)""")]
        public void ThenRadioNewmarIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = CVSMassetListPage.RadioNewmarName.Text;
                    break;
                case "access point mac address":
                    ActualValue = CVSMassetListPage.RadioNewmarApMacAddressValue.Text;
                    break;
                case "radio ip Address":
                    ActualValue = CVSMassetListPage.RadioNewmarRadioIpAddressValue.Text;
                    break;
                case "serial number":
                    ActualValue = CVSMassetListPage.RadioNewmarSerialNUmber.Text;
                    break;
                case "firmware version":
                    ActualValue = CVSMassetListPage.RadioNewmarFirmwareVersion.Text;
                    break;
                case "mac address":
                    ActualValue = CVSMassetListPage.RadioNewmarMacAddressValue.Text;
                    break;
                case "model number":
                    ActualValue = CVSMassetListPage.RadioNewmarModelNumberValue.Text;
                    break;
                case "rssi":
                    ActualValue = CVSMassetListPage.RadioNewmarRssiValue.Text;
                    break;
                case "server version":
                    ActualValue = CVSMassetListPage.RadioNewmarServerVersionValue.Text;
                    break;
                case "ssid":
                    ActualValue = CVSMassetListPage.RadioNewmarSsidValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid.");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " is not as expected.");
        }

        [When(@"user clicks Radio-Newmar toggle arrow")]
        public void WhenUserClicksRadio_NewmarToggleArrow()
        {
            CVSMassetListPage.RadioNewmarToggleArrow.Click();
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
                    ActualValue = CVSMassetListPage.RadioNewmarApMacAddressLabel.GetElementVisibility();
                    break;
                case "radio ip address":
                    ActualValue = CVSMassetListPage.RadioNewmarRadioIpAddressLabel.GetElementVisibility();
                    break;
                case "mac address":
                    ActualValue = CVSMassetListPage.RadioNewmarMacAddressLabel.GetElementVisibility();
                    break;
                case "model number":
                    ActualValue = CVSMassetListPage.RadioNewmarModelNumberLabel.GetElementVisibility();
                    break;
                case "rssi":
                    ActualValue = CVSMassetListPage.RadioNewmarRssiLabel.GetElementVisibility();
                    break;
                case "server version":
                    ActualValue = CVSMassetListPage.RadioNewmarServerVersionLabel.GetElementVisibility();
                    break;
                case "ssid":
                    ActualValue = CVSMassetListPage.RadioNewmarSsidLabel.GetElementVisibility();
                    break;

                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }

            Assert.AreEqual(ActualValue, ExpectedValue, LabelName + " is not displayed");
        }



        [Then(@"Connex Device ""(.*)"" is ""(.*)""")]
        public void ThenConnexDeviceIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = CVSMassetListPage.ConnexName.Text;
                    break;
                case "serial number":
                    ActualValue = CVSMassetListPage.ConnexSerialNumber.Text;
                    break;
                case "device hours on":
                    ActualValue = CVSMassetListPage.ConnexDeviceHoursValue.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid.");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " is not as expected.");
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
                    ActualColumnIndex = CVSMassetListPage.ConnexElementList.IndexOf(CVSMassetListPage.ConnexUsage);
                    break;
                default:
                    Assert.Fail(LabelName + " is invalid");
                    break;
            }

            Assert.AreEqual(ExpectedColumnIndex, ActualColumnIndex, LabelName + "is not in" + ColumnName);
        }

        [Then(@"Host Controller ""(.*)"" is ""(.*)""")]
        public void ThenHostControllerIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "name":
                    ActualValue = CVSMassetListPage.HostControllerName.Text;
                    break;
                case "serial number":
                    ActualValue = CVSMassetListPage.HostControllerSerialNumber.Text;
                    break;
                case "firmware version":
                    ActualValue = CVSMassetListPage.HostControllerFirmwareVersion.Text;
                    break;
                case "hardware version":
                    ActualValue = CVSMassetListPage.HostControllerHardwareVersion.Text;
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid.");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " is not as expected.");
        }

        [Then(@"Details Summary CVSM image is displayed")]
        public void ThenDetailsSummaryCVSMImageIsDisplayed()
        {
            Assert.IsTrue(CVSMassetListPage.DetailsSummaryCVSMImage.GetElementVisibility(), "CVSM Image is not displayed");
        }

        [Then(@"Details Summary ""(.*)"" label is displayed")]
        public void ThenDetailsSummaryLabelIsDisplayed(string LabelName)
        {
            bool ActualValue = false;
            bool ExpectedValue = true;
            switch (LabelName.ToLower().Trim())
            {
                case "ip address":
                    ActualValue = CVSMassetListPage.DetailsSummaryIPAddressLabel.GetElementVisibility();
                    break;
                case "radio ip address":
                    ActualValue = CVSMassetListPage.DetailsSummaryRadioIPAddressLabel.GetElementVisibility();
                    break;
                case "ethernet mac address":
                    ActualValue = CVSMassetListPage.DetailsSummaryEthernetMacAddressLabel.GetElementVisibility();
                    break;
                case "model":
                    ActualValue = CVSMassetListPage.DetailsSummaryModelLabel.GetElementVisibility();
                    break;
                case "asset name":
                    ActualValue = CVSMassetListPage.DetailsSummaryAssetNameLabel.GetElementVisibility();
                    break;
                case "serial number":
                    ActualValue = CVSMassetListPage.DetailsSummarySerialNumberLabel.GetElementVisibility();
                    break;
                case "facility":
                    ActualValue = CVSMassetListPage.DetailsSummaryFacilityLabel.GetElementVisibility();
                    break;
                case "location":
                    ActualValue = CVSMassetListPage.DetailsSummaryLocationLabel.GetElementVisibility();
                    break;
                case "room/bed":
                    ActualValue = CVSMassetListPage.DetailsSummaryRoomBedLabel.GetElementVisibility();
                    break;
                case "asset tag":
                    ActualValue = CVSMassetListPage.DetailsSummaryAssetTagLabel.GetElementVisibility();
                    break;
                case "connection status":
                    ActualValue = CVSMassetListPage.DetailsSummaryConnectionStatusLabel.GetElementVisibility();
                    break;
                case "last configuration deployed":
                    ActualValue = CVSMassetListPage.DetailsSummaryLastConfigurationDeployedLabel.GetElementVisibility();
                    break;
                case "last customization deployed":
                    ActualValue = CVSMassetListPage.DetailsSummaryLastCustomizationDeployedLabel.GetElementVisibility();
                    break;

                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }

            Assert.AreEqual(ActualValue, ExpectedValue, LabelName + " is not displayed");
        }

        [Then(@"Details Summary ""(.*)"" is ""(.*)""")]
        public void ThenDetailsSummaryIs(string LabelName, string ExpectedValue)
        {
            string ActualValue = null;
            switch (LabelName.ToLower().Trim())
            {
                case "ip address":
                    ActualValue = CVSMassetListPage.DetailsSummaryIPAddressValue.Text;
                    break;
                case "radio ip address":
                    ActualValue = CVSMassetListPage.DetailsSummaryRadioIPAddressValue.Text;
                    break;
                case "ethernet mac address":
                    ActualValue = CVSMassetListPage.DetailsSummaryEthernetMacAddressValue.Text;
                    break;
                case "model":
                    ActualValue = CVSMassetListPage.DetailsSummaryModelValue.Text;
                    break;
                case "asset name":
                    ActualValue = CVSMassetListPage.DetailsSummaryAssetNameValue.Text;
                    break;
                case "serial number":
                    ActualValue = CVSMassetListPage.DetailsSummarySerialNumberValue.Text;
                    break;
                case "facility":
                    ActualValue = CVSMassetListPage.DetailsSummaryFacilityValue.Text;
                    break;
                case "room/bed":
                    ActualValue = CVSMassetListPage.DetailsSummaryRoomBedValue.Text;
                    break;
                case "location":
                    ActualValue = CVSMassetListPage.DetailsSummaryLocationValue.Text;
                    break;
                case "asset tag":
                    ActualValue = CVSMassetListPage.DetailsSummaryAssetTagValue.Text;
                    break;
                case "connection status":
                    IList<IWebElement> TextList = CVSMassetListPage.DetailsSummaryConnectionStatusValue.FindElements(By.TagName("b"));
                    ActualValue = "";
                    foreach (IWebElement element in TextList)
                    {
                        ActualValue = ActualValue + element.Text;
                    }
                    break;
                case "last configuration deployed":
                    ActualValue = CVSMassetListPage.DetailsSummaryLastConfigurationDeployedValue.Text;
                    break;
                case "last customization deployed":
                    ActualValue = CVSMassetListPage.DetailsSummaryLastCustomizationDeployedValue.Text;
                    break;

                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;
            }

            Assert.AreEqual(ExpectedValue, ActualValue, LabelName + " is not as expected.");
        }

        [Then(@"Details Summary ""(.*)"" is blank")]
        public void ThenDetailsSummaryIsBlank(string LabelName)
        {
            switch(LabelName.ToLower().Trim())
            {
                case "room/bed":
                    Assert.IsEmpty(CVSMassetListPage.DetailsSummaryRoomBedValue.Text,LabelName+ " is not blank");
                    break;
                case "last customization deployed":
                    Assert.IsEmpty(CVSMassetListPage.DetailsSummaryLastCustomizationDeployedValue.Text, LabelName + " is not blank");
                    break;
                default:
                    Assert.Fail(LabelName + " is Invalid");
                    break;

            }
        }

        [Then(@"Locate Asset button is displayed")]
        public void ThenLocateAssetButtonIsDisplayed()
        {
            Assert.IsTrue(CVSMassetListPage.DetailsSummaryLocateAssetButton.GetElementVisibility(), "Locate Asset Button is not displayed");
        }


    }
}
