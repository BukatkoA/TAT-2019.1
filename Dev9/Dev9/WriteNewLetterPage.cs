using OpenQA.Selenium;

namespace Dev9
{
    /// <summary>
    /// Page for writing new letters.
    /// </summary>
    public class WriteNewLetterPage
    {
        /// <summary>
        /// The WebDriver.
        /// </summary>
        private IWebDriver driver;

        /// <summary>
        /// The recipient text box.
        /// </summary>
        public IWebElement Recipient => this.driver.FindElement(By.XPath("//textarea[@data-original-name='To']"));

        /// <summary>
        /// The frame with text editor.
        /// </summary>
        public IWebElement EditorFrame => this.driver.FindElement(By.XPath("//iframe[contains(@id, 'composeEditor_ifr')]"));

        /// <summary>
        /// The text editor.
        /// </summary>
        public IWebElement TextEditor => this.driver.FindElement(By.XPath("//body[@id = 'tinymce']"));

        /// <summary>
        /// The button to send the letter.
        /// </summary>
        public IWebElement SendLetterButton => this.driver.FindElement(By.XPath("//div[@data-name='send']"));

        /// <summary>
        /// The button for returning to inbox.
        /// </summary>
        public IWebElement ReturnToInboxButton => this.driver.FindElement(By.XPath("//a[@rel='history']"));

        /// <summary>
        /// Initializes a new instance of the WriteNewLetterPage class.
        /// </summary>
        /// <param name="driver">
        /// The WebDriver.
        /// </param>
        public WriteNewLetterPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Writes and sends a new letter.
        /// </summary>
        /// <param name="recipient">
        /// The recipient.
        /// </param>
        /// <param name="text">
        /// The text of the letter.
        /// </param>
        /// <returns>
        /// The MailInboxPage.
        /// </returns>
        public MailInboxPage SendLetter(string recipient, string text)
        {
            this.Recipient.SendKeys(recipient);
            this.driver.SwitchTo().Frame(this.EditorFrame);
            this.TextEditor.Clear();
            this.TextEditor.SendKeys(text);
            this.driver.SwitchTo().DefaultContent();
            this.SendLetterButton.Click();
            this.ReturnToInboxButton.Click();

            return new MailInboxPage(this.driver);
        }
    }
}