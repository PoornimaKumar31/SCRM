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

namespace HillromAutomationFramework.Steps.ReportsTab
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5902")]
    public class Req5902Steps
    {
        private readonly LoginPage loginPage = new LoginPage();
        private readonly LandingPage landingPage = new LandingPage();
        private readonly MainPage mainPage = new MainPage();
        private readonly ReportsPage reportsPage = new ReportsPage();
        private readonly CSMConfigStatusPage csmConfigStatusPage = new CSMConfigStatusPage();

        private readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        private ScenarioContext _scenarioContext;

        public Req5902Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"user is on CSM CONFIGURATION UPDATE STATUS page")]
        public void GivenUserIsOnCSMCONFIGURATIONUPDATESTATUSPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.ReportsTab.JavaSciptClick();
            reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CSMDeviceName);
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.ConfigurationReportType);
            reportsPage.GetReportButton.Click();
        }
        
        [When(@"user type ""(.*)"" in search textbox")]
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
            csmConfigStatusPage.SearchBox.EnterText(SearchText);
        }
        
        [When(@"press enter")]
        public void WhenPressEnter()
        {
            csmConfigStatusPage.SearchBox.EnterText(Keys.Enter);
        }
        
        [Then(@"device with the matching ""(.*)"" is displayed")]
        public void ThenDeviceWithTheMatchingIsDisplayed(string searchType)
        {
            //wait till data is loaded
            Thread.Sleep(1000);

            IList<IWebElement> column=null;
            string ExpectedSearchText = "";

            switch(searchType.ToLower().Trim())
            {
                case "serial number":
                    column = csmConfigStatusPage.SerialNumberColumn;
                    ExpectedSearchText = CSMConfigStatusPage.ExpectedValues.SerialNumberSearchText;
                    break;

                case "configuration":
                    column = csmConfigStatusPage.ConfigurationColumn;
                    ExpectedSearchText = CSMConfigStatusPage.ExpectedValues.ConfigurationSearchText;
                    break;

                case "location":
                    column = csmConfigStatusPage.LocationColumn;
                    ExpectedSearchText = CSMConfigStatusPage.ExpectedValues.LocationSearchText;
                    break;

                case "status":
                    column = csmConfigStatusPage.StatusColumn;
                    ExpectedSearchText = CSMConfigStatusPage.ExpectedValues.StatusSearchText;
                    break;

                case "last deployed":
                    column = csmConfigStatusPage.LastDeployedColumn;
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
