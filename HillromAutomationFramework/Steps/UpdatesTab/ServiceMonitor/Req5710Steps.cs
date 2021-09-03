﻿using HillromAutomationFramework.PageObjects;
using HillromAutomationFramework.SupportingCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.UpdatesTab.ServiceMonitor
{
    [Binding,Scope(Tag = "SoftwareRequirementID_5710")]
    public class Req5710Steps
    {

        LoginPage loginPage = new LoginPage();
        MainPage mainPage = new MainPage();
        ServiceMonitorPage serviceMoniterPage = new ServiceMonitorPage();
        WebDriverWait wait = new WebDriverWait(PropertyClass.Driver, TimeSpan.FromSeconds(10));

        [Given(@"user is on Service Monitor Settings page")]
        public void GivenUserIsOnServiceMonitorSettingsPage()
        {
            loginPage.LogIn(LoginPage.LogInType.AdminWithOutRollUpPage);
            Assert.AreEqual(true, mainPage.AssetsTab.GetElementVisibility(), "User is not on main page");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(MainPage.Locators.DeviceListTableID)));
            mainPage.UpdatesTab.JavaSciptClick();
            serviceMoniterPage.AssetTypeDropDown.SelectDDL(ServiceMonitorPage.Inputs.ServiceMoniterText);
            Assert.AreEqual(true, serviceMoniterPage.ServiceMoniterLabel.GetElementVisibility(), "Service Monitor Settings page is not displayed");
        }
        
        [Given(@"user selects a Service Monitor in the list")]
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
            Assert.AreEqual(ServiceMonitorPage.ExpectedValues.UpdateMessageText, serviceMoniterPage.UpdateMessage.Text, "Update message is matching with the expected value.");
        }
    }
}