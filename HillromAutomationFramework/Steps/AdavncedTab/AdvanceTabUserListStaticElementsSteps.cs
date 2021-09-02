﻿using HillromAutomationFramework.PageObjects;
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
        readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        AdvancedPage advancePage = new AdvancedPage();

        [Given(@"manager user is on User List page having user entries > (.*)")]
        public void GivenManagerUserIsOnUserListPageHavingUserEntries(int NoOfMinimumEntries)
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            advancePage.AdvancedTab.JavaSciptClick();
            int TotalUser = advancePage.DetailsButtonList.Count;
            Assert.Greater(TotalUser, NoOfMinimumEntries, "Manager user is on User Management page is not more than two entries");
        }

        [Then(@"User List label is displayed")]
        public void ThenUSERLISTLabelIsDisplayed()
        {
            Thread.Sleep(2000);
            bool IsUserListLabelTextDisplayed = advancePage.UserListLabel.GetElementVisibility();
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
            switch (HeadingParameter.ToLower().Trim())
            {
                case "full name":
                    Assert.IsTrue(advancePage.FullnameLabelOnUserList.GetElementVisibility(), "Full name column header is not displayed.");
                    break;
                case "role":
                    Assert.IsTrue(advancePage.RoleColumnHeader.GetElementVisibility(), "Role column header is not displayed.");
                    break;
                case "email":
                    Assert.IsTrue(advancePage.EmailColumnHeader.GetElementVisibility(), "Email column header is not displayed.");
                    break;
                default:
                    Assert.Fail(HeadingParameter + " is an invalid label name.");
                    break;
            }
        }

        [Then(@"User List Table is sorted by Email in Ascending order")]
        public void ThenUserListTableIsSortedByEmailAscendingOrder()
        {
            bool IsEmailSortedOrder = advancePage.FindEmailSortingOrder();
            Assert.IsTrue(IsEmailSortedOrder, "User List Table is not sorted by Email in Ascending order");
        }

        [Then(@"Details button is displayed and enabled for all User rows")]
        public void ThenDetailsButtonIsDisplayedAndEnabledForAllUserRows()
        {
            bool IsDisplayed = false;
            bool IsEnabled = false;
            int count = 0;
            IList<IWebElement> list = advancePage.UserList;
            for (int i = 0; i < list.Count; i++)
            {
                IsDisplayed = advancePage.DetailsButtonList[i].GetElementVisibility();
                IsEnabled = advancePage.DetailsButtonList[i].Enabled;
                if (IsDisplayed && IsEnabled == true)
                {
                    count++;
                }
            }
            Assert.AreEqual(true, count == list.Count, "Details Button is not displayed and enabled for other than logged in user for all rows");
        }

        [Then(@"Delete button is displayed and enabled for all rows other than logged in user")]
        public void ThenDeleteButtonIsDisplayedAndEnabledForOtherThanLoggedInUserForAllRows()
        {
            bool IsDisplayed = false;
            bool IsEnabled = false;
            int count = 0;
            IList<IWebElement> list = advancePage.UserListExceptLoggedInUser();
            for (int i = 0; i < list.Count; i++)
            {
                IsDisplayed = advancePage.DeleteButtonsList[i].GetElementVisibility();
                IsEnabled = advancePage.DeleteButtonsList[i].Enabled;
                if (IsDisplayed && IsEnabled == true)
                {
                    count++;
                }
            }
            Assert.AreEqual(true, count == list.Count, "Delete Button is not displayed and enabled for other than logged in user for all rows");
        }
    }
}
