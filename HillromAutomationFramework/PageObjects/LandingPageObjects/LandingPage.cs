using HillromAutomationFramework.PageObjects.LandingPageObjects;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace HillromAutomationFramework.PageObjects
{
    /// <summary>
    /// Landing Page related locators are stored.
    /// </summary>
    class LandingPage
    {
        public LandingPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Landing Page related locators are stored.
        /// </summary>
        public static class Locator
        {
            

            //Organization and facility XPath

            //L&T Automated Test East Organization
            public const string LNTAutomatedTestEastOrganizationTitleXPath = "//span[text()='L&T Automated Test East']";
            public const string LNTAutomatedTestEastOrganizationFacilityPanelTest4TitleXpath = LNTAutomatedTestEastOrganizationTitleXPath + "//parent::div//parent::div//span[text()='Test4']";
            public const string Organization0Facility0ServerID = "serv00";
            public const string Organization0Facility0DeviceID = "dev00";

            //L&T Automated Test Organization
            public const string LNTAutomatedTestOrganizationTitleXPath = "//span[text()='L&T Automated Test']";
            //L&T Automated Test Organization facility test1
            public const string LNTAutomatedTestOrganizationFacilityTest1TitleXPath = LNTAutomatedTestOrganizationTitleXPath + "//parent::div//parent::div//span[text()='Test1']";
            public const string Organization1Facility0ServerID = "serv10";
            public const string Organization1Facility0DeviceID = "dev10";

            //L&T Automated Test Organization facility test2
            public const string LNTAutomatedTestOrganizationFacilityTest2TitleXPath = LNTAutomatedTestOrganizationTitleXPath + "//parent::div//parent::div//span[text()='Test2']";
            public const string Organization1Facility1ServerID = "serv11";
            public const string Organization1Facility1DeviceID = "dev11";

            //L&T Automated Eye Test Organization
            public const string LNTAutomatedEyeTestOrganizationTitleXPath = "//span[text()='LT Automated Eye Test']";
            public const string LNTAutomatedEyeTestOrganizationFacilityTest1TitleXPath=LNTAutomatedEyeTestOrganizationTitleXPath+ "//parent::div//parent::div//span[text()='Test1']";
            public const string Organization2Facility0ServerID = "serv20";
            public const string Organization2Facility0DeviceID = "dev20";

            //PSS Service Organization
            public const string PSSServiceOrganizationTitleXpath = "//span[text()='PSS Service']";
            public const string PSSServiceOrganizationFacilityBatesvilleXpath = PSSServiceOrganizationTitleXpath + "//parent::div//parent::div//span[text()='Batesville']";

            //Header elements
            public const string UserNameLogoID = "userprofile_logo";
            public const string LogOutButtonID = "logout";
            public const string HeaderLogoID = "servicehub_logo";
         
        }

        /// Landing page user name logo
        [FindsBy(How = How.Id, Using = Locator.UserNameLogoID)]
        public IWebElement UserNameLogo { get; set; }

        // Landing page logout button
        [FindsBy(How = How.Id, Using = Locator.LogOutButtonID)]
        public IWebElement LogOutButton { get; set; }

        //L&T Automated test East
        [FindsBy(How =How.XPath, Using = Locator.LNTAutomatedTestEastOrganizationTitleXPath)]
        public IWebElement LNTAutomatedTestEastOrganizationTitle { get; set; }

        //L&T Automated test East Organization facility Test 4 
        [FindsBy(How = How.XPath, Using = Locator.LNTAutomatedTestEastOrganizationFacilityPanelTest4TitleXpath)]
        public IWebElement LNTAutomatedTestEastOrganizationFacilityPanelTest4Title { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization0Facility0ServerID)]
        public IWebElement Organization0Facility0Server { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization0Facility0DeviceID)]
        public IWebElement Organization0Facility0Device { get; set; }



        ///L&T Automated Test Organization
        [FindsBy(How = How.XPath, Using = Locator.LNTAutomatedTestOrganizationTitleXPath)]
        public IWebElement LNTAutomatedTestOrganizationTitle { get; set; }

        ///L&T Automated Test Organization facility test1
        [FindsBy(How = How.XPath, Using = Locator.LNTAutomatedTestOrganizationFacilityTest1TitleXPath)]
        public IWebElement LNTAutomatedTestOrganizationFacilityTest1Title { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization1Facility0ServerID)]
        public IWebElement Organization1Facility0Server { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization1Facility0DeviceID)]
        public IWebElement Organization1Facility0Device { get; set; }

        ///L&T Automated Test Organization facility test2
        [FindsBy(How = How.XPath, Using = Locator.LNTAutomatedTestOrganizationFacilityTest2TitleXPath)]
        public IWebElement LNTAutomatedTestOrganizationFacilityTest2Title { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization1Facility1ServerID)]
        public IWebElement Organization1Facility1Server { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization1Facility1DeviceID)]
        public IWebElement Organization1Facility1Device { get; set; }


        ///L&T Automated Eye Test Organization
        [FindsBy(How = How.XPath, Using = Locator.LNTAutomatedEyeTestOrganizationTitleXPath)]
        public IWebElement LNTAutomatedEyeTestOrganizationTitle { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.LNTAutomatedEyeTestOrganizationFacilityTest1TitleXPath)]
        public IWebElement LNTAutomatedEyeTestOrganizationFacilityTest1Title { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization2Facility0ServerID)]
        public IWebElement Organization2Facility0Server { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization2Facility0DeviceID)]
        public IWebElement Organization2Facility0Device { get; set; }

        ///PSS Service organization
        [FindsBy(How = How.XPath, Using = Locator.PSSServiceOrganizationTitleXpath)]
        public IWebElement PSSServiceOrganizationTitle { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.PSSServiceOrganizationFacilityBatesvilleXpath)]
        public IWebElement PSSServiceOrganizationFacilityBatesville { get; set; }

        /// <summary>
        /// List of organizations
        /// </summary>
        public enum Organizations
        {
            LNTAutomatedtestEast,
            LNTAutomatedTest,
            PSSService,
            LNTAutomatedEyeTest
        }

        /// <summary>
        /// List of facilities
        /// </summary>
        public enum Facility
        {
            Test1,
            Test2,
            Test4,
            Batesville,
        }



        /// <summary>
        /// Login and selects the preferred organization.
        /// </summary>
        /// <param name="organizations">Organization to select</param>
        /// <param name="facility">facility to select on the organization</param>
        public void LoginAndSelectPreferredOrganization(IWebDriver driver,LandingPage.Organizations organizations,LandingPage.Facility facility)
        {
            IWebElement facilityWebElement=null;

            LoginPage loginPage = new LoginPage(driver);
            loginPage.LogIn(driver,LoginPage.LogInType.AdminWithRollUpPage);
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                Message = "Roll up page is not displayed"
            };
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("rollup-page"));

            //Select the required Organization and Facility under that organization
            switch(organizations)
            {
                //L&T Automated Test East
                case LandingPage.Organizations.LNTAutomatedtestEast:
                        switch(facility)
                        {
                            case LandingPage.Facility.Test4:
                                facilityWebElement = LNTAutomatedTestEastOrganizationFacilityPanelTest4Title;
                                break;
                            default:
                                Assert.Fail(facility.ToString()+" facility does not exist in organization "+organizations.ToString());
                                break;
                        }
                 break;
                //L&T Automated Test 
                case LandingPage.Organizations.LNTAutomatedTest:
                    switch (facility)
                    {
                        case LandingPage.Facility.Test1:
                            facilityWebElement = LNTAutomatedTestOrganizationFacilityTest1Title;
                            break;
                        case LandingPage.Facility.Test2:
                            facilityWebElement = LNTAutomatedTestOrganizationFacilityTest2Title;
                            break;
                        default:
                            Assert.Fail(facility.ToString() + " facility does not exist in organization " + organizations.ToString());
                            break;
                    }
                    break;
                //PSS Service
                case LandingPage.Organizations.PSSService:
                    switch (facility)
                    {
                        case LandingPage.Facility.Batesville:
                            facilityWebElement = PSSServiceOrganizationFacilityBatesville;
                            break;
                        default:
                            Assert.Fail(facility.ToString() + " facility does not exist in organization " + organizations.ToString());
                            break;
                    }
                    break;
                //L&T Automated Eye Test
                case LandingPage.Organizations.LNTAutomatedEyeTest:
                    switch (facility)
                    {
                        case LandingPage.Facility.Test1:
                            facilityWebElement =LNTAutomatedEyeTestOrganizationFacilityTest1Title;
                            break;
                        default:
                            Assert.Fail(facility.ToString() + " facility does not exist in organization " + organizations.ToString());
                            break;
                    }
                    break;

                default:
                    Assert.Fail(organizations.ToString() + " organization does not exists.");
                    break;
            }

            //Move the element till visible
            SetMethods.MoveTotheElement(facilityWebElement,driver, "Organization " + organizations.ToString() + " and facility "+facility.ToString());
            facilityWebElement.Click();
            wait.Message = "Asset list is not displayed in the Main Page.";
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
        }
    }
}
