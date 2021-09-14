using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.UpdatesTab.UpgradeUpdate
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5706")]
    class Req5706Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly UpdatesSelectUpdatePage _updatesSelectUpdatePage;
        private readonly UpdateSelectDevicesPage _updateSelectDevicesPage;
        private readonly UpdateReviewActionPage _updateReviewActionPage;

        private readonly WebDriverWait _wait;
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public Req5706Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
            _updatesSelectUpdatePage = new UpdatesSelectUpdatePage(driver);
            _updateSelectDevicesPage = new UpdateSelectDevicesPage(driver);
            _updateReviewActionPage = new UpdateReviewActionPage(driver);
        }

        [Given(@"user is on CSM Review Action page")]
        public void GivenUserIsOnCSMReviewActionPage()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.UpdatesTab.JavaSciptClick(_driver);

            //updates tab
            _updatesSelectUpdatePage.AssetTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.CSMDeviceName);
            _updatesSelectUpdatePage.UpgradeTypeDropDown.SelectDDL(UpdatesSelectUpdatePage.ExpectedValues.UpdateTypeUpgrade);

            //first upgrade file
            _updatesSelectUpdatePage.FirstFileCVSMAndCentrellaInTable.Click();
            _updatesSelectUpdatePage.NextButton.Click();

            //Select device page
            bool IsSelectDevicePageDisplayed = (_updateSelectDevicesPage.ItemtoPush.GetElementVisibility()) || (_updateSelectDevicesPage.DeviceTypeLabel.GetElementVisibility());
            (IsSelectDevicePageDisplayed).Should().BeTrue(because: "Select devices page should be displayed when userclicks enabled next button in CSM Upgrade Select update page");

            //Select first device and click on next button
            _updateSelectDevicesPage.FirstDeviceCheckBox.Click();
            _updateSelectDevicesPage.NextButton.Click();

            bool IsReviewActionPageDisplayed = (_updateReviewActionPage.ItemToPushLabel.GetElementVisibility()) || (_updateReviewActionPage.DestinationLabel.GetElementVisibility());
            (IsReviewActionPageDisplayed).Should().BeTrue(because: "Review action page should be displayed when user clicks enabled next button in CSM Upgrade Select Assets page");
        }

        [When(@"user clicks Schedule radio button")]
        public void WhenUserClicksScheduleRadioButton()
        {
            _updateReviewActionPage.ScheduleCheckbox.Click();

        }

        [Then(@"Date label is displayed")]
        public void ThenDateLabelIsDisplayed()
        {
            (_updateReviewActionPage.DateLabel.GetElementVisibility()).Should().BeTrue(because: "Date Label should be displayed in CSM Upgrade Review action page");
            string DateLabelText = _updateReviewActionPage.DateLabel.Text;
            (DateLabelText).Should().BeEquivalentTo(UpdateReviewActionPage.ExpectedValues.DateLabelText, because: "Date label text should match with the expected value in CSM Upgrade Review action page.");
        }

        [Then(@"Calendar icon is displayed")]
        public void ThenCalendarIconIsDisplayed()
        {
            (_updateReviewActionPage.CalendarIcon.GetElementVisibility()).Should().BeTrue(because: "Calendar Icon should be displayed in CSM Upgrade Review action page");
        }

        [Then(@"Time label is displayed")]
        public void ThenTimeLabelIsDisplayed()
        {
            (_updateReviewActionPage.TimeLabel.GetElementVisibility()).Should().BeTrue(because: "Time Label should be displayed in CSM Upgrade Review action page");
            string TimeLabelText = _updateReviewActionPage.TimeLabel.Text;
            (TimeLabelText).Should().BeEquivalentTo(UpdateReviewActionPage.ExpectedValues.TimeLabelText, because: "Time label should match with the expected value in CSM Upgrade Review action page.");
        }

        [Then(@"Hour dropdown is displayed")]
        public void ThenHourDropdownIsDisplayed()
        {
            (_updateReviewActionPage.HourDDL.GetElementVisibility()).Should().BeTrue(because: "Hour dropdown should be displayed in CSM Upgrade Review action page");
        }

        [Then(@"Minutes dropdown is displayed")]
        public void ThenMinutesDropdownIsDisplayed()
        {
            (_updateReviewActionPage.MinuteDDL.GetElementVisibility()).Should().BeTrue(because: "Minute dropdown should be displayed in CSM Upgrade Review action page");
        }

        [Then(@"Confirm button is displayed")]
        public void ThenConfirmButtonIsDisplayed()
        {
            (_updateReviewActionPage.ConfirmButton.GetElementVisibility()).Should().BeTrue(because: "Confirm button should be displayed in CSM Upgrade Review action page");
        }

        [Then(@"Previous button is displayed")]
        public void ThenPreviousButtonIsDisplayed()
        {
            (_updateReviewActionPage.PreviousButton.GetElementVisibility()).Should().BeTrue(because: "Previous Button should be displayed in CSM Upgrade Review action page");
        }

        [When(@"clicks Hour dropdown")]
        public void WhenClicksHourDropdown()
        {
            _updateReviewActionPage.HourDDL.Click();
        }

        [Then(@"Hour dropdown displays (.*) to (.*)")]
        public void ThenHourDropdownDisplaysTo(int startPoint, int endPoint)
        {
            IList<IWebElement> AllOptions = _updateReviewActionPage.HourDDL.GetAllOptionsFromDDL();
            List<int> AllOptionsText = new List<int>();
            foreach(IWebElement option in AllOptions)
            {
                AllOptionsText.Add(int.Parse(option.Text));
            }
            int noOfOptions = (endPoint - startPoint) + 1;

            List<int> ExpectedOptionsList = (Enumerable.Range(startPoint, noOfOptions)).ToList();

            AllOptionsText.Should().Equal(ExpectedOptionsList, because: "Hour dropdown should contain all the options within range "+startPoint+" and "+endPoint);
        }

        [When(@"clicks Minutes dropdown")]
        public void WhenClicksMinutesDropdown()
        {
            _updateReviewActionPage.MinuteDDL.Click();
        }

        [Then(@"Minutes dropdown displays (.*), (.*), (.*) and (.*)")]
        public void ThenMinutesDropdownDisplaysAnd(int option1, int option2, int option3, int option4)
        {
            IList<IWebElement> AllOptions = _updateReviewActionPage.MinuteDDL.GetAllOptionsFromDDL();
            List<int> AllOptionsText = new List<int>();
            foreach (IWebElement option in AllOptions)
            {
                AllOptionsText.Add(int.Parse(option.Text));
            }
            List<int> ExpectedOptionList = new List<int> { option1,option2,option3,option4};

            AllOptionsText.Should().Equal(ExpectedOptionList, because: "Minutes drop down should contain only {0} {1} {2} {3}", option1, option2,option3,option4);
        }

        [When(@"user selects Date from Date selector icon")]
        public void WhenUserSelectsDateFromDateSelectorIcon()
        {
            _updateReviewActionPage.CalendarIcon.Click();
            _updateReviewActionPage.Date.Click();
        }

        [When(@"selects hours between (.*)")]
        public void WhenSelectsHoursBetween(string p0)
        {
            //Selecting Random Hours
            var random = new Random();
            IList<IWebElement> AllOptions = _updateReviewActionPage.HourDDL.GetAllOptionsFromDDL();
            int index = random.Next(1,AllOptions.Count);
            _updateReviewActionPage.HourDDL.SelectDDL(AllOptions[index].Text);
        }

        [When(@"selects minutes between (.*)")]
        public void WhenSelectsMinutesBetween(string p0)
        {
            //Selecting Random Minutes
            var random = new Random();
            IList<IWebElement> AllOptions = _updateReviewActionPage.MinuteDDL.GetAllOptionsFromDDL();
            int index = random.Next(AllOptions.Count);
            _updateReviewActionPage.MinuteDDL.SelectDDL(AllOptions[index].Text);
        }

        [When(@"clicks Confirm button")]
        public void WhenClicksConfirmButton()
        {
            _updateReviewActionPage.ConfirmButton.Click();
        }

        [Then(@"Upgrade process has been established message is displayed")]
        public void ThenUpgradeProcessHasBeenEstablishedMessageIsDisplayed()
        {
            _wait.Until(ExplicitWait.ElementIsVisible(By.ClassName(UpdateSelectDevicesPage.Locators.SuccessUpadteMessageClassName)));
            (_updateSelectDevicesPage.SuccessUpadteMessage.GetElementVisibility()).Should().BeTrue(because: "Update process Message should be displayed when user clicks confirm button on CSM Upgrade review action page.");
            (_updateSelectDevicesPage.SuccessUpadteMessage.Text).Should().BeEquivalentTo(UpdateSelectDevicesPage.ExpectedValues.UpdateProcessMessageText, because: "Update message should match with the expected value.");
        }

        [Then(@"Select Assets page is displayed")]
        public void ThenSelectAssetsPageIsDisplayed()
        {
            bool IsSelectDevicePageDisplayed = (_updateSelectDevicesPage.ItemtoPush.GetElementVisibility()) || (_updateSelectDevicesPage.DeviceTypeLabel.GetElementVisibility());
            (IsSelectDevicePageDisplayed).Should().BeTrue(because: "Select devices page should be displayed");
        }
    }
}
