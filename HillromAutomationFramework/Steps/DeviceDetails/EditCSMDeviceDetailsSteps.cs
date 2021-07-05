using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.EditDeviceDetails
{
    [Binding]
    public class EditCSMDeviceDetailsSteps
    {
        readonly ScenarioContext _scenarioContext;
        readonly LoginPage loginPage = new LoginPage();
        

        public EditCSMDeviceDetailsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"user has selected CSM device")]
        public void GivenUserHasSelectedCSMDevice()
        {
            
        }
        
        [Given(@"user is on Device Details page")]
        public void GivenUserIsOnDeviceDetailsPage()
        {
            _scenarioContext.Pending();
        }
        
        [When(@"user clicks Edit button")]
        public void WhenUserClicksEditButton()
        {
            _scenarioContext.Pending();
        }
        
        [Then(@"Room and Bed can be entered")]
        public void ThenRoomAndBedCanBeEntered()
        {
            _scenarioContext.Pending();
        }
        
        [Then(@"Saved")]
        public void ThenSaved()
        {
            _scenarioContext.Pending();
        }
        
        [Then(@"Entered Room, Bed is displayed on Device page")]
        public void ThenEnteredRoomBedIsDisplayedOnDevicePage()
        {
            _scenarioContext.Pending();
        }

        [Given(@"user has selected CSM device with Room, Bed")]
        public void GivenUserHasSelectedCSMDeviceWithRoomBed()
        {
            _scenarioContext.Pending();
        }

        [Then(@"the existing Room , Bed is editable")]
        public void ThenTheExistingRoomBedIsEditable()
        {
            _scenarioContext.Pending();
        }

        [Then(@"Updated Room, Bed is displayed on Device page")]
        public void ThenUpdatedRoomBedIsDisplayedOnDevicePage()
        {
            _scenarioContext.Pending();
        }

        [Then(@"the existing Room , Bed can be removed")]
        public void ThenTheExistingRoomBedCanBeRemoved()
        {
            _scenarioContext.Pending();
        }

        [Then(@"Blank Room, Bed is displayed on Device page")]
        public void ThenBlankRoomBedIsDisplayedOnDevicePage()
        {
            _scenarioContext.Pending();
        }

        [When(@"Room, Bed is entered and cancelled")]
        public void WhenRoomBedIsEnteredAndCancelled()
        {
            _scenarioContext.Pending();
        }

        [Then(@"Entered Room, Bed is not displayed on Device page")]
        public void ThenEnteredRoomBedIsNotDisplayedOnDevicePage()
        {
            _scenarioContext.Pending();
        }

        [When(@"Room, Bed is updated and cancelled")]
        public void WhenRoomBedIsUpdatedAndCancelled()
        {
            _scenarioContext.Pending();
        }

        [Then(@"Updated Room, Bed is not displayed on Device page")]
        public void ThenUpdatedRoomBedIsNotDisplayedOnDevicePage()
        {
            _scenarioContext.Pending();
        }

        [When(@"Room, Bed is removed and cancelled")]
        public void WhenRoomBedIsRemovedAndCancelled()
        {
            _scenarioContext.Pending();
        }

        [Then(@"Room, Bed is not removed on Device page")]
        public void ThenRoomBedIsNotRemovedOnDevicePage()
        {
            _scenarioContext.Pending();
        }



    }
}
