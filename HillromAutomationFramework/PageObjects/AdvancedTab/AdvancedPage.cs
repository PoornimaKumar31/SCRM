using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using SeleniumExtras.PageObjects;
using System.Linq;
using System.Threading;

namespace HillromAutomationFramework.PageObjects.AdvancedTab
{
    class AdvancedPage
    {
        public AdvancedPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
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
            public const string UserListLabelClassName = "hrtitle";
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
            public const string UserNameErrorMessageOnCreatePageXpath= "//div[@id='usrmgt_create_edit_win']/form/div/div/div/mat-error";
            public const string FullNameErrorMessageOnCreatePageXPath = "//div[@id='usrmgt_create_edit_win']/form/div[2]/div/div/mat-error";

            //Table Elements
            public const string FullnameLabelOnUserListID = "full_name";
            public const string RoleColumnHeaderID = "role";
            public const string EmailColumnHeaderID = "email";

            //Log History table data
            public const string LogHistoryTableDataXPath = "//*[@id=\"lbl_history_detail\"]/div[2]/div[2]";
            public const string LogHistoryContentXPath = "//*[@id=\"lbl_history_detail\"]//div[2]//div[1]";
            public const string UserListRowXPath = "//div[contains(@id,\"user_row\")]";
            public const string LoggedInUserNameID = "logged-in_username";

            //Delete Button Popup
            public const string DeltePopupID = "usrmgt_confirmation_win";
            public const string DeletePopupUserNameEmailID = "usrmgt_confirmation_user";
            public const string DeletePopupConfirmationMessageXPath = "//div[@id = \"confirm_delete_message\"]//p[2]//span";
            public const string DeletePopupYesButtonID = "delete-yes";
            public const string DeletePopupNoButtonID = "delete-no";
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
            public const string UpdatedFullName = "Alex Hasi";
            public const string PhoneNumberInvalid = "123";
            public const string SuperAdminUsername = "ltts_testing@hillrom.com";
            public const string UserInformationLabel = "User Information:";
        }

        [FindsBy(How = How.Id, Using = Locators.DeletePopupYesButtonID)]
        public IWebElement DeletePopupYesButton { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeletePopupNoButtonID)]
        public IWebElement DeletePopupNoButton { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.DeletePopupConfirmationMessageXPath)]
        public IWebElement DeletePopupConfirmationMessage { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeletePopupUserNameEmailID)]
        public IWebElement DeletePopupUserNameEmailID { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeltePopupID)]
        public IWebElement DeletePopup { get; set; }

        [FindsBy(How = How.Id, Using = Locators.EmailColumnHeaderID)]
        public IWebElement EmailColumnHeader { get; set; }

        [FindsBy(How = How.Id, Using = Locators.RoleColumnHeaderID)]
        public IWebElement RoleColumnHeader { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.UserListRowXPath)]
        public IList<IWebElement> UserList { get; set; }

        [FindsBy(How = How.Id, Using = Locators.LoggedInUserNameID)]
        public IWebElement LoggedInUserName { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.UserListRowXPath)]
        public IList<IWebElement> UserListRow { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.PhoneErrorMessageOnAddUserPageXPath)]
        public IWebElement PhoneErrorMessageOnAddUserPage { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DeleteButtonID)]
        public IList<IWebElement> DeleteButtonsList { get; set; }

        [FindsBy(How = How.Id, Using = Locators.FullnameLabelOnUserListID)]
        public IWebElement FullnameLabelOnUserList { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.LogHistoryContentXPath)]
        public IList<IWebElement> LogHistoryContent { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.LogHistoryTableDataXPath)]
        public IWebElement LogHistoryTableData { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.UserNameErrorMessageOnCreatePageXpath)]
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

        [FindsBy(How = How.ClassName, Using = Locators.UserListLabelClassName)]
        public IWebElement UserListLabel { get; set; }

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


        /// <summary>
        /// Getting User List rows of Username except Logged User
        /// </summary>
        /// <returns>Returns list of IWebElement of User list rows except Logged user</returns>
        public IList<IWebElement> UserListExceptLoggedInUser()
        {
            List<IWebElement> list = new List<IWebElement>(UserList);
            try
            {
                list.RemoveAt(GetIndexOfLoggedInUser(LoggedInUserName.Text));

            }
            catch (Exception e)
            {
                Assert.Fail("Logged in User could not be found" + e.ToString());
            }

            return list;
        }
        /// <summary>
        /// Getting row index of Logged user
        /// </summary>
        /// <param name="LoggedInUserName"></param>
        /// <returns>Returns index of Logged User</returns>
        public int GetIndexOfLoggedInUser(string LoggedInUserName)
        {
            IList<IWebElement> list = UserList;
            foreach (IWebElement element in list)
            {

                if (element.Text.StartsWith(LoggedInUserName))
                    return list.IndexOf(element);
            }
            return -1;
        }

        /// <summary>
        /// Collecting all Dates from the Log History column and putting it in a simple list as a string. Later in the second loop string is converted into DateTime list
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
        public bool FindEmailSortingOrder(IWebDriver driver)
        {           
            bool IsEmailIdAscendingOrder = false; 
            var list = new List<string>();
            int NoOfDetailsButton = DetailsButtonList.Count;
            for (int i = 0; i < NoOfDetailsButton; i++)
            {
                string userNameXPath = "//*[@id=\"email" + i + "\"]";
                string userName = driver.FindElement(By.XPath(userNameXPath)).Text;
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
        /// //To match Phone number I need to click on Details button then I will get Phone number. So providing ActualUserName through method to find in table content and then just Clicks only on corresponding Details button.
        /// </summary>
        /// <param name="ActualUserName"></param>
        public void ClickOnDetailsButtonOfSpecifiedUser(IWebDriver driver,string ActualUserName)
        {
            int DetailsButtonCount;
            int NoOfDetailsButton = DetailsButtonList.Count;
            for (DetailsButtonCount = 0; DetailsButtonCount < NoOfDetailsButton; DetailsButtonCount++)
            {
                string userNameXPath = "//*[@id=\"email" + DetailsButtonCount + "\"]";
                string userName = driver.FindElement(By.XPath(userNameXPath)).Text;
                if (userName == ActualUserName)
                {
                    DetailsButtonList[DetailsButtonCount].Click();
                    break;
                }
            }
        }

        public int GetIndexOfSpecificUser(IWebDriver driver,string userName)
        {
            int NoOfDetailsButton = DetailsButtonList.Count;
            //Iterating through the user list
            for (int detailsButtonPosition = 0; detailsButtonPosition < NoOfDetailsButton; detailsButtonPosition++)
            {
                string userFullNameXPath = "//*[@id=\"full_name" + detailsButtonPosition + "\"]";
                string userFullName = driver.FindElement(By.XPath(userFullNameXPath)).Text;
                if(userFullName.ToLower().Equals(userName.ToLower()))
                {
                    return (detailsButtonPosition);
                }
            }
            return (-1);
        }
    }
}
