using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Updates
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5709")]
    public class Req5709Steps
    {

        LoginPage loginPage = new LoginPage();
        MainPage mainPage = new MainPage();
        ServiceMoniterPage serviceMoniterPage = new ServiceMoniterPage();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        private ScenarioContext _scenarioContext;

        public Req5709Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"user is on Main page")]
        public void GivenUserIsOnMainPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithOutRollUpPage);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            Assert.AreEqual(true, mainPage.AssetsTab.GetElementVisibility(), "User is not on main page");
        }
        
        [When(@"user clicks Updates")]
        public void WhenUserClicksUpdates()
        {
            mainPage.UpdatesTab.JavaSciptClick();
        }
        
        [When(@"user selects Service Monitor")]
        public void WhenUserSelectsServiceMonitor()
        {
            serviceMoniterPage.AssetTypeDropDown.SelectDDL(ServiceMoniterPage.Inputs.ServiceMoniterText);
        }
        
        [Then(@"Service Monitor Settings page displays")]
        public void ThenServiceMonitorSettingsPageDisplays()
        {
            Assert.AreEqual(true, serviceMoniterPage.ServiceMoniterLabel.GetElementVisibility(), "Service Monitor Settings page is displayed");
        }

        [Given(@"user is on Service Monitor Settings page")]
        public void GivenUserIsOnServiceMonitorSettingsPage()
        {
            GivenUserIsOnMainPage();
            mainPage.UpdatesTab.JavaSciptClick();
            serviceMoniterPage.AssetTypeDropDown.SelectDDL(ServiceMoniterPage.Inputs.ServiceMoniterText);
            Assert.AreEqual(true, serviceMoniterPage.ServiceMoniterLabel.GetElementVisibility(), "Service Monitor Settings page is displayed");
        }

        [When(@"user clicks Call home period drop-down")]
        public void WhenUserClicksCallHomePeriodDrop_Down()
        {
            Assert.AreEqual(true, serviceMoniterPage.CallHomePeriodDropDown.GetElementVisibility(), "Call home period drop-down is not displayed");
            serviceMoniterPage.CallHomePeriodDropDown.Click();
        }

        [Then(@"drop down displays P1D \(24 HOURS\), PT8H \(8 HOURS\), PT4H \(4 HOURS\), PT15M \(15 MINUTES\)")]
        public void ThenDropDownDisplaysPDHOURSPTHHOURSPTHHOURSPTMMINUTES()
        {
            IList<IWebElement> Dropdownlist = serviceMoniterPage.CallHomePeriodDropDown.GetAllOptionsFromDDL();
            IList<string> DropDownListString = new List<string>();
            foreach(IWebElement option in Dropdownlist)
            {
                DropDownListString.Add(option.Text);
            }
            Assert.AreEqual(true, DropDownListString.Contains(ServiceMoniterPage.ExpectedValues.CallHomePeriodDropdownOptionP1D), ServiceMoniterPage.ExpectedValues.CallHomePeriodDropdownOptionP1D+" Option is not available.\n");
            Assert.AreEqual(true, DropDownListString.Contains(ServiceMoniterPage.ExpectedValues.CallHomePeriodDropdownOptionPT8H), ServiceMoniterPage.ExpectedValues.CallHomePeriodDropdownOptionPT8H+ " Option is not available.\n");
            Assert.AreEqual(true, DropDownListString.Contains(ServiceMoniterPage.ExpectedValues.CallHomePeriodDropdownOptionPT4H), ServiceMoniterPage.ExpectedValues.CallHomePeriodDropdownOptionPT4H+ " Option is not available.\n");
            Assert.AreEqual(true, DropDownListString.Contains(ServiceMoniterPage.ExpectedValues.CallHomePeriodDropdownOptionPT15M), ServiceMoniterPage.ExpectedValues.CallHomePeriodDropdownOptionPT15M + " Option is not available.\n");
        }


        [When(@"user clicks Deployment mode drop-down")]
        public void WhenUserClicksDeploymentModeDrop_Down()
        {
            serviceMoniterPage.DeploymentModeDropDown.Click();
        }

        [Then(@"drop down displays FALSE, TRUE")]
        public void ThenDropDownDisplaysFALSETRUE()
        {
            IList<IWebElement> Dropdownlist = serviceMoniterPage.DeploymentModeDropDown.GetAllOptionsFromDDL();
            IList<string> DropDownListString = new List<string>();
            foreach (IWebElement option in Dropdownlist)
            {
                DropDownListString.Add(option.Text);
            }
            Assert.AreEqual(true, DropDownListString.Contains(ServiceMoniterPage.ExpectedValues.DeploymentModeDropdownOptionTrue), ServiceMoniterPage.ExpectedValues.DeploymentModeDropdownOptionTrue + " Option is not available.\n");
            Assert.AreEqual(true, DropDownListString.Contains(ServiceMoniterPage.ExpectedValues.DeploymentModeDropdownOptionFalse), ServiceMoniterPage.ExpectedValues.DeploymentModeDropdownOptionFalse + " Option is not available.\n");
        }

        [When(@"user clicks Previous button")]
        public void WhenUserClicksPreviousButton()
        {
            serviceMoniterPage.PreviousButton.Click();
        }

        [Then(@"Updates page is displayed")]
        public void ThenUpdatesPageIsDisplayed()
        {
            Assert.AreEqual(true, serviceMoniterPage.AssetTypeDropDown.GetElementVisibility(), "Updates page is not displayed.\n");
        }

        [Given(@"no devices are selected")]
        public void GivenNoDevicesAreSelected()
        {
            Assert.AreEqual(ServiceMoniterPage.ExpectedValues.DestinationNoDeviceCountText, serviceMoniterPage.DestinalitioDeviceCount.Text, "Devices are selected.\n");
        }

        [Then(@"Service Monitor Settings label is displayed")]
        public void ThenServiceMonitorSettingsLabelIsDisplayed()
        {
            Assert.AreEqual(true, serviceMoniterPage.ServiceMoniterLabel.GetElementVisibility(), "Service Monitor Settings label is not displayed.\n");
            string ActualLabel = serviceMoniterPage.ServiceMoniterLabel.Text;
            string ExpectedLabel = ServiceMoniterPage.ExpectedValues.ServiceMoniterLabel;
            Assert.AreEqual(ExpectedLabel, ActualLabel, "Service Monitor Settings label text does not match with the expected text.\n");
        }

        [Then(@"Call home period label is displayed")]
        public void ThenCallHomePeriodLabelIsDisplayed()
        {
            Assert.AreEqual(true, serviceMoniterPage.CallHomePeroidLabel.GetElementVisibility(), "Call home period label is not displayed.\n");
            string ActualLabel = serviceMoniterPage.CallHomePeroidLabel.Text;
            string ExpectedLabel = ServiceMoniterPage.ExpectedValues.CallHomePeriodLabel;
            Assert.AreEqual(ExpectedLabel, ActualLabel, "Call home period label text does not match with the expected text.\n");
        }

        [Then(@"Call home period dropdown is displayed")]
        public void ThenCallHomePeriodDropdownIsDisplayed()
        {
            Assert.AreEqual(true, serviceMoniterPage.CallHomePeriodDropDown.GetElementVisibility(), "Call home period dropdown is not displayed");
        }

        [Then(@"Deployment mode label is displayed")]
        public void ThenDeploymentModeLabelIsDisplayed()
        {
            Assert.AreEqual(true, serviceMoniterPage.DeploymentModeLabel.GetElementVisibility(), "Deployment mode label is not displayed.\n");
            string ActualLabel = serviceMoniterPage.DeploymentModeLabel.Text;
            string ExpectedLabel = ServiceMoniterPage.ExpectedValues.DeploymentModeLabel;
            Assert.AreEqual(ExpectedLabel, ActualLabel, "Deployment mode label text does not match with the expected text.\n");
        }

        [Then(@"Deployment mode drop down is displayed")]
        public void ThenDeploymentModeDropDownIsDisplayed()
        {
            Assert.AreEqual(true, serviceMoniterPage.DeploymentModeDropDown.GetElementVisibility(), "Deployment mode drop down is not displayed");
        }

        [Then(@"Destinations label is displayed")]
        public void ThenDestinationsLabelIsDisplayed()
        {
            Assert.AreEqual(true, serviceMoniterPage.DestinationLabel.GetElementVisibility(), "Destinations label is not displayed.\n");
            string ActualLabel = serviceMoniterPage.DestinationLabel.Text;
            string ExpectedLabel = ServiceMoniterPage.ExpectedValues.DestinationLabel;
            Assert.AreEqual(ExpectedLabel, ActualLabel, "Destinations label text does not match with the expected text.\n");
        }

        [Then(@"location hierarchy selectors are displayed")]
        public void ThenLocationHierarchySelectorsAreDisplayed()
        {
            Assert.AreEqual(true, serviceMoniterPage.LocationHierarchySelectors.GetElementVisibility(), "location hierarchy selectors are not displayed");
        }

        [Then(@"count of selected devices is displayed")]
        public void ThenCountOfSelectedDevicesIsDisplayed()
        {
            Assert.AreEqual(true, serviceMoniterPage.DestinalitioDeviceCount.GetElementVisibility(), "count of selected devices is not displayed");
        }

        [Then(@"count of selected locations is displayed")]
        public void ThenCountOfSelectedLocationsIsDisplayed()
        {
            Assert.AreEqual(true, serviceMoniterPage.DestinalitioDeviceCount.GetElementVisibility(), "count of selected locations is not displayed");
        }

        [Then(@"Previous button is enabled")]
        public void ThenPreviousButtonIsEnabled()
        {
            Assert.AreEqual(true, serviceMoniterPage.PreviousButton.Enabled, "Previous button is disabled");
        }

        [Then(@"Deploy button is disabled")]
        public void ThenDeployButtonIsDisabled()
        {
            Assert.AreEqual(false, serviceMoniterPage.DeployButton.Enabled, "Deploy button is enabled");
        }

        [Then(@"Page x of y label is displayed")]
        public void ThenPageXOfYLabelIsDisplayed()
        {
            Assert.AreEqual(true, serviceMoniterPage.PaginationXofY.GetElementVisibility(), "Page x of y label is not displayed");
        }

        [Then(@"Displaying x to y of z results label is displayed")]
        public void ThenDisplayingXToYOfZResultsLabelIsDisplayed()
        {
            Assert.AreEqual(true, serviceMoniterPage.PaginationDisplayXofY.GetElementVisibility(), "Displaying x to y of z results label is not displayed");
        }

        [Then(@"Select all checkbox in column 1 is unchecked")]
        public void ThenSelectAllCheckboxInColumnIsUnchecked()
        {
            Assert.AreEqual(false, serviceMoniterPage.SelectAllCheckBox.Selected, "Select all checkbox in column 1 is checked");
        }

        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenInColumnIsDisplayed(string headingName)
        {
            IWebElement headingElement=null;
            string ExpectedHeadingText=null;
            switch(headingName.ToLower().Trim())
            {
                case "serial number": headingElement = serviceMoniterPage.SerialNumHeading;
                    ExpectedHeadingText = ServiceMoniterPage.ExpectedValues.SerialNumHeadingText;
                    break;
                case "call home period":
                    headingElement = serviceMoniterPage.CallHomePeriodHeading;
                    ExpectedHeadingText = ServiceMoniterPage.ExpectedValues.CallHomePeriodHeadingText;
                    break;
                case "deployment mode":
                    headingElement = serviceMoniterPage.DeploymentModeHeading;
                    ExpectedHeadingText = ServiceMoniterPage.ExpectedValues.DeploymentModeHeadingText;
                    break;
                case "location":
                    headingElement = serviceMoniterPage.LocationHeading;
                    ExpectedHeadingText = ServiceMoniterPage.ExpectedValues.LocationHeadingText;
                    break;
                case "last files deployed":
                    headingElement = serviceMoniterPage.LastFilesDeployedHeading;
                    ExpectedHeadingText = ServiceMoniterPage.ExpectedValues.LastFilesDeployedHeadingText;
                    break;
                default: Assert.Fail(headingName+" does not exist in the test data.\n");
                    break;
            }
            Assert.AreEqual(true, headingElement.GetElementVisibility(), headingName+" is not displayed");
            string ActualHeadingText = headingElement.Text;
            Assert.AreEqual(ExpectedHeadingText, ActualHeadingText, headingName+"is not matching with the expected value");

        }

        [Then(@"Select all checkbox is in column (.*)")]
        public void ThenSelectAllCheckboxIsInColumn(int columnNumber)
        {
            string firstcolumnId = serviceMoniterPage.TableHeading.FindElements(By.TagName("div"))[columnNumber - 1].GetAttribute("id");
            Assert.AreEqual(UpdateSelectDevicesPage.Locators.SelectAllcheckBoxID, firstcolumnId, "Select all checkbox is not in column " + columnNumber);
        }

        [Then(@"""(.*)"" label is in column (.*)")]
        public void ThenLabelIsInColumn(string columnHeading, int columnNumber)
        {
            IList<IWebElement> columns = serviceMoniterPage.TableHeading.FindElements(By.TagName("div"));
            Assert.AreEqual(columnHeading.ToLower().Trim(), columns[columnNumber - 1].Text.ToLower(), columnHeading + " is not in " + columnNumber);
        }



        [Given(@"user is on Service Monitor Settings page with ""(.*)"" entries")]
        public void GivenUserIsOnServiceMonitorSettingsPageWithEntries(string noOfEntries)
        {
            switch(noOfEntries)
            {
                case "<=50":
                    GivenUserIsOnServiceMonitorSettingsPage();
                    break;
                case ">50":
                    _scenarioContext.Pending();
                    break;
                case "50 and <=100":
                    _scenarioContext.Pending();
                    break;
                default: Assert.Fail("Invalid no of service moniter");
                    break;


            }
        }

        [Then(@"Previous page icon is disabled")]
        public void ThenPreviousPageIconIsDisabled()
        {
            String PageNumberBeforeClick = serviceMoniterPage.PaginationXofY.Text;
            serviceMoniterPage.PaginationPreviousButton.JavaSciptClick();
            string PageNumberAfterClick = serviceMoniterPage.PaginationXofY.Text;
            Assert.AreEqual(PageNumberBeforeClick, PageNumberAfterClick, "Previous page button is enabled");
        }

        [Then(@"Next page icon is disabled")]
        public void ThenNextPageIconIsDisabled()
        {
            String PageNumberBeforeClick = serviceMoniterPage.PaginationXofY.Text;
            serviceMoniterPage.PaginationNextButton.JavaSciptClick();
            string PageNumberAfterClick = serviceMoniterPage.PaginationXofY.Text;
            Assert.AreEqual(PageNumberBeforeClick, PageNumberAfterClick, "Next page button is enabled");
        }

        [Then(@"Next page icon is enabled")]
        public void ThenNextPageIconIsEnabled()
        {
            String PageNumberBeforeClick = serviceMoniterPage.PaginationXofY.Text;
            serviceMoniterPage.PaginationNextButton.JavaSciptClick();
            string PageNumberAfterClick = serviceMoniterPage.PaginationXofY.Text;
            Assert.AreNotEqual(PageNumberBeforeClick, PageNumberAfterClick, "Next page button is not enabled");
        }



        [Given(@"user selects Call home period as P1D \(24 HOURS\) and Deployment mode as FALSE")]
        public void GivenUserSelectsCallHomePeriodAsPDHOURSAndDeploymentModeAsFALSE()
        { 
            SelectElement select = new SelectElement(serviceMoniterPage.CallHomePeriodDropDown);
            select.SelectByText("P1D",true);
            serviceMoniterPage.DeploymentModeDropDown.SelectDDL("False");
        }

        [When(@"user selects checkbox for first data row in table")]
        public void WhenUserSelectsCheckboxForFirstDataRowInTable()
        {
            serviceMoniterPage.FirstDeviceCheckBox.Click();
        }

        [Then(@"Upgrade count label updated with selection of row")]
        public void ThenUpgradeCountLabelUpdatedWithSelectionOfRow()
        {
            Assert.AreEqual(ServiceMoniterPage.ExpectedValues.Destination1DeviceCountText, serviceMoniterPage.DestinalitioDeviceCount.Text, "Upgrade count label is not updated.\n");
        }

        [Then(@"Deploy button is enabled")]
        public void ThenDeployButtonIsEnabled()
        {
            Assert.AreEqual(true, serviceMoniterPage.DeployButton.Enabled, "Deploy button is not enabled");
        }

        [When(@"user clicks Deploy button")]
        public void WhenUserClicksDeployButton()
        {
            serviceMoniterPage.DeployButton.Click();
        }

        [Given(@"first (.*) entries are displayed")]
        public void GivenFirstEntriesAreDisplayed(int p0)
        {
            //id's are not available
            _scenarioContext.Pending();
        }

        [When(@"user clicks Next page button")]
        public void WhenUserClicksNextPageButton()
        {
            SetMethods.ScrollToBottomofWebpage();
            serviceMoniterPage.PaginationNextButton.JavaSciptClick();
        }

        [Then(@"second page of entries is displayed")]
        public void ThenSecondPageOfEntriesIsDisplayed()
        {
            _scenarioContext.Pending();
        }


    }
}
