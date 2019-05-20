using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Dev9
{
    /// <summary>
    /// Class for logging
    /// </summary>
    public class MailRuAccount
    {
        IWebDriver Driver { get; }
        IWebElement Login { get; set; }
        IWebElement Password { get; set; }
        IWebElement LoginButton { get; set; }
        MailRuLocators.LoginPageLocator Locator { get; }

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="driver">WebDriver</param>
        public MailRuAccount(IWebDriver driver)
        {
            this.Driver = driver;
            this.Locator = new MailRuLocators.LoginPageLocator();
        }

        /// <summary>
        /// Method goes to start page of mail.
        /// </summary>
        public void GoToUrl() => this.Driver.Navigate().GoToUrl(this.Locator.PageLocator);

        /// <summary>
        /// Logins to Mail ru account
        /// </summary>
        /// <param name="login">Account login</param>
        /// <param name="password">Account password</param>
        /// <returns>Mail ru main page</returns>
        public MainMailRuPage LogInPage(string login, string password)
        {
            this.Login = this.Driver.FindElement(By.XPath(this.Locator.LoginLocator), 10000);
            this.Login.SendKeys(login);
            this.Password = this.Driver.FindElement(By.XPath(this.Locator.PasswordLocator), 10000);
            this.Password.SendKeys(password);
            this.LoginButton = this.Driver.FindElement(By.XPath(this.Locator.LoginButtonLocator), 10000);
            this.LoginButton.Click();

            return new MainMailRuPage(this.Driver);
        }
    }
}