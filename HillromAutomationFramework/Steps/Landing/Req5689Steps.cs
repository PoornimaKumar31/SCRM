using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Landing
{
    [Binding, Scope(Tag = "SoftwareRequirementID_5689")]
    public class Req5689Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();
        MainPage mainPage = new MainPage();

        [Given(@"user login with roll-up page")]
        public void GivenUserLoginWithRollupPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
        }

        [Then(@"Roll-up page is displayed")]
        public void ThenRoll_UpPageIsDisplayed()
        {
            string ActualURL = PropertyClass.Driver.Url;
            string ExpectedURL = LandingPage.ExpectedValues.RollupPageURL;
            Assert.AreEqual(ExpectedURL, ActualURL, "Roll up page is not displayed");
        }

        [Given(@"user is on Landing page")]
        public void GivenUserIsOnLandingPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithRollUpPage);
        }

        [Given(@"Roll-up page is displayed")]
        public void GivenRoll_UpPageIsDisplayed()
        {
            Assert.AreEqual(LandingPage.ExpectedValues.RollupPageURL, PropertyClass.Driver.Url, "User is not on landing page");
        }

        [Then(@"Organization name is displayed")]
        public void ThenOrganizationNameIsDisplayed()
        {
            //L&T Automated Test East
            Assert.AreEqual(true, landingPage.LNTAutomatedTestEastOrganizationTitle.GetElementVisibility(), "Organization " + LandingPage.ExpectedValues.LNTAutomatedTestEastOrganizationTitle + " name is not displayed");
            String ActualTitle = landingPage.LNTAutomatedTestEastOrganizationTitle.Text;
            String ExpectedTitle = LandingPage.ExpectedValues.LNTAutomatedTestEastOrganizationTitle;
            Assert.AreEqual(ExpectedTitle, ActualTitle, ExpectedTitle+" name is not matching with the expected value.");

            //L & T Automated Test
            Assert.AreEqual(true, landingPage.LNTAutomatedTestOrganizationTitle.GetElementVisibility(), "Organization " + LandingPage.ExpectedValues.LNTAutomatedTestOrganizationTitle + " name is not displayed");
            ActualTitle = landingPage.LNTAutomatedTestOrganizationTitle.Text;
            ExpectedTitle = LandingPage.ExpectedValues.LNTAutomatedTestOrganizationTitle;
            Assert.AreEqual(ExpectedTitle, ActualTitle, ExpectedTitle + " name is not matching with the expected value.");

            //LT Automated Eye Test
            Assert.AreEqual(true, landingPage.LNTAutomatedEyeTestOrganizationTitle.GetElementVisibility(), "Organization " + LandingPage.ExpectedValues.LNTAutomatedEyeTestOrganizationTitle + " name is not displayed");
            ActualTitle = landingPage.LNTAutomatedEyeTestOrganizationTitle.Text;
            ExpectedTitle = LandingPage.ExpectedValues.LNTAutomatedEyeTestOrganizationTitle;
            Assert.AreEqual(ExpectedTitle, ActualTitle, ExpectedTitle + " name is not matching with the expected value.");
        }

        [Then(@"Facility name is displayed")]
        public void ThenFacilityNameIsDisplayed()
        {
            // //L&T Automated Test East Organization facility -Test4
            Assert.AreEqual(true, landingPage.LNTAutomatedTestEastOrganizationFacilityPanelTest4Title.GetElementVisibility(), "Facility " + LandingPage.ExpectedValues.LNTAutomatedTestEastOrganizationFacilityTest4 + " name is not displayed.");
            string ActualFacilityPanlelTitle = landingPage.LNTAutomatedTestEastOrganizationFacilityPanelTest4Title.Text;
            string ExpectedFacilityPanelTitle = LandingPage.ExpectedValues.LNTAutomatedTestEastOrganizationFacilityTest4;
            Assert.AreEqual(ExpectedFacilityPanelTitle, ActualFacilityPanlelTitle, ExpectedFacilityPanelTitle+" title is not matching with the expected value.");

            //L&T Automated Test Organization facility test1
            Assert.AreEqual(true, landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.GetElementVisibility(), "Facility " + LandingPage.ExpectedValues.LNTAutomatedTestOrganizationFacilityTest1 + " name is not displayed.");
            ActualFacilityPanlelTitle = landingPage.LNTAutomatedTestOrganizationFacilityTest1Title.Text;
            ExpectedFacilityPanelTitle = LandingPage.ExpectedValues.LNTAutomatedTestOrganizationFacilityTest1;
            Assert.AreEqual(ExpectedFacilityPanelTitle, ActualFacilityPanlelTitle, ExpectedFacilityPanelTitle+ " title is not matching with the expected value.");

            //L&T Automated Test Organization facility test2
            Assert.AreEqual(true, landingPage.LNTAutomatedTestOrganizationFacilityTest2Title.GetElementVisibility(), "Facility " + LandingPage.ExpectedValues.LNTAutomatedTestOrganizationFacilityTest2 + " name is not displayed.");
            ActualFacilityPanlelTitle = landingPage.LNTAutomatedTestOrganizationFacilityTest2Title.Text;
            ExpectedFacilityPanelTitle = LandingPage.ExpectedValues.LNTAutomatedTestOrganizationFacilityTest2;
            Assert.AreEqual(ExpectedFacilityPanelTitle, ActualFacilityPanlelTitle, ExpectedFacilityPanelTitle+" title is not matching with the expected value.");

            //L&T Automated Eye Test Organization
            Assert.AreEqual(true, landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.GetElementVisibility(), "Facility " + LandingPage.ExpectedValues.LNTAutomatedEyeTestOrganizationFacilityTest1 + " name is not displayed.");
            ActualFacilityPanlelTitle = landingPage.LNTAutomatedEyeTestOrganizationFacilityTest1Title.Text;
            ExpectedFacilityPanelTitle = LandingPage.ExpectedValues.LNTAutomatedEyeTestOrganizationFacilityTest1;
            Assert.AreEqual(ExpectedFacilityPanelTitle, ActualFacilityPanlelTitle, ExpectedFacilityPanelTitle+" title is not matching with the expected value.");
        }

        [Then(@"Servers are displayed")]
        public void ThenServersAreDisplayed()
        {
            //organization0-facility0
            Assert.AreEqual(true, landingPage.Organization0Facility0Server.GetElementVisibility(), "Organization 1 facility 1 servers are not displayed");

            //organization1-facility0
            Assert.AreEqual(true, landingPage.Organization1Facility0Server.GetElementVisibility(), "Organization 2 facility 1 servers are not displayed");

            //organization1-facility1
            Assert.AreEqual(true, landingPage.Organization1Facility1Server.GetElementVisibility(), "Organization 2 facility 2 servers are not displayed");

            //organization2-facility0
            Assert.AreEqual(true, landingPage.Organization2Facility0Server.GetElementVisibility(), "Organization 3 facility 1 servers are not displayed");
        }

        [Then(@"Devices are displayed")]
        public void ThenDevicesAreDisplayed()
        {
            //organization0-facility0
            Assert.AreEqual(true, landingPage.Organization0Facility0Device.GetElementVisibility(), "Organization 1 facility 1 devices are not displayed");

            //organization1-facility0
            Assert.AreEqual(true, landingPage.Organization1Facility0Device.GetElementVisibility(), "Organization 2 facility 1 devices are not displayed");

            //organization1-facility1
            Assert.AreEqual(true, landingPage.Organization1Facility1Device.GetElementVisibility(), "Organization 2 facility 2 devices are not displayed");

            //organization2-facility0
            Assert.AreEqual(true, landingPage.Organization2Facility0Device.GetElementVisibility(), "Organization 3 facility 1 devices are not displayed");
        }


        [Given(@"user login without roll-up page")]
        public void GivenUserLoginWithoutRoll_UpPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithOutRollUpPage);
        }

        [Then(@"Roll-up page is not displayed")]
        public void ThenRoll_UpPageIsNotDisplayed()
        {
            Assert.AreEqual(false, landingPage.LNTAutomatedTestEastOrganizationFacilityPanelTest4Title.GetElementVisibility(),"User is on landing page.");
        }

        [Then(@"Asset list page is displayed")]
        public void ThenCVSMassetListPageIsDisplayed()
        {
            Assert.AreEqual(true, mainPage.AssetsTab.GetElementVisibility(),"User is not on asset list page.");
        }



    }
}
