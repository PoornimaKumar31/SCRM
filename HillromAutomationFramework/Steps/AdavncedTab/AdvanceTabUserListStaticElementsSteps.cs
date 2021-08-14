using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.PageObjects.AdvancedTab;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.AdavncedTab
{
    [Binding,Scope(Tag = "TestCaseID_9662")]
    public sealed class AdvanceTabUserListStaticElementsSteps
    {
        readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        AdvancedPage advancePage = new AdvancedPage();
        string[] TableHeaderOnUserListPage = { };

        private readonly ScenarioContext _scenarioContext;

        public AdvanceTabUserListStaticElementsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"manager user is on USER LIST page having user entries > (.*)")]
        public void GivenManagerUserIsOnUSERLISTPageHavingUserEntries(int NoOfMinimumEntries)
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            advancePage.AdvancedTab.JavaSciptClick();
            int TotalUser = advancePage.DetailsButton.Count;
            Assert.Greater(TotalUser, NoOfMinimumEntries, "Manager user is on User Management page is not more than two entries");
        }

        [Then(@"USER LIST label is displayed")]
        public void ThenUSERLISTLabelIsDisplayed()
        {
            Thread.Sleep(2000);
            bool IsUserListLabelTextDisplayed = advancePage.UserListPage.GetElementVisibility();
            Assert.IsTrue(IsUserListLabelTextDisplayed, "User list page is not displayed");
        }

        [Then(@"CREATE button is displayed")]
        public void ThenCREATEButtonIsDisplayed()
        {
            bool IsCreateButtonDisplayed = advancePage.CreateUserOnCreatePage.GetElementVisibility();
            Assert.IsTrue(IsCreateButtonDisplayed, "CREATE button is not displayed.");
        }

        [Then(@"CREATE button is enabled")]
        public void ThenCREATEButtonIsEnabled()
        {
            bool IsCreateButtonEnabled = advancePage.CreateUserOnCreatePage.Enabled;
            Assert.IsTrue(IsCreateButtonEnabled, "CREATE button is not enabled.");
        }

        [Then(@"Full name Column(.*) is displayed")]
        public void ThenFullNameColumnIsDisplayed(int p0)
        {
            bool IsFullNameColumn1Displayed = advancePage.FullnameLabelOnUserList.GetElementVisibility();
            TableHeaderOnUserListPage = advancePage.UserListTableHeader.Text.Split();
            if (TableHeaderOnUserListPage[0] != "Full name")
            {
                Assert.IsTrue(IsFullNameColumn1Displayed, "Full name Column1 is not displayed.");
            }
        }

        [Then(@"Role Column(.*) is displayed")]
        public void ThenRoleColumnIsDisplayed(int p0)
        {
            bool IsRoleColumn2Displayed = advancePage.RoleLabelOnUserList.GetElementVisibility();
            if (TableHeaderOnUserListPage[1] != "Role")
            {
                Assert.IsTrue(IsRoleColumn2Displayed, "Role Column2 is not displayed");
            }
        }

        [Then(@"Email Column(.*) is displayed")]
        public void ThenEmailColumnIsDisplayed(int p0)
        {
            bool IsEmailColumn3Displayed = advancePage.EmailLabelOnUserList.GetElementVisibility();
            if (TableHeaderOnUserListPage[2] != "Email")
            {
                Assert.IsTrue(IsEmailColumn3Displayed, "Email Column3 is not displayed");
            }
        }

        [Then(@"User List Table is sorted by Email")]
        public void ThenUserListTableIsSortedByEmail()
        {
            bool IsEmailAscending = advancePage.IsEmailSorted();
            Assert.IsTrue(IsEmailAscending, "User List Table is not sorted by Email");
        }

        [Then(@"Details Button is displayed and enabled for all User rows")]
        public void ThenDetailsButtonIsDisplayedAndEnabledForAllUserRows()
        {
            int NoOfDetailsButton = advancePage.DetailsButton.Count;
            for (int i = 0; i < NoOfDetailsButton; i++)
            {
                bool IsDetailsButtonForAllIsEnabled = advancePage.DetailsButton[i].GetElementVisibility();
                Assert.IsTrue(IsDetailsButtonForAllIsEnabled, "Details Button is not displayed and not enabled for all User rows");
            }
        }

        [Then(@"Delete Button is displayed and enabled for other than logged in user for all rows")]
        public void ThenDeleteButtonIsDisplayedAndEnabledForOtherThanLoggedInUserForAllRows()
        {
            int count = advancePage.DeleteButtonIsDisplayedAndEnabledForOtherThanLoggedInUserForAllRows();
            Assert.AreEqual(0, count, "Delete Button is not displayed and enabled for other than logged in user for all rows");
        }

    }
}
