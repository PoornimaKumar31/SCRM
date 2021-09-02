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
        readonly WebDriverWait _wait;
        string RandomString = null;
        string RandomUsername = null;
        string RandomPhoneNumber =null;
        string RandomFullName = null;
        string ActualEmail = null;
        string ActualFullName = null;
        string ActualRole = null;
        string UserInputInvalidUserName = null;
        string UserInputFullname = null;
        string Role = null;

        private readonly ScenarioContext _scenarioContext;

        public Req5720Steps(ScenarioContext scenarioContext)
        {
            _loginPage = new LoginPage();
            _landingPage = new LandingPage();
            _advancePage = new AdvancedPage();
            _wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
            _scenarioContext = scenarioContext;
        }

        [Given(@"manager user is on User List page")]
        public void GivenManagerUserIsOnUserListPage()
        {
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            //Clicking on facility
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            _wait.Until(ExplicitWait.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
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
            string AddUserTitle = _advancePage.AddUserOnCreatePage.Text;
            Assert.AreEqual(AdvancedPage.ExpectedValues.AddUserListPageText, AddUserTitle, "Add User page is not displayed.");
        }

        [Then(@"User information label is displayed")]
        public void ThenUserInformationLabelIsDisplayed()
        {
            string UserInformationLabel = _advancePage.UserInformationLabel.Text;
            Assert.AreEqual("User Information:", UserInformationLabel, "User information label is not displayed.");
        }

        [Then(@"Username textbox is displayed")]
        public void ThenUsernameTextboxIsDisplayed()
        {
            bool IsDisplayed = _advancePage.UserNameTextBoxOnCreatePage.GetElementVisibility();
            Assert.IsTrue(IsDisplayed, "Username textbox is not displayed.");
        }

        [Then(@"unchecked checkbox with User manager label is displayed")]
        public void ThenUncheckedCheckboxWithUserManagerLabelIsDisplayed()
        {
            Thread.Sleep(2000);
            bool IsUnchecked = _advancePage.UserManagerOnCreatePage.Selected;
            Assert.IsFalse(IsUnchecked, "Unchecked checkbox with User manager label is not displayed.");
        }

        [Then(@"Full name textbox is displayed")]
        public void ThenFullNameTextboxIsDisplayed()
        {
            bool IsDisplayed = _advancePage.FullNameOnCreatePage.GetElementVisibility();
            Assert.IsTrue(IsDisplayed, "Full Name textbox is not displayed.");
        }

        [Then(@"Phone number textbox is displayed")]
        public void ThenPhoneNumberTextboxIsDisplayed()
        {
            bool IsDisplayed = _advancePage.PhoneNumberOnCreatePage.GetElementVisibility();
            Assert.IsTrue(IsDisplayed, "Phone number textbox is not displayed.");
        }

        [Then(@"disabled Save button is displayed")]
        public void ThenDisabledSaveButtonIsDisplayed()
        {
            bool IsDisabled = _advancePage.SaveButtonOnCreatePage.Enabled;
            bool IsSaveButtonVisibility = _advancePage.SaveButtonOnCreatePage.GetElementVisibility();
            Assert.IsFalse(IsDisabled, "Save button is not disabled");
            Assert.IsTrue(IsSaveButtonVisibility, "Save button is not displayed");
        }

        [Then(@"enabled Cancel button is displayed")]
        public void ThenEnabledCancelButtonIsDisplayed()
        {
            bool IsEnabled = _advancePage.CancelButtonOnCreatePage.Enabled;
            Assert.IsTrue(IsEnabled, "Cancel button is not enabled");
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
            UserInputFullname = FullName;
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
            bool IsDisplayed = _advancePage.UserNameErrorMessageOnCreatePage.GetElementVisibility();
            Assert.IsFalse(IsDisplayed, "Username error message is displayed");
        }

        [Then(@"enabled Save button is displayed")]
        public void ThenEnabledSaveButtonIsDisplayed()
        {
            bool IsSaveButtonEnabled = _advancePage.SaveButtonOnCreatePage.Enabled;
            Assert.IsTrue(IsSaveButtonEnabled);
        }

        [Then(@"username error message is displayed")]
        public void ThenUsernameErrorMessageIsDisplayed()
        {
            Thread.Sleep(1000);
            bool IsDisplayed = _advancePage.UserNameErrorMessageOnCreatePage.GetElementVisibility();
            Assert.IsTrue(IsDisplayed, "Username error message is not displayed");
        }

        [When(@"user enters invalid Username ""(.*)""")]
        public void WhenUserEntersInvalidUsername(string InvalidUserName)
        {
            UserInputInvalidUserName = InvalidUserName;
            _advancePage.UserNameTextBoxOnCreatePage.EnterText(UserInputInvalidUserName);
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
            Assert.IsTrue(IsUserListDisplayed, "User list Page is not displayed");
        }

        [Then(@"no user is created")]
        public void ThenNoUserIsCreated()
        {
            bool IsUserCreated = false;
            IList<IWebElement> list = _advancePage.UserList;
            Assert.Greater(list.Count, 0, "No user is present except logged User.");

            for (int i = 0; i < list.Count; i++)
            {
                ActualEmail = list[i].FindElement(By.Id("email" + i)).Text;
                if (ActualEmail == RandomUsername)
                {
                    IsUserCreated = true;
                    break;
                }
            }
            Assert.IsFalse(IsUserCreated, "New user is created");
        }

        [Given(@"manager user is on User Management page")]
        public void GivenManagerUserIsOnUserManagementPage()
        {
            Thread.Sleep(2000);
            bool IsUserManagementVisible = _advancePage.UserManagement.GetElementVisibility();
            Assert.IsTrue(IsUserManagementVisible, "Manager user is not on User Management page");
        }

        [When(@"user enters Username ""(.*)""")]
        public void WhenUserEntersUsername(string UserName)
        {
            UserInputInvalidUserName = UserName;
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
            UserInputFullname = FullName;
            _advancePage.FullNameOnCreatePage.EnterText(FullName);
        }

        [Then(@"no name error message is displayed")]
        public void ThenNoNameErrorMessageIsDisplayed()
        {
            bool IsNameErrorMessageDisplayed = _advancePage.FullNameErrorMessageOnCreatePage.GetElementVisibility();
            Assert.IsFalse(IsNameErrorMessageDisplayed, "Name error message is displayed");
        }

        [Then(@"name error message is displayed")]
        public void ThenNameErrorMessageIsDisplayed()
        {
            Thread.Sleep(2000);
            bool IsNameErrorMessageDisplayed = _advancePage.FullNameErrorMessageOnCreatePage.GetElementVisibility();
            Assert.IsTrue(IsNameErrorMessageDisplayed, "Name error message is not displayed");
        }

        [When(@"enters (.*)-character valid Full name")]
        public void WhenEnters_CharacterValidFullName(int stringSize)
        {
            //Passing the length of string to the method and generating random string and that string is used as a Full name.
            RandomString = GetMethods.GenerateRandomString(stringSize);
            _advancePage.FullNameOnCreatePage.EnterText(RandomString);
        }

        [When(@"enters Phone number ""(.*)""")]
        public void WhenEntersPhoneNumber(string phoneNumber)
        {
            RandomPhoneNumber = phoneNumber;
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
            bool IsCreated = false;
            IList<IWebElement> list = _advancePage.UserList;
            Assert.Greater(list.Count, 0, "No user is present except logged User.");

            for (int i = 0; i < list.Count; i++)
            {
                ActualEmail = list[i].FindElement(By.Id("email" + i)).Text;
                ActualFullName = list[i].FindElement(By.Id("full_name" + i)).Text;
                ActualRole = list[i].FindElement(By.Id("role" + i)).Text;
                if (ActualEmail == RandomUsername)
                {
                    IsCreated = true;
                    break;
                }
            }
            Assert.IsTrue(IsCreated, "New user is not created");
        }

        [Then(@"new user role is Administrator")]
        public void ThenNewUserRoleIsAdministrator()
        {
            Assert.IsTrue(ActualRole == AdvancedPage.ExpectedValues.UserRoleAdministratorOnUserListPage, "New user role is not Administrator");
        }

        [Then(@"Username, Name, and Phone number match")]
        public void ThenUsernameNameAndPhoneNumberMatch()
        {
            //Username and Full name matching from the User List Page
            Assert.AreEqual(true, RandomUsername == ActualEmail, "Username does not match");
            Assert.AreEqual(true, RandomFullName == ActualFullName, "Name does not match");

            //To match Phone number, need to click on Details button then I will get Phone number. So passing ActualUserName through method to find in table content and then Click on corresponding Details button.
            _advancePage.ClickOnDetailsButtonOfSpecifiedUser(RandomUsername);
            
            //Getting Phone number after clicking on Details button
            string ActualPhoneNumber = _advancePage.PhoneTextField.GetAttribute("value");
            Assert.AreEqual(true, ActualPhoneNumber == RandomPhoneNumber, "Phone does not match");
        }

        [When(@"does not click User Manager checkbox")]
        public void WhenDoesNotClickUserManagerCheckbox()
        {
            bool IsCheckboxSelected = _advancePage.UserManagerCheckBox.Selected;
            Assert.IsTrue(IsCheckboxSelected, "Click User Manager checkbox");
        }

        [Then(@"new user role is Regular")]
        public void ThenNewUserRoleIsRegular()
        {
            IList<IWebElement> list = _advancePage.UserList;
            for (int i = 0; i < list.Count; i++)
            {
                ActualRole = list[i].FindElement(By.Id("role" + i)).Text;
                ActualEmail = list[i].FindElement(By.Id("email" + i)).Text;
                ActualFullName = list[i].FindElement(By.Id("full_name" + i)).Text;
                if (RandomUsername == ActualEmail)
                {
                    break;
                }
            }
            Assert.AreEqual(AdvancedPage.ExpectedValues.UserRoleRegularOnUserListPage, ActualRole, "New user role is not Regular");
        }

        [Then(@"Username and Name match")]
        public void ThenUsernameAndNameMatch()
        {
            Assert.AreEqual(true, RandomFullName == ActualFullName, "Name not matched");
            Assert.AreEqual(true, RandomUsername == ActualEmail, "Username not matched");
        }

        [Then(@"Phone number is blank")]
        public void ThenPhoneNumberIsBlank()
        {
            _advancePage.ClickOnDetailsButtonOfSpecifiedUser(RandomUsername);
            string phoneNumber = _advancePage.PhoneTextField.GetAttribute("value");
            Assert.IsEmpty(phoneNumber, "Phone number is not blank");
        }

        [When(@"user enters valid Username")]
        public void WhenUserEntersValidUsername()
        {
            RandomUsername = GetMethods.GenerateRandomUsername(15);
            _advancePage.UserNameTextBoxOnCreatePage.EnterText(RandomUsername);
        }

        [When(@"enters valid Full name")]
        public void WhenEntersValidFullName()
        {
            RandomFullName = GetMethods.GenerateRandomString(15);
            _advancePage.FullNameOnCreatePage.EnterText(RandomFullName);
        }
      
        [When(@"unchecks User Manager checkbox")]
        public void WhenUnchecksUserManagerCheckbox()
        {
            bool IsCheckboxSelected = _advancePage.UserManagerOnCreatePage.Selected;

            if (IsCheckboxSelected == true)
            {                
                _advancePage.UserManagerOnCreatePage.JavaSciptClick();
                //Role = AdvancedPage.ExpectedValues.UserRoleRegularOnUserListPage;
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
            bool IsPhoneNumberErrorMessageDisplayed = _advancePage.PhoneErrorMessageOnAddUserPage.GetElementVisibility();
            Assert.IsTrue(IsPhoneNumberErrorMessageDisplayed, "Phone number error message is not displayed");
        }

        [When(@"user enters valid email address, Name, Phone")]
        public void WhenUserEntersValidEmailAddressNamePhone()
        {
            //Entering valid user name
            RandomUsername = GetMethods.GenerateRandomUsername(15);
            _advancePage.UserNameTextBoxOnCreatePage.EnterText(RandomUsername);
            UserInputInvalidUserName = RandomUsername;

            //Entering valid Full name
            RandomFullName = GetMethods.GenerateRandomString(15);
            _advancePage.FullNameOnCreatePage.EnterText(RandomFullName);
            UserInputFullname = RandomFullName;

            //Entering valid phone number
            string RandomNumber4Digits = GetMethods.GenerateNDigitRandomNumber(4);
            string Prefix = "+1315685";
            RandomPhoneNumber = Prefix + RandomNumber4Digits;
            _advancePage.PhoneNumberOnCreatePage.EnterText(RandomPhoneNumber);
        }
    }
}
