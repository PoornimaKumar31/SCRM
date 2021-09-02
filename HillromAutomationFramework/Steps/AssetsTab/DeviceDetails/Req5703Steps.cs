using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.AssetsTab.DeviceDetails
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5703")]
    public sealed class Req5703Steps
    {
        readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        CSMDeviceDetailsPage csmDeviceDetailsPage = new CSMDeviceDetailsPage();
        string ExistingRoomAndBed = "";
        string RandomRoomNo = "";
        string RandomBedNo = "";

        private readonly ScenarioContext _scenarioContext;

        public Req5703Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"user is on CSM Edit Asset Details dialog")]
        public void GivenUserIsOnCSMEditAssetDetailsDialog()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.AssetTypeDropDown.SelectDDL(MainPage.ExpectedValues.CSMDeviceName);
            mainPage.SearchField.SendKeys(CSMDeviceDetailsPage.ExpectedValues.SerialNumberwithRoomAndBed + Keys.Enter);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListRowID)));
            Thread.Sleep(2000);
            mainPage.DeviceListRow[0].Click();

            Thread.Sleep(2000);
            ExistingRoomAndBed = csmDeviceDetailsPage.RoomAndBedDetails.Text;
            csmDeviceDetailsPage.CSMDeviceEditButton.Click();
            wait.Message = "CSM edit asset details dialog is not displayed within specifies time.";
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(CSMDeviceDetailsPage.Locators.EditLabelPopupID)));
            bool IsEditAssetDetails = csmDeviceDetailsPage.EditLabelPopup.GetElementVisibility();
            Assert.IsTrue(IsEditAssetDetails, "User is not on CSM Edit Asset Details dialog.");
        }

        [When(@"user changes Room and Bed fields")]
        public void WhenUserChangesRoomAndBedFields()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CSMDeviceDetailsPage.Locators.RoomFieldID)));
            csmDeviceDetailsPage.RoomField.Clear();
            csmDeviceDetailsPage.BedField.Clear();
            RandomRoomNo = GetMethods.GenerateRandomString(5);
            RandomBedNo = GetMethods.GenerateRandomString(5);
            csmDeviceDetailsPage.RoomField.EnterText(RandomRoomNo);
            csmDeviceDetailsPage.BedField.EnterText(RandomBedNo);
        }

        [When(@"user clicks Save button")]
        public void WhenUserClicksSaveButton()
        {
            SetMethods.JavaSciptClick(csmDeviceDetailsPage.SaveButton);
        }

        [Then(@"changed Room and Bed are displayed on the CSM Asset Details page")]
        public void ThenChangedRoomAndBedAreDisplayedOnTheCSMAssetDetailsPage()
        {
            Thread.Sleep(2000);
            bool IsEqual = csmDeviceDetailsPage.RoomAndBedDetails.Text.Equals(RandomRoomNo + "/" + RandomBedNo);
            Assert.AreEqual(true, IsEqual, "Updated Room and Bed is not displayed on Device details page.");
        }

        [When(@"user clears Room field")]
        public void WhenRemovesRoomAndBedDetails()
        {
            csmDeviceDetailsPage.RoomField.Clear();
        }

        [Then(@"Room field contains hint text")]
        public void ThenRoomFieldContainsHintText()
        {
            string RoomHintText = csmDeviceDetailsPage.RoomHintText.Text;
            Assert.AreEqual("Room", RoomHintText, "Room field does not contains hint text.");
        }

        [When(@"user clears Bed field")]
        public void WhenUserClearsBedField()
        {
            Thread.Sleep(1000);
            csmDeviceDetailsPage.BedField.Clear();
        }

        [Then(@"Bed field contains hint text")]
        public void ThenBedFieldContainsHintText()
        {
            string BedHintText = csmDeviceDetailsPage.BedHintText.Text;
            Assert.AreEqual("Bed", BedHintText, "Bed field does not contains hint text.");
        }

        [When(@"user clicks Cancel button")]
        public void WhenUserClicksCancelButton()
        {
            csmDeviceDetailsPage.CancelButton.Click();
        }

        [Then(@"original Room and Bed are displayed on the CSM Asset Details page")]
        public void ThenOriginalRoomAndBedAreDisplayedOnTheCSMAssetDetailsPage()
        {
            Thread.Sleep(2000);
            Assert.AreEqual(ExistingRoomAndBed, csmDeviceDetailsPage.RoomAndBedDetails.Text, "Original Room and Bed is displayed on Device details page.");
        }

        [Then(@"Asset Tag value is displayed")]
        public void ThenAssetTagValueIsDisplayed()
        {
            Assert.AreEqual(true, csmDeviceDetailsPage.AssetTagPopup.Displayed, "Asset Tag value is not displayed.");
        }

        [Then(@"Asset Tag value is read only")]
        public void ThenAssetTagValueIsReadOnly()
        {
            Assert.AreEqual(true, csmDeviceDetailsPage.AssetTagPopup.IsReadOnly(), "Asset Tag value is not read only.");
        }

        [Then(@"Facility value is displayed")]
        public void ThenFacilityValueIsDisplayed()
        {
            Assert.AreEqual(true, csmDeviceDetailsPage.FacilityPopup.Displayed, "Facility value is not displayed.");
        }

        [Then(@"Facility value is read only")]
        public void ThenFacilityValueIsReadOnly()
        {
            Assert.AreEqual(true, csmDeviceDetailsPage.FacilityPopup.IsReadOnly(), "Facility value is not read only.");
        }

        [Then(@"Location ID value is displayed")]
        public void ThenLocationIDValueIsDisplayed()
        {
            Assert.AreEqual(true, csmDeviceDetailsPage.LocationPopup.Displayed, "Location ID value is not displayed.");
        }

        [Then(@"Location ID value is read only")]
        public void ThenLocationIDValueIsReadOnly()
        {
            Assert.AreEqual(true, csmDeviceDetailsPage.LocationPopup.IsReadOnly(), "Location ID value is not read only.");
        }

       
    }
}
