﻿using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.ReportsTab
{
    [Binding,Scope(Tag = "SoftwareRequirementID_9426")]
    public class Req9426Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        ReportsPage reportsPage = new ReportsPage();

        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        ScenarioContext _scenarioContext;

        public Req9426Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Given(@"user is on ""(.*)"" page")]
        public void GivenUserIsOnPage(string reportType)
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);

            if (reportType.ToLower().Trim().Equals("centrella firmware upgrade status"))
            {
                SetMethods.ScrollTillElementIsVisible(landingPage.EdenHospitalMedicalCenterOrganizationTitle,"Centrella Orgaization");
                landingPage.EdenHospitalMedicalCenterOrganizationFacilityMedicalCenter.Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
                mainPage.ReportsTab.JavaSciptClick();
                reportsPage.AssetTypeDDL.SelectDDL(ReportsPage.ExpectedValues.CentrellaDeviceName);
                reportsPage.ReportTypeDDL.SelectDDL(ReportsPage.ExpectedValues.FirmwareStatusReportType);
                reportsPage.GetReportButton.Click();
            }
            else
            { 
                 Assert.Fail(reportType + " is a invalid report type.");       
            }
           
        }
        
        [When(@"user clicks Download button")]
        public void WhenUserClicksDownloadButton()
        {
            reportsPage.DownloadButton.Click();
        }
        
        [Then(@"""(.*)"" Report is downloaded as csv file")]
        public void ThenReportIsDownloadedAsCsvFile(string reportName)
        {
            string fileName = "";
            if(reportName.ToLower().Trim().Equals("firmware status"))
            {
                fileName = FirmwareStatusPage.ExpectedValues.CentrellaFirmwareStatusReportName;
            }
            else
            {
                Assert.Fail(reportName + " is a invalid report.");
            }

            Assert.AreEqual(true, GetMethods.IsFileDownloaded(fileName, 10), reportName + " file is not downloaded.");
            Assert.AreEqual(true, GetMethods.CheckFileFormat(".csv"), reportName + " file is not in .csv format.");
        }
    }
}