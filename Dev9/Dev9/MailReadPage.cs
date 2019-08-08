using OpenQA.Selenium;

namespace Dev9
{
    /// <summary>
    /// Page for reading letters.
    /// </summary>
    public class MailReadPage
    {
        /// <summary>
        /// The WebDriver.
        /// </summary>
        private IWebDriver driver;

        /// <summary>
        /// Text of the mail.
        /// </summary>
        /// <remarks>
        /// Each new line is a new child div.
        /// In replies this also captures quote of the original letter.
        /// </remarks>
        public IWebElement MailText => this.driver.FindElement(By.XPath("//div[@class = 'js-helper js-readmsg-msg']/div/div/div")); ////TODO improve?

        /// <summary>
        /// The profile button.
        /// </summary>
        public IWebElement ProfileButton => this.driver.FindElement(By.XPath("//i[@id = 'PH_user-email']"));

        /// <summary>
        /// The settings button.
        /// </summary>
        public IWebElement PersonalDataButton => this.driver.FindElement(By.XPath("//span[text() = 'Личные данные']"));

        /// <summary>
        /// Initializes a new instance of the MailReadPage class. 
        /// </summary>
        /// <param name="driver">
        /// The WebDriver.
        /// </param>
        public MailReadPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Go to personal data page.
        /// </summary>
        /// <returns>
        /// The PersonalDataPage.
        /// </returns>
        public PersonalDataPage GoToPersonalDataPage()
        {
            this.ProfileButton.Click();
            this.PersonalDataButton.Click();

            return new PersonalDataPage(this.driver);
        }
    }
}