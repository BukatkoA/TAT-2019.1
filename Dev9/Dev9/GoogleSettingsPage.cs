using OpenQA.Selenium;

namespace Dev9
{
    public class GoogleSettingsPage
    {
        private IWebDriver Driver { get; set; }
        private IWebElement Nickname { get; set; }
        private IWebElement ChangeNickname { get; set; }
        private IWebElement SelectNickname { get; set; }
        private IWebElement ChangeUserNickname { get; set; }
        private IWebElement UserName { get; set; }
        private IWebElement SaveButton { get; set; }

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="driver">WebDriver</param>
        public GoogleSettingsPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// Changes nickname of account
        /// </summary>
        /// <param name="newNickname">New nickname</param>
        public void ChangeUserName(string newNickname)
        {
            this.ChangeUserNickname = this.Driver.FindElement(By.XPath("//div[@class = 'GiKO7c']"), 10);
            this.ChangeUserNickname.Click();
            this.UserName = this.Driver.FindElement(By.XPath("//a[@class = 'VZLjze Wvetm N5YmOc kJXJmd']"), 10);
            this.UserName.Click();
            this.SelectNickname = this.Driver.FindElement(By.XPath("//a[@class = 'VZLjze Wvetm N5YmOc kJXJmd']"), 10);
            this.SelectNickname.Click();
            this.ChangeNickname = this.Driver.FindElement(By.XPath("//span[@class = 'DPvwYc gPVQ']"), 10);
            this.ChangeNickname.Click();
            this.Nickname = this.Driver.FindElement(By.XPath("//input[@class = 'whsOnd zHQkBf']"), 10);
            this.Nickname.Click();
            this.Nickname.Clear();
            this.Nickname.SendKeys(newNickname);
            this.SaveButton = this.Driver.FindElement(By.XPath("//span[text() = 'Готово']"), 10);
            this.SaveButton.Click();
        }
    }
}