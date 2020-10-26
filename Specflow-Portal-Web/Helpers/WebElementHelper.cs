﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ROCO.Specflow.PortalWeb.Helpers
{
    public static class WebElementHelper
    {
        //this will search for the element until a timeout is reached
        public static IWebElement WaitUntilElementExists(this IWebDriver driver, By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementExists(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator +
                                  "' was not found in current context page.");
                throw;
            }
        }

        //this will wait for the element to be visible until a timeout is reached
        public static IWebElement WaitUntilElementVisible(this IWebDriver driver, By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator +
                                  "' was not found in current context page.");
                throw;
            }
        }


        // This will click an element and wait until a page is loaded
        public static void ClickAndWaitForPageToLoad(this IWebDriver driver, By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                var element = driver.FindElement(elementLocator);
                element.Click();
                wait.Until(ExpectedConditions.StalenessOf(element));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }

        //this will search for the element until a timeout is reached
        public static IWebElement WaitUntilElementClickable(this IWebDriver driver, By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator +
                                  "' was not found in current context page.");
                throw;
            }
        }

        public static string GetElementStringAndSkipIfNotExist(this IWebDriver driver, By elementLocator)
        {
            try
            {
                return driver.FindElement(elementLocator).Text;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator +
                                  "' was not found in current context page.");
            }

            return "";
        }

    }
}
