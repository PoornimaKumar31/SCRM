using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Updates
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5706")]
    class Req5706Steps
    {
        LoginPage loginPage = new LoginPage();
        MainPage mainPage = new MainPage();
        CSMUpdatesPage csmUpdatesPage = new CSMUpdatesPage();
        CSMConfigDeliverPage csmConfigDeliverPage = new CSMConfigDeliverPage();

        [Given(@"user is on CSM Review Action page")]
        public void GivenUserIsOnCSMReviewActionPage()
        {
            loginPage.SignIn("AdminWithoutRollUp");
            mainPage.UpdatesTab.JavaSciptClick();
            csmUpdatesPage.AssetTypeDDL.SelectDDL(CSMConfigDeliverPage.ExpectedValues.CSMDeviceName);
            string SelectedAssetType = csmUpdatesPage.AssetTypeDDL.GetSelectedOptionFromDDL();
            string ExpectedAssetType = CSMConfigDeliverPage.ExpectedValues.CSMDeviceName;
            Assert.AreEqual(ExpectedAssetType, SelectedAssetType, "CSM is not selected as asset type.\n");
            csmUpdatesPage.UpdateTypeDDL.SelectDDL(CSMUpdatesPage.ExpectedValue.UpdateTypeUpgrade);

            csmUpdatesPage.UpgradeFile.Click();

            csmUpdatesPage.NextButton.Click();
            bool IsSelectDevicePage = (csmConfigDeliverPage.ItemToPushLabel.GetElementVisibility()) || (csmConfigDeliverPage.DeviceType.GetElementVisibility());
            Assert.AreEqual(true, IsSelectDevicePage, "Select devices page is not displayed");

            csmConfigDeliverPage.FirstDeviceInTable.Click();

            PropertyClass.Driver.FindElement(By.Id("nextbtn")).Click();

            bool IsReviewActionPage = (csmConfigDeliverPage.ReviewActionItemToPushLabel.GetElementVisibility()) || (csmConfigDeliverPage.ReviewActionDestinationLabel.GetElementVisibility());
            Assert.AreEqual(true, IsReviewActionPage, "CSM Reiew action page is not displayed.");
        }

        [When(@"user clicks schedule radio button")]
        public void WhenUserClicksScheduleRadioButton()
        {
            csmUpdatesPage.ScheduleCheckbox.Click();

        }

        [Then(@"Date label is displayed")]
        public void ThenDateLabelIsDisplayed()
        {
            Assert.AreEqual(true, csmUpdatesPage.DateLabel.GetElementVisibility(), "Date Label is not displayed");
        }

        [Then(@"Calendar icon is displayed")]
        public void ThenCalendarIconIsDisplayed()
        {
            Assert.AreEqual(true, csmUpdatesPage.CalendarIcon.GetElementVisibility(), "Calendar Icon is not displayed");
        }

        [Then(@"Time label is displayed")]
        public void ThenTimeLabelIsDisplayed()
        {
            Assert.AreEqual(true, csmUpdatesPage.TimeLabel.GetElementVisibility(), "Time Label is not displayed");
        }

        [Then(@"Hour dropdown is displayed")]
        public void ThenHourDropdownIsDisplayed()
        {
            Assert.AreEqual(true, csmUpdatesPage.HourDDL.GetElementVisibility(), "Hour Label is not displayed");
        }

        [Then(@"Minutes dropdown is displayed")]
        public void ThenMinutesDropdownIsDisplayed()
        {
            Assert.AreEqual(true, csmUpdatesPage.MinuteDDL.GetElementVisibility(), "Minute Label is not displayed");
        }

        [Then(@"Confirm button is displayed")]
        public void ThenConfirmButtonIsDisplayed()
        {
            Assert.AreEqual(true, csmUpdatesPage.ConfirmButton.GetElementVisibility(), "Confirm button is not displayed");
        }

        [Then(@"Previous button is displayed")]
        public void ThenPreviousButtonIsDisplayed()
        {
            Assert.AreEqual(true, csmUpdatesPage.PreviousButton.GetElementVisibility(), "Previous Button is not displayed");
        }

        [When(@"clicks Hour dropdown")]
        public void WhenClicksHourDropdown()
        {
            csmUpdatesPage.HourDDL.Click();
        }

        [Then(@"Hour dropdown displays (.*) to (.*)")]
        public void ThenHourDropdownDisplaysTo(int p0, int p1)
        {
            IList<IWebElement> AllOptions = csmUpdatesPage.HourDDL.GetAllOptionsFromDDL();
            Assert.AreEqual((p1 - p0)+1, AllOptions.Count, "All elements are not present");
        }

        [When(@"clicks Minutes dropdown")]
        public void WhenClicksMinutesDropdown()
        {
            csmUpdatesPage.MinuteDDL.Click();
        }

        [Then(@"Minutes dropdown displays (.*), (.*), (.*) and (.*)")]
        public void ThenMinutesDropdownDisplaysAnd(int p0, int p1, int p2, int p3)
        {
            IList<IWebElement> AllOptions = csmUpdatesPage.MinuteDDL.GetAllOptionsFromDDL();
            Assert.AreEqual(4, AllOptions.Count, "All Elements are not present in Minutes dropdows");
        }

        [When(@"user selects Date from Date selector icon")]
        public void WhenUserSelectsDateFromDateSelectorIcon()
        {
            csmUpdatesPage.CalendarIcon.Click();
            csmUpdatesPage.Date.Click();
        }

        [When(@"selects hours between (.*)")]
        public void WhenSelectsHoursBetween(string p0)
        {
            var random = new Random();
            IList<IWebElement> AllOptions = csmUpdatesPage.HourDDL.GetAllOptionsFromDDL();
            int index = random.Next(AllOptions.Count);
            csmUpdatesPage.HourDDL.SelectDDL(AllOptions[index].Text);
        }

        [When(@"selects minutes between (.*)")]
        public void WhenSelectsMinutesBetween(string p0)
        {
            var random = new Random();
            IList<IWebElement> AllOptions = csmUpdatesPage.MinuteDDL.GetAllOptionsFromDDL();
            int index = random.Next(AllOptions.Count);
            csmUpdatesPage.MinuteDDL.SelectDDL(AllOptions[index].Text);
        }

        [When(@"clicks Confirm button")]
        public void WhenClicksConfirmButton()
        {
            csmUpdatesPage.ConfirmButton.Click();
        }

        [Then(@"Upgrade process has been established message is displayed")]
        public void ThenUpgradeProcessHasBeenEstablishedMessageIsDisplayed()
        {
            //Assert.Pass("Implementation will be done once ID will be provided");
        }

        [Then(@"Select Assets page is displayed")]
        public void ThenSelectAssetsPageIsDisplayed()
        {
            Thread.Sleep(5000);
            Assert.AreEqual(true, csmConfigDeliverPage.ItemToPushLabel.GetElementVisibility(), "Page is not loaded");
        }
    }
}
