using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AssetsTab;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.AssetsTab
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5687")]
    public class Req5687Steps
    {
        private readonly LoginPage loginPage;
        private readonly LandingPage landingPage;
        private readonly MainPage mainPage;

        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverWait _wait;

        public Req5687Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            loginPage = new LoginPage(driver);
            landingPage = new LandingPage(driver);
            mainPage = new MainPage(driver);
        }


        [Given(@"user is on Assets List page with more than one ""(.*)""")]
        public void GivenUserIsOnAssetsListPageWithMoreThanOneDevice(string deviceName)
        {
            loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            switch (deviceName.ToLower().Trim())
            {
                case "device":
                    landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.ClickWebElement(_driver);
                    break;
                case "csm":
                    landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.ClickWebElement(_driver);
                    break;
                case "cvsm":
                    landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.ClickWebElement(_driver);
                    break;
                case "rv700":
                    landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.ClickWebElement(_driver);
                    break;
                case "centrella":
                    landingPage.PSSServiceOrganizationFacilityBatesville.ClickWebElement(_driver);
                    break;
                default: Assert.Fail("Invalid device name " + deviceName);
                    break;
            }
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
        }
        
        [Given(@"Asset type is All assets")]
        public void GivenAssetTypeIsAllAssets()
        {
            Assert.AreEqual(true, MainPageExpectedValue.AllAssetsText == mainPage.AssetTypeDropDown.GetSelectedOptionFromDDL(), "All assets is not displayed");
        }
        
        
        [When(@"user selects ""(.*)"" from Asset type dropdown")]
        public void WhenUserSelectsRVFromAssetTypeDropdown(string deviceName)
        {
           string Device = "";
           switch(deviceName.ToLower().Trim())
            {
                case "csm":
                    Device = MainPageExpectedValue.CSMDeviceName;
                    break;
                case "cvsm":
                    Device = MainPageExpectedValue.CVSMDeviceName;
                    break;
                case "rv700":
                    Device = MainPageExpectedValue.RV700DeviceName;
                    break;
                case "centrella":
                    Device = MainPageExpectedValue.CentrellaDeviceName;
                    break;
                default:
                    Assert.Fail("Invalid device name " + deviceName);
                    break;
            }
            mainPage.AssetTypeDropDown.SelectDDL(Device);
            Thread.Sleep(3000);
        }

        [Then(@"all organization devices are displayed")]
        public void ThenAllOrganizationDevicesAreDisplayed()
        {
            int TotalRecords = mainPage.DeviceListRow.GetElementCount();
            Assert.AreEqual(int.Parse(MainPageExpectedValue.AllOrganizationsDevicesListWithRollUp), TotalRecords, "All Organization's devices are not displayed");
        }
        
        [Then(@"all organization ""(.*)"" devices are displayed")]
        public void ThenAllOrgnaizationRVDevicesAreDisplayed(string DeviceName)
        {  
            //Getting the list of Device type
            List<string> DeviceList = mainPage.GetColumnData("Type");

            for (int i = 0; i < DeviceList.Count; i++)
            {
                DeviceList[i] = (DeviceList[i]).ToLower();
            }

            List<string> DeviceListLowerCase = new List<string>(DeviceList.Select(deviceType => deviceType.ToLower()));

            //Asserting
            DeviceListLowerCase.Should().AllBe(DeviceName.ToLower());
        }
    }
}
