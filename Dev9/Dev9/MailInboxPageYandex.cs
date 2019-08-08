using OpenQA.Selenium;

namespace Dev9
{
    /// <summary>
    /// Inbox page.
    /// </summary>
    public class MailInboxPageYandex
    {
        /// <summary>
        /// The WebDriver.
        /// </summary>
        private IWebDriver driver;

        /// <summary>
        /// Locator of the latest mail element.
        /// </summary>
        public IWebElement WriteNewLetterButton => this.driver.FindElement(By.XPath("//a[@class='mail-ComposeButton js-main-action-compose']"));

        /// <summary>
        /// Locator of the latest mail element.
        /// </summary>
        public string LatestMailLocatorString => "//div[@class='ns-view-container-desc mail-MessagesList js-messages-list']/div[1]";

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="driver">
        /// The WebDriver.
        /// </param>
        public MailInboxPageYandex(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Checks if the mail has the correct sender.
        /// </summary>
        /// <param name="mailLocator">
        /// The locator of the mail.
        /// </param>
        /// <returns>
        /// 'True' if the sender is correct.
        /// </returns>
        public IWebElement SenderOfMail(string mailLocator) => this.driver.FindElement(By.XPath(mailLocator + "//span[@class='mail-MessageSnippet-FromText']"));

        /// <summary>
        /// Checks if the mail is unread.
        /// </summary>
        /// <param name="mailLocator">
        /// The locator of the mail.
        /// </param>
        /// <returns>
        /// 'True' if unread.
        /// </returns>
        public IWebElement UnreadMarkerOfMail(string mailLocator) => this.driver.FindElement(By.XPath(mailLocator + "//span[contains(@class, 'state_toRead')]"));

        /// <summary>
        /// Goes to the reading page for the mail.
        /// </summary>
        /// <param name="mailLocator">
        /// The mail locator.
        /// </param>
        /// <returns>
        /// The MailReadPage.
        /// </returns>
        public MailReadPage ReadMail(string mailLocator)
        {
            this.driver.FindElement(By.XPath(mailLocator)).Click();

            return new MailReadPage(this.driver);
        }
    }
}