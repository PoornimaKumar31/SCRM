using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AssetsTab;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.AssetsTab
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5686")]
    public class Req5686Steps
    {
        private readonly LoginPage loginPage;
        private readonly LandingPage landingPage;
        private readonly MainPage mainPage;

        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverWait _wait;

        public Req5686Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            loginPage = new LoginPage(driver);
            landingPage = new LandingPage(driver);
            mainPage = new MainPage(driver);
        }

        [Given(@"the user is on Landing page")]
        public void GivenTheUserIsOnLandingPage()
        {
            loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithRollUpPage);
            Assert.AreEqual(true, landingPage.LNTAutomatedTestEastOrganizationFacilityPanelTest4Title.GetElementVisibility(), "User is not on Landing page.");
        }
        
        [When(@"user clicks Facility panel for an organization")]
        public void WhenUserClicksFacilityPanelForAnOrganization()
        {
            landingPage.LNTAutomatedTestEastOrganizationFacilityPanelTest4Title.Click();
        }
        
        [Then(@"Organization label is displayed")]
        public void ThenOrganizationLabelIsDisplayed()
        {
            Assert.AreEqual(true, mainPage.OrganizationLabel.GetElementVisibility(), "Organization label is not displayed.");
            Assert.AreEqual(MainPageExpectedValue.OrganizationLabelText.ToLower(), mainPage.OrganizationLabel.Text.ToLower(),"Organization label is not matching the expected value.");
        }
        
        [Then(@"Organization dropdown is displayed")]
        public void ThenOrganizationDropdownIsDisplayed()
        {
            Assert.AreEqual(true, mainPage.OrganizationDropdown.GetElementVisibility(), "Organzation dropdown is not displayed.");
        }
        
        [Then(@"Asset type label is displayed")]
        public void ThenAssetTypeLabelIsDisplayed()
        {
            Assert.AreEqual(true, mainPage.AssetTypeLabel.GetElementVisibility(), "Asset type label is not displayed.");
            Assert.AreEqual(MainPageExpectedValue.AssetTypeLabelText.ToLower(), mainPage.AssetTypeLabel.Text.ToLower(), "Asset type label is not matching with the expected value.");
        }
        
        [Then(@"Asset type dropdown is displayed")]
        public void ThenAssetTypeDropdownIsDisplayed()
        {
            Assert.AreEqual(true, mainPage.AssetTypeDropDown.GetElementVisibility(), "Asset type dropdown is not displayed.");
        }
        
        [Then(@"Search field is displayed")]
        public void ThenSearchFieldIsDisplayed()
        {
            Assert.AreEqual(true, mainPage.SearchField.GetElementVisibility(), "Search field is displayed.");
        }
        
        [Then(@"""(.*)"" column heading is displayed")]
        public void ThenColumnHeadingIsDisplayed(string columnHeading)
        {
            IWebElement heading=null;
            string ExpectedText = "";
            switch(columnHeading.ToLower().Trim())
            {
                case "type": 
                    heading = mainPage.TypeHeading;
                    ExpectedText = MainPageExpectedValue.TypeHeadingText;
                    break;
                case "status":
                    heading = mainPage.StatusHeading;
                    ExpectedText = MainPageExpectedValue.StatusHeadingText;
                    break;
                case "firmware":
                    heading = mainPage.FirmwareHeading;
                    ExpectedText = MainPageExpectedValue.FirmwareHeadingText;
                    break;
                case "config file":
                    heading = mainPage.ConfigFileHeading;
                    ExpectedText = MainPageExpectedValue.ConfigFileHeadingText;
                    break;
                case "asset tag":
                    heading = mainPage.AssetTagHeading;
                    ExpectedText = MainPageExpectedValue.AssetTagHeadingText;
                    break;
                case "serial number":
                    heading = mainPage.SerialNumberHeading;
                    ExpectedText = MainPageExpectedValue.SerialNumberHeadingText;
                    break;
                case "location":
                    heading = mainPage.LocationHeading;
                    ExpectedText = MainPageExpectedValue.LocationHeadingText;
                    break;
                case "last connected":
                    heading = mainPage.LastConnectedHeading;
                    ExpectedText = MainPageExpectedValue.LastConnectedHeadingText;
                    break;
                case "pm due":
                    heading = mainPage.PMDueHeading;
                    ExpectedText = MainPageExpectedValue.PmDueHeadingText;
                    break;
                default: Assert.Fail(columnHeading+" is an invalid heading name.");
                    break;
            }
            Assert.AreEqual(true, heading.GetElementVisibility(),columnHeading+ " heading is not displayed.");
            Assert.AreEqual(ExpectedText.ToLower(), heading.Text.ToLower(), columnHeading + " is not matching with the expected value.");
        }


        [Then(@"""(.*)"" label is in column (.*)")]
        public void ThenColumnHeadingIsDisplayed(string columnName, int columnNumber)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));

            //Entire row
            IList<IWebElement> DeviceTableHeadingElements = mainPage.DeviceListTableHeader.FindElements(By.TagName("th"));

            List<string> columnHeadingListText = new List<string>();

            foreach (IWebElement column in DeviceTableHeadingElements)
            {
                columnHeadingListText.Add(column.Text.ToLower());
            }
            //Zero based indexing
            columnNumber--;

            //Matching the column place
            columnHeadingListText.Should().HaveElementAt(columnNumber, columnName.ToLower(), because: columnName + " column heading should be in column number " + columnNumber);
        }

        [Then(@"Page x of y label is displayed")]
        public void ThenPageXOfYLabelIsDisplayed()
        {
            Assert.AreEqual(true, mainPage.PaginationXOfYLabel.GetElementVisibility(), "Page x of y label is not displayed");
        }
        
        [Then(@"Displaying x to y of z results label is displayed")]
        public void ThenDisplayingXToYOfZResultsLabelIsDisplayed()
        {
            Assert.AreEqual(true, mainPage.PaginationDisplay.GetElementVisibility(), "Displaying x to y of z results label is not displayed");
        }

        [When(@"user clicks on the Facility panel for specific Organization")]
        public void WhenUserClicksOnTheFacilityPanelForSpecificOrganization()
        {
            landingPage.LNTAutomatedTestEastOrganizationFacilityPanelTest4Title.Click();
        }

        [Then(@"assets page open with selected ASSETS tab")]
        public void ThenAssetsPageOpenWithSelectedASSETSTab()
        {
            Assert.AreEqual("devices selected", mainPage.AssetsTab.GetAttribute("class"), "Assets tab is not selected.");
        }

        [Then(@"devices list shows for all Assets for selected Organization and Facility")]
        public void ThenDevicesListShowsForAllAssetsForSelectedOrganizationAndFacility()
        {
            Assert.AreEqual(15, mainPage.DeviceListRow.GetElementCount(),"Expected devices are not present in the device list.");
        }

        [Then(@"organization drop-down displays Selected Organization and Facility")]
        public void ThenOrganizationDrop_DownDisplaysSelectedOrganizationAndFacility()
        {
            Assert.AreEqual(true,mainPage.SelectedOrganizationName.GetElementVisibility(),"Selected Organization name is not displayed.");
            Assert.AreEqual(true, mainPage.SelectedFacilityName.GetElementVisibility(), "Selected facility name is not displayed.");
        }

        [Then(@"asset type drop-down displays All assets selected")]
        public void ThenAssetTypeDrop_DownDisplaysAllAssetsSelected()
        {
            string AssetTypeDropdownSelectedOption = mainPage.AssetTypeDropDown.GetSelectedOptionFromDDL();
            string ExpectedOption = MainPageExpectedValue.AllAssetsText;
            Assert.AreEqual(ExpectedOption, AssetTypeDropdownSelectedOption, AssetTypeDropdownSelectedOption + " option is selected in Asset type dropdown");
        }

        [Then(@"Search textbox with search icon at right end of text box")]
        public void ThenSearchTextboxWithSearchIconAtRightEndOfTextBox()
        {
            Assert.AreEqual(true,mainPage.SearchField.GetElementVisibility(),"Search field is not displayed.");
        }

        [When(@"user clicks ""(.*)"" column header")]
        public void WhenUserClicksColumnHeader(string columnHeaderName)
        {
            switch (columnHeaderName.ToLower().Trim())
            {
                case "status":
                    mainPage.StatusHeading.Click();
                    break;
                case "firmware":
                    mainPage.FirmwareHeading.Click();
                    break;
                case "config file":
                    mainPage.ConfigFileHeading.Click();
                    break;
                case "asset tag":
                    mainPage.AssetTagHeading.Click();
                    break;
                case "serial number":
                    mainPage.SerialNumberHeading.Click();
                    break;
                case "last connected":
                    mainPage.LastConnectedHeading.Click();
                    break;
                case "pm due":
                    mainPage.PMDueHeading.Click();
                    break;
                default:
                    Assert.Fail(columnHeaderName + " does not match with the test data.");
                    break;
            }
            Thread.Sleep(2000);
        }


        [Given(@"user is on Assets list page")]
        public void GivenUserIsOnAssetsListPage()
        {
            loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithOutRollUpPage);
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));

            
        }

        [Given(@"downward arrow shows for ascending order beside Serial Number column header for default sorted column")]
        public void GivenDownwardArrowShowsForAscendingOrderBesideSerialNumberColumnHeaderForDefaultShortedColumn()
        {
            mainPage.SerialNumberHeading.Click();
            Thread.Sleep(1000);
            string attributeValue = mainPage.SerialNumberHeading.GetAttribute("class");
            Assert.AreEqual(true, "serial ascending" == attributeValue, "Downward arrow does not show for ascending order beside Serial Number column header for default sorted column.");
        }

        [Then(@"downward arrow shows beside ""(.*)"" column header for ascending order")]
        public void ThenDownwordArrowShowsBesideColumnHeaderForAscendingOrder(string columnHeaderName)
        {
            string ExpectedClassName = "";
            string ActualClassName = null;
            switch (columnHeaderName.ToLower().Trim())
            {
                case "status":
                    ActualClassName = mainPage.StatusHeading.GetAttribute("class");
                    ExpectedClassName = "status ascending";
                    break;
                case "firmware":
                    ActualClassName = mainPage.FirmwareHeading.GetAttribute("class");
                    ExpectedClassName = "firmware ascending";
                    break;
                case "config file":
                    ActualClassName = mainPage.ConfigFileHeading.GetAttribute("class");
                    ExpectedClassName = "config ascending";
                    break;
                case "asset tag":
                    ActualClassName = mainPage.AssetTagHeading.GetAttribute("class");
                    ExpectedClassName = "asset sorting ascending";
                    break;
                case "serial number":
                    ActualClassName = mainPage.SerialNumberHeading.GetAttribute("class");
                    ExpectedClassName = "serial ascending";
                    break;
                case "last connected":
                    ActualClassName = mainPage.LastConnectedHeading.GetAttribute("class");
                    ExpectedClassName = "connection ascending";
                    break;
                case "pm due":
                    ActualClassName = mainPage.PMDueHeading.GetAttribute("class");
                    ExpectedClassName = "calibration ascending";
                    break;
                default:
                    Assert.Fail(columnHeaderName + " is not a valid column header");
                    break;
            }
            Assert.AreEqual(ExpectedClassName, ActualClassName, "Downward arrow is not displayed beside " + columnHeaderName);
        }


        [Then(@"upward arrow shows beside ""(.*)"" column header for descending order")]
        public void ThenUpwordArrowShowsBesideColumnHeaderForDescendingOrder(string columnHeaderName)
        {
            string ExpectedClassName = "";
            string ActualClassName = null;
            switch (columnHeaderName.ToLower().Trim())
            {
                case "status":
                    ActualClassName = mainPage.StatusHeading.GetAttribute("class");
                    ExpectedClassName = "status descending";
                    break;
                case "firmware":
                    ActualClassName = mainPage.FirmwareHeading.GetAttribute("class");
                    ExpectedClassName = "firmware descending";
                    break;
                case "config file":
                    ActualClassName = mainPage.ConfigFileHeading.GetAttribute("class");
                    ExpectedClassName = "config descending";
                    break;
                case "asset tag":
                    ActualClassName = mainPage.AssetTagHeading.GetAttribute("class");
                    ExpectedClassName = "asset sorting descending";
                    break;
                case "serial number":
                    Thread.Sleep(2000);
                    ActualClassName = mainPage.SerialNumberHeading.GetAttribute("class");
                    ExpectedClassName = "serial descending";
                    break;
                case "last connected":
                    ActualClassName = mainPage.LastConnectedHeading.GetAttribute("class");
                    ExpectedClassName = "connection descending";
                    break;
                case "pm due":
                    ActualClassName = mainPage.PMDueHeading.GetAttribute("class");
                    ExpectedClassName = "calibration descending";
                    break;
                default:
                    Assert.Fail(columnHeaderName + " is not a valid column header");
                    break;
            }
            Assert.AreEqual(ExpectedClassName, ActualClassName, "Upward arrow is not displayed beside " + columnHeaderName);
        }

        [Then(@"list is sorted in descending order by ""(.*)""")]
        public void ThenListIsSortedInDescendingOrderBy(string columnHeader)
        {
            Thread.Sleep(3000);
            List<string> ActualColumnData = mainPage.GetColumnData(columnHeader);

            List<string> SortedColumnData;

            List<DateTime> columnDateList = new List<DateTime>();

            //Sorting for date list
            if (columnHeader.ToLower().Equals("pm due") || columnHeader.ToLower().Equals("last connected"))
            {
                //Converting into date list
                foreach(string data in ActualColumnData)
                {
                    if(!(string.IsNullOrEmpty(data)))
                    {
                        columnDateList.Add(DateTime.Parse(data));
                    }
                }

                //Assertion
                columnDateList.Should().BeInDescendingOrder(because:"Asset list should be sorted by " + columnHeader + " in descending order.");

            }
            else
            {
                //Asserting
                SortedColumnData = new List<string>(ActualColumnData);
                SortedColumnData.Sort();
                SortedColumnData.Reverse();

                ActualColumnData.Should().BeEquivalentTo(SortedColumnData,because:"Asset list should be sorted by " + columnHeader + " in descending order.");
            }
        }

        [Then(@"list is sorted in ascending order by ""(.*)""")]
        public void ThenListIsSortedInAscendingOrderBy(string columnHeader)
        {
            Thread.Sleep(3000);
            List<string> ActualColumnData = mainPage.GetColumnData(columnHeader);

            List<string> SortedColumnData;

            List<DateTime> columnDateList = new List<DateTime>();

            //Sorting for date list
            if(columnHeader.ToLower().Equals("pm due") || columnHeader.ToLower().Equals("last connected"))
            {
                //Converting into date list
                foreach (string data in ActualColumnData)
                {
                    if (!(string.IsNullOrEmpty(data) && string.IsNullOrWhiteSpace(data)))
                    {
                        columnDateList.Add(DateTime.Parse(data));
                    }
                }

                //Asserting
                columnDateList.Should().BeInAscendingOrder(because: "Asset list should be sorted by " + columnHeader + " in ascending order.");

            }
            else
            {
                SortedColumnData = new List<string>(ActualColumnData);
                SortedColumnData.Sort();
                //Asserting

                ActualColumnData.Should().BeEquivalentTo(SortedColumnData, because: "Asset list should be sorted by " + columnHeader + " in ascending order.");
            }  
        }



        [Then(@"beds with errors are at the top of the list")]
        public void ThenBedsWithErrorsAreAtTheTopOfTheList()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0); // Implicit wait for 5 seconds
           
            //Finding the index of sorted column
            int columnNumber = mainPage.GetColumnIndex("status");

            //Taking the column data from the application
            IList<IWebElement> li1 = mainPage.DeviceListTableBody.FindElements(By.XPath("//td[" + columnNumber + "]"));

            List<int> li = new List<int>();

            foreach (IWebElement e in li1)
            {
                li.Add(e.FindElements(By.TagName("img")).Count);
            }

            bool isTrue = true;
            int i = 0;

            while (isTrue)
            {

                if (li[i] == 1)
                {
                    li.RemoveAt(0);
                }
                else
                {
                    isTrue = false;
                }
            }


            li.Distinct().Skip(1).Any().Should().BeFalse("Error Status message is not at the top");
            
        }

        [Then(@"beds with errors are at the bottom of the list")]
        public void ThenBedsWithErrorsAreAtTheBottomOfTheList()
        {
            mainPage.GoToLastPage(_driver,27);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0); // Implicit wait for 5 seconds

            //Finding the index of sorted column
            int columnNumber = mainPage.GetColumnIndex("status");

            //Taking the column data from the application
            IList<IWebElement> li1 = mainPage.DeviceListTableBody.FindElements(By.XPath("//td[" + columnNumber + "]"));

            List<int> li = new List<int>();

            foreach (IWebElement e in li1)
            {
                li.Add(e.FindElements(By.TagName("img")).Count);
            }

            bool isTrue = true;
            int i = 0;

            while (isTrue)
            {

                if (li[i] == 0)
                {
                    li.RemoveAt(0);
                }
                else
                {
                    isTrue = false;
                }
            }


            li.Distinct().Skip(1).Any().Should().BeFalse("Error Status message is not at the bottom");
        }

    }
}
