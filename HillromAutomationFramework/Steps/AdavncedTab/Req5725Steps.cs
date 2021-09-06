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
        string RandomUsername = "";
        string FullnameRandom = "";

        readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

        public Req5725Steps()
        {
            _loginPage = new LoginPage();
            _landingPage = new LandingPage();
            _advancePage = new AdvancedPage();
        }

        [Given(@"Manager user is on Add User page")]
        public void GivenManagerUserIsOnAddUserPage()
        {
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _advancePage.AdvancedTab.JavaSciptClick();
            Thread.Sleep(2000);
            _advancePage.CreateUserOnCreatePage.Click();
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
            _advancePage.UserManagerOnCreatePage.JavaSciptClick();
        }

        [When(@"clicks Save button")]
        public void WhenClicksSaveButton()
        {
            SetMethods.ScrollToBottomofWebpage();
            Thread.Sleep(2000);
            _advancePage.SaveButtonOnCreatePage.Click();
        }

        [Then(@"User List page is displayed")]
        public void ThenUserListPageIsDisplayed()
        {
            Thread.Sleep(2000);
            SetMethods.ScrollUpWebPage();
            Thread.Sleep(4000);
            string actualUserListLabelText = _advancePage.UserListLabel.Text;
            string expectedUserListLabelText = AdvancedPage.ExpectedValues.UserListPageLabelText;
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
                if (ActualEmail == RandomUsername && ActualRole == AdvancedPage.ExpectedValues.UserRoleAdministratorOnUserListPage)
                {
                    isUserManagerDisplayed = true;
                    break;
                }
            }
            isUserManagerDisplayed.Should().BeTrue("Newly added manager user should be displayed on User List page.");
        }
    }
}
