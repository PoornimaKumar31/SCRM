using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace HillromAutomationFramework.Coding.PageObjects
{
    public class LoginPage
    {
        /// Locators of all the elements of login page are listed.
        public static class Locator
        {
            //Static Elements  
            public const string LogoID = "logo_main";
            public const string ApplicationTitleID= "lbl_app_title";
            public const string LoginInstructionsID= "lbl_login";
            public const string GetStartedTitleID = "get_started_title";
            public const string GetStartedMessageID = "get_started_message";

            //Login
            public const string LoginButtonID = "btn_login";
            public const string EmailFieldID = "user";
            public const string PasswordFieldID = "password";
            public const string ErrorMessageXPath = "//*[@id=\"lbl_login_error\"]/div/div/p/span";
            public const string ForgetPasswordLinkID = "forgot_pwd";
            public const string ForgetPasswordSuccessMessageID = "snackbar";



            //Software Downloads
            public const string PartnerConnectID = "partnerconnect";
            public const string ServiceMoniterID = "servicemonitor";
            public const string DCPID = "dcp";

            //PDF downloads
            public const string AdministartorsGuideID = "adminguide";
            public const string InstructionForUseID = "useguide";
            public const string ReleaseNotesID = "releasenotes";


            //Login Page footers               
            public const string VersionXpath = "/html/body/c8y-bootstrap/c8y-login/div/div[4]/span";
            public const string PrivacyPolicyID = "privacy";
            public const string TermsOfUseID = "terms";
            public const string SupportedBrowsersID = "supportbrowsers";
            public const string SupportedBrowserPopupID = "browser-supported";
            public const string SupportedBrowserclosebuttonXpath = "//*[@id=\"browser-supported\"]/div/div/button";
        }

        /// Expected values in the login page.
        public static class ExpectedValues
        {
            //static elements
            public const string ApplicationTitleText= "SmartCare™";
            public const string LoginInstructionsText = "Enter your credentials to sign in.";
            public const string GetStartedTitleText = "Ready to get started?";
            public const string GetStartedMessageText = "Learn the value of the SmartCare™ Remote Management, download software, and access documentation.";

            //login
            public const string InvalidEntryErrorMessage = "Username or password invalid.";
            public const string NoEntryErrorMessage = "Full authentication is required to access this resource";
            public const string EmailFieldHintText = "Email address";
            public const string PasswordFieldHintText = "Password";
            public const string LandingPageTitle = "SmartCare™ Remote Management";

            //Forgot password
            public const string ForgotPasswordSuccessMessage = "You will receive an email with a link to update your password";

            

            //Software Downloads

            //PDF Documents URL
            public const string AdminstartorsGuidePDFURL = "https://www.hillrom.com/content/dam/hillrom-aem/us/en/sap-documents/LIT/80028/80028398LITPDF.pdf";
            public const string InstructionForUsePDFURL = "https://www.hillrom.com/content/dam/hillrom-aem/us/en/sap-documents/LIT/80028/80028397LITPDF.pdf";
            public const string RealeaseNotesPDFURL = "https://www.hillrom.com/content/dam/hillrom-aem/us/en/sap-documents/LIT/80028/80028399LITPDF.pdf";

            //footer links
            public const string CopyRightMessage = "© 2021 Hillrom™. All rights reserved.";
            public const string PrivacyPolicyURL = "https://www.hillrom.com/en/about-us/global-privacy-notice/";
            public const string TermsOfUseURL = "https://www.hillrom.com/en/about-us/hill-rom-terms-and-conditions/";

            //Supported Browser List
            public const string SupportedBrowserEdge = "Microsoft Edge : version 89 and higher";
            public const string SupportedBrowserChrome = "Google Chrome : version 86 and higher";
            public const string SupportedBrowserAppleSafari = "Apple Safari : iOS 14 and higher";
            

        }
        /// Constructor for login page which intializes all Web elements of login page.
        public LoginPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        /*Attributes for assigning values to the webelement*/

        /// Hillrom Logo
        [FindsBy(How = How.Id, Using = Locator.LogoID)]
        public IWebElement LoginPageLogo { get; set; }

        /// Application title
        [FindsBy(How = How.Id, Using = Locator.ApplicationTitleID)]
        public IWebElement ApplicationTitle { get; set; }

        ///Login Instructions
        [FindsBy(How = How.Id, Using = Locator.LoginInstructionsID)]
        public IWebElement LoginInstructions { get; set; }


        /// GetStartedTitle
        [FindsBy(How = How.Id, Using = Locator.GetStartedTitleID)]
        public IWebElement GetStartedTitle { get; set; }

        /// GetStartedMessage
        [FindsBy(How = How.Id, Using = Locator.GetStartedMessageID)]
        public IWebElement GetStartedMessage { get; set; }

        /// Email field
        [FindsBy(How = How.Id, Using = Locator.EmailFieldID)]
        public IWebElement EmailField { get; set; }

        /// Password Field
        [FindsBy(How = How.Id, Using = Locator.PasswordFieldID)]
        public IWebElement PasswordField { get; set; }

        /// Login Button
        [FindsBy(How = How.Id, Using = Locator.LoginButtonID)]
        public IWebElement LoginButton { get; set; }

        /// Credential Error message
        [FindsBy(How = How.XPath, Using = Locator.ErrorMessageXPath)]
        public IWebElement ErrorMessage { get; set; }

        
        //Forget Password

        // Forget Password Link
        [FindsBy(How = How.Id, Using = Locator.ForgetPasswordLinkID)]
        public IWebElement ForgotPasswordLink { get; set; }

        // Sucess message in forgot password
        [FindsBy(How = How.Id, Using = Locator.ForgetPasswordSuccessMessageID)]
        public IWebElement ForgetPasswordSuccessMessage { get; set; }


        //Sofware Downloads

        // Partner connect software download link
        [FindsBy(How = How.Id, Using = Locator.PartnerConnectID)]
        public IWebElement PartnerConnectLink { get; set; }

        // Service Moniter software download link
        [FindsBy(How = How.Id, Using = Locator.ServiceMoniterID)]
        public IWebElement ServiceMoniterLink { get; set; }

        // DCP Software download link
        [FindsBy(How = How.Id, Using = Locator.DCPID)]
        public IWebElement DCPLink { get; set; }

        //PDF downloads

        // Administrative Guide PDF link
        [FindsBy(How = How.Id, Using = Locator.AdministartorsGuideID)]
        public IWebElement AdministratorsGuidePDFLink { get; set; }

        // Instruction for use PDF link
        [FindsBy(How = How.Id, Using = Locator.InstructionForUseID)]
        public IWebElement InstructionForUsePDFLink { get; set; }

        // Release Notes PDF link
        [FindsBy(How = How.Id, Using = Locator.ReleaseNotesID)]
        public IWebElement ReleaseNotesPDFLink { get; set; }



        // Login Page Footer

        // Version No of SCRM portal
        [FindsBy(How = How.XPath, Using = Locator.VersionXpath)]
        public IWebElement VersionNumber { get; set; }

        // Privacy policy link
        [FindsBy(How = How.Id, Using = Locator.PrivacyPolicyID)]
        public IWebElement PrivacyPolicylink { get; set; }

        // Terms of use link
        [FindsBy(How = How.Id, Using = Locator.TermsOfUseID)]
        public IWebElement TermsOfUseLink { get; set; }

        // Supported browser list Link
        [FindsBy(How = How.Id, Using = Locator.SupportedBrowsersID)]
        public IWebElement SupportedBrowsersLink { get; set; }

        // Suppoterd browser list Pop-up   
        [FindsBy(How = How.Id, Using = Locator.SupportedBrowserPopupID)]
        public IWebElement SupportedBrowserPopup { get; set; }

        // Close button in supported browser list Pop-up.
        [FindsBy(How = How.XPath, Using = Locator.SupportedBrowserclosebuttonXpath)]
        public IWebElement SupportedBrowserclosebutton { get; set; }



        //Function for Login
        public void SignIn(string signinType)
        {
            PropertyClass.Driver.Navigate().GoToUrl(PropertyClass.BaseURL);  // Launch the Application
            // Explicit wait-> Wait till logo is displayed
            WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(LoginPage.Locator.LogoID)));

            if (signinType.ToLower().Trim().Contains("adminwithrollup"))
            {
                EmailField.EnterText(PropertyClass.readConfig.EmailIDAdminWithRollUp);
                PasswordField.EnterText(PropertyClass.readConfig.PasswordAdminWithRollUp);
                LoginButton.Clicks();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(LandingPage.Locator.Organization0FacilityPanel0ID)));
            }
            else if(signinType.ToLower().Trim().Contains("adminwithoutrollup"))
            {
                EmailField.EnterText(PropertyClass.readConfig.EmailAdminWithoutRollUp);
                PasswordField.EnterText(PropertyClass.readConfig.PasswordAdminWithoutRollUp);
                LoginButton.Clicks();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            }
            else if(signinType.ToLower().Trim().Contains("standarduserwithoutrollup"))
            {
                EmailField.EnterText(PropertyClass.readConfig.EmailStandardWithoutRollUp);
                PasswordField.EnterText(PropertyClass.readConfig.PasswordStandardWithoutRollUp);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.AssetsTabID)));
                LoginButton.Clicks();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.AssetsTabID)));
            }
            else if(signinType.ToLower().Trim().Contains("rv700"))
            {
                LandingPage landingPage = new LandingPage();
                EmailField.EnterText(PropertyClass.readConfig.EmailIDAdminWithRollUp);
                PasswordField.EnterText(PropertyClass.readConfig.PasswordAdminWithRollUp);
                LoginButton.Clicks();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(LandingPage.Locator.Organization0FacilityPanel0ID)));
                landingPage.Organization1Facility0Title.Click();
            }
            
        }
    }
}
