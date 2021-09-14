using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.AssetsTab.DeviceDetails
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5696")]
    public class Req5696Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly CVSMDeviceDetailsPage _cvsmDeviceDetailsPage;

        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        private readonly WebDriverWait _wait;
        string ExistingRoomAndBed;
        string NewRoomAndBed = "";

        public Req5696Steps(ScenarioContext scnenarioContext, IWebDriver driver)
        {
            _scenarioContext = scnenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
            _cvsmDeviceDetailsPage = new CVSMDeviceDetailsPage(driver);
        }

        [Given(@"user is on CVSM Asset Details page")]
        public void GivenUserIsOnCVSMAssetDetailsPage()
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CVSMDeviceName);
            Thread.Sleep(2000);
            _mainPage.SearchSerialNumberAndClick("100020000000");
        }
        
        [When(@"user clicks Edit button")]
        public void WhenUserClicksEditButton()
        {
            Thread.Sleep(1000);
            _cvsmDeviceDetailsPage.EditButton.Click();
        }
        
        [Then(@"Edit Asset Details dialog is displayed")]
        public void ThenEditAssetDetailsDialogWillDisplay()
        {
            _wait.Message = "Edit Asset Details dialog is not displayed within 10 seconds";
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(CVSMDeviceDetailsPage.Locators.EditAssetDetailsPopUpTitleID)));
            _cvsmDeviceDetailsPage.EditAssetDetailsPopUpTitle.GetElementVisibility().Should().BeTrue("Edit Asset Details dialog is not displayed.");
        }
        
        [Then(@"Edit Asset Details title is displayed")]
        public void ThenUserCanSeeEditAssetDetailsTitle()
        {
             _cvsmDeviceDetailsPage.EditAssetDetailsPopUpTitle.GetElementVisibility().Should().BeTrue("Edit Asset Details title is not displayed");
            string ActualTitle = _cvsmDeviceDetailsPage.EditAssetDetailsPopUpTitle.Text;
            string ExpectedTitle = CVSMDeviceDetailsPage.ExpectedValues.EditAssetDetailsPopUpTitle;
            Assert.AreEqual(ExpectedTitle, ActualTitle,"Edit asset title does not match the expected value.");
        }
        
        [Then(@"Facility label is displayed")]
        public void ThenUserCanSeeFacilityLabel()
        {
            _cvsmDeviceDetailsPage.EditAssetDetailsPopUPFacilityLabel.GetElementVisibility().Should().BeTrue("Facility label is not displayed.");
        }
        
        [Then(@"Location label is displayed")]
        public void ThenUserCanSeeLocationLabel()
        {
             _cvsmDeviceDetailsPage.EditAssetDetailsPopUPLocationLabel.GetElementVisibility().Should().BeTrue("Location label is not displayed");
        }
        
        [Then(@"Room entry field is displayed")]
        public void ThenUserCanSeeRoomEntryField()
        {
            _cvsmDeviceDetailsPage.RoomField.GetElementVisibility().Should().BeTrue("Room entry field is not displayed");
        }
        
        [Then(@"Bed entry field is displayed")]
        public void ThenUserCanSeeBedEntryField()
        {
            _cvsmDeviceDetailsPage.BedField.GetElementVisibility().Should().BeTrue("Bed entry field is not displayed.");
        }
        
        [Then(@"Save button is displayed")]
        public void ThenUserCanSeeSaveButton()
        {
            _cvsmDeviceDetailsPage.SaveButton.GetElementVisibility().Should().BeTrue("Save button is not displayed.");
        }
        
        [Then(@"Cancel button is displayed")]
        public void ThenUserCanSeeCancelButton()
        {
             _cvsmDeviceDetailsPage.CancelButton.GetElementVisibility().Should().BeTrue("Cancel button is not displayed.");
        }

        [Given(@"user is on CVSM Edit Asset Details dialog")]
        public void GivenUserIsOnCVSMEditAssetDetailsDialog()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CVSMDeviceName);
            Thread.Sleep(1000);
            _mainPage.SearchSerialNumberAndClick("100020000002");
            //to load the device details
            Thread.Sleep(1000);
            ExistingRoomAndBed = _cvsmDeviceDetailsPage.RoomAndBedDetails.Text;
            _cvsmDeviceDetailsPage.EditButton.Click();
        }

        [When(@"user changes Room and Bed fields")]
        public void WhenUserChangesRoomAndBedFields()
        {
            _cvsmDeviceDetailsPage.RoomField.Clear();
            string NewRoom = GetMethods.GenerateRandomString(5);
            string NewBed = GetMethods.GenerateRandomString(5);
            NewRoomAndBed = NewRoom + "/" + NewBed;
            _cvsmDeviceDetailsPage.RoomField.EnterText(NewRoom);
            _cvsmDeviceDetailsPage.BedField.Clear();
            _cvsmDeviceDetailsPage.BedField.EnterText(NewBed);
        }

        [When(@"user clicks Save button")]
        public void WhenUserClicksSaveButton()
        {
            _cvsmDeviceDetailsPage.SaveButton.Click();
        }

        [Then(@"changed Room and Bed are displayed on the CVSM Asset Details page")]
        public void ThenChangedRoomAndBedAreDisplayedOnTheCVSMAssetDetailsPage()
        {
            //To get the updated data thread.sleep
            Thread.Sleep(1000);
            string ActualRoomAndBed = _cvsmDeviceDetailsPage.RoomAndBedDetails.Text.ToLower();
            ActualRoomAndBed.Should().BeEquivalentTo(NewRoomAndBed.ToLower(),"Room and bed details are not changed.");
        }

        [When(@"user clicks Cancel button")]
        public void WhenUserClicksCancelButton()
        {
            _cvsmDeviceDetailsPage.CancelButton.Click();
        }

        [Then(@"original Room and Bed are displayed on the CVSM Asset Details page")]
        public void ThenOriginalRoomAndBedAreDisplayedOnTheCVSMAssetDetailsPage()
        {
            string ActualRoomAndBedDisplayed = _cvsmDeviceDetailsPage.RoomAndBedDetails.Text;
            ActualRoomAndBedDisplayed.Should().BeEquivalentTo(ExistingRoomAndBed, "Original room and bed details are not displayed.");
        }

        [When(@"user clears Bed field")]
        public void WhenUserClearsBedField()
        {
            _cvsmDeviceDetailsPage.BedField.Clear();
        }

        [Then(@"Bed field contains hint text")]
        public void ThenBedFieldContainsHintText()
        {
             _cvsmDeviceDetailsPage.BedLabel.GetElementVisibility().Should().BeTrue("Bed field hint text is not displayed.");
            string ActualHintText = _cvsmDeviceDetailsPage.BedLabel.Text;
            string ExpectedHintText = CVSMDeviceDetailsPage.ExpectedValues.BedLabelHintText;
            ActualHintText.Should().BeEquivalentTo(ExpectedHintText,"Bed Field hint text is matches the expected value.");
        }

        [When(@"user clears Room field")]
        public void WhenRoomFieldIsBlank()
        {
            _cvsmDeviceDetailsPage.RoomField.Clear();
        }

        [Then(@"Room field contains hint text")]
        public void ThenRoomFieldContainsHintText()
        {
             _cvsmDeviceDetailsPage.RoomLabel.GetElementVisibility().Should().BeTrue("Room field hint text is not displayed.");
            string ActualHintText = _cvsmDeviceDetailsPage.RoomLabel.Text;
            string ExpectedHintText = CVSMDeviceDetailsPage.ExpectedValues.RoomLabelHintText;
            ActualHintText.Should().BeEquivalentTo(ExpectedHintText, "Room field hint text is not matching with the expected value.");
        }

        [Then(@"Asset Tag value is displayed")]
        public void ThenTheAssetTagValueIsDisplayed()
        {
            _wait.Until(ExplicitWait.ElementIsVisible(By.Id(CVSMDeviceDetailsPage.Locators.EditAssetDetailsPopUPAssetTagLabelID)));
             _cvsmDeviceDetailsPage.EditAssetDetailsPopUPAssetTagValue.GetElementVisibility().Should().BeTrue("Asset Tag value is not displayed");
        }

        [Then(@"Asset Tag value is read only")]
        public void ThenTheAssetTagValueIsReadOnly()
        {
            _cvsmDeviceDetailsPage.EditAssetDetailsPopUPAssetTagValue.IsReadOnly().Should().BeTrue("Asset tag is not readonly.");
        }

        [Then(@"Facility value is displayed")]
        public void ThenTheFacilityValueIsDisplayed()
        {
            _cvsmDeviceDetailsPage.EditAssetDetailsPopUPFacilityValue.GetElementVisibility().Should().BeTrue("Facility value is not displayed");
        }

        [Then(@"Facility value is read only")]
        public void ThenTheFacilityValueIsReadOnly()
        {
            _cvsmDeviceDetailsPage.EditAssetDetailsPopUPFacilityValue.IsReadOnly().Should().BeTrue("Facility value is not read only");
        }

        [Then(@"Location ID value is displayed")]
        public void ThenTheLocationIDValueIsDisplayed()
        {
            _cvsmDeviceDetailsPage.EditAssetDetailsPopUPLocationValue.GetElementVisibility().Should().BeTrue("Location ID value is not displayed");
        }

        [Then(@"Location ID value is read only")]
        public void ThenTheLocationIDValueIsReadOnly()
        {
            _cvsmDeviceDetailsPage.EditAssetDetailsPopUPLocationValue.IsReadOnly().Should().BeTrue("Location ID value is not read only");
        }
    }
}
