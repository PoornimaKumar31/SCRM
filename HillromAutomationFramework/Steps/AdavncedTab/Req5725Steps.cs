using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AdvancedTab;
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

namespace HillromAutomationFramework.Steps.AdavncedTab
{
    [Binding, Scope(Tag = "SoftwareRequirementID_5725")]
    public sealed class Req5725Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly AdvancedPage _advancePage;

        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        string RandomUsername = "";
        string FullnameRandom = "";



        public Req5725Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _advancePage = new AdvancedPage(driver);
        }

        [Given(@"Manager user is on Add User page")]
        public void GivenManagerUserIsOnAddUserPage()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _advancePage.AdvancedTab.JavaSciptClick(_driver);

            Thread.Sleep(1000);
            bool IsUserListPageDisplayed = (_advancePage.FullnameLabelOnUserList.GetElementVisibility()) || (_advancePage.RoleColumnHeader.GetElementVisibility());
            (IsUserListPageDisplayed).Should().BeTrue(because: "User list page should be displayed.");

            //User is on add user page
            _advancePage.CreateUserOnCreatePage.Click();
            Thread.Sleep(1000);
        }

        [When(@"user enters valid Username")]
        public void WhenUserEntersValidUsername()
        {
            RandomUsername = GetMethods.GenerateRandomUsername(15);
            _advancePage.UserNameTextBoxOnCreatePage.EnterText(RandomUsername);
        }

        [When(@"enters valid Full name")]
        public void WhenEntersValidFullName()
        {
            FullnameRandom = GetMethods.GenerateRandomString(15);
            _advancePage.FullNameOnCreatePage.EnterText(FullnameRandom);
        }

        [When(@"checks User Manager checkbox")]
        public void WhenChecksUserManagerCheckbox()
        {
            Thread.Sleep(1000);
            _advancePage.UserManagerOnCreatePage.JavaSciptClick(_driver);
        }

        [When(@"clicks Save button")]
        public void WhenClicksSaveButton()
        {
            SetMethods.ScrollToBottomofWebpage(_driver);
            Thread.Sleep(2000);
            _advancePage.SaveButtonOnCreatePage.Click();
        }

        [Then(@"User List page is displayed")]
        public void ThenUserListPageIsDisplayed()
        {
            Thread.Sleep(2000);
            SetMethods.ScrollUpWebPage(_driver);
            Thread.Sleep(4000);
            string actualUserListLabelText = _advancePage.UserListLabel.Text;
            string expectedUserListLabelText = AdvancePageExpectedValues.UserListPageLabelText;
            actualUserListLabelText.Should().Be(expectedUserListLabelText, "User List page should be displayed on User Management tab.");
        }

        [Then(@"newly added manager user is displayed")]
        public void ThenNewlyAddedManagerUserIsDisplayed()
        {
            bool isUserManagerDisplayed = false;
            IList<IWebElement> list = _advancePage.UserList;
            list.Count.Should().BeGreaterThan(0, "No user is present except logged User.");

            for (int i = 0; i < list.Count; i++)
            {
                string ActualEmail = list[i].FindElement(By.Id("email" + i)).Text;
                string ActualRole = list[i].FindElement(By.Id("role" + i)).Text;
                if (ActualEmail == RandomUsername && ActualRole == AdvancePageExpectedValues.UserRoleAdministratorOnUserListPage)
                {
                    isUserManagerDisplayed = true;
                    break;
                }
            }
            isUserManagerDisplayed.Should().BeTrue("Newly added manager user should be displayed on User List page.");
        }
    }
}
