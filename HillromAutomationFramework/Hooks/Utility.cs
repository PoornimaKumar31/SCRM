using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using HillromAutomationFramework.Coding.SupportingCode;
using Microsoft.Edge.SeleniumTools;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Hooks
{
    [Binding]
    public sealed class Utility
    {
        //Declaration of variables to handle extent report
        private static ExtentTest _feature;
        private static ExtentTest _scenario;
        private static ExtentReports _extentReports;
        private static int screenShotNameCounter = 0;
        private readonly ScenarioContext _scenarioContext;
        public Utility(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        // Before the whole test setup the extent report
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //Declatation of HTML Reporter for Extent Report
            var htmlReporter = new ExtentHtmlReporter(PropertyClass.extentReportPath);
            htmlReporter.Config.ReportName = "Automated testing of Smart Care Remote Management";
            htmlReporter.Config.DocumentTitle = "Test Cases Report";

            //Attach report to reporter
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);

            //Adding system info to the project
            _extentReports.AddSystemInfo("Base URl", PropertyClass.BaseURL);
            _extentReports.AddSystemInfo("Operating System", Environment.OSVersion.ToString());
            _extentReports.AddSystemInfo("Browser", PropertyClass.BrowserName);
        }

        // After the test generate the extent report 
        [AfterTestRun]
        public static void AfterTestRun()
        {
            _extentReports.Flush();
        }

        // Before feature runs create a node in extent report.
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title,featureContext.FeatureInfo.Description);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            //log scenario in extent report
            _scenario = _feature.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title,_scenarioContext.ScenarioInfo.Description);
            
            //Browser setup
            string BrowserName = PropertyClass.BrowserName.ToLower().Trim();
            if(BrowserName.Contains("chrome"))
            {
                // to set the chrome download directory
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddUserProfilePreference("download.default_directory", PropertyClass.DownloadPath);
                chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);

                // Setting up the chrome driver
                PropertyClass.Driver = new ChromeDriver(chromeOptions);
            }
            else if(BrowserName.Contains("edge"))
            {
                EdgeOptions options = new EdgeOptions
                {
                    UseChromium = true
                };
                PropertyClass.Driver = new EdgeDriver(PropertyClass.driverPath, options);
            }
            else
            {
                Assert.Fail("Invalid Browser Name");
                Environment.Exit(1);
            }

           
            PropertyClass.Driver.Manage().Window.Maximize(); // Maximize the window
            PropertyClass.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // Implicit wait for 15 seconds
        }

        // After step log the test results in extent report
        [AfterStep]
        public void ReportSteps()
        {
            ScenarioBlock scenarioBlock = _scenarioContext.CurrentScenarioBlock;

            switch (scenarioBlock)
            {
                case ScenarioBlock.Given:
                    CreateNode<Given>();
                    break;
                case ScenarioBlock.When:
                    CreateNode<When>();
                    break;
                case ScenarioBlock.Then:
                    CreateNode<Then>();
                    break;
                default:
                    CreateNode<And>();
                    break;
            }
        }

        public void CreateNode<T>() where T : IGherkinFormatterModel
        {
            ScenarioExecutionStatus scenarioExecutionStatus = _scenarioContext.ScenarioExecutionStatus;

            switch (scenarioExecutionStatus)
            {
                case ScenarioExecutionStatus.OK:
                    _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
                    break;

                case ScenarioExecutionStatus.TestError:
                    var mediaEntity = GetMethods.CaptureScreenshot("screenshot" + screenShotNameCounter + DateTime.Now.ToString("HH.mm.ss"));
                    _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.InnerException,mediaEntity);
                    screenShotNameCounter++;
                    break;

                case ScenarioExecutionStatus.StepDefinitionPending:
                    _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Defination Pending");
                    break;
                default:
                    _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text).Info(_scenarioContext.ScenarioExecutionStatus.ToString());
                    break;
            }
        }
        //Closing the driver and setting the driver reference to null
        [AfterScenario]
        public void CleanUp()
        {
           //PropertyClass.Driver.Quit();
        }

    }
}