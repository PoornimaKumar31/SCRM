using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Landing
{
    [Binding, Scope(Tag = "SoftwareRequirementID_5689")]
    public class Req5689Steps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();

        [Given(@"user login with rollup page")]
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
            //Organization0
            Assert.AreEqual(true, landingPage.Organization0Title.GetElementVisibility(), "Organization " + LandingPage.ExpectedValues.Organization0Title + " name is not displayed");
            String ActualTitle = landingPage.Organization0Title.Text;
            String ExpectedTitle = LandingPage.ExpectedValues.Organization0Title;
            Assert.AreEqual(ExpectedTitle, ActualTitle, "Organization1 name is not matching with the expected value.");

            //Organization1
            Assert.AreEqual(true, landingPage.Organization1Title.GetElementVisibility(), "Organization " + LandingPage.ExpectedValues.Organization1Title + " name is not displayed");
            ActualTitle = landingPage.Organization1Title.Text;
            ExpectedTitle = LandingPage.ExpectedValues.Organization1Title;
            Assert.AreEqual(ExpectedTitle, ActualTitle, "Organization2 name is not matching with the expected value.");
        }

        [Then(@"Facility name is displayed")]
        public void ThenFacilityNameIsDisplayed()
        {
            //Organization0-Tile-0
            Assert.AreEqual(true, landingPage.Organization0Facility0Title.GetElementVisibility(), "Facility " + LandingPage.ExpectedValues.Organization0FacilityPanel0Title + " name is not displayed.");
            string ActualFacilityPanlelTitle = landingPage.Organization0Facility0Title.Text;
            string ExpectedFacilityPanelTitle = LandingPage.ExpectedValues.Organization0FacilityPanel0Title;
            Assert.AreEqual(ExpectedFacilityPanelTitle, ActualFacilityPanlelTitle, "Organization1 facility1 title is not matching with the expected value.");
            
            //Organization1-Tile-0
            Assert.AreEqual(true, landingPage.Organization1Facility0Title.GetElementVisibility(), "Facility " + LandingPage.ExpectedValues.Organization1FacilityPanel0Title + " name is not displayed.");
            ActualFacilityPanlelTitle = landingPage.Organization1Facility0Title.Text;
            ExpectedFacilityPanelTitle = LandingPage.ExpectedValues.Organization1FacilityPanel0Title;
            Assert.AreEqual(ExpectedFacilityPanelTitle, ActualFacilityPanlelTitle, "Organization2 facility1 title is not matching with the expected value.");
            
            //Organization1-Tile-1
            Assert.AreEqual(true, landingPage.Organization1Facility1Title.GetElementVisibility(), "Facility " + LandingPage.ExpectedValues.Organization1FacilityPanel1Title + " name is not displayed.");
            ActualFacilityPanlelTitle = landingPage.Organization1Facility1Title.Text;
            ExpectedFacilityPanelTitle = LandingPage.ExpectedValues.Organization1FacilityPanel1Title;
            Assert.AreEqual(ExpectedFacilityPanelTitle, ActualFacilityPanlelTitle, "Organization2 facility2 title is not matching with the expected value.");

            //Organization2-Tile-0
            Assert.AreEqual(true, landingPage.Organization2Facility0Title.GetElementVisibility(), "Facility " + LandingPage.ExpectedValues.Organization2FacilityPanel0Title + " name is not displayed.");
            ActualFacilityPanlelTitle = landingPage.Organization2Facility0Title.Text;
            ExpectedFacilityPanelTitle = LandingPage.ExpectedValues.Organization2FacilityPanel0Title;
            Assert.AreEqual(ExpectedFacilityPanelTitle, ActualFacilityPanlelTitle, "Organization3 facility1 title is not matching with the expected value.");
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

    }
}
