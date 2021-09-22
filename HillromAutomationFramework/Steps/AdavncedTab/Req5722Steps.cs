using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AdvancedTab;
using HillromAutomationFramework.SupportingCode;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.AdvancedTab
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5722")]
    class Req5722Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;
        private readonly AdvancedPage _advancedPage;
        private readonly WebDriverWait _wait;

        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public string email, fullname;
        public int firstElementIndex = 0;
        public IWebElement selectedRow;

        public Req5722Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
            _advancedPage = new AdvancedPage(driver);
        }

        [Given(@"manager user is on User List page having more than (.*) records")]
        public void GivenManagerUserIsOnUserListPageHavingMoreThanRecords(int numberOfUser)
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.AdvancedTab.JavaSciptClick(_driver);
            _advancedPage.UserList.Count.Should().BeGreaterThan(numberOfUser, "User List Page does not have more than 2 records.");
        }

        [When(@"user clicks Delete button for user")]
        public void WhenUserClicksDeleteButtonForUser()
        {
            selectedRow = _advancedPage.UserListExceptLoggedInUser()[firstElementIndex];
            string selectedRowID = selectedRow.GetAttribute("id");
            char rowNum = selectedRowID[selectedRowID.Length - 1];
            email = selectedRow.FindElement(By.Id("email" + rowNum)).Text;
            fullname = selectedRow.FindElement(By.Id("full_name" + rowNum)).Text;
            selectedRow.FindElement(By.Id(AdvancedPage.Locators.DeleteButtonID)).Click();
        }

        [Then(@"Delete User pop-up dialog is displayed")]
        public void ThenDeleteUserPop_UpDialogIsDisplayed()
        {
            bool isDeleteUserPopupDisplayed = _advancedPage.DeletePopup.GetElementVisibility();
            isDeleteUserPopupDisplayed.Should().BeTrue("Delete User pop-up dialog should be displayed.");
        }

        [Then(@"user full name and email address are displayed")]
        public void ThenUserFullNameAndEmailAddressAreDisplayed()
        {
            string expectedText = fullname + " (" + email+")";
            string actualText = _advancedPage.DeletePopupUserNameEmailID.Text;
            actualText.Should().BeEquivalentTo(expectedText,because:"User full name and email address should be displayed on User List page.");
        }

        [Then(@"""(.*)"" message is displayed")]
        public void ThenMessageIsDisplayed(string ExpectedText)
        {
            bool isConfirmationMessageDisplayed = _advancedPage.DeletePopupConfirmationMessage.GetElementVisibility();
            isConfirmationMessageDisplayed.Should().BeTrue("Are you sure you want to delete this user? message should be displayed on DELETE USER popup");
            string ConfirmationMessage = _advancedPage.DeletePopupConfirmationMessage.Text;
            (ConfirmationMessage).Should().BeEquivalentTo(ExpectedText, because: "Are you sure message should match with the expected value.");
        }

        [Then(@"Yes button is displayed")]
        public void ThenYesButtonIsDisplayed()
        {
            bool isYesButtonDisplayed = _advancedPage.DeletePopupYesButton.GetElementVisibility();
            isYesButtonDisplayed.Should().BeTrue("Yes button should be displayed on DELETE USER popup.");
        }

        [Then(@"No button is displayed")]
        public void ThenNoButtonIsDisplayed()
        {
            bool isNoButtonDisplayed = _advancedPage.DeletePopupNoButton.GetElementVisibility();
            isNoButtonDisplayed.Should().BeTrue("No button should be displayed on DELETE USER popup.");
        }

        [Given(@"user clicks Delete button for user")]
        public void GivenUserClicksDeleteButtonForUser()
        {
            selectedRow = _advancedPage.UserListExceptLoggedInUser()[firstElementIndex];
            string selectedRowID = selectedRow.GetAttribute("id");
            char rowNum = selectedRowID[selectedRowID.Length - 1];
            email = selectedRow.FindElement(By.Id("email" + rowNum)).Text;
            fullname = selectedRow.FindElement(By.Id("full_name" + rowNum)).Text;
            selectedRow.FindElement(By.Id(AdvancedPage.Locators.DeleteButtonID)).Click();
        }

        [Given(@"Delete User pop-up dialog is displayed")]
        public void GivenDeleteUserPop_UpDialogIsDisplayed()
        {
            bool isDeleteUserPopupDisplayed = _advancedPage.DeletePopup.GetElementVisibility();
            isDeleteUserPopupDisplayed.Should().BeTrue("Delete User pop-up dialog should be displayed.");
        }

        [When(@"user clicks No button")]
        public void WhenUserClicksNoButton()
        {
            _advancedPage.DeletePopupNoButton.Click();
        }

        [Then(@"Delete User pop-up dialog closes")]
        public void ThenDeleteUserPop_UpDialogCloses()
        {
            bool isDeleteUserPopupDisplayed = _advancedPage.DeletePopup.GetElementVisibility();
            isDeleteUserPopupDisplayed.Should().BeFalse("Delete User pop-up dialog should be closed.");
        }

        [Then(@"User List page is displayed")]
        public void ThenUserListPageIsDisplayed()
        {
            bool isUserListPageDisplayed = _advancedPage.UserListLabel.GetElementVisibility();
            isUserListPageDisplayed.Should().BeTrue("User List page should be displayed");
        }

        [Then(@"user is not deleted")]
        public void ThenUserIsNotDeleted()
        {
            bool isUserNotDeleted = selectedRow.GetElementVisibility();
            isUserNotDeleted.Should().BeTrue("User should not be deleted from User List page.");
        }

        [When(@"user clicks Yes button")]
        public void WhenUserClicksYesButton()
        {
            _advancedPage.DeletePopupYesButton.Click();
        }

        [Then(@"user is deleted")]
        public void ThenUserIsDeleted()
        {
            bool isUserDeleted = selectedRow.GetElementVisibility();
            isUserDeleted.Should().BeFalse("User should be deleted from User List page.");
        }
    }
}
