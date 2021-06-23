using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HillromAutomationFramework.Coding.PageObjects
{
    public class LoginPage
    {
        /// Locators of all the elements of login page are listed.
        public static class Locator
        {
            //Login
            public const string LogoXPath = "//*[@id=\"smartcare\"]/div[1]/img";
            public const string LoginButtonXPath = "//*[@id=\"smartcare\"]/c8y-credentials/form/button";
            public const string EmailFieldXPath = "//*[@id=\"user\"]";
            public const string PasswordFieldXPath = "//*[@id=\"password\"]";
            public const string ErrorMessageXPath = "//*[@id=\"smartcare\"]/c8y-credentials/div[1]/p/c8y-alert-outlet/div/div/p/span";

            //Forget password
            public const string ForgetPasswordLinkXpath = "//*[@id=\"smartcare\"]/c8y-credentials/form/div/a";
            public const string ForgetPasswordEmailFieldXpath = "//*[@id=\"smartcare\"]/c8y-recover-password/form/c8y-form-group/input";
            public const string ForgetPasswordSubmitButtonXpath = "//*[@id=\"smartcare\"]/c8y-recover-password/form/button";
            public const string ForgetPasswordLoginLinkXpath = "//*[@id=\"smartcare\"]/c8y-recover-password/form/div/p/a";
            public const string ForgetPasswordSuccessMessageXpath = "//*[@id=\"snackbar\"]";

            //Software Downloads
            public const string PartnerConnectLinkText = "PartnerConnect™";
            public const string ServiceMoniterLinkText = "Service Monitor";
            public const string DCPLinkText = "DCP";

            //PDF downloads
            public const string AdministartorsGuideLinkText = "Administrator's Guide";
            public const string InstructionForUseLinkText = "Instructions for Use";
            public const string ReleaseNotesLinkText = "Release Notes";


            //Login Page footers
            public const string VersionXpath = "/html/body/c8y-bootstrap/c8y-login/div/div[4]/span/text()[1]";
            public const string PrivacyPolicyLinkText = "Privacy Policy";
            public const string TermsOfUseLinkText = "Terms of Use";
            public const string SupportedBrowsersLinkText = "Supported Browsers";
            public const string SupportedBrowserPopupXpath = "//*[@id=\"browser-supported\"]";
            public const string SupportedBrowserclosebuttonXpath = "//*[@id=\"browser-supported\"]/div/div/button";

            // Landing page web elements
            public const string LandingPageTileXPath = "//*[@id=\"org0\"]/div";
            public const string LandingPageUserNameLogoXpath = "//*[@id=\"header\"]/div[1]/div/button";
            public const string LandingPageLogOutButtonXpath = "//*[@id=\"header\"]/div[1]/div/div/a";
        }

        /// Expected values in the login page.
        public static class ExpectedValues
        {
            //login
            public const string InvalidEntryErrorMessage = "Username or password invalid.";
            public const string NoEntryErrorMessage = "Full authentication is required to access this resource";
            public const string LandingPageTitle = "SmartCare™ Remote Management";

            //reset password
            public const string ResetPasswordSuccessMessage = "You will receive an email with a link to update your password";
            public const string ResetPasswordFailedMessage = "Invalid email address Try again";

            //Software Downloads

            //PDF Documents URL
            public const string AdminstartorsGuidePDFURL = "https://www.hillrom.com/content/dam/hillrom-aem/us/en/sap-documents/LIT/80028/80028398LITPDF.pdf";
            public const string InstructionForUsePDFURL = "https://www.hillrom.com/content/dam/hillrom-aem/us/en/sap-documents/LIT/80028/80028397LITPDF.pdf";
            public const string RealeaseNotesPDFURL = "https://www.hillrom.com/content/dam/hillrom-aem/us/en/sap-documents/LIT/80028/80028399LITPDF.pdf";

            //footer links
            public const string FooterVersionMessage = "Version 6.0.0  |  © 2021 Hillrom™. All rights reserved.";
            public const string PrivacyPolicyURL = "https://www.hillrom.com/en/about-us/global-privacy-notice/";
            public const string TermsOfUseURL = "https://www.hillrom.com/en/about-us/hill-rom-terms-and-conditions/";

            //Supported Browser List
            public const string SupportedBrowserEdge = "Microsoft Edge : version 89.0.774.68 and higher";
            public const string SupportedBrowserChrome = "Google Chrome : version 86 and higher";
            public const string SupportedBrowserAppleSafari = "Apple Safari : iOS 11 and higher";

        }
        /// Constructor for login page which intializes all Web elements of login page.
        public LoginPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        /*Attributes for assigning values to the webelement*/

        /// Email field
        [FindsBy(How = How.XPath, Using = Locator.EmailFieldXPath)]
        public IWebElement EmailField { get; set; }

        /// Password Field
        [FindsBy(How = How.XPath, Using = Locator.PasswordFieldXPath)]
        public IWebElement PasswordField { get; set; }

        /// Login Button
        [FindsBy(How = How.XPath, Using = Locator.LoginButtonXPath)]
        public IWebElement LoginButton { get; set; }

        /// Hillrom Logo
        [FindsBy(How = How.XPath, Using = Locator.LogoXPath)]
        public IWebElement LoginPageLogo { get; set; }

        /// Credential Error message
        [FindsBy(How = How.XPath, Using = Locator.ErrorMessageXPath)]
        public IWebElement ErrorMessage { get; set; }

        /// Landing page user name logo
        [FindsBy(How = How.XPath, Using = Locator.LandingPageUserNameLogoXpath)]
        public IWebElement LandingPageUserNameLogo { get; set; }

        // Landing page logout button
        [FindsBy(How = How.XPath, Using = Locator.LandingPageLogOutButtonXpath)]
        public IWebElement LandingPageLogOutButton { get; set; }

        //Forget Password

        // Forget Password Link
        [FindsBy(How = How.XPath, Using = Locator.ForgetPasswordLinkXpath)]
        public IWebElement ForgotPasswordLink { get; set; }

        // Email Field in forget password form
        [FindsBy(How = How.XPath, Using = Locator.ForgetPasswordEmailFieldXpath)]
        public IWebElement ForgetPasswordEmailFeild { get; set; }

        // Submit button in Forget password form
        [FindsBy(How = How.XPath, Using = Locator.ForgetPasswordSubmitButtonXpath)]
        public IWebElement ForgetPasswordSubmitButton { get; set; }

        // Login link forgot password form
        [FindsBy(How = How.XPath, Using = Locator.ForgetPasswordLoginLinkXpath)]
        public IWebElement ForgetPasswordLoginLink { get; set; }

        // Sucess message in forgot password
        [FindsBy(How = How.XPath, Using = Locator.ForgetPasswordSuccessMessageXpath)]
        public IWebElement ForgetPasswordSuccessMessage { get; set; }


        //Sofware Downloads

        // Partner connect software download link
        [FindsBy(How = How.LinkText, Using = Locator.PartnerConnectLinkText)]
        public IWebElement PartnerConnectLink { get; set; }

        // Service Moniter software download link
        [FindsBy(How = How.LinkText, Using = Locator.ServiceMoniterLinkText)]
        public IWebElement ServiceMoniterLink { get; set; }

        // DCP Software download link
        [FindsBy(How = How.LinkText, Using = Locator.DCPLinkText)]
        public IWebElement DCPLink { get; set; }

        //PDF downloads

        // Administrative Guide PDF link
        [FindsBy(How = How.LinkText, Using = Locator.AdministartorsGuideLinkText)]
        public IWebElement AdministratorsGuidePDFLink { get; set; }

        // Instruction for use PDF link
        [FindsBy(How = How.LinkText, Using = Locator.InstructionForUseLinkText)]
        public IWebElement InstructionForUsePDFLink { get; set; }

        // Release Notes PDF link
        [FindsBy(How = How.LinkText, Using = Locator.ReleaseNotesLinkText)]
        public IWebElement ReleaseNotesPDFLink { get; set; }



        // Login Page Footer

        // Version No of SCRM portal
        [FindsBy(How = How.XPath, Using = Locator.VersionXpath)]
        public IWebElement VersionNumber { get; set; }

        // Privacy policy link
        [FindsBy(How = How.LinkText, Using = Locator.PrivacyPolicyLinkText)]
        public IWebElement PrivacyPolicylink { get; set; }

        // Terms of use link
        [FindsBy(How = How.LinkText, Using = Locator.TermsOfUseLinkText)]
        public IWebElement TermsOfUseLink { get; set; }

        // Supported browser list Link
        [FindsBy(How = How.LinkText, Using = Locator.SupportedBrowsersLinkText)]
        public IWebElement SupportedBrowsersLink { get; set; }

        // Suppoterd browser list Pop-up   
        [FindsBy(How = How.XPath, Using = Locator.SupportedBrowserPopupXpath)]
        public IWebElement SupportedBrowserPopup { get; set; }

        // Close button in supported browser list Pop-up.
        [FindsBy(How = How.XPath, Using = Locator.SupportedBrowserclosebuttonXpath)]
        public IWebElement SupportedBrowserclosebutton { get; set; }

    }
}
