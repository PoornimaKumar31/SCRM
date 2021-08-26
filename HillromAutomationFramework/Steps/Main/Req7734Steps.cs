using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.PageObjects.AssetsTab;
using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Main
{
    [Binding,Scope(Tag = "SoftwareRequirementID_7734")]
    class Req7734Steps
    {
        MainPage mainPage = new MainPage();
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        CentrellaDeviceDetailsPage centrellaDeviceDetailsPage = new CentrellaDeviceDetailsPage();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        private ScenarioContext _scenarioContext;
        public Req7734Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Given(@"user is on device details page for Centrella Serial number ""(.*)""")]
        public void GivenUserIsOnDeviceDetailsPageForCentrellaSerialNumber(string serialNumber)
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(landingPage.PSSServiceOrganizationFacilityBatesville, "Centrella Orgaization");
            landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.SearchSerialNumberAndClick(serialNumber);
        }

        [When(@"user clicks Error codes tab")]
        public void WhenUserClicksErrorCodesTab()
        {
            centrellaDeviceDetailsPage.ErrorCodeTab.Click();
        }

        [When(@"clicks expansion arrow on a row in Error codes table")]
        public void WhenClicksOnARowInErrorCodesTable()
        {
            centrellaDeviceDetailsPage.ErrorRowExpenstionArrow.Click();
        }

        [Then(@"Centrella error code pop-up dialog is displayed")]
        public void ThenCentrellaErrorCodePop_UpDialogIsDisplayed()
        {
            _scenarioContext.Pending();
        }

        [Then(@"""(.*)"" title label is displayed")]
        public void ThenTitleLabelIsDisplayed(string p0)
        {
            _scenarioContext.Pending();
        }

        [Then(@"error code title value is displayed")]
        public void ThenErrorCodeTitleValueIsDisplayed()
        {
            _scenarioContext.Pending();
        }

        [Then(@"""(.*)"" label is displayed")]
        public void ThenLabelIsDisplayed(string p0)
        {
            _scenarioContext.Pending();
        }

        [Then(@"error code value is displayed")]
        public void ThenErrorCodeValueIsDisplayed()
        {
            _scenarioContext.Pending();
        }

        [Then(@"description is displayed")]
        public void ThenDescriptionIsDisplayed()
        {
            _scenarioContext.Pending();
        }

        [Then(@"solution is displayed")]
        public void ThenSolutionIsDisplayed()
        {
            _scenarioContext.Pending();
        }

        [Then(@"Reference link is displayed")]
        public void ThenReferenceLinkIsDisplayed()
        {
            _scenarioContext.Pending();
        }

        [Then(@"Close button is displayed")]
        public void ThenCloseButtonIsDisplayed()
        {
            _scenarioContext.Pending();
        }

    }
}
