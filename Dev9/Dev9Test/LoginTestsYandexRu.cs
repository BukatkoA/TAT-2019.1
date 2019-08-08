using Dev9;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Dev9Test
{
    /// <summary>
    /// Tests for logging in on Yandex.
    /// </summary>
    [TestFixture]
    public class LoginTestsYandex
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
            this.driver = new ChromeDriver { Url = "https://yandex.by" };
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
            var username = "testusername2112";
            var password = "Testpassword2821";
            var mailPage = homePage.Login(username, password);
            Assert.True(mailPage.WriteNewLetterButton.Displayed);
        }

        /// <summary>
        /// Negative test for logging in:
        /// wrong id, results in error message.
        /// Combines test for empty username: impossible to proceed without entering one.
        /// </summary>
        [Test]
        public void Login_EmptyInput_ErrorMessage()
        {
            var homePage = new HomePage(this.driver);
            homePage.Login_ExpectingError(string.Empty, string.Empty);
            Assert.AreEqual("Логин не указан", homePage.ErrorMessage.Text);
        }

        /// <summary>
        /// Negative test for logging in:
        /// empty password, results in error message.
        /// </summary>
        [Test]
        public void Login_EmptyPassword_ErrorMessage()
        {
            var homePage = new HomePage(this.driver);
            var username = "testusername9989";
            var password = string.Empty;
            homePage.Login_ExpectingError(username, password);
            Assert.AreEqual("Пароль не указан", homePage.ErrorMessage.Text);
        }

        /// <summary>
        /// Negative test for logging in:
        /// wrong username, results in error message.
        /// Combines test for wrong id: login operation won't proceed unless username is correct.
        /// </summary>
        [Test]
        public void Login_WrongUsername_ErrorMessage()
        {
            var homePage = new HomePage(this.driver);
            var username = "tsetsuusuus12123";
            var password = string.Empty;
            homePage.Login_ExpectingError(username, password);
            Assert.AreEqual("Такого аккаунта нет", homePage.ErrorMessage.Text);
        }

        /// <summary>
        /// Negative test for logging in:
        /// wrong password, results in error message.
        /// </summary>
        [Test]
        public void Login_WrongPassword_ErrorMessage()
        {
            var homePage = new HomePage(this.driver);
            var username = "testusername21123";
            var password = "testpassword21";
            homePage.Login_ExpectingError(username, password);
            Assert.AreEqual("Неверный пароль", homePage.ErrorMessage.Text);
        }

        /// <summary>
        /// Tear down: closes the driver.
        /// </summary>
        [TearDown]
        public void CloseBrowser()
        {
            this.driver.Quit();
        }
    }
}