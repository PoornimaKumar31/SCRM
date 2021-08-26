﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;

namespace HillromAutomationFramework.Coding.SupportingCode
{
    class PropertyClass
    {
        /// <summary>
        /// WebDriver for operating the browser.
        /// </summary>
        public static IWebDriver Driver { get; set; }

        /// <summary>
        /// Base URL of the application under test.
        /// </summary>
        public static string BaseURL = "https://incubator.deviot.hillrom.com/apps/remotemanagement";//Environment.GetEnvironmentVariable("BaseURL");

        /// <summary>
        /// Name of the browser to run tests.
        /// </summary>
        public static string BrowserName = "chrome";//Environment.GetEnvironmentVariable("BrowserName");

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

        // path in which Software Zip files are downloaded
        readonly public static string PartnerConnectFilePath = @DownloadPath + "\\PartnerConnect.zip";
        readonly public static string ServiceMonitorFilePath = @DownloadPath + "\\ServiceMonitor.zip";
        readonly public static string DCPFilePath = @DownloadPath + "\\DCP.zip";
        
    }
}