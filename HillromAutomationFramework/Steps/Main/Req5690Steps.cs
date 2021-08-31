using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Main
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5690")]
    class Req5690Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();

        [Given(@"user is on Assets List page")]
        public void GivenUserIsOnAssetsListPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
        }

        [Given(@"user is on Assets List page with more than 1 device")]
        public void GivenUserIsOnAssetsListPageWithMoreThanDevice()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
            landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            int count = mainPage.DeviceListRow.GetElementCount();
            Assert.Greater(count ,1, "More than one device is not displayed");
        }

        [Given(@"user has performed asset search")]
        public void GivenUserHasPerformedAssetSearch()
        {
            GivenUserIsOnAssetsListPage();
            string ExpectedPartialValue = MainPage.ExpectedValues.PartialFirmwareVersionText;
            mainPage.SearchField.EnterText(ExpectedPartialValue);
            mainPage.SearchField.EnterText(Keys.Enter);
            Thread.Sleep(1000);
        }

        [Given(@"there are devices matching the asset search")]
        public void GivenThereAreDevicesMatchingTheAssetSearch()
        {
            for (int i = 1; i <= mainPage.DeviceListRow.Count; i++)
            {
                string ActualAssetTypeText = PropertyClass.Driver.FindElement(By.XPath("//tr[" + i + "]/td[" + 3 + "]")).Text;
                Assert.AreEqual(true, ActualAssetTypeText.Contains(MainPage.ExpectedValues.PartialFirmwareVersionText), "Only the same Asset Tags data is not appering that contain Search text");
            }
        }

        [When(@"user enters partial Type text in Search field")]
        public void WhenUserEntersPartialTypeTextInSearchField()
        {
            string ExpectedPartialValue = MainPage.ExpectedValues.ValidPartialString.ToString();
            mainPage.SearchField.EnterText(ExpectedPartialValue);
        }

        [When(@"presses Enter key")]
        public void WhenPressesEnterKey()
        {
            mainPage.SearchField.EnterText(Keys.Enter);
            Thread.Sleep(2000);
        }

        [When(@"user enters partial Asset tag text in Search field")]
        public void WhenUserEntersPartialAssetTagTextInSearchField()
        {
            string ExpectedPartialText = MainPage.ExpectedValues.ValidPartialString.ToString();
            mainPage.SearchField.EnterText(ExpectedPartialText);
        }

        [When(@"user enters partial Serial number text in Search field")]
        public void WhenUserEntersPartialSerialNumberTextInSearchField()
        {
            string ExpectedPartialText = MainPage.ExpectedValues.PartialSerialNumberText;
            mainPage.SearchField.EnterText(ExpectedPartialText);
        }

        [When(@"user enters partial Firmware version text in Search field")]
        public void WhenUserEntersPartialFirmwareVersionTextInSearchField()
        {
            string ExpectedPartialText = MainPage.ExpectedValues.PartialFirmwareVersionText;
            mainPage.SearchField.EnterText(ExpectedPartialText);
        }

        [When(@"user enters text in Search field that does not match any asset in table")]
        public void WhenUserEntersTextInSearchFieldThatDoesNotMatchAnyAssetInTable()
        {
            mainPage.SearchField.EnterText(MainPage.ExpectedValues.InvalidPartialString);
        }

        [When(@"user enters valid MAC address in advanced AP search string")]
        public void WhenUserEntersValidMACAddressInAdvancedAPSearchString()
        {
            mainPage.SearchField.EnterText(MainPage.ExpectedValues.MACAddressText);
        }

        [When(@"user clicks X button")]
        public void WhenUserClicksXButton()
        {
            mainPage.SearchFieldCancelButton.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Search field contains hint text")]
        public void ThenSearchFieldContainsHintText()
        {
            Assert.AreEqual(MainPage.ExpectedValues.SearchFieldHintText, mainPage.SearchField.GetAttribute("placeholder"), "Search field hint text does not match the expected value.");
        }

        [Then(@"results in table contain only assets with types that contain Search text")]
        public void ThenResultsInTableContainOnlyAssetsWithTypesThatContainSearchText()
        {
            for (int i = 1; i <= mainPage.DeviceListRow.Count; i++)
            {
                string ActualAssetTypeText = PropertyClass.Driver.FindElement(By.XPath("//tr[" + i + "]/td[" + 1 + "]")).Text;
                Assert.AreEqual(true, ActualAssetTypeText.Contains(MainPage.ExpectedValues.PartialTypeText), "Only the same Asset Tags data is not appering that contain Search text");
            }
        }

        [Then(@"results in table contain only assets with Asset tags that contain Search text")]
        public void ThenResultsInTableContainOnlyAssetsWithAssetTagsThatContainSearchText()
        {
            for (int i = 1; i <= mainPage.DeviceListRow.Count; i++)
            {
                string ActualAssetTagText = PropertyClass.Driver.FindElement(By.XPath("//tr[" + i + "]/td[1]")).Text;
                Assert.AreEqual(true, ActualAssetTagText.Contains(MainPage.ExpectedValues.PartialAssetTagText), "Only the same Asset Tags data is not appering that contain Search text");
            }
        }

        [Then(@"results in table contain only assets with Serial numbers that contain Search text")]
        public void ThenResultsInTableContainOnlyAssetsWithSerialNumbersThatContainSearchText()
        {
            for (int i = 1; i <= mainPage.DeviceListRow.Count; i++)
            {
                string ActualSerialNumberText = PropertyClass.Driver.FindElement(By.XPath("//tr[" + i + "]/td[" + 6 + "]")).Text;
                Assert.AreEqual(true, ActualSerialNumberText.Contains(MainPage.ExpectedValues.PartialSerialNumberText), "Only the same Asset Tags data is not appering that contain Search text");
            }
        }

        [Then(@"results in table contain only assets with Firmware versions that contain Search text")]
        public void ThenResultsInTableContainOnlyAssetsWithFirmwareVersionsThatContainSearchText()
        {
            for (int i = 1; i <= mainPage.DeviceListRow.Count; i++)
            {
                string ActualFirmwareText = PropertyClass.Driver.FindElement(By.XPath("//tr[" + i + "]/td[" + 3 + "]")).Text;
                Assert.AreEqual(true, ActualFirmwareText.Contains(MainPage.ExpectedValues.PartialFirmwareVersionText), "Only the same Asset Tags data is not appering that contain Search text");
            }
        }

        [Then(@"(.*) results are displayed")]
        public void ThenResultsAreDisplayed(int p0)
        {
            string[] PageInformation = mainPage.PaginationDisplay.Text.Split();
            string str2 = PageInformation[3];
            int NoOfPages = int.Parse(str2);
            Assert.AreEqual(true, p0 == NoOfPages, "Zero results are not displayed.");
        }

        [Then(@"Displaying (.*) to (.*) of (.*) results is displayed")]
        public void ThenDisplayingToOfResultsIsDisplayed(int currentPage, int lastPage, int totalRecords)
        {
            string[] PageInformation = mainPage.PaginationDisplay.Text.Split();
            bool IsPageResultDisplayed = mainPage.DisplayPageResults(PageInformation, currentPage, lastPage, totalRecords);
            Assert.AreEqual(true, IsPageResultDisplayed, "Displaying 0 to 0 of 0 results is not displayed.");
        }

        [Then(@"results in table contain only assets with AP MAC addresses that match Search text")]
        public void ThenResultsInTableContainOnlyAssetsWithAPMACAddressesThatMatchSearchText()
        {
            int TotalRecords = mainPage.DeviceListRow.Count;

            Assert.AreEqual(true, TotalRecords == MainPage.ExpectedValues.MACTotalRecords, "Record is not displaying as per expected.");
            bool IsMACAddressVisible = mainPage.APMACAddressesMatchSearchText(mainPage.CompInfo, mainPage.RadioNewMarr, mainPage.MACAddress);
            Assert.AreEqual(true, IsMACAddressVisible, "MAC Address is not visible");
        }

        [Then(@"Search field is cleared")]
        public void ThenSearchFieldIsCleared()
        {
            string SearchFieldText = mainPage.SearchField.Text;
            Assert.AreEqual(0, SearchFieldText.Length, "Search field is not cleared.");
        }

        [Then(@"all assets are displayed")]
        public void ThenAllAssetsAreDisplayed()
        {
            Assert.AreEqual(true, MainPage.ExpectedValues.AllOrganizationsDevicesListWithRollUp == mainPage.DeviceListRow.Count, "All assets are not displayed.");
        }

        [Then(@"Next page and Previous page icons are displayed")]
        public void ThenNextPageAndPreviousPageIconsAreDisplayed()
        {
            Assert.AreEqual(true, mainPage.PaginationNextIcon.GetElementVisibility(), "Next icon is displayed");
            Assert.AreEqual(true, true == mainPage.PaginationPreviousIcon.GetElementVisibility(), "Previous icon is displayed");
        }

        [Then(@"Page x of y label is displayed")]
        public void ThenPageXOfYLabelIsDisplayed()
        {
            Assert.AreEqual(true, mainPage.PaginationXOfYLabel.GetElementVisibility(), "Page x of y label is not displayed.");
        }

        [Then(@"Displaying x to y of z results label is displayed")]
        public void ThenDisplayingXToYOfZResultsLabelIsDisplayed()
        {
            Assert.AreEqual(true, mainPage.PaginationDisplay.GetElementVisibility(), "Displaying x to y of z results label is not displayed.");
        }
    }
}
