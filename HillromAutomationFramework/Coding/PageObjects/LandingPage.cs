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
            public const string LandingPageTileID = "card";
            public const string LandingPageUserNameLogoID = "userprofile_logo";
            public const string LandingPageLogOutButtonID = "logout";

            public const string OrganizationalTitleID = "organization_title";
            public const string HeaderLogoID = "servicehub_logo";
            public const string OrganizationID = "org0";
            public const string OrganizationCardID = "card";
        }


        /// Landing page user name logo
        [FindsBy(How = How.Id, Using = Locator.LandingPageUserNameLogoID)]
        public IWebElement LandingPageUserNameLogo { get; set; }

        // Landing page logout button
        [FindsBy(How = How.Id, Using = Locator.LandingPageLogOutButtonID)]
        public IWebElement LandingPageLogOutButton { get; set; }

        [FindsBy(How = How.Id, Using = Locator.OrganizationID)]
        public IList<IWebElement> TileList { get; set; }

    }
}
