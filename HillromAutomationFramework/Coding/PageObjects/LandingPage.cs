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

        public static class locators
        {
            public const string OrganizationalTitleID = "organization_title";
            public const string HeaderLogoID = "servicehub_logo";
            public const string OrganizationID = "org0";
            public const string OrganizationCardID = "card";
        }

        [FindsBy(How = How.Id, Using = locators.OrganizationID)]
        public IList<IWebElement> TileList { get; set; }

    }
}
