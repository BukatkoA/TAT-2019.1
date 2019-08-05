using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ClassWork9
{
    /// <summary>
    /// Class implements interface method
    /// </summary>
    public class ChromeDriverCreater : ICreater
    {
        /// <summary>
        /// That method returns ChromeDriver
        /// </summary>
        /// <returns>ChromeDriver</returns>
        public IWebDriver Create()
        {
            return new ChromeDriver();
        }
    }
}