using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.PageObjects.AdvancedTab;
using HillromAutomationFramework.Coding.SupportingCode;
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
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        AdvancedPage advancePage = new AdvancedPage();
        readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        string RandomUsername = null;
        string RandomFullName = null;
        string Role = null;


        [Given(@"Manager user is on Add User page")]
        public void GivenManagerUserIsOnAddUserPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            //Clicking on facility
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            advancePage.AdvancedTab.JavaSciptClick();

            //User is on add user page
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
            RandomFullName = GetMethods.GenerateRandomString(15);
            advancePage.FullNameOnCreatePage.EnterText(RandomFullName);
        }
        
        [When(@"unchecks User Manager checkbox")]
        public void WhenUnchecksUserManagerCheckbox()
        {
            bool IsCheckboxSelected = advancePage.UserManagerOnCreatePage.Selected;

            if (IsCheckboxSelected == true)
            {
                advancePage.UserManagerOnCreatePage.JavaSciptClick();
            }
        }
        
        [When(@"clicks Save button")]
        public void WhenClicksSaveButton()
        {
            SetMethods.ScrollToBottomofWebpage();
            Thread.Sleep(1000);
            advancePage.SaveButtonOnCreatePage.Click();
        }
        
        [Then(@"User List page is displayed")]
        public void ThenUserListPageIsDisplayed()
        {
            Thread.Sleep(2000);
            SetMethods.ScrollUpWebPage();
            Thread.Sleep(1000);
            bool IsUserListDisplayed = advancePage.UserListPage.GetElementVisibility();
            Assert.IsTrue(IsUserListDisplayed, "User list page is not displayed");
        }
        
        [Then(@"newly added regular user is displayed")]
        public void ThenNewlyAddedRegularUserIsDisplayed()
        {
            bool IsRegularUserDisplayed = false;
            IList<IWebElement> list = advancePage.UserList;
            Assert.Greater(list.Count, 0, "No user is present except logged User.");

            for (int i = 0; i < list.Count; i++)
            {
                string ActualEmail = list[i].FindElement(By.Id("email" + i)).Text;
                string ActualRole = list[i].FindElement(By.Id("role" + i)).Text;
                if (ActualEmail == RandomUsername && ActualRole == AdvancedPage.ExpectedValues.UserRoleRegularOnUserListPage)
                {
                    IsRegularUserDisplayed = true;
                    break;
                }
            }
            Assert.IsTrue(IsRegularUserDisplayed, "Newy added regular user is not displayed");
        }
    }
}
