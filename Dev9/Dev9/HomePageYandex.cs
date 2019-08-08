using OpenQA.Selenium;

namespace Dev9
{
    /// <summary>
    /// The home page.
    /// Signing in is done here.
    /// </summary>
    public class HomePageYandex
    {
        /// <summary>
        /// The WebDriver.
        /// </summary>
        private IWebDriver driver;

        /// <summary>
        /// The button to initiate signing in.
        /// </summary>
        public IWebElement LoginStartButton => this.driver.FindElement(By.XPath("//a[contains(@class,'button desk-notif-card__login-enter-expanded')]"));

        /// <summary>
        /// The username box.
        /// </summary>
        public IWebElement UsernameBox => this.driver.FindElement(By.XPath("//input[@name='login']"));

        /// <summary>
        /// The password box.
        /// </summary>
        public IWebElement PasswordBox => this.driver.FindElement(By.XPath("//input[@name='passwd']"));

        /// <summary>
        /// The button for proceeding with the login procedure.
        /// </summary>
        public IWebElement LoginProceedButton => this.driver.FindElement(By.XPath("//button[@type='submit']"));

        /// <summary>
        /// The login error message.
        /// </summary>
        public IWebElement ErrorMessage => this.driver.FindElement(By.XPath("//div[@class='passp-form-field__error']"));

        /// <summary>
        /// Initializes a new instance of the HomePage class.
        /// </summary>
        /// <param name="driver">
        /// The WebDriver.
        /// </param>
        public HomePageYandex(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Method for logging in with provided credentials.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// The HomePage.
        /// </returns>
        public MailInboxPage Login(string username, string password)
        {
            this.LoginStartButton.Click();
            this.UsernameBox.SendKeys(username);
            this.LoginProceedButton.Click();
            this.PasswordBox.SendKeys(password);
            this.LoginProceedButton.Click();

            return new MailInboxPage(this.driver);
        }

        /// <summary>
        /// Method for logging in with provided credentials.
        /// For testing wrong/empty inputs only.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// Remains on this HomePage.
        /// </returns>
        public HomePageYandex Login_ExpectingError(string username, string password)
        {
            this.LoginStartButton.Click();
            this.UsernameBox.SendKeys(username);
            this.LoginProceedButton.Click();
            if (this.driver.FindElements(By.XPath("//div[@class='passp-form-field__error']")).Count == 0)
            {
                this.PasswordBox.SendKeys(password);
                this.LoginProceedButton.Click();
            }

            return this;
        }
    }
}