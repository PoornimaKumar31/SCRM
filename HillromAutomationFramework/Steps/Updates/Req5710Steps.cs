﻿using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Updates
{
    [Binding]
    public class Req5710Steps
    {

        LoginPage loginPage = new LoginPage();
        MainPage mainPage = new MainPage();
        ServiceMoniterPage serviceMoniterPage = new ServiceMoniterPage();

        [Given(@"user is on Service Monitor Settings page")]
        public void GivenUserIsOnServiceMonitorSettingsPage()
        {
            loginPage.SignIn("AdminWithoutRollup");
            Assert.AreEqual(true, mainPage.AssetsTab.GetElementVisibility(), "User is not on main page");
            mainPage.UpdatesTab.JavaSciptClick();
            serviceMoniterPage.AssetTypeDropDown.SelectDDL(ServiceMoniterPage.Inputs.ServiceMoniterText);
            Assert.AreEqual(true, serviceMoniterPage.ServiceMoniterLabel.GetElementVisibility(), "Service Monitor Settings page is not displayed");
        }
        
        [When(@"user selects a Service Monitor in the list")]
        public void WhenUserSelectsAServiceMonitorInTheList()
        {
            serviceMoniterPage.FirstDeviceCheckBox.Click();
        }
        
        [When(@"the user clicks Deploy button")]
        public void WhenTheUserClicksDeployButton()
        {
            serviceMoniterPage.DeployButton.Click();
        }
        
        [Then(@"Deploy button is enabled")]
        public void ThenDeployButtonIsEnabled()
        {
            Assert.AreEqual(true, serviceMoniterPage.DeployButton.Enabled, "Deploy button is not enabled.");
        }
        
        [Then(@"Update process has been established message displays")]
        public void ThenUpdateProcessHasBeenEstablishedMessageDisplays()
        {
            Assert.AreEqual(true, serviceMoniterPage.UpdateMessage.GetElementVisibility(), "Update message is not displayed.");
        }
    }
}
