using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HillromAutomationFramework.Coding.SupportingCode
{
    public static class SetMethods
    {
        /*for entering text in text field*/
        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }


        /*for clicking web element*/
        public static void Clicks(this IWebElement element)
        {
            element.Click();
        }

        /*for selecting value from drop down list*/
        public static void SelectDDL(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }
    }
}
