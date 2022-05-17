using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AssetsTab;
using HillromAutomationFramework.PageObjects.AssetsTab.DeviceDetails;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.AssetsTab.DeviceDetails
{
    [Binding,Scope(Tag = "SoftwareRequirementID_10361")]
    class Req10361Steps
    {
        private readonly LoginPage loginPage;
        private readonly LandingPage landingPage;
        private readonly MainPage mainPage;
        private readonly ProgressaDeviceDetailsPage progressaDeviceDetailsPage;

        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public Req10361Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            mainPage = new MainPage(driver);
            loginPage = new LoginPage(driver);
            landingPage = new LandingPage(driver);
            progressaDeviceDetailsPage = new ProgressaDeviceDetailsPage(driver);

        }


        [Given(@"user is on device details page for Progressa Serial number ""(.*)""")]
        public void GivenUserIsOnDeviceDetailsPageForProgressaSerialNumber(string serialNumber)
        {
            loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(landingPage.PSSServiceOrganizationFacilityBatesville, _driver, "Progressa Orgaization");
            landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.SearchSerialNumberAndClick(serialNumber);
        }

        [When(@"user clicks Error codes tab")]
        public void WhenUserClicksErrorCodeTab()
        {
            progressaDeviceDetailsPage.ErrorCodeTab.Click();
        }

        [When(@"clicks expansion arrow on a row in Error codes table")]
        public void WhenClicksOnARowInErrorCodesTable()
        {
            progressaDeviceDetailsPage.ErrorRowExpenstionArrow.Click();
        }

        [Then(@"""(.*)"" label and value is displayed")]
        public void ThenLabelAndValueIsDisplayed(string LabelName)
        {
            switch(LabelName.ToLower().Trim())
            {
                case "error code title":
                    Assert.IsTrue(progressaDeviceDetailsPage.ErrorCodeTitleLabel.GetElementVisibility(), LabelName +" Label and Value is not displayed");
                    break;

                default:
                    Assert.Fail(LabelName+" label name is invalid");
                    break;
            }
            
        }


        [Then(@"Progressa error code pop-up dialog is displayed")]
        public void ThenProgressaErrorCodePop_UpDialogIsDisplayed()
        {
            //Wait till dialog box is displayed with data
            Thread.Sleep(2000);
            Assert.IsTrue(progressaDeviceDetailsPage.ErrorPopupDialogBox.GetElementVisibility(),"Error Popup dialog is not displayed");
        }

        [Then(@"""(.*)"" label is displayed")]
        public void ThenLabelIsDisplayed(string labelName)
        {
            IWebElement labelWebElement = null;
            switch(labelName.ToLower().Trim())
            {
                case "error code":
                    labelWebElement = progressaDeviceDetailsPage.ErrorCodeLabel;
                    break;
                case "description":
                    labelWebElement = progressaDeviceDetailsPage.ErrorDescriptionLabel;
                    break;
                case "solution":
                    labelWebElement = progressaDeviceDetailsPage.ErrorSolutionLabel;
                    break;
                default: Assert.Fail(labelName + " label name is invalid.");
                    break;
            }
            bool IsLabelDisplayed = labelWebElement.GetElementVisibility();
            (IsLabelDisplayed).Should().BeTrue(because: labelName+ " label should be displayed in Progressa error code pop-up dialog box");
            string ActuallabelText = labelWebElement.Text;
            //Assingning prefix
            labelName += ":";
            (ActuallabelText).Should().BeEquivalentTo(labelName, because: labelName+ " should match the expected value in Progressa error code pop-up dialog box");
        }

        [Then(@"""(.*)"" value is displayed")]
        public void ThenValueIsDisplayed(string labelName)
        {
            IWebElement labelWebElement = null;
            switch (labelName.ToLower().Trim())
            {
                case "error code":
                    labelWebElement = progressaDeviceDetailsPage.ErrorCodeValue;
                    break;
                case "description":
                    labelWebElement = progressaDeviceDetailsPage.ErrorDescriptionValue;
                    break;
                case "solution":
                    labelWebElement = progressaDeviceDetailsPage.ErrorSolutionValue;
                    break;
                default:
                    Assert.Fail(labelName + " label name is invalid.");
                    break;
            }
            bool IsLabelValueDisplayed = labelWebElement.GetElementVisibility();
            (IsLabelValueDisplayed).Should().BeTrue(because: labelName + " label value should be displayed in Progressa error code pop-up dialog box");
        }

        [Then(@"Reference link is displayed")]
        public void ThenReferenceLinkIsDisplayed()
        {
            Assert.IsTrue(progressaDeviceDetailsPage.ErrorReferenceLink.GetElementVisibility(), "Reference Link is not displayed");
        }

        [Then(@"Close button is displayed")]
        public void ThenCloseButtonIsDisplayed()
        {
            Assert.IsTrue(progressaDeviceDetailsPage.ErrorCloseButton.GetElementVisibility(), "Close button is not displayed");
        }

        [When(@"user clicks Reference link")]
        public void WhenUserClicksReferenceLink()
        {
            progressaDeviceDetailsPage.ErrorReferenceLink.Click();
        }

        [Then(@"Service manual opens in a new tab")]
        public void ThenServiceManualOpensInANewTab()
        {
            SetMethods.WaitUntilNewWindowIsOpened(_driver, 2);

            //Storing reference of Current Window
            var CurrentWindow = _driver.WindowHandles[0];

            //Storing reference of Next Window
            var NewTab = _driver.WindowHandles[1]; 
            
            //Verifying if NewTab has opened
            NewTab.Should().NotBeNullOrEmpty("New Tab Should be Opened");
            
            //Switching to 
            _driver.SwitchTo().Window(NewTab);
         
            
            string URL = _driver.Url;
            
            //Verifying if URL contains ServiceManual PDF Name
            URL.Should().Contain(ProgressaDeviceDetailsPageExpectedValue.ServiceManualPDFName, "Service Manual is not displayed");
            

            //Switching Back to previous tab
            _driver.SwitchTo().Window(CurrentWindow);
        }

        [When(@"user clicks Close button")]
        public void WhenUserClicksCloseButton()
        {
            progressaDeviceDetailsPage.ErrorCloseButton.Click();
        }

        [Then(@"device details page for Progressa Serial number ""(.*)"" is displayed")]
        public void ThenDeviceDetailsPageForProgressaSerialNumberIsDisplayed(string serialNumber)
        {
            Assert.IsTrue(progressaDeviceDetailsPage.ProgressaLocateAssetButton.GetElementVisibility(), "User is not in the Device Details Page");
            Assert.AreEqual(serialNumber, progressaDeviceDetailsPage.ProgressaSerialNumberValue.Text, "Serial Number is not correct");
        }

        [When(@"clicks Reference button")]
        public void WhenClicksReferenceButton()
        {
            progressaDeviceDetailsPage.ReferenceButton.JavaSciptClick(_driver);
         
        }
    }
}
