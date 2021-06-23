using HillromAutomationFramework.Coding.SupportingCode;
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
            Assert.IsFalse(PropertyClass.Driver.PageSource.Contains(ExpectedText));
        }
    }
}