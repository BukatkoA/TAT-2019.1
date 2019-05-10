using OpenQA.Selenium;

namespace Dev9
{
    /// <summary>
    /// Class to start writing a letter
    /// </summary>
    public class MainMailRuPage
    {
        IWebDriver Driver { get; set; }
        IWebElement WriteMessage { get; set; }
        MailRuLocators.MainMailRuPage Locator { get; }

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="driver">WebDriver</param>
        public MainMailRuPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Locator = new MailRuLocators.MainMailRuPage();
        }

        /// <summary>
        /// Clicks to start writing a letter button
        /// </summary>
        /// <returns>Mail letter sender page</returns>
        public SendMessageToGoogle Finder()
        {
            this.WriteMessage = this.Driver.FindElement(By.XPath(this.Locator.WriteMessageLocator), 100);
            this.WriteMessage.Click();

            return new SendMessageToGoogle(this.Driver);
        }
    }
}