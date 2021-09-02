using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AssetsTab;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.AssetsTab.DeviceDetails
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

        [When(@"user clicks Error code tab")]
        public void WhenUserClicksErrorCodeTab()
        {
            centrellaDeviceDetailsPage.ErrorCodeTab.Click();
        }

        [When(@"clicks expansion arrow on a row in Error codes table")]
        public void WhenClicksOnARowInErrorCodesTable()
        {
            centrellaDeviceDetailsPage.ErrorRowExpenstionArrow.Click();
        }

        [Then(@"""(.*)"" label and value is displayed")]
        public void ThenLabelAndValueIsDisplayed(string LabelName)
        {
            switch(LabelName.ToLower().Trim())
            {
                case "error code title":
                    Assert.IsTrue(centrellaDeviceDetailsPage.ErrorCodeTitleLabel.GetElementVisibility(), LabelName +" Label and Value is not displayed");
                    break;

                default:
                    Assert.Fail("Label name is invalid");
                    break;
            }
            
        }


        [Then(@"Centrella error code pop-up dialog is displayed")]
        public void ThenCentrellaErrorCodePop_UpDialogIsDisplayed()
        {
            Assert.IsTrue(centrellaDeviceDetailsPage.ErrorPopupDialogBox.GetElementVisibility(),"Error Popup dialog is not displayed");
        }

        [Then(@"""(.*)"" label is displayed")]
        public void ThenLabelIsDisplayed(string p0)
        {
            _scenarioContext.Pending();
        }

        [Then(@"""(.*)"" value is displayed")]
        public void ThenValueIsDisplayed(string p0)
        {
            _scenarioContext.Pending();
        }

        [Then(@"Reference link is displayed")]
        public void ThenReferenceLinkIsDisplayed()
        {
            Assert.IsTrue(centrellaDeviceDetailsPage.ErrorReferenceLink.GetElementVisibility(), "Reference Link is not displayed");
        }

        [Then(@"Close button is displayed")]
        public void ThenCloseButtonIsDisplayed()
        {
            Assert.IsTrue(centrellaDeviceDetailsPage.ErrorCloseButton.GetElementVisibility(), "Close button is not displayed");
        }

        [When(@"user clicks Reference link")]
        public void WhenUserClicksReferenceLink()
        {
            centrellaDeviceDetailsPage.ErrorReferenceLink.Click();
        }

        [Then(@"Service manual opens in a new tab")]
        public void ThenServiceManualOpensInANewTab()
        {
            SetMethods.WaitUntilNewWindowIsOpened(PropertyClass.Driver, 2);

            //Storing reference of Current Window
            var CurrentWindow = PropertyClass.Driver.WindowHandles[0];

            //Storing reference of Next Window
            var NewTab = PropertyClass.Driver.WindowHandles[1]; 
            
            //Verifying if NewTab has opened
            NewTab.Should().NotBeNullOrEmpty("New Tab Should be Opened");
            
            //Switching to 
            PropertyClass.Driver.SwitchTo().Window(NewTab);
         
            
            string URL = PropertyClass.Driver.Url;
            
            //Verifying if URL contains ServiceManual PDF Name
            URL.Should().Contain(CentrellaDeviceDetailsPage.ExpectedValue.ServiceManualPDFName, "Service Manual is not displayed");
            

            //Switching Back to previous tab
            PropertyClass.Driver.SwitchTo().Window(CurrentWindow);
        }

        [When(@"user clicks Close button")]
        public void WhenUserClicksCloseButton()
        {
            centrellaDeviceDetailsPage.ErrorCloseButton.Click();
        }

        [Then(@"device details page for Centrella Serial number ""(.*)"" is displayed")]
        public void ThenDeviceDetailsPageForCentrellaSerialNumberIsDisplayed(string serialNumber)
        {
            Assert.IsTrue(centrellaDeviceDetailsPage.CentrellaLocateAssetButton.GetElementVisibility(), "User is not in the Device Details Page");
            Assert.AreEqual(serialNumber, centrellaDeviceDetailsPage.CentrellaSerialNumberValue.Text, "Serial Number is not correct");
        }

        [When(@"clicks Reference button")]
        public void WhenClicksReferenceButton()
        {
            centrellaDeviceDetailsPage.ReferenceButton.JavaSciptClick();
         
        }
    }
}
