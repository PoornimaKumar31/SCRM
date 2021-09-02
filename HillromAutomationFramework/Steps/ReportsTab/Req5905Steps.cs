using FluentAssertions;
using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.ReportsTab
{
    [Binding, Scope(Tag = "SoftwareRequirementID_5905")]
    public sealed class Req5905Steps
    {
        private readonly LoginPage _loginPage ;
        private readonly LandingPage _landingPage ;
        private readonly MainPage _mainPage;
        private readonly ReportsPage _reportsPage;
        private readonly FirmwareStatusPage _firmwareStatusPage;

        private readonly WebDriverWait _wait;
        private readonly ScenarioContext _scenarioContext;

        public Req5905Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage();
            _landingPage = new LandingPage();
            _mainPage = new MainPage();
            _reportsPage = new ReportsPage();
            _firmwareStatusPage = new FirmwareStatusPage();
        }

        [Given(@"user is on Centrella Firmware Upgrade Status Report page")]
        public void GivenUserIsOnCentrellaFirmwareUpgradeStatusReportPage()
        {
            //Loging in
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(_landingPage.PSSServiceOrganizationFacilityBatesville, "Centrella Orgaization");
            _landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));

            _mainPage.ReportsTab.JavaSciptClick();
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CentrellaDeviceName);
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareStatusReportType);
            _reportsPage.GetReportButton.Click();
        }

        [Then(@"Search textbox displays ""(.*)""")]
        public void ThenSearchTextboxDisplays(string hintText)
        {
            (_firmwareStatusPage.SearchBox.GetElementVisibility()).Should().BeTrue("Search box should be displayed in Centrella Firmware Upgrade Status Report page");
            //Matching place holder value
            string ActualHintText = _firmwareStatusPage.SearchBox.GetAttribute("placeholder");
            ActualHintText.Should().BeEquivalentTo(hintText,because:"Search box hint text should match the expected string");
        }

        [When(@"user enters ""(.*)"" in Search textbox")]
        public void WhenUserEntersInSearchTextbox(string searchType)
        {
            bool flag=false;
            //Setting the Flag based on the device

            //Centrella
            if(_scenarioContext.ScenarioInfo.Title.ToLower().Contains("centrella"))
            {
                flag = true;
            }
            //CSM
            else if(_scenarioContext.ScenarioInfo.Title.ToLower().Contains("csm"))
            {
                flag = false;
            }
            //if secnario does not belong to any device
            else
            {
                Assert.Fail(_scenarioContext.ScenarioInfo.Title + " does not have step defination for " + _scenarioContext.StepContext.StepInfo.Text);
            }


            string searchText=null;
            switch(searchType.ToLower().Trim())
            {
                case "serial number":
                    searchText = flag?FirmwareStatusPage.ExpectedValues.CentrellaSerialNumberSearchText:FirmwareStatusPage.ExpectedValues.CSMSerialNumberSearchText;
                    break;
                case "firmware version":
                    searchText = flag?FirmwareStatusPage.ExpectedValues.CentrellaFirmwareVersionSearchText:FirmwareStatusPage.ExpectedValues.CSMFirmwareVersionSearchText;
                    break;
                case "status":
                    searchText = flag?FirmwareStatusPage.ExpectedValues.CentrellaStatusSearchText:FirmwareStatusPage.ExpectedValues.CSMStatusSearchText;
                    break;
                case "location":
                    searchText = flag?FirmwareStatusPage.ExpectedValues.CentrellaLocationSearchText:FirmwareStatusPage.ExpectedValues.CSMLocationSearchText;
                        break;
                case "last deployed":
                    searchText = flag?FirmwareStatusPage.ExpectedValues.CentrellaLastDeployedSearchText:FirmwareStatusPage.ExpectedValues.CSMLastDeployedSearchText;
                    break;
                    
                default:
                    Assert.Fail(searchType + " is a invalid search type.");
                    break;
            }
            

            //Adding search text to scenario context
            _scenarioContext.Add("searchText", searchText);

            //Enter the text in search box
            _firmwareStatusPage.SearchBox.EnterText(searchText);
        }

        [When(@"presses Enter")]
        public void WhenPressesEnter()
        {
            _firmwareStatusPage.SearchBox.EnterText(Keys.Enter);
        }

        [Then(@"devices with matching ""(.*)"" are displayed"), Then(@"device with matching ""(.*)"" are displayed")]
        public void ThenDeviceWithMatchingIsDisplayed(string searchType)
        {
            //Wait till Data is loaded
            Thread.Sleep(1000);
            string ExpectedText = _scenarioContext.Get<string>("searchText");

            //Fetching data
            List<string> searchColumnElementList = _firmwareStatusPage.GetColumnData(searchType);

            //Check if Search matches the expected
            foreach (string data in searchColumnElementList)
            {
                data.Should().ContainEquivalentOf(ExpectedText.ToLower(), "Serach result should contain only the matching " + searchType + ":" + ExpectedText);
            }
        }


        [Given(@"user is on CSM Firmware Upgrade Status Report page")]
        public void GivenUserIsOnCSMFirmwareUpgradeStatusReportPage()
        {
            //Loging in
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(_landingPage.LNTAutomatedTestOrganizationFacilityTest1Title, "L&T Automated test Orgaization");
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));

            _mainPage.ReportsTab.JavaSciptClick();
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CSMDeviceName);
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareStatusReportType);
            _reportsPage.GetReportButton.Click();
        }



    }
}
