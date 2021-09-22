using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AssetsTab.DeviceDetails;
using HillromAutomationFramework.SupportingCode;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.AssetsTab.DeviceDetails
{
    [Binding, Scope(Tag = "SoftwareRequirementID_5703")]
    public sealed class Req5703Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly CSMDeviceDetailsPage _csmDeviceDetailsPage;

        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public Req5703Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
            _csmDeviceDetailsPage = new CSMDeviceDetailsPage(driver);
        }

        private static class _Global
        {
            public static string ExistingRoomAndBed;
            public static string RandomRoomNo;
            public static string RandomBedNo;
        }

        [Given(@"user is on CSM Edit Asset Details dialog")]
        public void GivenUserIsOnCSMEditAssetDetailsDialog()
        {
            //Login and selecting the required organization
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));

            //Searching serial number and clicking on device
            _mainPage.SearchSerialNumberAndClick(CSMDeviceDetailsPageExpectedValues.SerialNumberwithRoomAndBed);
            Thread.Sleep(2000);
            
            //Storing the value of current room and bed details
            _Global.ExistingRoomAndBed = _csmDeviceDetailsPage.RoomAndBedDetails.Text;


            //clicking on Edit button
            _csmDeviceDetailsPage.CSMDeviceEditButton.Click();

            //Waiting till popup is displayed
            _wait.Message = "CSM edit asset details dialog is not displayed within specifies time.";
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(CSMDeviceDetailsPage.Locators.EditLabelPopupID)));


            bool IsEditAssetDetails = _csmDeviceDetailsPage.EditLabelPopup.GetElementVisibility();
            IsEditAssetDetails.Should().BeTrue("User is not on CSM Edit Asset Details dialog.");
        }

        [When(@"user changes Room and Bed fields")]
        public void WhenUserChangesRoomAndBedFields()
        {
            //waiting for room and bed field and clearing the data if present
            _wait.Until(ExplicitWait.ElementExists(By.Id(CSMDeviceDetailsPage.Locators.RoomFieldID)));
            _csmDeviceDetailsPage.RoomField.Clear();
            _csmDeviceDetailsPage.BedField.Clear();

            //Generating random string for room and bed
            _Global.RandomRoomNo = GetMethods.GenerateRandomString(5);
            _Global.RandomBedNo = GetMethods.GenerateRandomString(5);

           //Assigning the value of room and bed to text field
            _csmDeviceDetailsPage.RoomField.EnterText(_Global.RandomRoomNo);
            _csmDeviceDetailsPage.BedField.EnterText(_Global.RandomBedNo);
        }

        [When(@"user clicks Save button")]
        public void WhenUserClicksSaveButton()
        {
            _csmDeviceDetailsPage.SaveButton.Click();
        }

        [Then(@"changed Room and Bed are displayed on the CSM Asset Details page")]
        public void ThenChangedRoomAndBedAreDisplayedOnTheCSMAssetDetailsPage()
        {
            Thread.Sleep(2000);
            bool IsEqual = _csmDeviceDetailsPage.RoomAndBedDetails.Text.Equals(_Global.RandomRoomNo + "/" + _Global.RandomBedNo);
            IsEqual.Should().BeTrue("Updated Room and Bed is not displayed on Device details page.");
        }

        [When(@"user clears Room field")]
        public void WhenRemovesRoomAndBedDetails()
        {
            _csmDeviceDetailsPage.RoomField.Clear();
        }

        [Then(@"Room field contains hint text")]
        public void ThenRoomFieldContainsHintText()
        {
            string RoomHintText = _csmDeviceDetailsPage.RoomHintText.Text;
            RoomHintText.Should().BeEquivalentTo("Room", "Room field does not contains hint text.");
        }

        [When(@"user clears Bed field")]
        public void WhenUserClearsBedField()
        {
            Thread.Sleep(1000);
            _csmDeviceDetailsPage.BedField.Clear();
        }

        [Then(@"Bed field contains hint text")]
        public void ThenBedFieldContainsHintText()
        {
            string BedHintText = _csmDeviceDetailsPage.BedHintText.Text;
            BedHintText.Should().BeEquivalentTo("Bed", "Bed field does not contains hint text.");
        }

        [When(@"user clicks Cancel button")]
        public void WhenUserClicksCancelButton()
        {
            _csmDeviceDetailsPage.CancelButton.Click();
        }

        [Then(@"original Room and Bed are displayed on the CSM Asset Details page")]
        public void ThenOriginalRoomAndBedAreDisplayedOnTheCSMAssetDetailsPage()
        {
            Thread.Sleep(2000);

            _csmDeviceDetailsPage.RoomAndBedDetails.Text.Should().BeEquivalentTo(_Global.ExistingRoomAndBed, 
                "Original Room and Bed should be displayed on Device details page when user clicks cancel button");
        }

        [Then(@"Asset Tag value is displayed")]
        public void ThenAssetTagValueIsDisplayed()
        {
            _csmDeviceDetailsPage.AssetTagPopup.GetElementVisibility().Should().BeTrue("Asset Tag value is not displayed.");
        }

        [Then(@"Asset Tag value is read only")]
        public void ThenAssetTagValueIsReadOnly()
        {
            _csmDeviceDetailsPage.AssetTagPopup.IsReadOnly().Should().BeTrue("Asset Tag value is not read only.");
        }

        [Then(@"Facility value is displayed")]
        public void ThenFacilityValueIsDisplayed()
        {
            _csmDeviceDetailsPage.FacilityPopup.GetElementVisibility().Should().BeTrue("Facility value is not displayed.");
        }

        [Then(@"Facility value is read only")]
        public void ThenFacilityValueIsReadOnly()
        {
            _csmDeviceDetailsPage.FacilityPopup.IsReadOnly().Should().BeTrue("Facility value is not read only.");
        }

        [Then(@"Location ID value is displayed")]
        public void ThenLocationIDValueIsDisplayed()
        {
            _csmDeviceDetailsPage.LocationPopup.GetElementVisibility().Should().BeTrue("Location ID value is not displayed.");
        }

        [Then(@"Location ID value is read only")]
        public void ThenLocationIDValueIsReadOnly()
        {
            _csmDeviceDetailsPage.LocationPopup.IsReadOnly().Should().BeTrue("Location ID value is not read only.");
        }

       
    }
}
