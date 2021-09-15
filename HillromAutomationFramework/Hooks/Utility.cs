using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using HillromAutomationFramework.SupportingCode;
using Microsoft.Edge.SeleniumTools;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace HillromAutomationFramework.Hooks
{
    [Binding]
    public sealed class Utility
    {
        //Declaration of variables to handle extent report
        private static ExtentReports _extentReports;
        [ThreadStatic]
        private static ExtentTest _feature;
        [ThreadStatic]
        private static ExtentTest _scenario;
        
        [ThreadStatic]
        private static int screenShotNameCounter = 0;

        //WebDriver for operating the browser.
        [ThreadStatic]
        private static IWebDriver _driver;

        //Sprcflow variables
        private readonly ScenarioContext _scenarioContext;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
        private readonly IObjectContainer _objectContainer;

        /// <summary>
        /// Constructor to intialize scenario Context
        /// </summary>
        /// <param name="scenarioContext">Scenario context from the existing scenario</param>
        public Utility(IObjectContainer objectContainer,ScenarioContext scenarioContext,ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
            _specFlowOutputHelper = specFlowOutputHelper;
        }


        /// <summary>
        /// Before the whole test setup the extent report
        /// </summary>
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //Declatation of HTML Reporter for Extent Report
            var htmlReporter = new ExtentHtmlReporter(PropertyClass.extentReportPath);
            htmlReporter.Config.ReportName = "Automated testing of Smart Care Remote Management";
            htmlReporter.Config.DocumentTitle = "Test Cases Report";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            //Attach report to reporter
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);

            //Adding system info to the project
            _extentReports.AddSystemInfo("Base URl", PropertyClass.BaseURL);
            _extentReports.AddSystemInfo("Operating System", Environment.OSVersion.ToString());
            _extentReports.AddSystemInfo("Browser", PropertyClass.BrowserName);

            //create downloads folder if not exists
            if (!Directory.Exists(PropertyClass.DownloadPath))
            {
                Directory.CreateDirectory(PropertyClass.DownloadPath);
            }
            else
            {
                //Delete all files in download folder
                GetMethods.ClearDownloadFolder(PropertyClass.DownloadPath + "\\");
            }
        }


        /// <summary>
        /// Before feature runs create a feature in extent report.
        /// </summary>
        /// <param name="featureContext">Current feature file</param>
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title,featureContext.FeatureInfo.Description);
        }

        /// <summary>
        /// Setups the browser before each test case.
        /// </summary>
        [BeforeScenario]
        public void BeforeScenario()
        {
            //log scenario in extent report
            _scenario = _feature.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title,_scenarioContext.ScenarioInfo.Description);
            _scenario.AssignCategory(_scenarioContext.ScenarioInfo.Tags);


            //Browser setup  
            string BrowserName = PropertyClass.BrowserName.ToLower().Trim();

            if(BrowserName.Contains("chrome"))
            {
                ChromeOptions chromeOptions = new ChromeOptions();
                //for incognito mode
                chromeOptions.AddArgument("--incognito");

                // Maximize the window
                chromeOptions.AddArgument("start-maximized");

                //for full screen
                //chromeOptions.AddArgument("--start-fullscreen");

                // to set the chrome download directory
                chromeOptions.AddUserProfilePreference("download.default_directory", PropertyClass.DownloadPath);
                chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);

                //Headless chrome (without opening chrome browser run test cases internally)
                //chromeOptions.AddArgument("--headless");

                // Setting up the chrome driver
                _driver= new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
                _specFlowOutputHelper.WriteLine("Launched chrome browser");
            }
            else if(BrowserName.Contains("edge"))
            {
                EdgeOptions edgeoptions = new EdgeOptions
                {
                    UseChromium = true,
                };

                //for incognito mode
                edgeoptions.AddArgument("inprivate");
                //for setting download directory
                edgeoptions.AddUserProfilePreference("download.default_directory", PropertyClass.DownloadPath);
                edgeoptions.AddUserProfilePreference("download.prompt_for_download", false);

                // Maximize the window
                edgeoptions.AddArgument("start-maximized");

                //for full screen
                edgeoptions.AddArgument("--start-fullscreen");

                //Headless(without opening edge browser,run the test internally)
                //edgeoptions.AddArgument("--headless");

                //Setting up Edge driver
                _driver= new EdgeDriver(edgeoptions);
                _specFlowOutputHelper.WriteLine("Launched edge browser");
            }
            else
            {
                _specFlowOutputHelper.WriteLine("Invalid browser name " + BrowserName);
                Assert.Fail("Invalid Browser Name:"+BrowserName);
                Environment.Exit(1);
            }
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); // Implicit wait for 5 seconds

            //Register webdriver as instance
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);

        }


        /// <summary>
        /// After step log the test results in extent report
        /// </summary>
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

        /// <summary>
        /// Create a step on extent report based on the step type
        /// </summary>
        /// <typeparam name="T">Step type: Given,When,Then</typeparam>
        public void CreateNode<T>() where T : IGherkinFormatterModel
        {
            ScenarioExecutionStatus scenarioExecutionStatus = _scenarioContext.ScenarioExecutionStatus;

            switch (scenarioExecutionStatus)
            {
                case ScenarioExecutionStatus.OK:
                    _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
                    break;

                case ScenarioExecutionStatus.TestError:
                    // Taking a screenshot for attaching in Test Context
                    var filePath = $"{TestContext.CurrentContext.TestDirectory}\\{TestContext.CurrentContext.Test.MethodName+ DateTime.Now.ToString("HH.mm.ss") + screenShotNameCounter}.jpg";
                    ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile(filePath);
                    _specFlowOutputHelper.AddAttachment(filePath);
                    
                    //taking screenshot for extent report
                    var mediaEntity = GetMethods.CaptureScreenshotBase64(_driver,"screenshot" + screenShotNameCounter + DateTime.Now.ToString("HH.mm.ss"));
                    _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n\n" + _scenarioContext.TestError.InnerException, mediaEntity);
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


        /// <summary>
        /// Closing the browser after test case end.
        /// </summary>
        [AfterScenario]
        public void CleanUp()
        {
           _driver.Quit();
        }

        /// <summary>
        /// After the test generate the extent report.
        /// </summary>
        [AfterTestRun]
        public static void AfterTestRun()
        {
            _extentReports.Flush();
        }

    }
}