using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using HillromAutomationFramework.Coding.SupportingCode;
using Microsoft.Edge.SeleniumTools;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
/**
* To run some some functions before and after test/feature/scenarios.
*/

namespace HillromAutomationFramework.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        //Declaration of variables to handle extent report
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        private static int screenShotNameCounter = 0;

        //Living doc
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
        private static ScenarioContext _scenarioContext;
        public Hooks1(ISpecFlowOutputHelper specFlowOutputHelper,ScenarioContext scenarioContext)
        {
            _specFlowOutputHelper = specFlowOutputHelper;
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
            htmlReporter.Config.DocumentTitle = "Test Case of Report";

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
        public void beforeScenario()
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
                    _specFlowOutputHelper.WriteLine("Chrome browser Launched");
                    break;

                case "mozilla firefox":
                    FirefoxOptions firefoxoptions = new FirefoxOptions();
                    //firefoxoptions.Profile.SetPreference("","");
                    firefoxoptions.SetPreference("browser.downLoad.folderList", 2);
                    firefoxoptions.SetPreference("browser.download.dir", PropertyClass.DownloadPath);
                    firefoxoptions.SetPreference("browser.download.panel.shown", false);
                    firefoxoptions.SetPreference("browser.download.manager.showWhenStarting", false);
                    firefoxoptions.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/zip;");
                    PropertyClass.Driver = new FirefoxDriver(firefoxoptions);
                    break;

                case "microsoft edge": // Setting up edge driver
                    var options = new EdgeOptions();
                    options.UseChromium = true;
                    PropertyClass.Driver = new EdgeDriver(PropertyClass.driverPath, options);
                    break;

                default:
                    Console.WriteLine("Invalid browser Name");
                    break;
            }
        }

        // Before Step reset the screenshot flag
        [BeforeStep]
        public void Beforesteps()
        {
            //set screenshot flag to zero
            _scenarioContext.StepContext.Add("value", 0);
        }

        // After step log the test results in extent report
        [AfterStep]
        public void ReportSteps()
        {
            var stepType = _scenarioContext.CurrentScenarioBlock.ToString();
            var flag = (int)_scenarioContext.StepContext["value"];

            // Log test results in extent report with the screenshot.
            if (_scenarioContext.StepContext.TestError == null && flag == 1)
            {
                //Take the screenshot
                _specFlowOutputHelper.AddAttachment(SeleniumGetMethods.getScreenshot("screenshot" + screenShotNameCounter + DateTime.Now.ToString("HH.mm.ss")));
                var mediaEntity = SeleniumGetMethods.CaptureScreenshot("screenshot" + screenShotNameCounter + DateTime.Now.ToString("HH.mm.ss"));
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Pass("Step Passed!!", mediaEntity);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Pass("Step Passed!!", mediaEntity);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Pass("Step Passed!!", mediaEntity);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Pass("Step Passed!!", mediaEntity);
            }

            // Log test results without the screenshot
            else if (_scenarioContext.StepContext.TestError == null && flag == 0)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Pass("Step Passed!!");
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Pass("Step Passed!!");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Pass("Step Passed!!");
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Pass("Step Passed!!");
            }

            // Log the test results in the extent report with screenshot if test fails.
            else if (_scenarioContext.StepContext.TestError != null)
             {
                _specFlowOutputHelper.AddAttachment(SeleniumGetMethods.getScreenshot("screenshot" + screenShotNameCounter + DateTime.Now.ToString("HH.mm.ss")));
                var mediaEntity = SeleniumGetMethods.CaptureScreenshot("screenshot" + screenShotNameCounter + DateTime.Now.ToString("HH.mm.ss"));
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.StepContext.TestError.InnerException, mediaEntity);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.StepContext.TestError.InnerException, mediaEntity);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.StepContext.TestError.Message, mediaEntity);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.StepContext.TestError.InnerException, mediaEntity);
                screenShotNameCounter++;
            }
        }

        // Log the scenario
        [BeforeScenario]
        public void Initialize()
        {
            scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }


        [AfterScenario]
        public void CleanUp()
        {
            PropertyClass.Driver.Quit();
            PropertyClass.Driver = null;
        }

        // capture the screenshot
        public static void CaptureNow()
        {
            _scenarioContext.StepContext["value"] = 1;
        }
    }
}
