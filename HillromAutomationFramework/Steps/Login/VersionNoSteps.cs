using HillromAutomationFramework.Coding.SupportingCode;
using HillromAutomationFramework.Hooks;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace HillromAutomationFramework.Steps.Login
{
    [Binding]
    public class VersionNoSteps
    {
        [Then(@"verify ""(.*)"" is displayed")]
        public void ThenVerifyIsDisplayed(string ExpectedText)
        {
            Assert.IsTrue(PropertyClass.Driver.PageSource.Contains(ExpectedText));
            Hooks1.CaptureNow();
        }
    }
}
