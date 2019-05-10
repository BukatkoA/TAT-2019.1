using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Dev9
{
    /// <summary>
    /// Class for IWebElement extensions
    /// </summary>
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Searches for an element for a specified time
        /// </summary>
        /// <param name="driver">IWebDriver</param>
        /// <param name="by">Mechanism by which an element can be found</param>
        /// <param name="timeoutInSeconds">Time in seconds for searching</param>
        /// <returns></returns>
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
    }
}