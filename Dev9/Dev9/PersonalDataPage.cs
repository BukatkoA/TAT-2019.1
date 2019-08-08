using OpenQA.Selenium;

namespace Dev9
{
    /// <summary>
    /// The personal data page.
    /// </summary>
    public class PersonalDataPage
    {
        /// <summary>
        /// The WebDriver.
        /// </summary>
        private IWebDriver driver;

        /// <summary>
        /// The nickname box.
        /// </summary>
        public IWebElement NicknameBox => this.driver.FindElement(By.XPath("//input[@id='NickName']"));

        /// <summary>
        /// The submit button.
        /// </summary>
        public IWebElement SubmitButton => this.driver.FindElement(By.XPath("//span[text() = 'Сохранить']"));

        /// <summary>
        /// Initializes a new instance of the PersonalDataPage class.
        /// </summary>
        /// <param name="driver">
        /// The WebDriver.
        /// </param>
        public PersonalDataPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// The change nickname.
        /// </summary>
        /// <param name="newNickname">
        /// The new nickname.
        /// </param>
        /// <returns>
        /// The PersonalDataPage.
        /// </returns>
        public PersonalDataPage ChangeNickname(string newNickname)
        {
            this.NicknameBox.Clear();
            this.NicknameBox.SendKeys(newNickname);
            this.SubmitButton.Click();
            // Return to the userdata page
            this.driver.FindElement(By.XPath("//a[@data-name='userinfo']")).Click();

            return this;
        }
    }
}