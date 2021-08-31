﻿using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding, Scope(Tag = "SoftwareRequirementID_5713")]
    class Req5713Steps
    {
        RV700DeviceDetailsPage rv700DeviceDetailsPage = new RV700DeviceDetailsPage();
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));


        [Given(@"user is on RV700 Log Files page")]
        public void GivenUserIsOnRVLogFilesPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.RV700DeviceName);
            Thread.Sleep(1000);
            mainPage.SearchSerialNumberAndClick("700090000008");
            rv700DeviceDetailsPage.LogsTab.Click();
        }

        [Given(@"Received, Pending or Executing message is not displayed")]
        public void GivenPendingOrExecutingMessageIsNotDisplayed()
        {
            Assert.AreEqual(false,rv700DeviceDetailsPage.LogsPendingMessage.GetElementVisibility(), "Reciving,Pending or Executing message is displayed");
        }

        [When(@"user clicks Request Logs button")]
        public void WhenUserClicksRequestLogsButton()
        {
            rv700DeviceDetailsPage.LogsRequestButton.Click();
        }

        [Then(@"Received, Pending or Executing message is displayed")]
        public void ThenPendingOrExecutingMessageIsDisplayed()
        {
            Assert.AreEqual(true,rv700DeviceDetailsPage.LogsPendingMessage.GetElementVisibility(), "Reciving, Pending or Executing message is not displayed");
            Assert.AreEqual(true, rv700DeviceDetailsPage.LogsPendingMessage.LogFilesRequestStatusMessageVerification(), "Log files request status message is not matching the expected value.");
        }

        [Given(@"Received, Pending or Executing message is displayed")]
        public void GivenPendingOrExecutingMessageIsDisplayed()
        {
            Assert.AreEqual(true,rv700DeviceDetailsPage.LogsPendingMessage.GetElementVisibility(), "Pending or Executing message is not displayed");
            Assert.AreEqual(true, rv700DeviceDetailsPage.LogsPendingMessage.LogFilesRequestStatusMessageVerification(), "Log files request status message is not matching the expected value.");
        }

        [Then(@"Request Logs button is disabled")]
        public void ThenRequestLogsButtonIsDisabled()
        {
            Assert.AreEqual(RV700DeviceDetailsPage.ExpectedValues.RequestLogButtonDisabledClassName,rv700DeviceDetailsPage.LogsRequestButton.GetAttribute("class"), "Request Logs button is not disabled");
        }

    }
}
