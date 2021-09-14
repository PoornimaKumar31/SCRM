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
    [Binding,Scope(Tag = "TestCaseID_9662")]
    public sealed class AdvanceTabUserListStaticElementsSteps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly AdvancedPage _advancePage;
        private readonly WebDriverWait _wait;

        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public AdvanceTabUserListStaticElementsSteps(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _advancePage = new AdvancedPage(driver);
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }


        [Given(@"manager user is on User List page having user entries > (.*)")]
        public void GivenManagerUserIsOnUserListPageHavingUserEntries(int NoOfMinimumEntries)
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _advancePage.AdvancedTab.JavaSciptClick(_driver);
            int TotalUser = _advancePage.DetailsButtonList.Count;
            TotalUser.Should().BeGreaterThan(NoOfMinimumEntries, because:" User list page should have greater than 2 enteries.");
        }

        [Then(@"User List label is displayed")]
        public void ThenUSERLISTLabelIsDisplayed()
        {
            Thread.Sleep(2000);
            bool IsUserListLabelTextDisplayed = _advancePage.UserListLabel.GetElementVisibility();
            IsUserListLabelTextDisplayed.Should().BeTrue(because:" User list page should be displayed.");
        }

        [Then(@"Create button is displayed")]
        public void ThenCREATEButtonIsDisplayed()
        {
            bool IsCreateButtonDisplayed = _advancePage.CreateUserOnCreatePage.GetElementVisibility();
            IsCreateButtonDisplayed.Should().BeTrue(because: " CREATE button should be displayed.");
        }

        [Then(@"Create button is enabled")]
        public void ThenCREATEButtonIsEnabled()
        {
            bool IsCreateButtonEnabled = _advancePage.CreateUserOnCreatePage.Enabled;
            IsCreateButtonEnabled.Should().BeTrue(because: " CREATE button should be enabled.");
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string HeadingParameter)
        {
            switch (HeadingParameter.ToLower().Trim())
            {
                case "full name":
                    _advancePage.FullnameLabelOnUserList.GetElementVisibility().Should().BeTrue(because: " Full name column header should be displayed.");
                    break;
                case "role":
                    _advancePage.RoleColumnHeader.GetElementVisibility().Should().BeTrue(because: " Role column header should be displayed.");
                    break;
                case "email":
                    _advancePage.EmailColumnHeader.GetElementVisibility().Should().BeTrue(because: " Email column header should be displayed.");
                    break;
                default:
                    HeadingParameter.Should().NotMatch(" does not match with any header name. So it is an invalid label name.");
                    break;
            }
        }

        [Then(@"User List Table is sorted by Email in Ascending order")]
        public void ThenUserListTableIsSortedByEmailAscendingOrder()
        {
            bool IsEmailSortedOrder = _advancePage.FindEmailSortingOrder(_driver);
            IsEmailSortedOrder.Should().BeTrue(because: " User List Table should be sorted by Email in Ascending order.");
        }

        [Then(@"Details button is displayed and enabled for all User rows")]
        public void ThenDetailsButtonIsDisplayedAndEnabledForAllUserRows()
        {
            bool IsDisplayed = false;
            bool IsEnabled = false;
            int count = 0;
            IList<IWebElement> list = _advancePage.UserList;
            for (int i = 0; i < list.Count; i++)
            {
                IsDisplayed = _advancePage.DetailsButtonList[i].GetElementVisibility();
                IsEnabled = _advancePage.DetailsButtonList[i].Enabled;
                if (IsDisplayed && IsEnabled == true)
                {
                    count++;
                }
            }
            bool isSame = count == list.Count;
            isSame.Should().BeTrue(because: " Details Button should be displayed and enabled for other than logged in user for all rows.");
        }

        [Then(@"Delete button is displayed and enabled for all rows other than logged in user")]
        public void ThenDeleteButtonIsDisplayedAndEnabledForOtherThanLoggedInUserForAllRows()
        {
            bool IsDisplayed = false;
            bool IsEnabled = false;
            int count = 0;
            IList<IWebElement> list = _advancePage.UserListExceptLoggedInUser();
            for (int i = 0; i < list.Count; i++)
            {
                IsDisplayed = _advancePage.DeleteButtonsList[i].GetElementVisibility();
                IsEnabled = _advancePage.DeleteButtonsList[i].Enabled;
                if (IsDisplayed && IsEnabled == true)
                {
                    count++;
                }
            }
            bool isSame = count == list.Count;
            isSame.Should().BeTrue(because: " Delete Button should be displayed and enabled for other than logged in user for all rows.");
        }
    }
}
