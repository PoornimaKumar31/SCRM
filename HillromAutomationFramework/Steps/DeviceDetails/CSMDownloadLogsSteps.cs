using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.DeviceDetails
{
    [Binding, Scope(Tag ="SoftwareRequirementID_5699")]
    class CSMDownloadLogsSteps
    {
        LoginPage loginPage = new LoginPage();
        CSMDeviceDetailsPage csmDeviceDetailsPage = new CSMDeviceDetailsPage();
        readonly WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        readonly MainPage mainPage = new MainPage();
        readonly DeviceDetailsPage deviceDetailsPage = new DeviceDetailsPage();
        private ScenarioContext _scenarioContext;


        public CSMDownloadLogsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"user has selected CSM device")]
        public void GivenUserHasSelectedCSMDevice()
        {
            loginPage.SignIn("AdminWithoutRollupPage");
            SelectElement selectAssetType = new SelectElement(mainPage.AssetTypeDropDown);
            selectAssetType.SelectByText(MainPage.ExpectedValues.CSMDeviceName);
            //select the row according to the data
            csmDeviceDetailsPage.CSMDevices[2].Clicks();
        }

        [Given(@"user is on Device Details page")]
        public void GivenUserIsOnDeviceDetailsPage()
        {
            Assert.IsTrue(deviceDetailsPage.AssetLabel.GetElementVisibility());
            Assert.IsTrue(deviceDetailsPage.AssetData.GetElementVisibility());
        }



        [When(@"user clicks Logs tab")]
        public void WhenUserClicksLogsTab()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CSMDeviceDetailsPage.Locators.LogsTabID)));
            csmDeviceDetailsPage.LogsTab.Click();
        }

        [Then(@"logs for CSM device are displayed")]
        public void ThenLogsForCSMDeviceAreDisplayed()
        {
            Thread.Sleep(2000);
            Assert.IsTrue(csmDeviceDetailsPage.LogFiles.Count>0);
        }

        [Given(@"user is on CSM Log Files page")]
        public void GivenUserIsOnCSMLogFilesPage()
        {
            loginPage.SignIn("adminwithoutrollup");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("devices")));
            SelectElement selectAssetType = new SelectElement(mainPage.AssetTypeDropDown);
            selectAssetType.SelectByText(MainPage.ExpectedValues.CSMDeviceName);
        }

        [Given(@"at least one log is present")]
        public void GivenAtLeastOneLogIsPresent()
        {
            csmDeviceDetailsPage.CSMDevices[2].Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CSMDeviceDetailsPage.Locators.LogsTabID)));
            csmDeviceDetailsPage.LogsTab.Click();
            Assert.IsTrue(csmDeviceDetailsPage.LogFiles.GetElementCount() > 0);
        }

        [When(@"user clicks log")]
        public void WhenUserClicksLog()
        {
            csmDeviceDetailsPage.LogFiles[0].Click();   
        }

        [Then(@"log is downloaded to computer")]
        public void ThenLogIsDownloadedToComputer()
        {
            bool file_exist = false;
            while (file_exist != true)
            {
                Task.Delay(1000).Wait();
                if (File.Exists(PropertyClass.DownloadPath +"\\"+ csmDeviceDetailsPage.LogFiles[0].Text))
                {
                    file_exist = true;
                }
            }
        }

        [Then(@"downloaded filename matches")]
        public void ThenDownloadedFilenameMatches()
        {
            Assert.IsTrue(File.Exists(PropertyClass.DownloadPath +"\\"+ csmDeviceDetailsPage.LogFiles[0].Text));
        }

         

        [Then(@"ten logs for CSM device are displayed")]
        public void ThenTenLogsForCSMDeviceAreDisplayed()
        {
            Assert.IsTrue(csmDeviceDetailsPage.LogFiles.GetElementCount() == 10);
        }

        [Then(@"user cannot navigate to next logs page")]
        public void ThenUserCannotNavigateToNextLogsPage()
        {
            csmDeviceDetailsPage.LogsNextButton.Click();
            Assert.IsTrue(csmDeviceDetailsPage.LogsCurrentPageNumber.Text == "1");
        }

        [When(@"user clicks Request Logs button")]
        public void WhenUserClicksRequestLogsButton()
        {
            csmDeviceDetailsPage.LogsRequestButton.Click();
        }

        [Then(@"Pending or Executing message is displayed")]
        public void ThenPendingOrExecutingMessageIsDisplayed()
        {
            Assert.IsTrue(csmDeviceDetailsPage.LogsPendingMessage.Displayed);
        }

        [Then(@"user can navigate to next logs page")]
        public void ThenUserCanNavigateToNextLogsPage()
        {
            csmDeviceDetailsPage.LogsNextButton.Click();
            Assert.IsTrue(csmDeviceDetailsPage.LogsCurrentPageNumber.Text == "2");
        }

        [Given(@"Pending or Executing message is displayed")]
        public void GivenPendingOrExecutingMessageIsDisplayed()
        {
            if(!(csmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility()))
            {
                //create a log file request if not there
                csmDeviceDetailsPage.LogsRequestButton.Click();
                Assert.IsTrue(csmDeviceDetailsPage.LogsPendingMessage.GetElementVisibility());
            }
        }

        [When(@"user navigates to next logs page")]
        public void WhenUserNavigatesToNextLogsPage()
        {
            csmDeviceDetailsPage.LogsNextButton.Click();
            Assert.IsTrue(csmDeviceDetailsPage.LogsCurrentPageNumber.Text == "2");
        }

        [When(@"user navigates to previous logs page")]
        public void WhenUserNavigatesToPreviousLogsPage()
        {
            csmDeviceDetailsPage.LogsPreviousButton.Click();
            Assert.IsTrue(csmDeviceDetailsPage.LogsCurrentPageNumber.Text == "1");
        }

        [Given(@"Log files are sorted by decreasing date")]
        public void GivenLogFilesAreSortedByDecreasingDate()
        {
            Thread.Sleep(3000);
            if (!(csmDeviceDetailsPage.DateSorting.GetAttribute("class") == CSMDeviceDetailsPage.Locators.LogsDescendingClassName))
            {
                csmDeviceDetailsPage.DateSorting.Click();
                Thread.Sleep(3000);
                if (!(csmDeviceDetailsPage.DateSorting.GetAttribute("class") == CSMDeviceDetailsPage.Locators.LogsDescendingClassName))
                {
                    Assert.Fail();
                }      
            }
        }

        [Given(@"CSM has (.*) logs")]
        public void GivenCSMHasLogs(int noOfLogs)
        {
            switch(noOfLogs)
            {
                case 0:
                        //Selecting CSM device with no log files
                        csmDeviceDetailsPage.CSMDevices[1].Click();
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CSMDeviceDetailsPage.Locators.LogsTabID)));
                        csmDeviceDetailsPage.LogsTab.Click();
                        break;

                case 10:
                        //selecting CSM device with 10 log files
                        csmDeviceDetailsPage.CSMDevices[7].Click();
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CSMDeviceDetailsPage.Locators.LogsTabID)));
                        csmDeviceDetailsPage.LogsTab.Click();
                        break;
                case 25:
                    //selecting CSM device with 25 log files
                    csmDeviceDetailsPage.CSMDevices[2].Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CSMDeviceDetailsPage.Locators.LogsTabID)));
                    csmDeviceDetailsPage.LogsTab.Click();
                    break;
            }
            
        }

        [Then(@"no logs for CSM device are displayed")]
        public void ThenNoLogsForCSMDeviceAreDisplayed()
        {
            Assert.IsTrue(csmDeviceDetailsPage.LogFiles.GetElementCount()==0);
        }




        [Given(@"newest ten logs are displayed")]
        public void GivenNewestTenLogsAreDisplayed()
        {
            Assert.IsTrue(csmDeviceDetailsPage.LogFiles.GetElementCount() == 10);
        }

        [When(@"user clicks Next page button")]
        public void WhenUserClicksNextPageButton()
        {
            csmDeviceDetailsPage.LogsNextButton.Click();
        }

        [Then(@"user will see next ten older logs")]
        public void ThenUserWillSeeNextTenOlderLogs()
        {
            Assert.IsTrue(csmDeviceDetailsPage.LogFiles.GetElementCount() == 10);
        }

        [Then(@"user will see logs page (.*) indicator")]
        public void ThenUserWillSeeLogsPageIndicator(int PageNumber)
        {
            Assert.IsTrue(csmDeviceDetailsPage.LogsCurrentPageNumber.Text == PageNumber.ToString());
        }

        [Given(@"logs are sorted by decreasing date")]
        public void GivenLogsAreSortedByDecreasingDate()
        {
            _scenarioContext.Pending();
        }

        [Given(@"second ten logs are displayed")]
        public void GivenSecondTenLogsAreDisplayed()
        {
            csmDeviceDetailsPage.LogsNextButton.Click();
            Assert.IsTrue(csmDeviceDetailsPage.LogFiles.GetElementCount() == 10);
        }

        [Then(@"user will see next five older logs")]
        public void ThenUserWillSeeNextFiveOlderLogs()
        {
            Assert.IsTrue(csmDeviceDetailsPage.LogFiles.GetElementCount() == 5);
        }


        [Given(@"user is on CSM Log File page")]
        public void GivenUserIsOnCSMLogFilePage()
        {
            loginPage.SignIn("AdminWithoutRollupPage");
            SelectElement selectAssetType = new SelectElement(mainPage.AssetTypeDropDown);
            selectAssetType.SelectByText(MainPage.ExpectedValues.CSMDeviceName);
            //select the row according to the data
            csmDeviceDetailsPage.CSMDevices[7].Clicks();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(CSMDeviceDetailsPage.Locators.LogsTabID)));
            csmDeviceDetailsPage.LogsTab.Click();
        }



        [Given(@"logs are sorted by increasing date")]
        public void GivenLogsAreSortedByIncreasingDate()
        {
            _scenarioContext.Pending();
        }

        [When(@"user clicks Date column heading")]
        public void WhenUserClicksDateColumnHeading()
        {
            csmDeviceDetailsPage.DateSorting.Click();
        }

        [Then(@"logs sort by decreasing date")]
        public void ThenLogsSortByDecreasingDate()
        {
            _scenarioContext.Pending();
        }

        [Then(@"user will see decreasing date sorting indicator")]
        public void ThenUserWillSeeDecreasingDateSortingIndicator()
        {
            Assert.IsTrue(csmDeviceDetailsPage.DateSorting.GetAttribute("class")==CSMDeviceDetailsPage.Locators.LogsDescendingClassName);
        }

        [Then(@"logs sort by increasing date")]
        public void ThenLogsSortByIncreasingDate()
        {
            _scenarioContext.Pending();
        }

        [Then(@"user will see increasing date sorting indicator")]
        public void ThenUserWillSeeIncreasingDateSortingIndicator()
        {
            Assert.IsTrue(csmDeviceDetailsPage.DateSorting.GetAttribute("class") == CSMDeviceDetailsPage.Locators.LogsAscendingClassName);
        }
    }
}
