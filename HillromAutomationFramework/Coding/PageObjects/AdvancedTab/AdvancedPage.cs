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
        AdvancedTabUserListPage advancedTabUserListPage = new AdvancedTabUserListPage();
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
            public const string UserManagementID = "tab_users";
            public const string UserListClass = "col-xs-12 manage-users-list ng-star-inserted";
            public const string EditUserLabelID = "lbl_edit";
            public const string UserManagerLabelClassName = "mat-checkbox-label";
            public const string LogHistoryID = "lbl_history";
            public const string DateColumnHeaderID = "lbl_date";
            public const string DetailsColumnHeaderID = "lbl_details";
            public const string SaveButtonID = "edit-selected";
            public const string NameFieldErrorMessageID = "name_error";
            public const string TableContentXPath = "//*[@id=\"usrmgt_list\"]/div/div[2]/div/div[2]";
            public const string UserListClassName = "hrtitle";
            public const string PhoneErrorID = "phone_error";
            public const string FullNameLabelOnEditUserPageXPath = "(//*[contains(text(),'Full name')])[2]";

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
            public const string FullnameLabelOnUserListID = "full_name";
            public const string UserListTableHeaderXPath = "//*[@id=\"usrmgt_list\"]/div/div[2]/div/div[1]";

            //Log History table data
            public const string LogHistoryTableDataXPath = "//*[@id=\"lbl_history_detail\"]/div[2]/div[2]";
            public const string LogHistoryContentXPath = "//*[@id=\"lbl_history_detail\"]//div[2]//div[1]";
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
            public const string LoggedUser = "ltts_testing@hillrom.com";
        }

        [FindsBy(How = How.XPath, Using = Locators.PhoneErrorMessageOnAddUserPageXPath)]
        public IWebElement PhoneErrorMessageOnAddUserPage { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeleteButtonID)]
        public IList<IWebElement> DeleteButtonsList { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.UserListTableHeaderXPath)]
        public IWebElement UserListTableHeader { get; set; }

        [FindsBy(How = How.Id, Using = Locators.FullnameLabelOnUserListID)]
        public IWebElement FullnameLabelOnUserList { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.LogHistoryContentXPath)]
        public IList<IWebElement> LogHistoryContent { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.LogHistoryTableDataXPath)]
        public IWebElement LogHistoryTableData { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.TableContentXPath)]
        public IWebElement TableContent { get; set; }

        [FindsBy(How = How.Id, Using = Locators.UserNameErrorMessageOnCreatePageID)]
        public IWebElement UserNameErrorMessageOnCreatePage { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.FullNameErrorMessageOnCreatePageXPath)]
        public IWebElement FullNameErrorMessageOnCreatePage { get; set; }

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

        [FindsBy(How = How.Id, Using = Locators.PhoneErrorID)]
        public IWebElement PhoneErrorMessage { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.UserListClassName)]
        public IWebElement UserListPage { get; set; }

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
        public IList<IWebElement> DetailsButtonList { get; set; }

        public string RandomFullNameLessThan50_49char { get; private set; }
        public string RandomPhoneNumber10_10Digits { get; private set; }


        /// <summary>
        /// User clicks any Details button except Logged User Details button
        /// </summary>
        /// <returns>DetailsButtonPosition</returns>
        public int FindDetailsButtonForOtherUserAndClick()
        {
            int DetailsButtonPosition;
            int NoOfDetailsButton = DetailsButtonList.Count;
            for (DetailsButtonPosition = 0; DetailsButtonPosition < NoOfDetailsButton; DetailsButtonPosition++)
            {
                string userNameXPath = "//*[@id=\"email" + DetailsButtonPosition + "\"]";
                string userName = PropertyClass.Driver.FindElement(By.XPath(userNameXPath)).Text;
                if (userName != AdvancedPage.ExpectedValues.LoggedUser)
                {
                    DetailsButtonList[DetailsButtonPosition].Click();
                    break;
                }
            }
            return DetailsButtonPosition;
        }

        /// <summary>
        ///  Updating Full name, Phone number and Role
        /// </summary>
        public void UpdateNamePhoneRole()
        {
            Thread.Sleep(2000);
            RandomFullNameLessThan50_49char = GetMethods.GenerateRandomString(49);
            RandomPhoneNumber10_10Digits = GetMethods.GenerateRandomPhoneNumber(1000000000);

            FullName.Clear();
            FullName.EnterText(RandomFullNameLessThan50_49char);
            PhoneTextField.Clear();
            PhoneTextField.EnterText(RandomPhoneNumber10_10Digits);
            Thread.Sleep(3000);
            UserManagerCheckBox.JavaSciptClick();
        }

        /// <summary>
        /// Manager wants to be on Edit User page where Log enteries are greater than 2
        /// </summary>
        /// <returns>DetailsButtonPosition</returns>
        public int FindEditUserPageWithLogEntriesGreaterThanTwo()
        {
            //Finding number of enteries in the table.
            int DetailsButtonPosition;
            int NoOfDetailsButton = DetailsButtonList.Count;
            string[] LogHistory = { };
            for (DetailsButtonPosition = 0; DetailsButtonPosition < NoOfDetailsButton; DetailsButtonPosition++)
            {
                PropertyClass.Driver.FindElement(By.XPath("(//*[@id=\"btn_edit\"])[" + (DetailsButtonPosition + 1) + "]")).Click();
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

            return DetailsButtonPosition;
        }

        /// <summary>
        /// Collecting all Dates from the Log History column firstly and putting it in a simple list as a string. Later in the second loop string is converted into DateTime list
        /// </summary>
        /// <returns>List of DateTime</returns>
        public List<DateTime> FindLogHistoryDateOrder()
        {
            var list = new List<string>();
            var DateTimeList = new List<DateTime>();
            string[] LogHistory = LogHistoryTableData.Text.Split();
            Thread.Sleep(2000);
            int LogHistoryCount = LogHistoryContent.Count;
            for (int i = 3; i < LogHistoryCount; i++)
            {
                list.Add(LogHistoryContent[i].Text);
            }

            for (int i = 0; i < list.Count; i++)
            {
                DateTimeList.Add(DateTime.Parse(list[i]));
            }
            return DateTimeList;
        }

        /// <summary>
        /// Finding Email oredr in Ascending
        /// </summary>
        /// <returns>Returns true if Email is sorted in Ascending order else false.</returns>
        public bool FindEmailSortingOrder()
        {           
            bool IsEmailIdAscendingOrder = false; 
            var list = new List<string>();
            int NoOfDetailsButton = DetailsButtonList.Count;
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
                IsEmailIdAscendingOrder = true;
            }
            return IsEmailIdAscendingOrder;
        }

       
        /// <summary>
        /// Clicking that Details Button where user Role is Administrator
        /// </summary>
        /// <returns>Returning RoleXPath and DetailsButtonPosition to verify after updating data</returns>
        public Dictionary<string, string> ClickDetailsButtonWhereRoleIsAdministrator()
        {
            int DetailsButtonPosition;
            string RoleXpath = null;
            var Elements = new Dictionary<string, string>();
            int NoOfDetailsButton = DetailsButtonList.Count;
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
                        DetailsButtonList[DetailsButtonPosition].Click();
                        break;
                    }
                }
            }

            Elements.Add(RoleXpath, DetailsButtonPosition.ToString());
            return Elements;
        }

        /// <summary>
        /// //To match Phone number I need to click on Details button then I will get Phone number. So providing ActualUserName through method to find in table content and then just Clicks only on corresponding Details button.
        /// </summary>
        /// <param name="ActualUserName"></param>
        public void ClicksOnDetailsButton(string ActualUserName)
        {
            int DetailsButtonCount;
            int NoOfDetailsButton = DetailsButtonList.Count;
            for (DetailsButtonCount = 0; DetailsButtonCount < NoOfDetailsButton; DetailsButtonCount++)
            {
                string userNameXPath = "//*[@id=\"email" + DetailsButtonCount + "\"]";
                string userName = PropertyClass.Driver.FindElement(By.XPath(userNameXPath)).Text;
                if (userName == ActualUserName)
                {
                    DetailsButtonList[DetailsButtonCount].Click();
                    break;
                }
            }
        }
    }
}
