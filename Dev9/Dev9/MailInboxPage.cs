using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Dev9
{
    /// <summary>
    /// Inbox page.
    /// </summary>
    public class MailInboxPage
    {
        /// <summary>
        /// The WebDriver.
        /// </summary>
        private IWebDriver driver;

        /// <summary>
        /// The button for writing a new letter.
        /// </summary>
        public IWebElement WriteNewLetterButton => this.driver.FindElement(By.XPath("//a[@data-name='compose']"));

        /// <summary>
        /// The latest mail in the inbox.
        /// </summary>
        public List<IWebElement> Mails => this.driver.FindElements(By.XPath("//div[@class='b-datalist__body']/div")).ToList();

        /// <summary>
        /// Initializes a new instance of the MailInboxPage class.
        /// </summary>
        /// <param name="driver">
        /// The WebDriver.
        /// </param>
        public MailInboxPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Proceed to the writing of a new letter.
        /// </summary>
        /// <returns>
        /// The WriteNewLetterPage.
        /// </returns>
        public WriteNewLetterPage WriteNewLetter()
        {
            this.WriteNewLetterButton.Click();

            return new WriteNewLetterPage(this.driver);
        }

        /// <summary>
        /// Goes to the reading page for the mail.
        /// </summary>
        /// <param name="mail">
        /// The mail to read.
        /// </param>
        /// <returns>
        /// The MailReadPage.
        /// </returns>
        public MailReadPage ReadMail(IWebElement mail)
        {
            mail.Click();

            return new MailReadPage(this.driver);
        }
    }
}