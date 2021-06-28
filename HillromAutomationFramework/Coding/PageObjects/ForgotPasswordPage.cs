using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HillromAutomationFramework.Coding.PageObjects
{
    public class ForgotPasswordPage
    {
        public static class Locator
        {
            public const string EmailFieldXpath = "//*[@id=\"smartcare\"]/c8y-recover-password/form/c8y-form-group/input";
            public const string SubmitButtonXpath = "//*[@id=\"smartcare\"]/c8y-recover-password/form/button";
            public const string LoginButtonXpath = "//*[@id=\"smartcare\"]/c8y-recover-password/form/div/p/a";
            public const string HillromLogoXpath= "//*[@id=\"smartcare\"]/div[1]/img";
            public const string ApplicationTitleXpath= "//*[@id=\"smartcare\"]/div[2]";
            public const string ResetPasswordInstructionsXpath= "//*[@id=\"smartcare\"]/c8y-recover-password/div/span";
        }
        public static class ExpectedValues
        {
            public const string EmailFieldHintText = "Email address";
            public const string FailedErrorMessage = "Invalid email address Try again";
            public const string ResetPasswordInstructionsText = "Enter your email address and we will send you instructions for resetting your password.";
        }

        public ForgotPasswordPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        // Email Field in forget password form
        [FindsBy(How = How.XPath, Using = Locator.EmailFieldXpath)]
        public IWebElement EmailFeild { get; set; }

        // Submit button in Forget password form
        [FindsBy(How = How.XPath, Using = Locator.SubmitButtonXpath)]
        public IWebElement SubmitButton { get; set; }

        // Login link forgot password form
        [FindsBy(How = How.XPath, Using = Locator.LoginButtonXpath)]
        public IWebElement LoginButton { get; set; }

        //Hillrom Logo
        [FindsBy(How = How.XPath, Using = Locator.HillromLogoXpath)]
        public IWebElement HillromLogo { get; set; }

        //Application Title
        [FindsBy(How = How.XPath, Using = Locator.ApplicationTitleXpath)]
        public IWebElement ApplicationTitle { get; set; }

        //Rest password instructions
        [FindsBy(How = How.XPath, Using = Locator.ResetPasswordInstructionsXpath)]
        public IWebElement ResetPasswordInstructions { get; set; }
    }
}
