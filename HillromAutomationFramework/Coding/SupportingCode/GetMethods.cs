using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace HillromAutomationFramework.Coding.SupportingCode
{
    public static class GetMethods
    {
        /// <summary>
        ///  Gets the value from text field
        /// </summary>
        /// <param name="element">Element from which text needs to be extracted.</param>
        /// <returns>Text from the webelement</returns>
        public static string GetTextFromField(this IWebElement element)
        {
            return element.Text;
        }

        /// <summary>
        /// For getting the selected option from Drop Down.
        /// </summary>
        /// <param name="element">Dropdown Element</param>
        /// <returns>selected option from the dropdown.</returns>
        public static string GetSelectedOptionFromDDL(this IWebElement element)
        {
            return new SelectElement(element).SelectedOption.Text;
        }

        /// <summary>
        /// Geting the dropdownoptions
        /// </summary>
        /// <param name="element">Dropdown Element</param>
        /// <returns>Dropdown options as list of webelements.</returns>
        public static IList<IWebElement> GetAllOptionsFromDDL(this IWebElement element)
        {
            return new SelectElement(element).Options;
        }

        /// <summary>
        /// Takes screenshot of current screen in base 64 format
        /// </summary>
        /// <param name="name">Screenshot name</param>
        /// <returns>Screenshot in media entity builder format.</returns>
        public static MediaEntityModelProvider CaptureScreenshotBase64(this string name)
        {
            var screenshot = ((ITakesScreenshot)PropertyClass.Driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, name).Build();
        }

        /// <summary>
        /// Check if element is displayed or not.
        /// </summary>
        /// <param name="element">Web element to check visibility.</param>
        /// <returns>true if element is displayed.</returns>
        public static bool GetElementVisibility(this IWebElement element)
        {
            try
            {
                return (element.Displayed);
            }
            catch (Exception)
            {
                return (false);
            }
        }

        /// <summary>
        /// Getting total element 
        /// </summary>
        /// <param name="webElement"></param>
        /// <returns>Count of element matching the locator</returns>
        public static int GetElementCount(this IList<IWebElement> webElementList)
        {
            try
            {
                return (webElementList.Count);
            }
            catch (Exception)
            {
                return (0);
            }
        }

        /// <summary>
        /// Check if the element is readonly.
        /// </summary>
        /// <param name="webElement"></param>
        /// <returns>true if element is readonly, else false</returns>
        public static bool IsReadOnly(this IWebElement webElement)
        {
            try
            {
                webElement.SendKeys("Text");
                return (webElement.GetAttribute("readonly") == "true");

            }
            catch (Exception)
            {
                return (true);
            }
        }

        /// <summary>
        /// Verify File is downloaded with in specified time
        /// </summary>
        /// <param name="fileName">Name of the downloaded file</param>
        /// <param name="waitTime">Time to wait untill file is downloaded</param>
        /// <returns>true if file is downloaded, else return false</returns>
        public static bool IsFileDownloaded(string fileName, int waitTime)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(PropertyClass.DownloadPath + "\\");
            //Delete all files in download folder
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                file.Delete();
            }

            bool file_exist = false;
            int time = 0;
            //Wait till file is downloaded
            while (file_exist != true && time <= waitTime)
            {
                Task.Delay(1000).Wait();
                time++;
                if (File.Exists(PropertyClass.DownloadPath + "\\" + fileName))
                {
                    file_exist = true;
                }
            }
            return (file_exist);
        }

        /// <summary>
        /// Check the file format in the download folder.
        /// Pre-Condition: Only if the one file exists in the download folder. 
        /// </summary>
        /// <param name="fileExtension">extention of the file.</param>
        /// <returns>true if file extention matches the given extension</returns>
        public static bool CheckFileFormat(string fileExtension)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(PropertyClass.DownloadPath + "\\");
            FileInfo[] fileInfo = directoryInfo.GetFiles();
            return (fileInfo[0].Extension == fileExtension);
        }

        /// <summary>
        /// Checks the log file request.
        /// </summary>
        /// <param name="element"></param>
        /// <returns>true if the request message is matching the expected value, else return false.</returns>
        public static bool LogFilesRequestStatusMessageVerification(this IWebElement element)
        {
            if (element.Text == "Log file request - EXECUTING" || element.Text == "Log file request - PENDING" || element.Text == "Log file request - RECEIVED")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Generaye Random string of specified length.
        /// </summary>
        /// <param name="stringSize">String size</param>
        /// <returns>Random string of size stringSize</returns>
        public static string GenerateRandomString(int stringSize)
        {
            int length = stringSize;
            Random random = new Random();
            string str = "";
            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str += letter.ToString();
            }
            return str;
        }

        /// <summary>
        /// Generate random username.
        /// </summary>
        /// <param name="stringSize">String size</param>
        /// <returns>Random string of size stringSize</returns>
        public static string GenerateRandomUsername(int stringSize)
        {
            int length = stringSize;
            Random random = new Random();
            string str = "";
            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str += letter.ToString();
            }

            string str2 = "@hillrom.com";
            str2 = str.ToLower() + str2;
            return str2;
        }

        /// <summary>
        /// Generates Random N Digit Number
        /// </summary>
        /// <param name="n">Number of Digits Required</param>
        /// <returns>N Digit Random number</returns>
        public static string GenerateNDigitRandomNumber(int n)
        {
            Random randGen = new Random();
            int minValue = (int)Math.Pow(10, n - 1);
            int maxValue = (int)(Math.Pow(10, n) - 1);
            int randomNumber = randGen.Next(minValue, maxValue);

            return randomNumber.ToString();
        }

        public static string CleanString(string str)
        {
            str = string.Join("", str.Split('\n', '\r', '\t'));
            return str;
        }

        /// <summary>
        /// Coverts Local Time to UTC Time
        /// </summary>
        /// <param name="dateTime">Local Time</param>
        /// <returns>UTC Time</returns>
        public static string ConvertDateTimeLocalToUTC(string dateTime)
        {
            //Formating time of the appliaction
            DateTime FormatedDate = DateTime.Parse(dateTime);

            //converting into UTC(GMT)
            DateTime ConvertedUTCTime = TimeZoneInfo.ConvertTime(FormatedDate, TimeZoneInfo.Local, TimeZoneInfo.Utc);

            return ConvertedUTCTime.ToString("f");
        }


        /// <summary>
        /// Converts NewYork Time to UTC Time
        /// </summary>
        /// <param name="NYTime">NY Time</param>
        /// <returns>UTC Time</returns>
        public static string ConvertNewYorkTimetoUTC(string NYTime)
        {
            DateTime FormatedDate = DateTime.Parse(NYTime);

            return FormatedDate.AddHours(4).ToString("f");
        }


        /// <summary>
        /// Function to convert the RGB code to Hex color code
        /// </summary>
        /// <param name="R"></param>
        /// <param name="G"></param>
        /// <param name="B"></param>
        /// <returns>Hex colour code</returns>
        public static string ConvertRGBtoHex(int R, int G, int B)
        {
            if ((R >= 0 && R <= 255) &&
                (G >= 0 && G <= 255) &&
                (B >= 0 && B <= 255))
            {
                string hexCode = "#";
                hexCode += DecToHexa(R);
                hexCode += DecToHexa(G);
                hexCode += DecToHexa(B);

                return hexCode;
            }

            // The hex color code doesn't exist
            else
                return "-1";
        }

        /// <summary>
        /// Function to convert decimal to hexadecimal
        /// </summary>
        /// <param name="n"></param>
        /// <returns>Hex code</returns>
        public static string DecToHexa(int n)
        {
            // char array to store
            // hexadecimal number
            char[] hexaDeciNum = new char[2];

            // Counter for hexadecimal
            // number array
            int i = 0;
            while (n != 0)
            {

                // Storing remainder in
                // temp variable.
                int temp = n % 16;

                // Check if temp < 10
                if (temp < 10)
                {
                    hexaDeciNum[i] = (char)(temp + 48);
                    i++;
                }
                else
                {
                    hexaDeciNum[i] = (char)(temp + 55);
                    i++;
                }
                n /= 16;
            }
            string hexCode = "";

            if (i == 2)
            {
                hexCode += hexaDeciNum[0];
                hexCode += hexaDeciNum[1];
            }
            else if (i == 1)
            {
                hexCode = "0";
                hexCode += hexaDeciNum[0];
            }
            else if (i == 0)
                hexCode = "00";

            // Return the equivalent
            // hexadecimal color code
            return hexCode;
        }

        /// <summary>
        /// It returns Lists of months name starting from current months
        /// </summary>
        /// <returns>Aug,Sep,Oct,Nov,Dec,Jan,Feb,Mar,Apr,May,Jun,Jul</returns>
        public static List<string> GetMonthsName()
        {
            DateTime dt = DateTime.Now;
            var monthsList = new List<string>();
            for (int i = 1; i < 13; i++)
            {
                monthsList.Add(dt.ToString("MMM"));
                dt = dt.AddMonths(1);
            }
            return monthsList;
        }

    }
}