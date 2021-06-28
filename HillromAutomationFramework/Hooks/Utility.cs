using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using HillromAutomationFramework.Coding.SupportingCode;
using Microsoft.Edge.SeleniumTools;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Hooks
{
    [Binding]
    public sealed class Utility
    {
        //Declaration of variables to handle extent report
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
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
            //Initializing the readConfig object
            PropertyClass.readConfig = new ReadConfig();
            //Creating object of Configuration builder
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(PropertyClass.configSettingPath);
            //For Building the configuration
            IConfigurationRoot configuration = builder.Build();
            //Binding the configuration.json with ReadConfig.cs class
            configuration.Bind(PropertyClass.readConfig);

            //Declatation of HTML Reporter for Extent Report
            var htmlReporter = new ExtentHtmlReporter(PropertyClass.extentReportPath);
            htmlReporter.Config.ReportName = "Automated testing of Smart Care Remote Management";
            htmlReporter.Config.DocumentTitle = "Reported Test Cases";

            //Attach report to reporter
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            //Adding system info to the project
            extent.AddSystemInfo("Base URl", PropertyClass.BaseURL);
            extent.AddSystemInfo("Operating System", Environment.OSVersion.ToString());
            extent.AddSystemInfo("Browser", PropertyClass.BrowserName);
        }

        // After the test generate the extent report 
        [AfterTestRun]
        public static void AfterTestRun()
        {
            extent.Flush();
        }

        // Before feature runs create a node in extent report.
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            //Browser setup
            switch (PropertyClass.BrowserName.ToLower())
            {
                case "google chrome": // to set the chrome download directory
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddUserProfilePreference("download.default_directory", PropertyClass.DownloadPath);
                    chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);

                    // Setting up the chrome driver
                    PropertyClass.Driver = new ChromeDriver(chromeOptions);
                    break;

                case "microsoft edge": // Setting up edge driver
                    EdgeOptions options = new EdgeOptions
                    {
                        UseChromium = true
                    };
                    PropertyClass.Driver = new EdgeDriver(PropertyClass.driverPath, options);
                    break;

                default:
                    Console.WriteLine("Invalid browser Name");
                    break;
            }
            PropertyClass.Driver.Manage().Window.Maximize(); // Maximize the window
            PropertyClass.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60); // Implicit wait for 60 seconds
        }

        // After step log the test results in extent report
        [AfterStep]
        public void ReportSteps()
        {
            var stepType = _scenarioContext.CurrentScenarioBlock.ToString();

            // Log the test results in the extent report with screenshot if test fails.
            if (_scenarioContext.TestError != null)
            {
                var mediaEntity = GetMethods.CaptureScreenshot("screenshot" + screenShotNameCounter + DateTime.Now.ToString("HH.mm.ss"));
                if (stepType == "Given")
                    _ = scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException, mediaEntity);
                else if (stepType == "When")
                    _ = scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException, mediaEntity);
                else if (stepType == "Then")
                    _ = scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                else if (stepType == "And")
                    _ = scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException, mediaEntity);
                screenShotNameCounter++;
            }
            else
            {
                // Log the test results in the extent report with screenshot if test pass.
                if (stepType == "Given")
                    _ = scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Pass(_scenarioContext.ScenarioExecutionStatus.ToString());
                else if (stepType == "When")
                    _ = scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Pass(_scenarioContext.ScenarioExecutionStatus.ToString());
                else if (stepType == "Then")
                    _ = scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Pass(_scenarioContext.ScenarioExecutionStatus.ToString());
                else if (stepType == "And")
                    _ = scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Pass(_scenarioContext.ScenarioExecutionStatus.ToString());
            }
        }

        // Log the scenario
        [BeforeScenario]
        public void Initialize()
        {
            scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        //Closing the driver and setting the driver reference to null
        [AfterScenario]
        public void CleanUp()
        {
            PropertyClass.Driver.Quit();
        }

    }
}