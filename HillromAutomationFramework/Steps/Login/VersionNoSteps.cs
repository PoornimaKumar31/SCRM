using HillromAutomationFramework.Coding.PageObjects;
using HillromAutomationFramework.Coding.SupportingCode;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class VersionNoSteps
    {
        LoginPage loginPage = new LoginPage();
        [Then(@"""(.*)"" is displayed")]
        public void ThenIsDisplayed(string ExpectedText)
        {
            Assert.IsTrue(PropertyClass.Driver.PageSource.Contains(ExpectedText));
        }
    }
}