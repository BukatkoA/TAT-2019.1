using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassWork9
{
    /// <summary>
    /// The class of currency page
    /// </summary>
    public class CurrencyPage
    {
        IWebDriver Driver { get; set; }
        WebDriverWait WebDriverWait { get; }
        List<IWebElement> Names { get; }
        List<IWebElement> Values { get; }

        readonly string web = "https://myfin.by/currency/minsk";
        readonly string xPath = "//div[@class = 'bank-info-head content_i calc_color']";
        readonly string xPathName = "//div[@class = 'table-responsive']//tr/td/a";
        readonly string xPathValue = "//div[@class = 'table-responsive']//tr/td[2]";

        /// <summary>
        /// Constructor of CurrencyPage
        /// </summary>
        /// <param name="driver">WebDriver</param>
        public CurrencyPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.WebDriverWait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(20));
            this.GoToUrl();
            this.Names = this.Driver.FindElements(By.XPath(this.xPathName)).ToList();
            this.Values = this.Driver.FindElements(By.XPath(this.xPathValue)).ToList();
        }

        /// <summary>
        /// The method goes to website
        /// </summary>
        public void GoToUrl() => this.Driver.Navigate().GoToUrl(this.web);

        /// <summary>
        /// Method returns list of currencies
        /// </summary>
        /// <returns>list of currencies</returns>
        public List<Currency> GetCurrency()
        {
            this.WebDriverWait.Until(time => this.Driver.FindElements(By.XPath(this.xPath)).Any());
            var currencies = new List<Currency>();

            for (int i = 0; i < this.Names.Count; i++)
            {
                currencies.Add(new Currency(this.Names[i].Text, this.Values[i].Text));
            }

            this.Driver.Quit();

            return currencies;
        }
    }
}