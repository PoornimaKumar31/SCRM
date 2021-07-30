using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HillromAutomationFramework.Coding.SupportingCode
{
    public static class GetMethods
    {
        /*for getting the value from text field*/
        public static string GetTextFromField(this IWebElement element)
        {
            return element.Text;
        }

        /*for getting the value from Drop Down List*/
        public static string GetSelectedOptionFromDDL(this IWebElement element)
        {
            return new SelectElement(element).SelectedOption.Text;
        }

        //Geting the dropdownoptions
        public static IList<IWebElement> GetAllOptionsFromDDL(this IWebElement element)
        {
            return new SelectElement(element).Options;
        }

        // Takes screenshot of current screen.
        public static MediaEntityModelProvider CaptureScreenshot(this string name)
        {
            var screenshot = ((ITakesScreenshot)PropertyClass.Driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, name).Build();
        }

        //Get element visibilty
        public static bool GetElementVisibility(this IWebElement element)
        {
            try
            {
                return (element.Displayed);
            }catch(Exception)
            {
                return (false);
            }
        }

        public static int GetElementCount(this IList<IWebElement> webElement)
        {
            try
            {
                return (webElement.Count);
            }catch(Exception)
            {
                return (0);
            }
        }

        public static bool IsReadOnly(this IWebElement webElement)
        {
            try
            {
                webElement.SendKeys("Text");
                return (false);
            }catch(Exception)
            {
                return (true);
            }
        }

        //Verify File is downloaded with in specified time
        public static bool IsFileDownloaded(string fileName, int waitTime)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(PropertyClass.DownloadPath + "\\");
            //Delete all files in download folder
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                file.Delete();
            }

            bool file_exist = false;
            int count = 0;
            while (file_exist != true && count <= waitTime)
            {
                Task.Delay(1000).Wait();
                count++;
                if (File.Exists(PropertyClass.DownloadPath + "\\" + fileName))
                {
                    file_exist = true;
                }
            }
            return (file_exist);
        }

        public static bool CheckFileFormat(string fileExtension)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(PropertyClass.DownloadPath + "\\");
            FileInfo[] fileInfo = directoryInfo.GetFiles();
            return (fileInfo[0].Extension == fileExtension);
        }


        public static bool ErrorMessageVerification(this IWebElement element)
        {
            if(element.Text == "Log file request - EXECUTING" || element.Text == "Log file request - PENDING" || element.Text == "Log file request - RECEIVED")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
