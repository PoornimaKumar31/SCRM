using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HillromAutomationFramework.Coding.PageObjects
{
    class LandingPage
    {
        public LandingPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        public static class Locator
        {

            //Organization and facility XPath

            //L&T Automated Test East Organization
            public const string LNTAutomatedTestEastOrganizationTitleXPath = "//span[text()='"+ExpectedValues.LNTAutomatedTestEastOrganizationTitle+"']";
            public const string LNTAutomatedTestEastOrganizationFacilityPanelTest4TitleXpath = LNTAutomatedTestEastOrganizationTitleXPath + "//parent::div//parent::div//span[text()='"+ExpectedValues.LNTAutomatedTestEastOrganizationFacilityTest4+"']";
            public const string Organization0Facility0ServerID = "serv00";
            public const string Organization0Facility0DeviceID = "dev00";

            //L&T Automated Test Organization
            public const string LNTAutomatedTestOrganizationTitleXPath = "//span[text()='" + ExpectedValues.LNTAutomatedTestOrganizationTitle + "']";
            //L&T Automated Test Organization facility test1
            public const string LNTAutomatedTestOrganizationFacilityTest1TitleXPath = LNTAutomatedTestOrganizationTitleXPath + "//parent::div//parent::div//span[text()='"+ExpectedValues.LNTAutomatedTestOrganizationFacilityTest1+"']";
            public const string Organization1Facility0ServerID = "serv10";
            public const string Organization1Facility0DeviceID = "dev10";

            //L&T Automated Test Organization facility test2
            public const string LNTAutomatedTestOrganizationFacilityTest2TitleXPath = LNTAutomatedTestOrganizationTitleXPath + "//parent::div//parent::div//span[text()='" + ExpectedValues.LNTAutomatedTestOrganizationFacilityTest2 + "']";
            public const string Organization1Facility1ServerID = "serv11";
            public const string Organization1Facility1DeviceID = "dev11";

            //L&T Automated Eye Test Organization
            public const string LNTAutomatedEyeTestOrganizationTitleXPath = "//span[text()='" + ExpectedValues.LNTAutomatedEyeTestOrganizationTitle + "']";
            public const string LNTAutomatedEyeTestOrganizationFacilityTest1TitleXPath=LNTAutomatedEyeTestOrganizationTitleXPath+ "//parent::div//parent::div//span[text()='" + ExpectedValues.LNTAutomatedEyeTestOrganizationFacilityTest1 + "']";
            public const string Organization2Facility0ServerID = "serv20";
            public const string Organization2Facility0DeviceID = "dev20";

            //EDEN HOSPITAL MEDICAL CENTER 602412
            public const string EdenHospitalMedicalCenterOrganizationTitleXpath = "//span[text()='" + ExpectedValues.EdenHospitalMedicalCenterOrganizationTitle + "']";
            public const string EdenHospitalMedicalCenterOrganizationFacilityMedicalCenterXpath= EdenHospitalMedicalCenterOrganizationTitleXpath + "//parent::div//parent::div//span[text()='" + ExpectedValues.EdenHospitalMedicalCenterOrganizationFacilityMedicalCenter + "']";

            //Header elements
            public const string UserNameLogoID = "userprofile_logo";
            public const string LogOutButtonID = "logout";
            public const string HeaderLogoID = "servicehub_logo";
         
        }
        public static class ExpectedValues
        {
            public static string RollupPageURL = PropertyClass.BaseURL + "/index.html#/rollup-page";

            //L&T Automated East Organization details
            public const string LNTAutomatedTestEastOrganizationTitle = "L&T Automated Test East";
            public const string LNTAutomatedTestEastOrganizationFacilityTest4 = "Test4";

            ///L&T Automated Test Organization details
            public const string LNTAutomatedTestOrganizationTitle = "L&T Automated Test";
            public const string LNTAutomatedTestOrganizationFacilityTest1 = "Test1";
            public const string LNTAutomatedTestOrganizationFacilityTest2 = "Test2";

            //L&T Automated Eye Test Organization
            public const string LNTAutomatedEyeTestOrganizationTitle = "LT Automated Eye Test";
            public const string LNTAutomatedEyeTestOrganizationFacilityTest1 = "Test1";

            //EDEN HOSPITAL MEDICAL CENTER 602412
            public const string EdenHospitalMedicalCenterOrganizationTitle = "EDEN HOSPITAL MEDICAL CENTER 602412";
            public const string EdenHospitalMedicalCenterOrganizationFacilityMedicalCenter = "EDEN HOSPITAL MEDICAL CENTER";
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


        ////L&T Automated Eye Test Organization
        [FindsBy(How = How.XPath, Using = Locator.LNTAutomatedEyeTestOrganizationTitleXPath)]
        public IWebElement LNTAutomatedEyeTestOrganizationTitle { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.LNTAutomatedEyeTestOrganizationFacilityTest1TitleXPath)]
        public IWebElement LNTAutomatedEyeTestOrganizationFacilityTest1Title { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization2Facility0ServerID)]
        public IWebElement Organization2Facility0Server { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization2Facility0DeviceID)]
        public IWebElement Organization2Facility0Device { get; set; }

        //EDEN HOSPITAL MEDICAL CENTER 602412
        [FindsBy(How = How.XPath, Using = Locator.EdenHospitalMedicalCenterOrganizationTitleXpath)]
        public IWebElement EdenHospitalMedicalCenterOrganizationTitle { get; set; }

        [FindsBy(How = How.XPath, Using = Locator.EdenHospitalMedicalCenterOrganizationFacilityMedicalCenterXpath)]
        public IWebElement EdenHospitalMedicalCenterOrganizationFacilityMedicalCenter { get; set; }

    }
}
