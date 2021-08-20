﻿using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.PageObjects.AdvancedTab;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.AdvancedTab
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5722")]
    class Req5722Steps
    {
        public string email, fullname;
        public int FirstElementIndex = 0;
        public IWebElement selectedRow;
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        AdvancedTabUserListPage advancedTabUserListPage = new AdvancedTabUserListPage();

        private ScenarioContext _scenarioContext;
        public Req5722Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"manager user is on User List page having more than (.*) records")]
        public void GivenManagerUserIsOnUserListPageHavingMoreThanRecords(int numberOfUser)
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.AdvancedTab.JavaSciptClick();
            Assert.Greater(advancedTabUserListPage.UserList.Count, numberOfUser,"User List Page does not have more than 2 records");
           
        }

        [When(@"user clicks Delete button for user")]
        public void WhenUserClicksDeleteButtonForUser()
        {
            selectedRow = advancedTabUserListPage.UserListExceptLoggedInUser()[FirstElementIndex];
            string selectedRowID = selectedRow.GetAttribute("id");
            char rowNum = selectedRowID[selectedRowID.Length - 1];
            email = selectedRow.FindElement(By.Id("email" + rowNum)).Text;
            fullname = selectedRow.FindElement(By.Id("full_name" + rowNum)).Text;
            selectedRow.FindElement(By.Id(AdvancedTabUserListPage.Locator.DeleteButonID)).Click();
        }

        [Then(@"Delete User pop-up dialog is displayed")]
        public void ThenDeleteUserPop_UpDialogIsDisplayed()
        {
            Assert.IsTrue(advancedTabUserListPage.DeletePopup.GetElementVisibility(),"Delete Popup is not displayed");
        }

        [Then(@"user full name and email address are displayed")]
        public void ThenUserFullNameAndEmailAddressAreDisplayed()
        {
            string ExpectedText = fullname + " (" + email+")";
            Assert.AreEqual(ExpectedText, advancedTabUserListPage.DeletePopupUserNameEmailID.Text, "Fullname and email is not as expected");
        }

        [Then(@"""(.*)"" message is displayed")]
        public void ThenMessageIsDisplayed(string ExpectedText)
        {
            Assert.IsTrue(advancedTabUserListPage.DeletePopupConfirmationMessage.GetElementVisibility(), "Confirmation message is not displayed");
        }


        [Then(@"Yes button is displayed")]
        public void ThenYesButtonIsDisplayed()
        {
            Assert.IsTrue(advancedTabUserListPage.DeletePopupYesButton.GetElementVisibility(),"Yes button is not displayed");
        }

        [Then(@"No button is displayed")]
        public void ThenNoButtonIsDisplayed()
        {
            Assert.IsTrue(advancedTabUserListPage.DeletePopupNoButton.GetElementVisibility(), "No button is not displayed");
        }


        [Given(@"user clicks Delete button for user")]
        public void GivenUserClicksDeleteButtonForUser()
        {
            selectedRow = advancedTabUserListPage.UserListExceptLoggedInUser()[FirstElementIndex];
            string selectedRowID = selectedRow.GetAttribute("id");
            char rowNum = selectedRowID[selectedRowID.Length - 1];
            email = selectedRow.FindElement(By.Id("email" + rowNum)).Text;
            fullname = selectedRow.FindElement(By.Id("full_name" + rowNum)).Text;
            selectedRow.FindElement(By.Id(AdvancedTabUserListPage.Locator.DeleteButonID)).Click();
        }

        [Given(@"Delete User pop-up dialog is displayed")]
        public void GivenDeleteUserPop_UpDialogIsDisplayed()
        {
            Assert.IsTrue(advancedTabUserListPage.DeletePopup.GetElementVisibility(), "Delete Popup is not displayed");
        }

        [When(@"user clicks No button")]
        public void WhenUserClicksNoButton()
        {
            advancedTabUserListPage.DeletePopupNoButton.Click();
        }

        [Then(@"Delete User pop-up dialog closes")]
        public void ThenDeleteUserPop_UpDialogCloses()
        {
            Assert.IsFalse(advancedTabUserListPage.DeletePopup.GetElementVisibility(), "Delete Popup is displayed");
        }

        [Then(@"User List page is displayed")]
        public void ThenUserListPageIsDisplayed()
        {
            Assert.IsTrue(advancedTabUserListPage.UserListLabel.GetElementVisibility(), "User is not on the user list page");
        }

        [Then(@"user is not deleted")]
        public void ThenUserIsNotDeleted()
        {
            Assert.IsTrue(selectedRow.GetElementVisibility(),"Could not find the user");
        }

        [When(@"user clicks Yes button")]
        public void WhenUserClicksYesButton()
        {
            advancedTabUserListPage.DeletePopupYesButton.Click();
        }

        [Then(@"user is deleted")]
        public void ThenUserIsDeleted()
        {
            Assert.IsFalse(selectedRow.GetElementVisibility(), "Could not find the user");
        }

    }
}