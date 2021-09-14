using FluentAssertions;
using HillromAutomationFramework.PageObjects;
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
    [Binding,Scope(Tag = "SoftwareRequirementID_5902")]
    public class Req5902Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly ReportsPage _reportsPage;
        private readonly CSMConfigStatusPage _csmConfigStatusPage;

        private readonly WebDriverWait _wait;
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public Req5902Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
            _reportsPage = new ReportsPage(driver);
            _csmConfigStatusPage = new CSMConfigStatusPage(driver);
        }

        [Given(@"user is on CSM CONFIGURATION UPDATE STATUS page")]
        public void GivenUserIsOnCSMCONFIGURATIONUPDATESTATUSPage()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.ReportsTab.JavaSciptClick(_driver);
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CSMDeviceName);
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.ConfigurationReportType);
            _reportsPage.GetReportButton.Click();
        }
        
        [When(@"user enters ""(.*)"" in Search textbox")]
        public void WhenUserTypeInSearchTextbox(string searchType)
        {
            string SearchText = "";
            switch(searchType.ToLower().Trim())
            {
                case "serial number":
                    SearchText = CSMConfigStatusPage.ExpectedValues.SerialNumberSearchText;
                    break;

                case "configuration":
                    SearchText = CSMConfigStatusPage.ExpectedValues.ConfigurationSearchText;
                    break;

                case "location":
                    SearchText = CSMConfigStatusPage.ExpectedValues.LocationSearchText;
                    break;

                case "status":
                    SearchText = CSMConfigStatusPage.ExpectedValues.StatusSearchText;
                    break;

                case "last deployed":
                    SearchText = CSMConfigStatusPage.ExpectedValues.LastDeployedSearchText;
                    break;

                default: Assert.Fail(searchType + " is a invalid search type.");
                    break;
            }
            _csmConfigStatusPage.SearchBox.EnterText(SearchText);
        }
        
        [When(@"presses Enter")]
        public void WhenPressEnter()
        {
            _csmConfigStatusPage.SearchBox.EnterText(Keys.Enter);
        }
        
        [Then(@"device with matching ""(.*)"" is displayed")]
        public void ThenDeviceWithTheMatchingIsDisplayed(string searchType)
        {
            //wait till data is loaded
            Thread.Sleep(1000);

            IList<IWebElement> column=null;
            string ExpectedSearchText = "";

            switch(searchType.ToLower().Trim())
            {
                case "serial number":
                    column = _csmConfigStatusPage.SerialNumberColumn;
                    ExpectedSearchText = CSMConfigStatusPage.ExpectedValues.SerialNumberSearchText;
                    break;

                case "configuration":
                    column = _csmConfigStatusPage.ConfigurationColumn;
                    ExpectedSearchText = CSMConfigStatusPage.ExpectedValues.ConfigurationSearchText;
                    break;

                case "location":
                    column = _csmConfigStatusPage.LocationColumn;
                    ExpectedSearchText = CSMConfigStatusPage.ExpectedValues.LocationSearchText;
                    break;

                case "status":
                    column = _csmConfigStatusPage.StatusColumn;
                    ExpectedSearchText = CSMConfigStatusPage.ExpectedValues.StatusSearchText;
                    break;

                case "last deployed":
                    column = _csmConfigStatusPage.LastDeployedColumn;
                    ExpectedSearchText = CSMConfigStatusPage.ExpectedValues.LastDeployedSearchText;
                    break;

                default: Assert.Fail(searchType + " is a invalid search type.");
                    break;
            }

            //checking the no of results
            int noOfResults = column.GetElementCount();
            noOfResults.Should().BeGreaterThan(0, "Atleast one device should match the search result.");

            //checking the existance in search text in Acitivity table
            foreach (IWebElement row in column)
            {
                row.Text.Should().ContainEquivalentOf(ExpectedSearchText, "Only " + searchType + " matched should be displayed.");
            }
        }
    }
}
