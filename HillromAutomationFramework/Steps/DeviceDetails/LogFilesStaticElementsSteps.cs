﻿using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Main
{
    [Binding,Scope(Tag = "TestCaseID_8953")]
    public class LogFilesStaticElementsSteps
    {
        private ScenarioContext _scenarioContext;

        public LogFilesStaticElementsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        LoginPage loginPage = new LoginPage();
        LogFilesStaticElements logFilesStaticElements = new LogFilesStaticElements();
        MainPage mainPage = new MainPage();
        CVSMDeviceDetailsPage cvsmDeviceDetailsPage = new CVSMDeviceDetailsPage();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        [Given(@"user has selected any device")]
        public void GivenUserHasSelectedAnyDevice()
        {
            
            loginPage.LogIn(LoginPage.LogInType.AdminWithOutRollUpPage);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.SearchSerialNumberAndClick("100020000001");

        }

        [Given(@"user is on Device Details page")]
        public void GivenUserIsOnMainPage()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.EditButton.GetElementVisibility());
        }

        [When(@"user clicks Logs tab")]
        public void WhenUserClicksLogsTab()
        {
            cvsmDeviceDetailsPage.LogsTab.Click();
        }

        [Then(@"Log Files label is displayed")]
        public void ThenLogFilesLabelIsDisplayed()
        {
            Assert.AreEqual(true, logFilesStaticElements.LogFilesLabel.GetElementVisibility(), "Logs label is not diplayed");
        }

        [Then(@"Request Logs button is displayed")]
        public void ThenRequestLogsButtonIsDisplayed()
        {
            Assert.AreEqual(true, logFilesStaticElements.RequestLogsButton.GetElementVisibility(), "Request Logs button is not displayed");
        }

        [Then(@"Name column heading is displayed")]
        public void ThenNameColumnHeadingIsDisplayed()
        {
            Assert.AreEqual(true, logFilesStaticElements.NameColumn.GetElementVisibility(), "Name column is not displayed");
        }

        [Then(@"Date column heading is displayed")]
        public void ThenDateColumnHeadingIsDisplayed()
        {
            Assert.AreEqual(true, logFilesStaticElements.DateColumn.GetElementVisibility(), "Date Column is not displayed");
        }

        [Then(@"date sorting indicator is displayed")]
        public void ThenDateSortingIndicatorIsDisplayed()
        {
            Assert.AreEqual(true, logFilesStaticElements.DateSortingIndicator.GetElementVisibility(), "Date sorting indicator is not displayed");
        }

        [Then(@"Previous page icon is displayed")]
        public void ThenPreviousPageIconIsDisplayed()
        {
            Assert.AreEqual(true, logFilesStaticElements.PreviousIcon.GetElementVisibility(), "Previous page icon is not displayed");
        }

        [Then(@"Next page icon is displayed")]
        public void ThenNextPageIconIsDisplayed()
        {
            Assert.AreEqual(true, logFilesStaticElements.NextIcon.GetElementVisibility(), "Next page icon is not displayed");
        }

        [Then(@"Displaying x to y of z results label is displayed (.*)")]
        public void ThenDisplayingXToYOfZResultsLabelIsDisplayed(int p0)
        {
            //Result Label is not present in the Logs page
            _scenarioContext.Pending();
        }
            

        [Then(@"Page x of y label is displayed (.*)")]
        public void ThenPageXOfYLabelIsDisplayed(int p0)
        {
            Assert.AreEqual(true, logFilesStaticElements.PaginationLabel.GetElementVisibility(), "pagination label is not displayed");
        }

    }
}