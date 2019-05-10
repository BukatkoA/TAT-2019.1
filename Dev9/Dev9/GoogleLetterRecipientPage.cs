using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Dev9
{
    /// <summary>
    /// Class for reading letter
    /// </summary>
    public class GoogleLetterRecipientPage
    {
        IWebDriver Driver { get; set; }
        private IWebElement Nickname { get; set; }
        private IWebElement Profile { get; set; }
        private IWebElement Settings { get; set; }

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        public GoogleLetterRecipientPage()
        {
            this.Driver = new ChromeDriver();
        }

        /// <summary>
        /// Gets text of message
        /// </summary>
        /// <returns>Received text</returns>
        public string GetNicknameFromLetter()
        {
            this.Nickname = this.Driver.FindElement(By.XPath("//span[@class = 'y2']"), 10);

            return this.Nickname.Text;
        }

        /// <summary>
        /// Opens settings
        /// </summary>
        /// <returns>Mail settings page</returns>
        public GoogleSettingsPage GoToSetting()
        {
            this.Profile = this.Driver.FindElement(By.XPath("//a[@class = 'gb_x gb_Da gb_f']"), 10);
            this.Profile.Click();
            this.Settings = this.Driver.FindElement(By.XPath("//a[@class = 'gb_0 gb_zf gbp1 gb_ke gb_kb']"), 10);
            this.Settings.Click();

            return new GoogleSettingsPage(this.Driver);
        }
    }
}