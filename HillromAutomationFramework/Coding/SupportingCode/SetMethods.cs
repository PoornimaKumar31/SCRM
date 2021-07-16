using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

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

                    FormatedDateList.Add(DateTime.Parse(element.Text)); ;
                }
            }

            List<DateTime> SortedList = new List<DateTime>(FormatedDateList);
            SortedList.Sort();
            if (typeOfSort.ToLower() == "d")
            {
                SortedList.Reverse();
            }
            if (SortedList.Equals(FormatedDateList))
            {
                return true;
            }
            else
                return false;
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
