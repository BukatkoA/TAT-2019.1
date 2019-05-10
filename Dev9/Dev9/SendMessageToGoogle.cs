using OpenQA.Selenium;

namespace Dev9
{
    /// <summary>
    /// Class for sending letter
    /// </summary>
    public class SendMessageToGoogle
    {
        IWebDriver Driver { get; set; }
        IWebElement SendTo { get; set; }
        IWebElement MessageBox { get; set; }
        IWebElement SendButton { get; set; }
        IWebElement Checker { get; set; }
        IWebElement SubmitButton { get; set; }
        MailRuLocators.SendMessageToGoogle Locator { get; }

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="driver">WebDriver</param>
        public SendMessageToGoogle(IWebDriver driver)
        {
            this.Driver = driver;
            this.Locator = new MailRuLocators.SendMessageToGoogle();
        }

        /// <summary>
        /// Sends letter
        /// </summary>
        /// <param name="messageRecipient">Who receives the letter</param>
        /// <param name="message">What contains the letter</param>
        public void SenderMessage(string messageRecipient, string message)
        {
            this.SendTo = this.Driver.FindElement(By.XPath(this.Locator.SendToLocator), 10);
            this.SendTo.Click();
            this.SendTo.SendKeys(messageRecipient);
            this.Checker = this.Driver.FindElement(By.XPath(this.Locator.MessageBoxEnterLocator), 10);
            this.Checker.Click();
            this.Driver.SwitchTo().Frame(this.Driver.FindElement(By.XPath("//iframe[contains(@id, 'composeEditor_ifr')]"), 10));
            this.MessageBox = this.Driver.FindElement(By.XPath(this.Locator.MessageBoxLocator), 10);
            this.MessageBox.Click();
            this.MessageBox.Clear();
            this.MessageBox.SendKeys(message);
            this.Driver.SwitchTo().DefaultContent();
            this.SendButton = this.Driver.FindElement(By.XPath(this.Locator.SendButtonLocator), 10);
            this.SendButton.Click();
        }
    }
}