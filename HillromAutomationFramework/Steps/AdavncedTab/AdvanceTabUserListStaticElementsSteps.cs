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
        int HeaderCount;



        //Updated
        [Given(@"manager user is on User List page having user entries > (.*)")]
        public void GivenManagerUserIsOnUserListPageHavingUserEntries(int NoOfMinimumEntries)
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            advancePage.AdvancedTab.JavaSciptClick();
            int TotalUser = advancePage.DetailsButton.Count;
            Assert.Greater(TotalUser, NoOfMinimumEntries, "Manager user is on User Management page is not more than two entries");
        }







        [Then(@"User List label is displayed")]
        public void ThenUSERLISTLabelIsDisplayed()
        {
            Thread.Sleep(2000);
            bool IsUserListLabelTextDisplayed = advancePage.UserListPage.GetElementVisibility();
            Assert.IsTrue(IsUserListLabelTextDisplayed, "User list page is not displayed");
        }

        [Then(@"Create button is displayed")]
        public void ThenCREATEButtonIsDisplayed()
        {
            bool IsCreateButtonDisplayed = advancePage.CreateUserOnCreatePage.GetElementVisibility();
            Assert.IsTrue(IsCreateButtonDisplayed, "CREATE button is not displayed.");
        }

        [Then(@"Create button is enabled")]
        public void ThenCREATEButtonIsEnabled()
        {
            bool IsCreateButtonEnabled = advancePage.CreateUserOnCreatePage.Enabled;
            Assert.IsTrue(IsCreateButtonEnabled, "CREATE button is not enabled.");
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string HeadingParameter)
        {
            bool IsHeaderDisplayed = advancePage.FullnameLabelOnUserList.GetElementVisibility();
            TableHeaderOnUserListPage = advancePage.UserListTableHeader.Text.Split();
            if (TableHeaderOnUserListPage[HeaderCount] != HeadingParameter)
            {
                if (HeadingParameter== "Full name")
                {
                    Assert.IsTrue(IsHeaderDisplayed, "Full name is not displayed.");                   
                }
                if (HeadingParameter == "Role")
                {
                    Assert.IsTrue(IsHeaderDisplayed, "Role is not displayed.");
                }
                if (HeadingParameter == "Email")
                {
                    Assert.IsTrue(IsHeaderDisplayed, "Email is not displayed.");
                }               
            }
            HeaderCount++;
        }

        [Then(@"User List Table is sorted by Email")]
        public void ThenUserListTableIsSortedByEmail()
        {
            bool IsEmailAscending = advancePage.IsEmailSorted();
            Assert.IsTrue(IsEmailAscending, "User List Table is not sorted by Email");
        }

        [Then(@"Details button is displayed and enabled for all User rows")]
        public void ThenDetailsButtonIsDisplayedAndEnabledForAllUserRows()
        {
            int NoOfDetailsButton = advancePage.DetailsButton.Count;
            for (int i = 0; i < NoOfDetailsButton; i++)
            {
                bool IsDetailsButtonForAllIsEnabled = advancePage.DetailsButton[i].GetElementVisibility();
                Assert.IsTrue(IsDetailsButtonForAllIsEnabled, "Details Button is not displayed and not enabled for all User rows");
            }
        }

        [Then(@"Delete button is displayed and enabled for all rows other than logged in user")]
        public void ThenDeleteButtonIsDisplayedAndEnabledForOtherThanLoggedInUserForAllRows()
        {
            int count = advancePage.DeleteButtonIsDisplayedAndEnabledForOtherThanLoggedInUserForAllRows();
            Assert.AreEqual(0, count, "Delete Button is not displayed and enabled for other than logged in user for all rows");
        }
    }
}
