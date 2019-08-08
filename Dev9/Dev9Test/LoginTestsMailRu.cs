using Dev9;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace DevTask9Tests
{
    /// <summary>
    /// Tests for logging in on Mail.ru.
    /// </summary>
    [TestFixture]
    public class LoginTestsMailRu
    {
        /// <summary>
        /// The WebDriver instance for tests.
        /// </summary>
        private IWebDriver driver;

        /// <summary>
        /// Set up: initializes the WebDriver. Sets the URL and implicit timer.
        /// </summary>
        [SetUp]
        public void StartBrowser()
        {
            this.driver = new ChromeDriver { Url = "https://mail.ru" };
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        /// <summary>
        /// Positive test for logging in:
        /// entering the correct ID.
        /// Moves user to the mail page.
        /// </summary>
        [Test]
        public void Login_CorrectId_Proceed()
        {
            var homePage = new HomePage(this.driver);
            var username = "testusername919";
            var password = "Testpass441";
            var mailPage = homePage.Login(username, password);
            Assert.True(mailPage.WriteNewLetterButton.Displayed);
        }

        /// <summary>
        /// Negative test for logging in:
        /// empty input, results in error message.
        /// </summary>
        [Test]
        public void Login_EmptyInput_ErrorMessage()
        {
            var homePage = new HomePage(this.driver);
            homePage.Login_ExpectingError(string.Empty, string.Empty);
            Assert.AreEqual("Введите имя ящика и пароль", homePage.ErrorMessage.Text);
        }

        /// <summary>
        /// Negative test for logging in:
        /// empty username, results in error message.
        /// </summary>
        [Test]
        public void Login_EmptyUsername_ErrorMessage()
        {
            var homePage = new HomePage(this.driver);
            homePage.Login_ExpectingError(string.Empty, "test");
            Assert.AreEqual("Введите имя ящика", homePage.ErrorMessage.Text);
        }

        /// <summary>
        /// Negative test for logging in:
        /// empty password, results in error message.
        /// </summary>
        [Test]
        public void Login_EmptyPassword_ErrorMessage()
        {
            var homePage = new HomePage(this.driver);
            homePage.Login_ExpectingError("testusername2112", string.Empty);
            Assert.AreEqual("Введите пароль", homePage.ErrorMessage.Text);
        }

        /// <summary>
        /// Negative test for logging in:
        /// wrong id or password, results in error message.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        [TestCase("testusername2112", "testing")]
        [TestCase("testusername919", "testing")]
        public void Login_WrongIdOrPassword_ErrorMessage(string username, string password)
        {
            var homePage = new HomePage(this.driver);
            homePage.Login_ExpectingError(username, password);
            Assert.AreEqual("Неверное имя или пароль", homePage.ErrorMessage.Text);
        }

        /// <summary>
        /// Tear down: close the driver.
        /// </summary>
        [TearDown]
        public void CloseBrowser()
        {
            this.driver.Quit();
        }
    }
}