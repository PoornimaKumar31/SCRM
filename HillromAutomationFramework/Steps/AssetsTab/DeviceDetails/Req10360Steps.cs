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
    [Binding,Scope(Tag = "SoftwareRequirementID_10360")]
    public sealed class Req10360Steps
    {
        private readonly LoginPage loginPage;
        private readonly LandingPage landingPage;
        private readonly MainPage mainPage;
        private readonly ProgressaDeviceDetailsPage progressaDeviceDetailsPage;

        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public Req10360Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            loginPage = new LoginPage(driver);
            landingPage = new LandingPage(driver);
            mainPage = new MainPage(driver);
            progressaDeviceDetailsPage = new ProgressaDeviceDetailsPage(driver);
        }

        [Given(@"user is on Asset List for an organization with Progressa devices")]
        public void GivenUserIsOnAssetListForAnOrganizationWithProgressaDevices()
        {
            loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(landingPage.PSSServiceOrganizationFacilityBatesville,_driver ,"Progressa Orgaization");
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

        [Given(@"user is on device details page for Progressa Serial number ""(.*)""")]
        public void GivenUserIsOnDeviceDetailsPageForProgressaSerialNumber(string serialNumber)
        {
            loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            SetMethods.MoveTotheElement(landingPage.PSSServiceOrganizationFacilityBatesville, _driver, "Progressa Orgaization");
            landingPage.PSSServiceOrganizationFacilityBatesville.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.SearchSerialNumberAndClick(serialNumber);
        }

        [Then(@"""(.*)"" is displayed in Error codes tab")]
        public void ThenIsDisplayedInErrorCodesTab(string ExpectedText)
        {
            if(progressaDeviceDetailsPage.ErrorCodeTab.GetAttribute("aria-selected")!="true")
            {
                progressaDeviceDetailsPage.ErrorCodeTab.Click();
            }
            Assert.AreEqual(ExpectedText, progressaDeviceDetailsPage.NoErrorReportedLabel.Text, "Label is not as expected");
        }

        [When(@"user clicks Error codes tab")]
        public void WhenUserClicksErrorCodesTab()
        {
            progressaDeviceDetailsPage.ErrorCodeTab.Click();
        }

        [Then(@"Reference button is displayed")]
        public void ThenReferenceButtonIsDisplayed()
        {
            Assert.IsTrue(progressaDeviceDetailsPage.ReferenceButton.GetElementVisibility(), "Reference button is not displayed");
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string ColumnName)
        {
            switch(ColumnName.Trim().ToLower())
            {
                case "severity":
                    Assert.IsTrue(progressaDeviceDetailsPage.SaverityColumnHeading.GetElementVisibility(), ColumnName + " is not displayed");
                    break;

                case "timestamp":
                    Assert.IsTrue(progressaDeviceDetailsPage.SaverityColumnHeading.GetElementVisibility(), ColumnName + " is not displayed");
                    break;

                case "code":
                    Assert.IsTrue(progressaDeviceDetailsPage.SaverityColumnHeading.GetElementVisibility(), ColumnName + " is not displayed");
                    break;

                case "description":
                    Assert.IsTrue(progressaDeviceDetailsPage.SaverityColumnHeading.GetElementVisibility(), ColumnName + " is not displayed");
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
            string ActualLabel = progressaDeviceDetailsPage.ColumnHeadingElements[ColumnNumber - 1].Text.ToLower().Trim();
            Assert.AreEqual(ExpectedLabel,ActualLabel,ColumnNumber+ " is not in the "+ColumnNumber);
                    
        }


    }
}
