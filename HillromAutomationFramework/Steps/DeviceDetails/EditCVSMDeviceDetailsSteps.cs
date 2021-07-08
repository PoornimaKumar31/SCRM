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
    public class EditCVSMDeviceDetailsSteps
    {
        readonly LoginPage loginPage = new LoginPage();
        readonly MainPage mainPage = new MainPage();
        readonly CVSMDeviceDetailsPage cvsmDeviceDetailsPage = new CVSMDeviceDetailsPage();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        string ExistingRoomAndBed;

        [Given(@"user is on CVSM Asset Details page")]
        public void GivenUserIsOnCVSMAssetDetailsPage()
        {
            loginPage.SignIn("AdminWithoutRollUp");
            SelectElement selectAssetType = new SelectElement(mainPage.AssetTypeDropDown);
            selectAssetType.SelectByText(MainPage.ExpectedValues.CVSMDeviceName);
            //select the row according to the data
            Thread.Sleep(1000);
            cvsmDeviceDetailsPage.CVSMDevices[0].Click();
        }
        
        [When(@"user clicks Edit button")]
        public void WhenUserClicksEditButton()
        {
            Thread.Sleep(1000);
            cvsmDeviceDetailsPage.EditButton.Click();
        }
        
        [Then(@"Edit Asset Details dialog will display")]
        public void ThenEditAssetDetailsDialogWillDisplay()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.EditAssetDetailsPopUpTitle.GetElementVisibility());
        }
        
        [Then(@"user can see Edit Asset Details title")]
        public void ThenUserCanSeeEditAssetDetailsTitle()
        {
            string ActualTitle = cvsmDeviceDetailsPage.EditAssetDetailsPopUpTitle.Text;
            string ExpectedTitle = CVSMDeviceDetailsPage.ExpectedValues.EditAssetDetailsPopUpTitle;
            Assert.AreEqual(ExpectedTitle, ActualTitle);
        }
        
        [Then(@"user can see Facility label")]
        public void ThenUserCanSeeFacilityLabel()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.EditAssetDetailsPopUPFacilityLabel.GetElementVisibility());
        }
        
        [Then(@"user can see Location Label")]
        public void ThenUserCanSeeLocationLabel()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.EditAssetDetailsPopUPLocationLabel.GetElementVisibility());
        }
        
        [Then(@"user can see Room entry field")]
        public void ThenUserCanSeeRoomEntryField()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.RoomField.GetElementVisibility());
        }
        
        [Then(@"user can see Bed entry field")]
        public void ThenUserCanSeeBedEntryField()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.BedField.GetElementVisibility());
        }
        
        [Then(@"user can see Save button")]
        public void ThenUserCanSeeSaveButton()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.SaveButton.GetElementVisibility());
        }
        
        [Then(@"user can see Cancel button")]
        public void ThenUserCanSeeCancelButton()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.CancelButton.GetElementVisibility());
        }

        [Given(@"user is on CVSM Edit Asset Details dialog")]
        public void GivenUserIsOnCVSMEditAssetDetailsDialog()
        {
            loginPage.SignIn("AdminWithoutRollUp");
            SelectElement selectAssetType = new SelectElement(mainPage.AssetTypeDropDown);
            selectAssetType.SelectByText(MainPage.ExpectedValues.CVSMDeviceName);
            //to load the cvsm device
            Thread.Sleep(1000);
            cvsmDeviceDetailsPage.CVSMDevices[1].Click();
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
            Assert.AreEqual(ExpectedRoomAndBed, ActualRoomAndBed);
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
            Assert.AreEqual(ExistingRoomAndBed, ActualRoomAndBedDisplayed);
        }

        [When(@"Bed field is blank")]
        public void WhenBedFieldIsBlank()
        {
            cvsmDeviceDetailsPage.BedField.Clear();
        }

        [Then(@"Bed field contains hint text")]
        public void ThenBedFieldContainsHintText()
        {
            string ActualHintText = cvsmDeviceDetailsPage.BedLabel.Text;
            string ExpectedHintText = CVSMDeviceDetailsPage.ExpectedValues.BedLabelHintText;
            Assert.AreEqual(ExpectedHintText, ActualHintText);
        }

        [When(@"Room field is blank")]
        public void WhenRoomFieldIsBlank()
        {
            cvsmDeviceDetailsPage.RoomField.Clear();
        }

        [Then(@"Room field contains hint text")]
        public void ThenRoomFieldContainsHintText()
        {
            string ActualHintText = cvsmDeviceDetailsPage.RoomLabel.Text;
            string ExpectedHintText = CVSMDeviceDetailsPage.ExpectedValues.RoomLabelHintText;
            Assert.AreEqual(ExpectedHintText, ActualHintText);
        }

        [Then(@"the Asset Tag value is displayed")]
        public void ThenTheAssetTagValueIsDisplayed()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.EditAssetDetailsPopUPAssetTagValue.GetElementVisibility());
        }

        [Then(@"the Asset Tag value is read only")]
        public void ThenTheAssetTagValueIsReadOnly()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.EditAssetDetailsPopUPAssetTagValue.IsReadOnly());
        }

        [Then(@"the Facility value is displayed")]
        public void ThenTheFacilityValueIsDisplayed()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.EditAssetDetailsPopUPFacilityValue.GetElementVisibility());
        }

        [Then(@"the Facility value is read only")]
        public void ThenTheFacilityValueIsReadOnly()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.EditAssetDetailsPopUPFacilityValue.IsReadOnly());
        }

        [Then(@"the Location ID value is displayed")]
        public void ThenTheLocationIDValueIsDisplayed()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.EditAssetDetailsPopUPLocationValue.GetElementVisibility());
        }

        [Then(@"the Location ID value is read only")]
        public void ThenTheLocationIDValueIsReadOnly()
        {
            Assert.IsTrue(cvsmDeviceDetailsPage.EditAssetDetailsPopUPLocationValue.IsReadOnly());
        }

    }
}
