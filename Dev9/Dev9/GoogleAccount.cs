using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Dev9
{
    /// <summary>
    /// Class for logging
    /// </summary>
    public class GoogleAccount
    {
        IWebDriver Driver { get; }
        IWebElement Login { get; set; }
        IWebElement Password { get; set; }
        IWebElement LoginButton { get; set; }
        GoogleLocators.LoginPageLocator Locator { get; }

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        public GoogleAccount()
        {
            this.Driver = new ChromeDriver();
            this.Locator = new GoogleLocators.LoginPageLocator();
        }

        /// <summary>
        /// Method goes to start page of mail.
        /// </summary>
        public void GoToUrl() => this.Driver.Navigate().GoToUrl(this.Locator.PageLocator);

        /// <summary>
        /// Logins to google account
        /// </summary>
        /// <param name="login">Account login</param>
        /// <param name="password">Account password</param>
        /// <returns>Google main page</returns>
        public MainGooglePage LogInPage(string login, string password)
        {
            this.Login = this.Driver.FindElement(By.XPath(this.Locator.LoginLocator), 10000);
            this.Login.SendKeys(login);
            this.LoginButton = this.Driver.FindElement(By.XPath(this.Locator.LoginButtonLocator), 10000);
            this.LoginButton.Click();
            this.Password = this.Driver.FindElement(By.XPath(this.Locator.PasswordLocator), 10000);
            this.Password.SendKeys(password);
            this.LoginButton = this.Driver.FindElement(By.XPath(this.Locator.LoginButtonLocator), 10000);
            this.LoginButton.Click();

            return new MainGooglePage(this.Driver);
        }
    }
}