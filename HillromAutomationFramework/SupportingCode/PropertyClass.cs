using System;

namespace HillromAutomationFramework.SupportingCode
{
    class PropertyClass
    {

        /// <summary>
        /// Base URL of the application under test.
        /// </summary>
        public static string BaseURL = Environment.GetEnvironmentVariable("BaseURL");


        /// <summary>
        /// Version number of AUT
        /// </summary>
        public static string VersionNumber = Environment.GetEnvironmentVariable("ApplicationVersionNumber");

        /// <summary>
        /// Name of the browser to run tests.
        /// </summary>
        public static string BrowserName = Environment.GetEnvironmentVariable("BrowserName");

        /// <summary>
        /// Current Working Directory i.e. //bin
        /// </summary>
        static readonly string workingDirectory = Environment.CurrentDirectory;

        /// <summary>
        /// Extent Report Path
        /// </summary>
        readonly public static string extentReportPath = workingDirectory + "\\TestResults\\index.html";


        /// <summary>
        /// Download folder path of the browser.
        /// </summary>
        public static string DownloadPath = workingDirectory + "\\Downloads";
    }
}