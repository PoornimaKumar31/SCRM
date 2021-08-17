using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.PageObjects.AdvancedTab;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.AdavncedTab
{
    [Binding, Scope(Tag = "SoftwareRequirementID_5725")]
    public sealed class Req5725Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        AdvancedPage advancePage = new AdvancedPage();
        string RandomUsername = "";
        string FullnameRandom = "";

        private readonly ScenarioContext _scenarioContext;
        readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

        public Req5725Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Manager user is on Add User page")]
        public void GivenManagerUserIsOnAddUserPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            advancePage.AdvancedTab.JavaSciptClick();
            Thread.Sleep(2000);
            advancePage.CreateUserOnCreatePage.Click();
        }

        [When(@"user enters valid Username")]
        public void WhenUserEntersValidUsername()
        {
            RandomUsername = GetMethods.GenerateRandomUsername(15);
            advancePage.UserNameTextBoxOnCreatePage.EnterText(RandomUsername);
        }

        [When(@"enters valid Full name")]
        public void WhenEntersValidFullName()
        {
            FullnameRandom = GetMethods.GenerateRandomString(15);
            advancePage.FullNameOnCreatePage.EnterText(FullnameRandom);
        }

        [When(@"checks User Manager checkbox")]
        public void WhenChecksUserManagerCheckbox()
        {
            Thread.Sleep(1000);
            advancePage.UserManagerOnCreatePage.JavaSciptClick();
        }

        [When(@"clicks Save button")]
        public void WhenClicksSaveButton()
        {
            SetMethods.ScrollToBottomofWebpage();
            Thread.Sleep(2000);
            advancePage.SaveButtonOnCreatePage.Click();
        }

        [Then(@"User List page is displayed")]
        public void ThenUserListPageIsDisplayed()
        {
            Thread.Sleep(2000);
            SetMethods.ScrollUpWebPage();
            Thread.Sleep(4000);
            string UserListLabelText = advancePage.UserListPage.Text;
            Assert.AreEqual(AdvancedPage.ExpectedValues.UserListPageLabelText, UserListLabelText, "User list page is not displayed");
        }

        [Then(@"newly added manager user is displayed")]
        public void ThenNewlyAddedManagerUserIsDisplayed()
        {
            bool IsNewlyAddedManagerUserDisplayed = advancePage.NewlyAddedManagerUserIsDisplayed(FullnameRandom, RandomUsername);
            Assert.IsTrue(IsNewlyAddedManagerUserDisplayed, "Newly added manager user is not displayed.");
        }
    }
}
