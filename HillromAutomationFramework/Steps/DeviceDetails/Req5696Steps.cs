using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5696")]
    public class Req5696Steps
    {
        readonly LoginPage loginPage = new LoginPage();
        readonly LandingPage landingPage = new LandingPage();
        readonly MainPage mainPage = new MainPage();
        readonly CVSMDeviceDetailsPage cvsmDeviceDetailsPage = new CVSMDeviceDetailsPage();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        string ExistingRoomAndBed;

        [Given(@"user is on CVSM Asset Details page")]
        public void GivenUserIsOnCVSMAssetDetailsPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.Organization1Facility0Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CVSMDeviceName);
            Thread.Sleep(1000);
            mainPage.SearchSerialNumberAndClick("100020000000");
        }
        
        [When(@"user clicks Edit button")]
        public void WhenUserClicksEditButton()
        {
            Thread.Sleep(1000);
            cvsmDeviceDetailsPage.EditButton.Click();
        }
        
        [Then(@"Edit Asset Details dialog is displayed")]
        public void ThenEditAssetDetailsDialogWillDisplay()
        {
            Assert.AreEqual(true,cvsmDeviceDetailsPage.EditAssetDetailsPopUpTitle.GetElementVisibility(), "Edit Asset Details dialog is not displayed.");
        }
        
        [Then(@"Edit Asset Details title is displayed")]
        public void ThenUserCanSeeEditAssetDetailsTitle()
        {
            Assert.AreEqual(true, cvsmDeviceDetailsPage.EditAssetDetailsPopUpTitle.GetElementVisibility(), "Edit Asset Details title is not displayed");
            string ActualTitle = cvsmDeviceDetailsPage.EditAssetDetailsPopUpTitle.Text;
            string ExpectedTitle = CVSMDeviceDetailsPage.ExpectedValues.EditAssetDetailsPopUpTitle;
            Assert.AreEqual(ExpectedTitle, ActualTitle,"Edit asset title does not match the expected value.");
        }
        
        [Then(@"Facility label is displayed")]
        public void ThenUserCanSeeFacilityLabel()
        {
            Assert.AreEqual(true,cvsmDeviceDetailsPage.EditAssetDetailsPopUPFacilityLabel.GetElementVisibility(),"Facility label is not displayed.");
        }
        
        [Then(@"Location label is displayed")]
        public void ThenUserCanSeeLocationLabel()
        {
            Assert.AreEqual(true, cvsmDeviceDetailsPage.EditAssetDetailsPopUPLocationLabel.GetElementVisibility(), "Location label is not displayed");
        }
        
        [Then(@"Room entry field is displayed")]
        public void ThenUserCanSeeRoomEntryField()
        {
            Assert.AreEqual(true,cvsmDeviceDetailsPage.RoomField.GetElementVisibility(), "Room entry field is not displayed");
        }
        
        [Then(@"Bed entry field is displayed")]
        public void ThenUserCanSeeBedEntryField()
        {
            Assert.AreEqual(true,cvsmDeviceDetailsPage.BedField.GetElementVisibility(), "Bed entry field is not displayed.");
        }
        
        [Then(@"Save button is displayed")]
        public void ThenUserCanSeeSaveButton()
        {
            Assert.AreEqual(true,cvsmDeviceDetailsPage.SaveButton.GetElementVisibility(), "Save button is not displayed.");
        }
        
        [Then(@"Cancel button is displayed")]
        public void ThenUserCanSeeCancelButton()
        {
            Assert.AreEqual(true, cvsmDeviceDetailsPage.CancelButton.GetElementVisibility(), "Cancel button is not displayed.");
        }

        [Given(@"user is on CVSM Edit Asset Details dialog")]
        public void GivenUserIsOnCVSMEditAssetDetailsDialog()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.Organization1Facility0Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CVSMDeviceName);
            Thread.Sleep(1000);
            mainPage.SearchSerialNumberAndClick("100020000002");
            //to load the device details
            Thread.Sleep(1000);
            ExistingRoomAndBed = cvsmDeviceDetailsPage.RoomAndBedDetails.Text;
            cvsmDeviceDetailsPage.EditButton.Click();
        }

        [When(@"user changes Room and Bed fields")]
        public void WhenUserChangesRoomAndBedFields()
        {
            cvsmDeviceDetailsPage.RoomField.Clear();
            cvsmDeviceDetailsPage.RoomField.EnterText(CVSMDeviceDetailsPage.ExpectedValues.UpdateRoomValue);
            cvsmDeviceDetailsPage.BedField.Clear();
            cvsmDeviceDetailsPage.BedField.EnterText(CVSMDeviceDetailsPage.ExpectedValues.UpdateBedValue);
        }

        [When(@"user clicks Save button")]
        public void WhenUserClicksSaveButton()
        {
            cvsmDeviceDetailsPage.SaveButton.Click();
        }

        [Then(@"changed Room and Bed are displayed on the CVSM Asset Details page")]
        public void ThenChangedRoomAndBedAreDisplayedOnTheCVSMAssetDetailsPage()
        {
            //To get the updated data thread.sleep
            Thread.Sleep(1000);
            string ActualRoomAndBed = cvsmDeviceDetailsPage.RoomAndBedDetails.Text;
            string ExpectedRoomAndBed = CVSMDeviceDetailsPage.ExpectedValues.UpdateRoomValue + "/" + CVSMDeviceDetailsPage.ExpectedValues.UpdateBedValue;
            Assert.AreEqual(ExpectedRoomAndBed, ActualRoomAndBed,"Room and bed details are not changed.");
        }

        [When(@"user clicks Cancel button")]
        public void WhenUserClicksCancelButton()
        {
            cvsmDeviceDetailsPage.CancelButton.Click();
        }

        [Then(@"original Room and Bed are displayed on the CVSM Asset Details page")]
        public void ThenOriginalRoomAndBedAreDisplayedOnTheCVSMAssetDetailsPage()
        {
            string ActualRoomAndBedDisplayed = cvsmDeviceDetailsPage.RoomAndBedDetails.Text;
            Assert.AreEqual(ExistingRoomAndBed, ActualRoomAndBedDisplayed,"Original room and bed details are not displayed.");
        }

        [When(@"Bed field is blank")]
        public void WhenBedFieldIsBlank()
        {
            cvsmDeviceDetailsPage.BedField.Clear();
        }

        [Then(@"Bed field contains hint text")]
        public void ThenBedFieldContainsHintText()
        {
            Assert.AreEqual(true, cvsmDeviceDetailsPage.BedLabel.GetElementVisibility(),"Bed field hint text is not displayed.");
            string ActualHintText = cvsmDeviceDetailsPage.BedLabel.Text;
            string ExpectedHintText = CVSMDeviceDetailsPage.ExpectedValues.BedLabelHintText;
            Assert.AreEqual(ExpectedHintText, ActualHintText,"Bed Field hint text is matches the expected value.");
        }

        [When(@"Room field is blank")]
        public void WhenRoomFieldIsBlank()
        {
            cvsmDeviceDetailsPage.RoomField.Clear();
        }

        [Then(@"Room field contains hint text")]
        public void ThenRoomFieldContainsHintText()
        {
            Assert.AreEqual(true, cvsmDeviceDetailsPage.RoomLabel.GetElementVisibility(),"Room field hint text is not displayed.");
            string ActualHintText = cvsmDeviceDetailsPage.RoomLabel.Text;
            string ExpectedHintText = CVSMDeviceDetailsPage.ExpectedValues.RoomLabelHintText;
            Assert.AreEqual(ExpectedHintText, ActualHintText, "Room field hint text is not matching with the expected value.");
        }

        [Then(@"Asset Tag value is displayed")]
        public void ThenTheAssetTagValueIsDisplayed()
        {
            Assert.AreEqual(true,cvsmDeviceDetailsPage.EditAssetDetailsPopUPAssetTagValue.GetElementVisibility(), "Asset Tag value is not displayed");
        }

        [Then(@"Asset Tag value is read only")]
        public void ThenTheAssetTagValueIsReadOnly()
        {
            Assert.AreEqual(true,cvsmDeviceDetailsPage.EditAssetDetailsPopUPAssetTagValue.IsReadOnly(),"Asset tag is not readonly.");
        }

        [Then(@"Facility value is displayed")]
        public void ThenTheFacilityValueIsDisplayed()
        {
            Assert.AreEqual(true,cvsmDeviceDetailsPage.EditAssetDetailsPopUPFacilityValue.GetElementVisibility(), "Facility value is not displayed");
        }

        [Then(@"Facility value is read only")]
        public void ThenTheFacilityValueIsReadOnly()
        {
            Assert.AreEqual(true,cvsmDeviceDetailsPage.EditAssetDetailsPopUPFacilityValue.IsReadOnly(), "Facility value is not read only");
        }

        [Then(@"Location ID value is displayed")]
        public void ThenTheLocationIDValueIsDisplayed()
        {
            Assert.AreEqual(true,cvsmDeviceDetailsPage.EditAssetDetailsPopUPLocationValue.GetElementVisibility(), "Location ID value is not displayed");
        }

        [Then(@"Location ID value is read only")]
        public void ThenTheLocationIDValueIsReadOnly()
        {
            Assert.AreEqual(true,cvsmDeviceDetailsPage.EditAssetDetailsPopUPLocationValue.IsReadOnly(), "Location ID value is not read only");
        }
    }
}
