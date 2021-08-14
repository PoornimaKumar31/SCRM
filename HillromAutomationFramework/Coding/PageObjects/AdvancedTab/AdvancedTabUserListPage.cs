using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HillromAutomationFramework.Coding.PageObjects.AdvancedTab
{
    class AdvancedTabUserListPage
    {
        public AdvancedTabUserListPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }
        public static class ExpectedValues
        {
            public const string EditUserPageLabelText = "EDIT USER";
            public const string UserListPageLabelText = "USER LIST";
            public const string UserManagementLabelTextOnEditUserPage = "User Management";
            public const string UserRoleAdministratorOnUserListPage = "Administrator";
            public const string UserRoleRegularOnUserListPage = "Regular";
            public const string PhoneNumberErrorMessage = "Please enter a valid phone number";
            public const string FullNameErrorMessage = "Please enter a valid name";
            public const string UpdatedFullName = "Alex Hasi";
            public const string PhoneNumberInvalid = "123";
            public const string SuperAdminUsername = "ltts_testing@hillrom.com";
        }
        public static class Locator
        {
            public const string UserListtLabelXPath = "//span[@class = \"hrtitle\"]";
            public const string UserListRowXPath = "//div[contains(@id,\"user_row\")]";
            public const string LoggedInUserNameID = "logged-in_username";
            public const string DeleteButonID = "btn_delete";
            public const string DeltePopupID = "usrmgt_confirmation_win";
            public const string DeletePopupUserNameEmailID = "usrmgt_confirmation_user";
            public const string DeletePopupConfirmationMessageXPath = "//div[@id = \"confirm_delete_message\"]//p[2]//span";
            public const string DeletePopupYesButtonID = "delete-yes";
            public const string DeletePopupNoButtonID = "delete-no";

        }

        [FindsBy(How = How.XPath, Using = Locator.UserListtLabelXPath)]
        public IWebElement UserListLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DeletePopupYesButtonID)]
        public IWebElement DeletePopupYesButton { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DeletePopupNoButtonID)]
        public IWebElement DeletePopupNoButton { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.DeletePopupConfirmationMessageXPath)]
        public IWebElement DeletePopupConfirmationMessage { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DeletePopupUserNameEmailID)]
        public IWebElement DeletePopupUserNameEmailID { get; set; }

        [FindsBy(How = How.Id, Using = Locator.DeleteButonID)]
        public IWebElement DeleteButton { get; set; }
        
        [FindsBy(How = How.Id, Using = Locator.DeltePopupID)]
        public IWebElement DeletePopup { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.UserListRowXPath)]
        public IList<IWebElement> UserList { get; set; }

        [FindsBy(How = How.Id, Using = Locator.LoggedInUserNameID)]
        public IWebElement LoggedInUserName { get; set; }

        public IList<IWebElement> UserListExceptLoggedInUser()
        {
            List<IWebElement> list = new List<IWebElement>(UserList);
            try
            {
                list.RemoveAt(GetIndexOfLoggedInUser(LoggedInUserName.Text));

            }
            catch(Exception e)
            {
                Assert.Fail("Logged in User could not be found"+ e.ToString());
            }
            
            return list;
        }

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
    }
}
