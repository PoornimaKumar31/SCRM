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
            //Organization1
            public const string LNTAutomatedTestEastOrganizationTitleXPath = "//span[text()="+ExpectedValues.LNTAutomatedTestEastOrganizationTitle+"]";
            public const string Organization0FacilityPanel0ID = "fac00";
            public const string Organization0Facility0TitleID = "facName00";
            public const string Organization0Facility0ServerID = "serv00";
            public const string Organization0Facility0DeviceID = "dev00";

            
            //Organization2
            public const string LNTAutomatedTestOrganizationTitleXPath = "//span[text()=" + ExpectedValues.LNTAutomatedTestOrganizationTitle + "]";
            public const string LNTAutomatedTestOrganizationFacilityTest1XPath = LNTAutomatedTestEastOrganizationTitleXPath +"//parent::div//parent::div//span[text()="+ExpectedValues.LNTAutomatedTestOrganizationFacilityTest1+"]";
            public const string LNTAutomatedTestOrganizationFacilityTest2 = LNTAutomatedTestEastOrganizationTitleXPath + "//parent::div//parent::div//span[text()=" + ExpectedValues.LNTAutomatedTestOrganizationFacilityTest2+"]";
            public const string Organization1Facility0ServerID = "serv10";
            public const string Organization1Facility0DeviceID = "dev10";

           
            public const string Organization1FacilityPanel1ID = "fac11";
            public const string Organization1Facility1TitleID = "facName11";
            public const string Organization1Facility1ServerID = "serv11";
            public const string Organization1Facility1DeviceID = "dev11";

            //Organization3
            public const string Organization2TitleID = "//span[text()=" + ExpectedValues.LNTAutomatedEyeTestOrganizationTitle + "]";
            public const string Organization2FacilityPanel0ID = "fac20";
            public const string Organization2Facility0TitleID = "facName20";
            public const string Organization2Facility0ServerID = "serv20";
            public const string Organization2Facility0DeviceID = "dev20";


            //Organization and facility XPath;
            




            public const string UserNameLogoID = "userprofile_logo";
            public const string LogOutButtonID = "logout";
            public const string HeaderLogoID = "servicehub_logo";
         
        }
        public static class ExpectedValues
        {
            public static string RollupPageURL = PropertyClass.BaseURL + "/rollup-page";

            //L&T Automated East Organization details
            public const string LNTAutomatedTestEastOrganizationTitle = "L&T Automated Test East";
            public const string LNTAutomatedTestEastOrganizationFacilityTest4 = "Test4";

            //Organization2 details
            public const string LNTAutomatedTestOrganizationTitle = "L&T Automated Test";
            public const string LNTAutomatedTestOrganizationFacilityTest1 = "Test1";
            public const string LNTAutomatedTestOrganizationFacilityTest2 = "Test2";

            //Organizaion3 details
            public const string LNTAutomatedEyeTestOrganizationTitle = "LT Automated Eye Test";
            public const string LNTAutomatedEyeTestOrganizationFacilityTest1 = "Test1";
        }


        /// Landing page user name logo
        [FindsBy(How = How.Id, Using = Locator.UserNameLogoID)]
        public IWebElement UserNameLogo { get; set; }

        // Landing page logout button
        [FindsBy(How = How.Id, Using = Locator.LogOutButtonID)]
        public IWebElement LogOutButton { get; set; }

        
        [FindsBy(How =How.Id, Using = Locator.Organization0TitleID)]
        public IWebElement Organization0Title { get; set; }

        //organization0facility0
        [FindsBy(How =How.Id, Using = Locator.Organization0FacilityPanel0ID)]
        public IWebElement Organization0FacilityPaneel0 { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization0Facility0TitleID)]
        public IWebElement Organization0Facility0Title { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization0Facility0ServerID)]
        public IWebElement Organization0Facility0Server { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization0Facility0DeviceID)]
        public IWebElement Organization0Facility0Device { get; set; }

        

        //organization1facility0
        [FindsBy(How = How.Id, Using = Locator.Organization1TitleID)]
        public IWebElement Organization1Title { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization1FacilityPanel0ID)]
        public IWebElement Organization1FacilityPaneel0 { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization1Facility0TitleID)]
        public IWebElement Organization1Facility0Title { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization1Facility0ServerID)]
        public IWebElement Organization1Facility0Server { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization1Facility0DeviceID)]
        public IWebElement Organization1Facility0Device { get; set; }

        //Organization1facility1
        [FindsBy(How = How.Id, Using = Locator.Organization1FacilityPanel1ID)]
        public IWebElement Organization1FacilityPaneel1 { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization1Facility1TitleID)]
        public IWebElement Organization1Facility1Title { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization1Facility1ServerID)]
        public IWebElement Organization1Facility1Server { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization1Facility1DeviceID)]
        public IWebElement Organization1Facility1Device { get; set; }


        //organization2facility0
        [FindsBy(How = How.Id, Using = Locator.Organization2FacilityPanel0ID)]
        public IWebElement Organization2FacilityPaneel0 { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization2Facility0TitleID)]
        public IWebElement Organization2Facility0Title { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization2Facility0ServerID)]
        public IWebElement Organization2Facility0Server { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization2Facility0DeviceID)]
        public IWebElement Organization2Facility0Device { get; set; }


    }
}
