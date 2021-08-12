using FluentAssertions;
using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.PageObjects.ReportsTab;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.ReportsTab
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5900")]
    public class Req5900Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        ReportsPage reportsPage = new ReportsPage();
        ActivityReportPage activityReportPage = new ActivityReportPage();

        private readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        private ScenarioContext _scenarioContext;

        public Req5900Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"user is on CSM ACTIVITY REPORT page")]
        public void GivenUserIsOnCSMACTIVITYREPORTPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.ReportsTab.JavaSciptClick();
            reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CSMDeviceName);
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.ActivityReportType);
            reportsPage.GetReportButton.Click();
        }
        
        [Then(@"Search Textbox displays ""(.*)""")]
        public void ThenSearchTextboxDisplays(string ExpectedsearchBoxHintText)
        {
            string ActualHintText = activityReportPage.SearchBox.GetAttribute("placeholder");
            ActualHintText.Should().BeEquivalentTo(ExpectedsearchBoxHintText.Trim(),"It displays hint text which is searchable.");
        }


        [When(@"press enter")]
        public void WhenPressEnter()
        {
            activityReportPage.SearchBox.EnterText(Keys.Enter);
        }

        [When(@"user type ""(.*)"" in search textbox")]
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

                case "last vital sent":
                    searchText = ActivityReportPage.ExpectedValues.LastVitalSentSearchText;
                    throw new PendingStepException("No data for the last vital sent.");

                default: Assert.Fail(searchType + " is a invalid search type");
                    break;
            }
            //entering the search text in the search box.
            activityReportPage.SearchBox.EnterText(searchText);
        }

        [Then(@"device with the matching ""(.*)"" is displayed")]
        public void ThenDeviceWithTheMatchingIsDisplayed(string searchType)
        {
            //wait till data is loaded
            Thread.Sleep(1000);
            string ExpectedSearchText = "";
            IList<IWebElement> column = null;
            switch (searchType.ToLower().Trim())
            {
                case "serial number":
                    column = activityReportPage.SerialNumberColumn;
                    ExpectedSearchText = ActivityReportPage.ExpectedValues.SerialNumberSearchText;
                    break;

                case "location":
                    column = activityReportPage.LocationColumn;
                    ExpectedSearchText = ActivityReportPage.ExpectedValues.LocationSearchText;
                    break;

                case "last vital sent":
                    column = activityReportPage.LastVitalSentColumn;
                    ExpectedSearchText = ActivityReportPage.ExpectedValues.LastVitalSentSearchText;
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
