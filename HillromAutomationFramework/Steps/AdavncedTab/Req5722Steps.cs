using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AdvancedTab;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.AdvancedTab
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5722")]
    class Req5722Steps
    {       
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;        
        private readonly AdvancedPage _advancedPage;
        private readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        private ScenarioContext _scenarioContext;

        public string email, fullname;
        public int FirstElementIndex = 0;
        public IWebElement selectedRow;

        public Req5722Steps(ScenarioContext scenarioContext)
        {
            _loginPage = new LoginPage();
            _landingPage = new LandingPage();
            _mainPage = new MainPage();
            _advancedPage = new AdvancedPage();
            _scenarioContext = scenarioContext;
        }

        [Given(@"manager user is on User List page having more than (.*) records")]
        public void GivenManagerUserIsOnUserListPageHavingMoreThanRecords(int numberOfUser)
        {
            _loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            _mainPage.AdvancedTab.JavaSciptClick();
            Assert.Greater(_advancedPage.UserList.Count, numberOfUser,"User List Page does not have more than 2 records");
           
        }

        [When(@"user clicks Delete button for user")]
        public void WhenUserClicksDeleteButtonForUser()
        {
            selectedRow = _advancedPage.UserListExceptLoggedInUser()[FirstElementIndex];
            string selectedRowID = selectedRow.GetAttribute("id");
            char rowNum = selectedRowID[selectedRowID.Length - 1];
            email = selectedRow.FindElement(By.Id("email" + rowNum)).Text;
            fullname = selectedRow.FindElement(By.Id("full_name" + rowNum)).Text;
            selectedRow.FindElement(By.Id(AdvancedPage.Locators.DeleteButtonID)).Click();
        }

        [Then(@"Delete User pop-up dialog is displayed")]
        public void ThenDeleteUserPop_UpDialogIsDisplayed()
        {
            Assert.IsTrue(_advancedPage.DeletePopup.GetElementVisibility(),"Delete Popup is not displayed");
        }

        [Then(@"user full name and email address are displayed")]
        public void ThenUserFullNameAndEmailAddressAreDisplayed()
        {
            string ExpectedText = fullname + " (" + email+")";
            Assert.AreEqual(ExpectedText, _advancedPage.DeletePopupUserNameEmailID.Text, "Fullname and email is not as expected");
        }

        [Then(@"""(.*)"" message is displayed")]
        public void ThenMessageIsDisplayed(string ExpectedText)
        {
            Assert.IsTrue(_advancedPage.DeletePopupConfirmationMessage.GetElementVisibility(), "Confirmation message is not displayed");
        }


        [Then(@"Yes button is displayed")]
        public void ThenYesButtonIsDisplayed()
        {
            Assert.IsTrue(_advancedPage.DeletePopupYesButton.GetElementVisibility(),"Yes button is not displayed");
        }

        [Then(@"No button is displayed")]
        public void ThenNoButtonIsDisplayed()
        {
            Assert.IsTrue(_advancedPage.DeletePopupNoButton.GetElementVisibility(), "No button is not displayed");
        }


        [Given(@"user clicks Delete button for user")]
        public void GivenUserClicksDeleteButtonForUser()
        {
            selectedRow = _advancedPage.UserListExceptLoggedInUser()[FirstElementIndex];
            string selectedRowID = selectedRow.GetAttribute("id");
            char rowNum = selectedRowID[selectedRowID.Length - 1];
            email = selectedRow.FindElement(By.Id("email" + rowNum)).Text;
            fullname = selectedRow.FindElement(By.Id("full_name" + rowNum)).Text;
            selectedRow.FindElement(By.Id(AdvancedPage.Locators.DeleteButtonID)).Click();
        }

        [Given(@"Delete User pop-up dialog is displayed")]
        public void GivenDeleteUserPop_UpDialogIsDisplayed()
        {
            Assert.IsTrue(_advancedPage.DeletePopup.GetElementVisibility(), "Delete Popup is not displayed");
        }

        [When(@"user clicks No button")]
        public void WhenUserClicksNoButton()
        {
            _advancedPage.DeletePopupNoButton.Click();
        }

        [Then(@"Delete User pop-up dialog closes")]
        public void ThenDeleteUserPop_UpDialogCloses()
        {
            Assert.IsFalse(_advancedPage.DeletePopup.GetElementVisibility(), "Delete Popup is displayed");
        }

        [Then(@"User List page is displayed")]
        public void ThenUserListPageIsDisplayed()
        {
            Assert.IsTrue(_advancedPage.UserListLabel.GetElementVisibility(), "User is not on the user list page");
        }

        [Then(@"user is not deleted")]
        public void ThenUserIsNotDeleted()
        {
            Assert.IsTrue(selectedRow.GetElementVisibility(),"Could not find the user");
        }

        [When(@"user clicks Yes button")]
        public void WhenUserClicksYesButton()
        {
            _advancedPage.DeletePopupYesButton.Click();
        }

        [Then(@"user is deleted")]
        public void ThenUserIsDeleted()
        {
            Assert.IsFalse(selectedRow.GetElementVisibility(), "Could not find the user");
        }
    }
}
