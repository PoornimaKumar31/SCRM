using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.AssetsTab;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.AssetsTab
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5690")]
    class Req5690Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;

        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverWait _wait;


        public Req5690Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
        }

        [Given(@"user is on Assets List page")]
        public void GivenUserIsOnAssetsListPage()
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
        }

        [Given(@"user is on Assets List page with more than 1 device")]
        public void GivenUserIsOnAssetsListPageWithMoreThanDevice()
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Click();
            int count = _mainPage.DeviceListRow.GetElementCount();
            Assert.Greater(count ,1, "More than one device is not displayed");
        }

        [Given(@"user has performed asset search")]
        public void GivenUserHasPerformedAssetSearch()
        {
            GivenUserIsOnAssetsListPage();
            string ExpectedPartialValue = MainPageExpectedValue.PartialFirmwareVersionText;
            _mainPage.SearchField.EnterText(ExpectedPartialValue);
            _mainPage.SearchField.EnterText(Keys.Enter);
            Thread.Sleep(1000);
        }

        [Given(@"there are devices matching the asset search")]
        public void GivenThereAreDevicesMatchingTheAssetSearch()
        {
            for (int i = 1; i <= _mainPage.DeviceListRow.Count; i++)
            {
                string ActualAssetTypeText = _driver.FindElement(By.XPath("//tr[" + i + "]/td[" + 3 + "]")).Text;
                Assert.AreEqual(true, ActualAssetTypeText.Contains(MainPageExpectedValue.PartialFirmwareVersionText), "Only the same Asset Tags data is not appering that contain Search text");
            }
        }

        [When(@"user enters partial Type text in Search field")]
        public void WhenUserEntersPartialTypeTextInSearchField()
        {
            string ExpectedPartialValue = MainPageExpectedValue.ValidPartialString.ToString();
            _mainPage.SearchField.EnterText(ExpectedPartialValue);
        }

        [When(@"presses Enter key")]
        public void WhenPressesEnterKey()
        {
            _mainPage.SearchField.EnterText(Keys.Enter);
            Thread.Sleep(2000);
        }

        [When(@"user enters partial Asset tag text in Search field")]
        public void WhenUserEntersPartialAssetTagTextInSearchField()
        {
            string ExpectedPartialText = MainPageExpectedValue.ValidPartialString.ToString();
            _mainPage.SearchField.EnterText(ExpectedPartialText);
        }

        [When(@"user enters partial Serial number text in Search field")]
        public void WhenUserEntersPartialSerialNumberTextInSearchField()
        {
            string ExpectedPartialText = MainPageExpectedValue.PartialSerialNumberText;
            _mainPage.SearchField.EnterText(ExpectedPartialText);
        }

        [When(@"user enters partial Firmware version text in Search field")]
        public void WhenUserEntersPartialFirmwareVersionTextInSearchField()
        {
            string ExpectedPartialText = MainPageExpectedValue.PartialFirmwareVersionText;
            _mainPage.SearchField.EnterText(ExpectedPartialText);
        }

        [When(@"user enters text in Search field that does not match any asset in table")]
        public void WhenUserEntersTextInSearchFieldThatDoesNotMatchAnyAssetInTable()
        {
            _mainPage.SearchField.EnterText(MainPageExpectedValue.InvalidPartialString);
        }

        [When(@"user enters valid MAC address in advanced AP search string")]
        public void WhenUserEntersValidMACAddressInAdvancedAPSearchString()
        {
            _mainPage.SearchField.EnterText(MainPageExpectedValue.MACAddressText);
        }

        [When(@"user clicks X button")]
        public void WhenUserClicksXButton()
        {
            _mainPage.SearchFieldCancelButton.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Search field contains hint text")]
        public void ThenSearchFieldContainsHintText()
        {
            Assert.AreEqual(MainPageExpectedValue.SearchFieldHintText, _mainPage.SearchField.GetAttribute("placeholder"), "Search field hint text does not match the expected value.");
        }

        [Then(@"results in table contain only assets with types that contain Search text")]
        public void ThenResultsInTableContainOnlyAssetsWithTypesThatContainSearchText()
        {
            for (int i = 1; i <= _mainPage.DeviceListRow.Count; i++)
            {
                string ActualAssetTypeText = _driver.FindElement(By.XPath("//tr[" + i + "]/td[" + 1 + "]")).Text;
                Assert.AreEqual(true, ActualAssetTypeText.Contains(MainPageExpectedValue.PartialTypeText), "Only the same Asset Tags data is not appering that contain Search text");
            }
        }

        [Then(@"results in table contain only assets with Asset tags that contain Search text")]
        public void ThenResultsInTableContainOnlyAssetsWithAssetTagsThatContainSearchText()
        {
            for (int i = 1; i <= _mainPage.DeviceListRow.Count; i++)
            {
                string ActualAssetTagText = _driver.FindElement(By.XPath("//tr[" + i + "]/td[1]")).Text;
                Assert.AreEqual(true, ActualAssetTagText.Contains(MainPageExpectedValue.PartialAssetTagText), "Only the same Asset Tags data is not appering that contain Search text");
            }
        }

        [Then(@"results in table contain only assets with Serial numbers that contain Search text")]
        public void ThenResultsInTableContainOnlyAssetsWithSerialNumbersThatContainSearchText()
        {
            for (int i = 1; i <= _mainPage.DeviceListRow.Count; i++)
            {
                string ActualSerialNumberText = _driver.FindElement(By.XPath("//tr[" + i + "]/td[" + 6 + "]")).Text;
                Assert.AreEqual(true, ActualSerialNumberText.Contains(MainPageExpectedValue.PartialSerialNumberText), "Only the same Asset Tags data is not appering that contain Search text");
            }
        }

        [Then(@"results in table contain only assets with Firmware versions that contain Search text")]
        public void ThenResultsInTableContainOnlyAssetsWithFirmwareVersionsThatContainSearchText()
        {
            for (int i = 1; i <= _mainPage.DeviceListRow.Count; i++)
            {
                string ActualFirmwareText = _driver.FindElement(By.XPath("//tr[" + i + "]/td[" + 3 + "]")).Text;
                Assert.AreEqual(true, ActualFirmwareText.Contains(MainPageExpectedValue.PartialFirmwareVersionText), "Only the same Asset Tags data is not appering that contain Search text");
            }
        }

        [Then(@"(.*) results are displayed")]
        public void ThenResultsAreDisplayed(int p0)
        {
            string[] PageInformation = _mainPage.PaginationDisplay.Text.Split();
            string str2 = PageInformation[3];
            int NoOfPages = int.Parse(str2);
            Assert.AreEqual(true, p0 == NoOfPages, "Zero results are not displayed.");
        }

        [Then(@"Displaying (.*) to (.*) of (.*) results is displayed")]
        public void ThenDisplayingToOfResultsIsDisplayed(int currentPage, int lastPage, int totalRecords)
        {
            string[] PageInformation = _mainPage.PaginationDisplay.Text.Split();
            _mainPage.DisplayPageResults(PageInformation, currentPage, lastPage, totalRecords);
        }

        [Then(@"results in table contain only assets with AP MAC addresses that match Search text")]
        public void ThenResultsInTableContainOnlyAssetsWithAPMACAddressesThatMatchSearchText()
        {
            int TotalRecords = _mainPage.DeviceListRow.Count;

            Assert.AreEqual(true, TotalRecords == int.Parse(MainPageExpectedValue.MACTotalRecords), "Record is not displaying as per expected.");
            bool IsMACAddressVisible = _mainPage.APMACAddressesMatchSearchText(_driver,_mainPage.CompInfo, _mainPage.RadioNewMarr, _mainPage.MACAddress);
            Assert.AreEqual(true, IsMACAddressVisible, "MAC Address is not visible");
        }

        [Then(@"Search field is cleared")]
        public void ThenSearchFieldIsCleared()
        {
            string SearchFieldText = _mainPage.SearchField.Text;
            Assert.AreEqual(0, SearchFieldText.Length, "Search field is not cleared.");
        }

        [Then(@"all assets are displayed")]
        public void ThenAllAssetsAreDisplayed()
        {
            Assert.AreEqual(true, int.Parse(MainPageExpectedValue.AllOrganizationsDevicesListWithRollUp) == _mainPage.DeviceListRow.Count, "All assets are not displayed.");
        }

        [Then(@"Next page and Previous page icons are displayed")]
        public void ThenNextPageAndPreviousPageIconsAreDisplayed()
        {
            Assert.AreEqual(true, _mainPage.PaginationNextIcon.GetElementVisibility(), "Next icon is displayed");
            Assert.AreEqual(true, true == _mainPage.PaginationPreviousIcon.GetElementVisibility(), "Previous icon is displayed");
        }

        [Then(@"Page x of y label is displayed")]
        public void ThenPageXOfYLabelIsDisplayed()
        {
            Assert.AreEqual(true, _mainPage.PaginationXOfYLabel.GetElementVisibility(), "Page x of y label is not displayed.");
        }

        [Then(@"Displaying x to y of z results label is displayed")]
        public void ThenDisplayingXToYOfZResultsLabelIsDisplayed()
        {
            Assert.AreEqual(true, _mainPage.PaginationDisplay.GetElementVisibility(), "Displaying x to y of z results label is not displayed.");
        }
    }
}
