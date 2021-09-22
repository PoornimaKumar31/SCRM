using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AssetsTab;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.AssetsTab.DeviceDetails
{
    [Binding,Scope(Tag = "SoftwareRequirementID_7733")]
    public sealed class Req7733Steps
    {
        private readonly LoginPage loginPage;
        private readonly LandingPage landingPage;
        private readonly MainPage mainPage;
        private readonly CentrellaDeviceDetailsPage centrellaDeviceDetailsPage;

        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public Req7733Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            loginPage = new LoginPage(driver);
            landingPage = new LandingPage(driver);
            mainPage = new MainPage(driver);
            centrellaDeviceDetailsPage = new CentrellaDeviceDetailsPage(driver);
        }

        [Given(@"user is on Asset List for an organization with Centrella devices")]
        public void GivenUserIsOnAssetListForAnOrganizationWithCentrellaDevices()
        {
            loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(landingPage.PSSServiceOrganizationFacilityBatesville,_driver ,"Centrella Orgaization");
            landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
        }

        [Then(@"an error icon is displayed in the ""(.*)"" column for bed with serial number ""(.*)""")]
        public void ThenAnErrorIconIsDisplayedInTheColumnForBedWithSerialNumber(string columnName, string serialNumber)
        {
            Assert.IsTrue(mainPage.GetDeviceColumnData(columnName, serialNumber).GetElementVisibility());
        }

        [Then(@"an error icon is not displayed in the ""(.*)"" column for bed with serial number ""(.*)""")]
        public void ThenAnErrorIconIsNotDisplayedInTheColumnForBedWithSerialNumber(string columnName, string serialNumber)
        {
            Assert.IsTrue(mainPage.GetDeviceColumnData(columnName, serialNumber).GetElementVisibility());
        }

        [Given(@"user is on device details page for Centrella Serial number ""(.*)""")]
        public void GivenUserIsOnDeviceDetailsPageForCentrellaSerialNumber(string serialNumber)
        {
            loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(landingPage.PSSServiceOrganizationFacilityBatesville, _driver, "Centrella Orgaization");
            landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.SearchSerialNumberAndClick(serialNumber);
        }

        [Then(@"""(.*)"" is displayed in Error codes tab")]
        public void ThenIsDisplayedInErrorCodesTab(string ExpectedText)
        {
            if(centrellaDeviceDetailsPage.ErrorCodeTab.GetAttribute("aria-selected")!="true")
            {
                centrellaDeviceDetailsPage.ErrorCodeTab.Click();
            }
            Assert.AreEqual(ExpectedText, centrellaDeviceDetailsPage.NoErrorReportedLabel.Text, "Label is not as expected");
        }

        [When(@"user clicks Error codes tab")]
        public void WhenUserClicksErrorCodesTab()
        {
            centrellaDeviceDetailsPage.ErrorCodeTab.Click();
        }

        [Then(@"Reference button is displayed")]
        public void ThenReferenceButtonIsDisplayed()
        {
            Assert.IsTrue(centrellaDeviceDetailsPage.ReferenceButton.GetElementVisibility(), "Reference button is not displayed");
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string ColumnName)
        {
            switch(ColumnName.Trim().ToLower())
            {
                case "severity":
                    Assert.IsTrue(centrellaDeviceDetailsPage.SaverityColumnHeading.GetElementVisibility(), ColumnName + " is not displayed");
                    break;

                case "timestamp":
                    Assert.IsTrue(centrellaDeviceDetailsPage.SaverityColumnHeading.GetElementVisibility(), ColumnName + " is not displayed");
                    break;

                case "code":
                    Assert.IsTrue(centrellaDeviceDetailsPage.SaverityColumnHeading.GetElementVisibility(), ColumnName + " is not displayed");
                    break;

                case "description":
                    Assert.IsTrue(centrellaDeviceDetailsPage.SaverityColumnHeading.GetElementVisibility(), ColumnName + " is not displayed");
                    break;

                default:
                    Assert.Fail(ColumnName + " is invalid");
                    break;
            }
        }

        [Then(@"""(.*)"" label is in column (.*)")]
        public void ThenLabelIsInColumn(string ColumnName, int ColumnNumber)
        {
            string ExpectedLabel = ColumnName.Trim().ToLower();
            string ActualLabel = centrellaDeviceDetailsPage.ColumnHeadingElements[ColumnNumber - 1].Text.ToLower().Trim();
            Assert.AreEqual(ExpectedLabel,ActualLabel,ColumnNumber+ " is not in the "+ColumnNumber);
                    
        }


    }
}
