using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;

namespace HillromAutomationFramework.Coding.SupportingCode
{
    class PropertyClass
    {
        //Initializing Driver
        public static IWebDriver Driver { get; set; }

        //Base URL
        public static string BaseURL = Environment.GetEnvironmentVariable("BaseURL");

        //Browser Name
        public static string BrowserName = Environment.GetEnvironmentVariable("BrowserName");

        //Configuration files
        public static ReadConfig readConfig;

        //Current Working Directory i.e. //bin
        static readonly string workingDirectory = Environment.CurrentDirectory;

        //Current Project Directory i.e. //HillRomAutomation
        public static string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

        //Extent Report Path
        readonly public static string extentReportPath = Environment.CurrentDirectory+"\\TestResults\\ExtentReport.html";//TestContext.CurrentContext.TestDirectory + "\\TestResults\\ExtentReport.html";//@projectDirectory + "\\Reports\\ExtentReport.html";

        //Screenshot path
        //public static readonly string screenshotFolder = @projectDirectory + "\\Screenshots\\";


        // Configuration file path
        public static readonly string configSettingPath = workingDirectory + "\\Configuration.json";//@projectDirectory + "\\Configuration.json";

        // Driver path
        public static string driverPath = projectDirectory + "\\Drivers";

        public static string DownloadPath = @projectDirectory + "\\Downloads";

        // path in which Software Zip files are downloaded
        readonly public static string PartnerConnectFilePath = @DownloadPath + "\\PartnerConnect.zip";
        readonly public static string ServiceMonitorFilePath = @DownloadPath + "\\ServiceMonitor.zip";
        readonly public static string DCPFilePath = @DownloadPath + "\\DCP.zip";
    }
}