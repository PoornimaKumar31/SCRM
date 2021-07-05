using HillromAutomationFramework.Coding.SupportingCode;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HillromAutomationFramework.Coding.PageObjects
{
    class CSMDeviceDetailsPage
    {
        public CSMDeviceDetailsPage()
        {
            PageFactory.InitElements(PropertyClass.Driver, this);
        }

        public static class Locator
        {
            public const string LogsButtonXpath = "//*[@id=\"device-main\"]/div[2]/div/div/div[3]";
            public const string LogFilesID = "device-details";
        }

        [FindsBy(How = How.XPath, Using = Locator.LogsButtonXpath)]
        public IWebElement LogsButton { get; set; }

        [FindsBy(How = How.Id, Using = Locator.LogFilesID)]
        public IWebElement LogFiles { get; set; }

        [FindsBy(How = How.Id, Using = "555566667777")]
        public IList<IWebElement> CSMDevices { get; set; }
    }
}
