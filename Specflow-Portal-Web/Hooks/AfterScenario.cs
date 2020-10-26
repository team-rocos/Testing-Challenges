using System;
using System.IO;
using OpenQA.Selenium;
using ROCO.Specflow.PortalWeb.Infrastructure;
using TechTalk.SpecFlow;

namespace ROCO.Specflow.PortalWeb.Hooks
{
    [Binding]
    class AfterScenario
    {
        private readonly BrowserDriver _browserDriver;

        public AfterScenario(BrowserDriver browserDriver)
        {
            _browserDriver = browserDriver;
        }

        [AfterScenario(Order = 0)]
        public void AfterScenarioMakeScreenshot(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            var screenshotsFolder = "Screenshots";
            Directory.CreateDirectory(screenshotsFolder);

            if (_browserDriver.Current is ITakesScreenshot takesScreenshot)
            {
                var screenshot = takesScreenshot.GetScreenshot();
                var tempFileName = Path.Combine(Directory.GetCurrentDirectory(),
                    $"{screenshotsFolder}\\{DateTime.Now.ToString("yyMMddHHmmss.f")}_{featureContext.FeatureInfo.Title}-{scenarioContext.ScenarioInfo.Title}.png");
                screenshot.SaveAsFile(tempFileName, ScreenshotImageFormat.Png);

                Console.WriteLine($"SCREENSHOT[ {tempFileName} ]");
            }
        }
    }
}