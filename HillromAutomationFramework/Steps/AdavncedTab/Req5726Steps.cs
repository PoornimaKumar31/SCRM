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
        LoginPage _loginPage;
        LandingPage _landingPage;
        AdvancedPage _advancePage;
        readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

        string randomUsername = null;
        string randomFullName = null;
        string role = null;

        public Req5726Steps()
        {
            _loginPage = new LoginPage();
            _landingPage = new LandingPage();
            _advancePage = new AdvancedPage();
        }

        [Given(@"Manager user is on Add User page")]
        public void GivenManagerUserIsOnAddUserPage()
        {
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            //Clicking on facility
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _advancePage.AdvancedTab.JavaSciptClick();

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
                _advancePage.UserManagerOnCreatePage.JavaSciptClick();
            }
        }
        
        [When(@"clicks Save button")]
        public void WhenClicksSaveButton()
        {
            _advancePage.SaveButtonOnCreatePage.ClickWebElement("Save Button");
        }
        
        [Then(@"User List page is displayed")]
        public void ThenUserListPageIsDisplayed()
        {
            Thread.Sleep(2000);
            SetMethods.ScrollUpWebPage();
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
                if (ActualEmail == randomUsername && ActualRole == AdvancedPage.ExpectedValues.UserRoleRegularOnUserListPage)
                {
                    isRegularUserDisplayed = true;
                    break;
                }
            }
            isRegularUserDisplayed.Should().BeTrue("Newly added regular user should be displayed on User List page.");
        }
    }
}
