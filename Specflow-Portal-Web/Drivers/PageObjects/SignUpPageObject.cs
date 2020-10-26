using OpenQA.Selenium;
using ROCO.Specflow.PortalWeb.Helpers;

namespace ROCO.Specflow.PortalWeb.Drivers.PageObjects
{
    public class SignUpPageObject
    {
        private readonly IWebDriver _webDriver;

        public readonly string urlPath = "signup";

        public SignUpPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public IWebElement Banner => _webDriver.WaitUntilElementVisible(By.XPath("//div[@class='main wider']/div/span"));

        public IWebElement FirstName => _webDriver.FindElement(By.Id("mat-input-0"));
        public IWebElement FirstNameErrorMessage => _webDriver.FindElement(By.Id("mat-error-0"));

        public IWebElement LastName => _webDriver.FindElement(By.Id("mat-input-1"));
        public IWebElement LastNameErrorMessage => _webDriver.FindElement(By.Id("mat-error-1"));
        
        public IWebElement Email => _webDriver.FindElement(By.Id("mat-input-2"));
        public string EmailErrorMessage => _webDriver.GetElementStringAndSkipIfNotExist(By.Id("mat-error-6")) 
                                           + _webDriver.GetElementStringAndSkipIfNotExist(By.Id("mat-error-2"));
   
        public IWebElement AccountName => _webDriver.FindElement(By.Id("mat-input-5"));
        public string AccountNameErrorMessage => _webDriver.GetElementStringAndSkipIfNotExist(By.Id("mat-error-5")) 
                                                 + _webDriver.GetElementStringAndSkipIfNotExist(By.Id("mat-error-7"));

        public IWebElement Password => _webDriver.FindElement(By.Id("mat-input-3"));
        public string PasswordErrorMessage => _webDriver.GetElementStringAndSkipIfNotExist(By.Id("mat-error-3"))
                                                 + _webDriver.GetElementStringAndSkipIfNotExist(By.Id("mat-error-8"));

        public IWebElement ConfirmPassword => _webDriver.FindElement(By.Id("mat-input-4"));
        public IWebElement ConfirmPasswordErrorMessage => _webDriver.FindElement(By.Id("mat-error-4"));

        public IWebElement InvitationCode => _webDriver.FindElement(By.Id("mat-input-6"));
        //public IWebElement InvitationCodeErrorMessage => _webDriver.FindElement(By.Id("mat-error-9"));

        public IWebElement SignUpButton => _webDriver.FindElement(By.XPath("//app-loading-button/button"));
    }
}
