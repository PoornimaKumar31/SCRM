using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace HillromAutomationFramework.SupportingCode
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
        /// <param name="driver">web driver of the browser</param>
        public static void DoubleClick(this IWebElement element,IWebDriver driver)
        {
            try
            {
                Actions actions = new Actions(driver);
                actions.DoubleClick(element).Perform();
            }
            catch (Exception e)
            {
                Assert.Fail("Exception has occured.\n"+e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element">element to click on</param>
        /// <param name="driver">web driver of the browser</param>
        /// <param name="elementName">name of the element</param>
        public static void ClickWebElement(this IWebElement element, IWebDriver driver, string elementName="Webelement")
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15))
            {
                Message = elementName + " element is not clickable."
            };
            try
            {
                Actions actions = new Actions(driver);
                actions.MoveToElement(element);
                actions.Perform();

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                element.Click();
            }
            catch (Exception e)
            {
                Assert.Fail(" Exception Occured\n"+e);
            }

        }

        /// <summary>
        /// Clicking on a element using javascipt
        /// </summary>
        /// <param name="webElement">WebElement to click.</param>
        /// <param name="driver">web driver of the browser</param>
        public static void JavaSciptClick(this IWebElement webElement,IWebDriver driver)
        {
            try
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                executor.ExecuteScript("arguments[0].click()", webElement);
            }
            catch (Exception e)
            {
                Assert.Fail("Unable to click on the element using javascript.\n"+ e.Message);
            }

        }

        /// <summary>
        /// Scroll to the bottom of webpage.
        /// </summary>
        /// <param name="driver">web driver of the browser</param>
        public static void ScrollToBottomofWebpage(IWebDriver driver)
        {
            long scrollHeight = 0;
            try
            {
                do
                {
                    IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)(driver);
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
                Assert.Fail("Unable to scroll to bottom of the webpage.\n " + e.Message);
            }
        }

        /// <summary>
        /// Scroll till the element is visible and clickable
        /// </summary>
        /// <param name="element">element where th web page has to move</param>
        /// <param name="elementName"></param>
        public static void MoveTotheElement(this IWebElement element,IWebDriver driver,string elementName = "WebElement")
        {
            Actions actions = new Actions(driver);
            try
            {
                actions.MoveToElement(element);
                actions.Perform();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                {
                    Message = "The" + elementName + " is not visible and unable to click on it"
                };
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            }
            catch(Exception e)
            {
                Assert.Fail("Unable to move to the element "+elementName+"\n"+e.Message);
            }
            
        }

        /// <summary>
        /// Scroll up web page
        /// </summary>
        public static void ScrollUpWebPage(IWebDriver driver)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollTo(0, 0)");
            }
            catch (Exception e)
            {

                Assert.Fail("Unable to scoll to the top of the webpage.\n"+e.Message);
            }
            
        }

        /// <summary>
        /// For selecting option from the dropdown list.
        /// </summary>
        /// <param name="element">Dropdown WebElement</param>
        /// <param name="value">Option text to select.</param>
        public static void SelectDDL(this IWebElement element, string value,bool partialMatch=false)
        {
            try
            {
                new SelectElement(element).SelectByText(value,partialMatch);
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
        /// <returns>true if dates are sorted in specified order, else false</returns>
        public static bool IsDateSorted(this IList<IWebElement> dateList, string typeOfSort = "a")
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

        /// <summary>
        /// Wait for a specified time interval  untill two strings are equal.
        /// </summary>
        /// <param name="FirstString">First string to compare</param>
        /// <param name="SecoundString">Second string to compare</param>
        /// <param name="maxRetryCount">Maximum retry count</param>
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

            bool boolReturnValue = (FirstString.Equals(SecoundString));
            if (!boolReturnValue)
            {
                throw new ApplicationException("strings are not equal. Timedout after 10 Seconds");
            }
        }

        /// <summary>
        /// Wait's until new window is opened for a specified time interval
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="ExpectedNumberOfWindows"></param>
        /// <param name="maxRetryCount"></param>
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


