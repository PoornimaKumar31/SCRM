using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.PageObjects.Component_Information;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5702")]
    class Req5702Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        CSMAssetListPage csmAssetListPage = new CSMAssetListPage();
        MainPage mainPage = new MainPage();
        

        //Context Injection
        private ScenarioContext _scenarioContext;
        public Req5702Steps(ScenarioContext scnenarioContext)
        {
            _scenarioContext = scnenarioContext;              
        }


        [Given(@"user is on Asset List page with more than one CSM")]
        public void GivenUserIsOnAssetListPageWithMoreThanOneCSM()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CSMDeviceName);
            Assert.Greater(csmAssetListPage.GetDeviceCount(), 2);
        }

        [When(@"user clicks any CSM")]
        public void WhenUserClicksAnyCSM()
        {
            Thread.Sleep(2000);
            mainPage.SearchSerialNumberAndClick("100010000000");
        }

        [Then(@"Asset Details landing page is displayed")]
        public void ThenAssetDetailsLandingPageIsDisplayed()
        {
            Assert.IsTrue(csmAssetListPage.CSMDetailsPage.GetElementVisibility(), "Asset Details Landing Page is not displayed");
        }

        [Then(@"Asset Detail summary subsection with Edit button is displayed")]
        public void ThenAssetDetailSummarySubsectionWithEditButtonIsDisplayed()
        {
            Assert.IsTrue(csmAssetListPage.CSMDetailsSummary.GetElementVisibility(), "CVSM details summary subsection is not displayed");
            Assert.IsTrue(csmAssetListPage.EditButton.GetElementVisibility(), "Edit Button is not displayed");
        }

        [Then(@"Preventive Maintenance tab is displayed")]
        public void ThenPreventiveMaintenanceTabIsDisplayed()
        {
            Assert.IsTrue(csmAssetListPage.PreventiveMaintenanceTab.GetElementVisibility(), "Preventive Mainetenance Tab is not displayed");
        }

        [Then(@"Component Information tab is displayed")]
        public void ThenComponentInformationTabIsDisplayed()
        {
            Assert.IsTrue(csmAssetListPage.ComponentInformationTab.GetElementVisibility(), "Component information tab is not displayed");
        }

        [Then(@"Logs tab is displayed")]
        public void ThenLogsTabIsDisplayed()
        {
            Assert.IsTrue(csmAssetListPage.LogsTab.GetElementVisibility(), "Logs tab is not displayed");
        }

        [Then(@"Asset Detail subsection is displayed")]
        public void ThenAssetDetailSubsectionIsDisplayed()
        {
            Assert.IsTrue(csmAssetListPage.AssetDetailsSubsection.GetElementVisibility(), "Asset Details Subsection is not displayed");
        }

    }
}
