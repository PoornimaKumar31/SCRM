using HillromAutomationFramework.Coding.SupportingCode;
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
            public const string Organization01Facility01TileID = "fac00";
            public const string Organization01Facility02TileID = "fac01";
            public const string Organization02Facility01TileID = "fac10";
            public const string UserNameLogoID = "userprofile_logo";
            public const string LogOutButtonID = "logout";
            public const string OrganizationalTitleID = "organization_title";
            public const string HeaderLogoID = "servicehub_logo";
         
        }


        /// Landing page user name logo
        [FindsBy(How = How.Id, Using = Locator.UserNameLogoID)]
        public IWebElement UserNameLogo { get; set; }

        // Landing page logout button
        [FindsBy(How = How.Id, Using = Locator.LogOutButtonID)]
        public IWebElement LogOutButton { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization01Facility01TileID)]
        public IWebElement Organization01Facility01Tile { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization01Facility02TileID)]
        public IWebElement Organization01Facility02Tile { get; set; }

        [FindsBy(How = How.Id, Using = Locator.Organization02Facility01TileID)]
        public IWebElement Organization02Facility01Tile { get; set; }

    }
}
