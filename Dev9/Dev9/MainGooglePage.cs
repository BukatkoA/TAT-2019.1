using OpenQA.Selenium;

namespace Dev9
{
    /// <summary>
    /// Class to start writing a letter
    /// </summary>
    public class MainGooglePage
    {
        IWebDriver Driver { get; set; }
        IWebElement WriteMessage { get; set; }
        GoogleLocators.MainGooglePage Locator { get; }

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="driver">WebDriver</param>
        public MainGooglePage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Locator = new GoogleLocators.MainGooglePage();
        }

        /// <summary>
        /// Method find write button
        /// </summary>
        public SendMessageToMailRu Finder()
        {
            this.WriteMessage = this.Driver.FindElement(By.XPath(this.Locator.WriteMessageLocator), 10000);
            this.WriteMessage.Click();

            return new SendMessageToMailRu(this.Driver);
        }
    }
}