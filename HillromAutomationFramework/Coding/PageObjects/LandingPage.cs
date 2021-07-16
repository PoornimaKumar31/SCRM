﻿using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

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
            public const string Organization0TitleID = "org0";
            public const string Organization0FacilityPanel0ID = "fac00";
            public const string Organization0Facility0TitleID = "facName00";
            public const string Organization0Facility0ServerID = "serv00";
            public const string Organization0Facility0DeviceID = "dev00";
            public const string Organization0FacilityPanel1ID = "fac01";
            public const string Organization0Facility1TitleID = "facName01";
            public const string Organization0Facility1ServerID = "serv01";
            public const string Organization0Facility1DeviceID = "dev01";

            public const string Organization1TitleID = "org1";
            public const string Organization1FacilityPanel0ID = "fac10";
            public const string Organization1Facility0TitleID = "facName10";
            public const string Organization1Facility0ServerID = "serv10";
            public const string Organization1Facility0DeviceID = "dev10";

            public const string UserNameLogoID = "userprofile_logo";
            public const string LogOutButtonID = "logout";
            public const string HeaderLogoID = "servicehub_logo";
         
        }
        public static class ExpectedValues
        {
            public const string RollupPageURL = "https://incubator.deviot.hillrom.com/apps/remotemanagement-centrella/index.html#/rollup-page";

            //Organizaion1 details
            //Facility Panel1
            public const string Organization0Title = "L&T Automated Test";
            public const string Organization0FacilityPanel0Title = "Test1";

            //Facility Panel2
            public const string Organization0FacilityPanel1Title = "Test2";

            //Organization2 details
            public const string Organization1Title = "LT Automated Eye Test";
            public const string Organization1FacilityPanel0Title = "Test1";
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

        //Organization0facility1
        [FindsBy(How = How.Id, Using = Locator.Organization0FacilityPanel1ID)]
        public IWebElement Organization0FacilityPaneel1 { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization0Facility1TitleID)]
        public IWebElement Organization0Facility1Title { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization0Facility1ServerID)]
        public IWebElement Organization0Facility1Server { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization0Facility1DeviceID)]
        public IWebElement Organization0Facility1Device { get; set; }

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

    }
}
