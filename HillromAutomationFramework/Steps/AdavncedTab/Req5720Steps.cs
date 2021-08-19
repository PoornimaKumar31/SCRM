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
    [Binding, Scope(Tag = "SoftwareRequirementID_5720")]
    public class Req5720Steps
    {      
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        AdvancedPage advancePage = new AdvancedPage();
        string RandomString;
        string RandomUsername = null;
        string RandomMobileNumber;
        string FullnameRandom = null;
        string ActualUserName = null;
        string ActualFullName = null;
        string ActualRole = null;
        string UserInputInvalidUserName = null;
        string UserInputFullname = null;

        private readonly ScenarioContext _scenarioContext;
        readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

        public Req5720Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"manager user is on User List page")]
        public void GivenManagerUserIsOnUserListPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            //Clicking on facility
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            advancePage.AdvancedTab.JavaSciptClick();
        }

        [When(@"user clicks Create button")]
        public void WhenUserClicksCreateButton()
        {
            Thread.Sleep(1000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)PropertyClass.Driver;
            js.ExecuteScript("window.scrollTo(0, 0)");
            advancePage.CreateUserOnCreatePage.Click();
        }

        [Then(@"Add User page is displayed")]
        public void ThenAddUserPageIsDisplayed()
        {
            string AddUserTitle = advancePage.AddUserOnCreatePage.Text;
            Assert.AreEqual(AdvancedPage.ExpectedValues.AddUserListPageText, AddUserTitle, "Add User page is not displayed");
        }

        [Then(@"User information label is displayed")]
        public void ThenUserInformationLabelIsDisplayed()
        {
            string UserInformationLabel = advancePage.UserInformationLabel.Text;
            Assert.AreEqual("User Information:", UserInformationLabel, "User information label is not displayed");
        }

        [Then(@"Username textbox is displayed")]
        public void ThenUsernameTextboxIsDisplayed()
        {
            bool IsDisplayed = advancePage.UserNameTextBoxOnCreatePage.GetElementVisibility();
            Assert.IsTrue(IsDisplayed, "Username textbox is not displayed");
        }

        [Then(@"unchecked checkbox with User manager label is displayed")]
        public void ThenUncheckedCheckboxWithUserManagerLabelIsDisplayed()
        {
            Thread.Sleep(2000);
            bool IsUnchecked = advancePage.UserManagerOnCreatePage.Selected;
            Assert.IsFalse(IsUnchecked, "Unchecked checkbox with User manager label is not displayed");
        }

        [Then(@"Full name textbox is displayed")]
        public void ThenFullNameTextboxIsDisplayed()
        {
            bool IsDisplayed = advancePage.FullNameOnCreatePage.GetElementVisibility();
            Assert.IsTrue(IsDisplayed, "Full Name textbox is not displayed");
        }

        [Then(@"Phone number textbox is displayed")]
        public void ThenPhoneNumberTextboxIsDisplayed()
        {
            bool IsDisplayed = advancePage.PhoneNumberOnCreatePage.GetElementVisibility();
            Assert.IsTrue(IsDisplayed, "Phone number textbox is not displayed");
        }

        [Then(@"disabled Save button is displayed")]
        public void ThenDisabledSaveButtonIsDisplayed()
        {
            bool IsDisabled = advancePage.SaveButtonOnCreatePage.Enabled;
            bool IsSaveButtonVisibility = advancePage.SaveButtonOnCreatePage.GetElementVisibility();
            Assert.IsFalse(IsDisabled, "Save button is not disabled");
            Assert.IsTrue(IsSaveButtonVisibility, "Save button is not displayed");
        }

        [Then(@"enabled Cancel button is displayed")]
        public void ThenEnabledCancelButtonIsDisplayed()
        {
            bool IsEnabled = advancePage.CancelButtonOnCreatePage.Enabled;
            Assert.IsTrue(IsEnabled, "Cancel button is not enabled");
        }

        [Given(@"manager user is on Add User page")]
        public void GivenManagerUserIsOnAddUserPage()
        {
            GivenManagerUserIsOnUserListPage();
            advancePage.CreateUserOnCreatePage.Click();
        }

        [When(@"user enters Full name ""(.*)""")]
        public void WhenUserEntersFullNam(string FullName)
        {
            UserInputFullname = FullName;
            advancePage.FullNameOnCreatePage.EnterText(FullName);
        }

        [When(@"clicks Username textbox")]
        public void WhenClicksUsernameTextbox()
        {
            advancePage.UserNameTextBoxOnCreatePage.Click();
        }

        [When(@"enters valid Username ""(.*)""")]
        public void WhenEntersValidUsername(string ValidUserName)
        {
            advancePage.UserNameTextBoxOnCreatePage.EnterText(ValidUserName);
        }


        [When(@"presses Tab key")]
        public void WhenPressesTabKey()
        {
            advancePage.UserNameTextBoxOnCreatePage.EnterText(Keys.Tab);
        }

        [Then(@"no username error message is displayed")]
        public void ThenNoUsernameErrorMessageIsDisplayed()
        {
            bool IsDisplayed = advancePage.UserNameErrorMessageOnCreatePage.GetElementVisibility();
            Assert.IsFalse(IsDisplayed, "Username error message is displayed");
        }

        [Then(@"enabled Save button is displayed")]
        public void ThenEnabledSaveButtonIsDisplayed()
        {
            bool IsSaveButtonEnabled = advancePage.SaveButtonOnCreatePage.Enabled;
            Assert.IsTrue(IsSaveButtonEnabled);
        }

        [Then(@"username error message is displayed")]
        public void ThenUsernameErrorMessageIsDisplayed()
        {
            Thread.Sleep(1000);
            bool IsDisplayed = advancePage.UserNameErrorMessageOnCreatePage.GetElementVisibility();
            Assert.IsTrue(IsDisplayed, "Username error message is not displayed");
        }

        [When(@"user enters invalid Username ""(.*)""")]
        public void WhenUserEntersInvalidUsername(string InvalidUserName)
        {
            UserInputInvalidUserName = InvalidUserName;
            advancePage.UserNameTextBoxOnCreatePage.EnterText(UserInputInvalidUserName);
        }

        [When(@"user clicks Cancel button")]
        public void WhenUserClicksCancelButton()
        {
            advancePage.CancelButtonOnCreatePage.Click();
        }

        [Then(@"User List page is displayed")]
        public void ThenUserListPageIsDisplayed()
        {
            Thread.Sleep(3000);
            string UserListLabelText = advancePage.UserListPage.Text;
            Assert.AreEqual(AdvancedPage.ExpectedValues.UserListPageLabelText, UserListLabelText, "User list page is not displayed");
        }

        [Then(@"no user is created")]
        public void ThenNoUserIsCreated()
        {
            Thread.Sleep(3000);
            bool matches = false;
            string[] tableContent = advancePage.TableContent.Text.Split();
            for (int i = 0; i < tableContent.Length; i++)
            {
                if (tableContent[i] == UserInputFullname)
                {
                    string ActualUserName = tableContent[i + 4];
                    if (ActualUserName == UserInputInvalidUserName)
                    {
                        matches = true;
                    }
                }
            }
            Assert.IsFalse(matches, "New user is created");
        }

        [Given(@"manager user is on User Management page")]
        public void GivenManagerUserIsOnUserManagementPage()
        {
            Thread.Sleep(2000);
            bool IsUserManagementVisible = advancePage.UserManagement.GetElementVisibility();
            Assert.IsTrue(IsUserManagementVisible, "Manager user is not on User Management page");
        }

        [When(@"user enters Username ""(.*)""")]
        public void WhenUserEntersUsername(string UserName)
        {
            UserInputInvalidUserName = UserName;
            advancePage.UserNameTextBoxOnCreatePage.EnterText(UserName);
        }

        [When(@"clicks Full name textbox")]
        public void WhenClicksFullNameTextbox()
        {
            advancePage.FullNameOnCreatePage.Click();
        }

        [When(@"enters (.*)-character Full name")]
        public void WhenEnters_CharacterFullName(int stringSize)
        {
            string FullName = GetMethods.GenerateRandomString(stringSize);
            UserInputFullname = FullName;
            advancePage.FullNameOnCreatePage.EnterText(FullName);
        }

        [Then(@"no name error message is displayed")]
        public void ThenNoNameErrorMessageIsDisplayed()
        {
            bool IsNameErrorMessageDisplayed = advancePage.FullNameErrorMessageOnCreatePage.GetElementVisibility();
            Assert.IsFalse(IsNameErrorMessageDisplayed, "Name error message is displayed");
        }

        [Then(@"name error message is displayed")]
        public void ThenNameErrorMessageIsDisplayed()
        {
            Thread.Sleep(2000);
            bool IsNameErrorMessageDisplayed = advancePage.FullNameErrorMessageOnCreatePage.GetElementVisibility();
            Assert.IsTrue(IsNameErrorMessageDisplayed, "Name error message is not displayed");
        }

        [When(@"enters (.*)-character valid Full name")]
        public void WhenEnters_CharacterValidFullName(int stringSize)
        {
            //Passing the length of string to the method and generating random string and that string is used as a Full name.
            RandomString = GetMethods.GenerateRandomString(stringSize);
            advancePage.FullNameOnCreatePage.EnterText(RandomString);
        }

        [When(@"enters Phone number ""(.*)""")]
        public void WhenEntersPhoneNumber(string phoneNumber)
        {
            RandomMobileNumber = phoneNumber;
            advancePage.PhoneNumberOnCreatePage.EnterText(phoneNumber);
        }

        [When(@"clicks User Manager checkbox")]
        public void WhenClicksUserManagerCheckbox()
        {
            advancePage.UserManagerOnCreatePage.JavaSciptClick();
        }

        [When(@"clicks Save")]
        public void WhenClicksSave()
        {
            SetMethods.ScrollToBottomofWebpage();
            Thread.Sleep(1000);
            advancePage.SaveButtonOnCreatePage.Click();
        }

        [Then(@"new user is created")]
        public void ThenNewUserIsCreated()
        {
            //Fetching all table data and then splits to put all data on index so that I can fetch required data form the index. Once data will be matched in search criteria.
            string[] tableContent = advancePage.TableContent.Text.Split();
            Thread.Sleep(2000);
            for (int i = 0; i < tableContent.Length; i++)
            {
                if (tableContent[i] == FullnameRandom)
                {
                    ActualFullName = tableContent[i];
                    ActualRole = tableContent[i + 2];
                    ActualUserName = tableContent[i + 4];
                    break;
                }
            }
            Assert.AreEqual(true, RandomUsername == ActualUserName, "New user is not created");
        }

        [Then(@"new user role is Administrator")]
        public void ThenNewUserRoleIsAdministrator()
        {
            Assert.AreEqual(true, "Administrator" == ActualRole, "Username is not displayed");
        }

        [Then(@"Username, Name, and Phone number match")]
        public void ThenUsernameNameAndPhoneNumberMatch()
        {
            //Username and Full name matching from the User List Page
            Assert.AreEqual(true, RandomUsername == ActualUserName, "Username does not match");
            Assert.AreEqual(true, FullnameRandom == ActualFullName, "Name does not match");

            //To match Phone number, need to click on Details button then I will get Phone number. So passing ActualUserName through method to find in table content and then Click on corresponding Details button.
            advancePage.ClickOnDetailsButtonOfSpecifiedUser(RandomUsername);
            
            //Getting Phone number after clicking on Details button
            string ActualPhoneNumber = advancePage.PhoneTextField.GetAttribute("value");
            Assert.AreEqual(true, ActualPhoneNumber == RandomMobileNumber, "Phone does not match");
        }

        [When(@"does not click User Manager checkbox")]
        public void WhenDoesNotClickUserManagerCheckbox()
        {
            bool IsCheckboxSelected = advancePage.UserManagerCheckBox.Selected;
            Assert.IsTrue(IsCheckboxSelected, "Click User Manager checkbox");
        }

        [Then(@"new user role is Regular")]
        public void ThenNewUserRoleIsRegular()
        {
            //Fetching all table data and then splits to put all data on index so that I can fetch required data form the index. Once data will be matched in search criteria.
            string[] tableContent = advancePage.TableContent.Text.Split();
            Thread.Sleep(2000);
            for (int i = 0; i < tableContent.Length; i++)
            {
                if (tableContent[i] == FullnameRandom)
                {
                    ActualFullName = tableContent[i];
                    ActualRole = tableContent[i + 2];
                    ActualUserName = tableContent[i + 4];                   
                    break;
                }
            }
            Assert.AreEqual(true, AdvancedPage.ExpectedValues.UserRoleRegularOnUserListPage == ActualRole, "New user role is not Regula");
        }

        [Then(@"Username and Name match")]
        public void ThenUsernameAndNameMatch()
        {
            Assert.AreEqual(true, FullnameRandom == ActualFullName, "Name is not miss match");
            Assert.AreEqual(true, RandomUsername == ActualUserName, "Username is not miss match");
        }

        [Then(@"Phone number is blank")]
        public void ThenPhoneNumberIsBlank()
        {
            advancePage.ClickOnDetailsButtonOfSpecifiedUser(ActualUserName);
            string phoneNumber = advancePage.PhoneTextField.GetAttribute("value");
            Assert.IsEmpty(phoneNumber, "Phone number is not blank");
        }

        [When(@"user enters valid Username")]
        public void WhenUserEntersValidUsername()
        {
            RandomUsername = GetMethods.GenerateRandomUsername(15);
            advancePage.UserNameTextBoxOnCreatePage.EnterText(RandomUsername);
        }

        [When(@"enters valid Full name")]
        public void WhenEntersValidFullName()
        {
            FullnameRandom = GetMethods.GenerateRandomString(15);
            advancePage.FullNameOnCreatePage.EnterText(FullnameRandom);
        }
      
        [When(@"unchecks User Manager checkbox")]
        public void WhenUnchecksUserManagerCheckbox()
        {
            bool IsCheckboxSelected = advancePage.UserManagerOnCreatePage.Selected;
            if (IsCheckboxSelected == true)
            {
                advancePage.UserManagerOnCreatePage.JavaSciptClick();
            }
        }

        [When(@"user enters Phone number ""(.*)""")]
        public void WhenUserEntersPhoneNumber(string PhoneNumber)
        {

            advancePage.PhoneNumberOnCreatePage.EnterText(PhoneNumber);
        }

        [Then(@"phone number error message is displayed")]
        public void ThenPhoneNumberErrorMessageIsDisplayed()
        {
            bool IsPhoneNumberErrorMessageDisplayed = advancePage.PhoneErrorMessageOnAddUserPage.GetElementVisibility();
            Assert.IsTrue(IsPhoneNumberErrorMessageDisplayed, "Phone number error message is not displayed");
        }

        [When(@"user enters valid email address, Name, Phone")]
        public void WhenUserEntersValidEmailAddressNamePhone()
        {
            //Entering valid user name
            RandomUsername = GetMethods.GenerateRandomUsername(15);
            advancePage.UserNameTextBoxOnCreatePage.EnterText(RandomUsername);
            UserInputInvalidUserName = RandomUsername;

            //Entering valid Full name
            FullnameRandom = GetMethods.GenerateRandomString(15);
            advancePage.FullNameOnCreatePage.EnterText(FullnameRandom);
            UserInputFullname = FullnameRandom;

            //Entering valid phone number
            RandomMobileNumber = GetMethods.GenerateRandomPhoneNumber(1000000000);
            advancePage.PhoneNumberOnCreatePage.EnterText(RandomMobileNumber);
        }
    }
}
