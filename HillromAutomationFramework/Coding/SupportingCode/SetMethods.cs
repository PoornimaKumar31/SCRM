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
        /// <summary>
        /// For entering text in text field.
        /// </summary>
        /// <param name="element">WebElement to enter text.</param>
        /// <param name="value">Text to enter.</param>
        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        /// <summary>
        /// Double clicks on the webelement.
        /// </summary>
        /// <param name="element">Webelement to double click.</param>
        public static void DoubleClick(this IWebElement element)
        {
            Actions actions = new Actions(PropertyClass.Driver);
            actions.DoubleClick(element).Perform();
        }

        /// <summary>
        /// Clicking on a element using javascipt
        /// </summary>
        /// <param name="webElement">WebElement to click.</param>
        public static void JavaSciptClick(this IWebElement webElement)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)PropertyClass.Driver;
            executor.ExecuteScript("arguments[0].click()", webElement);
        }

        /// <summary>
        /// Scroll to the bottom of webpage.
        /// </summary>
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

        /// <summary>
        /// Scroll up web page
        /// </summary>
        public static void ScrollUpWebPage()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)PropertyClass.Driver;
            js.ExecuteScript("window.scrollTo(0, 0)");
        }

        /// <summary>
        /// For selecting option from the dropdown list.
        /// </summary>
        /// <param name="element">Dropdown WebElement</param>
        /// <param name="value">Option text to select.</param>
        public static void SelectDDL(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }

        /// <summary>
        /// Check if date is sorted.
        /// </summary>
        /// <param name="dateList">List of dates</param>
        /// <param name="typeOfSort">acensing or descending</param>
        /// <returns></returns>
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
        /// <summary>
        /// Sorting the logs.
        /// </summary>
        /// <param name="AllDateList">List of dates of log files.</param>
        /// <param name="typeOfSort">Type of sorting ascending or desecnding.</param>
        /// <returns></returns>
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


