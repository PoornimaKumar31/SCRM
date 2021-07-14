using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

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

        //Clicking using javascipt
        public static void JavaSciptClick(this IWebElement webElement)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)PropertyClass.Driver;
            executor.ExecuteScript("arguments[0].click()", webElement);
        }

        //scroll till bottom of page
        public static void ScrollToBottomofWebpage()
        {
            long scrollHeight = 0;
            do
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)(PropertyClass.Driver);
                var newScrollHeight = (long)js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight); return document.body.scrollHeight;");
                if (newScrollHeight == scrollHeight)
                {
                    break;
                }
                else
                {
                    scrollHeight = newScrollHeight;
                    Thread.Sleep(400);
                }
            } while (true);
        }

        /*for selecting value from drop down list*/
        public static void SelectDDL(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }

        public static bool isDateSorted(this IList<IWebElement> dateList, string typeOfSort = "a")
        {
            List<string> ActualDateList = new List<string>();

            foreach (IWebElement i in dateList)
            {
                if (i.Text != "Date")
                {
                    ActualDateList.Add(i.Text);
                }
            }

            List<DateTime> FormatedDateList = new List<DateTime>();
            for (int i = 0; i < ActualDateList.Count; i++)
            {
                FormatedDateList.Add(DateTime.Parse(ActualDateList[i]));
            }

            List<DateTime> SortedList = new List<DateTime>(FormatedDateList);
            SortedList.Sort();
            if (typeOfSort.ToLower() == "d")
            {
                SortedList.Reverse();
            }
            if (SortedList == FormatedDateList)
            {
                return true;
            }
            else
                return false;
        }
    }
}
