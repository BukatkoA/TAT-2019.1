using OpenQA.Selenium;

namespace ClassWork9
{
    /// <summary>
    /// Interface for factory pattern
    /// </summary>
    public interface ICreater
    {
        /// <summary>
        /// The method creates webdriver
        /// </summary>
        /// <returns>Webdriver</returns>
        IWebDriver Create();
    }
}
