using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.ReportsTab;
using HillromAutomationFramework.SupportingCode;
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
    [Binding,Scope(Tag = "SoftwareRequirementID_5900")]
    public class Req5900Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly ReportsPage _reportsPage;
        private readonly ActivityReportPage _activityReportPage;

        private readonly WebDriverWait _wait;
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public Req5900Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
            _reportsPage = new ReportsPage(driver);
            _activityReportPage = new ActivityReportPage(driver);
        }

        [Given(@"user is on CSM ACTIVITY REPORT page")]
        public void GivenUserIsOnCSMACTIVITYREPORTPage()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));

            _mainPage.ReportsTab.JavaSciptClick(_driver);
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPageExpectedValues.CSMDeviceName);
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.ActivityReportType);
            _reportsPage.GetReportButton.Click();
        }
        
        [Then(@"Search Textbox displays ""(.*)""")]
        public void ThenSearchTextboxDisplays(string ExpectedsearchBoxHintText)
        {
            string ActualHintText = _activityReportPage.SearchBox.GetAttribute("placeholder");
            ActualHintText.Should().BeEquivalentTo(ExpectedsearchBoxHintText.Trim(),"It displays hint text which is searchable.");
        }


        [When(@"presses Enter")]
        public void WhenPressesEnter()
        {
            _activityReportPage.SearchBox.EnterText(Keys.Enter);
        }

        [When(@"user enters ""(.*)"" in Search textbox")]
        public void WhenUserTypeInSearchTextbox(string searchType)
        {
            string searchText = "";
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("csm"))
            {
                switch (searchType.ToLower().Trim())
                {
                    case "serial number":
                        searchText = ActivityReportPageExpectedValues.SerialNumberSearchText;
                        break;

                    case "location":
                        searchText = ActivityReportPageExpectedValues.LocationSearchText;
                        break;

                    default:
                        Assert.Fail(searchType + " is a invalid search type");
                        break;
                }
            }

            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("cvsm"))
            {
                switch (searchType.ToLower().Trim())
                {
                    case "serial number":
                        searchText = ActivityReportPageExpectedValues.CVSMSerialNumberSearchText;
                        break;

                    case "ownership unit":
                        searchText = ActivityReportPageExpectedValues.CVSMLocationSearchText;
                        break;

                    default:
                        Assert.Fail(searchType + " is a invalid search type");
                        break;
                }
            }

            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("centrella"))
            {
                switch (searchType.ToLower().Trim())
                {
                    case "serial number":
                        searchText = ActivityReportPageExpectedValues.CentrellaSerialNumberSearchText;
                        break;

                    default:
                        Assert.Fail(searchType + " is a invalid search type");
                        break;
                }

            }

            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("progressa"))
            {
                switch (searchType.ToLower().Trim())
                {
                    case "serial number":
                        searchText = ActivityReportPageExpectedValues.ProgressaSerialNumberSearchText;
                        break;

                    default:
                        Assert.Fail(searchType + " is a invalid search type");
                        break;
                }

            }
            //entering the search text in the search box.
            _activityReportPage.SearchBox.EnterText(searchText);
        }

        [Then(@"device with matching ""(.*)"" is displayed")]
        public void ThenDeviceWithTheMatchingIsDisplayed(string searchType)
        {
            //wait till data is loaded
            Thread.Sleep(1000);
            string ExpectedSearchText = "";
            IList<IWebElement> column = null;
            if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("csm"))
            {
                switch (searchType.ToLower().Trim())
                {
                    case "serial number":
                        column = _activityReportPage.SerialNumberColumn;
                        ExpectedSearchText = ActivityReportPageExpectedValues.SerialNumberSearchText;
                        break;

                    case "location":
                        column = _activityReportPage.LocationColumn;
                        ExpectedSearchText = ActivityReportPageExpectedValues.LocationSearchText;
                        break;

                    default:
                        Assert.Fail(searchType + " is invalid search type.");
                        break;
                }
            }
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("cvsm"))
            {
                switch (searchType.ToLower().Trim())
                {
                    case "serial number":
                        column = _activityReportPage.SerialNumberColumn;
                        ExpectedSearchText = ActivityReportPageExpectedValues.CVSMSerialNumberSearchText;
                        break;

                    case "ownership unit":
                        column = _activityReportPage.LocationColumn;
                        ExpectedSearchText = ActivityReportPageExpectedValues.CVSMLocationSearchText;
                        break;

                    default:
                        Assert.Fail(searchType + " is invalid search type.");
                        break;
                }
            }
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("centrella"))
            {
                switch (searchType.ToLower().Trim())
                {
                    case "serial number":
                        column = _activityReportPage.SerialNumberColumn;
                        ExpectedSearchText = ActivityReportPageExpectedValues.CentrellaSerialNumberSearchText;
                        break;

                    default:
                        Assert.Fail(searchType + " is invalid search type.");
                        break;
                }
            }
            else if (_scenarioContext.ScenarioInfo.Title.ToLower().Contains("progressa"))
            {
                switch (searchType.ToLower().Trim())
                {
                    case "serial number":
                        column = _activityReportPage.SerialNumberColumn;
                        ExpectedSearchText = ActivityReportPageExpectedValues.ProgressaSerialNumberSearchText;
                        break;

                    default:
                        Assert.Fail(searchType + " is invalid search type.");
                        break;
                }
            }
            //checking the no of results
            int noOfResults = column.GetElementCount();
            noOfResults.Should().BeGreaterThan(0, "Atleast one device should match the search result.");

            //checking the existance in search text in Acitivity table
            foreach (IWebElement row in column)
            {
                row.Text.Should().ContainEquivalentOf(ExpectedSearchText, "Only "+searchType +" matched should be displayed.");
            }
        }

        [Given(@"user is on CVSM ACTIVITY REPORT page")]
        public void GivenUserIsOnCVSMACTIVITYREPORTPage()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));

            _mainPage.ReportsTab.JavaSciptClick(_driver);
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPageExpectedValues.CVSMDeviceName);
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.ActivityReportType);
            _reportsPage.GetReportButton.Click();
        }

        [Given(@"user is on Centrella Activity Report page")]
        public void GivenUserIsOnCentrellaACTIVITYREPORTPage()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(_landingPage.PSSServiceOrganizationFacilityBatesville, _driver, "Centrella Orgaization");
            _landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));

            _mainPage.ReportsTab.JavaSciptClick(_driver);
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPageExpectedValues.CentrellaDeviceName);
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.ActivityReportType);
            _reportsPage.GetReportButton.Click();
        }

        [Given(@"user is on Progressa Activity Report page")]
        public void GivenUserIsOnProgressaACTIVITYREPORTPage()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(_landingPage.PSSServiceOrganizationFacilityBatesville, _driver, "Progressa Orgaization");
            _landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));

            _mainPage.ReportsTab.JavaSciptClick(_driver);
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPageExpectedValues.ProgressaDeviceName);
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPageExpectedValues.ActivityReportType);
            _reportsPage.GetReportButton.Click();
        }
    }
}
