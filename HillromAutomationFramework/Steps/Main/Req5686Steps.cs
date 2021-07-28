﻿using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Main
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5686")]
    public class Req5686Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();

        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));
        private ScenarioContext _scenarioContext;

        public Req5686Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"the user is on Landing page")]
        public void GivenTheUserIsOnLandingPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            Assert.AreEqual(true, landingPage.Organization0Facility0Title.GetElementVisibility(), "User is not on Landing page.");
        }
        
        [When(@"user clicks Facility panel for an organization")]
        public void WhenUserClicksFacilityPanelForAnOrganization()
        {
            landingPage.Organization0Facility0Title.Click();
        }
        
        [Then(@"Organization label is displayed")]
        public void ThenOrganizationLabelIsDisplayed()
        {
            //replace organization label xpath with id. 
            Assert.AreEqual(true, mainPage.OrganizationLabel.GetElementVisibility(), "Organization label is not displayed.");
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
            switch(columnHeading.ToLower().Trim())
            {
                case "type": 
                    heading = mainPage.TypeHeading;
                    break;
                case "firmware":
                    heading = mainPage.FirmwareHeading;
                    break;
                case "config file":
                    heading = mainPage.ConfigFileHeading;
                    break;
                case "asset tag":
                    heading = mainPage.AssetTagHeading;
                    break;
                case "serial number":
                    heading = mainPage.SerialNumberHeading;
                    break;
                case "location":
                    heading = mainPage.LocationHeading;
                    break;
                case "last connected":
                    heading = mainPage.LastConnectedHeading;
                    break;
                case "pm due":
                    heading = mainPage.PMDueHeading;
                    break;
                default: Assert.Fail(columnHeading+" is an invalid heading name.");
                    break;
            }
            Assert.AreEqual(true, heading.GetElementVisibility(),columnHeading+ " heading is not displayed.");
        }


        [When(@"""(.*)"" label is in column (.*)")]
        public void WhenColumnHeadingIsDisplayed(string columnName, int columnNumber)
        {
            //Entire row
            IList<IWebElement> DeviceTableHeadingElements = mainPage.DeviceListTableHeader.FindElements(By.TagName("th"));
            //Matching the column place
            Assert.AreEqual(columnName.ToLower().Trim(), DeviceTableHeadingElements[columnNumber - 1].Text.ToLower(), columnName + " is not displayed at column number \""+columnNumber+"\".");
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
            landingPage.Organization0Facility0Title.Click();
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
            string ExpectedOption = MainPage.ExpectedValues.AllAssetsText;
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
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.Organization0Facility0Title.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(MainPage.Locators.DeviceListTableID)));
        }

        [Given(@"downward arrow shows for ascending order beside Serial Number column header for default sorted column")]
        public void GivenDownwardArrowShowsForAscendingOrderBesideSerialNumberColumnHeaderForDefaultShortedColumn()
        {
            Assert.AreEqual("serial ascending", mainPage.SerialNumberHeading.GetAttribute("class"),"Downward arrow does not appear on selrial column header.");
        }

        [Then(@"downward arrow shows beside ""(.*)"" column header for ascending order")]
        public void ThenDownwordArrowShowsBesideColumnHeaderForAscendingOrder(string columnHeaderName)
        {
            string ExpectedClassName = "";
            string ActualClassName = null;
            switch (columnHeaderName.ToLower().Trim())
            {
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
            Thread.Sleep(1000);
            Assert.AreEqual(true, mainPage.CheckSort(columnHeader, "d"),"Device list is not sorted by \""+columnHeader+"\" in descending order." );
        }

        [Then(@"list is sorted in ascending order by ""(.*)""")]
        public void ThenListIsSortedInAscendingOrderBy(string columnHeader)
        {
            Thread.Sleep(1000);
            Assert.AreEqual(true, mainPage.CheckSort(columnHeader, "a"), "Device list is not sorted by \"" + columnHeader + "\" in ascending order.");
        }


    }
}
