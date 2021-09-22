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
    [Binding, Scope(Tag = "SoftwareRequirementID_5721")]
    public class Req5721Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly AdvancedPage _advancePage;
        private readonly WebDriverWait _wait;
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        string SelectedUserName = null;
        string randomFullName = null;
        string randomPhoneNumber = null;
        string blankFullName = "";
        int randomInvalidUsernameLength = 51;
        int randomValidUsernameLength = 49;
        int detailsButtonPosition;
        string roleXpath = null;

        public Req5721Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _advancePage = new AdvancedPage(driver);
        }


        [Given(@"manager user is on User Management page having user entries list > (.*)")]
        public void GivenManagerUserIsOnUserManagementPageHavingUserEntriesList(int noOfMinimumEntries)
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _advancePage.AdvancedTab.JavaSciptClick(_driver);
            int totalUser = _advancePage.DetailsButtonList.Count;
            totalUser.Should().BeGreaterThan(noOfMinimumEntries, "Manager user should be more than two entries on User Management page.");
        }

        [When(@"user clicks Details button for other User record")]
        public void WhenUserClicksDetailsButtonForOtherUserRecord()
        {
            detailsButtonPosition = 0;
            IList<IWebElement> list = _advancePage.UserListExceptLoggedInUser();
            list.Count.Should().BeGreaterThan(0, "No user is present except logged User");

            //Selecting first user details button and clicking
            list[detailsButtonPosition].FindElement(By.Id(AdvancedPage.Locators.DetailsButtonID)).Click();
        }

        [Then(@"Edit Users page is displayed")]
        public void ThenEDITUSERSPageIsDisplayed()
        {
            bool isEditUserPageDisplayed = _advancePage.EditUserLabel.GetElementVisibility();
            isEditUserPageDisplayed.Should().BeTrue("EDIT USER page should be displayed.");
        }

        [Then(@"User information label is displayed")]
        public void ThenUserInformationLabelIsDisplayed()
        {
            bool isUserManagementVisible = _advancePage.UserManagement.GetElementVisibility();
            isUserManagementVisible.Should().BeTrue("User Information label should be displayed on Edit User page.");
        }

        [Then(@"Username textbox is displayed")]
        public void ThenUsernameEmailaddressFieldIsDisplayed()
        {
            bool isUsernameVisible = _advancePage.UserNameOREmailField.GetElementVisibility();
            isUsernameVisible.Should().BeTrue("Username field should be displayed on Edit User page.");
        }

        [Then(@"checkbox with label User manager is displayed")]
        public void ThenCheckboxIsDisplayedWithLabelUserManager()
        {
            bool isCheckboxVisible = _advancePage.UserManagerCheckBox.GetElementVisibility();
            isCheckboxVisible.Should().BeTrue("Checkbox should be displayed with label User Manager on Edit User page.");

            bool isUserManagerLabelVisible = _advancePage.UserManagerLabel.GetElementVisibility();
            isUserManagerLabelVisible.Should().BeTrue("User Manager label should be displayed on Edit User page.");
        }

        [Then(@"Log history label is displayed")]
        public void ThenLogHistoryLabelIsDisplayed()
        {
            bool isHistoryLabelDisplayed = _advancePage.LogHistory.GetElementVisibility();
            isHistoryLabelDisplayed.Should().BeTrue("Log History label displayed on Edit User page.");
        }

        [Then(@"Date column heading is displayed")]
        public void ThenDateColumnHeadingIsDisplayed()
        {
            bool isDateLabelDisplayed = _advancePage.DateColumnHeader.GetElementVisibility();
            isDateLabelDisplayed.Should().BeTrue("Date column heading label should be displayed on Edit User page.");
        }

        [Then(@"Details column heading is displayed")]
        public void ThenDetailsColumnHeadingIsDisplayed()
        {
            bool isDetailsLabelDisplayed = _advancePage.DetailsColumnHeader.GetElementVisibility();
            isDetailsLabelDisplayed.Should().BeTrue("Details column heading should be displayed on Edit User page.");
        }

        [Then(@"Save and Cancel buttons are displayed")]
        public void ThenSaveAndCancelButtonsIsDisplayed()
        {
            Thread.Sleep(2000);
            bool isSaveButtonDisplayed = _advancePage.SaveButton.GetElementVisibility();
            isSaveButtonDisplayed.Should().BeTrue("Save button should be displayed on Edit User page.");

            bool isCancelButtonVisible = _advancePage.CancelButton.GetElementVisibility();
            isCancelButtonVisible.Should().BeTrue("Cancel button should be displayed on Edit User page.");
        }

        [Given(@"manager user is on Edit User page")]
        public void GivenManagerUserIsOnEDITUSERPage()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _advancePage.AdvancedTab.JavaSciptClick(_driver);

            detailsButtonPosition = 0;
            IList<IWebElement> list = _advancePage.UserListExceptLoggedInUser();
            list.Count.Should().BeGreaterThan(0, "No user should be present except logged User.");

            //Selecting first user details button and clicking
            SelectedUserName = list[detailsButtonPosition].FindElement(By.Id("full_name"+detailsButtonPosition)).Text;
            list[detailsButtonPosition].FindElement(By.Id(AdvancedPage.Locators.DetailsButtonID)).Click();
        }

        [When(@"user enters Full name with ""(.*)"" characters")]
        public void WhenUserEntersFullNameWithCharacters(string FullNameCharacterSize)
        {
            if (FullNameCharacterSize == ">50")
            {
                _advancePage.FullName.Clear();
                randomFullName = GetMethods.GenerateRandomString(randomInvalidUsernameLength);
                _advancePage.FullName.EnterText(randomFullName);
            }
            else
            {
                _advancePage.FullName.Clear();
                randomFullName = GetMethods.GenerateRandomString(randomValidUsernameLength);
                _advancePage.FullName.EnterText(randomFullName);
            }           
        }

        [Then(@"full name error message is displayed")]
        public void ThenPleaseEnterAValidNameErrorMessageIsDisplayed()
        {
            Thread.Sleep(2000);
            bool isErrorMessageDisplayed = _advancePage.FullNameErrorMessageOnCreatePage.GetElementVisibility();
            isErrorMessageDisplayed.Should().BeTrue("Please enter a valid name error message should be displayed on EDIT USER page.");
        }

        [Then(@"Save button is disabled")]
        public void ThenSaveButtonIsDisabled()
        {
            bool isSaveButtonDisabled = _advancePage.SaveButton.Enabled;
            isSaveButtonDisabled.Should().BeFalse("Save button should be disabled on EDIT USER page.");
        }

        [Then(@"phone number error message is not displayed")]
        public void ThenPhoneNumberErrorMessageIsNotDisplayed()
        {          
            bool isPhoneumberErrorMessageDisplayed = _advancePage.PhoneErrorMessage.GetElementVisibility();
            isPhoneumberErrorMessageDisplayed.Should().BeFalse("Phone number error message should not be displayed on EDIT USER page.");
        }

        [Then(@"Save button is enabled")]
        public void ThenSaveButtonIsEnabled()
        {
            bool isSaveButtonEnabled = _advancePage.SaveButton.Enabled;
            isSaveButtonEnabled.Should().BeTrue("Save button should be enabled on EDIT USER page.");
        }

        [When(@"user clicks Save button")]
        public void WhenUserClicksOnSaveButton()
        {
            _advancePage.SaveButton.JavaSciptClick(_driver);
            Thread.Sleep(2000);
        }

        [Then(@"updated Full name is displayed on User List")]
        public void ThenUpdatedFullNameIsDisplayedOnTheUserList()
        {
            bool isCreated = false;
            IList<IWebElement> list = _advancePage.UserList;
            list.Count.Should().BeGreaterThan(0, "No user is present.");

            for (int i = 0; i < list.Count; i++)
            {
                string ActualFullName = list[i].FindElement(By.Id("full_name" + i)).Text;

                if (ActualFullName == randomFullName)
                {
                    isCreated = true;
                    break;
                }
            }
            isCreated.Should().BeTrue("New user should be created on USER LIST page.");
        }

        [When(@"user enters blank Full name")]
        public void WhenUserEntersBlankFullName()
        {
            _advancePage.FullName.EnterText(blankFullName);
        }

        [When(@"clicks Cancel button")]
        public void WhenUserClicksOnCancelButton()
        {
            _advancePage.CancelButton.Click();
        }

        [Then(@"user list page is displayed")]
        public void ThenUserListPageIsDisplays()
        {
            Thread.Sleep(2000);
            bool isUserListLabelTextDisplayed = _advancePage.UserListLabel.GetElementVisibility();
            isUserListLabelTextDisplayed.Should().BeTrue("User List page should be displayed on User Management page..");
        }

        [When(@"user enters phone number (.*)")]
        public void WhenUserEntersPhoneNumberStartingWith91FollowedByElevenDigitsMobileNumber(string PhoneNumber)
        {
            _advancePage.PhoneTextField.Clear();
            _advancePage.PhoneTextField.EnterText(PhoneNumber);
        }

        [Then(@"phone number error message is displayed")]
        public void ThenPleaseEnterAValidPhoneNumberErrorMessageIsDisplayed()
        {
            Thread.Sleep(2000);
            bool isPhoneNumberErrorMessage = _advancePage.PhoneErrorMessage.GetElementVisibility();
            isPhoneNumberErrorMessage.Should().BeTrue("Phone number error message should be displayed on EDIT USER page.");
        }

        [When(@"user enters a plus sign and a valid random 11-digit Phone number")]
        public void WhenUserEntersPhoneNumberStartingWithFollowedByTenDigitsMobileNumber()
        {
            _advancePage.PhoneTextField.Clear();
            //Generating phone number just by passing length of phone number to the method.
            string Random4Digits = GetMethods.GenerateNDigitRandomNumber(4);
            string Prefix = "+1315685";
            randomPhoneNumber = Prefix + Random4Digits;
            _advancePage.PhoneTextField.EnterText(randomPhoneNumber);
        }

        [When(@"user enters blank Phone number")]
        public void WhenUserEntersBlankPhoneNumber()
        {
            _advancePage.PhoneTextField.EnterText(Keys.Control + "a");
            _advancePage.PhoneTextField.EnterText(Keys.Delete);
            _advancePage.PhoneTextField.EnterText(""); 
        }

        [When(@"user enters invalid phone number (.*)")]
        public void WhenUserEntersInvalidPhoneNumber(string InvalidPhoneNumber)
        {
            _advancePage.PhoneTextField.Clear();
            _advancePage.PhoneTextField.EnterText(InvalidPhoneNumber);
        }

        [When(@"user deselects the User Manager checkbox")]
        public void WhenUserDeselectsTheUserManagerCheckbox()
        {
            Thread.Sleep(2000);
            bool isSelected = _advancePage.UserManagerCheckBox.Selected;
            if (isSelected == true)
            {
                _advancePage.UserManagerCheckBox.JavaSciptClick(_driver);
            }
            else
            {
                isSelected.Should().BeFalse("User Manager Check box is already deselected.");
            }
        }

        [When(@"user changes Full name, Phone number and Role")]
        public void WhenUserUpdatesFullNameAndPhoneNumber()
        {
            _scenarioContext.Add("fullname", _advancePage.FullName.GetAttribute("value"));
            _scenarioContext.Add("phonenumber", _advancePage.PhoneTextField.GetAttribute("value"));
            _scenarioContext.Add("role", _advancePage.UserManagerCheckBox.Selected);

            //Updating Fullname
            Thread.Sleep(2000);
            _advancePage.FullName.Clear();
            _advancePage.FullName.EnterText(GetMethods.GenerateRandomString(49));
            _advancePage.PhoneTextField.Clear();
            
            //Generating Random 4 digits int number
            string Random4Digits = GetMethods.GenerateNDigitRandomNumber(4);
            string Prefix = "+1315685";
            randomPhoneNumber = Prefix + Random4Digits;

            //Entering phone number in the text box
            _advancePage.PhoneTextField.EnterText(randomPhoneNumber);          
            Thread.Sleep(3000);
            _advancePage.UserManagerCheckBox.JavaSciptClick(_driver);
        }

        [Then(@"Full name, Phone number, and Role are not changed on User List page")]
        public void ThenUpdatedFullNameIsNotDisplayedOnUSERLISTPage()
        {
            _advancePage.DetailsButtonList[detailsButtonPosition].Click();
            string actualFullname = _advancePage.FullName.GetAttribute("value");
            string expectedFullname = _scenarioContext.Get<string>("fullname");
            actualFullname.Should().Be(expectedFullname, "Full name should not be changed on EDIT USER page.");

            string actualPhoneNumber = _advancePage.PhoneTextField.GetAttribute("value");
            string expectedPhonenumber = _scenarioContext.Get<string>("phonenumber");
            actualPhoneNumber.Should().Be(expectedPhonenumber, "Phone number should not be changed on EDIT USER page.");

            bool actualRole = _advancePage.UserManagerCheckBox.Selected;
            bool expectedRole = _scenarioContext.Get<Boolean>("role");
            bool bothTrue = actualRole == expectedRole;
            bothTrue.Should().BeTrue("User role should not be changed on EDIT USER page.");
        }

        [Given(@"manager user is on Edit User page with log entries > (.*)")]
        public void GivenManagerUserIsOnEDITUSERPageWithLogEntries(int LogHistoryCount)
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _advancePage.AdvancedTab.JavaSciptClick(_driver);
            Thread.Sleep(2000);

            int NoOfDetailsButton = _advancePage.DetailsButtonList.Count;
            string[] LogHistory = { };
            for (detailsButtonPosition = 0; detailsButtonPosition < NoOfDetailsButton; detailsButtonPosition++)
            {
                _driver.FindElement(By.XPath("(//*[@id=\"btn_edit\"])[" + (detailsButtonPosition + 1) + "]")).Click();
                Thread.Sleep(2000);
                int LogHistoryRows = _advancePage.UserListRow.Count;
                if (LogHistoryRows > 2)
                {
                    break;
                }
                else
                {
                    _advancePage.CancelButton.Click();
                }
            }
            if (LogHistory.Length == 0)
            {
                bool isEqual = LogHistory.Length == 0;
                isEqual.Should().BeTrue("No any user is present which has History Logs.");
            }
        }

        [Then(@"Log History table is sorted by descending date sort order")]
        public void ThenLogHistoryTableIsSortedByDescendingDateSortOrder()
        {
            var DateTimeList = _advancePage.FindLogHistoryDateOrder();
            Assert.That(DateTimeList, Is.Ordered.Descending, "Data is not in descending order.");
        }

        [When(@"user clicks Details button for user with a phone number")]
        public void WhenUserClicksDetailsButtonForUserWithAPhoneNumber()
        {
            int IsAllUserRowPhoneNull = -1;
            string phone = null;
            int NoOfDetailsButton = _advancePage.DetailsButtonList.Count;
            IList<IWebElement> list = _advancePage.UserList;
            for (detailsButtonPosition = 0; detailsButtonPosition < NoOfDetailsButton; detailsButtonPosition++)
            {
                SelectedUserName = list[detailsButtonPosition].FindElement(By.Id("full_name" + detailsButtonPosition)).Text;
                _advancePage.DetailsButtonList[detailsButtonPosition].Click();
                phone = _advancePage.PhoneTextField.GetAttribute("value");
                if (phone == "")
                {
                    _advancePage.CancelButton.Click();
                }
                else if (phone != "")
                {
                    IsAllUserRowPhoneNull = 1;
                    break;
                }
            }
            if (IsAllUserRowPhoneNull == -1)
            {
                Assert.Fail("Phone number does not exist in any user records.");
            }

            _scenarioContext.Add("phonenumber", phone);
        }

        [Then(@"Phone number is unchanged")]
        public void ThenUserPhoneNumberIsNotChanged()
        {
            string actualPhoneNumber = _advancePage.PhoneTextField.GetAttribute("value");
            string expectedPhonenumber = _scenarioContext.Get<string>("phonenumber");
            actualPhoneNumber.Should().Be(expectedPhonenumber, "Phone number should be unchanged.");
        }

        [Then(@"presses Tab")]
        public void ThenPressesTab()
        {
            _advancePage.FullName.EnterText(Keys.Tab);
        }

        [When(@"presses Tab")]
        public void WhenPressesTab()
        {
            _advancePage.FullName.EnterText(Keys.Tab);
        }

        [Then(@"user is not edited")]
        public void ThenUserIsNotEdited()
        {
            _advancePage.DetailsButtonList[detailsButtonPosition].Click();
            Thread.Sleep(2000);
            string actualUserName = _advancePage.FullName.GetAttribute("value");
            bool isTrue = blankFullName != actualUserName;
            isTrue.Should().BeTrue("User should not be edited on Edit User page.");
        }

        [Then(@"Phone number is entered number")]
        public void ThenPhoneNumberIsEnteredNumber()
        {
            Thread.Sleep(2000);
            string EnteredPhoneNumber = _advancePage.PhoneTextField.GetAttribute("value");
            EnteredPhoneNumber.Should().BeEquivalentTo(randomPhoneNumber, "Phone number should be entered number on Edit User page.");
        }

        [Then(@"full name error message is not displayed")]
        public void ThenFullNameErrorMessageIsNotDisplayed()
        {
            Thread.Sleep(2000);
            bool isFullNameErrorMessageDisplayed = _advancePage.NameFieldErrorMessage.GetElementVisibility();
            isFullNameErrorMessageDisplayed.Should().BeFalse("Full name error message should not be displayed on User List page.");
        }

        [When(@"(.*)clicks Details button for same user")]
        public void WhenClicksDetailsButtonForSameUser(string p0)
        {
            Thread.Sleep(2000);
            detailsButtonPosition = _advancePage.GetIndexOfSpecificUser(_driver,SelectedUserName);
            _advancePage.DetailsButtonList[detailsButtonPosition].Click();
        }

        [Then(@"Phone number is blank")]
        public void ThenPhoneNumberIsBlank()
        {
            Thread.Sleep(2000);
            string enteredPhoneNumber = _advancePage.PhoneTextField.GetAttribute("value");
            enteredPhoneNumber.Should().BeEmpty("Phone number should be blank on Edit User page.");
        }

        [When(@"user clicks Details button for user with Administrator role")]
        public void WhenUserClicksDetailsButtonForUserWithAdministratorRole()
        {   
            int NoOfDetailsButton = _advancePage.DetailsButtonList.Count;
            IList<IWebElement> list = _advancePage.UserList;
            //Iterating through the user list
            for (detailsButtonPosition = 0; detailsButtonPosition < NoOfDetailsButton; detailsButtonPosition++)
            {
                string userNameXPath = "//*[@id=\"email" + detailsButtonPosition + "\"]";
                string userName = _driver.FindElement(By.XPath(userNameXPath)).Text;
                if (userName != AdvancePageExpectedValues.LoggedUser)
                {
                    roleXpath = "//*[@id=\"role" + detailsButtonPosition + "\"]";
                    string Role = _driver.FindElement(By.XPath(roleXpath)).Text;
                    if (Role == AdvancePageExpectedValues.UserRoleAdministratorOnUserListPage)
                    {
                        SelectedUserName = list[detailsButtonPosition].FindElement(By.Id("full_name" + detailsButtonPosition)).Text;
                        _advancePage.DetailsButtonList[detailsButtonPosition].Click();
                        break;
                    }
                }
            }
        }

        [Then(@"Regular is displayed in Role column in user list")]
        public void ThenRegularIsDisplayedInRoleColumnInUserList()
        {
            Thread.Sleep(2000);
            string actualRole = _driver.FindElement(By.XPath(roleXpath)).Text;
            string expectedRole = AdvancePageExpectedValues.UserRoleRegularOnUserListPage;
            actualRole.Should().Be(expectedRole, "Regular should be displayed in Role column on User List page.");
        }

        [When(@"user selects the User Manager checkbox")]
        public void WhenUserSelectsTheUserManagerCheckbox()
        {
            Thread.Sleep(2000);
            _advancePage.UserManagerCheckBox.JavaSciptClick(_driver);
        }

        [Then(@"Administrator is displayed in Role column in User List")]
        public void ThenAdministratorIsDisplayedInRoleColumnInUserList()
        {
            Thread.Sleep(2000);
            string actualRole = _driver.FindElement(By.XPath(roleXpath)).Text;
            string expectedRole = AdvancePageExpectedValues.UserRoleAdministratorOnUserListPage;
            actualRole.Should().Be(expectedRole, "Administrator should be displayed in Role column on User List page.");
        }

        [Then(@"Username textbox is read only")]
        public void ThenUsernameTextboxIsReadOnly()
        {
            bool isUsernameReadOnly = _advancePage.UserNameOREmailField.IsReadOnly();
            isUsernameReadOnly.Should().BeTrue("Username textbox should be read only on Edit User page.");
        }

        [Then(@"checkbox is unchecked")]
        public void ThenCheckboxIsUnchecked()
        {
            Thread.Sleep(2000);
            _advancePage.UserManagerCheckBox.JavaSciptClick(_driver);
        }

        [Then(@"Cancel button is enabled")]
        public void ThenCancelButtonEnabled()
        {
            bool isCancelButtonEnabled = _advancePage.CancelButton.Enabled;
            isCancelButtonEnabled.Should().BeTrue("Cancel button should be enabled on Edit User page.");
        }

        [Then(@"Full name textbox is displayed")]
        public void ThenFullNameTextboxIsDisplayed()
        {
            bool isDisplayed = _advancePage.FullNameLabelOnEditUserPage.GetElementVisibility();
            isDisplayed.Should().BeTrue("Full name textbox should be displayed on Edit User page.");
        }

        [Then(@"Phone number textbox is displayed")]
        public void ThenPhoneNumberTextboxIsDisplayed()
        {
            bool isDisplayed = _advancePage.PhoneTextField.GetElementVisibility();
            isDisplayed.Should().BeTrue("Phone number textbox should be displayed on Edit User page.");
        }

        [Given(@"manager user is on User List page")]
        public void GivenManagerUserIsOnUserListPage()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _advancePage.AdvancedTab.JavaSciptClick(_driver);
        }

        [When(@"user clears Full name field")]
        public void WhenUserClearsFullNameField()
        {
            _advancePage.FullName.Clear();
        }
    }
}
