using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace HillromAutomationFramework.Coding.SupportingCode
{
    public static class GetMethods
    {
        /*for getting the value from text field*/
        public static string GetText(IWebElement element)
        {
            return element.GetAttribute("value");
        }

        /*for getting the value from Drop Down List*/
        public static string GetTextFromDDL(IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
        }

        // Takes screenshot of current screen.
        public static MediaEntityModelProvider CaptureScreenshot(this string name)
        {
            var screenshot = ((ITakesScreenshot)PropertyClass.Driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, name).Build();
        }


        //screenshots
        public static string GetScreenshot(string name)
        {
            var screenshot = ((ITakesScreenshot)PropertyClass.Driver).GetScreenshot();
            string screenshotfilename = $"{TestContext.CurrentContext.TestDirectory}\\{TestContext.CurrentContext.Test.MethodName}.png";//PropertyClass.screenshotFolder + name + ".png";
            screenshot.SaveAsFile(screenshotfilename, ScreenshotImageFormat.Png);
            return (screenshotfilename);
        }
    }
}
