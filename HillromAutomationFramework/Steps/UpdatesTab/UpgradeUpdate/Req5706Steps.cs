using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.UpdatesTab.UpgradeUpdate
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5706")]
    class Req5706Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        UpdatesSelectUpdatePage updatesSelectUpdatePage = new UpdatesSelectUpdatePage();
        UpdateSelectDevicesPage updateSelectDevicesPage = new UpdateSelectDevicesPage();
        UpdateReviewActionPage updateReviewActionPage = new UpdateReviewActionPage();

        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        private ScenarioContext _scenarioContext;

        public Req5706Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"user is on CSM Review Action page")]
        public void GivenUserIsOnCSMReviewActionPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.UpdatesTab.JavaSciptClick();
            //updates tab
            updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.CSMDeviceName);
            updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade);

            //first upgrade file
            updatesSelectUpdatePage.FirstFileCVSMAndCentrellaInTable.Click();

            updatesSelectUpdatePage.NextButton.Click();
            //Select device page
            bool IsSelectDevicePage = (updateSelectDevicesPage.ItemtoPush.GetElementVisibility()) || (updateSelectDevicesPage.DeviceTypeLabel.GetElementVisibility());
            Assert.AreEqual(true, IsSelectDevicePage, "Select devices page is not displayed");

            updateSelectDevicesPage.FirstDeviceCheckBox.Click();

            updateSelectDevicesPage.NextButton.Click();

            bool IsReviewActionPage = (updateReviewActionPage.ItemToPushLabel.GetElementVisibility()) || (updateReviewActionPage.DestinationLabel.GetElementVisibility());
            Assert.AreEqual(true, IsReviewActionPage, "CSM Review action page is not displayed.");
        }

        [When(@"user clicks Schedule radio button")]
        public void WhenUserClicksScheduleRadioButton()
        {
            updateReviewActionPage.ScheduleCheckbox.Click();

        }

        [Then(@"Date label is displayed")]
        public void ThenDateLabelIsDisplayed()
        {
            Assert.AreEqual(true, updateReviewActionPage.DateLabel.GetElementVisibility(), "Date Label is not displayed");
            Assert.AreEqual(UpdateReviewActionPage.ExpectedValues.DateLabelText, updateReviewActionPage.DateLabel.Text, "Date label is not matching with the expected value.");
        }

        [Then(@"Calendar icon is displayed")]
        public void ThenCalendarIconIsDisplayed()
        {
            Assert.AreEqual(true, updateReviewActionPage.CalendarIcon.GetElementVisibility(), "Calendar Icon is not displayed");
        }

        [Then(@"Time label is displayed")]
        public void ThenTimeLabelIsDisplayed()
        {
            Assert.AreEqual(true, updateReviewActionPage.TimeLabel.GetElementVisibility(), "Time Label is not displayed");
            Assert.AreEqual(UpdateReviewActionPage.ExpectedValues.TimeLabelText, updateReviewActionPage.TimeLabel.Text, "Time label is not matching the expected value.");
        }

        [Then(@"Hour dropdown is displayed")]
        public void ThenHourDropdownIsDisplayed()
        {
            Assert.AreEqual(true, updateReviewActionPage.HourDDL.GetElementVisibility(), "Hour Label is not displayed");
        }

        [Then(@"Minutes dropdown is displayed")]
        public void ThenMinutesDropdownIsDisplayed()
        {
            Assert.AreEqual(true, updateReviewActionPage.MinuteDDL.GetElementVisibility(), "Minute Label is not displayed");
        }

        [Then(@"Confirm button is displayed")]
        public void ThenConfirmButtonIsDisplayed()
        {
            Assert.AreEqual(true, updateReviewActionPage.ConfirmButton.GetElementVisibility(), "Confirm button is not displayed");
        }

        [Then(@"Previous button is displayed")]
        public void ThenPreviousButtonIsDisplayed()
        {
            Assert.AreEqual(true, updateReviewActionPage.PreviousButton.GetElementVisibility(), "Previous Button is not displayed");
        }

        [When(@"clicks Hour dropdown")]
        public void WhenClicksHourDropdown()
        {
            updateReviewActionPage.HourDDL.Click();
        }

        [Then(@"Hour dropdown displays (.*) to (.*)")]
        public void ThenHourDropdownDisplaysTo(int p0, int p1)
        {
            IList<IWebElement> AllOptions = updateReviewActionPage.HourDDL.GetAllOptionsFromDDL();
            Assert.AreEqual((p1 - p0)+1, AllOptions.Count, "All elements are not present");
        }

        [When(@"clicks Minutes dropdown")]
        public void WhenClicksMinutesDropdown()
        {
            updateReviewActionPage.MinuteDDL.Click();
        }

        [Then(@"Minutes dropdown displays (.*), (.*), (.*) and (.*)")]
        public void ThenMinutesDropdownDisplaysAnd(int p0, int p1, int p2, int p3)
        {
            IList<IWebElement> AllOptions = updateReviewActionPage.MinuteDDL.GetAllOptionsFromDDL();
            Assert.AreEqual(4, AllOptions.Count, "All Elements are not present in Minutes dropdows");
        }

        [When(@"user selects Date from Date selector icon")]
        public void WhenUserSelectsDateFromDateSelectorIcon()
        {
            updateReviewActionPage.CalendarIcon.Click();
            updateReviewActionPage.Date.Click();
        }

        [When(@"selects hours between (.*)")]
        public void WhenSelectsHoursBetween(string p0)
        {
            var random = new Random();
            IList<IWebElement> AllOptions = updateReviewActionPage.HourDDL.GetAllOptionsFromDDL();
            int index = random.Next(AllOptions.Count);
            updateReviewActionPage.HourDDL.SelectDDL(AllOptions[index].Text);
        }

        [When(@"selects minutes between (.*)")]
        public void WhenSelectsMinutesBetween(string p0)
        {
            var random = new Random();
            IList<IWebElement> AllOptions = updateReviewActionPage.MinuteDDL.GetAllOptionsFromDDL();
            int index = random.Next(AllOptions.Count);
            updateReviewActionPage.MinuteDDL.SelectDDL(AllOptions[index].Text);
        }

        [When(@"clicks Confirm button")]
        public void WhenClicksConfirmButton()
        {
            updateReviewActionPage.ConfirmButton.Click();
        }

        [Then(@"Upgrade process has been established message is displayed")]
        public void ThenUpgradeProcessHasBeenEstablishedMessageIsDisplayed()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(UpdateSelectDevicesPage.Locators.SuccessUpadteMessageClassName)));
            Assert.AreEqual(true, updateSelectDevicesPage.SuccessUpadteMessage.GetElementVisibility(), "Update message is not displayed.");
            Assert.AreEqual(UpdateSelectDevicesPage.ExpectedValues.UpdateProcessMessageText, updateSelectDevicesPage.SuccessUpadteMessage.Text, "Update message is matching the expected value.");
        }

        [Then(@"Select Assets page is displayed")]
        public void ThenSelectAssetsPageIsDisplayed()
        {
            Assert.AreEqual(true, updateSelectDevicesPage.ItemtoPush.GetElementVisibility(), "Page is not loaded");
        }
    }
}
