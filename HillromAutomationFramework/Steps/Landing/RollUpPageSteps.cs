using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Landing
{
    [Binding]
    public class RollUpPageSteps
    {
        LoginPage loginPage = new LoginPage();
        LandingPage landingPage = new LandingPage();

        [Given(@"user is logging in with rollup page configuration")]
        public void GivenUserIsLoggedWithRollupPageConfiguration()
        {
            loginPage.SignIn("Adminwithrollup");
            string ActualURL = PropertyClass.Driver.Url;
            string ExpectedURL = LandingPage.ExpectedValues.RollupPageURL;
            Assert.AreEqual(ExpectedURL, ActualURL);
        }
        
        [Then(@"user will see Organization titles")]
        public void ThenUserWillSeeOrganizationTitles()
        {
            //Organization0
            String ActualTitle = landingPage.Organization0Title.Text;
            String ExpectedTitle = LandingPage.ExpectedValues.Organization0Title;
            Assert.AreEqual(ExpectedTitle, ActualTitle);

            //Organization1
            ActualTitle = landingPage.Organization1Title.Text;
            ExpectedTitle = LandingPage.ExpectedValues.Organization1Title;
            Assert.AreEqual(ExpectedTitle, ActualTitle);
        }
        
        [Then(@"facility panel with the titles")]
        public void ThenFacilityPanelWithTheTitles()
        {
            //Organization0-Tile0
            string ActualFacilityPanlelTitle = landingPage.Organization0Facility0Title.Text;
            string ExpectedFacilityPanelTitle = LandingPage.ExpectedValues.Organization0FacilityPanel0Title;
            Assert.AreEqual(ExpectedFacilityPanelTitle, ActualFacilityPanlelTitle);
            //Organization0-Tile1
            ActualFacilityPanlelTitle = landingPage.Organization0Facility1Title.Text;
            ExpectedFacilityPanelTitle = LandingPage.ExpectedValues.Organization0FacilityPanel1Title;
            Assert.AreEqual(ExpectedFacilityPanelTitle, ActualFacilityPanlelTitle);

            //Organization1
            ActualFacilityPanlelTitle = landingPage.Organization1Facility0Title.Text;
            ExpectedFacilityPanelTitle = LandingPage.ExpectedValues.Organization1FacilityPanel0Title;
            Assert.AreEqual(ExpectedFacilityPanelTitle, ActualFacilityPanlelTitle);
        }

        [Then(@"location information on each facility panel")]
        public void ThenLocationInformationOnEachFacilityPanel()
        {
            //organization0-facility0
            String ActualData = landingPage.Organization0FacilityPaneel0.Text;
            string[] TileData = ActualData.Split("\r\n");
            string[] servers = TileData[1].Split(" ");
            Assert.AreEqual(LandingPage.ExpectedValues.Organization0FacilityPanel0ServerCount, servers[0]);
            string[] devices = TileData[2].Split(" ");
            Assert.AreEqual(LandingPage.ExpectedValues.Organization0FacilityPanel0DeviceCount, devices[0]);

            //Organzation0-facility1
            ActualData = landingPage.Organization0FacilityPaneel1.Text;
            TileData = ActualData.Split("\r\n");
            servers = TileData[1].Split(" ");
            Assert.AreEqual(LandingPage.ExpectedValues.Organization0FacilityPanel1ServerCount, servers[0]);
            devices = TileData[2].Split(" ");
            Assert.AreEqual(LandingPage.ExpectedValues.Organization0FacilityPanel1DeviceCount, devices[0]);

            //Organization1-facility0
            ActualData = landingPage.Organization1FacilityPaneel0.Text;
            TileData = ActualData.Split("\r\n");
            servers = TileData[1].Split(" ");
            Assert.AreEqual(LandingPage.ExpectedValues.Organization1FacilityPanel0ServerCount, servers[0]);
            devices = TileData[2].Split(" ");
            Assert.AreEqual(LandingPage.ExpectedValues.Organization1FacilityPanel0DeviceCount, devices[0]);
        }


        [Given(@"user is logged without rollup page configuration")]
        public void GivenUserIsLoggedWithoutRollupPageConfiguration()
        {
            loginPage.SignIn("adminwithoutrollup");  
        }


        [Then(@"user will see the Mainpage")]
        public void ThenUserWillSeeTheMainpage()
        {
            string CurrentPageURL = PropertyClass.Driver.Url;
            //checking with mainpage url
            Assert.AreEqual(MainPage.ExpectedValues.MainpageURL, CurrentPageURL);
        }

        [Then(@"without roll up")]
        public void ThenWithoutRollUp()
        {
            string CurrentPageURL = PropertyClass.Driver.Url;
            string RollupPageURL = LandingPage.ExpectedValues.RollupPageURL;
            Assert.AreNotEqual(RollupPageURL, CurrentPageURL);
        }




    }
}
