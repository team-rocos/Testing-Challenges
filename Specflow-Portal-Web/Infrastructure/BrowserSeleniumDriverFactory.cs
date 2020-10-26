using ROCO.Specflow.PortalWeb.Contexts;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ROCO.Specflow.PortalWeb.Infrastructure
{
    public class BrowserSeleniumDriverFactory
    {
        public IWebDriver GetBrowserDriver(string browserId)
        {
            string lowerBrowserId = browserId.ToUpper();
            switch (lowerBrowserId)
            {
                case "CHROME": return GetChromeDriver(false);
                case "CHROME-HEADLESS": return GetChromeDriver(true);
                case string browser: throw new NotSupportedException($"{browser} is not a supported browser");
                default: throw new NotSupportedException("not supported browser: <null>");
            }
        }
        
        private IWebDriver GetChromeDriver(bool isHeadless)
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService(TestContext.TestDirectory);

            // TODO add required browser options to make it consistent
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");
            chromeOptions.AddArgument("--disable-notifications");

            if (isHeadless)
            {
                chromeOptions.AddArgument("headless");
            }

            var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions)
            {
                //Url = _testRunContext.Hostname
            };

            return chromeDriver;
        }
    }
}
