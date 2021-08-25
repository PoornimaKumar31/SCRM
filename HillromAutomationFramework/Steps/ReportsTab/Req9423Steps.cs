using FluentAssertions;
using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.PageObjects.ReportsTab;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.ReportsTab
{
    [Binding, Scope(Tag = "SoftwareRequirementID_9423")]
    public class Req9423Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        ReportsPage reportsPage = new ReportsPage();
        ActivityReportPage activityReportPage = new ActivityReportPage();

        private ScenarioContext _scenarioContext;
        private WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

        public Req9423Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Given(@"user is on Reports page")]
        public void GivenUserIsOnReportsPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(landingPage.PSSServiceOrganizationFacilityBatesville, "Centrella Orgaization");
            landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.ReportsTab.JavaSciptClick();
        }
        
        [Given(@"Centrella Asset type is selected")]
        public void GivenCentrellaAssetTypeIsSelected()
        {
            reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CentrellaDeviceName);
        }
        
        [When(@"user clicks report type dropdown")]
        public void WhenUserClicksReportTypeDropdown()
        {
            reportsPage.ReportTypeDDL.Click();
        }
        
        [Then(@"Report type dropdown displays ""(.*)""")]
        public void ThenReportTypeDropdownDisplays(string ExpectedOptions)
        {
            List<string> ExpectedOptionList = new List<string>(ExpectedOptions.ToLower().Split(", "));
            List<string> ActualOptionList = new List<string>(reportsPage.ReportTypeDDL.GetAllOptionsFromDDL().Select(x => x.Text.ToLower()));
            //Removing hidden option
            ActualOptionList.Remove("select");
            //Asserting
            ActualOptionList.Should().BeEquivalentTo(ExpectedOptionList,"Expected Options are not same as Actual");
        }

        [Given(@"Activity Report type is selected")]
        public void GivenActivityReportTypeIsSelected()
        {
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.ActivityReportType);
        }

        [When(@"user clicks Get report button")]
        public void WhenUserClicksGetReportButton()
        {
            reportsPage.GetReportButton.Click();
        }

        [Then(@"Activity Report \(Centrella\) label is displayed")]
        public void ThenActivityReportCentrellaLabelIsDisplayed()
        {
            Assert.IsTrue(activityReportPage.ActivityReportHeader.GetElementVisibility(), "Activity Report (Centrella) label is not displayed.");
            Assert.AreEqual(ActivityReportPage.ExpectedValues.ActivityReportCentreallaHeader.ToLower(), activityReportPage.ActivityReportHeader.Text.ToLower(),"Activity report header is not matching the expected value.");
        }

        [Then(@"Print button is displayed")]
        public void ThenPrintButtonIsDisplayed()
        {
            Assert.IsTrue(activityReportPage.PrintButton.GetElementVisibility(),"Print button is not displayed.");
        }

        [Then(@"Download button is displayed")]
        public void ThenDownloadButtonIsDisplayed()
        {
            Assert.IsTrue(activityReportPage.DownloadButton.GetElementVisibility(), "Download button is not displayed.");
        }

        [Then(@"Search box is displayed")]
        public void ThenSearchBoxIsDisplayed()
        {
            Assert.IsTrue(activityReportPage.SearchBox.GetElementVisibility(), "Search box is not displayed.");
        }

        [Then(@"Previous page icon is displayed")]
        public void ThenPreviousPageIconIsDisplayed()
        {
            Assert.IsTrue(activityReportPage.PaginationPreviousPageIcon.GetElementVisibility(),"Previous page icon is not displayed.");
        }

        [Then(@"Next page icon is displayed")]
        public void ThenNextPageIconIsDisplayed()
        {
            Assert.IsTrue(activityReportPage.PaginationNextPageIcon.GetElementVisibility(),"Next page icon is not displayed.");
        }

        [Then(@"Page x of y indicator is displayed")]
        public void ThenPageXOfYIndicatorIsDisplayed()
        {
            Assert.IsTrue(activityReportPage.PaginationPageXofY.GetElementVisibility(),"Page x of y indicator is no displayed.");
        }

        [Then(@"Displaying x to y of z results indicator is displayed")]
        public void ThenDisplayingXToYOfZResultsIndicatorIsDisplayed()
        {
            Assert.IsTrue(activityReportPage.PaginationDisplayXY.GetElementVisibility(), "Display x to y of z results is not displayed.");
        }

        [Given(@"user is on Centrella Activity Report page")]
        public void GivenUserIsOnCentrellaActivityReportPage()
        {
            GivenUserIsOnReportsPage();
            //Selecting Centrella device
            reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CentrellaDeviceName);
            //Selecting the Activity Report
            reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.ActivityReportType);
            reportsPage.GetReportButton.Click();
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string columnHeading)
        {
            IWebElement column = null;
            string ExpectedColumnHeading = "";

            switch (columnHeading.ToLower().Trim())
            {
                case "serial number":
                    column = activityReportPage.SerialNumberHeading;
                    ExpectedColumnHeading = ActivityReportPage.ExpectedValues.SerialNumberHeadingText;
                    break;

                case "location":
                    column = activityReportPage.LocationHeading;
                    ExpectedColumnHeading = ActivityReportPage.ExpectedValues.LocationHeadingText;
                    break;

                case "last vital sent":
                    column = activityReportPage.LastVitalSentHeading;
                    ExpectedColumnHeading = ActivityReportPage.ExpectedValues.LastVitalSentHeadingText;
                    break;

                default:
                    Assert.Fail(columnHeading + " is a invalid heading name.");
                    break;
            }

            Assert.AreEqual(true, column.GetElementVisibility(), columnHeading + " is not displayed");
            Assert.AreEqual(ExpectedColumnHeading.ToLower(), column.Text.ToLower(), columnHeading + " is not matching with the expected value.");
        }

        [Then(@"""(.*)"" label is in column (.*)")]
        public void ThenLabelIsInColumn(string columnHeading, int columnNumber)
        {
            IList<IWebElement> columns = activityReportPage.TableHeading.FindElements(By.TagName("div"));
            Assert.AreEqual(columnHeading.ToLower().Trim(), columns[columnNumber - 1].Text.ToLower(), columnHeading + " is not in " + columnNumber);
        }


    }
}
