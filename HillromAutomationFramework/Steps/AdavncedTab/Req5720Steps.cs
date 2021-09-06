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
using ExplicitWait = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HillromAutomationFramework.Steps.AdavncedTab
{
    [Binding, Scope(Tag = "SoftwareRequirementID_5720")]
    public class Req5720Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly AdvancedPage _advancePage;
        private readonly ScenarioContext _scenarioContext;
        readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        string randomString = null;
        string randomUsername = null;
        string randomPhoneNumber =null;
        string randomFullName = null;
        string actualEmail = null;
        string actualFullName = null;
        string actualRole = null;
        string userInputInvalidUserName = null;
        string userInputFullname = null;
        string role = null;

        

        public Req5720Steps(ScenarioContext scenarioContext)
        {
            _loginPage = new LoginPage();
            _landingPage = new LandingPage();
            _advancePage = new AdvancedPage();           
            _scenarioContext = scenarioContext;
        }

        [Given(@"manager user is on User List page")]
        public void GivenManagerUserIsOnUserListPage()
        {
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            //Clicking on facility
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _advancePage.AdvancedTab.JavaSciptClick();
        }

        [When(@"user clicks Create button")]
        public void WhenUserClicksCreateButton()
        {
            Thread.Sleep(1000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)PropertyClass.Driver;
            js.ExecuteScript("window.scrollTo(0, 0)");
            _advancePage.CreateUserOnCreatePage.Click();
        }

        [Then(@"Add User page is displayed")]
        public void ThenAddUserPageIsDisplayed()
        {
            string addUserTitle = _advancePage.AddUserOnCreatePage.Text;
            addUserTitle.Should().Be(AdvancedPage.ExpectedValues.AddUserListPageText, "Add User page should be displayed on clicking on CREATE button.");
        }

        [Then(@"User information label is displayed")]
        public void ThenUserInformationLabelIsDisplayed()
        {
            string UserInformationLabel = _advancePage.UserInformationLabel.Text;
            UserInformationLabel.Should().Be(AdvancedPage.ExpectedValues.UserInformationLabel, "User information label should be displayed on EDIT USER page.");
        }

        [Then(@"Username textbox is displayed")]
        public void ThenUsernameTextboxIsDisplayed()
        {
            bool isUsernameTextBoxDisplayed = _advancePage.UserNameTextBoxOnCreatePage.GetElementVisibility();
            isUsernameTextBoxDisplayed.Should().BeTrue(because: "Username textbox should be displayed on Add User page.");
        }

        [Then(@"unchecked checkbox with User manager label is displayed")]
        public void ThenUncheckedCheckboxWithUserManagerLabelIsDisplayed()
        {
            Thread.Sleep(2000);
            bool isDisplayed = _advancePage.UserManagerOnCreatePage.Selected;
            isDisplayed.Should().BeFalse(because: "Unchecked checkbox with User manager label should be displayed on Add User page.");
        }

        [Then(@"Full name textbox is displayed")]
        public void ThenFullNameTextboxIsDisplayed()
        {
            bool isDisplayed = _advancePage.FullNameOnCreatePage.GetElementVisibility();
            isDisplayed.Should().BeTrue(because: "Full Name textbox should be displayed on Add User page.");
        }

        [Then(@"Phone number textbox is displayed")]
        public void ThenPhoneNumberTextboxIsDisplayed()
        {
            bool isDisplayed = _advancePage.PhoneNumberOnCreatePage.GetElementVisibility();
            isDisplayed.Should().BeTrue(because: "Phone number textbox is displayed on Add User page.");
        }

        [Then(@"disabled Save button is displayed")]
        public void ThenDisabledSaveButtonIsDisplayed()
        {
            bool isDisabled = _advancePage.SaveButtonOnCreatePage.Enabled;
            bool isSaveButtonVisibility = _advancePage.SaveButtonOnCreatePage.GetElementVisibility();

            isDisabled.Should().BeFalse(because: "Save button should be disabled on Add User page.");
            isSaveButtonVisibility.Should().BeTrue(because: "Save button should be displayed on Add User page.");
        }

        [Then(@"enabled Cancel button is displayed")]
        public void ThenEnabledCancelButtonIsDisplayed()
        {
            bool isEnabled = _advancePage.CancelButtonOnCreatePage.Enabled;
            isEnabled.Should().BeTrue(because: "Cancel button should be enabled on Add User page.");
        }

        [Given(@"manager user is on Add User page")]
        public void GivenManagerUserIsOnAddUserPage()
        {
            GivenManagerUserIsOnUserListPage();
            _advancePage.CreateUserOnCreatePage.Click();
        }

        [When(@"user enters Full name ""(.*)""")]
        public void WhenUserEntersFullNam(string FullName)
        {
            userInputFullname = FullName;
            _advancePage.FullNameOnCreatePage.EnterText(FullName);
        }

        [When(@"clicks Username textbox")]
        public void WhenClicksUsernameTextbox()
        {
            _advancePage.UserNameTextBoxOnCreatePage.Click();
        }

        [When(@"enters valid Username ""(.*)""")]
        public void WhenEntersValidUsername(string ValidUserName)
        {
            _advancePage.UserNameTextBoxOnCreatePage.EnterText(ValidUserName);
        }

        [When(@"presses Tab key")]
        public void WhenPressesTabKey()
        {
            _advancePage.UserNameTextBoxOnCreatePage.EnterText(Keys.Tab);
        }

        [Then(@"no username error message is displayed")]
        public void ThenNoUsernameErrorMessageIsDisplayed()
        {
            bool isDisplayed = _advancePage.UserNameErrorMessageOnCreatePage.GetElementVisibility();
            isDisplayed.Should().BeFalse(because: "Error message should not be displayed when user enters valid username.");
        }

        [Then(@"enabled Save button is displayed")]
        public void ThenEnabledSaveButtonIsDisplayed()
        {
            bool IsSaveButtonEnabled = _advancePage.SaveButtonOnCreatePage.Enabled;
            IsSaveButtonEnabled.Should().BeTrue(because: "Save button should be enabled on Add User page.");
            bool isSaveDisplayed = _advancePage.SaveButtonOnCreatePage.GetElementVisibility();
            isSaveDisplayed.Should().BeTrue(because: "Save button should be displayed on Add User page.");
        }

        [Then(@"username error message is displayed")]
        public void ThenUsernameErrorMessageIsDisplayed()
        {
            Thread.Sleep(1000);
            bool isUsernameErrorMessageDisplayed = _advancePage.UserNameErrorMessageOnCreatePage.GetElementVisibility();
            isUsernameErrorMessageDisplayed.Should().BeTrue("Username error message should be displayed on Add User page.");
        }

        [When(@"user enters invalid Username ""(.*)""")]
        public void WhenUserEntersInvalidUsername(string InvalidUserName)
        {
            userInputInvalidUserName = InvalidUserName;
            _advancePage.UserNameTextBoxOnCreatePage.EnterText(userInputInvalidUserName);
        }

        [When(@"user clicks Cancel button")]
        public void WhenUserClicksCancelButton()
        {
            _advancePage.CancelButtonOnCreatePage.Click();
        }

        [Then(@"User List page is displayed")]
        public void ThenUserListPageIsDisplayed()
        {
            Thread.Sleep(2000);
            SetMethods.ScrollUpWebPage();
            Thread.Sleep(1000);
            bool IsUserListDisplayed = _advancePage.UserListLabel.GetElementVisibility();
            IsUserListDisplayed.Should().BeTrue("User list Page should be displayed");
        }

        [Then(@"no user is created")]
        public void ThenNoUserIsCreated()
        {
            bool IsUserCreated = false;
            IList<IWebElement> list = _advancePage.UserList;
            Assert.Greater(list.Count, 0, "No user is present except logged User.");

            for (int i = 0; i < list.Count; i++)
            {
                actualEmail = list[i].FindElement(By.Id("email" + i)).Text;
                if (actualEmail == randomUsername)
                {
                    IsUserCreated = true;
                    break;
                }
            }
            IsUserCreated.Should().BeFalse("New user should be created on USER LIST page");
        }

        [Given(@"manager user is on User Management page")]
        public void GivenManagerUserIsOnUserManagementPage()
        {
            Thread.Sleep(2000);
            bool IsUserManagementVisible = _advancePage.UserManagement.GetElementVisibility();
            IsUserManagementVisible.Should().BeTrue("Manager user should be on User Management page");
        }

        [When(@"user enters Username ""(.*)""")]
        public void WhenUserEntersUsername(string UserName)
        {
            userInputInvalidUserName = UserName;
            _advancePage.UserNameTextBoxOnCreatePage.EnterText(UserName);
        }

        [When(@"clicks Full name textbox")]
        public void WhenClicksFullNameTextbox()
        {
            _advancePage.FullNameOnCreatePage.Click();
        }

        [When(@"enters (.*)-character Full name")]
        public void WhenEnters_CharacterFullName(int stringSize)
        {
            string FullName = GetMethods.GenerateRandomString(stringSize);
            userInputFullname = FullName;
            _advancePage.FullNameOnCreatePage.EnterText(FullName);
        }

        [Then(@"no name error message is displayed")]
        public void ThenNoNameErrorMessageIsDisplayed()
        {
            bool isNameErrorMessageDisplayed = _advancePage.FullNameErrorMessageOnCreatePage.GetElementVisibility();
            isNameErrorMessageDisplayed.Should().BeFalse("No name error message should be displayed on ADD USER page.");
        }

        [Then(@"name error message is displayed")]
        public void ThenNameErrorMessageIsDisplayed()
        {
            Thread.Sleep(2000);
            bool isNameErrorMessageDisplayed = _advancePage.FullNameErrorMessageOnCreatePage.GetElementVisibility();
            isNameErrorMessageDisplayed.Should().BeTrue("Name error message should be displayed on ADD USER page.");
        }

        [When(@"enters (.*)-character valid Full name")]
        public void WhenEnters_CharacterValidFullName(int stringSize)
        {
            //Passing the length of string to the method and generating random string and that string is used as a Full name.
            randomString = GetMethods.GenerateRandomString(stringSize);
            _advancePage.FullNameOnCreatePage.EnterText(randomString);
        }

        [When(@"enters Phone number ""(.*)""")]
        public void WhenEntersPhoneNumber(string phoneNumber)
        {
            randomPhoneNumber = phoneNumber;
            _advancePage.PhoneNumberOnCreatePage.EnterText(phoneNumber);
        }

        [When(@"clicks User Manager checkbox")]
        public void WhenClicksUserManagerCheckbox()
        {
            _advancePage.UserManagerOnCreatePage.JavaSciptClick();
        }

        [When(@"clicks Save")]
        public void WhenClicksSave()
        {
            SetMethods.ScrollToBottomofWebpage();
            Thread.Sleep(1000);
            _advancePage.SaveButtonOnCreatePage.Click();
        }

        [Then(@"new user is created")]
        public void ThenNewUserIsCreated()
        {
            bool isUserCreated = false;
            IList<IWebElement> list = _advancePage.UserList;
            //Assert.Greater(list.Count, 0, "No user is present except logged User.");
            list.Count.Should().BeGreaterThan(0, "No user should be present except logged User on USER LIST page");

            for (int i = 0; i < list.Count; i++)
            {
                actualEmail = list[i].FindElement(By.Id("email" + i)).Text;
                actualFullName = list[i].FindElement(By.Id("full_name" + i)).Text;
                actualRole = list[i].FindElement(By.Id("role" + i)).Text;
                if (actualEmail == randomUsername)
                {
                    isUserCreated = true;
                    break;
                }
            }
            isUserCreated.Should().BeTrue("New user should be created on USER LIST page.");
        }

        [Then(@"new user role is Administrator")]
        public void ThenNewUserRoleIsAdministrator()
        {
            bool isTrue = actualRole == AdvancedPage.ExpectedValues.UserRoleAdministratorOnUserListPage;
            isTrue.Should().BeTrue("New user role should appear Administrator on USER LIST page.");
        }

        [Then(@"Username, Name, and Phone number match")]
        public void ThenUsernameNameAndPhoneNumberMatch()
        {
            //Username and Full name matching from the User List Page
            bool isSameUsername = randomUsername == actualEmail;
            isSameUsername.Should().BeTrue("Username should be matched.");

            bool isSameFullname = randomFullName == actualFullName;
            isSameFullname.Should().BeTrue("Name should be matched.");

            //To match Phone number, need to click on Details button then I will get Phone number. So passing ActualUserName through method to find in table content and then Click on corresponding Details button.
            _advancePage.ClickOnDetailsButtonOfSpecifiedUser(randomUsername);
            
            //Getting Phone number after clicking on Details button
            string ActualPhoneNumber = _advancePage.PhoneTextField.GetAttribute("value");
            bool isSamePhoneNumber = ActualPhoneNumber == randomPhoneNumber;
            isSamePhoneNumber.Should().BeTrue("Phone number should be matched.");
        }

        [When(@"does not click User Manager checkbox")]
        public void WhenDoesNotClickUserManagerCheckbox()
        {
            bool IsCheckboxSelected = _advancePage.UserManagerCheckBox.Selected;
            IsCheckboxSelected.Should().BeTrue("User Manager checkbox is already selected.");
        }

        [Then(@"new user role is Regular")]
        public void ThenNewUserRoleIsRegular()
        {
            IList<IWebElement> list = _advancePage.UserList;
            for (int i = 0; i < list.Count; i++)
            {
                actualRole = list[i].FindElement(By.Id("role" + i)).Text;
                actualEmail = list[i].FindElement(By.Id("email" + i)).Text;
                actualFullName = list[i].FindElement(By.Id("full_name" + i)).Text;
                if (randomUsername == actualEmail)
                {
                    break;
                }
            }
            actualRole.Should().Be(AdvancedPage.ExpectedValues.UserRoleRegularOnUserListPage, "New user role should be Regular on USER LIST page.");
        }

        [Then(@"Username and Name match")]
        public void ThenUsernameAndNameMatch()
        {
            bool isSameUsername = randomUsername == actualEmail;
            isSameUsername.Should().BeTrue("Username should be matched.");

            bool isSameFullName = randomFullName == actualFullName;
            isSameFullName.Should().BeTrue("Name should be matched.");
        }

        [Then(@"Phone number is blank")]
        public void ThenPhoneNumberIsBlank()
        {
            _advancePage.ClickOnDetailsButtonOfSpecifiedUser(randomUsername);
            string phoneNumber = _advancePage.PhoneTextField.GetAttribute("value");
            phoneNumber.Should().BeEmpty("Phone number should be blank.");
        }

        [When(@"user enters valid Username")]
        public void WhenUserEntersValidUsername()
        {
            randomUsername = GetMethods.GenerateRandomUsername(15);
            _advancePage.UserNameTextBoxOnCreatePage.EnterText(randomUsername);
        }

        [When(@"enters valid Full name")]
        public void WhenEntersValidFullName()
        {
            randomFullName = GetMethods.GenerateRandomString(15);
            _advancePage.FullNameOnCreatePage.EnterText(randomFullName);
        }
      
        [When(@"unchecks User Manager checkbox")]
        public void WhenUnchecksUserManagerCheckbox()
        {
            bool IsCheckboxSelected = _advancePage.UserManagerOnCreatePage.Selected;

            if (IsCheckboxSelected == true)
            {                
                _advancePage.UserManagerOnCreatePage.JavaSciptClick();
            }
        }

        [When(@"user enters Phone number ""(.*)""")]
        public void WhenUserEntersPhoneNumber(string PhoneNumber)
        {
            _advancePage.PhoneNumberOnCreatePage.EnterText(PhoneNumber);
        }

        [Then(@"phone number error message is displayed")]
        public void ThenPhoneNumberErrorMessageIsDisplayed()
        {
            bool isPhoneNumberErrorMessageDisplayed = _advancePage.PhoneErrorMessageOnAddUserPage.GetElementVisibility();
            isPhoneNumberErrorMessageDisplayed.Should().BeTrue("Phone number error message should be displayed on ADD USER page.");
        }

        [When(@"user enters valid email address, Name, Phone")]
        public void WhenUserEntersValidEmailAddressNamePhone()
        {
            //Entering valid user name
            randomUsername = GetMethods.GenerateRandomUsername(15);
            _advancePage.UserNameTextBoxOnCreatePage.EnterText(randomUsername);
            userInputInvalidUserName = randomUsername;

            //Entering valid Full name
            randomFullName = GetMethods.GenerateRandomString(15);
            _advancePage.FullNameOnCreatePage.EnterText(randomFullName);
            userInputFullname = randomFullName;

            //Entering valid phone number
            string RandomNumber4Digits = GetMethods.GenerateNDigitRandomNumber(4);
            string Prefix = "+1315685";
            randomPhoneNumber = Prefix + RandomNumber4Digits;
            _advancePage.PhoneNumberOnCreatePage.EnterText(randomPhoneNumber);
        }
    }
}
