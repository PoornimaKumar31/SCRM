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
        }
        public static class ExpectedValues
        {
            public const string EmailFieldHintText = "Email address";
            public const string FailedErrorMessage = "Invalid email address Try again";
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


    }
}
