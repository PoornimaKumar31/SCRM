using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Main
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5687")]
    public class Req5687Steps
    {
        LoginPage loginPage = new LoginPage();
        MainPage mainPage = new MainPage();
        LandingPage landingPage = new LandingPage();

        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));


        [Given(@"user is on Assets List page with more than one ""(.*)""")]
        public void GivenUserIsOnAssetsListPageWithMoreThanOneDevice(string deviceName)
        {
            switch(deviceName.ToLower().Trim())
            {
                case "device":
                    loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
                    landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
                    break;
                case "csm":
                    loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
                    landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
                    break;
                case "cvsm":
                    loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
                    landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
                    break;
                case "rv700":
                    loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
                    landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.Click();
                    break;
                default: Assert.Fail("Invalid device name " + deviceName);
                    break;
            }
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
        }
        
        [Given(@"Asset type is All assets")]
        public void GivenAssetTypeIsAllAssets()
        {
            Assert.AreEqual(true, MainPage.ExpectedValues.AllAssetsText == mainPage.AssetTypeDropDown.GetSelectedOptionFromDDL(), "All assets is not displayed");
        }
        
        
        [When(@"user selects ""(.*)"" from Asset type dropdown")]
        public void WhenUserSelectsRVFromAssetTypeDropdown(string deviceName)
        {
           string Device = "";
           switch(deviceName.ToLower().Trim())
            {
                case "csm":
                    Device = MainPage.ExpectedValues.CSMDeviceName;
                    break;
                case "cvsm":
                    Device = MainPage.ExpectedValues.CVSMDeviceName;
                    break;
                case "rv700":
                    Device = MainPage.ExpectedValues.RV700DeviceName;
                    break;
                default:
                    Assert.Fail("Invalid device name " + deviceName);
                    break;
            }
            mainPage.AssetTypeDropDown.SelectDDL(Device);
            Thread.Sleep(1000);
        }

        [Then(@"all organization devices are displayed")]
        public void ThenAllOrganizationDevicesAreDisplayed()
        {
            int TotalRecords = mainPage.DeviceListRow.GetElementCount();
            Assert.AreEqual(true, MainPage.ExpectedValues.AllOrganizationsDevicesListWithRollUp == TotalRecords, "All Organization's devices are not displayed");
        }
        
        [Then(@"all organization ""(.*)"" devices are displayed")]
        public void ThenAllOrgnaizationRVDevicesAreDisplayed(string deviceName)
        {  
            int ExpectedDeviceCount=0;
            switch (deviceName.ToLower().Trim())
            {
                case "csm":
                    ExpectedDeviceCount = MainPage.ExpectedValues.AllOrgnaizationCSMDevicesCount;
                    break;
                case "cvsm":
                    ExpectedDeviceCount = MainPage.ExpectedValues.AllOrgnaizationCVSMDevicesCount;
                    break;
                case "rv700":
                    ExpectedDeviceCount = MainPage.ExpectedValues.AllOrgnaizationRV700DevicesCount;
                    break;
                default:
                    Assert.Fail("Invalid device name " + deviceName);
                    break;
            }
            int ActualDeviceCount = mainPage.DeviceListRow.GetElementCount();
            Assert.AreEqual(ExpectedDeviceCount, ActualDeviceCount,"All organization "+deviceName+" devices are not displayed");
        }
    }
}
