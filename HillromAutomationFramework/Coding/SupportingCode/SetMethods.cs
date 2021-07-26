using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public static void DoubleClick(this IWebElement element)
        {
            Actions actions = new Actions(PropertyClass.Driver);
            actions.DoubleClick(element).Perform();
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
            List<DateTime> FormatedDateList = new List<DateTime>();
            foreach (IWebElement element in dateList)
            {
                if (element.Text != "Date")
                {

                    FormatedDateList.Add(DateTime.Parse(element.Text));
                    
                }
            }
            Console.WriteLine("Now Normal List That displayed : \n\n");
            foreach(DateTime a in FormatedDateList)
            {
                Console.WriteLine(a+"   ");
            }

            List<DateTime> SortedList = new List<DateTime>(FormatedDateList);
            SortedList.Sort();
            if (typeOfSort.ToLower() == "d")
            {
                SortedList.Reverse();
            }
            Console.WriteLine("Now Sorted List\n\n");
            foreach(DateTime a in SortedList)
            {
                Console.WriteLine(a+"   ");
            }

            return SortedList.SequenceEqual(FormatedDateList);
            
        }

        public static List<DateTime> GetSortedLogs(List<DateTime> AllDateList,string typeOfSort = "a")
        {
            if (typeOfSort.ToLower() == "d")
            {
                AllDateList.Sort();
                return AllDateList;
            }
            else
            {
                AllDateList.Sort();
                AllDateList.Reverse();
                return AllDateList;
            }
        }
    }
}
