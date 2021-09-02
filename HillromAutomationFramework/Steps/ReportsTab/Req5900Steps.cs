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

        public Req5900Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
            _loginPage = new LoginPage();
            _landingPage = new LandingPage();
            _mainPage = new MainPage();
            _reportsPage = new ReportsPage();
            _activityReportPage = new ActivityReportPage();  
        }

        [Given(@"user is on CSM ACTIVITY REPORT page")]
        public void GivenUserIsOnCSMACTIVITYREPORTPage()
        {
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));

            _mainPage.ReportsTab.JavaSciptClick();
            _reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CSMDeviceName);
            _reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.ActivityReportType);
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
            switch(searchType.ToLower().Trim())
            {
                case "serial number":
                    searchText = ActivityReportPage.ExpectedValues.SerialNumberSearchText;
                    break;

                case "location":
                    searchText = ActivityReportPage.ExpectedValues.LocationSearchText;
                    break;

                default: Assert.Fail(searchType + " is a invalid search type");
                    break;
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
            switch (searchType.ToLower().Trim())
            {
                case "serial number":
                    column = _activityReportPage.SerialNumberColumn;
                    ExpectedSearchText = ActivityReportPage.ExpectedValues.SerialNumberSearchText;
                    break;

                case "location":
                    column = _activityReportPage.LocationColumn;
                    ExpectedSearchText = ActivityReportPage.ExpectedValues.LocationSearchText;
                    break;

                default: Assert.Fail(searchType + " is invalid search type.");
                    break;
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



    }
}
