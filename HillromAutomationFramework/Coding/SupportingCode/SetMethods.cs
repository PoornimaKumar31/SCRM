using NUnit.Framework;
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

            try
            {
                element.SendKeys(value);
            }

            catch (Exception e)
            {
                Assert.Fail("Exception has occured.\n"+e.Message);

            }

        }

        /// <summary>
        /// Double clicks on the webelement.
        /// </summary>
        /// <param name="element">Webelement to double click.</param>
        public static void DoubleClick(this IWebElement element)
        {
            try
            {
                Actions actions = new Actions(PropertyClass.Driver);
                actions.DoubleClick(element).Perform();
            }
            catch (Exception e)
            {
                Assert.Fail("Exception has occured.\n"+e.Message);
            }
        }

        public static void ClickWebElement(this IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

            try
            {
                Actions actions = new Actions(PropertyClass.Driver);
                actions.MoveToElement(element);
                actions.Perform();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                element.Click();
            }
            catch (Exception e)
            {
                Assert.Fail(e + " Exception Occured");
            }

        }

        /// <summary>
        /// Clicking on a element using javascipt
        /// </summary>
        /// <param name="webElement">WebElement to click.</param>
        public static void JavaSciptClick(this IWebElement webElement)
        {
            try
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)PropertyClass.Driver;
                executor.ExecuteScript("arguments[0].click()", webElement);
            }
            catch (Exception e)
            {
                Console.WriteLine(e + " Exceptions Occured");
            }

        }

        /// <summary>
        /// Scroll to the bottom of webpage.
        /// </summary>
        public static void ScrollToBottomofWebpage()
        {
            long scrollHeight = 0;
            try
            {
                do
                {
                    IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)(PropertyClass.Driver);
                    var newScrollHeight = (long)javaScriptExecutor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight); return document.body.scrollHeight;");
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
            catch(Exception e)
            {
                Console.WriteLine(e+" Exception Occured");
            }
        }

        /// <summary>
        /// Scroll till the element is visible and clickable
        /// </summary>
        /// <param name="element"></param>
        /// <param name="elementName"></param>
        public static void MoveTotheElement(this IWebElement element,string elementName = "WebElement")
        {
            Actions actions = new Actions(PropertyClass.Driver);
            try
            {
                actions.MoveToElement(element);
                actions.Perform();
                WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10))
                {
                    Message = "The" + elementName + " is not visible and unable to click on it"
                };
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            }
            catch(Exception e)
            {
                Console.WriteLine(e+" Exception Occured");
            }
            
        }

        /// <summary>
        /// Scroll up web page
        /// </summary>
        public static void ScrollUpWebPage()
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)PropertyClass.Driver;
                js.ExecuteScript("window.scrollTo(0, 0)");
            }
            catch (Exception e)
            {

                Assert.Fail("Exception has occured.\n"+e.Message);
            }
            
        }

        /// <summary>
        /// For selecting option from the dropdown list.
        /// </summary>
        /// <param name="element">Dropdown WebElement</param>
        /// <param name="value">Option text to select.</param>
        public static void SelectDDL(this IWebElement element, string value)
        {
            try
            {
                new SelectElement(element).SelectByText(value);
            }
            catch(Exception e)
            {
                Assert.Fail("Exception has occured.\n"+e.Message);
            }
            
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

            List<DateTime> SortedList = new List<DateTime>(FormatedDateList);
            SortedList.Sort();
            if (typeOfSort.ToLower() == "d")
            {
                SortedList.Reverse();
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

        public static void WaitUntilTwoStringsAreEqual(string FirstString, string SecoundString,int maxRetryCount = 100)
        {
            FirstString = FirstString.ToLower().Trim();
            SecoundString = SecoundString.ToLower().Trim();

            for (var i = 0; i < maxRetryCount; Thread.Sleep(100), i++)
            {
                if(FirstString.Equals(SecoundString))
                {
                    return;
                }
            }

            bool boolReturnValue = (FirstString.Equals(SecoundString) ? true : false);
            if (!boolReturnValue)
            {
                throw new ApplicationException("strings are not equal. Timedout after 10 Seconds");
            }
        }


        public static void WaitUntilNewWindowIsOpened(this IWebDriver driver, int ExpectedNumberOfWindows, int maxRetryCount = 100)
        {
            int ActualNumberofWindows;
            bool boolReturnValue;
            for (var i = 0; i < maxRetryCount; Thread.Sleep(100), i++)
            {
                ActualNumberofWindows = driver.WindowHandles.Count;
                boolReturnValue = (ActualNumberofWindows == ExpectedNumberOfWindows);
                if (boolReturnValue)
                {
                    return;
                }
            }
            //try one last time to check for window
            ActualNumberofWindows = driver.WindowHandles.Count;
            boolReturnValue = (ActualNumberofWindows == ExpectedNumberOfWindows ? true : false);
            if (!boolReturnValue)
            {
                throw new ApplicationException("New window did not open.");
            }
        }
    }
}


