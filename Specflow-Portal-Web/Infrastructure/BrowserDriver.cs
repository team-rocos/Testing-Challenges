using OpenQA.Selenium;
using ROCO.Specflow.PortalWeb.Contexts;
using ROCO.Specflow.PortalWeb.Helpers;
using System;

namespace ROCO.Specflow.PortalWeb.Infrastructure
{
    public class BrowserDriver : IDisposable
    {
        private readonly BrowserSeleniumDriverFactory _browserSeleniumDriverFactory;
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private readonly TestRunContext _testRunContext;
        private bool _isDisposed;

        public BrowserDriver(BrowserSeleniumDriverFactory browserSeleniumDriverFactory, TestRunContext testRunContext)
        {
            _browserSeleniumDriverFactory = browserSeleniumDriverFactory;
            _testRunContext = testRunContext;
            _currentWebDriverLazy = new Lazy<IWebDriver>(GetWebDriver);
        }

        public IWebDriver Current => _currentWebDriverLazy.Value;

        private IWebDriver GetWebDriver()
        {
            return _browserSeleniumDriverFactory.GetBrowserDriver(_testRunContext.Browser);
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            if (_currentWebDriverLazy.IsValueCreated)
            {
                Current.Quit();
            }

            _isDisposed = true;
        }

        public void Navigate(string urlPart)
        {
            if (!Current.Url.EndsWith(urlPart))
            {
                Current.Navigate().GoToUrl($"{_testRunContext.Hostname}/{urlPart}");
                RetryHelper.WaitFor(() => Current.Url.EndsWith(urlPart),_testRunContext.Retry);
            }
        }
    }
}