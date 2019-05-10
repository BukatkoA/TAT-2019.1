using OpenQA.Selenium;

namespace Dev9
{
    /// <summary>
    /// Class for sending letter
    /// </summary>
    public class SendMessageToMailRu
    {
        IWebDriver Driver { get; set; }
        IWebElement SendTo { get; set; }
        IWebElement MessageBox { get; set; }
        IWebElement SendButton { get; set; }
        GoogleLocators.SendMessageToMailRu Locator { get; }

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="driver">WebDriver</param>
        public SendMessageToMailRu(IWebDriver driver)
        {
            this.Driver = driver;
            this.Locator = new GoogleLocators.SendMessageToMailRu();
        }

        /// <summary>
        /// Sends letter
        /// </summary>
        /// <param name="messageRecipient">Who receives the letter</param>
        /// <param name="message">What contains the letter</param>
        public void SenderMessage(string messageRecipient, string message)
        {
            this.SendTo = this.Driver.FindElement(By.XPath(this.Locator.SendToLocator), 10000);
            this.SendTo.Click();
            this.SendTo.SendKeys(messageRecipient);
            this.MessageBox = this.Driver.FindElement(By.XPath(this.Locator.MessageBoxLocator), 10000);
            this.MessageBox.Click();
            this.MessageBox.SendKeys(message);
            this.SendButton = this.Driver.FindElement(By.XPath(this.Locator.SendButtonLocator));
            this.SendButton.Click();
        }
    }
}