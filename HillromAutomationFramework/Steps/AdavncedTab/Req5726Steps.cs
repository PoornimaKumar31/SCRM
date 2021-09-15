using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AdvancedTab;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.AdavncedTab
{
    [Binding, Scope(Tag = "SoftwareRequirementID_5726")]
    public class Req5726Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly AdvancedPage _advancePage;

        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        string randomUsername = null;
        string randomFullName = null;

        public Req5726Steps(ScenarioContext scenarioContext, IWebDriver driver)
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
            //Clicking on facility
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _advancePage.AdvancedTab.JavaSciptClick(_driver);

            Thread.Sleep(2000);
            bool IsUserListPageDisplayed = (_advancePage.FullnameLabelOnUserList.GetElementVisibility()) || (_advancePage.RoleColumnHeader.GetElementVisibility());
            (IsUserListPageDisplayed).Should().BeTrue(because: "User list page should be displayed.");

            //User is on add user page
            _advancePage.CreateUserOnCreatePage.Click();
            Thread.Sleep(1000);
        }
        
        [When(@"user enters valid Username")]
        public void WhenUserEntersValidUsername()
        {
            randomUsername = GetMethods.GenerateRandomUsername(15);
            _advancePage.UserNameTextBoxOnCreatePage.EnterText(randomUsername);
        }
        
        [When(@"enters valid Full name")]
        public void WhenEntersValidFullName()
        {
            randomFullName = GetMethods.GenerateRandomString(15);
            _advancePage.FullNameOnCreatePage.EnterText(randomFullName);
        }
        
        [When(@"unchecks User Manager checkbox")]
        public void WhenUnchecksUserManagerCheckbox()
        {
            bool IsCheckboxSelected = _advancePage.UserManagerOnCreatePage.Selected;

            if (IsCheckboxSelected == true)
            {
                _advancePage.UserManagerOnCreatePage.JavaSciptClick(_driver);
            }
        }
        
        [When(@"clicks Save button")]
        public void WhenClicksSaveButton()
        {
            SetMethods.ScrollToBottomofWebpage(_driver);
            _advancePage.SaveButtonOnCreatePage.ClickWebElement(_driver,"Save Button");
        }
        
        [Then(@"User List page is displayed")]
        public void ThenUserListPageIsDisplayed()
        {
            Thread.Sleep(2000);
            SetMethods.ScrollUpWebPage(_driver);
            Thread.Sleep(1000);
            bool isUserListDisplayed = _advancePage.UserListLabel.GetElementVisibility();
            isUserListDisplayed.Should().BeTrue("User List page should be displayed.");
        }
        
        [Then(@"newly added regular user is displayed")]
        public void ThenNewlyAddedRegularUserIsDisplayed()
        {
            bool isRegularUserDisplayed = false;
            IList<IWebElement> list = _advancePage.UserList;
            list.Count.Should().BeGreaterThan(0, "No user is present except logged User.");

            for (int i = 0; i < list.Count; i++)
            {
                string ActualEmail = list[i].FindElement(By.Id("email" + i)).Text;
                string ActualRole = list[i].FindElement(By.Id("role" + i)).Text;
                if (ActualEmail == randomUsername && ActualRole == AdvancePageExpectedValues.UserRoleRegularOnUserListPage)
                {
                    isRegularUserDisplayed = true;
                    break;
                }
            }
            isRegularUserDisplayed.Should().BeTrue("Newly added regular user should be displayed on User List page.");
        }
    }
}
