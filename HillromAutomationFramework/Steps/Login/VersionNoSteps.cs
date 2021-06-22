using HillromAutomationFramework.Coding.SupportingCode;
using HillromAutomationFramework.Hooks;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class VersionNoSteps
    {
        [Then(@"verify ""(.*)"" is displayed")]
        public void ThenVerifyIsDisplayed(string ExpectedText)
        {
            Assert.IsFalse(PropertyClass.Driver.PageSource.Contains(ExpectedText));
            Hooks1.CaptureNow();
        }
    }
}
