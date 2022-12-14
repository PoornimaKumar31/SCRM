using FluentAssertions;
using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.PageObjects.LandingPageObjects;
using HillromAutomationFramework.SupportingCode;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Landing
{
    [Binding, Scope(Tag = "SoftwareRequirementID_5689")]
    public class Req5689Steps
    {
        private readonly LoginPage _loginPage;
        private readonly LandingPage _landingPage;
        private readonly MainPage _mainPage;

        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverWait _wait;

        public Req5689Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _loginPage = new LoginPage(driver);
            _landingPage = new LandingPage(driver);
            _mainPage = new MainPage(driver);
        }

        [Given(@"user login with roll-up page")]
        public void GivenUserLoginWithRollupPage()
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
        }

        [Then(@"Roll-up page is displayed")]
        public void ThenRoll_UpPageIsDisplayed()
        {
            string ActualURL = _driver.Url;
            string ExpectedURL = PropertyClass.BaseURL+ LandingPageExpectedValue.RollupPageURL;
            ActualURL.Should().BeEquivalentTo(ExpectedURL, "Roll up page is not displayed");
        }

        [Given(@"user is on Landing page")]
        public void GivenUserIsOnLandingPage()
        {
            _loginPage.LogIn(_driver,LoginPage.LogInType.AdminWithRollUpPage);
        }

        [Given(@"Roll-up page is displayed")]
        public void GivenRoll_UpPageIsDisplayed()
        {
            string ExpectedValue = PropertyClass.BaseURL + LandingPageExpectedValue.RollupPageURL;
            string ActualValue = _driver.Url;
            ActualValue.Should().BeEquivalentTo(ExpectedValue, "User is not on landing page");
        }

        [Then(@"Organization name is displayed")]
        public void ThenOrganizationNameIsDisplayed()
        {
            //L&T Automated Test East
            _landingPage.LNTAutomatedTestEastOrganizationTitle.GetElementVisibility().Should().BeTrue("Organization " + LandingPageExpectedValue.LNTAutomatedTestEastOrganizationTitle + " name is not displayed");
            string ActualTitle = _landingPage.LNTAutomatedTestEastOrganizationTitle.Text;
            string ExpectedTitle = LandingPageExpectedValue.LNTAutomatedTestEastOrganizationTitle;
            ActualTitle.Should().BeEquivalentTo(ExpectedTitle, ExpectedTitle + " name is not matching with the expected value.");

            //L & T Automated Test
            _landingPage.LNTAutomatedTestOrganizationTitle.GetElementVisibility().Should().BeTrue("Organization " + LandingPageExpectedValue.LNTAutomatedTestOrganizationTitle + " name is not displayed");
            ActualTitle = _landingPage.LNTAutomatedTestOrganizationTitle.Text;
            ExpectedTitle = LandingPageExpectedValue.LNTAutomatedTestOrganizationTitle;
            ActualTitle.Should().BeEquivalentTo(ExpectedTitle, ExpectedTitle + " name is not matching with the expected value.");

            //LT Automated Eye Test
            _landingPage.LNTAutomatedEyeTestOrganizationTitle.GetElementVisibility().Should().BeTrue("Organization " + LandingPageExpectedValue.LNTAutomatedEyeTestOrganizationTitle + " name is not displayed");
            ActualTitle = _landingPage.LNTAutomatedEyeTestOrganizationTitle.Text;
            ExpectedTitle = LandingPageExpectedValue.LNTAutomatedEyeTestOrganizationTitle;
            ActualTitle.Should().BeEquivalentTo(ExpectedTitle, ExpectedTitle + " name is not matching with the expected value.");
        }

        [Then(@"Facility name is displayed")]
        public void ThenFacilityNameIsDisplayed()
        {
            // //L&T Automated Test East Organization facility -Test4
            _landingPage.LNTAutomatedTestEastOrganizationFacilityPanelTest4Title.GetElementVisibility().Should().BeTrue("Facility " + LandingPageExpectedValue.LNTAutomatedTestEastOrganizationFacilityTest4 + " name is not displayed.");
            string ActualFacilityPanlelTitle = _landingPage.LNTAutomatedTestEastOrganizationFacilityPanelTest4Title.Text;
            string ExpectedFacilityPanelTitle = LandingPageExpectedValue.LNTAutomatedTestEastOrganizationFacilityTest4;
            ActualFacilityPanlelTitle.Should().BeEquivalentTo(ExpectedFacilityPanelTitle, ExpectedFacilityPanelTitle+" title is not matching with the expected value.");

            //L&T Automated Test Organization facility test1
            _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.GetElementVisibility().Should().BeTrue("Facility " + LandingPageExpectedValue.LNTAutomatedTestOrganizationFacilityTest1 + " name is not displayed.");
            ActualFacilityPanlelTitle = _landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Text;
            ExpectedFacilityPanelTitle = LandingPageExpectedValue.LNTAutomatedTestOrganizationFacilityTest1;
            ActualFacilityPanlelTitle.Should().BeEquivalentTo(ExpectedFacilityPanelTitle, ExpectedFacilityPanelTitle+ " title is not matching with the expected value.");

            //L&T Automated Test Organization facility test2
            _landingPage.LNTAutomatedTestOrganizationFacilityTest2Title.GetElementVisibility().Should().BeTrue("Facility " + LandingPageExpectedValue.LNTAutomatedTestOrganizationFacilityTest2 + " name is not displayed.");
            ActualFacilityPanlelTitle = _landingPage.LNTAutomatedTestOrganizationFacilityTest2Title.Text;
            ExpectedFacilityPanelTitle = LandingPageExpectedValue.LNTAutomatedTestOrganizationFacilityTest2;
            ActualFacilityPanlelTitle.Should().BeEquivalentTo(ExpectedFacilityPanelTitle, ExpectedFacilityPanelTitle+" title is not matching with the expected value.");

            //L&T Automated Eye Test Organization
            _landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.GetElementVisibility().Should().BeTrue("Facility " + LandingPageExpectedValue.LNTAutomatedEyeTestOrganizationFacilityTest1 + " name is not displayed.");
            ActualFacilityPanlelTitle = _landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.Text;
            ExpectedFacilityPanelTitle = LandingPageExpectedValue.LNTAutomatedEyeTestOrganizationFacilityTest1;
            ActualFacilityPanlelTitle.Should().BeEquivalentTo(ExpectedFacilityPanelTitle, ExpectedFacilityPanelTitle+" title is not matching with the expected value.");
        }

        [Then(@"Servers are displayed")]
        public void ThenServersAreDisplayed()
        {
            //organization0-facility0
            _landingPage.Organization0Facility0Server.GetElementVisibility().Should().BeTrue("Organization 1 facility 1 servers are not displayed");

            //organization1-facility0
            _landingPage.Organization1Facility0Server.GetElementVisibility().Should().BeTrue("Organization 2 facility 1 servers are not displayed");

            //organization1-facility1
            _landingPage.Organization1Facility1Server.GetElementVisibility().Should().BeTrue("Organization 2 facility 2 servers are not displayed");

            //organization2-facility0
            _landingPage.Organization2Facility0Server.GetElementVisibility().Should().BeTrue("Organization 3 facility 1 servers are not displayed");
        }

        [Then(@"Devices are displayed")]
        public void ThenDevicesAreDisplayed()
        {
            //organization0-facility0
            _landingPage.Organization0Facility0Device.GetElementVisibility().Should().BeTrue("Organization 1 facility 1 devices are not displayed");

            //organization1-facility0
            _landingPage.Organization1Facility0Device.GetElementVisibility().Should().BeTrue("Organization 2 facility 1 devices are not displayed");

            //organization1-facility1
            _landingPage.Organization1Facility1Device.GetElementVisibility().Should().BeTrue("Organization 2 facility 2 devices are not displayed");

            //organization2-facility0
            _landingPage.Organization2Facility0Device.GetElementVisibility().Should().BeTrue("Organization 3 facility 1 devices are not displayed");
        }


        [Given(@"user login without roll-up page")]
        public void GivenUserLoginWithoutRoll_UpPage()
        {
            _loginPage.LogIn(_driver, LoginPage.LogInType.AdminWithOutRollUpPage);
        }

        [Then(@"Roll-up page is not displayed")]
        public void ThenRoll_UpPageIsNotDisplayed()
        {
            _landingPage.LNTAutomatedTestEastOrganizationFacilityPanelTest4Title.GetElementVisibility().Should().BeFalse("User is on landing page.");
        }

        [Then(@"Asset list page is displayed")]
        public void ThenCVSMassetListPageIsDisplayed()
        {
            _mainPage.AssetsTab.GetElementVisibility().Should().BeTrue("User is not on asset list page.");
        }
    }
}
