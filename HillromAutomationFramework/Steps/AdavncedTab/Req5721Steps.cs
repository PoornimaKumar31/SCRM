using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AdvancedTab;
using HillromAutomationFramework.SupportingCode;
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
        string RandomFullName = null;
        string RandomPhoneNumber = null;
        string BlankFullName = "";
        int MinLength = 1000;
        int MaxLength = 9999;
        int RandomInvalidUsernameLength = 51;
        int RandomValidUsernameLength = 49;
        int DetailsButtonPosition;
        string RoleXpath = null;

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
            int TotalUser = advancePage.DetailsButtonList.Count;
            Assert.Greater(TotalUser, NoOfMinimumEntries, "Manager user is on User Management page is not more than two entries");
        }

        [When(@"user clicks Details button for other User record")]
        public void WhenUserClicksDetailsButtonForOtherUserRecord()
        {
            DetailsButtonPosition = 0;
            IList<IWebElement> list = advancePage.UserListExceptLoggedInUser();
            Assert.Greater(list.Count, 0, "No user is present except logged User.");

            //Selecting first user details button and clicking
            list[DetailsButtonPosition].FindElement(By.Id(AdvancedPage.Locators.DetailsButtonID)).Click();
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

            DetailsButtonPosition = 0;
            IList<IWebElement> list = advancePage.UserListExceptLoggedInUser();
            Assert.Greater(list.Count, 0, "No user is present except logged User.");
            //Selecting first user details button and clicking
            list[DetailsButtonPosition].FindElement(By.Id(AdvancedPage.Locators.DetailsButtonID)).Click();
        }

        [When(@"user enters Full name with ""(.*)"" characters")]
        public void WhenUserEntersFullNameWithCharacters(string FullNameCharacterSize)
        {
            if (FullNameCharacterSize == ">50")
            {
                advancePage.FullName.Clear();
                RandomFullName = GetMethods.GenerateRandomString(RandomInvalidUsernameLength);
                advancePage.FullName.EnterText(RandomFullName);
            }
            else
            {
                advancePage.FullName.Clear();
                RandomFullName = GetMethods.GenerateRandomString(RandomValidUsernameLength);
                advancePage.FullName.EnterText(RandomFullName);
            }           
        }

        [Then(@"full name error message is displayed")]
        public void ThenPleaseEnterAValidNameErrorMessageIsDisplayed()
        {
            Thread.Sleep(2000);
            bool IsErrorMessageDisplayed = advancePage.FullNameErrorMessageOnCreatePage.GetElementVisibility();
            Assert.IsTrue(IsErrorMessageDisplayed, "Please enter a valid name error message is not displayed.");
        }

        [Then(@"Save button is disabled")]
        public void ThenSaveButtonIsDisabled()
        {
            bool IsSaveButtonDisabled = advancePage.SaveButton.Enabled;
            Assert.IsFalse(IsSaveButtonDisabled, "Save button is enabled.");
        }

        [Then(@"phone number error message is not displayed")]
        public void ThenPhoneNumberErrorMessageIsNotDisplayed()
        {          
            bool Visibility = advancePage.PhoneErrorMessage.GetElementVisibility();
            Assert.IsFalse(Visibility, "Phone number error message is displayed.");
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
            advancePage.SaveButton.JavaSciptClick();
            Thread.Sleep(2000);
        }

        [Then(@"updated Full name is displayed on User List")]
        public void ThenUpdatedFullNameIsDisplayedOnTheUserList()
        {
            bool IsCreated = false;
            IList<IWebElement> list = advancePage.UserList;
            Assert.Greater(list.Count, 0, "No user is present.");

            for (int i = 0; i < list.Count; i++)
            {
                string ActualFullName = list[i].FindElement(By.Id("full_name" + i)).Text;

                if (ActualFullName == RandomFullName)
                {
                    IsCreated = true;
                    break;
                }
            }
            Assert.IsTrue(IsCreated, "New user is not created");
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
            bool IsUserListLabelTextDisplayed = advancePage.UserListLabel.GetElementVisibility();
            Assert.IsTrue(IsUserListLabelTextDisplayed, "User list page is not displayed");
        }

        [When(@"user enters phone number (.*)")]
        public void WhenUserEntersPhoneNumberStartingWith91FollowedByElevenDigitsMobileNumber(string PhoneNumber)
        {
            advancePage.PhoneTextField.Clear();
            advancePage.PhoneTextField.EnterText(PhoneNumber);
        }

        [Then(@"phone number error message is displayed")]
        public void ThenPleaseEnterAValidPhoneNumberErrorMessageIsDisplayed()
        {
            Thread.Sleep(2000);
            bool IsPhoneNumberErrorMessage = advancePage.PhoneErrorMessage.GetElementVisibility();
            Assert.IsTrue(IsPhoneNumberErrorMessage, "phone number error message is not displayed");
        }

        [When(@"user enters a plus sign and a valid random 11-digit Phone number")]
        public void WhenUserEntersPhoneNumberStartingWithFollowedByTenDigitsMobileNumber()
        {
            advancePage.PhoneTextField.Clear();
            //Generating phone number just by passing length of phone number to the method.
            string Random4Digits = GetMethods.GenerateNDigitRandomNumber(4);
            string Prefix = "+1315685";
            RandomPhoneNumber = Prefix + Random4Digits;
            advancePage.PhoneTextField.EnterText(RandomPhoneNumber);
        }

        [When(@"user enters blank Phone number")]
        public void WhenUserEntersBlankPhoneNumber()
        {
            advancePage.PhoneTextField.EnterText(Keys.Control + "a");
            advancePage.PhoneTextField.EnterText(Keys.Delete);
            advancePage.PhoneTextField.EnterText(""); 
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

            //Updating Fullname
            Thread.Sleep(2000);
            advancePage.FullName.Clear();
            advancePage.FullName.EnterText(GetMethods.GenerateRandomString(49));
            advancePage.PhoneTextField.Clear();
            
            //Generating Random 4 digits int number
            string Random4Digits = GetMethods.GenerateNDigitRandomNumber(4);
            string Prefix = "+1315685";
            RandomPhoneNumber = Prefix + Random4Digits;

            //Entering phone number in the text box
            advancePage.PhoneTextField.EnterText(RandomPhoneNumber);          
            Thread.Sleep(3000);
            advancePage.UserManagerCheckBox.JavaSciptClick();
        }

        [Then(@"Full name, Phone number, and Role are not changed on User List page")]
        public void ThenUpdatedFullNameIsNotDisplayedOnUSERLISTPage()
        {
            advancePage.DetailsButtonList[DetailsButtonPosition].Click();
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

            int NoOfDetailsButton = advancePage.DetailsButtonList.Count;
            string[] LogHistory = { };
            for (DetailsButtonPosition = 0; DetailsButtonPosition < NoOfDetailsButton; DetailsButtonPosition++)
            {
                PropertyClass.Driver.FindElement(By.XPath("(//*[@id=\"btn_edit\"])[" + (DetailsButtonPosition + 1) + "]")).Click();
                Thread.Sleep(2000);
                int LogHistoryRows = advancePage.UserListRow.Count;
                if (LogHistoryRows > 2)
                {
                    break;
                }
                else
                {
                    advancePage.CancelButton.Click();
                }
            }
            if (LogHistory.Length == 0)
            {
                Assert.IsTrue(LogHistory.Length == 0, "No any user is present which has History Logs.");
            }
        }

        [Then(@"Log History table is sorted by descending date sort order")]
        public void ThenLogHistoryTableIsSortedByDescendingDateSortOrder()
        {
            var DateTimeList = advancePage.FindLogHistoryDateOrder();
            
            Assert.That(DateTimeList, Is.Ordered.Descending, "Data is not in descending order.");
        }

        [When(@"user clicks Details button for user with a phone number")]
        public void WhenUserClicksDetailsButtonForUserWithAPhoneNumber()
        {
            int IsAllUserRowPhoneNull = -1;
            string phone = null;
            int NoOfDetailsButton = advancePage.DetailsButtonList.Count;
            for (DetailsButtonPosition = 0; DetailsButtonPosition < NoOfDetailsButton; DetailsButtonPosition++)
            {
                advancePage.DetailsButtonList[DetailsButtonPosition].Click();
                phone = advancePage.PhoneTextField.GetAttribute("value");
                if (phone == "")
                {
                    advancePage.CancelButton.Click();
                }
                else if (phone != "")
                {
                    IsAllUserRowPhoneNull = 1;
                    break;
                }
            }
            if (IsAllUserRowPhoneNull==-1)
            {
                Assert.Fail("Phone number does not exist in any user records.");
            }

            _scenarioContext.Add("phonenumber", phone);
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
            advancePage.DetailsButtonList[DetailsButtonPosition].Click();
            Thread.Sleep(2000);
            string ActualUserName = advancePage.FullName.GetAttribute("value");
            Assert.AreEqual(true, BlankFullName != ActualUserName, "New user is created");
        }

        [Then(@"Phone number is entered number")]
        public void ThenPhoneNumberIsEnteredNumber()
        {
            Thread.Sleep(2000);
            string EnteredPhoneNumber = advancePage.PhoneTextField.GetAttribute("value");
            Assert.AreEqual(true, RandomPhoneNumber == EnteredPhoneNumber, "Phone number is not entered number.");
        }

        [Then(@"full name error message is not displayed")]
        public void ThenFullNameErrorMessageIsNotDisplayed()
        {
            Thread.Sleep(2000);
            bool FullNameErrorMessageisplayed = advancePage.NameFieldErrorMessage.GetElementVisibility();
            Assert.IsFalse(FullNameErrorMessageisplayed, "Full name error message is displayed");
        }

        [When(@"(.*)clicks Details button for same user")]
        public void WhenClicksDetailsButtonForSameUser(string p0)
        {
            Thread.Sleep(2000);
            advancePage.DetailsButtonList[DetailsButtonPosition].Click();
        }

        [Then(@"Phone number is blank")]
        public void ThenPhoneNumberIsBlank()
        {
            Thread.Sleep(2000);
            string EnteredPhoneNumber = advancePage.PhoneTextField.GetAttribute("value");
            Assert.AreEqual("", EnteredPhoneNumber, "Phone number is not entered number");
        }

        [When(@"user clicks Details button for user with Administrator role")]
        public void WhenUserClicksDetailsButtonForUserWithAdministratorRole()
        {   
            int NoOfDetailsButton = advancePage.DetailsButtonList.Count;
            //Iterating through the user list
            for (DetailsButtonPosition = 0; DetailsButtonPosition < NoOfDetailsButton; DetailsButtonPosition++)
            {
                string userNameXPath = "//*[@id=\"email" + DetailsButtonPosition + "\"]";
                string userName = PropertyClass.Driver.FindElement(By.XPath(userNameXPath)).Text;
                if (userName != AdvancedPage.ExpectedValues.LoggedUser)
                {
                    RoleXpath = "//*[@id=\"role" + DetailsButtonPosition + "\"]";
                    string Role = PropertyClass.Driver.FindElement(By.XPath(RoleXpath)).Text;
                    if (Role == AdvancedPage.ExpectedValues.UserRoleAdministratorOnUserListPage)
                    {
                        advancePage.DetailsButtonList[DetailsButtonPosition].Click();
                        break;
                    }
                }
            }
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
