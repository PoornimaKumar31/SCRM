using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.EditDeviceDetails
{
    [Binding]
    public class EditCSMDeviceDetailsSteps
    {
        readonly ScenarioContext _scenarioContext;
        readonly LoginPage loginPage = new LoginPage();
        readonly MainPage mainPage = new MainPage();
        readonly DeviceDetailsPage deviceDetailsPage = new DeviceDetailsPage();
        readonly CSMDeviceDetailsPage cSMDeviceDetailsPage = new CSMDeviceDetailsPage();
        string ExistingRoomAndBed;


        public EditCSMDeviceDetailsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"user has selected CSM device with details not set")]
        public void GivenUserHasSelectedCSMDevice()
        {
<<<<<<< HEAD
            
=======
            loginPage.SignIn("AdminWithoutRollupPage");
            SelectElement selectAssetType = new SelectElement(mainPage.AssetTypeDropDown);
            selectAssetType.SelectByText(MainPage.ExpectedValues.CSMDeviceName);
            //select the row according to the data
            cSMDeviceDetailsPage.CSMDevices[0].Clicks();
>>>>>>> 0e9de7d74c51f765d5ef38f8af94c1c73b4ad6db
        }
        
        [Given(@"user is on Device Details page")]
        public void GivenUserIsOncSMDeviceDetailsPage()
        {
            Assert.IsTrue(deviceDetailsPage.AssetLabel.GetElementVisibility());
            Assert.IsTrue(deviceDetailsPage.AssetData.GetElementVisibility());
        }
        
        [When(@"user clicks Edit button")]
        public void WhenUserClicksEditButton()
        {
            Thread.Sleep(1000);
            ExistingRoomAndBed = cSMDeviceDetailsPage.RoomAndBedDetails.Text;
            cSMDeviceDetailsPage.CSMDeviceEditButton.Clicks();
        }
        
        [Then(@"Room and Bed can be entered")]
        public void ThenRoomAndBedCanBeEntered()
        {
            cSMDeviceDetailsPage.RoomField.EnterText(CSMDeviceDetailsPage.ExpectedValues.NewRoomValue);
            cSMDeviceDetailsPage.BedField.EnterText(CSMDeviceDetailsPage.ExpectedValues.NewBedValue);
        }
        
        [Then(@"Saved")]
        public void ThenSaved()
        {
            cSMDeviceDetailsPage.SaveButton.Clicks();
        }
        
        [Then(@"Entered Room, Bed is displayed on Device page")]
        public void ThenEnteredRoomBedIsDisplayedOnDevicePage()
        {
            //Need to upgrade
            Thread.Sleep(500);
            string ActualRoomAndBedText = cSMDeviceDetailsPage.RoomAndBedDetails.Text;
            string ExpectedRoomAndBedText = CSMDeviceDetailsPage.ExpectedValues.NewRoomValue + "/" + CSMDeviceDetailsPage.ExpectedValues.NewBedValue;
            Assert.AreEqual(ExpectedRoomAndBedText,ActualRoomAndBedText);
        }

        [Given(@"user has selected CSM device with Room, Bed")]
        public void GivenUserHasSelectedCSMDeviceWithRoomBed()
        {
            loginPage.SignIn("AdminWithoutRollupPage");
            SelectElement selectAssetType = new SelectElement(mainPage.AssetTypeDropDown);
            selectAssetType.SelectByText(MainPage.ExpectedValues.CSMDeviceName);
            cSMDeviceDetailsPage.CSMDevices[1].Clicks();
        }

        [Then(@"the existing Room , Bed is editable")]
        public void ThenTheExistingRoomBedIsEditable()
        {
            //Clearing the input fields and entering the values
            cSMDeviceDetailsPage.RoomField.Clear();
            cSMDeviceDetailsPage.RoomField.EnterText(CSMDeviceDetailsPage.ExpectedValues.NewRoomValue);
            cSMDeviceDetailsPage.BedField.Clear();
            cSMDeviceDetailsPage.BedField.EnterText(CSMDeviceDetailsPage.ExpectedValues.NewBedValue);
        }

        [Then(@"Updated Room, Bed is displayed on Device page")]
        public void ThenUpdatedRoomBedIsDisplayedOnDevicePage()
        {
            //Need to upgrade
            Thread.Sleep(500);
            string ActualRoomAndBedText = cSMDeviceDetailsPage.RoomAndBedDetails.Text;
            string ExpectedRoomAndBedText = CSMDeviceDetailsPage.ExpectedValues.NewRoomValue + "/" + CSMDeviceDetailsPage.ExpectedValues.NewBedValue;
            Assert.AreEqual(ExpectedRoomAndBedText, ActualRoomAndBedText);
        }


        [Given(@"user has selected CSM device with Room, Bed details")]
        public void GivenUserHasSelectedNewCSMDeviceWithRoomBed()
        {
            loginPage.SignIn("AdminWithoutRollupPage");
            SelectElement selectAssetType = new SelectElement(mainPage.AssetTypeDropDown);
            selectAssetType.SelectByText(MainPage.ExpectedValues.CSMDeviceName);
            cSMDeviceDetailsPage.CSMDevices[2].Clicks();
        }

        [Then(@"the existing Room , Bed can be removed")]
        public void ThenTheExistingRoomBedCanBeRemoved()
        {
            cSMDeviceDetailsPage.RoomField.Clear();
            cSMDeviceDetailsPage.BedField.Clear();
        }

        [Then(@"Blank Room, Bed is displayed on Device page")]
        public void ThenBlankRoomBedIsDisplayedOnDevicePage()
        {
            //Need to upgrade
            Thread.Sleep(1000);
            string ActualRoomAndBedText = cSMDeviceDetailsPage.RoomAndBedDetails.Text;
            string ExpectedRoomAnBedText = CSMDeviceDetailsPage.ExpectedValues.RoomAndBedNotSet;
            Assert.AreEqual(ExpectedRoomAnBedText, ActualRoomAndBedText);
        }

        [When(@"Room, Bed is entered and cancelled")]
        public void WhenRoomBedIsEnteredAndCancelled()
        {
            cSMDeviceDetailsPage.RoomField.EnterText(CSMDeviceDetailsPage.ExpectedValues.UpdateRoomValue);
            cSMDeviceDetailsPage.BedField.EnterText(CSMDeviceDetailsPage.ExpectedValues.UpdateBedValue);
            //Clicking on cancel button
            cSMDeviceDetailsPage.CancelButton.Click();
        }

        [Then(@"Entered Room, Bed is not displayed on Device page")]
        public void ThenEnteredRoomBedIsNotDisplayedOnDevicePage()
        {
            //Need to upgarde
            Thread.Sleep(500);
            string ActualRoomAndBed = cSMDeviceDetailsPage.RoomAndBedDetails.Text;
            string EnteredRoomAndBed = CSMDeviceDetailsPage.ExpectedValues.UpdateRoomValue + "/" + CSMDeviceDetailsPage.ExpectedValues.UpdateBedValue;
            Assert.AreNotEqual(EnteredRoomAndBed, ActualRoomAndBed);
        }

        [When(@"Room, Bed is updated and cancelled")]
        public void WhenRoomBedIsUpdatedAndCancelled()
        {
            cSMDeviceDetailsPage.RoomField.Clear();
            cSMDeviceDetailsPage.RoomField.EnterText(CSMDeviceDetailsPage.ExpectedValues.UpdateRoomValue);
            cSMDeviceDetailsPage.BedField.Clear();
            cSMDeviceDetailsPage.BedField.EnterText(CSMDeviceDetailsPage.ExpectedValues.UpdateBedValue);

            //cancelling
            cSMDeviceDetailsPage.CancelButton.Clicks();
        }

        [Then(@"Updated Room, Bed is not displayed on Device page")]
        public void ThenUpdatedRoomBedIsNotDisplayedOnDevicePage()
        {
            //Need to upgrade
            Thread.Sleep(500);
            string ActualRoomAndBed = cSMDeviceDetailsPage.RoomAndBedDetails.Text;
            string UpdatedRoomAndBed = CSMDeviceDetailsPage.ExpectedValues.UpdateRoomValue + "/" + CSMDeviceDetailsPage.ExpectedValues.UpdateBedValue;
            Assert.AreNotEqual(UpdatedRoomAndBed, ActualRoomAndBed);
        }

        [When(@"Room, Bed is removed and cancelled")]
        public void WhenRoomBedIsRemovedAndCancelled()
        {
            cSMDeviceDetailsPage.RoomField.Clear();
            cSMDeviceDetailsPage.BedField.Clear();
            //Cancelling
            cSMDeviceDetailsPage.CancelButton.Clicks();
        }

        [Then(@"Room, Bed is not removed on Device page")]
        public void ThenRoomBedIsNotRemovedOnDevicePage()
        {
            //Need To Upgrade
            Thread.Sleep(500);
            string ActualRoomAndBed = cSMDeviceDetailsPage.RoomAndBedDetails.Text;
            Assert.AreEqual(ExistingRoomAndBed, ActualRoomAndBed);
        }



    }
}
