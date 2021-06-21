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
            Assert.IsTrue(PropertyClass.Driver.PageSource.Contains(ExpectedText));
            //Hooks1.CaptureNow();
            //adding attachment parts
            var attachmentFilePath = $"{TestContext.CurrentContext.TestDirectory}\\{TestContext.CurrentContext.Test.MethodName}.jpg";
            ((ITakesScreenshot)(PropertyClass.Driver)).GetScreenshot().SaveAsFile(attachmentFilePath);
            TestContext.AddTestAttachment(attachmentFilePath);
        }
    }
}
