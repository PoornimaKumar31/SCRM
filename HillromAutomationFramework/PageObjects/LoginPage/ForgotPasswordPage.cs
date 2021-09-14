﻿using HillromAutomationFramework.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HillromAutomationFramework.PageObjects
{
    public class ForgotPasswordPage
    {
        public static class Locator
        {
            //Forget password
            public const string LinkID = "forgot_pwd";
            public const string EmailFieldID = "forgot_email";
            public const string SubmitButtonID = "btn_forgot_submit";
            public const string LoginLinkID = "lnk_nav_login";
            public const string SuccessMessageID = "snackbar";    
            public const string HillromLogoID= "logo_main";
            public const string ApplicationTitleID= "lbl_app_title";
            public const string ApplicationSubtitleID = "lbl_app_sub_title";
            public const string ResetPasswordInstructionsID = "lbl_forgot_email";
            public const string InvalidEmailErrorMessageXpath= "//input[@id='forgot_email']/parent::c8y-form-group/c8y-messages/small/div";
        }
        public static class ExpectedValues
        {
            public const string ApplicationTitle = "SmartCare™";
            public const string ApplicationSubTitle = "Remote Management";
            public const string EmailFieldHintText = "Email address";
            public const string FailedErrorMessage = "Invalid email address Try again";
            public const string ResetPasswordInstructionsText = "Enter your email address and we will send you instructions for resetting your password.";
            public const string InvalidEmailErrorMessageText = "Invalid email address.";
        }

        public ForgotPasswordPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        // Email Field in forget password form
        [FindsBy(How = How.Id, Using = Locator.EmailFieldID)]
        public IWebElement EmailFeild { get; set; }

        // Submit button in Forget password form
        [FindsBy(How = How.Id, Using = Locator.SubmitButtonID)]
        public IWebElement SubmitButton { get; set; }

        // Login link forgot password form
        [FindsBy(How = How.Id, Using = Locator.LoginLinkID)]
        public IWebElement LoginLink { get; set; }

        //Hillrom Logo
        [FindsBy(How = How.Id, Using = Locator.HillromLogoID)]
        public IWebElement HillromLogo { get; set; }

        //Application Title
        [FindsBy(How = How.Id, Using = Locator.ApplicationTitleID)]
        public IWebElement ApplicationTitle { get; set; }

        [FindsBy(How = How.Id, Using = Locator.ApplicationSubtitleID)]
        public IWebElement ApplicationSubtitle { get; set; }

        //Reset password instructions
        [FindsBy(How = How.Id, Using = Locator.ResetPasswordInstructionsID)]
        public IWebElement ResetPasswordInstructions { get; set; }

        //Invalid email address erroe message
        [FindsBy(How = How.XPath, Using = Locator.InvalidEmailErrorMessageXpath)]
        public IWebElement InvalidEmailErrorMessage { get; set; }
    }
}
