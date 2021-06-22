﻿using OpenQA.Selenium;
using System;
using System.IO;

namespace HillromAutomationFramework.Coding.SupportingCode
{
    class PropertyClass
    {
        //Initializing Driver
        public static IWebDriver Driver { get; set; }

        //Base URL
        public static string BaseURL = "https://incubator.deviot.hillrom.com/apps/remotemanagement/index.html#/";//Environment.GetEnvironmentVariable("BaseURL");

        //Browser Name
        public static string BrowserName = "Google Chrome";//Environment.GetEnvironmentVariable("BrowserName");

        //Configuration files
        public static ReadConfig readConfig;

        //Current Working Directory i.e. //bin
        static readonly string workingDirectory = Environment.CurrentDirectory;

        //Current Project Directory i.e. //HillRomAutomation
        public static string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

        //Extent Report Path
        readonly public static string extentReportPath = @projectDirectory + "\\Reports\\ExtentReport.html";

        //Screenshot path
        readonly public static string screenshotFolder = projectDirectory + "\\Screenshots\\";


        // Configuration file path
        public static readonly string configSettingPath = @projectDirectory+"\\Configuration.json";

        // Driver path
        public static string driverPath = projectDirectory + "\\Drivers";

        public static string DownloadPath = @projectDirectory + "\\Downloads";

        // path in which Software Zip files are downloaded
        readonly public static string PartnerConnectFilePath = @DownloadPath + "\\PartnerConnect.zip";
        readonly public static string ServiceMonitorFilePath = @DownloadPath + "\\ServiceMonitor.zip";
        readonly public static string DCPFilePath = @DownloadPath + "\\DCP.zip";
    }
}
