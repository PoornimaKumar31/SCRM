using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using SeleniumExtras.PageObjects;
using System.Linq;
using System.Threading;

namespace HillromAutomationFramework.Coding.PageObjects.AdvancedTab
{
    class AdvancedPage
    {
        public AdvancedPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        public static class Locators
        {
            public const string AdvancedID = "advancedTab";
            public const string DetailsButtonID = "btn_edit";
            public const string DeleteButtonID = "btn_delete";
            public const string CancelButtonID = "edit-Cancel";
            public const string SaveButton = "button_selected";
            public const string UserNameOREmailFieldID = "username";
            public const string FullNameID = "name";
            public const string PhoneID = "phone";
            public const string UserManagerCheckBoxID = "role-input";
            public const string RoleInputID = "role";
            public const string RoleCheckBoxClass = "mat-checkbox-frame";
            public const string UserManagementID = "tab_users";
            public const string UserListClass = "col-xs-12 manage-users-list ng-star-inserted";
            public const string EditUserLabelID = "lbl_edit";
            public const string UserManagerLabelClassName = "mat-checkbox-label";
            public const string LogHistoryID = "lbl_history";
            public const string DateColumnHeaderID = "lbl_date";
            public const string DetailsColumnHeaderID = "lbl_details";
            public const string SaveButtonID = "edit-selected";
            public const string NameFieldErrorMessageID = "name_error";
            public const string AddedManagerDetailsXPath = "//*[@id=\"usrmgt_list\"]/div/div[2]/div/div[2]/div[1]";
            public const string UserName_UpdatedXpath = "//*[@id=\"usrmgt_list\"]/div/div[2]/div/div[2]/div[2]/div[1]";
            public const string UserName2ndRow1stColumnXPath = "//*[@id=\"usrmgt_list\"]/div/div[2]/div/div[2]/div[2]/div[1]";
            public const string UserRole2ndRow2ndColumnXPath = "//*[@id=\"usrmgt_list\"]/div/div[2]/div/div[2]/div[2]/div[2]";
            public const string Username2ndRow3rdColumnXPath = "//*[@id=\"usrmgt_list\"]/div/div[2]/div/div[2]/div[2]/div[3]";
            public const string TableContentXPath = "//*[@id=\"usrmgt_list\"]/div/div[2]/div/div[2]";
            public const string UserListClassName = "hrtitle";
            public const string PhoneErrorID = "phone_error";
            public const string LogHistoryClass = "col-xs-6";
            public const string FullNameLabelOnEditUserPageXPath = "(//*[contains(text(),'Full name')])[2]";
            public const string PhoneNumberLabelOnEditUserPageXPath = "//*[contains(text(),'Phone number')]";


            //User Create
            public const string CreateUserOnCreatePageID = "btn_add";
            public const string SaveButtonOnCreatePageID = "create-save";
            public const string CancelButtonOnCreatePageID = "create-Cancel";
            public const string AddUserOnCreatePageID = "lbl_add_user";
            public const string UserInformationLabelID = "usrmgt_create_edit_title";
            public const string PhoneErrorMessageOnAddUserPageXPath = "//*[contains(text(),' Please enter a valid phone number')]";

            public const string UserNameTextBoxOnCreatePageID = "create-username";
            public const string FullNameOnCreatePageID = "create-name";
            public const string PhoneNumberOnCreatePageID = "create-phone";
            public const string UserManagerOnCreatePageID = "create-role-input";
            public const string UserNameErrorMessageOnCreatePageID = "invalid_email";
            public const string FullNameErrorMessageOnCreatePageXPath = "//*[contains(text(),'Please enter a valid name')]";

            //Table Elements
            public const string TableFirstRowDataID = "user_row0";
            public const string TableFirstRowDetailsButtonXpath = "(//*[@id=\"btn_edit\"])[1]";
            public const string FullnameLabelOnUserListID = "full_name";
            public const string RoleLabelOnUserListID = "role";
            public const string EmailLabelOnUserListID = "email";
            public const string UserListTableHeaderXPath = "//*[@id=\"usrmgt_list\"]/div/div[2]/div/div[1]";

            //Log History table data
            public const string LogHistoryTableDataXPath = "//*[@id=\"lbl_history_detail\"]/div[2]/div[2]";
            public const string LogHistoryContentXPath = "//*[@id=\"lbl_history_detail\"]//div[2]//div[1]";
            public const string EmailFieldOnUserListPageXPath = "//*[@id=\"email\"]";
        }

