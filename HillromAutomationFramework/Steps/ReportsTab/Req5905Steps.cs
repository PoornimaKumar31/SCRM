using FluentAssertions;
using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.ReportsTab
{
    [Binding, Scope(Tag = "SoftwareRequirementID_5905")]
    public sealed class Req5905Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        ReportsPage reportsPage = new ReportsPage();
        FirmwareStatusPage firmwareStatusPage = new FirmwareStatusPage();

        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        private readonly ScenarioContext _scenarioContext;

        public Req5905Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"user is on Centrella Firmware Upgrade Status Report page")]
        public void GivenUserIsOnCentrellaFirmwareUpgradeStatusReportPage()
        {
            //Loging in
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(landingPage.PSSServiceOrganizationFacilityBatesville, "Centrella Orgaization");
            landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.ReportsTab.JavaSciptClick();
            reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CentrellaDeviceName);
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareStatusReportType);
            reportsPage.GetReportButton.Click();
        }

        [Then(@"Search textbox displays ""(.*)""")]
        public void ThenSearchTextboxDisplays(string hintText)
        {
            Assert.IsTrue(firmwareStatusPage.SearchBox.GetElementVisibility(),"Search box is not displayed.");
            //Matching place holder value
            Assert.AreEqual(hintText.ToLower(), firmwareStatusPage.SearchBox.GetAttribute("placeholder").ToLower(), "Search box hint text does not match the expected value.");

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
            firmwareStatusPage.SearchBox.EnterText(searchText);
        }

        [When(@"presses Enter")]
        public void WhenPressesEnter()
        {
            firmwareStatusPage.SearchBox.EnterText(Keys.Enter);
        }

        [Then(@"devices with matching ""(.*)"" are displayed")]
        public void ThenDeviceWithMatchingIsDisplayed(string searchType)
        {
            //Wait till Data is loaded
            Thread.Sleep(1000);
            string ExpectedText = _scenarioContext.Get<string>("searchText");

            //Fetching data
            List<string> searchColumnElementList = firmwareStatusPage.GetColumnData(searchType);

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
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(landingPage.LNTAutomatedTestOrganizationFacilityTest1Title, "L&T Automated test Orgaization");
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));

            mainPage.ReportsTab.JavaSciptClick();
            reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CSMDeviceName);
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareStatusReportType);
            reportsPage.GetReportButton.Click();
        }



    }
}
