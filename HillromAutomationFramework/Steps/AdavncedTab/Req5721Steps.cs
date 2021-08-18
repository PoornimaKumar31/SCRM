using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.PageObjects.AdvancedTab;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.AdavncedTab
{
    [Binding, Scope(Tag = "SoftwareRequirementID_5721")]
    public class Req5721Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        AdvancedPage advancePage = new AdvancedPage();
        string RandomFullNameLessThan50_49char = "";
        string UserNameGreaterThan50_51char = "";
        string RandomPhoneNumber10_10Digits = "";
        string ActualFullName = "";
        string BlankFullName = "";
        int TenDigitRandomMobileNumber = 1000000000;
        int DetailsButtonCount;

        string UpdatedFullName = "";
        string UpdatedPhoneNumber = "";
        string RoleXpath = "";
        bool IsCheckBoxSelected;
        readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));


        private readonly ScenarioContext _scenarioContext;

        public Req5721Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"manager user is on User Management page having user entries list > (.*)")]
        public void GivenManagerUserIsOnUserManagementPageHavingUserEntriesList(int NoOfMinimumEntries)
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            advancePage.AdvancedTab.JavaSciptClick();
            int TotalUser = advancePage.DetailsButton.Count;
            Assert.Greater(TotalUser, NoOfMinimumEntries, "Manager user is on User Management page is not more than two entries");
        }

        [When(@"user clicks Details button for other User record")]
        public void WhenUserClicksDetailsButtonForOtherUserRecord()
        {
            DetailsButtonCount = advancePage.UserClicksDetailsButtonForOtherUserRecord();
        }

        [Then(@"Edit Users page is displayed")]
        public void ThenEDITUSERSPageIsDisplayed()
        {
            bool IsEditUsersPageDisplayed = advancePage.EditUserLabel.GetElementVisibility();
            Assert.IsTrue(IsEditUsersPageDisplayed, "EDIT USERS page is not displayed");
        }

        [Then(@"User information label is displayed")]
        public void ThenUserInformationLabelIsDisplayed()
        {
            bool IsUserManagementVisible = advancePage.UserManagement.GetElementVisibility();
            Assert.IsTrue(IsUserManagementVisible, "User Information label is not displayed");
        }

        [Then(@"Username textbox is displayed")]
        public void ThenUsernameEmailaddressFieldIsDisplayed()
        {
            bool IsUsernameVisible = advancePage.UserNameOREmailField.GetElementVisibility();
            Assert.IsTrue(IsUsernameVisible, "Username field is not displayed");
        }

        [Then(@"checkbox with label User manager is displayed")]
        public void ThenCheckboxIsDisplayedWithLabelUserManager()
        {
            bool IsCheckboxVisible = advancePage.UserManagerCheckBox.GetElementVisibility();
            bool IsUserManagerLabelVisible = advancePage.UserManagerLabel.GetElementVisibility();
            Assert.IsTrue(IsCheckboxVisible, "Checkbox is not displayed with label User Manager.");
            Assert.IsTrue(IsUserManagerLabelVisible, "User Manager label is not displayed.");
        }

        [Then(@"Log history label is displayed")]
        public void ThenLogHistoryLabelIsDisplayed()
        {
            bool IsHistoryLabelDisplayed = advancePage.LogHistory.GetElementVisibility();
            Assert.IsTrue(IsHistoryLabelDisplayed, "Log History label is not displayed");
        }

        [Then(@"Date column heading is displayed")]
        public void ThenDateColumnHeadingIsDisplayed()
        {
            bool IsDateLabelDisplayed = advancePage.DateColumnHeader.GetElementVisibility();
            Assert.IsTrue(IsDateLabelDisplayed, "Log History label is not displayed");
        }

        [Then(@"Details column heading is displayed")]
        public void ThenDetailsColumnHeadingIsDisplayed()
        {
            bool IsDetailsLabelDisplayed = advancePage.DetailsColumnHeader.GetElementVisibility();
            Assert.IsTrue(IsDetailsLabelDisplayed, "Log History label is not displayed");
        }

        [Then(@"Save and Cancel buttons are displayed")]
        public void ThenSaveAndCancelButtonsIsDisplayed()
        {
            Thread.Sleep(2000);
            bool IsSaveButtonDisplayed = advancePage.SaveButton.GetElementVisibility();
            Assert.IsTrue(IsSaveButtonDisplayed, "Save button is not displayed");
            bool IsCancelButtonVisible = advancePage.CancelButton.GetElementVisibility();
            Assert.IsTrue(IsCancelButtonVisible, "Cancel button is not displayed");
        }

        [Given(@"manager user is on Edit User page")]
        public void GivenManagerUserIsOnEDITUSERPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            advancePage.AdvancedTab.JavaSciptClick();
            DetailsButtonCount = advancePage.UserClicksDetailsButtonForOtherUserRecord();
        }

        [When(@"user enters full name with more than fifty characters")]
        public void WhenUserEntersFullNameWithMoreThanCharacters()
        {
            
        }

        [When(@"user enters Full name with ""(.*)"" characters")]
        public void WhenUserEntersFullNameWithCharacters(string FullNameCharacterSize)
        {
            if (true)
            {

            }
            int FullNameSize = int.Parse(FullNameCharacterSize);
            advancePage.FullName.Clear();
            UserNameGreaterThan50_51char = GetMethods.GenerateRandomString(FullNameSize);
            advancePage.FullName.EnterText(UserNameGreaterThan50_51char);
        }

        [Then(@"full name error message is displayed")]
        public void ThenPleaseEnterAValidNameErrorMessageIsDisplayed()
        {
            Thread.Sleep(2000);
            bool IsErrorMessageDisplayed = advancePage.FullNameErrorMessageOnCreatePage.GetElementVisibility();
            Assert.IsTrue(IsErrorMessageDisplayed, "Please enter a valid name error message is not displayed");
        }

        [Then(@"Save button is disabled")]
        public void ThenSaveButtonIsDisabled()
        {
            bool IsSaveButtonDisabled = advancePage.SaveButton.Enabled;
            Assert.IsFalse(IsSaveButtonDisabled, "Save button is enabled");
        }
        /*
        [When(@"user enters full name with less than or equal to fifty characters")]
        public void WhenUserEntersFullNameWithLessThanOrEqualToCharacters()
        {
            advancePage.FullName.Clear();
            //Generating random string for Full name just by passing string size to the method and entering into the Full name text box. 
            RandomFullNameLessThan50_49char = GetMethods.GenerateRandomString(49);
            advancePage.FullName.EnterText(RandomFullNameLessThan50_49char);
        }
        */
        [Then(@"phone number error message is not displayed")]
        public void ThenPhoneNumberErrorMessageIsNotDisplayed()
        {
           
            bool Visibility = advancePage.PhoneErrorMessage.GetElementVisibility();
            Assert.IsFalse(Visibility, "Element is not displayed");
        }

        [Then(@"Save button is enabled")]
        public void ThenSaveButtonIsEnabled()
        {
            bool IsSaveButtonEnabled = advancePage.SaveButton.Enabled;
            Assert.IsTrue(IsSaveButtonEnabled, "Save button is disabled");
        }

        [When(@"user clicks Save button")]
        public void WhenUserClicksOnSaveButton()
        {
            advancePage.SaveButton.Click();
        }

        [Then(@"updated Full name is displayed on User List")]
        public void ThenUpdatedFullNameIsDisplayedOnTheUserList()
        {
            Thread.Sleep(2000);
            //Searching user created data in the table just by passing Randomly generated Full name in the table content.
            ActualFullName = advancePage.UpdatedFullNameIsDisplayedOnTheUserList(RandomFullNameLessThan50_49char);
            Assert.AreEqual(true, RandomFullNameLessThan50_49char == ActualFullName, "Updated full name is not displayed on the user list");
        }

        [When(@"user enters blank Full name")]
        public void WhenUserEntersBlankFullName()
        {
            advancePage.FullName.EnterText(BlankFullName);
        }

        [When(@"clicks Cancel button")]
        public void WhenUserClicksOnCancelButton()
        {
            advancePage.CancelButton.Click();
        }

        [Then(@"user list page is displayed")]
        public void ThenUserListPageIsDisplays()
        {
            Thread.Sleep(2000);
            bool IsUserListLabelTextDisplayed = advancePage.UserListPage.GetElementVisibility();
            Assert.IsTrue(IsUserListLabelTextDisplayed, "User list page is not displayed");
        }

        [When(@"user enters phone number (.*)")]
        public void WhenUserEntersPhoneNumberStartingWith91FollowedByElevenDigitsMobileNumber(string mobileNumber)
        {
            advancePage.PhoneTextField.Clear();
            advancePage.PhoneTextField.EnterText(mobileNumber);
        }

        [Then(@"phone number error message is displayed")]
        public void ThenPleaseEnterAValidPhoneNumberErrorMessageIsDisplayed()
        {
            Thread.Sleep(2000);
            bool IsPhoneNumberErrorMessage = advancePage.PhoneErrorMessage.GetElementVisibility();
            Assert.IsTrue(IsPhoneNumberErrorMessage, "phone number error message is not displayed");
        }

        [When(@"user enters a plus sign and a random 10-digit Phone number")]
        public void WhenUserEntersPhoneNumberStartingWithFollowedByTenDigitsMobileNumber()
        {
            advancePage.PhoneTextField.Clear();
            //Generating mobile number through method just by passing size of phone number.
            RandomPhoneNumber10_10Digits = GetMethods.GenerateRandomMobileNumber(TenDigitRandomMobileNumber);
            advancePage.PhoneTextField.EnterText(RandomPhoneNumber10_10Digits);
        }

        [When(@"user enters blank Phone number")]
        public void WhenUserEntersBlankPhoneNumber()
        {
            advancePage.PhoneTextField.Clear();
            //advancePage.PhoneTextField.EnterText("");
        }

        [When(@"user enters invalid phone number (.*)")]
        public void WhenUserEntersInvalidPhoneNumber(string InvalidPhoneNumber)
        {
            advancePage.PhoneTextField.Clear();
            advancePage.PhoneTextField.EnterText(InvalidPhoneNumber);
        }

        [When(@"user deselects the User Manager checkbox")]
        public void WhenUserDeselectsTheUserManagerCheckbox()
        {
            Thread.Sleep(2000);
            bool IsSelected = advancePage.UserManagerCheckBox.Selected;
            if (IsSelected == true)
            {
                advancePage.UserManagerCheckBox.JavaSciptClick();
            }
            else
            {
                Assert.IsFalse(IsSelected, "User Manager Check box is already deselected.");
            }
        }

        [When(@"user changes Full name, Phone number and Role")]
        public void WhenUserUpdatesFullNameAndPhoneNumber()
        {
            _scenarioContext.Add("fullname", advancePage.FullName.GetAttribute("value"));
            _scenarioContext.Add("phonenumber", advancePage.PhoneTextField.GetAttribute("value"));
            _scenarioContext.Add("role", advancePage.UserManagerCheckBox.Selected);
            advancePage.UserChangesFullNameNumberAndRole();
        }

        [Then(@"Full name, Phone number, and Role are not changed on User List page")]
        public void ThenUpdatedFullNameIsNotDisplayedOnUSERLISTPage()
        {
            advancePage.DetailsButton[DetailsButtonCount].Click();
            string ActualFullname = advancePage.FullName.GetAttribute("value");
            Assert.AreEqual(_scenarioContext.Get<string>("fullname"), ActualFullname, "Full name is changed");

            string ActualPhoneNumber = advancePage.PhoneTextField.GetAttribute("value");
            Assert.AreEqual(_scenarioContext.Get<string>("phonenumber"), ActualPhoneNumber, "Phone number is changed");

            bool ActualRole = advancePage.UserManagerCheckBox.Selected;
            bool ExpectedRole = _scenarioContext.Get<Boolean>("role");
            Assert.AreEqual(ExpectedRole, ActualRole, "User role is changed");
        }

        [Given(@"manager user is on Edit User page with log entries > (.*)")]
        public void GivenManagerUserIsOnEDITUSERPageWithLogEntries(int LogHistoryCount)
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            advancePage.AdvancedTab.JavaSciptClick();
            Thread.Sleep(2000);
            DetailsButtonCount = advancePage.ManagerUserIsOnEditUserPageWithLogEntriesGreaterThanTwo(DetailsButtonCount);
        }

        [Then(@"Log History table is sorted by descending date sort order")]
        public void ThenLogHistoryTableIsSortedByDescendingDateSortOrder()
        {
            var DateTimeList = advancePage.LogHistoryTableIsSortedByDescendingDateSortOrder();
            Assert.That(DateTimeList, Is.Ordered.Descending, "Data is not in descending order.");
        }

        [When(@"user clicks Details button for user with a phone number")]
        public void WhenUserClicksDetailsButtonForUserWithAPhoneNumber()
        {
            DetailsButtonCount = advancePage.UserClicksDetailsButtonForUserWithAPhoneNumber();
            _scenarioContext.Add("phonenumber", advancePage.PhoneTextField.GetAttribute("value"));
        }

        [Then(@"Phone number is unchanged")]
        public void ThenUserPhoneNumberIsNotChanged()
        {
            string PhoneNumber = advancePage.PhoneTextField.GetAttribute("value");
            Assert.AreEqual(_scenarioContext.Get<string>("phonenumber"), PhoneNumber, "User phone number is changed");
        }

        [Then(@"presses Tab")]
        public void ThenPressesTab()
        {
            advancePage.FullName.EnterText(Keys.Tab);
        }

        [When(@"presses Tab")]
        public void WhenPressesTab()
        {
            advancePage.FullName.EnterText(Keys.Tab);
        }

        [Then(@"user is not edited")]
        public void ThenUserIsNotEdited()
        {
            advancePage.DetailsButton[DetailsButtonCount].Click();
            Thread.Sleep(2000);
            string ActualUserName = advancePage.FullName.GetAttribute("value");
            Assert.AreEqual(true, BlankFullName != ActualUserName, "New user is created");
        }

        [Then(@"Phone number is entered number")]
        public void ThenPhoneNumberIsEnteredNumber()
        {
            Thread.Sleep(2000);
            string EnteredPhoneNumber = advancePage.PhoneTextField.GetAttribute("value");
            Assert.AreEqual(true, RandomPhoneNumber10_10Digits == EnteredPhoneNumber, "Phone number is not entered number");
        }

        [Then(@"full name error message is not displayed")]
        public void ThenFullNameErrorMessageIsNotDisplayed()
        {
            Thread.Sleep(2000);
            bool FullNameErrorMessageisplayed = advancePage.NameFieldErrorMessage.GetElementVisibility();
            Assert.IsFalse(FullNameErrorMessageisplayed, "Full name error message is displayed");
        }

        [When(@"clicks Details button for same user")]
        public void WhenClicksDetailsButtonForSameUser()
        {
            Thread.Sleep(2000);
            advancePage.DetailsButton[DetailsButtonCount].Click();
        }

        [Then(@"Phone number is blank")]
        public void ThenPhoneNumberIsBlank()
        {
            Thread.Sleep(5000);
            string EnteredPhoneNumber = advancePage.PhoneTextField.GetAttribute("value");

            Assert.AreEqual(true, EnteredPhoneNumber == "", "Phone number is not entered number");
        }


        [When(@"user clicks Details button for user with Administrator role")]
        public void WhenUserClicksDetailsButtonForUserWithAdministratorRole()
        {
            Dictionary<string, string> DictionaryElements = advancePage.UserClicksDetailsButtonForUserWithAdministratorRole(DetailsButtonCount, RoleXpath);
            RoleXpath = DictionaryElements.ElementAt(0).Key;
            var DetailsButtonAt = DictionaryElements.ElementAt(0).Value;
            DetailsButtonCount = int.Parse(DetailsButtonAt);
        }

        [Then(@"Regular is displayed in Role column in user list")]
        public void ThenRegularIsDisplayedInRoleColumnInUserList()
        {
            Thread.Sleep(2000);
            string Role = PropertyClass.Driver.FindElement(By.XPath(RoleXpath)).Text;
            Assert.AreEqual(true, Role == AdvancedPage.ExpectedValues.UserRoleRegularOnUserListPage, "Regular is not displayed in Role column in user list");
        }

        [When(@"user selects the User Manager checkbox")]
        public void WhenUserSelectsTheUserManagerCheckbox()
        {
            Thread.Sleep(2000);
            advancePage.UserManagerCheckBox.JavaSciptClick();
        }

        [Then(@"Administrator is displayed in Role column in User List")]
        public void ThenAdministratorIsDisplayedInRoleColumnInUserList()
        {
            Thread.Sleep(2000);
            string Role = PropertyClass.Driver.FindElement(By.XPath(RoleXpath)).Text;
            Assert.AreEqual(true, AdvancedPage.ExpectedValues.UserRoleAdministratorOnUserListPage == Role, "Administrator is not displayed in Role column in User List");
        }

        [Then(@"Username textbox is read only")]
        public void ThenUsernameTextboxIsReadOnly()
        {
            bool IsUsernameReadOnly = advancePage.UserNameOREmailField.IsReadOnly();
            Assert.IsTrue(IsUsernameReadOnly, "Username field is not read only");
        }

        [Then(@"checkbox is unchecked")]
        public void ThenCheckboxIsUnchecked()
        {
            Thread.Sleep(2000);
            advancePage.UserManagerCheckBox.JavaSciptClick();
        }

        [Then(@"Cancel button is enabled")]
        public void ThenCancelButtonEnabled()
        {
            bool IsCancelButtonEnabled = advancePage.CancelButton.Enabled;
            Assert.IsTrue(IsCancelButtonEnabled, "Save button is disabled");
        }

        [Then(@"Full name textbox is displayed")]
        public void ThenFullNameTextboxIsDisplayed()
        {
            bool IsDisplayed = advancePage.FullNameLabelOnEditUserPage.GetElementVisibility();
            Assert.IsTrue(IsDisplayed, "Full Name textbox is not displayed");
        }

        [Then(@"Phone number textbox is displayed")]
        public void ThenPhoneNumberTextboxIsDisplayed()
        {
            bool IsDisplayed = advancePage.PhoneTextField.GetElementVisibility();
            Assert.IsTrue(IsDisplayed, "Phone number textbox is not displayed");
        }

        [Given(@"manager user is on User List page")]
        public void GivenManagerUserIsOnUserListPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            advancePage.AdvancedTab.JavaSciptClick();
        }

        [When(@"user clears Full name field")]
        public void WhenUserClearsFullNameField()
        {
            advancePage.FullName.Clear();
        }
    }
}