        /// <summary>
        /// Expected values of the Advance Page
        /// </summary>
        public static class ExpectedValues
        {
            public const string EditUserPageLabelText = "EDIT USER";
            public const string UserListPageLabelText = "USER LIST";
            public const string AddUserListPageText = "ADD USER";
            public const string UserManagementLabelTextOnEditUserPage = "User Management";
            public const string UserRoleAdministratorOnUserListPage = "Administrator";
            public const string UserRoleRegularOnUserListPage = "Regular";
            public const string PhoneNumberErrorMessage = "Please enter a valid phone number";
            public const string FullNameErrorMessage = "Please enter a valid name";
            public const string UpdatedFullName = "Alex Hasi";
            public const string PhoneNumberInvalid = "123";
            public const string LoggedUser = "ltts_testing@hillrom.com";
        }

        [FindsBy(How = How.XPath, Using = Locators.PhoneErrorMessageOnAddUserPageXPath)]
        public IWebElement PhoneErrorMessageOnAddUserPage { get; set; }


        [FindsBy(How = How.Id, Using = Locators.DeleteButtonID)]
        public IList<IWebElement> DeleteButtons { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.UserListTableHeaderXPath)]
        public IWebElement UserListTableHeader { get; set; }

        [FindsBy(How = How.Id, Using = Locators.FullnameLabelOnUserListID)]
        public IWebElement FullnameLabelOnUserList { get; set; }

        [FindsBy(How = How.Id, Using = Locators.RoleLabelOnUserListID)]
        public IWebElement RoleLabelOnUserList { get; set; }

