/*using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Main
{
    [Binding]
    public class LogFilesStaticElementsSteps
    {
        readonly LoginPage loginPage = new LoginPage();
        readonly LandingPage landingPage = new LandingPage();
        readonly LogFilesStaticElements logFilesStaticElements = new LogFilesStaticElements();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));


        [Given(@"user is on log page")]
        public void GivenUserIsOnLogPage()
        {

        }

        [Given(@"user has selected CVSM device")]
        public void GivenUserHasSelectedCVSMDevice()
        {
            PropertyClass.Driver.Navigate().GoToUrl(PropertyClass.BaseURL);  // Launch the Application

            // Explicit wait-> Wait till logo is displayed
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(LoginPage.Locator.LogoID)));

            loginPage.EmailField.EnterText(PropertyClass.Config.EmailIDAdminWithRollUp);
            loginPage.PasswordField.EnterText(PropertyClass.readConfig.PasswordAdminWithRollUp);
            loginPage.LoginButton.Clicks();

            // Explicit wait-> Wait till the organization list is displayed           
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(LandingPage.Locator.LandingPageTileID)));

            string actualTitle = PropertyClass.Driver.Title;
            string expectedTitle = LoginPage.ExpectedValues.LandingPageTitle;
            Assert.AreEqual(expectedTitle, actualTitle); //Compare the title

            PropertyClass.Driver.FindElement(By.Id("facName00")).Clicks();


            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(LogFilesStaticElements.Locator.CVSMLogsTabId)));
            Thread.Sleep(3000);
            PropertyClass.Driver.FindElement(By.XPath(LogFilesStaticElements.Locator.CVSMDeviceXpath)).Click();
        }

        [Given(@"user in on Main page")]
        public void GivenUserInOnMainPage()
        {

        }

        [When(@"user clicks Logs tab")]
        public void WhenUserClicksLogsTab()
        {
            Console.WriteLine("I am in user user clicks Logs tab");
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(logFilesStaticElements.CVSMLogsTabXPathWebElement.Text)));
            //Thread.Sleep(3000);
            //PropertyClass.Driver.FindElement(By.XPath(LogFilesStaticElements.Locator.CVSMLogsTabXpath)).Click();
            logFilesStaticElements.CVSMLogsTabXPathWebElement.Click();
        }

        [Then(@"Log Files label is displayed")]
        public void ThenUserWillSeeLogFilesLabel()
        {
            Thread.Sleep(2000);
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(logFilesStaticElements.LogFilesWebElement.Text)));
            Assert.IsTrue(logFilesStaticElements.LogFilesWebElement.Displayed);
        }
        [Then(@"Request Logs button is displayed")]
        public void ThenUserWillSeeRequestLogsButton()
        {
            //Thread.Sleep(2000);
            // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(logFilesStaticElements.RequestLogsButtonWebElement.Text)));
            Assert.IsTrue(logFilesStaticElements.LogFilesWebElement.Displayed);
        }

        [Then(@"Name column heading is displayed")]
        public void ThenUserWillSeeNameColumnHeading()
        {
            //Thread.Sleep(2000);
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName(logFilesStaticElements.NameColumnWebElement.Text)));
            Assert.IsTrue(logFilesStaticElements.NameColumnWebElement.Displayed);
        }

        [Then(@"Date column heading is displayed")]
        public void ThenUserWillSeeDateColumnHeading()
        {
            //Thread.Sleep(2000);
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(logFilesStaticElements.DateColumnWebElement.Text)));
            Assert.IsTrue(logFilesStaticElements.DateColumnWebElement.Displayed);
        }

        [Then(@"date sorting indicator is displayed")]
        public void ThenUserWillSeeDateSortingIndicator()
        {
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(logFilesStaticElements.DateColumnWebElement.Text)));
            Assert.IsTrue(logFilesStaticElements.DateColumnWebElement.Displayed);
        }

        [Then(@"Previous page icon is displayed")]
        public void ThenUserWillSeePreviousIcon()
        {
            Assert.IsTrue(logFilesStaticElements.PreviousIconWebElement.Displayed);
        }

        [Then(@"Next page icon is displayed")]
        public void ThenUserWillSeeNextIcon()
        {
            Assert.IsTrue(logFilesStaticElements.NextIconWebElement.Displayed);
        }

        [Then(@"user will see current logs page indicator")]
        public void ThenUserWillSeeCurrentLogsPageIndicator()
        {
            Assert.IsTrue(logFilesStaticElements.CurrentLogsPageWebElement.Displayed);
            //Currently only 7 records are populating on this page but it should be 10 records per page.
        }

        [Then(@"user will see number of logs pages")]
        public void ThenUserWillSeeNumberOfLogsPages()
        {
            //There is no Number of Logs Page
            //There is bug in this page
        }
    }
}
*/