        [FindsBy(How = How.Id, Using = Locators.EmailLabelOnUserListID)]
        public IWebElement EmailLabelOnUserList { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.EmailFieldOnUserListPageXPath)]
        public IList<IWebElement> EmailFieldOnUserListPageXPath { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.LogHistoryContentXPath)]
        public IList<IWebElement> LogHistoryContent { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.LogHistoryTableDataXPath)]
        public IWebElement LogHistoryTableData { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.TableFirstRowDetailsButtonXpath)]
        public IWebElement TableFirstRowDetailsButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.TableFirstRowDataID)]
        public IWebElement TableFirstRowData { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.TableContentXPath)]
        public IWebElement TableContent { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.Username2ndRow3rdColumnXPath)]
        public IWebElement Username2ndRow3rdColumn { get; set; }

        [FindsBy(How = How.Id, Using = Locators.UserNameErrorMessageOnCreatePageID)]
        public IWebElement UserNameErrorMessageOnCreatePage { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.FullNameErrorMessageOnCreatePageXPath)]
        public IWebElement FullNameErrorMessageOnCreatePage { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.PhoneNumberLabelOnEditUserPageXPath)]
        public IWebElement PhoneNumberLabelOnEditUserPage { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.FullNameLabelOnEditUserPageXPath)]
        public IWebElement FullNameLabelOnEditUserPage { get; set; }

        [FindsBy(How = How.Id, Using = Locators.UserNameTextBoxOnCreatePageID)]
        public IWebElement UserNameTextBoxOnCreatePage { get; set; }

        [FindsBy(How = How.Id, Using = Locators.FullNameOnCreatePageID)]
        public IWebElement FullNameOnCreatePage { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PhoneNumberOnCreatePageID)]
        public IWebElement PhoneNumberOnCreatePage { get; set; }

        [FindsBy(How = How.Id, Using = Locators.UserManagerOnCreatePageID)]
        public IWebElement UserManagerOnCreatePage { get; set; }

        [FindsBy(How = How.Id, Using = Locators.UserInformationLabelID)]
        public IWebElement UserInformationLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CreateUserOnCreatePageID)]
        public IWebElement CreateUserOnCreatePage { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SaveButtonOnCreatePageID)]
        public IWebElement SaveButtonOnCreatePage { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CancelButtonOnCreatePageID)]
        public IWebElement CancelButtonOnCreatePage { get; set; }

        [FindsBy(How = How.Id, Using = Locators.AddUserOnCreatePageID)]
        public IWebElement AddUserOnCreatePage { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.LogHistoryClass)]
        public IList<IWebElement> LogHistoryRecords { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.UserRole2ndRow2ndColumnXPath)]
        public IWebElement UserRole2ndRow2ndColumn { get; set; }


        [FindsBy(How = How.ClassName, Using = Locators.RoleCheckBoxClass)]
        public IWebElement RoleCheckBox { get; set; }

        [FindsBy(How = How.Id, Using = Locators.RoleInputID)]
        public IWebElement RoleInput { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PhoneErrorID)]
        public IWebElement PhoneErrorMessage { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.UserListClassName)]
        public IWebElement UserListPage { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.UserName2ndRow1stColumnXPath)]
        public IWebElement UserName2ndRow1stColumn { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.UserName_UpdatedXpath)]
        public IWebElement UserName_Updated { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.AddedManagerDetailsXPath)]
        public IWebElement AddedManagerDetailsXP { get; set; }

        [FindsBy(How = How.Id, Using = Locators.NameFieldErrorMessageID)]
        public IWebElement NameFieldErrorMessage { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PhoneID)]
        public IWebElement PhoneTextField { get; set; }

        [FindsBy(How = How.Id, Using = Locators.SaveButtonID)]
        public IWebElement SaveButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.CancelButtonID)]
        public IWebElement CancelButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DetailsColumnHeaderID)]
        public IWebElement DetailsColumnHeader { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DateColumnHeaderID)]
        public IWebElement DateColumnHeader { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LogHistoryID)]
        public IWebElement LogHistory { get; set; }

        [FindsBy(How = How.Id, Using = Locators.UserManagerCheckBoxID)]
        public IWebElement UserManagerCheckBox { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.UserManagerLabelClassName)]
        public IWebElement UserManagerLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.FullNameID)]
        public IWebElement FullName { get; set; }

        [FindsBy(How = How.Id, Using = Locators.UserNameOREmailFieldID)]
        public IWebElement UserNameOREmailField { get; set; }

        [FindsBy(How = How.Id, Using = Locators.UserManagementID)]
        public IWebElement UserManagement { get; set; }

        [FindsBy(How = How.Id, Using = Locators.EditUserLabelID)]
        public IWebElement EditUserLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.AdvancedID)]
        public IWebElement AdvancedTab { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DetailsButtonID)]
        public IList<IWebElement> DetailsButton { get; set; }

        public string RandomFullNameLessThan50_49char { get; private set; }
        public string RandomPhoneNumber10_10Digits { get; private set; }


        public int UserClicksDetailsButtonForOtherUserRecord()
        {
            int DetailsButtonCount;
            int NoOfDetailsButton = DetailsButton.Count;
            for (DetailsButtonCount = 0; DetailsButtonCount < NoOfDetailsButton; DetailsButtonCount++)
            {
                string userNameXPath = "//*[@id=\"email" + DetailsButtonCount + "\"]";
                string userName = PropertyClass.Driver.FindElement(By.XPath(userNameXPath)).Text;
                if (userName != AdvancedPage.ExpectedValues.LoggedUser)
                {
                    DetailsButton[DetailsButtonCount].Click();
                    break;
                }
            }
            return DetailsButtonCount;
        }

        /// <summary>
        ///  Updating Full name, Phone number and Role
        /// </summary>
        public void UserChangesFullNameNumberAndRole()
        {
            Thread.Sleep(2000);
            RandomFullNameLessThan50_49char = GetMethods.GenerateRandomString(49);
            RandomPhoneNumber10_10Digits = GetMethods.GenerateRandomMobileNumber(1000000000);

            FullName.Clear();
            FullName.EnterText(RandomFullNameLessThan50_49char);
            PhoneTextField.Clear();
            PhoneTextField.EnterText(RandomPhoneNumber10_10Digits);
            Thread.Sleep(3000);
            UserManagerCheckBox.JavaSciptClick();
        }
        public int ManagerUserIsOnEditUserPageWithLogEntriesGreaterThanTwo(int DetailsButtonCount)
        {
            //Finding number of enteries in the table.
            int NoOfDetailsButton = DetailsButton.Count;
            string[] LogHistory = { };
            for (DetailsButtonCount = 0; DetailsButtonCount < NoOfDetailsButton; DetailsButtonCount++)
            {
                PropertyClass.Driver.FindElement(By.XPath("(//*[@id=\"btn_edit\"])[" + (DetailsButtonCount + 1) + "]")).Click();
                Thread.Sleep(2000);
                LogHistory = LogHistoryTableData.Text.Split();
                int count = LogHistory.Length;
                if (count > 20)
                {
                    break;
                }
                else
                {
                    CancelButton.Click();
                }
            }
            if (LogHistory.Length == 0)
            {
                Assert.IsTrue(LogHistory.Length == 0, "No any user is present which has History Logs.");
            }
            bool boo = LogHistory.Length == 0;
            return DetailsButtonCount;
        }

        
        public List<DateTime> LogHistoryTableIsSortedByDescendingDateSortOrder()
        {
            var list = new List<string>();
            var DateTimeList = new List<DateTime>();
            string[] LogHistory = LogHistoryTableData.Text.Split();
            Thread.Sleep(2000);
            int LogHistoryCount = LogHistoryContent.Count;
            //Getting all the dated from the Logs and putting in a list in first loop as a string
            for (int i = 3; i < LogHistoryCount; i++)
            {
                list.Add(LogHistoryContent[i].Text);
            }

            //Converting list text into DateTime format
            for (int i = 0; i < list.Count; i++)
            {
                DateTimeList.Add(DateTime.Parse(list[i]));
            }
            return DateTimeList;
        }

        public bool IsEmailSorted()
        {
            bool IsEmailIdDescending = false;
            var list = new List<string>();
            //var Elements = new Dictionary<string, string>();
            int NoOfDetailsButton = DetailsButton.Count;
            for (int i = 0; i < NoOfDetailsButton; i++)
            {
                string userNameXPath = "//*[@id=\"email" + i + "\"]";
                string userName = PropertyClass.Driver.FindElement(By.XPath(userNameXPath)).Text;
                list.Add(userName);
            }

            //Checking eailId is in ascending order
            var orderedByAsc = list.OrderBy(d => d);
            if (list.SequenceEqual(orderedByAsc))
            {
                IsEmailIdDescending = true;
            }

            //Checking eailId is in descending order
            var orderedByDsc = list.OrderByDescending(d => d);
            if (list.SequenceEqual(orderedByDsc))
            {
                IsEmailIdDescending = true;
            }
            return IsEmailIdDescending;
        }
        public int UserClicksDetailsButtonForUserWithAPhoneNumber()
        {
            int DetailsButtonCount;
            int NoOfDetailsButton = DetailsButton.Count;
            for (DetailsButtonCount = 0; DetailsButtonCount < NoOfDetailsButton; DetailsButtonCount++)
            {
                DetailsButton[DetailsButtonCount].Click();
                string phone = PhoneTextField.GetAttribute("value");
                if (phone == "")
                {
                    CancelButton.Click();
                }
                else
                {
                    return DetailsButtonCount;
                }
            }
            return -1;
        }

        public Dictionary<string, string> UserClicksDetailsButtonForUserWithAdministratorRole(int DetailsButtonCount, string RoleXpath)
        {
            var Elements = new Dictionary<string, string>();
            int NoOfDetailsButton = DetailsButton.Count;
            for (DetailsButtonCount = 0; DetailsButtonCount < NoOfDetailsButton; DetailsButtonCount++)
            {
                string userNameXPath = "//*[@id=\"email" + DetailsButtonCount + "\"]";
                string userName = PropertyClass.Driver.FindElement(By.XPath(userNameXPath)).Text;
                if (userName != AdvancedPage.ExpectedValues.LoggedUser)
                {
                    RoleXpath = "//*[@id=\"role" + DetailsButtonCount + "\"]";
                    string Role = PropertyClass.Driver.FindElement(By.XPath(RoleXpath)).Text;
                    if (Role == AdvancedPage.ExpectedValues.UserRoleAdministratorOnUserListPage)
                    {
                        DetailsButton[DetailsButtonCount].Click();
                        break;
                    }
                }
            }

            Elements.Add(RoleXpath, DetailsButtonCount.ToString());
            return Elements;
        }

        public string UpdatedFullNameIsDisplayedOnTheUserList(string RandomFullNameLessThan50_49char)
        {
            Thread.Sleep(2000);
            string ActualFullName = "";
            string[] tableContent = TableContent.Text.Split();
            for (int i = 0; i < tableContent.Length; i++)
            {
                if (tableContent[i] == RandomFullNameLessThan50_49char)
                {
                    ActualFullName = tableContent[i];
                    break;
                }
            }
            return ActualFullName;
        }

        public string RegularIsDisplayedInRoleColumn()
        {
            string ActualRole = "";
            string[] tableContent = TableContent.Text.Split();
            for (int i = 0; i < tableContent.Length; i++)
            {
                if (tableContent[i] == RandomFullNameLessThan50_49char)
                {
                    ActualRole = tableContent[i + 2];
                    break;
                }
            }
            return ActualRole;
        }

        public Dictionary<string, string> FullnamePhoneNumberAndRoleAreNotChangedOnUserListPage(int DetailsButtonCount)
        {
            var Elements = new Dictionary<string, string>();
            DetailsButton[DetailsButtonCount].Click();
            string UpdatedFullName = FullName.GetAttribute("value");
            string UpdatedPhoneNumber = PhoneTextField.GetAttribute("value");
            string UpdatedUserName = UserNameOREmailField.GetAttribute("value");
            bool UpdatedRole = RoleInput.Selected;

            Elements.Add("1", UpdatedFullName);
            Elements.Add("2", UpdatedPhoneNumber);
            Elements.Add("3", UpdatedRole.ToString());
            Elements.Add("4", UpdatedUserName);
            return Elements;
        }

        public bool NoUserIsCreated(string UserInputFullname, string UserInputInvalidUserName)
        {
            string[] tableContent = TableContent.Text.Split();
            for (int i = 0; i < tableContent.Length; i++)
            {
                if (tableContent[i] == UserInputFullname)
                {
                    string ActualUserName = tableContent[i + 4];
                    if (ActualUserName == UserInputInvalidUserName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void UsernameNameAndPhoneNumberMatch(string ActualUserName)
        {
            int DetailsButtonCount;
            int NoOfDetailsButton = DetailsButton.Count;
            for (DetailsButtonCount = 0; DetailsButtonCount < NoOfDetailsButton; DetailsButtonCount++)
            {
                string userNameXPath = "//*[@id=\"email" + DetailsButtonCount + "\"]";
                string userName = PropertyClass.Driver.FindElement(By.XPath(userNameXPath)).Text;
                if (userName == ActualUserName)
                {
                    DetailsButton[DetailsButtonCount].Click();
                    break;
                }
            }
        }

        public bool NewlyAddedManagerUserIsDisplayed(string RandomUserFullname, string RandomUserName)
        {
            bool IsUserCreated = false;
            string[] tableContent = TableContent.Text.Split();
            for (int i = 0; i < tableContent.Length; i++)
            {
                if (tableContent[i] == RandomUserFullname)
                {
                    string ActualUserName = tableContent[i + 4];
                    if (ActualUserName == RandomUserName)
                    {
                        IsUserCreated = true;
                    }
                    else
                    {
                        IsUserCreated = false;
                    }
                }
            }
            return IsUserCreated;
        }

        public int DeleteButtonIsDisplayedAndEnabledForOtherThanLoggedInUserForAllRows()
        {
            int NoOfDeleteButtons = DeleteButtons.Count;
            bool IsVisibleAndEnable = false;
            bool IsEnabled = false;
            int count = 0;
            for (int i = 0; i < NoOfDeleteButtons; i++)
            {
                string userNameXPath = "//*[@id=\"email" + i + "\"]";
                string userName = PropertyClass.Driver.FindElement(By.XPath(userNameXPath)).Text;
                if (userName != "ltts_testing@hillrom.com")
                {
                    IsVisibleAndEnable = DeleteButtons[i].GetElementVisibility();
                    IsEnabled = DeleteButtons[i].Enabled;
                    if (IsVisibleAndEnable == IsEnabled)
                    {

                    }
                    else
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
